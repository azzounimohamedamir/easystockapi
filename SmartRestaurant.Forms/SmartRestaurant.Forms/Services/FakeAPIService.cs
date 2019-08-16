using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using SmartRestaurant.Application.Services;
using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Forms.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Forms.Services
{
    public class FakeAPIService : IAPIService
    {
        public async Task<List<LanguageCulture>> GetLanguagesAsync()
        {
            return await Task.Run(() =>
            {
                return new List<LanguageCulture>
                {
                    new LanguageCulture{ CultureIso=EnumLaguangeIso.Ar,
                        LanguageName ="العربية" ,
                        SelectLanguage = "اختر لغتك",

            },
                    new LanguageCulture{ CultureIso=EnumLaguangeIso.Fr,
                        LanguageName ="Français" ,
                         SelectLanguage = "choisir voter langauge ",
                    },
                    new LanguageCulture{ CultureIso=EnumLaguangeIso.En,
                        LanguageName ="English" ,
                        SelectLanguage = "choose your language ",

                    },
                };
 
            });
        }

        public  Task<ServiceModel> GetRestaurantServiceAsync(string restaurantId, EnumLaguangeIso language)
        {

            Task<ServiceModel> val = null;
            if (language== EnumLaguangeIso.Ar)
            {
                val = Task.Factory.StartNew(() =>
                {
                    return new ServiceModel
                    {
                        ServiceName = "ServiceName",
                        Sections = new List<SectionModel>
                        {
                            new SectionModel
                            {
                                Name="المقبلات",
                                Childs = new List<SectionModel>
                                {
                                    new SectionModel
                                    {
                                        Name="مقبلات 01",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                            new MenuDishItemModel
                                            {
                                                Name ="طبق 01" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "بطاطا"},
                                                    new IngredientModel{ Name = "طماطم"},
                                                    new IngredientModel{ Name = "بيض"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="وصف وصف وصف",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                             new MenuDishItemModel
                                            {
                                                Name ="طبق 02" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                             new MenuDishItemModel
                                            {
                                                Name ="طبق 03" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                             new MenuDishItemModel
                                            {
                                                Name ="طبق 04" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            }


                                        }
                                    },
                                    new SectionModel
                                    {
                                        Name="مقبلات 02",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                             new MenuDishItemModel
                                            {
                                                Name ="Dish01" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                            new MenuDishItemModel{ Name="Dish04"},
                                        }
                                    }
                                }
                            },
                            new SectionModel
                            {
                                Name="الأطباق",
                                Childs = new List<SectionModel>
                                {
                                    new SectionModel
                                    {
                                        Name="Plat 01",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                             new MenuDishItemModel
                                            {
                                                Name ="Plat 01" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                            new MenuDishItemModel
                                            {
                                                Name ="Plat 02" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            }
                                        }
                                    },
                                     new SectionModel
                                    {
                                        Name="Plat 02",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                            new MenuDishItemModel{ Name="Plat03"},
                                            new MenuDishItemModel{ Name="Plat04"},
                                        }
                                    }
                                }
                            },
                              new SectionModel
                            {
                                Name="الشواء",
                                Childs = new List<SectionModel>
                                {
                                    new SectionModel
                                    {
                                        Name="Plat 01",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                            new MenuDishItemModel{ Name="Plat01"},
                                            new MenuDishItemModel{ Name="Plat02"},
                                        }
                                    },
                                     new SectionModel
                                    {
                                        Name="Plat 02",
                                        Childs = new List<SectionModel>
                                        {
                                           new SectionModel
                                           {   Name="Plat 02 01",
                                               Dishes = new List<MenuDishItemModel>
                                               {
                                                   new MenuDishItemModel{ Name="Plat03"},
                                                  new MenuDishItemModel{ Name="Plat04"},
                                               }
                                           },
                                           new SectionModel
                                           {   Name="Plat 02 02",
                                               Dishes = new List<MenuDishItemModel>
                                               {
                                                   new MenuDishItemModel{ Name="Plat03"},
                                                  new MenuDishItemModel{ Name="Plat04"},
                                               }
                                           }
                                        }
                                    }
                                }
                            }
                        }
                    };
                });
            }
            else
            {
                val = Task.Factory.StartNew(() =>
                {
                    return new ServiceModel
                    {
                        ServiceName = "ServiceName",
                        Sections = new List<SectionModel>
                        {
                            new SectionModel
                            {
                                Name="Entreé",
                                Childs = new List<SectionModel>
                                {
                                    new SectionModel
                                    {
                                        Name="Entreé 01",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                            new MenuDishItemModel
                                            {
                                                Name ="Dish01" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                             new MenuDishItemModel
                                            {
                                                Name ="Dish02" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                             new MenuDishItemModel
                                            {
                                                Name ="Dish03" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                             new MenuDishItemModel
                                            {
                                                Name ="Dish04" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            }


                                        }
                                    },
                                    new SectionModel
                                    {
                                        Name="Entreé 02",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                             new MenuDishItemModel
                                            {
                                                Name ="Dish01" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                            new MenuDishItemModel{ Name="Dish04"},
                                        }
                                    }
                                }
                            },
                            new SectionModel
                            {
                                Name="Plat",
                                Childs = new List<SectionModel>
                                {
                                    new SectionModel
                                    {
                                        Name="Plat 01",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                             new MenuDishItemModel
                                            {
                                                Name ="Plat 01" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            },
                                            new MenuDishItemModel
                                            {
                                                Name ="Plat 02" ,
                                                Ingredients = new List<IngredientModel>
                                                {
                                                    new IngredientModel{ Name = "potato"},
                                                    new IngredientModel{ Name = "tomato"},
                                                    new IngredientModel{ Name = "egg"},
                                                },
                                                Price= new PriceModel{ Amount=500, Currency="DA" } ,
                                                Description="Description Description Description",
                                                DishId= Guid.NewGuid().ToString(),
                                                Nutrrition = new DishNutrritionModel
                                                {
                                                    Calorie=50,
                                                    Carbohydrate=10,
                                                    Fibre=2,
                                                    GlycemicIndex=15,
                                                    Lipid=65,
                                                    Protein=200
                                                }
                                            }
                                        }
                                    },
                                     new SectionModel
                                    {
                                        Name="Plat 02",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                            new MenuDishItemModel{ Name="Plat03"},
                                            new MenuDishItemModel{ Name="Plat04"},
                                        }
                                    }
                                }
                            },
                              new SectionModel
                            {
                                Name="Plat",
                                Childs = new List<SectionModel>
                                {
                                    new SectionModel
                                    {
                                        Name="Plat 01",
                                        Dishes = new List<MenuDishItemModel>
                                        {
                                            new MenuDishItemModel{ Name="Plat01"},
                                            new MenuDishItemModel{ Name="Plat02"},
                                        }
                                    },
                                     new SectionModel
                                    {
                                        Name="Plat 02",
                                        Childs = new List<SectionModel>
                                        {
                                           new SectionModel
                                           {   Name="Plat 02 01",
                                               Dishes = new List<MenuDishItemModel>
                                               {
                                                   new MenuDishItemModel{ Name="Plat03"},
                                                  new MenuDishItemModel{ Name="Plat04"},
                                               }
                                           },
                                           new SectionModel
                                           {   Name="Plat 02 02",
                                               Dishes = new List<MenuDishItemModel>
                                               {
                                                   new MenuDishItemModel{ Name="Plat03"},
                                                  new MenuDishItemModel{ Name="Plat04"},
                                               }
                                           }
                                        }
                                    }
                                }
                            }
                        }
                    };
                });
            }
              
            return val;
        }

        public  Task<string> GetRestaurantServiceIdAsync(string restaurantId)
        {           
            return  Task.Factory.StartNew(() =>
            {
                return Guid.NewGuid().ToString();
               // return "11";                 
            });
        }

        public async Task<List<TableItemModel>> GetRestaurantTablesAsync(string restaurantId)
        {
            return await Task.Run(() =>
            {
                return new List<TableItemModel>
                {
                    new TableItemModel { Name="Table01"},
                    new TableItemModel { Name="Table02"},
                    new TableItemModel { Name="Table03"},
                    new TableItemModel { Name="Table04"},
                };
            });
        }
    }
}
