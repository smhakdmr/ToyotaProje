using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string LicencePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Km { get; set; }
        public int? ModelYear { get; set; }
        public DateTime ArrivalDate { get; set; }
        public bool isGuarantee { get; set; }
        public string? City { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool isActive { get; set; }
    }
}
