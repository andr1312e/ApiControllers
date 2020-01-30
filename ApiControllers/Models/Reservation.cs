using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
    public class Reservation
    {
        public int ReservationId { set; get; }
        public string ClientName { set; get; }
        public string Location { set; get; }
    }
}
