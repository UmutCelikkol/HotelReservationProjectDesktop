using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Reservation:BaseEntity
    {
        public int CustomerID { get; set; }
        public int RoomID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }

        public decimal Amount { get; set; }

        //Relational Properties
        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }


        public override string ToString()
        {
            return $"{Customer.FirstName} {Customer.LastName}:{StartDate.ToString()}->{FinishDate.ToString()}";
        }
    }
}
