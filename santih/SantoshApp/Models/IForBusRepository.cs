using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantoshApp.Models
{
    interface IForBusRepository
    {

        void Add(BusModel bus);
        IEnumerable<BusModel> GetAll();
        BusModel Find(int busId);
        BusModel Remove(int busId);
        void Update(BusModel bus);
    }
}
