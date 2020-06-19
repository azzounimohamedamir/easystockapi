using Helpers;
using SmartRestaurant.Domain.Allergies;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Foods;
using SmartRestaurant.Domain.Products;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Persistence.ApplicationDataBase
{
    public class SmartRestaurantDatabaseSeed
    {
        private readonly string uploads = "https://localhost:5000/uploads";
        private readonly string uploadsFoodCategories = $"https://localhost:5000/uploads/foods/categories";
        private readonly string uploadsFood = $"https://localhost:5000/uploads/foods/foods";

        public SmartRestaurantDatabaseSeed(SmartRestaurantDbContext context)
        {
            this.context = context;
        }

        private readonly Dictionary<string, Guid> chainsIds = new Dictionary<string, Guid>
        {
            {
                "CH01",

                "a6e6b3ab-8f73-4af2-a7c0-b6d5d6e22372".ToGuid()

            },
            {
                "CH02",
                "0338643f-87c8-4415-bd14-256020fcf34e".ToGuid()
            },
            {
                "CH03",
                "0c703c18-4d7f-4586-b1d6-d02a60df9b09".ToGuid()
            }
        };

        private readonly Dictionary<string, Guid> restaurantsIds = new Dictionary<string, Guid>
        {
            {
                "RST01",
                "27e7e25a-cf92-4ea5-a9cc-b77d4d220efc".ToGuid()
            },
            {
                "RST02",
                "12689539-7dfc-4916-9ac0-692f50bb03c3".ToGuid()
            },
            {
                "RST03",
                "ada8720c-52e4-472d-b92c-252ba638db2f".ToGuid()
            }
        };

        private readonly SmartRestaurantDbContext context;

        private Dictionary<string, Address> address = new Dictionary<string, Address>
        {
            {
                "Alger",
                new Address("Cite des roses", "Alger", "Alger", "Algérie", "16100")
            },
            {
                "Blida",
                new Address("Cite des fleurs", "Blida", "Blida", "Algérie", "09100")
            },
            {
                "Tipaza",
                new Address("Cite des enfants", "Tipaza", "Tipaza", "Algérie", "42100")
            }
        };

        private Dictionary<string, Currency> currencies = new Dictionary<string, Currency>();
        private Dictionary<string, Language> languages = new Dictionary<string, Language>();
        private Dictionary<int, RestaurantType> types = new Dictionary<int, RestaurantType>();
        private Dictionary<int, Owner> owners = new Dictionary<int, Owner>();
        private Dictionary<int, Chain> chains = new Dictionary<int, Chain>();
        private Dictionary<int, Restaurant> restaurants = new Dictionary<int, Restaurant>();
        private Dictionary<string, FoodCategory> foodCategories = new Dictionary<string, FoodCategory>();
        private Dictionary<string, Unit> units = new Dictionary<string, Unit>();

        private Dictionary<string, Allergy> allergies = new Dictionary<string, Allergy>();
        private Dictionary<string, Illness> illness = new Dictionary<string, Illness>();

        List<ProductFamily> PopulateProductsFamillies()
        {
            return new List<ProductFamily>
            {
                new ProductFamily
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="PF-01",
                        Name="Boissons",
                        Description="",
                        Products=new List<Product>
                        {
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="JUS",
                                Name="Jus d'orange et abricot ROUIBA",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="JUS",
                                Name="Jus d'orange JUFRÉ",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="JUS",
                                Name="Jus d'orange TASSILO 1 L",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="LAIT",
                                Name="Lait chocolaté TASSILO",
                                Description=""
                            },
                        }
                    },
                new ProductFamily
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="PF-02",
                        Name="Eaux",
                        Description="",
                        Products=new List<Product>
                        {
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="EGAZ",
                                Name="EAU GAZ LALLA KHEDIDJA 1L",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="EAU",
                                Name="EAU MINERAL Mont djurdjura 1L",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="EAU",
                                Name="EAU MINERALE 50 CL",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="EAU",
                                Name="EAU DE SOURCE MANBAA 0,5L",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="EAU",
                                Name="EAU MINERALE NGAOUES 50 CL",
                                Description=""
                            },
                            new Product
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="EAU",
                                Name="EAU GAZIFIE 33CL",
                                Description=""
                            },
                        }
                    }
            };
        }

        List<DishFamily> PopulateDishesFamillies(Guid restaurantId)
        {
            return new List<DishFamily>
            {
                new DishFamily
                    {
                        Id=Guid.NewGuid(),
                        RestaurantId=restaurantId,
                        IsDisabled=false,
                        Alias="ENT",
                        Name="Entrées",
                        Description="",
                        Childs=new List<DishFamily>
                        {
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="ENTCH",
                                Name="Entrées Chaudes",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="ENTFR",
                                Name="Entrées Froides",
                                Description="",
                            }
                        }
                    },
                new DishFamily
                    {
                        Id=Guid.NewGuid(),
                        RestaurantId=restaurantId,
                        IsDisabled=false,
                        Alias="PLA",
                        Name="Plats",
                        Description="",
                        Childs=new List<DishFamily>
                        {
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="PLAPO",
                                Name="Poissons",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="PLAVR",
                                Name="Viandes rouges",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="PLAVB",
                                Name="Viandes blanches",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="PLATJ",
                                Name="Tajines",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="PLAPL",
                                Name="Pâtes et lasagne",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="PLAGL",
                                Name="Grillades",
                                Description="",
                            },
                        }
                    },
                new DishFamily
                    {
                        Id=Guid.NewGuid(),
                        RestaurantId=restaurantId,
                        IsDisabled=false,
                        Alias="BOI",
                        Name="Boissons",
                        Description="",
                        Childs=new List<DishFamily>
                        {
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="BOICO",
                                Name="Cocktail",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="BOIJP",
                                Name="Jus pressé",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="BOISO",
                                Name="Soda",
                                Description="",
                            }
                        }
                    },
                new DishFamily
                    {
                        Id=Guid.NewGuid(),
                        RestaurantId=restaurantId,
                        IsDisabled=false,
                        Alias="DES",
                        Name="Desserts",
                        Description="",
                        Childs=new List<DishFamily>
                        {
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="DESGT",
                                Name="Gâteaux",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="DESTR",
                                Name="Tartes",
                                Description="",
                            },
                            new DishFamily
                            {
                                Id=Guid.NewGuid(),
                                RestaurantId=restaurantId,
                                IsDisabled=false,
                                Alias="DESTM",
                                Name="Tiramisu",
                                Description="",
                            }
                        }
                    }
            };
        }

        private decimal RandomDecimal()
        {
            Random random = new Random();
            int r = random.Next(100, 10000);
            return (decimal)r / 10;
        }

        private Nutrition GetRandomNutrition()
        {
            var Qt = new Quantity(units.GetValueOrDefault("g").Id, RandomDecimal());
            var nutrrition = new Nutrition(Qt, RandomDecimal(), RandomDecimal(), RandomDecimal(), RandomDecimal(), RandomDecimal(), RandomDecimal());
            return nutrrition;
        }

        void SetUnitAndPicture(FoodCategory category)
        {
            if (category.Picture != null) category.Picture.Name = category.Name;
            if (category.Childs != null)
            {
                foreach (var child in category.Childs)
                {
                    SetUnitAndPicture(child);
                }
            }
            if (category.Foods != null)
            {
                foreach (var food in category.Foods)
                {
                    food.UnitId = units.GetValueOrDefault("g").Id;
                    if (food.Picture != null) food.Picture.Name = food.Name;
                }
            }
        }

        void SeedFoodCategories()
        {
            foodCategories = new Dictionary<string, FoodCategory>
            {
                {
                    "VPO", //Viandes - poissons - OEufs
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="VPO",
                        Name="Viandes - poissons - OEufs",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Name="Not defined",
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/viandes-poissons-oeufs.jpg"
                        },
                        Childs=new List<FoodCategory>
                        {
                            new FoodCategory //Les viandes
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="VPOVI",
                                Name="Les viandes",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/viandes.jpg"
                                },
                                Childs=new List<FoodCategory>
                                {
                                    new FoodCategory
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="VPOVR",
                                        Name="Les viandes rouges",
                                        Description="",
                                        Picture=new Picture
                                        {
                                            Id=Guid.NewGuid(),
                                            IsDisabled=false,
                                            Name="Not defined",
                                            Alias="",
                                            Description="",
                                            ImageUrl=$"{uploadsFoodCategories}/viandes-rouges.jpg"
                                        },
                                        Foods=new List<Food>
                                        {
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Agneau",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/agneau.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Boeuf",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/boeuf.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Cheval",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/cheval.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Mouton",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/mouton.jpg"
                                                }
                                            },
                                        }
                                    },
                                    new FoodCategory
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="VPOVB",
                                        Name="Les viande blanche",
                                        Description="",
                                        Picture=new Picture
                                        {
                                            Id=Guid.NewGuid(),
                                            IsDisabled=false,
                                            Name="Not defined",
                                            Alias="",
                                            Description="",
                                            ImageUrl=$"{uploadsFoodCategories}/viandes-blanches.jpg"
                                        },
                                        Foods=new List<Food>
                                        {
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Lapin",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/lapin.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Veau",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/veau.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Volailles",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/volailles.jpg"
                                                }
                                            },
                                        }
                                    },
                                    new FoodCategory
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="VPOVN",
                                        Name="Les viande noire",
                                        Description="",
                                        Picture=new Picture
                                        {
                                            Id=Guid.NewGuid(),
                                            IsDisabled=false,
                                            Name="Not defined",
                                            Alias="",
                                            Description="",
                                            ImageUrl=$"{uploadsFoodCategories}/viandes-noires.jpg"
                                        },
                                        Foods=new List<Food>
                                        {
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Biche",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/biche.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Chevreuil",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/chevreuil.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Faisan",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/faisan.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Lièvre",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/lievre.jpg"
                                                }
                                            },
                                        }
                                    },
                                    new FoodCategory
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="VPOVO",
                                        Name="Volaille",
                                        Description="",
                                        Picture=new Picture
                                        {
                                            Id=Guid.NewGuid(),
                                            IsDisabled=false,
                                            Name="Not defined",
                                            Alias="",
                                            Description="",
                                            ImageUrl=$"{uploadsFoodCategories}/volailles.jpg"
                                        },
                                        Foods=new List<Food>
                                        {
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Dinde",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/dinde.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Canard",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/canard.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Oie",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/oie.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Pintade",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/pintade.jpg"
                                                }
                                            },
                                            new Food
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="",
                                                Name="Poulet",
                                                Description="",
                                                Nutrition=GetRandomNutrition(),
                                                Picture=new Picture
                                                {
                                                     Id=Guid.NewGuid(),
                                                     IsDisabled=false,
                                                     Name="Not defined",
                                                     Alias="",
                                                     Description="",
                                                     ImageUrl=$"{uploadsFood}/poulet.jpg"
                                                }
                                            },
                                        }
                                    }
                                }
                            },
                            new FoodCategory //Les charcuteries
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="VPOCA",
                                Name="Les charcuteries",
                                Description="",
                            },
                            new FoodCategory //Les poissons
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="VPOPO",
                                Name="Les poissons",
                                Description="",
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFoodCategories}/poissons.jpg"
                                },
                                Foods=new List<Food>
                                {
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Dorade",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/dorade.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Colin",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/colin.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Cabillaud",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/cabillaud.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Sole",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/sole.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Lieu",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/lieu.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Truite",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/truite.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Limande",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/limande.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Anchois",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/anchois.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Sardine",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/sardine.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Maquereau",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/maquereau.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Anguille",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/anguille.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Thon",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/thon.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Hareng",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/hareng.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Saumon",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/saumon.jpg"
                                        }
                                    },
                                },
                            },
                            new FoodCategory //Les fruits de mer
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="VPOPO",
                                Name="Les fruits de mer",
                                Description="",
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFoodCategories}/mollusques.jpg"
                                },
                                Foods=new List<Food>
                                {
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Crevette",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/crevette.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Crabe",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/crabe.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Ecrevisse",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/ecrevisse.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Langouste",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/langouste.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Homard",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/homard.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Bulot",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/bulot.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Huître",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/huitre.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Coques",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/coques.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Calamar",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/calamar.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Moule",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/moule.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Seiche",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/seiche.jpg"
                                        }
                                    },
                                },
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="VPOOF",
                                Name="Les oeufs",
                                Description="",
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFoodCategories}/oeufs.jpg"
                                },
                            },
                        }

                    }
                },
                {
                    "PL", //Produits laitiers
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="PL",
                        Name="Produits laitiers",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Name="Not defined",
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/produits-laitiers.jpg"
                        },
                        Childs=new List<FoodCategory>
                        {
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="PLLT",
                                Name="Le lait et beurre",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/produits-laitiers.jpg"
                                },
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="PLFR",
                                Name="Les fromages",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/fromages.jpg"
                                },
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="PLCR",
                                Name="Les crème",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/creme.jpg"
                                },
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="PLYT",
                                Name="Yaourt",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/yaourt.jpg"
                                },
                            },
                        }

                    }
                },
                {
                    "MG", //Matières grasses
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="MG",
                        Name="Matières grasses",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Name="Not defined",
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/matieres-grasses.jpg"
                        },
                        Childs=new List<FoodCategory>
                        {
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="MGOA",
                                Name="Matières grasses d’origine animale",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/matieres-grasses.jpg"
                                },
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="MGHU",
                                Name="Huiles",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/huile.jpg"
                                },
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="MGMR",
                                Name="Margarines",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/margarine.jpg"
                                },
                            },
                        }

                    }
                },
                {
                    "LF", //Les fruits et les légumes frais
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="LF",
                        Name="Les fruits et les légumes frais",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Name="Not defined",
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/fruits-et-legumes-frais.jpg"
                        },
                        Childs=new List<FoodCategory>
                        {
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="LFLE",
                                Name="Légumes",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/legumes.jpg"
                                },
                                Foods=new List<Food>
                                {
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Ail",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/ail.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Artichaut",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/artichaut.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Asperge",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/asperge.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Aubergine",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/aubergine.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Bette",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/bette.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Betterave",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/betterave.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Brocoli",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/brocoli.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Carotte",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/carotte.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Céleri",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/celeri.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Champignon",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/champignon.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Chou",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/chou.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Chou de Bruxelles",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/chou-de-bruxelles.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Chou-fleur",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/chou-fleur.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Chou-rave",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/chou-rave.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Chou rouge",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/chou-rouge.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Chou vert",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/chou-vert.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Citrouille",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/citrouille.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Concombre",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/concombre.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Courgette",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/courgette.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Cresson",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/cresson.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Crosne",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/crosne.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Echalote",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/echalote.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Endive",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/endive.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Epinard",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/epinard.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Fenouil",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/fenouil.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Haricot vert",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/haricot-vert.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Laitue",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/Laitue.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Lentille",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/lentille.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Maïs",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/mais.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Melon",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/melon.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Navet",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/navet.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Oignon",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/oignon.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Petit pois",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/petit-pois.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pissenlit",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pissenlit.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Poireau",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/poireau.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Poivron",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/poivron.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pomme de terre",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pomme-de-terre.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Radis",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/radis.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Rhubarbe",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/rhubarbe.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Salsifis",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/salsifis.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Soja",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/soja.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Tomate",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/tomate.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Topinambour",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/topinambour.jpg"
                                        }
                                    },
                                }
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="LFFF",
                                Name="Fruits",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/fruits.jpg"
                                },
                                Foods=new List<Food>
                                {
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Abricot",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/abricot.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Amande",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/amande.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Ananas",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/ananas.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Avocat",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/avocat.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Baie de goji",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/baie-de-goji.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Banane",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/banane.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Cacahuète",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/cacahuete.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Cassis",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/cassis.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Cerise",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/cerise.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Châtaigne",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/chataigne.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Citron",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/citron.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Clémentine",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/clementine.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Coing",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/coing.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Datte",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/datte.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Figue",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/figue.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Fraise",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/fraise.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Framboise",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/framboise.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Fruit de la passion",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/fruit-de-la-passion.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Goyave",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/goyave.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Grenade",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/grenade.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Groseille",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/groseille.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Kaki",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/kaki.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Kiwi",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/kiwi.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Litchi",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/litchi.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Mandarine",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/mandarine.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Mangue",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/mangue.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Mirabelle",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/mirabelle.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Mûre",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/mure.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Myrtille",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/myrtille.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Nectarine",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/nectarine.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Noisette",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/noisette.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Noix",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/noix.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Noix de cajou",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/noix-de-cajou.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Noix de coco",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/noix-de-coco.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Noix de pécan",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/noix-de-pecan.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Noix du brésil",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/noix-du-bresil.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Orange",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/orange.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pamplemousse",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pamplemousse.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Papaye",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/papaye.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pastèque",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pasteque.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pêche",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/Peche.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pignon de pin",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pignon-de-pin.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pistache",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pistache.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Poire",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/poire.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pomme",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pomme.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Prune",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/prune.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pruneau",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pruneau.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Raisin",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/raisin.jpg"
                                        }
                                    }
                                }
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="LFFS",
                                Name="Fruits secs",
                                Description="",
                            },
                        }

                    }
                },
                {
                    "CDL", //Céréales et dérivés - légumineuses
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CDL",
                        Name="Céréales et dérivés - légumineuses",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Name="Not defined",
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/cereales-feculents.jpg"
                        },
                        Childs=new List<FoodCategory>
                        {
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="CDLCD",
                                Name="Céréales et dérivés",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/cereales-feculents.jpg"
                                },
                                Foods=new List<Food>
                                {
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Amarante",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/amarante.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Avoine",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/avoine.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Blé",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/blé.jpg"
                                        }
                                    },

                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Millet",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/millet.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Orge",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/orge.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Sarrasin",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/sarrasin.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Seigle",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/seigle.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Triticale",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/triticale.jpg"
                                        }
                                    },
                                }
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="CDLLE",
                                Name="Légumes secs",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/legumes-secs.jpg"
                                },
                                Foods=new List<Food>
                                {
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Lentilles",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/lentilles.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Fèves",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/feves.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Haricots blancs",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/haricots-blancs.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Haricots rouges",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/haricots-rouges.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Flageolets",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/flageolets.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pois cassés",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pois-casses.jpg"
                                        }
                                    },
                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Pois chiches",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/pois-chiches.jpg"
                                        }
                                    },

                                    new Food
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="",
                                        Name="Petits pois",
                                        Description="",
                                        Nutrition=GetRandomNutrition(),
                                        Picture=new Picture
                                        {
                                             Id=Guid.NewGuid(),
                                             IsDisabled=false,
                                             Name="Not defined",
                                             Alias="",
                                             Description="",
                                             ImageUrl=$"{uploadsFood}/petits-pois.jpg"
                                        }
                                    },
                                }
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="CDLPT",
                                Name="pâtes",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/pates.jpg"
                                },
                            },
                            new FoodCategory
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="CDLPT",
                                Name="Pains",
                                Description="",
                                Picture=new Picture
                                {
                                    Id=Guid.NewGuid(),
                                    IsDisabled=false,
                                    Name="Not defined",
                                    Alias="",
                                    Description="",
                                    ImageUrl=$"{uploadsFoodCategories}/pain.jpg"
                                },
                            },
                        }

                    }
                },
                {
                    "EPI", //Les épices
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="EPI",
                        Name="Les épices",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Name="Not defined",
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/epices-herbes.jpg"

                        },
                        Foods=new List<Food>
                        {
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Anis",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/Anis.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Cannelle",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/cannelle.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Cardamome",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/cardamome.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Coriandre",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/coriandre.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Cumin",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/cumin.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Curcuma",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/curcuma.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Curry",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/curry.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Gingembre",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/gingembre.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Paprika",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/paprika.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Piment",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/piment.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Poivre",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/poivre.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Safran",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/safran.jpg"
                                }
                            },
                        }
                    }
                },
                {
                    "HER", //Les herbes
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="EPI",
                        Name="Les herbes",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Name="Not defined",
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/epices-herbes.jpg"
                        },
                        Foods=new List<Food>
                        {
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Basilic",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/basilic.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Ciboulette",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/ciboulette.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Estragon",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/estragon.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Laurier",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/laurier.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Menthe",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name ="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/menthe.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Origan",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/origan.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Persil",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/persil.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Romarin",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/romarin.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Sarriette",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/sarriette.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Sauge",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/sauge.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Stevia",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/stevia.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Thym",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/thym.jpg"
                                }
                            },
                        }
                    }
                },
                {
                    "SPS", //Sucres et produits sucrés
                    new FoodCategory
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="SPS",
                        Name="Sucres et produits sucrés",
                        Description="",
                        Picture=new Picture
                        {
                            Id=Guid.NewGuid(),
                            IsDisabled=false,
                            Alias="",
                            Description="",
                            ImageUrl=$"{uploadsFoodCategories}/produits-sucres.jpg"
                        },
                        Foods=new List<Food>
                        {
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Miel",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/miel.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Sirop",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Name="Not defined",
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/sirop.jpg"
                                }
                            },
                            new Food
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="",
                                Name="Sucre",
                                Description="",
                                Nutrition=GetRandomNutrition(),
                                Picture=new Picture
                                {
                                     Id=Guid.NewGuid(),
                                     IsDisabled=false,
                                     Alias="",
                                     Description="",
                                     ImageUrl=$"{uploadsFood}/sucre.jpg"
                                }
                            },
                        }
                    }
                }
            };
            foreach (var keyvalue in foodCategories)
            {
                var category = keyvalue.Value;
                SetUnitAndPicture(category);
                context.FoodCategories.Add(category);
            }
        }

        void SeedUnits()
        {
            units = new Dictionary<string, Unit>
            {
                {
                    "t",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="T",
                        Name="Tonne",
                        Description="",
                        Symbol="t"
                    }
                },
                {
                    "kg",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="KG",
                        Name="kilogramme",
                        Description="",
                        Symbol="kg"
                    }
                },
                {
                    "g",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="G",
                        Name="Gramme",
                        Description="",
                        Symbol="g"
                    }
                },
                {
                    "dg",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="DG",
                        Name="Décigramme",
                        Description="",
                        Symbol="dg"
                    }
                },
                {
                    "cg",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CG",
                        Name="Centigramme",
                        Description="",
                        Symbol="cg"
                    }
                },
                {
                    "mg",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="MG",
                        Name="Milligramme",
                        Description="",
                        Symbol="mg"
                    }
                },
                {
                    "µg",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="µG",
                        Name="Microgramme",
                        Description="",
                        Symbol="μg"
                    }
                },
                {
                    "hl",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="HL",
                        Name="Hectolitre",
                        Description="",
                        Symbol="hl"
                    }
                },
                {
                    "L",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="L",
                        Name="Litre",
                        Description="",
                        Symbol="L"
                    }
                },
                {
                    "dl",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="DL",
                        Name="Décilitre",
                        Description="",
                        Symbol="dl"
                    }
                },
                {
                    "cl",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CL",
                        Name="Centilitre",
                        Description="",
                        Symbol="cl"
                    }
                },
                {
                    "ml",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="ML",
                        Name="Millilitre ",
                        Description="",
                        Symbol="ml"
                    }
                },
                //,,,,,,,unité
                {
                    "batton",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="BT",
                        Name="Bâtton",
                        Description="",
                        Symbol="bâtton"
                    }
                },
                {
                    "cube",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CU",
                        Name="Cube",
                        Description="",
                        Symbol="cube"
                    }
                },
                {
                    "poignee",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="POI",
                        Name="Poignée",
                        Description="",
                        Symbol="poignée"
                    }
                },
                {
                    "cuilleree-a-soupe",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CUISO",
                        Name="Cuillerée à soupe",
                        Description="",
                        Symbol="cuillerée à soupe"
                    }
                },
                {
                    "tasse",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="TAS",
                        Name="Tasse",
                        Description="",
                        Symbol="tasse"
                    }
                },
                {
                    "cuilleree-a-the",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CUITH",
                        Name="Cuillerée à thé",
                        Description="",
                        Symbol="cuillerée à thé"
                    }
                },
                {
                    "cuilleree-a-cafe",
                    new Unit
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CUICF",
                        Name="Cuillerée à café",
                        Description="",
                        Symbol="cuillerée à café"
                    }
                },
            };

            foreach (var keyvalue in units)
            {
                context.Units.Add(keyvalue.Value);
            }
        }

        void SeedLanguages()
        {
            languages = new Dictionary<string, Language>
            {
                {
                    "af-ZA",
                    new Language
                    {
                        Id="af-ZA",
                        IsDisabled=false,
                        Alias="AFK",
                        Name="Afrikaans-South Africa",
                        IsRTL=false,
                        EnglishName="Afrikaans-South Africa",
                        IsoCode="AFK"
                    }
                },
                {
                    "sq-AL",
                    new Language
                    {
                        Id="sq-AL",
                        IsDisabled=false,
                        Alias="SQI",
                        Name="Albanian-Albania",
                        IsRTL=false,
                        EnglishName="Albanian-Albania",
                        IsoCode="SQI"
                    }
                },
                {
                    "ar-DZ",
                    new Language
                    {
                        Id="ar-DZ",
                        IsDisabled=false,
                        Alias="ARG",
                        Name="Arabic-Algeria",
                        IsRTL=true,
                        EnglishName="Arabic-Algeria",
                        IsoCode="ARG"
                    }
                },
                {
                    "ar-BH",
                    new Language
                    {
                        Id="ar-BH",
                        IsDisabled=false,
                        Alias="ARH",
                        Name="Arabic-Bahrain",
                        IsRTL=true,
                        EnglishName="Arabic-Bahrain",
                        IsoCode="ARH"
                    }
                },
                {
                    //ar-EG Arabic-Egypt 0x0C01 ARE
                    "ar-EG",
                    new Language
                    {
                        Id="ar-EG",
                        IsDisabled=false,
                        Alias="ARE",
                        Name="Arabic-Egypt",
                        IsRTL=true,
                        EnglishName="Arabic-Egypt",
                        IsoCode="ARE"
                    }
                },
                {
                    //ar-IQ Arabic-Iraq 0x0801 ARI
                    "ar-IQ",
                    new Language
                    {
                        Id="ar-IQ",
                        IsDisabled=false,
                        Alias="ARI",
                        Name="Arabic-Iraq",
                        IsRTL=true,
                        EnglishName="Arabic-Iraq",
                        IsoCode="ARI"
                    }
                },
                {
                    //en-US English-United States 0x0409 ENU
                    "en-US",
                    new Language
                    {
                        Id="en-US",
                        IsDisabled=false,
                        Alias="ENU",
                        Name="English-United States",
                        IsRTL=true,
                        EnglishName="English-United States",
                        IsoCode="ENU"
                    }
                },
                {
                    //fr-FR French-France 0x040C FRA
                    "fr-FR",
                    new Language
                    {
                        Id="fr-FR",
                        IsDisabled=false,
                        Alias="FRA",
                        Name="French-France",
                        IsRTL=true,
                        EnglishName="French-France",
                        IsoCode="FRA"
                    }
                },
            };
            foreach (var keyvalue in languages)
            {
                context.Languages.Add(keyvalue.Value);
            }

        }

        void SeedCurrencies()
        {
            currencies = new Dictionary<string, Currency>
            {
                {
                    "DZD",
                    new Currency
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="DZD",
                        Name="Dinar Algérien",
                        IsoCode="DZD",
                        Symbol="DZD "
                    }
                },
                {
                    "EUR",
                    new Currency
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="DZD",
                        Name="Euro",
                        IsoCode="EUR",
                        Symbol="€"
                    }
                },
                {
                    "USD",
                    new Currency
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="USD",
                        Name="United States dollar",
                        IsoCode="USD",
                        Symbol="$"
                    }
                }
            };
            foreach (var keyvalue in currencies)
            {
                context.Currencies.Add(keyvalue.Value);
            }

        }

        void SeedOwners()
        {
            owners = new Dictionary<int, Owner>
            {
                {
                    1,
                    new Owner
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="OW01",
                        UserName="Owner 01",
                        FirstName="Ben Ali",
                        LastName="Bilal",
                        DateOfBirth=new System.DateTime(1980,12,1),
                        Address=address.GetValueOrDefault("Alger"),
                    }
                },
                {
                    2,
                    new Owner
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="OW02",
                        UserName="Owner 02",
                        FirstName="Dadi",
                        LastName="Mohamed",
                        DateOfBirth=new System.DateTime(1980,12,1),
                        Address=address.GetValueOrDefault("Blida"),
                    }
                },
                {
                    3,
                    new Owner
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="OW03",
                        UserName="Owner 03",
                        FirstName="Falha",
                        LastName="Ibrahim",
                        DateOfBirth=new System.DateTime(1980,12,1),
                        Address=address.GetValueOrDefault("Tipaza"),
                    }
                }
            };

            foreach (var keyvalue in owners)
            {
                context.Owners.Add(keyvalue.Value);
            }

        }

        void SeedChains()
        {
            chains = new Dictionary<int, Chain>
            {
                {1,
                    new Chain
                {
                    Id=chainsIds.GetValueOrDefault("CH01"),
                     IsDisabled=false,
                     Alias="CH01",
                    Name="Galaxy Chains",
                    Description="",
                   OwnerId=owners.GetValueOrDefault(1).Id,


                }

                },

               {2,
                    new Chain
                {
                    Id=chainsIds.GetValueOrDefault("CH02"),
                     IsDisabled=false,
                     Alias="CH02",
                    Name="Orange Chains",
                    Description="",
                   OwnerId=owners.GetValueOrDefault(2).Id,


                }

                },
                {3,
                    new Chain
                {
                    Id=chainsIds.GetValueOrDefault("CH03"),
                     IsDisabled=false,
                     Alias="CH03",
                    Name="MoonLight Chains",
                    Description="",
                   OwnerId=owners.GetValueOrDefault(3).Id,


                }

                },


            };


            foreach (var keyvalue in chains)
            {
                try
                {
                    context.Chains.Add(keyvalue.Value);
                }
                catch (Exception)
                {

                }

            }

        }

        void SeedRestaurantTypes()
        {
            types = new Dictionary<int, RestaurantType>
            {
                {
                    1,
                    new RestaurantType
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Name="Bio",
                        Description=null,
                    }
                },
                {
                    2,
                    new RestaurantType
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Name="VIP",
                        Description=null,
                    }
                }
                ,
                {
                    3,
                    new RestaurantType
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Name="Pizza",
                        Description=null,
                    }
                }
                ,
                {
                    4,
                    new RestaurantType
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Name="Traditionel",
                        Description=null,
                    }
                }
                 ,
                {
                    5,
                    new RestaurantType
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Name="Végétarien",
                        Description=null,
                    }
                }

            };

            foreach (var keyvalue in types)
            {
                context.RestaurantTypes.Add(keyvalue.Value);
            }

        }

        void SeedRestaurants()
        {
            restaurants = new Dictionary<int, Restaurant>
            {
                {
                    1,
                    new Restaurant
                    {
                        Id=restaurantsIds.GetValueOrDefault("RST01"),
                        IsDisabled=false,
                        Alias="RST01",
                        Name="La Baie D'Alger",
                        Description="",
                        ChainId=chains.GetValueOrDefault(1).Id,
                        OwnerId=owners.GetValueOrDefault(1).Id,
                        RestaurantTypeId=types.GetValueOrDefault(1).Id,
                        Address=address.GetValueOrDefault("Alger"),
                        CreatedDate=System.DateTime.Now,
                        PriceRange=new PriceRange(currencies.GetValueOrDefault("DZD").Id,600.00m,2500.00m),
                        Floors=new List<Floor>
                        {
                            new Floor
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="FL01",
                                Name="Etage 01",
                                Description="",
                                Areas=new List<Area>
                                {
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR01",
                                        Name="Etage 01 Zone 01",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T01",
                                                Name="Table 01",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T02",
                                                Name="Table 02",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T03",
                                                Name="Table 03",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T04",
                                                Name="Table 04",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T05",
                                                Name="Table 05",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T06",
                                                Name="Table 06",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T07",
                                                Name="Table 07",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T08",
                                                Name="Table 08",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T09",
                                                Name="Table 09",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T10",
                                                Name="Table 10",
                                                Description=""
                                            },
                                        }

                                    },
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR02",
                                        Name="Etage 01 Zone 02",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T11",
                                                Name="Table 11",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T12",
                                                Name="Table 12",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T12",
                                                Name="Table 13",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T14",
                                                Name="Table 14",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T15",
                                                Name="Table 15",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T16",
                                                Name="Table 16",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T17",
                                                Name="Table 17",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T18",
                                                Name="Table 18",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T19",
                                                Name="Table 19",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T20",
                                                Name="Table 20",
                                                Description=""
                                            },
                                        }
                                    }
                                }
                            },
                            new Floor
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="FL02",
                                Name="Etage 02",
                                Description="",
                                Areas=new List<Area>
                                {
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR01",
                                        Name="Etage 02 Zone 01",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T21",
                                                Name="Table 21",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T22",
                                                Name="Table 22",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T23",
                                                Name="Table 23",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T24",
                                                Name="Table 24",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T25",
                                                Name="Table 25",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T26",
                                                Name="Table 26",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T27",
                                                Name="Table 27",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T28",
                                                Name="Table 28",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T29",
                                                Name="Table 29",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T30",
                                                Name="Table 30",
                                                Description=""
                                            },
                                        }

                                    },
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR02",
                                        Name="Etage 02 Zone 02",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T31",
                                                Name="Table 31",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T32",
                                                Name="Table 32",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T33",
                                                Name="Table 33",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T34",
                                                Name="Table 34",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T35",
                                                Name="Table 35",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T36",
                                                Name="Table 36",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T37",
                                                Name="Table 37",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T38",
                                                Name="Table 38",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T39",
                                                Name="Table 39",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T40",
                                                Name="Table 40",
                                                Description=""
                                            },
                                        }
                                    }
                                }
                            },
                        },
                        ProductFamilies=PopulateProductsFamillies(),
                        DishFamilies=PopulateDishesFamillies(restaurantsIds.GetValueOrDefault("RST01")),
                    }
                },
                {
                    2,
                    new Restaurant
                    {
                        Id="12689539-7dfc-4916-9ac0-692f50bb03c3".ToGuid(),
                        IsDisabled=false,
                        Alias="RST02",
                        Name="Chic Chic",
                        Description="",
                        ChainId=chains.GetValueOrDefault(2).Id,
                        OwnerId=owners.GetValueOrDefault(2).Id,
                        RestaurantTypeId=types.GetValueOrDefault(2).Id,
                        Address=address.GetValueOrDefault("Blida"),
                        CreatedDate=System.DateTime.Now,
                        PriceRange=new PriceRange(currencies.GetValueOrDefault("DZD").Id,500.00m,1900.00m),
                        Floors=new List<Floor>
                        {
                            new Floor
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="FL01",
                                Name="Etage 01",
                                Description="",
                                Areas=new List<Area>
                                {
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR01",
                                        Name="Etage 01 Zone 01",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T01",
                                                Name="Table 01",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T02",
                                                Name="Table 02",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T03",
                                                Name="Table 03",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T04",
                                                Name="Table 04",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T05",
                                                Name="Table 05",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T06",
                                                Name="Table 06",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T07",
                                                Name="Table 07",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T08",
                                                Name="Table 08",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T09",
                                                Name="Table 09",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T10",
                                                Name="Table 10",
                                                Description=""
                                            },
                                        }

                                    },
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR02",
                                        Name="Etage 01 Zone 02",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T11",
                                                Name="Table 11",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T12",
                                                Name="Table 12",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T12",
                                                Name="Table 13",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T14",
                                                Name="Table 14",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T15",
                                                Name="Table 15",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T16",
                                                Name="Table 16",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T17",
                                                Name="Table 17",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T18",
                                                Name="Table 18",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T19",
                                                Name="Table 19",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T20",
                                                Name="Table 20",
                                                Description=""
                                            },
                                        }
                                    }
                                }
                            },
                            new Floor
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="FL02",
                                Name="Etage 02",
                                Description="",
                                Areas=new List<Area>
                                {
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR01",
                                        Name="Etage 02 Zone 01",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T21",
                                                Name="Table 21",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T22",
                                                Name="Table 22",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T23",
                                                Name="Table 23",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T24",
                                                Name="Table 24",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T25",
                                                Name="Table 25",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T26",
                                                Name="Table 26",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T27",
                                                Name="Table 27",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T28",
                                                Name="Table 28",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T29",
                                                Name="Table 29",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T30",
                                                Name="Table 30",
                                                Description=""
                                            },
                                        }

                                    },
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR02",
                                        Name="Etage 02 Zone 02",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T31",
                                                Name="Table 31",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T32",
                                                Name="Table 32",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T33",
                                                Name="Table 33",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T34",
                                                Name="Table 34",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T35",
                                                Name="Table 35",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T36",
                                                Name="Table 36",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T37",
                                                Name="Table 37",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T38",
                                                Name="Table 38",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T39",
                                                Name="Table 39",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T40",
                                                Name="Table 40",
                                                Description=""
                                            },
                                        }
                                    }
                                }
                            },
                        },
                        ProductFamilies=PopulateProductsFamillies(),
                        DishFamilies=PopulateDishesFamillies(restaurantsIds.GetValueOrDefault("RST02")),
                    }
                },
                {
                    3,
                    new Restaurant
                    {
                        Id="ada8720c-52e4-472d-b92c-252ba638db2f".ToGuid(),
                        IsDisabled=false,
                        Alias="RST03",
                        Name="El Djenina",
                        Description="",
                        ChainId=chains.GetValueOrDefault(3).Id,
                        OwnerId=owners.GetValueOrDefault(3).Id,
                        RestaurantTypeId=types.GetValueOrDefault(2).Id,
                        Address=address.GetValueOrDefault("Tipaza"),
                        CreatedDate=System.DateTime.Now,
                        PriceRange=new PriceRange(currencies.GetValueOrDefault("DZD").Id,400.00m,1800.00m),
                        Floors=new List<Floor>
                        {
                            new Floor
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="FL01",
                                Name="Etage 01",
                                Description="",
                                Areas=new List<Area>
                                {
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR01",
                                        Name="Etage 01 Zone 01",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T01",
                                                Name="Table 01",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T02",
                                                Name="Table 02",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T03",
                                                Name="Table 03",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T04",
                                                Name="Table 04",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T05",
                                                Name="Table 05",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T06",
                                                Name="Table 06",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T07",
                                                Name="Table 07",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T08",
                                                Name="Table 08",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T09",
                                                Name="Table 09",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T10",
                                                Name="Table 10",
                                                Description=""
                                            },
                                        }

                                    },
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR02",
                                        Name="Etage 01 Zone 02",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T11",
                                                Name="Table 11",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T12",
                                                Name="Table 12",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T12",
                                                Name="Table 13",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T14",
                                                Name="Table 14",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T15",
                                                Name="Table 15",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T16",
                                                Name="Table 16",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T17",
                                                Name="Table 17",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T18",
                                                Name="Table 18",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T19",
                                                Name="Table 19",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T20",
                                                Name="Table 20",
                                                Description=""
                                            },
                                        }
                                    }
                                }
                            },
                            new Floor
                            {
                                Id=Guid.NewGuid(),
                                IsDisabled=false,
                                Alias="FL02",
                                Name="Etage 02",
                                Description="",
                                Areas=new List<Area>
                                {
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR01",
                                        Name="Etage 02 Zone 01",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T21",
                                                Name="Table 21",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T22",
                                                Name="Table 22",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T23",
                                                Name="Table 23",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T24",
                                                Name="Table 24",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T25",
                                                Name="Table 25",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T26",
                                                Name="Table 26",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T27",
                                                Name="Table 27",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T28",
                                                Name="Table 28",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T29",
                                                Name="Table 29",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T30",
                                                Name="Table 30",
                                                Description=""
                                            },
                                        }

                                    },
                                    new Area
                                    {
                                        Id=Guid.NewGuid(),
                                        IsDisabled=false,
                                        Alias="AR02",
                                        Name="Etage 02 Zone 02",
                                        Tables=new List<Table>
                                        {
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T31",
                                                Name="Table 31",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T32",
                                                Name="Table 32",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T33",
                                                Name="Table 33",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T34",
                                                Name="Table 34",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T35",
                                                Name="Table 35",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T36",
                                                Name="Table 36",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T37",
                                                Name="Table 37",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T38",
                                                Name="Table 38",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T39",
                                                Name="Table 39",
                                                Description=""
                                            },
                                            new Table
                                            {
                                                Id=Guid.NewGuid(),
                                                IsDisabled=false,
                                                Alias="T40",
                                                Name="Table 40",
                                                Description=""
                                            },
                                        }
                                    }
                                }
                            },
                        },
                        ProductFamilies=PopulateProductsFamillies(),
                        DishFamilies=PopulateDishesFamillies(restaurantsIds.GetValueOrDefault("RST03")),
                    }
                }

            };

            foreach (var keyvalue in restaurants)
            {
                context.Restaurants.Add(keyvalue.Value);
            }
        }

        void SeedAllergies()
        {
            allergies = new Dictionary<string, Allergy>
            {
                {
                    "cereales",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CEREA",
                        Name="Céréales contenant du gluten",
                        Description="Céréales contenant du gluten (blé, seigle, orge, avoine, épeautre, kamut ou leurs souches hybridées) et produits à base de ces céréales",
                    }
                },
                {
                    "crustaces",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CRUST",
                        Name="Crustacés",
                        Description="Crustacés et produits à base de crustacés",
                    }
                },
                {
                    "oeufs",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="OEUFS",
                        Name="Oeufs",
                        Description="Oeufs et produits à base d'oeufs",
                    }
                },
                {
                    "poissons",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="POISS",
                        Name="Poissons",
                        Description="Poissons et produits à base de poissons",
                    }
                },
                {
                    "arachides",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="ARACH",
                        Name="Arachides",
                        Description="Arachides et produits à base d'arachides",
                    }
                },
                {
                    "soja",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="SOJA",
                        Name="Soja",
                        Description="Soja et produits à base de soja",
                    }
                },
                {
                    "lait",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="LAIT",
                        Name="Lait",
                        Description="Lait et produits à base de lait (y compris de lactose)",
                    }
                },
                {
                    "fruits-a-coques",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="FRUCO",
                        Name="Fruits à coques",
                        Description="Fruits à coques (amandes, noisettes, noix, noix de : cajou, pécan, macadamia, du Brésil, du  Queensland, pistaches) et produits à base de ces fruits)",
                    }
                },
                {
                    "celeri",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="CELER",
                        Name="Céleri",
                        Description="Céleri et produits à base de céleri",
                    }
                },
                {
                    "moutarde",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="MOUTA",
                        Name="Moutarde",
                        Description="Moutarde et produits à base de moutarde",
                    }
                },
                {
                    "graines-de-sesame",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="GRSEA",
                        Name="Graines de sésame",
                        Description="Graines de sésame et  produits à base de graines de sésame",
                    }
                },
                {
                    "anhydride",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="ANHYD",
                        Name="Anhydride sulfureux et sulfites en concentration de plus de 10mg/kg ou 10 mg/l",
                        Description="Anhydride sulfureux et sulfites en concentration de plus de 10mg/kg ou 10 mg/l (exprimés en SO2)",
                    }
                },
                {
                    "lupin",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="LUPIN",
                        Name="Lupin",
                        Description="Lupin et produits à base de lupin",
                    }
                },
                {
                    "mollusques",
                    new Allergy
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="MOLLU",
                        Name="Mollusques",
                        Description="Mollusques et produits à base de mollusques",
                    }
                }

            };
            foreach (var keyvalue in allergies)
            {
                context.Allergies.Add(keyvalue.Value);
            }
        }

        void SeedIllness()
        {

            illness = new Dictionary<string, Illness>
            {
                {
                    "m01",
                    new Illness
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="",
                        Name="Bilharziose compliquée",
                        Description="",
                    }
                },
                {
                    "m02",
                    new Illness
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="",
                        Name="Insuffisance cardiaque",
                        Description="",
                    }
                },
                {
                    "m03",
                    new Illness
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="",
                        Name="Diabète de type 1",
                        Description="",
                    }
                },
                {
                    "m04",
                    new Illness
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="",
                        Name="Diabète de type 2",
                        Description="",
                    }
                },
                {
                    "m05",
                    new Illness
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="",
                        Name="Insuffisance respiratoire",
                        Description="",
                    }
                },
                {
                    "m06",
                    new Illness
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="",
                        Name="Rectocolite hémorragique",
                        Description="",
                    }
                },
                {
                    "m07",
                    new Illness
                    {
                        Id=Guid.NewGuid(),
                        IsDisabled=false,
                        Alias="",
                        Name="Sclérose en plaques",
                        Description="",
                    }
                },
            };
            foreach (var keyvalue in illness)
            {
                context.Illnesses.Add(keyvalue.Value);
            }
        }

        public async Task SeedEverythingAsync()
        {
            if (context.Languages.Any())
            {
                return;
            }
            SeedUnits();
            SeedLanguages();
            SeedCurrencies();
            SeedOwners();
            SeedChains();
            SeedRestaurantTypes();
            SeedRestaurants();
            SeedAllergies();
            SeedIllness();
            SeedFoodCategories();

            await context.SaveChangesAsync();


        }

        public async Task ClearAllDataAsync()
        {
            context.Dishes.RemoveRange(context.Dishes);
            context.DishFamilies.RemoveRange(context.DishFamilies);

            context.Products.RemoveRange(context.Products);
            context.ProductFamilies.RemoveRange(context.ProductFamilies);
            context.Tables.RemoveRange(context.Tables);
            context.Areas.RemoveRange(context.Areas);
            context.Floors.RemoveRange(context.Floors);
            context.Restaurants.RemoveRange(context.Restaurants);
            context.RestaurantTypes.RemoveRange(context.RestaurantTypes);
            context.Chains.RemoveRange(context.Chains);
            context.Owners.RemoveRange(context.Owners);

            context.Foods.RemoveRange(context.Foods);
            context.FoodCategories.RemoveRange(context.FoodCategories);
            context.Pictures.RemoveRange(context.Pictures);

            context.Allergies.RemoveRange(context.Allergies);
            context.Illnesses.RemoveRange(context.Illnesses);

            context.Currencies.RemoveRange(context.Currencies);
            context.Languages.RemoveRange(context.Languages);
            context.Units.RemoveRange(context.Units);

            await context.SaveChangesAsync();
        }


        //        public async Task<List<string>> CreateRoles(IServiceProvider serviceProvider)
        //        {
        //            //adding custom roles
        //            var RoleManager = serviceProvider.GetRequiredService<RoleManager<BaseIdentityRole>>();
        //           var UserManager = serviceProvider.GetRequiredService<UserManager<BaseIdentityUser>>();
        //            List<string> roleNames = new List<string>(){ "Owner", "Cashier", "Butler" ,
        //             "Chef", "Cooker", "Waiter" , "Guest", "Storekeeper" ,"Developper"

        //            };
        //            IdentityResult roleResult;
        //​
        //            foreach (var roleName in roleNames)
        //            {
        //                //creating the roles and seeding them to the database
        //                var roleExist = await RoleManager.RoleExistsAsync(roleName);
        //                if (!roleExist)
        //                {
        //                    roleResult = await RoleManager.CreateAsync(new BaseIdentityRole(roleName));
        //                }
        //            }
        //​
        //             // creating a super user who could maintain the web app
        ////            var poweruser = new BaseIdentityUser
        ////            {
        ////                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
        ////                Email = Configuration.GetSection("AppSettings")["UserEmail"]
        ////            };
        ////​
        ////            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
        ////            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);
        ////​
        ////            if (user == null)
        ////            {
        ////                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
        ////                if (createPowerUser.Succeeded)
        ////                {
        ////                    // here we assign the new user the "Admin" role 
        ////                    await UserManager.AddToRoleAsync(poweruser, "Admin");
        ////                }
        ////            }

        //            return roleNames;
        //        }


        //        public async Task SeedUsers(IServiceProvider serviceProvider)
        //        {

        //            var RoleManager = serviceProvider.GetRequiredService<RoleManager<BaseIdentityRole>>();
        //            var UserManager = serviceProvider.GetRequiredService<UserManager<BaseIdentityUser>>();
        //            string password = "123456";
        //            /// adding user to each rolename 
        //            var rolesNames = await CreateRoles(serviceProvider);

        //            foreach (var item in rolesNames)
        //            {
        //                var user = new BaseIdentityUser();
        //                user.UserName = item+"01";
        //                user.Email = item+"01"+"@localhost";
        //                user.FirstName = item + "name";
        //                user.LastName = item + "lastname";

        //                var identityResult = await UserManager.CreateAsync(user, password);
        //                if (identityResult.Succeeded)
        //                {
        //                    await UserManager.AddClaimAsync(user, new Claim("organisation", "g22r"));

        //                    await UserManager.AddClaimAsync(user, new Claim("unique_name", user.UserName));
        //                    await UserManager.AddClaimAsync(user, new Claim("family_name", user.FirstName));
        //                    await UserManager.AddClaimAsync(user, new Claim("last_name", user.LastName));
        //                    await UserManager.AddClaimAsync(user, new Claim("gender", "1"));
        //                    await UserManager.AddClaimAsync(user, new Claim("email", user.Email));
        //                    await UserManager.AddClaimAsync(user, new Claim("id", user.Id));

        //                }

        //            }


        //        }
    }
}
