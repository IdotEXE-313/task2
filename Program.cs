using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;


namespace task2
{
    class Program
    {
        public static List<string> ProductNames = new List<string>();
        public static List<decimal> ProductPrices = new List<decimal>();
        static void Main(string[] args)
        {
            //Call both methods in order to fetch the product names and prices of each product
            GetProductName();
            GetProductCost();

            //Couldn't be bothered to create different methods for each of these considering they all return different values and can be done here anyway :)
            decimal highestPrice = ProductPrices.Max();
            int productNameIndex_h = ProductPrices.IndexOf(highestPrice);

            decimal lowestPrice = ProductPrices.Min();
            int productNameIndex_l = ProductPrices.IndexOf(lowestPrice);

            Console.WriteLine($"The most expensive item is {ProductNames[productNameIndex_h]} priced at £{highestPrice}");
            Console.WriteLine($"The least expensive item is {ProductNames[productNameIndex_l]} priced at £{lowestPrice}");

            //Outputs the result of the averageprice of all items (see averageprice method for calculations)
            decimal averagePrice = AveragePrice();
            Console.WriteLine($"The average price is £{averagePrice}");
            
        }
        public static void GetProductName()
        {
            Console.WriteLine("Enter 'None' when you have finished inputting products");
            Thread.Sleep(2000);

            while(true)
            {
                Console.Write("Enter a product name: ");
                string productName = Console.ReadLine();
                string isNone = productName.ToLower();


                if (isNone == "none") { break; } 

                ProductNames.Add(productName);

            }
        }
        public static void GetProductCost()
        {
            if (ProductNames.Count == 0) { Console.WriteLine("You did not input any items! Goodbye");Thread.Sleep(2000);Environment.Exit(-1); }

            Console.WriteLine("Enter a price for each product. Enter None to terminate the program.");
            Thread.Sleep(2000);

            while(true)
            {
                for (int index = 0; index < ProductNames.Count; index = index + 0) 
                {
                    Console.Write($"Enter the price of {ProductNames[index]}: £");
                    try
                    {
                        string checkForNone = Console.ReadLine().ToLower();
                        decimal productPrice;

                        if (checkForNone == "none") { Console.WriteLine("You have decided not to input a price. Goodbye!");Thread.Sleep(2000);Environment.Exit(-1); }

                        productPrice = Convert.ToDecimal(checkForNone);


                        ProductPrices.Add(productPrice);
                        index++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a valid decimal value");
                        continue;
                    }
                        
                }
                break;
            }
        }

        public static decimal AveragePrice()
        {
            decimal totalCost = 0;


            for (int index = 0; index < ProductPrices.Count; index++)
            {
                var currentIndex = ProductPrices[index];

                if (currentIndex > 50)
                {
                    currentIndex = decimal.Multiply(currentIndex, (decimal)0.95); //If the price is over 50, then a 5% discount is added
                    currentIndex = decimal.Multiply(currentIndex, (decimal)1.2); //Then goes on to apply 20% VAT
                    totalCost += currentIndex;
                }
                else
                {
                    currentIndex = decimal.Multiply(currentIndex, (decimal)1.2); //Applies 20% VAT if the price is not over 50
                    totalCost += currentIndex;
                }
                
            }

            decimal averagePrice = totalCost / ProductPrices.Count();

            return averagePrice;
        }
        
       

        
    }
}
