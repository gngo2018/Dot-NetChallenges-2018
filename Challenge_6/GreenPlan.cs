using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    public enum CarType { Gas, Hybrid, Electric}
    public class GreenPlan
    {
        public CarType TypeOfCar { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int AverageMileage { get; set; }

        public GreenPlan(CarType typeOfCar, string carBrand, string carModel, int averageMileage)
        {
            TypeOfCar = typeOfCar;
            CarBrand = carBrand;
            CarModel = carModel;
            AverageMileage = averageMileage;
        }

        public GreenPlan()
        {

        }
    }
}
