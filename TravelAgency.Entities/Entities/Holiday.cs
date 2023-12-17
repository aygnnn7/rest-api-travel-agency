using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Entities.Entities
{
    public class Holiday
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Location")]
        public long? LocationId { get; set; }
        public Location Location { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        [StringLength(50)]
        public string Price { get; set; }
        public int FreeSlots { get; set; }



    }
}
