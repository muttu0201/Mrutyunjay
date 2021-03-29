using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantoshApp.Models
{
    public class BusRepositry : IForBusRepository
    {
        private readonly PatilDbContext _context;

        public BusRepositry(PatilDbContext context)
        {
            _context = context;
        }
        public void Add(BusModel bus)
        {
            _context.BusModels.Add(bus);

            _context.SaveChanges();

        }

        public BusModel Find(int busId)
        {
            var hotel = _context.BusModels.Find(busId);
            return hotel;

        }

        public IEnumerable<BusModel> GetAll()
        {
            return _context.BusModels.ToList();

        }

        public BusModel Remove(int busId)
        {
            var busEntry = Find(busId);
            _context.BusModels.Remove(busEntry);
            _context.SaveChanges();
            return busEntry;
        }

        public void Update(BusModel bus)
        {
            _context.Entry(bus).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
