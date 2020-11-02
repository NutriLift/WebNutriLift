﻿using NutriLift.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriLift.Services
{
    public interface IFoodService
    {
        Task<List<FoodNameModel>> GetAllFoodsAsync();
        Task UpdateFoodAsync(FoodNameModel foodModel);
        Task<FoodNameModel> GetFoodByIdAsync(Guid id);
        bool FoodNameExists(Guid id);
        Task DeleteFoodAsync(Guid id);
        Task CreateFoodAsync(FoodNameModel foodModel);
    }
}
