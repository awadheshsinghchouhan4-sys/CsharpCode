using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDependency_task.Sevices
{
    internal class Jio : ISim
    {
        public string RechargePlan()
        {
            return " 300 - One mont recharge";
        }

        public string SimOrgainization()
        {
            return " Jio india ";
        }
    }
}
