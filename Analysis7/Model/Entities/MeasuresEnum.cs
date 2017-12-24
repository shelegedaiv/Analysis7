using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analysis7.Model.Entities
{
    public enum MeasuresEnum
    {
        [Description("preliminary training of project team members")] training,
        [Description("agreeing a detailed list of requirements for software with the customer")] requirements,
        [Description("exact compliance with the requirements of the customer from the agreed list of requirements for software;")] complience_req       
    }

        
}
