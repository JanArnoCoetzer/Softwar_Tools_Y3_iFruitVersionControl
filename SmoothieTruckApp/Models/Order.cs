using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieTruckApp.Models;

public class Order
{
    public int Id { get; set; }
    public List<OrderLine> Lines { get; set; } = new();
    public decimal Subtotal => Lines.Sum(l => l.Item.Price * l.Quantity);
    public decimal Tax => Math.Round(Subtotal * 0.08m, 2);
    public decimal Total => Subtotal + Tax;
}