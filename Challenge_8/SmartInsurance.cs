using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8
{
    public enum CarStyle { Sport, Small, Medium, Large}
    public class SmartInsurance
    {
        public CarStyle CarType { get; set; }
        public string DriverName { get; set; }
        public int AverageSpeed { get; set; }
        public bool DoesTailgate { get; set; }
        public bool StopOrRoll { get; set; }
        public bool Swerve { get; set; }
        public decimal PremiumCost { get; set; }
        public decimal TailgateCost { get; set; }
        public decimal StopCost { get; set; }
        public decimal SwerveCost { get; set; }
        public decimal SpeedingCost { get; set; }

        public SmartInsurance(CarStyle carType, string driverName, int averageSpeed, bool doesTailgate, bool stopOrRoll, bool swerve, decimal premiumCost, decimal tailgateCost, decimal stopCost, decimal swerveCost, decimal speedingCost)
        {
            CarType = carType;
            DriverName = driverName;
            AverageSpeed = averageSpeed;
            DoesTailgate = doesTailgate;
            StopOrRoll = stopOrRoll;
            Swerve = swerve;
            PremiumCost = premiumCost;
            TailgateCost = tailgateCost;
            StopCost = stopCost;
            SwerveCost = swerveCost;
            SpeedingCost = speedingCost;
        }

        public SmartInsurance()
        {

        }
    }
}
