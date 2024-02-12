﻿using BeautyClinicApi.Models;

public class CartItem
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int UserId { get; set; }

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public virtual Product Product { get; set; }
    public virtual Cart Cart { get; set; }


}