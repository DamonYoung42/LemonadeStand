using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadStandTest
{
    [TestClass]
    public class LemonadeStandTest
    {
        [TestMethod]
        public void VerifyCashOnHandGreater()
        {

            //Arrange
            Day day = new Day();
            Store store = new Store();

            store.cashOnHand = 10.00;
            double cost = 6.50;
            bool result;

            //Act
            result = day.VerifyCashOnHand(store, cost);

            //Assert
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void VerifyCashOnHandLess()
        {
            //Arrange
            Day day = new Day();
            Store store = new Store();

            store.cashOnHand = 5.00;
            double cost = 6.50;
            bool result;

            //Act
            result = day.VerifyCashOnHand(store, cost);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void VerifyCashOnHandEqual()
        {

            //Arrange
            Day day = new Day();
            Store store = new Store();

            store.cashOnHand = 6.50;
            double cost = 6.50;
            bool result;

            //Act
            result = day.VerifyCashOnHand(store, cost);

            //Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void NoInventoryAllZero()
        {
            //Arrange
            Store store = new Store();
            bool result;

            //Act
            result = store.NoInventory();

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void NoInventoryOnlyLemonadeZero()
        {

            //Arrange
            Store store = new Store();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Cup cup = new Cup();
            Ice ice = new Ice();

            bool result;

            store.storeInventory.sugarInventory.Add(sugar);
            store.storeInventory.iceInventory.Add(ice);
            store.storeInventory.cupInventory.Add(cup);

            //Act
            result = store.NoInventory();

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void NoInventoryOnlySugarZero()
        {
            
            //Arrange
            Store store = new Store();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Cup cup = new Cup();
            Ice ice = new Ice();

            bool result;

            store.storeInventory.lemonInventory.Add(lemon);
            store.storeInventory.iceInventory.Add(ice);
            store.storeInventory.cupInventory.Add(cup);

            //Act
            result = store.NoInventory();

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void NoInventoryOnlyIceZero()
        {

            //Arrange
            Store store = new Store();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Cup cup = new Cup();
            Ice ice = new Ice();

            bool result;

            store.storeInventory.lemonInventory.Add(lemon);
            store.storeInventory.sugarInventory.Add(sugar);
            store.storeInventory.cupInventory.Add(cup);

            //Act
            result = store.NoInventory();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NoInventoryOnlyCupZero()
        {

            //Arrange
            Store store = new Store();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Cup cup = new Cup();
            Ice ice = new Ice();

            bool result;

            store.storeInventory.lemonInventory.Add(lemon);
            store.storeInventory.sugarInventory.Add(sugar);
            store.storeInventory.iceInventory.Add(ice);

            //Act
            result = store.NoInventory();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NoInventoryNoneZero()
        {


            //Arrange
            Store store = new Store();
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Cup cup = new Cup();
            Ice ice = new Ice();

            bool result;

            store.storeInventory.lemonInventory.Add(lemon);
            store.storeInventory.sugarInventory.Add(sugar);
            store.storeInventory.iceInventory.Add(ice);
            store.storeInventory.cupInventory.Add(cup);

            //Act
            result = store.NoInventory();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetWeatherForecastTemperature()
        {

            //Arrange
            Weather weather = new Weather();
            int result;
            int tempMin = 30;
            int tempMax = 100;

            //Act
            weather.SetWeather();
            result = weather.GetWeatherTemperature();
            //Assert
            Assert.IsTrue(tempMin <= result && result <= tempMax);

        }
        [TestMethod]
        public void SetWeatherForecastConditions()
        {
         
            //Arrange
            Weather weather = new Weather();
            string result;

            //Act
            weather.SetWeather();
            result = weather.GetWeatherConditions();

            //Assert
            Assert.IsTrue(result == "Sunny" || result == "Rainy" || result == "Overcast");

        }

        [TestMethod]
        public void AddIceToIceInventory()
        {

            //Arrange
            Inventory inventory = new Inventory();
            int result;
            int quantity = 1;

            //Act
            inventory.AddToIceInventory(quantity);
            result = inventory.iceInventory.Count;

            //Assert
            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void AddSugarToSugarInventory()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int result;
            int quantity = 1;

            //Act
            inventory.AddToSugarInventory(quantity);
            result = inventory.sugarInventory.Count;

            //Assert
            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void AddLemonToLemonInventory()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int result;
            int quantity = 1;

            //Act
            inventory.AddToLemonInventory(quantity);
            result = inventory.lemonInventory.Count;

            //Assert
            Assert.IsTrue(result == 1);

        }

        [TestMethod]
        public void AddCupToCupInventory()
        {
            //Arrange
            Inventory inventory = new Inventory();
            int result;
            int quantity = 1;

            //Act
            inventory.AddToCupInventory(quantity);
            result = inventory.cupInventory.Count;

            //Assert
            Assert.IsTrue(result == 1);
        }
    }
}
