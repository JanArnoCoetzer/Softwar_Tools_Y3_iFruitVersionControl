using System;
using System.Collections.Generic;
using System.Text;
namespace SmoothieTruckApp.Models;
public class RecipeIngredient
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int StockId { get; set; }
    public decimal QuantityRequired { get; set; }
}
