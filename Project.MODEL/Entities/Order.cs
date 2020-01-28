using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Order:BaseEntity
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        //Relational Properties
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }

        public override string ToString()
        {
            return $"{Customer.FirstName} {Customer.LastName}->{Product.ProductName}";
        }
    }
}
