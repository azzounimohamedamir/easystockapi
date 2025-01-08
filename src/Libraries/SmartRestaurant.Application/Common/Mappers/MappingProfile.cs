using System;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using SmartRestaurant.Application.AdminArea.Commands;
using SmartRestaurant.Application.Clients.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Depenses.Commands;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Commands;
using SmartRestaurant.Application.GestionAchats.BonsAchat.Commands;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands;
using SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Commands;
using SmartRestaurant.Application.GestionStock.Inventaire.Commands;
using SmartRestaurant.Application.GestionStock.Stock.Commands;
using SmartRestaurant.Application.GestionVentes.BonCommandeClient.Commands;
using SmartRestaurant.Application.GestionVentes.Caisses.Commands;
using SmartRestaurant.Application.GestionVentes.FactureProformat.Commands;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands;
using SmartRestaurant.Application.GestionVentes.VenteParBl.Commands;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Commands;
using SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Commands;
using SmartRestaurant.Application.Parametres.SocieteInfo.Commands;
using SmartRestaurant.Application.ProgrammeFidelite.Commands;
using SmartRestaurant.Application.Stock.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Stock, StockDto>()
                
                    
                .ReverseMap();
            CreateMap<FactureAvoir, FactureAvoirDto>()
               .ReverseMap();
            CreateMap<Facture, FactureDto>()
              .ReverseMap();
            CreateMap<Category, CategoryDto>()
            .ReverseMap();
            CreateMap<CategoryAttribute, CategoryAttributsDto>()
          .ReverseMap();
            CreateMap<ProductAttribute, ProductAttributeDto>()
          .ReverseMap();
            CreateMap<AttributeValue, AttributeValueDto>()
          .ReverseMap();
            CreateMap<ProductAttributeValue, ProductAttributeValueDto>()
             .ReverseMap();
            CreateMap<FactureAvoirDto, FactureDto>()
              .ReverseMap();
            CreateMap<RetourProductsAvoir, RetourProductsAvoirDto>()
              .ReverseMap();
            CreateMap<AjoutProductsAvoir, AjoutProductsAvoirDto>()
             .ReverseMap();
            CreateMap<MotifModification, MotifModificationDto>()
              .ReverseMap();
            CreateMap<FacProducts, FacProductsDto>()
              .ReverseMap();


            CreateMap<FacProProducts, FacProProductsDto>()
             .ReverseMap();
            CreateMap<ClientFidelite, ClientFideliteDto>()
          .ReverseMap();
            CreateMap<NiveauFidelite, NiveauFideliteDto>()
.ReverseMap();

            CreateMap<Domain.Entities.BlProducts, RetourProducts>()
             .ForMember(x => x.DocumentId, o => o.MapFrom(p => p.BlId))
                            .ReverseMap();

            CreateMap<AjoutProductsAvoir, FacProducts>()
       .ForMember(x => x.FactureId, o => o.MapFrom(p => p.DocumentId))
       .ReverseMap();
            CreateMap<CreateClientAppCommand, MyClients>()
     .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
     .ReverseMap();
            CreateMap<CreateLicenceCommand, LicenceKeys>()
   .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
   .ReverseMap();
            CreateMap<UpdateClientAppCommand, MyClients>()
  .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
  .ReverseMap();
            CreateMap<UpdateLicenceCommand, LicenceKeys>()
  .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
  .ReverseMap();
            CreateMap<ResetLicenceCommand, LicenceKeys>()
  .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
  .ReverseMap();
            CreateMap<CreateInventaireParEquipeCommand, InventaireEquipe>()
    .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
    .ReverseMap();

            CreateMap<CreateSocieteInfoCommand, SocieteInfo>()
   .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
   .ReverseMap();




            CreateMap<AjouterNivFideliteCommand, NiveauFidelite>()
  .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
  .ReverseMap();

            CreateMap<UpdateNivFideliteCommand, NiveauFidelite>()
  .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
  .ReverseMap();

            CreateMap<UpdatePointFideliteClientCommand, ClientFidelite>()
.ReverseMap();



            CreateMap<UpdateSocieteInfoCommand, SocieteInfo>()
   .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
   .ReverseMap();

            CreateMap<CreateDefaultConfigCommand, DefaultConfigLog>()
.ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
.ReverseMap();

            CreateMap<UpdateDefaultConfigCommand, DefaultConfigLog>()
   .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
   .ReverseMap();
            CreateMap<InviteUserToJoinOrganizationCommand, ApplicationUser>()
                            .ForMember(x => x.UserName, o => o.MapFrom(p => p.Email));

            CreateMap<UserAcceptsInvitationToJoinOrganizationCommand, ApplicationUser>()
                .ForMember(x => x.Email, o => o.Ignore());


            CreateMap<ApplicationUser, EmployeDto>()
                .ReverseMap();

            CreateMap<ReglerEcartsInventaireCommand, LignesInventaireFinal>()
   .ReverseMap();

            CreateMap<Inventaire, InventaireDto>()
 .ReverseMap();


            CreateMap<BonCommandeClient, BonCommandeClientDto>()
 .ReverseMap();
            CreateMap<BcProducts, BcProductsDto>()
.ReverseMap();
            CreateMap<LignesInventaireFinal, LignesInventaireFinalDto>()
                    .ForMember(x => x.CodeProduit, o => o.MapFrom(p => p.CodeProduit))
                    .ForMember(x => x.CodeBar, o => o.MapFrom(p => p.CodeBar))

.ReverseMap();
            CreateMap<RetourProductsAvoir, FacProducts>()
      .ForMember(x => x.FactureId, o => o.MapFrom(p => p.DocumentId))
      .ReverseMap();

            CreateMap<RetourProducts, VenteComptoirProducts>()
    .ForMember(x => x.VenteComptoirId, o => o.MapFrom(p => p.DocumentId))
    .ReverseMap();




            CreateMap<Domain.Entities.FactureProformat, FactureProformatDto>()
               .ReverseMap();
            CreateMap<Domain.Entities.AttributeValue, AttributeValueDto>()
              .ReverseMap();
            CreateMap<Domain.Entities.ProductAttribute, ProductAttributeDto>()
              .ReverseMap();

            CreateMap<Domain.Entities.Category, CategoryDto>()
              .ReverseMap();

            CreateMap<AttributsNew, ProductAttributeValue>()
              .ReverseMap();


            CreateMap<CreateProductOnStockCommand, Domain.Entities.Stock>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
                .ReverseMap();
            CreateMap<ImportStockFromExcelCommand, Domain.Entities.Stock>()
               .ReverseMap();

            CreateMap<UpdateProductOnStockCommand, Domain.Entities.Stock>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
                .ReverseMap();


         
            CreateMap<CreateDepenseCommand, Domain.Entities.Depense>()
            .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
            .ReverseMap();

            CreateMap<UpdateDepenseCommand, Domain.Entities.Depense>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
                .ReverseMap();

           

            

          



            CreateMap<AjouterPermRoleCommand, Domain.Identity.Entities.Permissions>()
      .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
      .ReverseMap();
            CreateMap<UpdatePermRoleCommand, Domain.Identity.Entities.Permissions>()
     .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
     .ReverseMap();



            CreateMap<CreateCaisseCommand, Caisses>()
     .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
     .ReverseMap();
            CreateMap<UpdateCaisseCommand, Caisses>()
     .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
     .ReverseMap();

            CreateMap<UpdateProfilUserCommand, ApplicationUser>()
 .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
 .ReverseMap();


            CreateMap<CreateVenteComptoirCommand, Domain.Entities.VenteComptoir>()
              .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
              .ReverseMap();
            CreateMap<UpdateVenteComptoirCommand, Domain.Entities.VenteComptoir>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
           
             .ReverseMap();





            CreateMap<CreateBlCommand, Bl>()
            .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
            .ReverseMap();
            CreateMap<UpdateBlCommand, Bl>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
            
             .ReverseMap();

            CreateMap<CreateFactureCommand, Facture>()
         .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
         .ReverseMap();
            CreateMap<UpdateFactureCommand, Facture>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ReverseMap();


            CreateMap<CreateBCCommand, BonCommandeClient>()
       .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
       .ReverseMap();
            CreateMap<UpdateBCCommand, BonCommandeClient>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ForMember(x => x.Numero, o => o.Ignore())
             .ReverseMap();



            CreateMap<CreateBCFCommand, BonCommandeFournisseur>()
     .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
     .ReverseMap();
            CreateMap<UpdateBCFCommand, BonCommandeFournisseur>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ForMember(x => x.Numero, o => o.Ignore())
             .ReverseMap();



            CreateMap<CreateBACommand, BonAchats>()
     .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
     .ReverseMap();
            CreateMap<UpdateBACommand, BonAchats>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ForMember(x => x.Numero, o => o.Ignore())
             .ReverseMap();


            CreateMap<AjouterRegAcompteBACommand, Domain.Entities.Reglement_Acompte_BA_Fournisseur>()
           .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
           .ReverseMap();

            CreateMap<AjouterRegAcompteFactureCommand, Domain.Entities.Reglement_Acompte_Facture_Client>()
            .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
            .ReverseMap();

            CreateMap<CreateClientCommand, Domain.Entities.Client>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ReverseMap();
           
            CreateMap<UpdateClientCommand, Domain.Entities.Client>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ReverseMap();

            CreateMap<AssainirClientCommand, Domain.Entities.Client>()
            .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
            .ReverseMap();

            CreateMap<CreateFournisseurCommand, Fournisseur>()
            .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
            .ReverseMap();

            CreateMap<UpdateFournisseurCommand, Fournisseur>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ReverseMap();
            CreateMap<Domain.Entities.VenteComptoir, VenteComptoirDto>()
           .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
           .ReverseMap();


            CreateMap<CreateFactureProformatCommand, Facture>()
      .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
      .ReverseMap();
            CreateMap<UpdateFactureProformatCommand, Facture>()
             .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
             .ReverseMap();

          



            CreateMap<Domain.Entities.Client, ClientDto>().ReverseMap();
            CreateMap<Reglement_Acompte_Facture_Client, Reglement_Acompte_Facture_Client_Dto>();


            CreateMap<Domain.Entities.CreditClients, CreditDto>();
            CreateMap<Domain.Entities.AvanceClients, AvanceDto>();



            CreateMap<Domain.Entities.CreditClients, CreditDto>()
        .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
        .ReverseMap();
            CreateMap<Domain.Entities.AvanceClients, AvanceDto>()
        .ForMember(x => x.Id, o => o.MapFrom(p => p.Id))
        .ReverseMap();


          
        }




    }
}