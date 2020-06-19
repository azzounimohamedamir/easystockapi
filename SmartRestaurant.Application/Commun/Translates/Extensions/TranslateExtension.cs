using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SmartRestaurant.Application.Commun.Translators.Extensions
{
    public class TranslateExtension : ITranslateService
    {
        private readonly ISmartRestaurantDatabaseService db;


        public T Translate<T>(ISmartRestaurantDatabaseService db, T entity, string languageIsoCode)
        {

            var entityType = entity.GetType();
            string entityName = entityType.Name;
            if (entityName.EndsWith("y"))
            {
                entityName.Remove(entityName.Length - 1);
                entityName += "ie";
            }
            var tableName = entityName + "s";
            var entityPrimaryKeyName = "Id";

            var entityPrimaryKeyValue = entityType.
                                 GetProperty(entityPrimaryKeyName)
                                 .GetValue(entity, null).ToString();

            // Get the entity info
            var entityFieldsTraslations = db.Translates
                .Where(t => t.TableName == tableName
            && t.PrimaryKeyValue == entityPrimaryKeyValue
            && t.Language.IsoCode == languageIsoCode).ToList();

            if (null != entityFieldsTraslations)
            {

                foreach (var t in entityFieldsTraslations)
                {
                    // Overwrite each field with the translated value
                    entityType.GetProperty(t.ColumnName).SetValue(entity, t.Text, null);
                }
            }
            return entity;
        }

        public static Type GetType(string name)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            List<Type> types = new List<Type>();

            foreach (Assembly assembly in assemblies)
            {
                Type type = assembly.DefinedTypes.FirstOrDefault(x => x.FullName == name);
                if (type != null)
                    return type;
            }

            return null;
        }

    }
}
