using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTYF.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;
        public string Summary { get; set; } = default!;
        public DateTime EventDateTime { get; set; }
        public string Location { get; set; } = default!;
        public int Capacity { get; set; }
    }
}
