using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        List<Outing> _listOfOutings = new List<Outing>();

        public void AddOutingToList(Outing outing)
        {
            _listOfOutings.Add(outing);
        }

        public List<Outing> GetOutingList()
        {
            return _listOfOutings;
        }

        public decimal AddTotalCostOfOutings()
        {
            decimal total = 0.0m;

            foreach (var outing in _listOfOutings)
            {
                total += outing.TotalCost;
            }
            return total;
        }

        public decimal AddTotalCostGolf()
        {
            decimal totalEventCost = 0.0m;
            foreach (var outing in _listOfOutings)
            {
                if (outing.EventType == OutingType.Golf)
                {
                    totalEventCost = totalEventCost + outing.TotalCost;
                }
            }
            return totalEventCost;
        }

        public decimal AddTotalCostConcert()
        {
            decimal totalEventCost = 0.0m;
            foreach (var outing in _listOfOutings)
            {
                if (outing.EventType == OutingType.Concert)
                {
                    totalEventCost = totalEventCost + outing.TotalCost;
                }
            }
            return totalEventCost;
        }

        public decimal AddTotalCostBowling()
        {
            decimal totalEventCost = 0.0m;
            foreach (var outing in _listOfOutings)
            {
                if (outing.EventType == OutingType.Bowling)
                {
                    totalEventCost = totalEventCost + outing.TotalCost;
                }
            }
            return totalEventCost;
        }

        public decimal AddTotalCostPark()
        {
            decimal totalEventCost = 0.0m;
            foreach (var outing in _listOfOutings)
            {
                if (outing.EventType == OutingType.Park)
                {
                    totalEventCost = totalEventCost + outing.TotalCost;
                }
            }
            return totalEventCost;
        }


    }
}
