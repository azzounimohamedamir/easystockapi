using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartRestaurant.Infrastructure.Migrations
{
    public partial class newmigrationsall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caisses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: true),
                    Vendeur = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    SoldeJ = table.Column<decimal>(nullable: true),
                    SoldeM = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caisses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    RaisonSociale = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Addresse = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Nrc = table.Column<decimal>(nullable: false),
                    Nif = table.Column<decimal>(nullable: false),
                    Nic = table.Column<decimal>(nullable: false),
                    Commerce = table.Column<string>(nullable: true),
                    Numarticle = table.Column<decimal>(nullable: false),
                    TotalCredits = table.Column<decimal>(nullable: false),
                    TotalAvances = table.Column<decimal>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreanceAssainies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateAssainissement = table.Column<DateTime>(nullable: false),
                    NomClient = table.Column<string>(nullable: true),
                    AssainissementSur = table.Column<string>(nullable: true),
                    AncienCredit = table.Column<decimal>(nullable: false),
                    MontantAssainissement = table.Column<decimal>(nullable: false),
                    Reste = table.Column<decimal>(nullable: false),
                    Motif = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreanceAssainies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultConfigLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timbre = table.Column<string>(nullable: true),
                    Tva = table.Column<string>(nullable: true),
                    Categorie = table.Column<Guid>(nullable: false),
                    ModeVente = table.Column<string>(nullable: true),
                    SommeFacture = table.Column<string>(nullable: true),
                    PointsGagner = table.Column<string>(nullable: true),
                    DeviseParDefault = table.Column<string>(nullable: true),
                    MargeBenifDetail = table.Column<string>(nullable: true),
                    MargeBenifGros = table.Column<string>(nullable: true),
                    AutorisationQteNeg = table.Column<bool>(nullable: false),
                    PrixAchatMoyPondere = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultConfigLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Depenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Somme = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Observations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    RaisonSociale = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Addresse = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Nrc = table.Column<decimal>(nullable: false),
                    Nif = table.Column<decimal>(nullable: false),
                    Nic = table.Column<decimal>(nullable: false),
                    Commerce = table.Column<string>(nullable: true),
                    Numarticle = table.Column<decimal>(nullable: false),
                    TotalCredits = table.Column<decimal>(nullable: false),
                    TotalAvances = table.Column<decimal>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    IsDisabled = table.Column<bool>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventaireEquipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreationInv = table.Column<DateTime>(nullable: false),
                    Equipe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaireEquipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventaires",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Trimestre = table.Column<int>(nullable: false),
                    Annuel = table.Column<bool>(nullable: false),
                    TotalProduitsInventaire = table.Column<int>(nullable: false),
                    TotalProduitsEnManque = table.Column<int>(nullable: false),
                    TotalProduitsEnSurnombre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MouvementStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProduitId = table.Column<Guid>(nullable: false),
                    DateMvt = table.Column<DateTime>(nullable: false),
                    ProduitName = table.Column<string>(nullable: true),
                    TypeMouvement = table.Column<int>(nullable: false),
                    Qte = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MouvementStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NiveauFidelites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    MinPointsRequis = table.Column<int>(nullable: false),
                    MaxPointsRequis = table.Column<int>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveauFidelites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocieteInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomSociete = table.Column<string>(nullable: true),
                    Activite = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Siteweb = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    RegistreCommerce = table.Column<string>(nullable: true),
                    Rib = table.Column<string>(nullable: true),
                    Nif = table.Column<string>(nullable: true),
                    Nis = table.Column<string>(nullable: true),
                    NumeroArticle = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocieteInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodeP = table.Column<string>(nullable: true),
                    Designaation = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CodeBar = table.Column<string>(nullable: true),
                    Rayonnage = table.Column<string>(nullable: true),
                    QteAlerte = table.Column<decimal>(nullable: false),
                    QteInitiale = table.Column<decimal>(nullable: false),
                    QteRestante = table.Column<decimal>(nullable: false),
                    PrixVenteDetail = table.Column<decimal>(nullable: false),
                    PrixAchat = table.Column<decimal>(nullable: false),
                    PrixVenteGros = table.Column<decimal>(nullable: false),
                    Tva = table.Column<decimal>(nullable: false),
                    IsPerissable = table.Column<bool>(nullable: false),
                    DatePeremption = table.Column<DateTime>(nullable: false),
                    JourAlerte = table.Column<int>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvanceClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    MontantAvance = table.Column<decimal>(nullable: false),
                    DateAvance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvanceClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvanceClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FactureId = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBl = table.Column<string>(nullable: true),
                    Caisse = table.Column<int>(nullable: false),
                    NomCaissier = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Heure = table.Column<string>(nullable: true),
                    LieuLivraison = table.Column<string>(nullable: true),
                    Conducteur = table.Column<string>(nullable: true),
                    MatriculeVeh = table.Column<string>(nullable: true),
                    NomVehicule = table.Column<string>(nullable: true),
                    DateFermuture = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    MontantTotalHT = table.Column<decimal>(nullable: false),
                    MontantTotalHTApresRemise = table.Column<decimal>(nullable: false),
                    MontantTotalTVA = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    Timbre = table.Column<decimal>(nullable: false),
                    RestTotal = table.Column<decimal>(nullable: false),
                    TotalReglement = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    VendeurId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Rip = table.Column<long>(nullable: false),
                    Rib = table.Column<long>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bls_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonCommandeClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CodeBC = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Heure = table.Column<string>(nullable: true),
                    DateFermuture = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    MontantTotalHT = table.Column<decimal>(nullable: false),
                    MontantTotalHTApresRemise = table.Column<decimal>(nullable: false),
                    MontantTotalTVA = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    Timbre = table.Column<decimal>(nullable: false),
                    RestTotal = table.Column<decimal>(nullable: false),
                    TotalReglement = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    VendeurId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Rip = table.Column<long>(nullable: false),
                    Rib = table.Column<long>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonCommandeClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonCommandeClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    MontantCredit = table.Column<decimal>(nullable: false),
                    DateCredit = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "factureProformats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeFP = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Heure = table.Column<string>(nullable: true),
                    DateFermuture = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    MontantTotalHT = table.Column<decimal>(nullable: false),
                    MontantTotalHTApresRemise = table.Column<decimal>(nullable: false),
                    MontantTotalTVA = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    Timbre = table.Column<decimal>(nullable: false),
                    RestTotal = table.Column<decimal>(nullable: false),
                    TotalReglement = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    VendeurId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Rip = table.Column<long>(nullable: false),
                    Rib = table.Column<long>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factureProformats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factureProformats_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BlId = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeF = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Heure = table.Column<string>(nullable: true),
                    Caisse = table.Column<int>(nullable: false),
                    CouponPrice = table.Column<decimal>(nullable: false),
                    NomCaissier = table.Column<string>(nullable: true),
                    DateFermuture = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    MontantTotalHT = table.Column<decimal>(nullable: false),
                    MontantTotalHTApresRemise = table.Column<decimal>(nullable: false),
                    MontantTotalTVA = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    Timbre = table.Column<decimal>(nullable: false),
                    RestTotal = table.Column<decimal>(nullable: false),
                    TotalReglement = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    VendeurId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    Rip = table.Column<long>(nullable: false),
                    Rib = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetourProduitClients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: true),
                    ReturnedFrom = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Heure = table.Column<string>(nullable: true),
                    RestTotal = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetourProduitClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetourProduitClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenteComptoirs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeVc = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Heure = table.Column<string>(nullable: true),
                    Caisse = table.Column<int>(nullable: false),
                    NomCaissier = table.Column<string>(nullable: true),
                    Remise = table.Column<decimal>(nullable: false),
                    VendeurId = table.Column<Guid>(nullable: false),
                    BlId = table.Column<Guid>(nullable: false),
                    CouponPrice = table.Column<decimal>(nullable: false),
                    DateFermuture = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    MontantTotalHT = table.Column<decimal>(nullable: false),
                    MontantTotalHTApresRemise = table.Column<decimal>(nullable: false),
                    MontantTotalTVA = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    Timbre = table.Column<decimal>(nullable: false),
                    RestTotal = table.Column<decimal>(nullable: false),
                    TotalReglement = table.Column<decimal>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: false),
                    Rip = table.Column<long>(nullable: false),
                    Rib = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenteComptoirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenteComptoirs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonAchats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeBA = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Heure = table.Column<string>(nullable: true),
                    DateFermuture = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    MontantTotalHT = table.Column<decimal>(nullable: false),
                    MontantTotalHTApresRemise = table.Column<decimal>(nullable: false),
                    MontantTotalTVA = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    Timbre = table.Column<decimal>(nullable: false),
                    RestTotal = table.Column<decimal>(nullable: false),
                    TotalReglement = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    VendeurId = table.Column<Guid>(nullable: false),
                    FournisseurId = table.Column<Guid>(nullable: false),
                    Rip = table.Column<long>(nullable: false),
                    Rib = table.Column<long>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonAchats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonAchats_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonCommandeFournisseurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CodeBC = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Heure = table.Column<string>(nullable: true),
                    DateFermuture = table.Column<DateTime>(nullable: false),
                    DateEcheance = table.Column<DateTime>(nullable: false),
                    MontantTotalHT = table.Column<decimal>(nullable: false),
                    MontantTotalHTApresRemise = table.Column<decimal>(nullable: false),
                    MontantTotalTVA = table.Column<decimal>(nullable: false),
                    MontantTotalTTC = table.Column<decimal>(nullable: false),
                    Timbre = table.Column<decimal>(nullable: false),
                    RestTotal = table.Column<decimal>(nullable: false),
                    TotalReglement = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false),
                    Etat = table.Column<string>(nullable: true),
                    VendeurId = table.Column<Guid>(nullable: false),
                    FournisseurId = table.Column<Guid>(nullable: false),
                    Rip = table.Column<long>(nullable: false),
                    Rib = table.Column<long>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonCommandeFournisseurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonCommandeFournisseurs_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LignesInventaireEquipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodeProduit = table.Column<string>(nullable: true),
                    NomProduit = table.Column<string>(nullable: true),
                    Rayonnage = table.Column<string>(nullable: true),
                    CodeBar = table.Column<string>(nullable: true),
                    QuantiteTrouvee = table.Column<int>(nullable: true),
                    Equipe = table.Column<int>(nullable: true),
                    InventaireEquipeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesInventaireEquipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LignesInventaireEquipes_InventaireEquipes_InventaireEquipeId",
                        column: x => x.InventaireEquipeId,
                        principalTable: "InventaireEquipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LignesInventaireFinals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodeProduit = table.Column<string>(nullable: true),
                    NomProduit = table.Column<string>(nullable: true),
                    Rayonnage = table.Column<string>(nullable: true),
                    CodeBar = table.Column<string>(nullable: true),
                    QuantiteTrouveeA = table.Column<decimal>(nullable: false),
                    QuantiteTrouveeB = table.Column<decimal>(nullable: false),
                    QuantiteTrouveeReel = table.Column<decimal>(nullable: false),
                    QuantiteStockLogiciel = table.Column<decimal>(nullable: false),
                    QteEcart = table.Column<decimal>(nullable: false),
                    Manque = table.Column<bool>(nullable: false),
                    Surnombre = table.Column<bool>(nullable: false),
                    Egaux = table.Column<bool>(nullable: false),
                    Observation = table.Column<string>(nullable: true),
                    InventaireId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesInventaireFinals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LignesInventaireFinals_Inventaires_InventaireId",
                        column: x => x.InventaireId,
                        principalTable: "Inventaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientFidelites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    DateInscription = table.Column<DateTime>(nullable: false),
                    Withdraw = table.Column<decimal>(nullable: false),
                    NiveauFideliteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFidelites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientFidelites_NiveauFidelites_NiveauFideliteId",
                        column: x => x.NiveauFideliteId,
                        principalTable: "NiveauFidelites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductAttributeId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_ProductAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "ProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryAttribute",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    ProductAttributeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttribute", x => new { x.CategoryId, x.ProductAttributeId });
                    table.ForeignKey(
                        name: "FK_CategoryAttribute_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryAttribute_ProductAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "ProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProductAttributeId = table.Column<Guid>(nullable: false),
                    StockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeValues_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    LastPuv = table.Column<decimal>(nullable: false),
                    HasReduction = table.Column<bool>(nullable: false),
                    Reduction = table.Column<float>(nullable: false),
                    BlId = table.Column<Guid>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlProducts_Bls_BlId",
                        column: x => x.BlId,
                        principalTable: "Bls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BcProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    BcId = table.Column<Guid>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BcProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BcProducts_BonCommandeClients_BcId",
                        column: x => x.BcId,
                        principalTable: "BonCommandeClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BcProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacProProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    LastPuv = table.Column<decimal>(nullable: false),
                    HasReduction = table.Column<bool>(nullable: false),
                    Reduction = table.Column<float>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false),
                    FactureProformatId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacProProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacProProducts_factureProformats_FactureProformatId",
                        column: x => x.FactureProformatId,
                        principalTable: "factureProformats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacProProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    LastPuv = table.Column<decimal>(nullable: false),
                    HasReduction = table.Column<bool>(nullable: false),
                    Reduction = table.Column<float>(nullable: false),
                    FactureId = table.Column<Guid>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacProducts_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactureAvoirs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroAvoir = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFactureOriginal = table.Column<Guid>(nullable: false),
                    DateAvoir = table.Column<DateTime>(nullable: false),
                    HeureAvoir = table.Column<string>(nullable: true),
                    TypeAvoir = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactureAvoirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactureAvoirs_Factures_IdFactureOriginal",
                        column: x => x.IdFactureOriginal,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reglement_Acompte_Facture_Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    FactureId = table.Column<Guid>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Libelle = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reglement_Acompte_Facture_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reglement_Acompte_Facture_Clients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reglement_Acompte_Facture_Clients_Factures_FactureId",
                        column: x => x.FactureId,
                        principalTable: "Factures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RetourProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false),
                    RetourProduitClientId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetourProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetourProducts_RetourProduitClients_RetourProduitClientId",
                        column: x => x.RetourProduitClientId,
                        principalTable: "RetourProduitClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RetourProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenteComptoirProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    LastPuv = table.Column<decimal>(nullable: false),
                    HasReduction = table.Column<bool>(nullable: false),
                    Reduction = table.Column<float>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    VenteComptoirId = table.Column<Guid>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenteComptoirProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VenteComptoirProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenteComptoirProducts_VenteComptoirs_VenteComptoirId",
                        column: x => x.VenteComptoirId,
                        principalTable: "VenteComptoirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BAProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Pua = table.Column<decimal>(nullable: false),
                    Pmp = table.Column<decimal>(nullable: false),
                    Newpua = table.Column<decimal>(nullable: false),
                    BAId = table.Column<Guid>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false),
                    BonAchatsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BAProducts_BonAchats_BonAchatsId",
                        column: x => x.BonAchatsId,
                        principalTable: "BonAchats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BAProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reglement_Acompte_BA_Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FournisseurId = table.Column<Guid>(nullable: false),
                    BAId = table.Column<Guid>(nullable: false),
                    Montant = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Libelle = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reglement_Acompte_BA_Fournisseurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reglement_Acompte_BA_Fournisseurs_BonAchats_BAId",
                        column: x => x.BAId,
                        principalTable: "BonAchats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reglement_Acompte_BA_Fournisseurs_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbcProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Pua = table.Column<decimal>(nullable: false),
                    BcaId = table.Column<Guid>(nullable: false),
                    SelectedStockId = table.Column<Guid>(nullable: false),
                    BonCommandeFournisseurId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbcProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbcProducts_BonCommandeFournisseurs_BonCommandeFournisseurId",
                        column: x => x.BonCommandeFournisseurId,
                        principalTable: "BonCommandeFournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbcProducts_Stocks_SelectedStockId",
                        column: x => x.SelectedStockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AjoutProductsAvoirs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    FactureAvoirId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjoutProductsAvoirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AjoutProductsAvoirs_FactureAvoirs_FactureAvoirId",
                        column: x => x.FactureAvoirId,
                        principalTable: "FactureAvoirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotifModifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAvoir = table.Column<Guid>(nullable: false),
                    Motif = table.Column<int>(nullable: false),
                    ModificationAt = table.Column<string>(nullable: true),
                    AncienneValeur = table.Column<string>(nullable: true),
                    NouvelleValeur = table.Column<string>(nullable: true),
                    LigneFactureItem = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotifModifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotifModifications_FactureAvoirs_IdAvoir",
                        column: x => x.IdAvoir,
                        principalTable: "FactureAvoirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetourProductsAvoirs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Qte = table.Column<decimal>(nullable: false),
                    MontantHT = table.Column<decimal>(nullable: false),
                    MontantTVA = table.Column<decimal>(nullable: false),
                    MontantTTC = table.Column<decimal>(nullable: false),
                    Puv = table.Column<decimal>(nullable: false),
                    FactureAvoirId = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetourProductsAvoirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RetourProductsAvoirs_FactureAvoirs_FactureAvoirId",
                        column: x => x.FactureAvoirId,
                        principalTable: "FactureAvoirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Addresse", "Commerce", "DateEcheance", "Email", "FullName", "IsBanned", "IsDisabled", "Nic", "Nif", "Nrc", "Numarticle", "RaisonSociale", "Tel", "TotalAvances", "TotalCredits" },
                values: new object[] { new Guid("52a857b7-ee3c-42db-96a7-76d3042818ac"), "", "Client Comptoir", new DateTime(2034, 9, 30, 16, 3, 20, 900, DateTimeKind.Local).AddTicks(4444), "guest-client@gmail.com", "Client Comptoir", false, false, 45421845214m, 845784545m, 548512451m, 0m, "Client Anonyme", "0561596837", 0m, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_AbcProducts_BonCommandeFournisseurId",
                table: "AbcProducts",
                column: "BonCommandeFournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_AbcProducts_SelectedStockId",
                table: "AbcProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_AjoutProductsAvoirs_FactureAvoirId",
                table: "AjoutProductsAvoirs",
                column: "FactureAvoirId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_ProductAttributeId",
                table: "AttributeValues",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AvanceClients_ClientId",
                table: "AvanceClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BAProducts_BonAchatsId",
                table: "BAProducts",
                column: "BonAchatsId");

            migrationBuilder.CreateIndex(
                name: "IX_BAProducts_SelectedStockId",
                table: "BAProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_BcProducts_BcId",
                table: "BcProducts",
                column: "BcId");

            migrationBuilder.CreateIndex(
                name: "IX_BcProducts_SelectedStockId",
                table: "BcProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_BlProducts_BlId",
                table: "BlProducts",
                column: "BlId");

            migrationBuilder.CreateIndex(
                name: "IX_BlProducts_SelectedStockId",
                table: "BlProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Bls_ClientId",
                table: "Bls",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonAchats_FournisseurId",
                table: "BonAchats",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_BonCommandeClients_ClientId",
                table: "BonCommandeClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonCommandeFournisseurs_FournisseurId",
                table: "BonCommandeFournisseurs",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttribute_ProductAttributeId",
                table: "CategoryAttribute",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFidelites_NiveauFideliteId",
                table: "ClientFidelites",
                column: "NiveauFideliteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditClients_ClientId",
                table: "CreditClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FacProducts_FactureId",
                table: "FacProducts",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_FacProducts_SelectedStockId",
                table: "FacProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_FacProProducts_FactureProformatId",
                table: "FacProProducts",
                column: "FactureProformatId");

            migrationBuilder.CreateIndex(
                name: "IX_FacProProducts_SelectedStockId",
                table: "FacProProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_FactureAvoirs_IdFactureOriginal",
                table: "FactureAvoirs",
                column: "IdFactureOriginal");

            migrationBuilder.CreateIndex(
                name: "IX_factureProformats_ClientId",
                table: "factureProformats",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ClientId",
                table: "Factures",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesInventaireEquipes_InventaireEquipeId",
                table: "LignesInventaireEquipes",
                column: "InventaireEquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_LignesInventaireFinals_InventaireId",
                table: "LignesInventaireFinals",
                column: "InventaireId");

            migrationBuilder.CreateIndex(
                name: "IX_MotifModifications_IdAvoir",
                table: "MotifModifications",
                column: "IdAvoir");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValues_StockId",
                table: "ProductAttributeValues",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglement_Acompte_BA_Fournisseurs_BAId",
                table: "Reglement_Acompte_BA_Fournisseurs",
                column: "BAId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglement_Acompte_BA_Fournisseurs_FournisseurId",
                table: "Reglement_Acompte_BA_Fournisseurs",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglement_Acompte_Facture_Clients_ClientId",
                table: "Reglement_Acompte_Facture_Clients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reglement_Acompte_Facture_Clients_FactureId",
                table: "Reglement_Acompte_Facture_Clients",
                column: "FactureId");

            migrationBuilder.CreateIndex(
                name: "IX_RetourProducts_RetourProduitClientId",
                table: "RetourProducts",
                column: "RetourProduitClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RetourProducts_SelectedStockId",
                table: "RetourProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_RetourProductsAvoirs_FactureAvoirId",
                table: "RetourProductsAvoirs",
                column: "FactureAvoirId");

            migrationBuilder.CreateIndex(
                name: "IX_RetourProduitClients_ClientId",
                table: "RetourProduitClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_CategoryId",
                table: "Stocks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VenteComptoirProducts_SelectedStockId",
                table: "VenteComptoirProducts",
                column: "SelectedStockId");

            migrationBuilder.CreateIndex(
                name: "IX_VenteComptoirProducts_VenteComptoirId",
                table: "VenteComptoirProducts",
                column: "VenteComptoirId");

            migrationBuilder.CreateIndex(
                name: "IX_VenteComptoirs_ClientId",
                table: "VenteComptoirs",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbcProducts");

            migrationBuilder.DropTable(
                name: "AjoutProductsAvoirs");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "AvanceClients");

            migrationBuilder.DropTable(
                name: "BAProducts");

            migrationBuilder.DropTable(
                name: "BcProducts");

            migrationBuilder.DropTable(
                name: "BlProducts");

            migrationBuilder.DropTable(
                name: "Caisses");

            migrationBuilder.DropTable(
                name: "CategoryAttribute");

            migrationBuilder.DropTable(
                name: "ClientFidelites");

            migrationBuilder.DropTable(
                name: "CreanceAssainies");

            migrationBuilder.DropTable(
                name: "CreditClients");

            migrationBuilder.DropTable(
                name: "DefaultConfigLogs");

            migrationBuilder.DropTable(
                name: "Depenses");

            migrationBuilder.DropTable(
                name: "FacProducts");

            migrationBuilder.DropTable(
                name: "FacProProducts");

            migrationBuilder.DropTable(
                name: "LignesInventaireEquipes");

            migrationBuilder.DropTable(
                name: "LignesInventaireFinals");

            migrationBuilder.DropTable(
                name: "MotifModifications");

            migrationBuilder.DropTable(
                name: "MouvementStocks");

            migrationBuilder.DropTable(
                name: "ProductAttributeValues");

            migrationBuilder.DropTable(
                name: "Reglement_Acompte_BA_Fournisseurs");

            migrationBuilder.DropTable(
                name: "Reglement_Acompte_Facture_Clients");

            migrationBuilder.DropTable(
                name: "RetourProducts");

            migrationBuilder.DropTable(
                name: "RetourProductsAvoirs");

            migrationBuilder.DropTable(
                name: "SocieteInfos");

            migrationBuilder.DropTable(
                name: "VenteComptoirProducts");

            migrationBuilder.DropTable(
                name: "BonCommandeFournisseurs");

            migrationBuilder.DropTable(
                name: "BonCommandeClients");

            migrationBuilder.DropTable(
                name: "Bls");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "NiveauFidelites");

            migrationBuilder.DropTable(
                name: "factureProformats");

            migrationBuilder.DropTable(
                name: "InventaireEquipes");

            migrationBuilder.DropTable(
                name: "Inventaires");

            migrationBuilder.DropTable(
                name: "BonAchats");

            migrationBuilder.DropTable(
                name: "RetourProduitClients");

            migrationBuilder.DropTable(
                name: "FactureAvoirs");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "VenteComptoirs");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
