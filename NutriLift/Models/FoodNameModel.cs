using System;

namespace NutriLift.Models
{
    public class FoodNameModel
    {
        public Guid FN_PK { get; set; }
        public string FN_Name { get; set; }
        public bool FN_IsLiquid { get; set; }
    }
}
