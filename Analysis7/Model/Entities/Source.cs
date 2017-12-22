
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Analysis7.Model.Entities
{
    public class Source : RiskEntity
    {

        public Source(string name, string description) : base(name, description)
        {
            Status = true;
        }


        



    }
}