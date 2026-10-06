using System;
using System.Collections.Generic;
using System.Text;
namespace SmoothieTruckApp.Models;
public class StockItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public string Unit { get; set; } = string.Empty;
}