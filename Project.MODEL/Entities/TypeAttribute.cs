using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class TypeAttribute:BaseEntity
    {
        public int TypeID { get; set; }
        public int AttributeID { get; set; }

        //Relational Properties
        public virtual Type Type { get; set; }
        public virtual Attribute Attribute { get; set; }
    }
}
