using System;

namespace NutriLift.Entities
{
    public class FoodName
    {
        public Guid FN_PK { get; set; }
        public string FN_Name { get; set; }
        public bool FN_IsLiquid { get; set; }
    }
}
