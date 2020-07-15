using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MenuEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MenuId",
                table: "Meals");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "2b3bd95d-5256-4ac9-9fb0-82b3d1a338e5");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "2da7dce0-f0cd-4860-b848-9cb20d0dad59");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "552a180a-88c8-4bb5-b6e5-7b6185fb579e");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "74ad21db-d73f-4872-8298-d49a3e255431");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "a2f4bbf8-1269-45f4-85ee-d038e67e8f9a");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "a5ab403e-2e11-472c-a01c-134dc5c75927");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "e4a84bc4-e21c-4577-a2f5-7ab5892ec1b4");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "f7791d85-9275-47bc-9386-9e5029d50e38");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "763d9710-740e-4fcf-be5e-2fda79acbbf5");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "a9c92cba-5717-4236-826d-28fce855b3c0");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "ca573704-4345-481b-9761-96daa5f6c258");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "ef55e123-fae8-4464-9dce-21c317c6b20a");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Meals");

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "Menus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MenuId",
                table: "MealCategory",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MealCategory",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Image", "MenuId", "ModifiedAt" },
                values: new object[,]
                {
                    { "217bc187-8b57-4b5e-956f-dec1c113e5fa", "Soups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "soup.jpg", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "91418c8d-e2fa-4857-b022-1389609a5558", "Meals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "meal.jpg", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2b653674-6ea1-4ac4-bb11-6e3a47aebbf8", "Desserts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desserts.jpg", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "42b75f51-1435-4336-a9f1-6082d9989b25", "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "drinks.jpg", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MealCategoryId", "MealName", "ModifiedAt", "Price", "TimeForPrepare" },
                values: new object[,]
                {
                    { "28fdd8ff-08c2-45ec-be1c-aa07d897a95b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chicken.jpg", "217bc187-8b57-4b5e-956f-dec1c113e5fa", "Chicken soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "c02f3d14-6cb5-49f8-aba9-c68241fd33b3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish-soup.jpg", "217bc187-8b57-4b5e-956f-dec1c113e5fa", "Fish soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "e0311b12-2f46-4a3b-a628-5ac17a4eebae", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pizza.jpg", "91418c8d-e2fa-4857-b022-1389609a5558", "Pizza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "860bf0c3-7475-48a4-8e0a-964fb8cfedfe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish.jpg", "91418c8d-e2fa-4857-b022-1389609a5558", "Fish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "a8aac5e7-894f-4a0c-b510-3bb68c5052bf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cake.jpg", "2b653674-6ea1-4ac4-bb11-6e3a47aebbf8", "Cake", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "7df58bab-b678-46fb-99e6-4d33decaf780", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pancakes.jpg", "2b653674-6ea1-4ac4-bb11-6e3a47aebbf8", "Pancakes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "0698ef9f-3f3c-4a66-9bff-6a0af174e5ef", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wine.jpg", "42b75f51-1435-4336-a9f1-6082d9989b25", "Wine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "476d2f46-fdb3-439b-b2d4-4a90f0c372cf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "water.jpg", "42b75f51-1435-4336-a9f1-6082d9989b25", "Water", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealCategory_MenuId",
                table: "MealCategory",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealCategory_Menus_MenuId",
                table: "MealCategory",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealCategory_Menus_MenuId",
                table: "MealCategory");

            migrationBuilder.DropIndex(
                name: "IX_MealCategory_MenuId",
                table: "MealCategory");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "0698ef9f-3f3c-4a66-9bff-6a0af174e5ef");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "28fdd8ff-08c2-45ec-be1c-aa07d897a95b");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "476d2f46-fdb3-439b-b2d4-4a90f0c372cf");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "7df58bab-b678-46fb-99e6-4d33decaf780");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "860bf0c3-7475-48a4-8e0a-964fb8cfedfe");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "a8aac5e7-894f-4a0c-b510-3bb68c5052bf");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "c02f3d14-6cb5-49f8-aba9-c68241fd33b3");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "e0311b12-2f46-4a3b-a628-5ac17a4eebae");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "217bc187-8b57-4b5e-956f-dec1c113e5fa");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "2b653674-6ea1-4ac4-bb11-6e3a47aebbf8");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "42b75f51-1435-4336-a9f1-6082d9989b25");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "91418c8d-e2fa-4857-b022-1389609a5558");

            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MealCategory");

            migrationBuilder.AddColumn<string>(
                name: "MenuId",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MealCategory",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Image", "ModifiedAt" },
                values: new object[,]
                {
                    { "ef55e123-fae8-4464-9dce-21c317c6b20a", "Soups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "soup.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "763d9710-740e-4fcf-be5e-2fda79acbbf5", "Meals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "meal.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "ca573704-4345-481b-9761-96daa5f6c258", "Desserts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desserts.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "a9c92cba-5717-4236-826d-28fce855b3c0", "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "drinks.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MealCategoryId", "MealName", "MenuId", "ModifiedAt", "Price", "TimeForPrepare" },
                values: new object[,]
                {
                    { "a5ab403e-2e11-472c-a01c-134dc5c75927", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chicken.jpg", "ef55e123-fae8-4464-9dce-21c317c6b20a", "Chicken soup", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "a2f4bbf8-1269-45f4-85ee-d038e67e8f9a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish-soup.jpg", "ef55e123-fae8-4464-9dce-21c317c6b20a", "Fish soup", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "f7791d85-9275-47bc-9386-9e5029d50e38", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pizza.jpg", "763d9710-740e-4fcf-be5e-2fda79acbbf5", "Pizza", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "2b3bd95d-5256-4ac9-9fb0-82b3d1a338e5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish.jpg", "763d9710-740e-4fcf-be5e-2fda79acbbf5", "Fish", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "74ad21db-d73f-4872-8298-d49a3e255431", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cake.jpg", "ca573704-4345-481b-9761-96daa5f6c258", "Cake", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "e4a84bc4-e21c-4577-a2f5-7ab5892ec1b4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pancakes.jpg", "ca573704-4345-481b-9761-96daa5f6c258", "Pancakes", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "2da7dce0-f0cd-4860-b848-9cb20d0dad59", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wine.jpg", "a9c92cba-5717-4236-826d-28fce855b3c0", "Wine", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "552a180a-88c8-4bb5-b6e5-7b6185fb579e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "water.jpg", "a9c92cba-5717-4236-826d-28fce855b3c0", "Water", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MenuId",
                table: "Meals",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Menus_MenuId",
                table: "Meals",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
