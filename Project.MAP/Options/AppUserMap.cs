using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap:EntityTypeConfiguration<AppUser>
    {
        public AppUserMap()
        {
            HasOptional(x=> x.Profile).WithRequired(x=>x.AppUser);
        }
    }
}
