using MurrcatConsole.MurrcatModel;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections.Generic;

namespace MurrcatConsole
{
    class Program
    {
        static readonly string connectionString;
        static Program()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();
            string userId = "", password = "";
            config.Providers.Any(p => p.TryGet("MurrrcatDb:UserId", out userId));
            config.Providers.Any(p => p.TryGet("MurrrcatDb:Password", out password));
            connectionString = string.Format(
                config.GetConnectionString("DefaultConnection"),
                userId, password
            );
        }

        static void Main(string[] args)
        {
            PrintCatalog();
            Console.WriteLine();

            string id = "murzik";
            PrintCat(id);
            PrintCat(id, FindCatWithOwner(id));
            Console.WriteLine();

            PrintByCategoryName("Кот");
            Console.WriteLine();

            PrintByCategoryName("Пушистый");
            Console.WriteLine();

            var newCatId = "zhenya";
            Cat newCat = CreateCat(newCatId, "Женя", 100.0m, 3);

            PrintCat(newCatId);
            ChangePrice(newCat, 120m);

            PrintCat(newCatId);
            ChangePrice(newCatId, 150m);

            PrintCat(newCatId);
            DeleteCat(newCatId);

            PrintCatalog();
            Console.WriteLine();

            var catToUpdate = FindCatWithOwner("murchik");
            catToUpdate.Description = "Мурчливый котенок";
            catToUpdate.Price = 123456m;
            var catCategories = new List<int>()
            {
                1, 3, 16
            };
            UpdateCatWithCategories(catToUpdate, catCategories, new Owner() { Id = 2 });
            PrintCat("murchik");
        }

        private static MurrrcatContext CreateMurrrcatContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MurrrcatContext>();
            var options = optionsBuilder
                    .UseSqlServer(connectionString)
                    .Options;
            return new MurrrcatContext(options);
        }

        private static void PrintCatalog()
        {
            using (var context = CreateMurrrcatContext())
            {
                var cats = context.Cats.ToList();
                Console.WriteLine("Котолог:");
                foreach (var cat in cats)
                {
                    Console.WriteLine($"{cat.Name} стоит {cat.Price:N2} руб.");
                }
            }
        }

        private static void PrintCat(string id)
        {
            using (var context = CreateMurrrcatContext())
            {
                var cat = context.Cats.Find(id);
                if (cat == null)
                {
                    Console.WriteLine($"{id} в котологе не найден");
                }
                else
                {
                    var catCategories = context.CatCategories
                        .Where(cc => cc.Cat == id)
                        .Select(cc => cc.CategoryNavigation.Name)
                        .ToList();
                    var catOwner = context.Owners.Find(cat.Owner);
                    Console.WriteLine($"{id}: зовут {cat.Name}, стоит {cat.Price:N2} руб.");
                    Console.WriteLine("Описание: " + cat.Description);
                    Console.WriteLine("Владелец: " + catOwner?.Name);
                    Console.WriteLine("Категории: " + string.Join(", ", catCategories));
                }
            }
        }

        private static Cat FindCatWithOwner(string id)
        {
            using (var context = CreateMurrrcatContext())
            {
                var cat = context.Cats
                    .Include(cat => cat.OwnerNavigation)
                    .FirstOrDefault(cat => cat.Id == id);
                return cat;
            }
        }

        private static void PrintCat(string id, Cat cat)
        {
            if (cat == null)
            {
                Console.WriteLine($"{id} в котологе не найден");
            }
            else
            {
                Console.WriteLine($"{id}: зовут {cat.Name}, стоит {cat.Price:N2} руб.");
                Console.WriteLine("Описание: " + cat.Description);
                Console.WriteLine("Владелец: " + cat.OwnerNavigation.Name);
            }
        }

        private static void PrintByCategoryName(string category)
        {
            using (var context = CreateMurrrcatContext())
            {
                if (!context.Categories.Any(c => c.Name == category))
                {
                    Console.WriteLine($"Категория {category} не существует");
                    return;
                }
                var catsInCategory = context.CatCategories
                    .Where(c => c.CategoryNavigation.Name == category)
                    .Select(c => c.CatNavigation)
                    .ToArray();
                if (catsInCategory.Length == 0)
                {
                    Console.WriteLine($"В категории {category} ничего не найдено");
                }
                else
                {
                    Console.WriteLine($"Категория {category}:");
                    foreach (var cat in catsInCategory)
                    {
                        Console.WriteLine($"{cat.Name} стоит {cat.Price:N2} руб.");
                    }
                }
            }
        }

        private static Cat CreateCat(string id, string name, decimal price, int ownerId)
        {
            Cat newCat = new Cat()
            {
                Id = id,
                Name = name,
                Price = price,
                OldPrice = price,
                Owner = ownerId
            };

            using (var context = CreateMurrrcatContext())
            {
                context.Cats.Add(newCat);
                context.SaveChanges();
            }

            return newCat;
        }

        private static bool ChangePrice(string id, decimal newPrice)
        {
            using (var context = CreateMurrrcatContext())
            {
                var cat = context.Cats.Find(id);
                if (cat == null)
                { 
                    return false;
                }
                cat.OldPrice = cat.Price;
                cat.Price = newPrice;
                context.SaveChanges();
            }

            return true;
        }

        private static bool ChangePrice(Cat cat, decimal newPrice)
        {
            using (var context = CreateMurrrcatContext())
            {
                if (cat == null)
                {
                    return false;
                }
                context.Update(cat);
                cat.OldPrice = cat.Price;
                cat.Price = newPrice;
                context.SaveChanges();
            }

            return true;
        }

        private static bool DeleteCat(string id)
        {

            using (var context = CreateMurrrcatContext())
            {
                var cat = context.Cats.Find(id);
                if (cat == null)
                {
                    return false;
                }
                context.Cats.Remove(cat);
                context.SaveChanges();
            }

            return true;
        }



        private static bool UpdateCatWithCategories(Cat cat, IEnumerable<int> categoryIds, 
            Owner owner)
        {
            using var context = CreateMurrrcatContext();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                cat.Owner = owner.Id;
                cat.OwnerNavigation = null;
                context.Update(cat);
                context.SaveChanges();

                var categoriesToRemove = context.CatCategories
                    .Where(cc => cc.Cat == cat.Id && !categoryIds.Any(cId => cc.Category == cId))
                    .ToList();
                context.CatCategories.RemoveRange(categoriesToRemove);
                context.SaveChanges();

                var newCategories = categoryIds
                    .Where(cId => !context.CatCategories.Any(cc => cc.Cat == cat.Id && cc.Category == cId))
                    .Select(cId => new CatCategory() { Cat = cat.Id, Category = cId })
                    .ToList();
                context.CatCategories.AddRange(newCategories);
                context.SaveChanges();

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                transaction.Rollback();
            }
            return false;
        }
    }
}
