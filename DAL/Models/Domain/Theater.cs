using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Theater
    {
        public int TheaterId { get; set; }
        public string TheaterName { get; set; } = null!;
        public string? Location { get; set; }
        public int Capacity { get; set; }

        // Foreign Key
        public int AddressId { get; set; }
        // Navigation Property
        public Address? Address { get; set; }

        // Navigation Collection
        public List<Seat> Seats { get; set; } = new List<Seat>();
    }
}
