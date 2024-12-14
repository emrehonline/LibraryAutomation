using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities
{
    public class Rent
    {
        public string Book { get; set; }
        public string Customer { get; set; }
        public string RentedDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
