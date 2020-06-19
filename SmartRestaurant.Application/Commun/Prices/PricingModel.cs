using Helpers;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Pricings;
using System;

namespace SmartRestaurant.Application.Commun.Prices
{
    public class PricingModel
    {
        public string CurrencyId { get; set; }
        public decimal Tva { get; set; }
        public decimal PurchasePriceHT { get; set; }
        public decimal SalePriceHT { get; set; }
        public decimal PurchasePriceTTC => PurchasePriceHT * (1 + Tva / 100m);
        public decimal SalePriceTTC { get; set; }
        public decimal Gain { get; set; }
        public bool IsPercentage { get; set; }
        public static Pricing GetPricing(PricingModel model)
        {
            return new Pricing
            {
                Id = Guid.NewGuid(),
                PurchasePriceHT = new Price(model.CurrencyId.ToGuid()
                , model.PurchasePriceHT),
                Gain = new Price(model.CurrencyId.ToGuid()
                , model.SalePriceHT - model.PurchasePriceHT),
                Tva = model.Tva,
                IsPercentage = model.IsPercentage,
                GainAmount = model.Gain,
            };
        }
        public static void GetPricing(ref Pricing pricing, PricingModel model)
        {

            pricing.PurchasePriceHT = new Price(model.CurrencyId.ToGuid()
            , model.PurchasePriceHT);
            pricing.Gain = new Price(model.CurrencyId.ToGuid()
             , model.SalePriceHT - model.PurchasePriceHT);
            pricing.Tva = model.Tva;
            pricing.IsPercentage = model.IsPercentage;
            pricing.GainAmount = model.Gain;

        }
    }
}