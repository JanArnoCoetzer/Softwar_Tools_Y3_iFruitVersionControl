using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieTruckApp.Models;
public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public string CatagoryName { get; set; }
    public Color CatagoryColor { get; set; }
}