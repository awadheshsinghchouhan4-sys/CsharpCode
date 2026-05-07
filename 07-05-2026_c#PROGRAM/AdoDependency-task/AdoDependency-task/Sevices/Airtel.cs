using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDependency_task.Sevices
{
    internal class Airtel : ISim
    {
        public string RechargePlan()
        {
            return " 349 one month plan";
        }

        public string SimOrgainization()
        {
            return " Airtel Global";
        }
    }
}
