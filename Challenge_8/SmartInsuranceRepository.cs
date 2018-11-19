using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public class SmartInsuranceRepository
    {
        List<SmartInsurance> _listOfInfo = new List<SmartInsurance>();

        public void AddInfoToList(SmartInsurance info)
        {
            _listOfInfo.Add(info);
        }

        public List<SmartInsurance> GetInfoList()
        {
            return _listOfInfo;
        }

        public decimal CalculatedPremium()
        {
            decimal total = 0.0m;

            foreach (var driver in _listOfInfo)
            {
                if (driver.CarType == CarStyle.Sport)
                {
                    driver.PremiumCost = 25m;
                }

                if (driver.CarType == CarStyle.Large)
                {
                    driver.PremiumCost = 25m;
                }

                if (driver.DoesTailgate == true)
                {
                    driver.TailgateCost = 25m;
                }

                else
                {
                    driver.TailgateCost = 0m;
                }

                if (driver.StopOrRoll == true)
                {
                    driver.StopCost = 25m;
                }

                else
                {
                    driver.StopCost = 0m;
                }

                if (driver.Swerve == true)
                {
                    driver.SwerveCost = 25m;
                }

                else
                {
                    driver.SwerveCost = 0m;
                }

                if (driver.AverageSpeed >= 75)
                {
                    driver.SpeedingCost = 25m;
                }

                else
                {
                    driver.SpeedingCost = 0m;
                }

                total += driver.PremiumCost + driver.SpeedingCost + driver.StopCost + driver.SwerveCost + driver.SpeedingCost + 100m;
            }
            return total;
        }
    }


}
