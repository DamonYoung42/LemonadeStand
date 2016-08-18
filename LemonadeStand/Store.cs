using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {

        //public List<Ingredient> storeInventoryList;
        public Inventory storeInventory;
        public Weather weatherConditions;
        public UserInput storeInterface;
        public int dayOfOperation;
        public double cashOnHand;
        public double initialInvestment;
        public double productPrice;
        public Recipe recipe;
        public int dailyCupsSold;
        public double dailyRevenue;
        public double totalRevenue;
        public double dailyExpenses;
        public double totalExpenses;
        public int maxNumOfDays;
        public bool soldOut;
        public bool bankrupt;
        public double demandLevel;
        public List<Customer> dailyCustomers;
        public int dailyNumOfCustomers;
        public int spoiledLemons;
        public int spoiledIce;
        public int spoiledSugar;
        public bool validRecipe;
        public int lemonRecipeQuantity;
        public int iceRecipeQuantity;
        public int cupRecipeQuantity;
        public int sugarRecipeQuantity;

        public Store()
        {
            storeInventory = new Inventory();
            initialInvestment = 10.00;
            cashOnHand = initialInvestment;
            recipe = new Recipe();
            dayOfOperation = 1;
            maxNumOfDays = 0;
            weatherConditions = new Weather();
            productPrice = 0;
            dailyCupsSold = 0;
            dailyRevenue = 0;
            totalRevenue = 0;
            dailyExpenses = 0;
            totalExpenses = 0;
            bankrupt = false;
            soldOut = false;
            dailyCustomers = new List<Customer> { };
            spoiledLemons = 0;
            spoiledIce = 0;
            spoiledSugar = 0;
            storeInterface = new UserInput();
            validRecipe = false;
            lemonRecipeQuantity = 0;
            sugarRecipeQuantity = 0;
            iceRecipeQuantity = 0;
            cupRecipeQuantity = 0;

        }

        public void DisplayWeather()
        {
            Console.WriteLine("The weather forecast for Day {0} is {1} and {2}", dayOfOperation, weatherConditions.temperature, weatherConditions.conditions);
        }

        public void SubtractSpoiledDay()
        {
            foreach(Lemon ingredient in storeInventory.lemonInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }


            foreach (Ice ingredient in storeInventory.iceInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;

            }


            foreach (Sugar ingredient in storeInventory.sugarInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }


            foreach (Cup ingredient in storeInventory.cupInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }

        }


        public void BuyInventory()
        {
            //DisplayInventory();
            AddLemonInventory();
            AddSugarInventory();
            AddIceInventory();
            AddCupInventory();
        
        }

        public void AddLemonInventory()
        {
            int userInput;
            double cost = 0;
            Lemon newLemon;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} lemons in your inventory.", storeInventory.lemonInventory.Count());
            userInput = storeInterface.SetInventory("lemon");
            
            switch (userInput)
            {
                case 1:
                    cost = .60;
                    numOfItemsToAdd = 5;
                    break;
                case 2:
                    cost = 2.00;
                    numOfItemsToAdd = 20;
                    break;
                case 3:
                    cost = 4.00;
                    numOfItemsToAdd = 50;
                    break;
                default:
                    addItems = false;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newLemon = new Lemon();
                    storeInventory.lemonInventory.Add(newLemon);
                }
                dailyExpenses += cost;
                totalExpenses += cost;
                UpdateCashOnHand(cost);
            }

        }

        public void AddSugarInventory()
        {
            int userInput;
            double cost = 0;
            Sugar newSugar;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} sugar in your inventory.", storeInventory.sugarInventory.Count());
            userInput = storeInterface.SetInventory("sugar");

            switch (userInput)
            {
                case 1:
                    cost = .60;
                    numOfItemsToAdd = 5;
                    break;
                case 2:
                    cost = 2.00;
                    numOfItemsToAdd = 20;
                    break;
                case 3:
                    cost = 9.00;
                    numOfItemsToAdd = 100;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newSugar = new Sugar();
                    storeInventory.sugarInventory.Add(newSugar);
                }
                dailyExpenses += cost;
                totalExpenses += cost;
                UpdateCashOnHand(cost);
            }

        }

        public void AddIceInventory()
        {
            int userInput;
            double cost = 0;
            Ice newIce;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} ice cubes in your inventory.", storeInventory.iceInventory.Count());
            userInput = storeInterface.SetInventory("ice");

            switch (userInput)
            {
                case 1:
                    cost = .80;
                    numOfItemsToAdd = 100;
                    break;
                case 2:
                    cost = 1.80;
                    numOfItemsToAdd = 250;
                    break;
                case 3:
                    cost = 2.50;
                    numOfItemsToAdd = 500;
                    break;
                default:
                    addItems = false;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newIce = new Ice();
                    storeInventory.iceInventory.Add(newIce);
                }
                dailyExpenses += cost;
                totalExpenses += cost;
                UpdateCashOnHand(cost);
            }

        }

        public void AddCupInventory()
        {
            int userInput;
            double cost = 0;
            Cup newCup;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} cups in your inventory.", storeInventory.cupInventory.Count());
            userInput = storeInterface.SetInventory("cup");

            switch (userInput)
            {
                case 1:
                    cost = 3.00;
                    numOfItemsToAdd = 50;
                    break;
                case 2:
                    cost = 5.00;
                    numOfItemsToAdd = 100;
                    break;
                case 3:
                    cost = 8.00;
                    numOfItemsToAdd = 200;
                    break;
                default:
                    addItems = false;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newCup = new Cup();
                    storeInventory.cupInventory.Add(newCup);
                }
                dailyExpenses += cost;
                totalExpenses += cost;
                UpdateCashOnHand(cost);
            }

        }
        public bool CheckCashOnHand(double cost)
        {
            if (cashOnHand < cost)
            {
                Console.WriteLine("Sorry, you don't have enough cash to purchase those ingredients.");
                return false;
            }
            return true;
        }

        //public void DisplayInventory()
        //{
        //    var distinctInventoryItems = storeInventory.Select(x => x.name)
        //        .GroupBy(s => s)
        //        .Select(g => new { name = g.Key, Count = g.Count() });

        //    foreach (var item in distinctInventoryItems)
        //    {
        //        Console.WriteLine("Ingredient: {0}, Quantity: {1}", item.name, item.Count);
        //    }

        //}

        public void SetProductPrice()
        {
            productPrice = storeInterface.SetPrice();

        }

        public void UpdateCashOnHand(double cost)
        {
            cashOnHand -= cost;
            Console.WriteLine("Cash on hand: {0:$0.00}", cashOnHand);
        }


        public void CreateRecipe()
        {
            do
            {
                Console.WriteLine("Set your recipe for the day.");
                lemonRecipeQuantity = storeInterface.SetRecipe("lemons");

                sugarRecipeQuantity = storeInterface.SetRecipe("sugar");

                iceRecipeQuantity = storeInterface.SetRecipe("ice");

                CheckForValidRecipe();

            } while (!validRecipe);
       }

        public void CheckForValidRecipe()
        {
            
            if ((storeInventory.lemonInventory.Count() < lemonRecipeQuantity)
                || (storeInventory.iceInventory.Count() < iceRecipeQuantity) 
                    || (storeInventory.sugarInventory.Count() < sugarRecipeQuantity)
                    || (storeInventory.cupInventory.Count() < cupRecipeQuantity))
                {
                validRecipe = false;
                Console.WriteLine("You don't have enough inventory to create your recipe!");
                BuyInventory();
                }
            else
            {
                validRecipe = true;
            }

        }

         public void SellToCustomers()
        {
            //open for business, generate customers
            //Update daily revenue, total revenue, total expenses

            Console.WriteLine("selling ... selling ... selling!!!");
       
            foreach(Customer customer in dailyCustomers)
            {
                if (!soldOut)
                {
                    if (customer.chanceOfPurchase >= demandLevel)
                    {
                        dailyCupsSold++;
                        dailyRevenue += productPrice;
                        ////remove inventory
                        storeInventory.cupInventory.RemoveAt(0);
                        storeInventory.iceInventory.RemoveRange(0, iceRecipeQuantity);
                    }
                                    
                    ////check inventory levels -- not here; have to make pitcher, remove lemons and sugar when pitcher is made!!!
                    ////CheckInventory();
                }
            }

            totalRevenue += dailyRevenue;
            cashOnHand += dailyRevenue;

        

        }

        public void RemoveInventory()
        {
            storeInventory.lemonInventory.RemoveRange(0, lemonRecipeQuantity);
            storeInventory.iceInventory.RemoveRange(0, iceRecipeQuantity);
            storeInventory.sugarInventory.RemoveRange(0, sugarRecipeQuantity);
        }       

        public void CheckInventory()
        {
            if ((storeInventory.lemonInventory.Count() < lemonRecipeQuantity) ||
                    (storeInventory.sugarInventory.Count() < sugarRecipeQuantity) ||
                    (storeInventory.iceInventory.Count() < iceRecipeQuantity) ||
                    (storeInventory.cupInventory.Count() < cupRecipeQuantity))
            {
                soldOut = true;
            }

            if (soldOut)
            {
                Console.WriteLine("You have run out of supplies.");
            }
        }

        public void GenerateCustomers()
        {
            int numOfCustomersMin = 25;
            int numOfCustomersMax = 150;
            Random random = new Random(DateTime.Now.Millisecond);

            dailyNumOfCustomers = random.Next(numOfCustomersMin, numOfCustomersMax);

            for (int i = 0; i < Convert.ToInt32(dailyNumOfCustomers); i++)
            {
                Customer newCustomer = new Customer(weatherConditions, productPrice);
                dailyCustomers.Add(newCustomer);
            }

        }
        
        public void RemoveSpoiledInventory()
        {
            storeInventory.lemonInventory.RemoveAll(item => item.numOfDaysBeforeExpiration == 0);
            storeInventory.iceInventory.RemoveAll(item => item.numOfDaysBeforeExpiration == 0);
            storeInventory.sugarInventory.RemoveAll(item => item.numOfDaysBeforeExpiration == 0);
        }

        public void GenerateDemandLevel()
        {
            int temperatureLevelOne = 60;
            int temperatureLevelTwo = 75;
            int temperatureLevelThree = 85;
            double sunnyFactor = 1.1;
            double overcastFactor = .80;
            double rainyFactor = .20;

            Random chance = new Random(DateTime.Now.Millisecond);
            demandLevel = chance.Next(0, 100);
            if (weatherConditions.temperature < temperatureLevelOne)
            {
                demandLevel *= .30;
            }
            else if (weatherConditions.temperature < temperatureLevelTwo)
            {
                demandLevel *= .60;
            }
            else if (weatherConditions.temperature < temperatureLevelThree)
            {
                demandLevel *= .75;
            }
            else
            {
                demandLevel *= .90;
            }

            switch (weatherConditions.conditions)
            {
                case "Sunny":
                    demandLevel *= sunnyFactor;
                    break;
                case "Overcast":
                    demandLevel *= overcastFactor;
                    break;
                case "Rainy":
                    demandLevel *= rainyFactor;
                    break;
            }
        }

    }
}
