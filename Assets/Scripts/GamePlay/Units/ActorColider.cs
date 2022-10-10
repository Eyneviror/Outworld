using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FiberFramework;

namespace Outworld.GamePlay
{
    [RequireComponent(typeof(BoxCollider2D))]
    class ActorColider: MonoBehaviour
    {
        [HideInInspector] public IComponentProvider AtachedActor => actor;
        [SerializeField] private Actor actor;

        
    }
}
