using System;
namespace SynCart;

public class ProductDetails
{
    private static int s_productID = 2000;
    public string ProductID {get; }
    public string ProductName {get; set;}
    public int Stock {get;set;}
    public double Price {get; set;}
    public int ShippingDuration {get; set;}



    public ProductDetails(string productName, int stock, double price ,int shippingDuration )
    {
        s_productID++;
        ProductID = "PID"+s_productID;
        ProductName = productName;
        Stock = stock;
        Price = price;
        ShippingDuration =shippingDuration;
    }
}
