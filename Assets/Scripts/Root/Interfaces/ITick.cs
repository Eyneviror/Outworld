using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outworld.Main.Interfaces
{
    public interface ITick
    {
        public void Tick();
    }

    public interface ITickFixed
    {
        public void TickFixed();
    }
    
}
