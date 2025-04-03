using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingApp.Domain.Constants
{
    public enum BookingStatus
    {
        // Possible values: "Pending", "Confirmed", "Cancelled"
        Pending=1,
        Confirmed=2,
        Cancelled=3
    }
}
