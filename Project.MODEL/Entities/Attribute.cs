﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Attribute:BaseEntity
    {
        public string AttributeName { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public virtual List<TypeAttribute> TypeAttributes { get; set; }

        public override string ToString()
        {
            return $"{AttributeName}";
        }
    }
}
