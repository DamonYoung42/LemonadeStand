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

        public FileInputOutput()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public void WriteDailyResults(Day day, int dayOfOperation)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("dayOfOperation", Convert.ToString(dayOfOperation));
            data.Add("dailyRevenue", Convert.ToString(day.dailyRevenue));
            data.Add("dailyExpenes", Convert.ToString(day.dailyExpenses));
            data.Add("numOfCustomers", Convert.ToString(day.numOfCustomers));
            data.Add("numOfBuyingCustomers", Convert.ToString(day.numOfBuyingCustomers));
            data.Add("pricePerCup", Convert.ToString(day.pricePerCup));
            data.Add("actualTemperature", Convert.ToString(day.weatherActual.temperature));
            data.Add("actualConditions", Convert.ToString(day.weatherActual.conditions));


           using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                foreach (var item in data)
                {
                    writer.WriteLine(item.Key + "," + item.Value);
                }
            }

        }

    }
}
