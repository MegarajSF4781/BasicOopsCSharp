using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SynCart
{
    public static class Operations
    {
        public static List<CustomerDetails> customerDetails = new List<CustomerDetails>();
        public static List<ProductDetails> productDetails = new List<ProductDetails>();
        public static List<OrderDetails> orderDetails = new List<OrderDetails>();
        public static CustomerDetails loggedInCustomer;
        public static void MainMenu()
        {
            try
            {
                bool choice = true;
                do
                {
                    System.Console.WriteLine("*******Main Menu*******");
                    System.Console.WriteLine("Select Option: \n1.Registration \n2.Login \n3.Exit");
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            {
                                System.Console.WriteLine("Registration");
                                Registration();
                                break;
                            }

                        case 2:
                            {
                                System.Console.WriteLine("Login");
                                Login();
                                break;
                            }
                        case 3:
                            {
                                choice = false;
                                break;
                            }
                    }
                } while (choice);
            }
            catch (Exception ex)
            {

            }
        }
        public static void Registration()
        {
            try
            {
                System.Console.WriteLine("*****************Registration*****************");
                System.Console.WriteLine("Enter your name");
                string customerName = Console.ReadLine();

                System.Console.WriteLine("Enter your city name");
                string city = Console.ReadLine();

                System.Console.WriteLine("Enter your phone number (only in 10 digits)");
                string phone = Console.ReadLine();

                System.Console.WriteLine("Enter your mail Id");
                string emailID = Console.ReadLine();

                CustomerDetails customer = new CustomerDetails(customerName, city, phone, 0, emailID);
                System.Console.WriteLine($"Your Registration ID: {customer.CustomerID}");
                customerDetails.Add(customer);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        public static void Login()
        {
            try
            {
                System.Console.WriteLine("*******Login********");
                System.Console.WriteLine("Enter your id");
                string customerID = Console.ReadLine().ToUpper();
                bool flag = true;
                foreach (CustomerDetails customer in customerDetails)
                {
                    if (customer.CustomerID == customerID)
                    {
                        System.Console.WriteLine("Login Successfull");
                        loggedInCustomer = customer;
                        flag = false;
                        SubMenu();
                        break;
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("Invalid login id");
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }

        }

        public static void SubMenu()
        {
            try
            {
                bool choice = true;
                do
                {
                    System.Console.WriteLine("***********SUBMENU*********");
                    System.Console.WriteLine("Select option \n1. Puchase \n2. Order History \n3. Cancel \n4. Balance Check \n5. Recharge \n6.Exit");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                System.Console.WriteLine("Purchase");
                                Purchase();
                                break;
                            }
                        case 2:
                            {
                                System.Console.WriteLine("Order History");
                                OrderHistory();
                                break;
                            }
                        case 3:
                            {
                                System.Console.WriteLine("Cancel");
                                Cancel();
                                break;
                            }
                        case 4:
                            {
                                System.Console.WriteLine("Balance Check");
                                BalanceCheck();
                                break;
                            }
                        case 5:
                            {
                                System.Console.WriteLine("Recharge");
                                Recharge();
                                break;
                            }
                        case 6:
                            {
                                choice = false;
                                break;
                            }
                    }
                } while (choice == true);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        public static void Purchase()
        {
            try
            {
                // show product list
                // get product id and count
                // check product id and count is valid
                //calculate total amount and check the user have the amount to proceed purchase
                // reduce amount from user, reduce stock count
                // create object and add it to list

                //admission:
                // show department list
                // get department id 
                // check dept id is valid
                // check department has more than 1 seat
                // check the user is eligible for admission
                // reduce seat count in department
                //Create admission object and add it to list

                //check the student has any admission thet is he has a entry and the status is admitted
                // change the status to cancelled
                // increase department seat count
                // show admission cancelled successfully
                // if there is no admission the show there is no admission detail for current user

                System.Console.WriteLine("Purchase");
                foreach (ProductDetails product in productDetails)
                {
                    System.Console.WriteLine($"{product.ProductID} {product.ProductName} {product.Stock} {product.Price} {product.ShippingDuration}");
                }
                System.Console.WriteLine("enter product ID");
                string productID = Console.ReadLine().ToUpper();
                System.Console.WriteLine("Enter Quantity required");
                int count = int.Parse(Console.ReadLine());
                bool productFlag = true;
                foreach (ProductDetails product in productDetails)
                {
                    if (product.ProductID == productID)
                    {
                        productFlag = false;
                        if (product.Stock >= count)
                        {
                            double totalAmount = product.Price * count;
                            if (totalAmount <= loggedInCustomer.WalletBalance)
                            {
                                product.Stock -= count;
                                loggedInCustomer.DeductAmount(totalAmount);
                                OrderDetails order = new OrderDetails(loggedInCustomer.CustomerID,productID,totalAmount,DateTime.Now,count,OrderStatus.Ordered);
                                orderDetails.Add(order);
                                System.Console.WriteLine($"Order placed successfully! \n Order ID {order.OrderID}");
                            }
                            else
                            {
                                System.Console.WriteLine("Insufficient balance");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Entered quantity unavailable");
                        }
                        break;
                    }

                }
                if (productFlag)
                {
                    System.Console.WriteLine("Invalid Product ID");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        public static void OrderHistory()
        {
            try
            {
                System.Console.WriteLine("Order History");
                bool flag = true;
                foreach (OrderDetails order in orderDetails)
                {
                    if (loggedInCustomer.CustomerID == order.CustomerID)
                    {
                        flag = false;
                        System.Console.WriteLine($"{order.CustomerID} {order.ProductID} {order.TotalPrice} {order.PurchaseDate.ToString("dd/MM/yyyy", null)} {order.Quantity} {order.Status}");
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("There is no order details found !");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        public static void Cancel()
        {
            try
            {
                System.Console.WriteLine("Cancel");
                 bool flag = true;
                foreach (OrderDetails order in orderDetails)
                {
                    if (loggedInCustomer.CustomerID == order.CustomerID && order.Status==OrderStatus.Ordered)
                    {
                        flag = false;
                        System.Console.WriteLine($"{order.CustomerID} {order.ProductID} {order.TotalPrice} {order.PurchaseDate.ToString("dd/MM/yyyy", null)} {order.Quantity} {order.Status}");
                    }
                }
                if (flag)
                {
                    System.Console.WriteLine("There is no order details found !");
                }
                // get order id from user
                // check order id present in list and check it belong to current user and its status is ordered
                // If it is valid order id, then return amount to the user and return product's count change order status to cancelled
                //show order cancelled successfully
                else{
                    System.Console.WriteLine("Enter order id to be cancelled");
                    string orderID = Console.ReadLine().ToUpper();
                    bool orderFlag = true;
                    foreach(OrderDetails order in orderDetails)
                    {
                        if(loggedInCustomer.CustomerID == order.CustomerID && order.Status==OrderStatus.Ordered && order.OrderID==orderID)
                        {
                            order.Status = OrderStatus.Cancelled;
                            loggedInCustomer.Recharge(order.TotalPrice);
                            foreach(ProductDetails product in productDetails)
                            {
                                if(product.ProductID == order.ProductID)
                                {
                                    product.Stock+=order.Quantity;
                                }
                            }
                            System.Console.WriteLine("Order Cancelled Successfully");
                            orderFlag = false;
                        }
                    }
                    if(orderFlag)
                    {
                        System.Console.WriteLine("Invalid order id entered");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        public static void BalanceCheck()
        {
            try
            {
                System.Console.WriteLine($"Balance is: {loggedInCustomer.WalletBalance}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        public static void Recharge()
        {
            try
            {
                System.Console.WriteLine("Enter The amount to be racharged");
                double amount = double.Parse(Console.ReadLine());
                if (amount > 0)
                {
                    loggedInCustomer.Recharge(amount);
                }
                else
                {
                    System.Console.WriteLine("Invalid amount");

                }
                System.Console.WriteLine($"Balance is:{loggedInCustomer.WalletBalance}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        public static void DefaultData()
        {
            try
            {
                CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", "98858588", 5000, "ravi@mail.com");
                CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", "9888475757", 60000, "baskaran@mail.com");
                customerDetails.Add(customer1);
                customerDetails.Add(customer2);

                OrderDetails order1 = new OrderDetails("CID3001", "PID2001", 20000, DateTime.Now, 2, Enum.Parse<OrderStatus>("Ordered"));
                OrderDetails order2 = new OrderDetails("CID3002", "PID2003", 40000, DateTime.Now, 2, Enum.Parse<OrderStatus>("Ordered"));
                orderDetails.Add(order1);
                orderDetails.Add(order2);

                ProductDetails product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
                ProductDetails product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
                ProductDetails product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
                ProductDetails product4 = new ProductDetails("iPhone", 5, 50000, 6);
                ProductDetails product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
                ProductDetails product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
                ProductDetails product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);
                productDetails.Add(product1);
                productDetails.Add(product2);
                productDetails.Add(product3);
                productDetails.Add(product4);
                productDetails.Add(product5);
                productDetails.Add(product6);
                productDetails.Add(product7);

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.StackTrace);
            }
        }

    }


}