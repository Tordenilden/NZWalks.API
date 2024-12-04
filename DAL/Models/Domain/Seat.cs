using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Seat
    {

        public int SeatId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        
        // Foreign Key
        public int TheaterId { get; set; }
        // Navigation Property
        public Theater Theater { get; set; } = null!;

    }
}
