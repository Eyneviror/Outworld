using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FiberFramework;
using Outworld.Actors;
using UnityEngine.AI;

namespace Outworld.GamePlay.Units
{
    [RequireComponent(typeof(Actor))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class WorkerActorWrapper : MonoBehaviour, IActorWrapper
    {
        [SerializeField] private UnitInfo unitInfo;
        private UnitTag unitTag = new UnitTag();

        public void InitWrapper(IComponentProvider provider)
        {
            provider.AddActorComponent(unitTag);
            provider.AddActorComponent(unitInfo);
            DefaultComponents<Rigidbody2D,NavMeshAgent> Data =
                new DefaultComponents<Rigidbody2D, NavMeshAgent>(GetComponent<Rigidbody2D>(),GetComponent<NavMeshAgent>());
            //TODO: Need reafcotring. Level : 0
            GetComponent<NavMeshAgent>().updateUpAxis = false;
            GetComponent<NavMeshAgent>().updateRotation = false;
            provider.AddActorComponent(Data);
        }
    }
}
