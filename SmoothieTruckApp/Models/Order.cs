using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieTruckApp.Models;
{
    //only the values needed for subtotals added here
    public List<OrderLine> Lines { get; set; } = new();
    public decimal Subtotal => Lines.Sum(l => l.Item.Price * l.Quantity);
    public decimal Tax => Math.Round(Subtotal * 0.08m, 2);
    public decimal Total => Subtotal + Tax;
}