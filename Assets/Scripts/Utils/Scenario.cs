using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outworld.Utils
{
    public abstract class Scenario : UnityEngine.MonoBehaviour
    {
        protected string scenarioName;
        public string ScenarioName => name;
    }
}
