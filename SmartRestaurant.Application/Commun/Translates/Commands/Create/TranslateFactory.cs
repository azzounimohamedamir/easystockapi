using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Translates.Translates.Commands.Update;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Application.Commun.Prices;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Application.Commun.Translates.Commands.Update;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Create
{
    public static class TranslateFactory
    {
        public static Translate ToEntity(this CreateTranslateModel model)
        {
            return new Translate
            {
                Id = Guid.NewGuid(),
                Alias = model.Alias,
                ColumnName = model.ColumnName,
                LanguageId = model.LanguageId,
                PrimaryKeyName = model.PrimaryKeyName,
                TableName = model.TableName,
                PrimaryKeyValue = model.PrimaryKeyValue,
                IsDisabled = model.IsDisabled,
                Text = model.Text
            };
        }

        public static void ToEntity(this UpdateTranslateModel model
            , ref Translate Translate)
        {

            Translate.Id = Guid.NewGuid();
            Translate.Alias = model.Alias;
            Translate.ColumnName = model.ColumnName;
            Translate.LanguageId = model.LanguageId;
            Translate.PrimaryKeyName = model.PrimaryKeyName;
            Translate.TableName = model.TableName;
            Translate.PrimaryKeyValue = model.PrimaryKeyValue;
            Translate.IsDisabled = model.IsDisabled;
            Translate.Text = model.Text;

        }

        public static PricingModel ToModel(this Pricing pricing)
        {
            return new PricingModel
            {
                CurrencyId = pricing.Gain.CurrencyId.ToString(),
                Gain = pricing.Gain.Amount,
                IsPercentage = pricing.IsPercentage,
                PurchasePriceHT = pricing.PurchasePriceHT.Amount,
                SalePriceHT = pricing.SalePriceHT.Amount,
                SalePriceTTC = pricing.SalePriceTTC.Amount,
                Tva = pricing.Tva
            };
        }
    }
}
