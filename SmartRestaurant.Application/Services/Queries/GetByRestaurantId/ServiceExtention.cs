using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using SmartRestaurant.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Services.Queries.GetByRestaurantId
{
    public static class ServiceExtention
    {
        public static List<SectionModel> GetServiceSections(ICollection<ServiceDish> serviceDishes, ICollection<ServiceProduct> serviceProducts)
        {

            var sections = new List<SectionModel>();

            // Dishes

            if (serviceDishes != null && serviceDishes.Count > 0)
            {
                var dishes = new List<Dish>();
                foreach (var item in serviceDishes)
                {
                    dishes.Add(item.Dish);
                }

                List<SectionModel> unmergedSections = new List<SectionModel>();
                foreach (var dish in dishes)
                {
                    unmergedSections.Add(GetSection(dish));
                }
                unmergedSections = unmergedSections.OrderBy(x => x.level).ToList();

                foreach (var sect in unmergedSections)
                {
                    foreach (var other in unmergedSections)
                    {
                        if (sect == other || other.level > sect.level) continue;
                        var merged = MergeSections(sect, other);
                        if (merged) unmergedSections.Remove(other);
                    }
                }
                foreach (var sect in unmergedSections)
                {
                    sections.Add(sect);
                }
            }
            //Products
            if (serviceProducts != null && serviceProducts.Count > 0)
            {
                var productFamilies = serviceProducts.GroupBy(x => x.Product.ProductFamily);

                foreach (var family in productFamilies)
                {
                    var section = new SectionModel();
                    section.Name = family.Key.Name;

                    foreach (var product in family.Key.Products)
                    {
                        section.Products.Add(product);
                    }
                    sections.Add(section);
                }
            }
            return sections;
        }

        private static bool MergeSections(SectionModel sect, SectionModel other)
        {
            var childOfSect = GetChildOfLevel(sect, other.level);
            if (childOfSect != null && childOfSect.Name == other.Name)
            {
                childOfSect.Childs.AddRange(other.Childs);
                return true;
            }
            return false;
        }

        private static SectionModel GetSection(Dish dish)
        {
            var sections = getDishParents(dish.Family, null);
            var lowestChild = GetlowestChild(sections);
            lowestChild.Dishes.Add(new MenuDishItemModel
            {
                Name = dish.Name,
                Description = dish.Description,
                Images = getDishImages(dish.Gallery),
                DishId = dish.Id.ToString(),
                Ingredients = getDishIngredients(dish.Ingredients)

            });

            return sections;
        }

        private static List<IngredientModel> getDishIngredients(ICollection<DishIngredient> ingredients)
        {
            List<IngredientModel> result = new List<IngredientModel>();
            foreach (var ing in ingredients)
            {
                result.Add(new IngredientModel
                {
                    Id = ing.Id.ToString(),
                    //TODO:ImageUrl
                    IsPrincipal = ing.IsPrincipal,
                    IsSwitchable = ing.IsSwitchable,
                    Name = ing.Name,
                    Nutrition = getNutritionModel(ing.Food.Nutrition),
                    Quantity = new IngredientQuantityModel
                    {
                        UnitName = ing.Quantity.Unit.Name,
                        Value = ing.Quantity.Value
                    }
                });
            }
            return result;
        }

        private static IngredientNutritionModel getNutritionModel(Nutrition nutrition)
        {
            return new IngredientNutritionModel
            {
                Calorie = nutrition.Calorie,
                Carbohydrate = nutrition.Carbohydrate,
                Fibre = nutrition.Fibre,
                GlycemicIndex = nutrition.GlycemicIndex,
                Lipid = nutrition.Lipid,
                Protein = nutrition.Protein
            };
        }

        private static List<BaseImageModel> getDishImages(Gallery gallery)
        {
            List<BaseImageModel> result = new List<BaseImageModel>();
            var cover = gallery.Pictures.FirstOrDefault();
            foreach (var pic in gallery.Pictures)
            {
                result.Add(new BaseImageModel
                {
                    Description = pic.Description,
                    ImageUrl = pic.ImageUrl,
                    IsCover = pic.Id == cover.Id,
                    Title = pic.Name
                });
            }
            return result;
        }

        private static SectionModel getDishParents(DishFamily family, SectionModel childSection)
        {
            if (family.Parent == null)
            {
                return new SectionModel { Name = family.Name, Childs = new List<SectionModel> { childSection } };
            }
            else
            {
                var sectionChld = new SectionModel { Name = family.Name };

                List<SectionModel> childs = null;
                if (childSection != null)
                    childs = new List<SectionModel> { childSection };

                sectionChld.Childs = childs;
                sectionChld.level = (sectionChld.Childs?.FirstOrDefault()?.level ?? 0) + 1;
                return getDishParents(family.Parent, sectionChld);
            }
        }
        private static SectionModel GetlowestChild(SectionModel section)
        {
            if (section.Childs == null)
            {
                return section;
            }
            else
            {
                return GetlowestChild(section.Childs.FirstOrDefault());
            }
        }

        private static SectionModel GetChildOfLevel(SectionModel section, int level)
        {
            if (section.Childs == null)
            {
                return null;
            }
            else if (section.level == level)
            {
                return section;
            }

            else
            {
                SectionModel result = null;
                foreach (var child in section.Childs)
                {
                    result = GetChildOfLevel(child, level);
                    if (result != null) break;
                }
                return result;
            }
        }
    }
}
