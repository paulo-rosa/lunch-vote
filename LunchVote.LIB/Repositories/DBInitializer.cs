using LunchVote.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchVote.LIB.Repositories
{
    public class DBInitializer : IDBInitializer
    {
        private LunchVoteContext _context;

        public DBInitializer(LunchVoteContext context)
        {
            _context = context;
        }

        public async Task Initialize()
        {
            if (_context.Professionals.Any()) return;

            var professionalsToAdd = new List<Professional>()
            {
                new Professional{ Name = "Dev. Sênior" },
                new Professional{ Name = "Dev. Pleno" },
                new Professional{ Name = "DBA" },
                new Professional{ Name = "Estagiário" },
                new Professional{ Name = "Tester" },
                new Professional{ Name = "GP" }
            };

            var restaurantsToAdd = new List<Restaurant>()
            {
                new Restaurant(){  Name = "Espaço 40" },
                new Restaurant(){  Name = "Prédio 50" },
                new Restaurant(){  Name = "RU" },
                new Restaurant(){  Name = "Prédio 11" },
                new Restaurant(){  Name = "Subway" }
            };

            await _context.Professionals.AddRangeAsync(professionalsToAdd);
            await _context.Restaurants.AddRangeAsync(restaurantsToAdd);
            await _context.SaveChangesAsync();
        }
    }
}
