using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    /// <summary>
    /// Food A ={
    /// Quantity={
    ///     100.25m, 
    ///     Unit{Name="gr", Id="GUID"}
    /// },
    /// Nutrition={
    /// GlycemicIndex=15,
    /// ...
    /// Calorie=100,
    /// .....
    /// Lipid=120,
    /// }
    /// </summary>
    public class Nutrition : ValueObject<Nutrition>
    {        
        //public Guid UnitId { get; private set; }
        //public decimal UnitValue { get; set; }
        public Quantity Quantity { get;private set; }

        public decimal GlycemicIndex { get; private set; }
        public decimal Fibre { get; private set; }
        public decimal Calorie { get; private set; }
        public decimal Protein { get; private set; }
        public decimal Carbohydrate { get; private set; }
        public decimal Lipid { get; private set; }

        //public virtual Unit Unit { get; set; }

        //for EF migration only 
        private Nutrition()
        {

        }
        public Nutrition(
            Quantity quantity, 
            decimal glycemicIndex,
            decimal fibre,
            decimal calorie, 
            decimal protein,
            decimal carbohydrate, 
            decimal lipid )
        {

            Quantity = quantity;
            GlycemicIndex = glycemicIndex;
            Fibre = fibre;
            Calorie = calorie;
            Protein = protein;
            Carbohydrate = carbohydrate;
            Lipid = lipid;
        }

        public Nutrition SetQuantity(Quantity quantity)
        {
            Quantity = quantity;
            return this;
        }
        public Nutrition SetQuantity(Guid unitId,decimal value)
        {
            Quantity = new Quantity(unitId,value);
            return this;
        }
        
        public Nutrition SetGlycemicIndex(decimal value)
        {
            GlycemicIndex = value;
            return this;
        }
        
        public Nutrition SetFibre(decimal value)
        {
            Fibre = value;
            return this;
        }
        
        public Nutrition SetCalorie(decimal value)
        {
            Calorie = value;
            return this;
        }
        
        public Nutrition SetProtein(decimal value)
        {
            Protein = value;
            return this;
        }
        
        public Nutrition SetCarbohydrate(decimal value)
        {
            Carbohydrate = value;
            return this;
        }
        
        public Nutrition SetLipid(decimal value)
        {
            Lipid = value;
            return this;
        }
        protected override bool EqualsCore(Nutrition other)
        {
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Quantity.UnitId;
            yield return Quantity.Value;

            yield return GlycemicIndex;
            yield return Calorie;
            yield return Protein;
            yield return Carbohydrate;
            yield return Lipid;
        }
    }
}
