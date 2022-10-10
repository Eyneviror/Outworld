using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outworld.Main.Interfaces;
using FiberFramework;

namespace Outworld.GamePlay.Commands
{

    class ActorCommand : ICommand
    {
        private IComponentProvider actor;
        private ActorBehaviour behaviour;
        private ActorData data;

        public ActorCommand(IComponentProvider a, ActorBehaviour beh = null, ActorData d=null)
        {
            actor = a;
            behaviour = beh;
            data = d;
        }

        public void Execute()
        {
            if(data!=null)
                actor.AddActorComponent(data,false);
            if(behaviour!=null)
                actor.AddActorBehaviour(behaviour);
        }
    }
}
