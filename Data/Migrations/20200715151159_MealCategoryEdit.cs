using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MealCategoryEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "056aea55-91e3-4324-bff1-7b8302fc70a9");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "3b2d020d-fabb-4ff9-939c-92b5198f5230");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "65c99f3d-5226-4e9e-be18-0479793fc042");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "665dd055-fd88-4047-9b83-45a8626e1fc7");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "6bb8dafc-a22c-42d8-971d-057b3e9d21a2");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "a24616fe-b818-4b12-9c8e-9a48329c0c5d");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "b6d60791-54c0-4fc5-bcbe-3a658046dab6");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "cbfa45dc-6d4f-4cdd-ae88-1d0368db7099");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "3bd9417f-8196-4076-8a9f-3d8987cd4d90");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "54f661d1-73ae-4de5-b5bb-1ce0c68094a5");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "6982c492-f782-45f6-8e73-3f5330eb4c10");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "fce72683-49f9-4164-bfe3-6a118a7eb0fc");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MealCategory",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Image",
                table: "MealCategory");

            migrationBuilder.InsertData(
                table: "MealCategory",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "ModifiedAt" },
                values: new object[,]
                {
                    { "3bd9417f-8196-4076-8a9f-3d8987cd4d90", "Soups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "fce72683-49f9-4164-bfe3-6a118a7eb0fc", "Meals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "54f661d1-73ae-4de5-b5bb-1ce0c68094a5", "Desserts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6982c492-f782-45f6-8e73-3f5330eb4c10", "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MealCategoryId", "MealName", "MenuId", "ModifiedAt", "Price", "TimeForPrepare" },
                values: new object[,]
                {
                    { "65c99f3d-5226-4e9e-be18-0479793fc042", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "3bd9417f-8196-4076-8a9f-3d8987cd4d90", "Chicken soup", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "cbfa45dc-6d4f-4cdd-ae88-1d0368db7099", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "3bd9417f-8196-4076-8a9f-3d8987cd4d90", "Fish soup", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "3b2d020d-fabb-4ff9-939c-92b5198f5230", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fce72683-49f9-4164-bfe3-6a118a7eb0fc", "Pizza", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "056aea55-91e3-4324-bff1-7b8302fc70a9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fce72683-49f9-4164-bfe3-6a118a7eb0fc", "Fish", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "6bb8dafc-a22c-42d8-971d-057b3e9d21a2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "54f661d1-73ae-4de5-b5bb-1ce0c68094a5", "Cake", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "a24616fe-b818-4b12-9c8e-9a48329c0c5d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "54f661d1-73ae-4de5-b5bb-1ce0c68094a5", "Pancakes", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "b6d60791-54c0-4fc5-bcbe-3a658046dab6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "6982c492-f782-45f6-8e73-3f5330eb4c10", "Vine", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "665dd055-fd88-4047-9b83-45a8626e1fc7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "6982c492-f782-45f6-8e73-3f5330eb4c10", "Water", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null }
                });
        }
    }
}
