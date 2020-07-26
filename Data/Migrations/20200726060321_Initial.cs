using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    MenuName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CardStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    MealName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    TimeForPrepare = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    MealCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_MealCategories_MealCategoryId",
                        column: x => x.MealCategoryId,
                        principalTable: "MealCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuMealCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    MenuId = table.Column<string>(nullable: true),
                    MealCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuMealCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuMealCategories_MealCategories_MealCategoryId",
                        column: x => x.MealCategoryId,
                        principalTable: "MealCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuMealCategories_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ShoppingCardId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_ShoppingCards_ShoppingCardId",
                        column: x => x.ShoppingCardId,
                        principalTable: "ShoppingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    HasPaid = table.Column<bool>(nullable: false),
                    OrderComment = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderMeals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    OrderId = table.Column<string>(nullable: true),
                    MealId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Statuses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMeals_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MealCategories",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "DeletedAt", "Image", "ModifiedAt" },
                values: new object[,]
                {
                    { "aeb34cc5-8658-467a-9608-354377b38255", "Soups", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "soup.jpg", null },
                    { "1bb7b173-1d33-48fa-8a7a-8a7195a7b620", "Meals", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "meal.jpg", null },
                    { "9ed6940c-2011-475d-8908-7f303f181f88", "Desserts", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "desserts.jpg", null },
                    { "7d704b2c-106f-4788-9c92-92bda7c34ace", "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "drinks.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MenuName", "ModifiedAt" },
                values: new object[] { "ef51be58-caed-4aba-9601-8bf5ed97ee5d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "book_left_image.jpg", "Standard", null });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Image", "MealCategoryId", "MealName", "ModifiedAt", "Price", "TimeForPrepare" },
                values: new object[,]
                {
                    { "12ba7d17-9bdc-4d27-b142-45d7cbc030e5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "chicken.jpg", "aeb34cc5-8658-467a-9608-354377b38255", "Chicken soup", null, 20m, null },
                    { "14b698d9-8a4b-4da3-80eb-c7765660f948", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fish-soup.jpg", "aeb34cc5-8658-467a-9608-354377b38255", "Fish soup", null, 10m, null },
                    { "59ce7ff0-e62f-4a26-86cf-cd1d9d9f970e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pizza.jpg", "1bb7b173-1d33-48fa-8a7a-8a7195a7b620", "Pizza", null, 10m, null },
                    { "38d325c7-22fb-4e7b-a902-5d5e0162641a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "fish.jpg", "1bb7b173-1d33-48fa-8a7a-8a7195a7b620", "Fish", null, 15m, null },
                    { "0528cced-208a-4a94-9e30-9086cf1ca671", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "cake.jpg", "9ed6940c-2011-475d-8908-7f303f181f88", "Cake", null, 5m, null },
                    { "9e6a5863-6075-4e33-8f8e-ab15435c900b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "pancakes.jpg", "9ed6940c-2011-475d-8908-7f303f181f88", "Pancakes", null, 7m, null },
                    { "cf241f2c-c8e1-466b-9ddd-fc219b1c60ae", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "wine.jpg", "7d704b2c-106f-4788-9c92-92bda7c34ace", "Wine", null, 0m, null },
                    { "70eaa34c-4027-4283-bcd2-69b29cf3ac78", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "water.jpg", "7d704b2c-106f-4788-9c92-92bda7c34ace", "Water", null, 3m, null }
                });

            migrationBuilder.InsertData(
                table: "MenuMealCategories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "MealCategoryId", "MenuId", "ModifiedAt" },
                values: new object[,]
                {
                    { "e519f53f-6d60-4ceb-bc51-e5f7293e044e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aeb34cc5-8658-467a-9608-354377b38255", "ef51be58-caed-4aba-9601-8bf5ed97ee5d", null },
                    { "b66d6e20-cad2-407c-9392-fd13fadfc001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1bb7b173-1d33-48fa-8a7a-8a7195a7b620", "ef51be58-caed-4aba-9601-8bf5ed97ee5d", null },
                    { "dc8bbe6c-950c-4741-8a09-b4cf7eba4ffa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "9ed6940c-2011-475d-8908-7f303f181f88", "ef51be58-caed-4aba-9601-8bf5ed97ee5d", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ShoppingCardId",
                table: "Customers",
                column: "ShoppingCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealCategoryId",
                table: "Meals",
                column: "MealCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuMealCategories_MealCategoryId",
                table: "MenuMealCategories",
                column: "MealCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuMealCategories_MenuId",
                table: "MenuMealCategories",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMeals_MealId",
                table: "OrderMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMeals_OrderId",
                table: "OrderMeals",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MenuMealCategories");

            migrationBuilder.DropTable(
                name: "OrderMeals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "MealCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ShoppingCards");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
