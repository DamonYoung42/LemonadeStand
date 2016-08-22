using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LemonadeStand
{
    public class FileInputOutput
    {
        public string fileName = "LemonadeStandData.txt";
        public Tuple<int, double, double, int, int, double, int, Tuple<string>> data;

        public FileInputOutput()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public void WriteDailyResults(Day day, int dayOfOperation)
        {

            string dataString = dayOfOperation + "," + day.dailyRevenue + "," + day.dailyExpenses + "," + day.numOfCustomers + "," + day.numOfBuyingCustomers + "," + day.pricePerCup + "," + day.weatherActual.temperature + "," + day.weatherActual.conditions;
            //data = Tuple.Create(dayOfOperation, day.dailyRevenue, day.dailyExpenses, day.numOfCustomers, day.numOfBuyingCustomers, day.pricePerCup, day.weatherActual.temperature, day.weatherActual.conditions);
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(dataString);
            }

        }
            public void ReadDailyResults()
        {
            string dataString;
            using (StreamReader reader = new StreamReader(fileName))
            {
                do
                {
                    dataString = reader.ReadLine();
                    if (dataString != null)
                    {
                        string[] dataNumbers = new string[8];
                        dataNumbers = dataString.Split(new[] { ',' });
                        Console.WriteLine("Day {0}: Revenue ({1:$0.00}) ... Expenses ({2:$0.00}) ... # of Customers ({3}) ... # of Buying Customers ({4}) ... Price ({5:$0.00})... Temperature ({6}) ... Conditions ({7})",
                            dataNumbers[0], Convert.ToDouble(dataNumbers[1]), Convert.ToDouble(dataNumbers[2]), dataNumbers[3], dataNumbers[4], Convert.ToDouble(dataNumbers[5]), dataNumbers[6], dataNumbers[7]);
                    }

                } while (dataString != null);
            }

        }
    }

}

