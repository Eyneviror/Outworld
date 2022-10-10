using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FiberFramework
{
    [Serializable]
    public abstract class ActorBehaviour
    {
        public bool isInited = false;
        public bool isEnabled = true;
        public bool IsDependeciesInjected = false;
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void Init(IComponentProvider provider);
        public abstract void OnRemoved();
    }
}
