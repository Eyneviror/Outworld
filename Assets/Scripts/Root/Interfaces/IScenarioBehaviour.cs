using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outworld.Main.Interfaces
{
    public interface IScenarioBehaviour
    {

        public bool IsEnabled {get ;set;}

        public void Init(IRootProvider rootProvider);
        public void UpdateScenario();
        public void FixedUpdateScenario();
        public void Exit();
        public string GetName();

    }
}
