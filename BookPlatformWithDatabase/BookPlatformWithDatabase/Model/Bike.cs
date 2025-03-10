using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPlatformWithDatabase.Model
{
    internal class Bike
    {
        public int BikeId { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public decimal Price { get; set; }
        public int PublishedYear { get; set; }
    }
}
