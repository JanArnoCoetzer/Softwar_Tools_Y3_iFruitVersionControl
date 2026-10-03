using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieTruckApp.Models;
public class MenuItem
{
    //only the values needed for subtotals added here
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}