using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTYF.Domain.Entities
{
    public class EventBooking
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; } = default!;

        public string BookerName { get; set; } = default!;
        public string BookerEmail { get; set; } = default!;
        public string? Note { get; set; }

        public DateTime DateBooked { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
    }
}
