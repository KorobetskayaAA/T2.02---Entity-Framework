using Microsoft.EntityFrameworkCore.Migrations;

namespace MurrrcatConsoleCodeFirst.Migrations
{
    public partial class ChangeTableNameInFluetnApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatCategory_Categories_CategoriesId",
                table: "CatCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CatCategory_Cats_CatsId",
                table: "CatCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Owners_OwnerId",
                table: "Cats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cats",
                table: "Cats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatCategory",
                table: "CatCategory");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameTable(
                name: "Cats",
                newName: "Cat");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "CatCategory",
                newName: "Cat_Category");

            migrationBuilder.RenameIndex(
                name: "IX_Cats_OwnerId",
                table: "Cat",
                newName: "IX_Cat_OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_CatCategory_CatsId",
                table: "Cat_Category",
                newName: "IX_Cat_Category_CatsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat",
                table: "Cat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cat_Category",
                table: "Cat_Category",
                columns: new[] { "CategoriesId", "CatsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Owner_OwnerId",
                table: "Cat",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Category_Cat_CatsId",
                table: "Cat_Category",
                column: "CatsId",
                principalTable: "Cat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat_Category_Category_CategoriesId",
                table: "Cat_Category",
                column: "CategoriesId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Owner_OwnerId",
                table: "Cat");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Category_Cat_CatsId",
                table: "Cat_Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Cat_Category_Category_CategoriesId",
                table: "Cat_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat_Category",
                table: "Cat_Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cat",
                table: "Cat");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Cat_Category",
                newName: "CatCategory");

            migrationBuilder.RenameTable(
                name: "Cat",
                newName: "Cats");

            migrationBuilder.RenameIndex(
                name: "IX_Cat_Category_CatsId",
                table: "CatCategory",
                newName: "IX_CatCategory_CatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Cat_OwnerId",
                table: "Cats",
                newName: "IX_Cats_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatCategory",
                table: "CatCategory",
                columns: new[] { "CategoriesId", "CatsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cats",
                table: "Cats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatCategory_Categories_CategoriesId",
                table: "CatCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatCategory_Cats_CatsId",
                table: "CatCategory",
                column: "CatsId",
                principalTable: "Cats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Owners_OwnerId",
                table: "Cats",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
