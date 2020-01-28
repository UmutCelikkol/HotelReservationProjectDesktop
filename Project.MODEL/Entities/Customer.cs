using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCNo { get; set; }

        //Relational Properties

        public virtual List<Reservation> Reservations { get; set; }
        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{TCNo}: {FirstName} {LastName}";
        }
    }
}
