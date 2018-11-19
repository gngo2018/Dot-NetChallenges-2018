using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6
{
    class GreenPlanRepository
    {
        List<GreenPlan> _masterList = new List<GreenPlan>();
        List<GreenPlan> _listOfGasCars = new List<GreenPlan>();
        List<GreenPlan> _listOfHybridCars = new List<GreenPlan>();
        List<GreenPlan> _listOfElectricCars = new List<GreenPlan>();

        //Can someone please go over this with me to explain what exactly is happening. Have kind of an idea, but not functioning the way I'm wanting it to in the UI for Update
        //Ended up not using, but still want to go over it
        public List<GreenPlan> GetMasterList()
        {
            var masterList = _masterList.Concat(_listOfGasCars).Concat(_listOfHybridCars).Concat(_listOfElectricCars).ToList();
            _masterList = masterList;
            return _masterList;
        }

        //Gas List
        public void AddCarToGasList(GreenPlan gas)
        {
            _listOfGasCars.Add(gas);
        }
        public List<GreenPlan> GetGasCarList()
        {
            return _listOfGasCars;
        }
        //Hybrid List
        public void AddCarToHybridList(GreenPlan hybrid)
        {
            _listOfHybridCars.Add(hybrid);
        }
        public List<GreenPlan> GetHybridCarList()
        {
            return _listOfHybridCars;
        }
        //Electric List
        public void AddCarToElectricList(GreenPlan electric)
        {
            _listOfElectricCars.Add(electric);
        }

        public List<GreenPlan> GetElectricCarList()
        {
            return _listOfElectricCars;
        }
    }
}
