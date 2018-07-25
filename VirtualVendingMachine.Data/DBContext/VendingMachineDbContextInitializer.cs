using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Configuration;
using VirtualVendingMachine.Domain;

namespace VirtualVendingMachine.Data.DBContext
{
    public class VendingMachineDbContextInitializer : IDatabaseInitializer<VendingMachineDbContext>
    {

        public void InitializeDatabase(VendingMachineDbContext context)
        {

            context.Database.Delete();
            context.Database.Create();

            //initial data

            var tea = new Product
            {
                ProductName = "Tea"
            };
            var espresso = new Product
            {
                ProductName = "Espresso"
            };
            var juice = new Product
            {
                ProductName = "Juice"
            };
            var chickenSoup = new Product
            {
                ProductName = "Chicken Soup"
            };

            context.Products.Add(tea);
            context.Products.Add(espresso);
            context.Products.Add(juice);
            context.Products.Add(chickenSoup);

            var teaVending = new VendingMachineProduct
            {
                Price = (decimal) 1.30,
                Portion = 10,
                Product = tea
            };
            var espressoVending = new VendingMachineProduct
            {
                Price = (decimal) 1.80,
                Portion = 20,
                Product = espresso
            };
            var juiceVending = new VendingMachineProduct
            {
                Price = (decimal) 1.80,
                Portion = 20,
                Product = juice
            };
            var chickenSoupVending = new VendingMachineProduct
            {
                Price = (decimal) 1.80,
                Portion = 10,
                Product = chickenSoup
            };

            context.VendingMachineProducts.Add(teaVending);
            context.VendingMachineProducts.Add(espressoVending);
            context.VendingMachineProducts.Add(juiceVending);
            context.VendingMachineProducts.Add(chickenSoupVending);

            var tenCent = new Currency
            {
                CoinName = "10 Cent",
                Value = (decimal) 0.10
            };

            var twentyCent = new Currency
            {
                CoinName = "20 Cent",
                Value = (decimal) 0.20
            };

            var fiftyCent = new Currency
            {
                CoinName = "50 Cent",
                Value = (decimal) 0.50
            };

            var oneEuro = new Currency
            {
                CoinName = "1 Euro",
                Value = 1
            };

            context.Currencies.Add(tenCent);
            context.Currencies.Add(twentyCent);
            context.Currencies.Add(fiftyCent);
            context.Currencies.Add(oneEuro);

            var tenCentVending = new VendingMachineCoin
            {
                Currency = tenCent,
                Pieces = 100
            };

            var twentyCentVending = new VendingMachineCoin
            {
                Currency = twentyCent,
                Pieces = 100
            };

            var fiftyCentVending = new VendingMachineCoin
            {
                Currency = fiftyCent,
                Pieces = 100
            };

            var oneEuroVending = new VendingMachineCoin
            {
                Currency = oneEuro,
                Pieces = 100
            };

            context.VendingMachineCoins.Add(tenCentVending);
            context.VendingMachineCoins.Add(twentyCentVending);
            context.VendingMachineCoins.Add(fiftyCentVending);
            context.VendingMachineCoins.Add(oneEuroVending);

            context.SaveChanges();
        }
    }
}

