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
    public int ItemCount => Lines.Sum(l => l.Quantity);

    public void AddItem(MenuItem item, int quantity = 1)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be at least 1.");
        }

        OrderLine? existing = Lines.FirstOrDefault(l => l.Item.Id == item.Id);

        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            Lines.Add(new OrderLine { Item = item, Quantity = quantity });
        }
    }

    public bool RemoveItem(int itemId)
    {
        return Lines.RemoveAll(l => l.Item.Id == itemId) > 0;
    }

    public void Clear()
    {
        Lines.Clear();
    }
}