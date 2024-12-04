using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class AddAddressRequestDto
    {
        public int AddressId { get; set; }
        public string Street1 { get; set; } = null!;
        public string? Street2 { get; set; }
        public int StreetNumber { get; set; }
        public string? Building { get; set; }
        public int? Floor { get; set; }
        public string? Direction { get; set; } // Venstre, Højre, Midt For, andet...

        // Navigation Properties
        public int PostalCodeId { get; set; }
    }
}
