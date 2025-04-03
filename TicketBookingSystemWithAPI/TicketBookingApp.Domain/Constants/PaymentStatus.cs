using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBookingApp.Domain.Constants
{
    public enum PaymentStatus
    {
        // Possible values: "Pending", "Success", "Failed"
        Pending=1,
        Success=2,
        Failed=3
    }
}
