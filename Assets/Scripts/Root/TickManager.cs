using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outworld.Main.Interfaces;

namespace Outworld.Main
{
    public class TickManager : ITick, ITickFixed
    {
        private static  List<ITick> ticks;
        private static  List<ITickFixed> tickFixeds;


        public TickManager()
        {
            ticks = new List<ITick>();
            tickFixeds = new List<ITickFixed>();
        }

        public void Tick()
        {
            foreach(var tick in ticks)
            {
                tick.Tick();
            }

        }

        public void TickFixed()
        {
            foreach(var tickFixed in tickFixeds)
            {
                tickFixed.TickFixed();
            }
        }

        public static void Register(ITick tick,ITickFixed tickFixed = null)
        {
            ticks.Add(tick);
            if (tickFixed != null)
                tickFixeds.Add(tickFixed);
        }

        public static void Remove(ITick tick)
        {
            ticks.Remove(tick);
        }
        public static void Remove(ITickFixed tick)
        {
            tickFixeds.Remove(tick);
        }
    }
}
