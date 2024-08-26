using System;
namespace SynCart;

public class CustomerDetails
{
    private static int s_customerID = 3000;
    public string CustomerID {get; set;}
    public string CustomerName {get; set;}
    public string City {get; set;}
    public string MobileNumber {get; set;}
    private double _walletBalance;
    public double WalletBalance {get{return _walletBalance;}}
    public string EmailID {get; set;}


    public CustomerDetails(string customerName,string city, string mobileNumber, int walletBalance, string emailID)
    {
        s_customerID++;
        CustomerID = "CID"+s_customerID;
        CustomerName = customerName;
        City = city;
        MobileNumber = mobileNumber;
        _walletBalance = walletBalance;
        EmailID = emailID;
    }

    public void Recharge(double amount)
    {
        _walletBalance+=amount;
    }

    public void DeductAmount(double amount)
    {
        _walletBalance-=amount;
    }


}
