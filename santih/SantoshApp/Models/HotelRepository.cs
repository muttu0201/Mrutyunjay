using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantoshApp.Models
{
    public class HotelRepository : IHotelRepository
    {
        private readonly PatilDbContext _context;

        public HotelRepository( PatilDbContext context)
        {
            _context = context;
        }
        public void Add(HotelModel hotel)
        {
            _context.HotelModels.Add(hotel);

            _context.SaveChanges();

        }

        public HotelModel Find(int hotelId)
        {
          var hotel =   _context.HotelModels.Find(hotelId);
            return hotel;

        }

        public IEnumerable<HotelModel> GetAll()
        {
          return  _context.HotelModels.ToList();

        }

        public HotelModel Remove(int hotelId)
        {
            var hotelEntry = Find(hotelId);
            _context.HotelModels.Remove(hotelEntry);
            _context.SaveChanges();
            return hotelEntry;
        }

        public void Update(HotelModel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
