using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outworld.Main.Interfaces
{
   public  interface IRootProvider
    {
        public void SetActiveScenario(string Name,bool active);
    }
}
