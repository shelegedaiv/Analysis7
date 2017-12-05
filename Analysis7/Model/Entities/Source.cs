
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Analysis7.Model.Entities
{
    public class Source : RiskEntity
    {

        public int Status
        {
            get { return Status; }

            set
            {
                if (value > 1) Status = 1;
                else if (value < 0) Status = 0;
                else Status = value;
                Notify();
            }
        }

        public Source(string name, string description) : base(name, description)
        {

        }


        



    }
}