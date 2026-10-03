using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieTruckApp.Models;
public class OrderLine
{
    //only the values needed for subtotals added here
    public MenuItem Item { get; set; } = null!;
    public int Quantity { get; set; } = 1;
}