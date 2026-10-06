using System;
using System.Collections.Generic;
using System.Text;
namespace SmoothieTruckApp.Models;

public class Recipe
{
    public int ItemId { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; } = new();
}
