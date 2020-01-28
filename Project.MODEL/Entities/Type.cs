using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Type:BaseEntity
    {
        public string TypeName { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public virtual List<Room> Rooms { get; set; }
        public virtual List<TypeAttribute> TypeAttributes { get; set; }

        public override string ToString()
        {
            return $"{TypeName}";
        }
    }
}
