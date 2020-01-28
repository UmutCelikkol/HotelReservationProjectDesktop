using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class TypeAttributeMap : EntityTypeConfiguration<TypeAttribute>
    {
        public TypeAttributeMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.TypeID,
                x.AttributeID
            });
        }
    }
}
