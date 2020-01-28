using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Room:BaseEntity
    {
        public string Number { get; set; }
        public int Floor { get; set; }
        public string Block { get; set; }
        public int TypeID { get; set; }
        public decimal Price { get; set; }

        //Relational Properties
        public virtual Type Type { get; set; }
        public virtual List<Reservation> Reservations { get; set; }

        public override string ToString()
        {
            return $"{Number} {Floor} {Block} {Type.TypeName}";
        }
    }
}
