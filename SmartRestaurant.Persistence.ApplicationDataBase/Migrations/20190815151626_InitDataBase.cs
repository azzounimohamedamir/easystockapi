using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    IsoCode = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    IsoCode = table.Column<string>(maxLength: 5, nullable: false),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Illnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illnesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kitchens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitchens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    SelectLanguage = table.Column<string>(nullable: true),
                    IsoCode = table.Column<string>(maxLength: 5, nullable: false),
                    IsRTL = table.Column<bool>(nullable: false, defaultValueSql: "0"),
                    EnglishName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_Latitude = table.Column<string>(nullable: true),
                    Address_Longitude = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SRUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ChainId = table.Column<string>(nullable: true),
                    RestuarantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SRUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    CountryId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    IsoCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountriesCurrencies",
                columns: table => new
                {
                    CountryId = table.Column<string>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountriesCurrencies", x => new { x.CountryId, x.CurrencyId });
                    table.ForeignKey(
                        name: "FK_CountriesCurrencies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountriesCurrencies_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    PrimaryKeyName = table.Column<string>(nullable: true),
                    PrimaryKeyValue = table.Column<string>(nullable: true),
                    ColumnName = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 256, nullable: true),
                    LanguageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translates_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chains",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chains_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mailings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    TemplateId = table.Column<string>(nullable: true),
                    TemplateId1 = table.Column<Guid>(nullable: true),
                    Action = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mailings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mailings_Templates_TemplateId1",
                        column: x => x.TemplateId1,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    TemplateId = table.Column<string>(nullable: true),
                    TemplateId1 = table.Column<Guid>(nullable: true),
                    Action = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Templates_TemplateId1",
                        column: x => x.TemplateId1,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    StateId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    IsoCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    ChainId = table.Column<Guid>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: false),
                    RestaurantTypeId = table.Column<Guid>(nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_Latitude = table.Column<string>(nullable: true),
                    Address_Longitude = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PriceRange_CurrencyId = table.Column<Guid>(nullable: false),
                    PriceRange_MinAmount = table.Column<decimal>(nullable: false),
                    PriceRange_MaxAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Currencies_PriceRange_CurrencyId",
                        column: x => x.PriceRange_CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_Chains_ChainId",
                        column: x => x.ChainId,
                        principalTable: "Chains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurants_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_RestaurantTypes_RestaurantTypeId",
                        column: x => x.RestaurantTypeId,
                        principalTable: "RestaurantTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MailingUsers",
                columns: table => new
                {
                    MailingId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailingUsers", x => new { x.MailingId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MailingUsers_Mailings_MailingId",
                        column: x => x.MailingId,
                        principalTable: "Mailings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MailingUsers_SRUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SRUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationUsers",
                columns: table => new
                {
                    NotificationId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationUsers", x => new { x.NotificationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_NotificationUsers_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationUsers_SRUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "SRUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floors_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductFamilies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFamilies_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFeatures",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    FeatureId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFeatures", x => new { x.RestaurantId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_RestaurantFeatures_Features_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantFeatures_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantKitchens",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    KitchenId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantKitchens", x => new { x.RestaurantId, x.KitchenId });
                    table.ForeignKey(
                        name: "FK_RestaurantKitchens_Kitchens_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Kitchens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantKitchens_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantMeals",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    MealId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantMeals", x => new { x.RestaurantId, x.MealId });
                    table.ForeignKey(
                        name: "FK_RestaurantMeals_Meals_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantMeals_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantPriceTypes",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    PriceTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantPriceTypes", x => new { x.RestaurantId, x.PriceTypeId });
                    table.ForeignKey(
                        name: "FK_RestaurantPriceTypes_PriceTypes_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "PriceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantPriceTypes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    RestaurantId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantRatings_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantRecommendations",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    RecommendationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantRecommendations", x => new { x.RestaurantId, x.RecommendationId });
                    table.ForeignKey(
                        name: "FK_RestaurantRecommendations_Recommendations_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Recommendations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantRecommendations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantSpecialties",
                columns: table => new
                {
                    RestaurantId = table.Column<Guid>(nullable: false),
                    SpecialtyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantSpecialties", x => new { x.RestaurantId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_RestaurantSpecialties_Specialties_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantSpecialties_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    Periode = table.Column<int>(nullable: false),
                    DateService_Date = table.Column<DateTime>(nullable: false),
                    DateService_StartTime_Value = table.Column<TimeSpan>(nullable: false),
                    DateService_EndTime_Value = table.Column<TimeSpan>(nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    FirstName = table.Column<string>(maxLength: 256, nullable: false),
                    LastName = table.Column<string>(maxLength: 256, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_State = table.Column<string>(nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<string>(nullable: true),
                    Address_Latitude = table.Column<string>(nullable: true),
                    Address_Longitude = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    StaffRole = table.Column<int>(nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    IsPercentage = table.Column<bool>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarifications_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    FloorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceState",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    SysDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceState", x => new { x.ServiceId, x.State });
                    table.ForeignKey(
                        name: "FK_ServiceState_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Issuer = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<Guid>(nullable: true),
                    StaffId = table.Column<Guid>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    RestaurantId = table.Column<Guid>(nullable: false),
                    ChefId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Staffs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menus_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    AreaId = table.Column<Guid>(nullable: false),
                    TableNumber = table.Column<int>(nullable: false),
                    Chair = table.Column<int>(nullable: false),
                    MaxChairCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    MenuId = table.Column<Guid>(nullable: false),
                    IsPackage = table.Column<bool>(nullable: false),
                    GalleryId = table.Column<Guid>(nullable: true),
                    Discount_CurrencyId = table.Column<Guid>(nullable: false),
                    Discount_Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItems_Currencies_Discount_CurrencyId",
                        column: x => x.Discount_CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    TableId = table.Column<Guid>(nullable: false),
                    PlaceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodAllergies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    FoodId = table.Column<Guid>(nullable: false),
                    AllergyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodAllergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodAllergies_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    PurchasePriceHT_CurrencyId = table.Column<Guid>(nullable: false),
                    PurchasePriceHT_Amount = table.Column<decimal>(nullable: false),
                    Gain_CurrencyId = table.Column<Guid>(nullable: false),
                    Gain_Amount = table.Column<decimal>(nullable: false),
                    Tva = table.Column<decimal>(nullable: false),
                    IsPercentage = table.Column<bool>(nullable: false),
                    GainAmount = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    DishId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pricings_Currencies_Gain_CurrencyId",
                        column: x => x.Gain_CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pricings_Currencies_PurchasePriceHT_CurrencyId",
                        column: x => x.PurchasePriceHT_CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DishAccompanying",
                columns: table => new
                {
                    ParentId = table.Column<Guid>(nullable: false),
                    AccompanyingId = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishAccompanying", x => new { x.ParentId, x.AccompanyingId });
                    table.ForeignKey(
                        name: "FK_DishAccompanying_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishEquivalences",
                columns: table => new
                {
                    ParentId = table.Column<Guid>(nullable: false),
                    EquivalenceId = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    QuantityParent_Value = table.Column<decimal>(nullable: false),
                    QuantityParent_UnitId = table.Column<Guid>(nullable: false),
                    QuantityEquivalence_Value = table.Column<decimal>(nullable: false),
                    QuantityEquivalence_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishEquivalences", x => new { x.ParentId, x.EquivalenceId });
                    table.ForeignKey(
                        name: "FK_DishEquivalences_Units_QuantityEquivalence_UnitId",
                        column: x => x.QuantityEquivalence_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishEquivalences_Units_QuantityParent_UnitId",
                        column: x => x.QuantityParent_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    DishId = table.Column<Guid>(nullable: false),
                    FoodId = table.Column<Guid>(nullable: false),
                    IsPrincipal = table.Column<bool>(nullable: false),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false),
                    IsSwitchable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishTarifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    DishId = table.Column<Guid>(nullable: false),
                    TarificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishTarifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishTarifications_Tarifications_TarificationId",
                        column: x => x.TarificationId,
                        principalTable: "Tarifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(maxLength: 256, nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: true),
                    DishId = table.Column<Guid>(nullable: true),
                    MenuItemId = table.Column<Guid>(nullable: true),
                    TheCoverPictureId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galleries_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Galleries_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDish",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    ServiceId = table.Column<Guid>(nullable: false),
                    DishId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDish_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    FamillyId = table.Column<Guid>(nullable: false),
                    GalleryId = table.Column<Guid>(nullable: true),
                    PreparationTime_Value = table.Column<TimeSpan>(nullable: false),
                    ServiceTime_Value = table.Column<TimeSpan>(nullable: false),
                    MenuItemId = table.Column<Guid>(nullable: true),
                    CanBeAccompanying = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dishes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    FoodCategoryId = table.Column<Guid>(nullable: false),
                    PictureId = table.Column<Guid>(nullable: true),
                    UnitId = table.Column<Guid>(nullable: false),
                    Nutrition_Quantity_Value = table.Column<decimal>(nullable: false),
                    Nutrition_Quantity_UnitId = table.Column<Guid>(nullable: false),
                    Nutrition_GlycemicIndex = table.Column<decimal>(nullable: false),
                    Nutrition_Fibre = table.Column<decimal>(nullable: false),
                    Nutrition_Calorie = table.Column<decimal>(nullable: false),
                    Nutrition_Protein = table.Column<decimal>(nullable: false),
                    Nutrition_Carbohydrate = table.Column<decimal>(nullable: false),
                    Nutrition_Lipid = table.Column<decimal>(nullable: false),
                    IsNatural = table.Column<bool>(nullable: false),
                    IsIndustriel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foods_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Foods_Units_Nutrition_Quantity_UnitId",
                        column: x => x.Nutrition_Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodCompositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    FoodId = table.Column<Guid>(nullable: false),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCompositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCompositions_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCompositions_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodIllnesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    FoodId = table.Column<Guid>(nullable: false),
                    IllnessId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodIllnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodIllnesses_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodIllnesses_Illnesses_IllnessId",
                        column: x => x.IllnessId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: true),
                    GalleryId = table.Column<Guid>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 2000, nullable: false),
                    FoodId = table.Column<Guid>(nullable: true),
                    FoodCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pictures_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DishFamillies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    RestaurantId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    PictureId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishFamillies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishFamillies_DishFamillies_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DishFamillies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishFamillies_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DishFamillies_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 5, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    PictureId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCategories_FoodCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FoodCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodCategories_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SlugUrl = table.Column<string>(nullable: true),
                    PictureId = table.Column<Guid>(nullable: true),
                    ProductFamilyId = table.Column<Guid>(nullable: false),
                    MenuItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductFamilies_ProductFamilyId",
                        column: x => x.ProductFamilyId,
                        principalTable: "ProductFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTarifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    TarificationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTarifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTarifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTarifications_Tarifications_TarificationId",
                        column: x => x.TarificationId,
                        principalTable: "Tarifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    Alias = table.Column<string>(maxLength: 15, nullable: true),
                    ServiceId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    Quantity_Value = table.Column<decimal>(nullable: false),
                    Quantity_UnitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProducts_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProducts_Units_Quantity_UnitId",
                        column: x => x.Quantity_UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_FloorId",
                table: "Areas",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chains_OwnerId",
                table: "Chains",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_OwnerId",
                table: "Contact",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_RestaurantId",
                table: "Contact",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_StaffId",
                table: "Contact",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "CountryNameIndex",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountriesCurrencies_CurrencyId",
                table: "CountriesCurrencies",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "CurrencyNameIndex",
                table: "Currencies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishAccompanying_AccompanyingId",
                table: "DishAccompanying",
                column: "AccompanyingId");

            migrationBuilder.CreateIndex(
                name: "IX_DishAccompanying_Quantity_UnitId",
                table: "DishAccompanying",
                column: "Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DishEquivalences_EquivalenceId",
                table: "DishEquivalences",
                column: "EquivalenceId");

            migrationBuilder.CreateIndex(
                name: "IX_DishEquivalences_QuantityEquivalence_UnitId",
                table: "DishEquivalences",
                column: "QuantityEquivalence_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DishEquivalences_QuantityParent_UnitId",
                table: "DishEquivalences",
                column: "QuantityParent_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_FamillyId",
                table: "Dishes",
                column: "FamillyId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_MenuItemId",
                table: "Dishes",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_DishFamillies_ParentId",
                table: "DishFamillies",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DishFamillies_PictureId",
                table: "DishFamillies",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DishFamillies_RestaurantId",
                table: "DishFamillies",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_DishId",
                table: "DishIngredients",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_FoodId",
                table: "DishIngredients",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_Quantity_UnitId",
                table: "DishIngredients",
                column: "Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTarifications_DishId",
                table: "DishTarifications",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishTarifications_TarificationId",
                table: "DishTarifications",
                column: "TarificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_RestaurantId",
                table: "Floors",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAllergies_AllergyId",
                table: "FoodAllergies",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAllergies_FoodId",
                table: "FoodAllergies",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "FoodCategoryNameIndex",
                table: "FoodCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_ParentId",
                table: "FoodCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCategories_PictureId",
                table: "FoodCategories",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCompositions_FoodId",
                table: "FoodCompositions",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCompositions_Quantity_UnitId",
                table: "FoodCompositions",
                column: "Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIllnesses_FoodId",
                table: "FoodIllnesses",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIllnesses_IllnessId",
                table: "FoodIllnesses",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodCategoryId",
                table: "Foods",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "FoodNameIndex",
                table: "Foods",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PictureId",
                table: "Foods",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_UnitId",
                table: "Foods",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Nutrition_Quantity_UnitId",
                table: "Foods",
                column: "Nutrition_Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_DishId",
                table: "Galleries",
                column: "DishId",
                unique: true,
                filter: "[DishId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_MenuItemId",
                table: "Galleries",
                column: "MenuItemId",
                unique: true,
                filter: "[MenuItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_RestaurantId",
                table: "Galleries",
                column: "RestaurantId",
                unique: true,
                filter: "[RestaurantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "LanguageNameIndex",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mailings_TemplateId1",
                table: "Mailings",
                column: "TemplateId1");

            migrationBuilder.CreateIndex(
                name: "IX_MailingUsers_UserId",
                table: "MailingUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_Discount_CurrencyId",
                table: "MenuItems",
                column: "Discount_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ChefId",
                table: "Menus",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_RestaurantId",
                table: "Menus",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TemplateId1",
                table: "Notifications",
                column: "TemplateId1");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsers_UserId",
                table: "NotificationUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_FoodCategoryId",
                table: "Pictures",
                column: "FoodCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_FoodId",
                table: "Pictures",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_GalleryId",
                table: "Pictures",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_RestaurantId",
                table: "Pictures",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_TableId",
                table: "Places",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_DishId",
                table: "Pricings",
                column: "DishId",
                unique: true,
                filter: "[DishId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_ProductId",
                table: "Pricings",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_Gain_CurrencyId",
                table: "Pricings",
                column: "Gain_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_PurchasePriceHT_CurrencyId",
                table: "Pricings",
                column: "PurchasePriceHT_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFamilies_RestaurantId",
                table: "ProductFamilies",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MenuItemId",
                table: "Products",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PictureId",
                table: "Products",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductFamilyId",
                table: "Products",
                column: "ProductFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTarifications_ProductId",
                table: "ProductTarifications",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTarifications_TarificationId",
                table: "ProductTarifications",
                column: "TarificationId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantRatings_RestaurantId",
                table: "RestaurantRatings",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_PriceRange_CurrencyId",
                table: "Restaurants",
                column: "PriceRange_CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ChainId",
                table: "Restaurants",
                column: "ChainId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerId",
                table: "Restaurants",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_RestaurantTypeId",
                table: "Restaurants",
                column: "RestaurantTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDish_DishId",
                table: "ServiceDish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDish_ServiceId",
                table: "ServiceDish",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProducts_ProductId",
                table: "ServiceProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProducts_ServiceId",
                table: "ServiceProducts",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProducts_Quantity_UnitId",
                table: "ServiceProducts",
                column: "Quantity_UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RestaurantId",
                table: "Services",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_RestaurantId",
                table: "Staffs",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_AreaId",
                table: "Tables",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifications_RestaurantId",
                table: "Tarifications",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Translates_LanguageId",
                table: "Translates",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "UnitNameIndex",
                table: "Units",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_Symbol",
                table: "Units",
                column: "Symbol",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodAllergies_Foods_FoodId",
                table: "FoodAllergies",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Dishes_DishId",
                table: "Pricings",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Products_ProductId",
                table: "Pricings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishAccompanying_Dishes_AccompanyingId",
                table: "DishAccompanying",
                column: "AccompanyingId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishAccompanying_Dishes_ParentId",
                table: "DishAccompanying",
                column: "ParentId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishEquivalences_Dishes_EquivalenceId",
                table: "DishEquivalences",
                column: "EquivalenceId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishEquivalences_Dishes_ParentId",
                table: "DishEquivalences",
                column: "ParentId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Foods_FoodId",
                table: "DishIngredients",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DishTarifications_Dishes_DishId",
                table: "DishTarifications",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Dishes_DishId",
                table: "Galleries",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDish_Dishes_DishId",
                table: "ServiceDish",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_DishFamillies_FamillyId",
                table: "Dishes",
                column: "FamillyId",
                principalTable: "DishFamillies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Pictures_PictureId",
                table: "Foods",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodCategories_FoodCategoryId",
                table: "Foods",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_FoodCategories_FoodCategoryId",
                table: "Pictures",
                column: "FoodCategoryId",
                principalTable: "FoodCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chains_Owners_OwnerId",
                table: "Chains");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Owners_OwnerId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DishFamillies_Restaurants_RestaurantId",
                table: "DishFamillies");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Restaurants_RestaurantId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurants_RestaurantId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Restaurants_RestaurantId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Restaurants_RestaurantId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Staffs_ChefId",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Currencies_Discount_CurrencyId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Dishes_DishId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Units_UnitId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Units_Nutrition_Quantity_UnitId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_MenuItems_MenuItemId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCategories_Pictures_PictureId",
                table: "FoodCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Pictures_PictureId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "CountriesCurrencies");

            migrationBuilder.DropTable(
                name: "DishAccompanying");

            migrationBuilder.DropTable(
                name: "DishEquivalences");

            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "DishTarifications");

            migrationBuilder.DropTable(
                name: "FoodAllergies");

            migrationBuilder.DropTable(
                name: "FoodCompositions");

            migrationBuilder.DropTable(
                name: "FoodIllnesses");

            migrationBuilder.DropTable(
                name: "MailingUsers");

            migrationBuilder.DropTable(
                name: "NotificationUsers");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "ProductTarifications");

            migrationBuilder.DropTable(
                name: "RestaurantFeatures");

            migrationBuilder.DropTable(
                name: "RestaurantKitchens");

            migrationBuilder.DropTable(
                name: "RestaurantMeals");

            migrationBuilder.DropTable(
                name: "RestaurantPriceTypes");

            migrationBuilder.DropTable(
                name: "RestaurantRatings");

            migrationBuilder.DropTable(
                name: "RestaurantRecommendations");

            migrationBuilder.DropTable(
                name: "RestaurantSpecialties");

            migrationBuilder.DropTable(
                name: "ServiceDish");

            migrationBuilder.DropTable(
                name: "ServiceProducts");

            migrationBuilder.DropTable(
                name: "ServiceState");

            migrationBuilder.DropTable(
                name: "Translates");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Illnesses");

            migrationBuilder.DropTable(
                name: "Mailings");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SRUsers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Tarifications");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Kitchens");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "PriceTypes");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "ProductFamilies");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Chains");

            migrationBuilder.DropTable(
                name: "RestaurantTypes");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "DishFamillies");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "FoodCategories");
        }
    }
}
