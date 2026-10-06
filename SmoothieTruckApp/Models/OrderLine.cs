using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieTruckApp.Models;
public class OrderLine
{
    public MenuItem Item { get; set; } = null!;
    public int Quantity { get; set; } = 1;
}