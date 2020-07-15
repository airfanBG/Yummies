using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class MenuMealCategory_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "MenuId",
                table: "MealCategory");

            migrationBuilder.CreateTable(
                name: "MenuMealCategory",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    MenuId = table.Column<string>(nullable: true),
                    MealCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMealCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuMealCategory_MealCategory_MealCategoryId",
                        column: x => x.MealCategoryId,
                        principalTable: "MealCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuMealCategory_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MealCategory",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Image", "ModifiedAt" },
                values: new object[,]
                {
                    { "ba8602bc-e7ff-4b95-a9ba-2739dcf70637", "Soups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "soup.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "c31328fc-5f5e-464d-97b8-d5cf4bde93ec", "Meals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "meal.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "0bd45854-232e-4be1-824c-79ea572563f6", "Desserts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desserts.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "e121636a-da9a-4f84-a2b9-407b6e583e1c", "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "drinks.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "MenuName", "ModifiedAt" },
                values: new object[] { "82b064a1-0b78-4fa2-82e9-d8aef78c10db", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Standard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MealCategoryId", "MealName", "ModifiedAt", "Price", "TimeForPrepare" },
                values: new object[,]
                {
                    { "d5a03b9c-bddb-484e-a5ef-2bba786b1901", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chicken.jpg", "ba8602bc-e7ff-4b95-a9ba-2739dcf70637", "Chicken soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "7005f56f-6cb6-4114-b1d2-79c3287b7d79", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish-soup.jpg", "ba8602bc-e7ff-4b95-a9ba-2739dcf70637", "Fish soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "026829cf-c8aa-4138-a0c9-d4e45a03dbc5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pizza.jpg", "c31328fc-5f5e-464d-97b8-d5cf4bde93ec", "Pizza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "a43da5f6-1a65-472c-ba45-56e0d9f3bad9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish.jpg", "c31328fc-5f5e-464d-97b8-d5cf4bde93ec", "Fish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "259c4d40-7cda-4dd8-b42b-0e0fe8790ac3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cake.jpg", "0bd45854-232e-4be1-824c-79ea572563f6", "Cake", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "f51d80b6-1622-4871-b651-28db9f788717", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pancakes.jpg", "0bd45854-232e-4be1-824c-79ea572563f6", "Pancakes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "3aa7e09e-c4ba-4142-803e-f66a75cbc6c4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wine.jpg", "e121636a-da9a-4f84-a2b9-407b6e583e1c", "Wine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "eb0c3551-a586-4d52-a0f4-5a55f848033f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "water.jpg", "e121636a-da9a-4f84-a2b9-407b6e583e1c", "Water", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null }
                });

            migrationBuilder.InsertData(
                table: "MenuMealCategory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "MealCategoryId", "MenuId", "ModifiedAt" },
                values: new object[,]
                {
                    { "64abb715-50e8-4e8d-a253-de67640dd26e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ba8602bc-e7ff-4b95-a9ba-2739dcf70637", "82b064a1-0b78-4fa2-82e9-d8aef78c10db", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "243bb118-4315-4460-969f-163965bda0b1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c31328fc-5f5e-464d-97b8-d5cf4bde93ec", "82b064a1-0b78-4fa2-82e9-d8aef78c10db", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "cf0e341a-f79d-4016-9502-de8a5da3a4b7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "0bd45854-232e-4be1-824c-79ea572563f6", "82b064a1-0b78-4fa2-82e9-d8aef78c10db", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuMealCategory_MealCategoryId",
                table: "MenuMealCategory",
                column: "MealCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuMealCategory_MenuId",
                table: "MenuMealCategory",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuMealCategory");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "026829cf-c8aa-4138-a0c9-d4e45a03dbc5");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "259c4d40-7cda-4dd8-b42b-0e0fe8790ac3");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "3aa7e09e-c4ba-4142-803e-f66a75cbc6c4");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "7005f56f-6cb6-4114-b1d2-79c3287b7d79");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "a43da5f6-1a65-472c-ba45-56e0d9f3bad9");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "d5a03b9c-bddb-484e-a5ef-2bba786b1901");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "eb0c3551-a586-4d52-a0f4-5a55f848033f");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "f51d80b6-1622-4871-b651-28db9f788717");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: "82b064a1-0b78-4fa2-82e9-d8aef78c10db");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "0bd45854-232e-4be1-824c-79ea572563f6");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "ba8602bc-e7ff-4b95-a9ba-2739dcf70637");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "c31328fc-5f5e-464d-97b8-d5cf4bde93ec");

            migrationBuilder.DeleteData(
                table: "MealCategory",
                keyColumn: "Id",
                keyValue: "e121636a-da9a-4f84-a2b9-407b6e583e1c");

            migrationBuilder.AddColumn<string>(
                name: "MenuId",
                table: "MealCategory",
                type: "nvarchar(450)",
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
    }
}
