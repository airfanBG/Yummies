using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMealCategory_MealCategories_MealCategoryId",
                table: "MenuMealCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMealCategory_Menus_MenuId",
                table: "MenuMealCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMealCategory",
                table: "MenuMealCategory");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "1959bb65-7511-4b00-b873-fc13f7bc299b");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "23985511-e6a9-479c-873a-53318379cd87");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "4c7c9de5-3a17-448c-81d8-b79b69ce9afb");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "91e27a54-436b-4bc8-b44a-516c94a9b232");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "b561d40b-3ad1-4941-8e3c-6f2c2d20c04f");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "cbbb3dde-80fc-446d-b266-2fb82143573b");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "eb2cfce0-93fb-42aa-b16f-e6ff621832c1");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "ef398678-88cd-4706-8a1f-337c81191b71");

            migrationBuilder.DeleteData(
                table: "MenuMealCategory",
                keyColumn: "Id",
                keyValue: "0584c6bf-f8e9-4d51-b468-1fac9d9aa4bc");

            migrationBuilder.DeleteData(
                table: "MenuMealCategory",
                keyColumn: "Id",
                keyValue: "57acf76c-662c-4687-b8c6-3bd5ced26730");

            migrationBuilder.DeleteData(
                table: "MenuMealCategory",
                keyColumn: "Id",
                keyValue: "9f9caf33-e009-4867-9069-5ed12564cdb2");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "0c8947a9-f4a0-4fad-ac12-9f0dfe4e73e7");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "24de350d-b80c-4a55-b367-85720f77e47e");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "37cf9c62-6912-4c7b-a48f-aa3e698641cb");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "bfb9bb67-51ae-491e-a1a6-5341e6c81a2d");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: "16917117-3990-4432-bf7c-f16da0fd7f9f");

            migrationBuilder.RenameTable(
                name: "MenuMealCategory",
                newName: "MenuMealCategories");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMealCategory_MenuId",
                table: "MenuMealCategories",
                newName: "IX_MenuMealCategories_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMealCategory_MealCategoryId",
                table: "MenuMealCategories",
                newName: "IX_MenuMealCategories_MealCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMealCategories",
                table: "MenuMealCategories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "MealCategories",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Image", "ModifiedAt" },
                values: new object[,]
                {
                    { "cbc883e3-e478-451a-9ccb-87e207392743", "Soups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "soup.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "28a8e671-e246-49ee-add9-6b299b95b895", "Meals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "meal.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6e3fb4cf-2891-491f-85f8-c9e17319b1e8", "Desserts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desserts.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "a923f49f-62cb-4d7a-8128-013f4cad4913", "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "drinks.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MenuName", "ModifiedAt" },
                values: new object[] { "a5387eba-a3be-4b0e-9743-c798f0090cd1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book_left_image.jpg", "Standard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MealCategoryId", "MealName", "ModifiedAt", "Price", "TimeForPrepare" },
                values: new object[,]
                {
                    { "d9f9e1d3-1990-4eae-81a4-0c235863b93e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chicken.jpg", "cbc883e3-e478-451a-9ccb-87e207392743", "Chicken soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "babbca5e-91c6-4f09-bc59-ba95bf57b92e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish-soup.jpg", "cbc883e3-e478-451a-9ccb-87e207392743", "Fish soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "a6fe5fba-c30e-4a7e-9dce-f9f7019862bf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pizza.jpg", "28a8e671-e246-49ee-add9-6b299b95b895", "Pizza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "50c1cee5-d73a-4afa-bb9e-a5f2600cd000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish.jpg", "28a8e671-e246-49ee-add9-6b299b95b895", "Fish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "b3a6046b-f417-49f8-b783-fdb6d6c7b3c6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cake.jpg", "6e3fb4cf-2891-491f-85f8-c9e17319b1e8", "Cake", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "cfb036e2-cee5-4a47-93fe-2594c9d65a9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pancakes.jpg", "6e3fb4cf-2891-491f-85f8-c9e17319b1e8", "Pancakes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "356631bc-ead5-4d9a-87bb-9a9f63a8fb56", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wine.jpg", "a923f49f-62cb-4d7a-8128-013f4cad4913", "Wine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "c682d896-07fc-4654-9e1a-b814eadbbbe4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "water.jpg", "a923f49f-62cb-4d7a-8128-013f4cad4913", "Water", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null }
                });

            migrationBuilder.InsertData(
                table: "MenuMealCategories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "MealCategoryId", "MenuId", "ModifiedAt" },
                values: new object[,]
                {
                    { "2a77c6fd-69fe-4114-a035-fda65a49b982", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cbc883e3-e478-451a-9ccb-87e207392743", "a5387eba-a3be-4b0e-9743-c798f0090cd1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2b4f3d62-8d75-4d58-be5d-d9f93e32ce98", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "28a8e671-e246-49ee-add9-6b299b95b895", "a5387eba-a3be-4b0e-9743-c798f0090cd1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "f54ae289-27d0-4f8e-9fff-2458a528885f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6e3fb4cf-2891-491f-85f8-c9e17319b1e8", "a5387eba-a3be-4b0e-9743-c798f0090cd1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMealCategories_MealCategories_MealCategoryId",
                table: "MenuMealCategories",
                column: "MealCategoryId",
                principalTable: "MealCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMealCategories_Menus_MenuId",
                table: "MenuMealCategories",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuMealCategories_MealCategories_MealCategoryId",
                table: "MenuMealCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuMealCategories_Menus_MenuId",
                table: "MenuMealCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuMealCategories",
                table: "MenuMealCategories");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "356631bc-ead5-4d9a-87bb-9a9f63a8fb56");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "50c1cee5-d73a-4afa-bb9e-a5f2600cd000");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "a6fe5fba-c30e-4a7e-9dce-f9f7019862bf");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "b3a6046b-f417-49f8-b783-fdb6d6c7b3c6");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "babbca5e-91c6-4f09-bc59-ba95bf57b92e");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "c682d896-07fc-4654-9e1a-b814eadbbbe4");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "cfb036e2-cee5-4a47-93fe-2594c9d65a9f");

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: "d9f9e1d3-1990-4eae-81a4-0c235863b93e");

            migrationBuilder.DeleteData(
                table: "MenuMealCategories",
                keyColumn: "Id",
                keyValue: "2a77c6fd-69fe-4114-a035-fda65a49b982");

            migrationBuilder.DeleteData(
                table: "MenuMealCategories",
                keyColumn: "Id",
                keyValue: "2b4f3d62-8d75-4d58-be5d-d9f93e32ce98");

            migrationBuilder.DeleteData(
                table: "MenuMealCategories",
                keyColumn: "Id",
                keyValue: "f54ae289-27d0-4f8e-9fff-2458a528885f");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "28a8e671-e246-49ee-add9-6b299b95b895");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "6e3fb4cf-2891-491f-85f8-c9e17319b1e8");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "a923f49f-62cb-4d7a-8128-013f4cad4913");

            migrationBuilder.DeleteData(
                table: "MealCategories",
                keyColumn: "Id",
                keyValue: "cbc883e3-e478-451a-9ccb-87e207392743");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: "a5387eba-a3be-4b0e-9743-c798f0090cd1");

            migrationBuilder.RenameTable(
                name: "MenuMealCategories",
                newName: "MenuMealCategory");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMealCategories_MenuId",
                table: "MenuMealCategory",
                newName: "IX_MenuMealCategory_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuMealCategories_MealCategoryId",
                table: "MenuMealCategory",
                newName: "IX_MenuMealCategory_MealCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuMealCategory",
                table: "MenuMealCategory",
                column: "Id");

            migrationBuilder.InsertData(
                table: "MealCategories",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Image", "ModifiedAt" },
                values: new object[,]
                {
                    { "24de350d-b80c-4a55-b367-85720f77e47e", "Soups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "soup.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "37cf9c62-6912-4c7b-a48f-aa3e698641cb", "Meals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "meal.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "bfb9bb67-51ae-491e-a1a6-5341e6c81a2d", "Desserts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "desserts.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "0c8947a9-f4a0-4fad-ac12-9f0dfe4e73e7", "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "drinks.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MenuName", "ModifiedAt" },
                values: new object[] { "16917117-3990-4432-bf7c-f16da0fd7f9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "book_left_image.jpg", "Standard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MealCategoryId", "MealName", "ModifiedAt", "Price", "TimeForPrepare" },
                values: new object[,]
                {
                    { "b561d40b-3ad1-4941-8e3c-6f2c2d20c04f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chicken.jpg", "24de350d-b80c-4a55-b367-85720f77e47e", "Chicken soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "4c7c9de5-3a17-448c-81d8-b79b69ce9afb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish-soup.jpg", "24de350d-b80c-4a55-b367-85720f77e47e", "Fish soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "eb2cfce0-93fb-42aa-b16f-e6ff621832c1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pizza.jpg", "37cf9c62-6912-4c7b-a48f-aa3e698641cb", "Pizza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "ef398678-88cd-4706-8a1f-337c81191b71", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fish.jpg", "37cf9c62-6912-4c7b-a48f-aa3e698641cb", "Fish", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "1959bb65-7511-4b00-b873-fc13f7bc299b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cake.jpg", "bfb9bb67-51ae-491e-a1a6-5341e6c81a2d", "Cake", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "23985511-e6a9-479c-873a-53318379cd87", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pancakes.jpg", "bfb9bb67-51ae-491e-a1a6-5341e6c81a2d", "Pancakes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "cbbb3dde-80fc-446d-b266-2fb82143573b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wine.jpg", "0c8947a9-f4a0-4fad-ac12-9f0dfe4e73e7", "Wine", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null },
                    { "91e27a54-436b-4bc8-b44a-516c94a9b232", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "water.jpg", "0c8947a9-f4a0-4fad-ac12-9f0dfe4e73e7", "Water", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, null }
                });

            migrationBuilder.InsertData(
                table: "MenuMealCategory",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "MealCategoryId", "MenuId", "ModifiedAt" },
                values: new object[,]
                {
                    { "9f9caf33-e009-4867-9069-5ed12564cdb2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "24de350d-b80c-4a55-b367-85720f77e47e", "16917117-3990-4432-bf7c-f16da0fd7f9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "57acf76c-662c-4687-b8c6-3bd5ced26730", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "37cf9c62-6912-4c7b-a48f-aa3e698641cb", "16917117-3990-4432-bf7c-f16da0fd7f9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "0584c6bf-f8e9-4d51-b468-1fac9d9aa4bc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bfb9bb67-51ae-491e-a1a6-5341e6c81a2d", "16917117-3990-4432-bf7c-f16da0fd7f9f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMealCategory_MealCategories_MealCategoryId",
                table: "MenuMealCategory",
                column: "MealCategoryId",
                principalTable: "MealCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuMealCategory_Menus_MenuId",
                table: "MenuMealCategory",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
