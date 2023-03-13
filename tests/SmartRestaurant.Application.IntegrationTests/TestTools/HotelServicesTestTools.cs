using SmartRestaurant.Application.Common.Configuration;
using SmartRestaurant.Application.HotelServices.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartRestaurant.Domain.ValueObjects;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class HotelServicesTestTools
    {
        public static async Task<HotelService> createHotelService()
        {
            var command = new CreateHotelServiceCommand
            {
                SectionId = new Guid("3cbf3570-4444-4673-8746-29b7cf568093"),
                Names = new Names()
                {

                    AR = "maintenanceService AR",
                    EN = "maintenanceService EN",
                    FR = "maintenanceService FR",
                    TR = "maintenanceService TR",
                    RU = "maintenanceService RU"
                },
                isSmartrestaurantMenue = false,
                DetailServce = new Names()
                {
                    AR = "رحلة بالقارب",
                    EN = "Boat trip",
                    FR = "francais",
                    TR = "Picanto",
                    RU = "прокат автомобилей"
                },
                TitelSeccesResponce = new Names()
                {
                    AR = "رحلة بالقارب",
                    EN = "sss55",
                    FR = "Balade en mer premiere classe",
                    TR = "Araba kiralama",
                    RU = "Picanto"
                },
                TitelFailureResponce = new Names()
                {
                    AR = "azz",
                    EN = "Boat trip",
                    FR = "Balade en mer",
                    TR = "turque",
                    RU = "Picanto"
                },
                Parametres = new List<CreateServiceParametreDto>()
            };

            var parametre = new CreateServiceParametreDto()
            {
                IsRequired = true,
                IsShowing = true,
                Names = new Names()
                {
                    AR = "paramAr",
                    FR = "paramFr",
                    EN = "paramEn",
                    TR = "paramTr",
                    RU = "paramRu"
                },
                ServiceParametreType = ServiceParametreType.NumericValue
            };

            command.Parametres.Add(parametre);
            await SendAsync(command);

            return await FindAsync<HotelService>(command.Id);
        }

        public static async Task CreateHotelServicesList(int numberOfElems, Guid sectionId)
        {

            for (var i = 0; i < numberOfElems; i++)
            {
                var command = new CreateHotelServiceCommand
                {
                    SectionId = sectionId,
                    Names = new Names()
                    {

                        AR = $"maintenanceService AR{i}",
                        EN = $"maintenanceService EN{i}",
                        FR = $"maintenanceService FR{i}",
                        TR = $"maintenanceService TR{i}",
                        RU = $"maintenanceService RU{i}"
                    },
                    isSmartrestaurantMenue = false,
                    DetailServce = new Names()
                    {
                        AR = $"رحلة بالقارب{i}",
                        EN = $"Boat trip{i}",
                        FR = $"francais{i}",
                        TR = $"Picanto{i}",
                        RU = $"прокат автомобилей{i}"
                    },
                    TitelSeccesResponce = new Names()
                    {
                        AR = $"رحلة بالقارب{i}",
                        EN = $"sss55{i}",
                        FR = $"Balade en mer premiere classe{i}",
                        TR = $"Araba kiralama{i}",
                        RU = $"Picanto{i}"
                    },
                    TitelFailureResponce = new Names()
                    {
                        AR = $"azz{i}",
                        EN = $"Boat trip{i}",
                        FR = $"Balade en mer{i}",
                        TR = $"turque{i}",
                        RU = $"Picanto{i}"
                    },
                    Parametres = new List<CreateServiceParametreDto>()
                };

                var parametre = new CreateServiceParametreDto()
                {
                    IsRequired = true,
                    IsShowing = true,
                    Names = new Names()
                    {
                        AR = $"paramAr{i}",
                        FR = $"paramFr{i}",
                        EN = $"paramEn{i}",
                        TR = $"paramTr{i}",
                        RU = $"paramRu{i}"
                    },
                    ServiceParametreType = ServiceParametreType.NumericValue
                };

                command.Parametres.Add(parametre);
                await SendAsync(command);
            }

        }
        public static async Task<HotelService> CreateHotelServiceBySectionId(Guid sectionId, string foodBusinessId)
        {

            var command = new CreateHotelServiceCommand
            {
                SectionId = sectionId,
                MenuID = null,
                FoodBusinessID = foodBusinessId,
                Names = new Names()
                {

                    AR = "مطعم مول شيراطون",
                    EN = "Mall Sheraton Restaurant",
                    FR = "Mall Sheraton Restaurant",
                    TR = "Mall Sheraton Restaurant",
                    RU = "Mall Sheraton Restaurant"
                },
                isSmartrestaurantMenue = true,
                DetailServce = new Names()
                {
                    AR = "متوفر",
                    EN = "available",
                    FR = "disponible",
                    TR = "available",
                    RU = "available"
                },
                TitelSeccesResponce = new Names()
                {
                    AR = "نعم",
                    EN = "Yes",
                    FR = "Oui",
                    TR = "Yes",
                    RU = "Yes"
                },
                TitelFailureResponce = new Names()
                {
                    AR = "لا",
                    EN = "No",
                    FR = "Non",
                    TR = "No",
                    RU = "No"
                },
                Parametres = null
            };


            await SendAsync(command);

            return await FindAsync<HotelService>(command.Id);
        }

        public static async Task<HotelService> CreateHotelParkingServiceBySectionId(Guid sectionId, string foodBusinessId)
        {

            var command = new CreateHotelServiceCommand
            {
                SectionId = sectionId,
                MenuID = null,
                FoodBusinessID = foodBusinessId,
                Names = new Names()
                {

                    AR = "باركينغ",
                    EN = "Parking",
                    FR = "Parking",
                    TR = "Parking",
                    RU = "Parking"
                },
                isSmartrestaurantMenue = false,
                DetailServce = new Names()
                {
                    AR = "متوفر",
                    EN = "available",
                    FR = "disponible",
                    TR = "available",
                    RU = "available"
                },
                TitelSeccesResponce = new Names()
                {
                    AR = "نعم",
                    EN = "Yes",
                    FR = "Oui",
                    TR = "Yes",
                    RU = "Yes"
                },
                TitelFailureResponce = new Names()
                {
                    AR = "لا",
                    EN = "No",
                    FR = "Non",
                    TR = "No",
                    RU = "No"
                },
                Parametres = new List<CreateServiceParametreDto>()
            };
            var parametre = new CreateServiceParametreDto()
            {
                IsRequired = true,
                IsShowing = true,
                Names = new Names()
                {
                    AR = "عدد الساعات",
                    FR = "nombre de heures",
                    EN = "nombre de heures",
                    TR = "nombre de heures",
                    RU = "nombre de heures"
                },
                ServiceParametreType = ServiceParametreType.NumericValue
            };

            command.Parametres.Add(parametre);

            await SendAsync(command);

            return await FindAsync<HotelService>(command.Id);
        }

    }

}

