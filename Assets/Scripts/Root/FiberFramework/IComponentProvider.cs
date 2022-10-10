using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiberFramework
{
    public interface IComponentProvider
    {
        public T GetActorComponent<T>() where T : ActorData;
        public void AddActorComponent<T> (T component, bool checkDependesInBehaviours = true) where T : ActorData;
        public void RemoveActorComponent<T>() where T : ActorData;
        public bool TryGetActorComponent<T>();

        public T GetActorBehaviour<T>() where T : ActorBehaviour;
        public void AddActorBehaviour<T>(T component, bool checkDependesInBehaviours = true) where T : ActorBehaviour;
        public void RemoveActorBehaviour<T>() where T : ActorBehaviour;
        public bool TryGetBehaviour<T>() where T : ActorBehaviour;
    }
}
