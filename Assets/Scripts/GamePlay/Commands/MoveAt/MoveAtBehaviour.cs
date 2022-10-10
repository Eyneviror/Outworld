using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiberFramework;
using UnityEngine;
using UnityEngine.AI;

namespace Outworld.GamePlay.Commands
{
    class MoveAtBehaviour : ActorBehaviour
    {
        private Rigidbody2D rigidBody;
        private NavMeshAgent agent;
        private Vector2 target;
        private IComponentProvider provider;

        public override void Init(IComponentProvider componentProvider)
        {
            provider = componentProvider;
            
        }

        [InjectInit]
        public void Inject(DefaultComponents<Rigidbody2D, NavMeshAgent> dc)
        {
            rigidBody = dc.component;
            agent = dc.component2;
        }

        public override void Update()
        {

        }

        public void SetTargetInWorld(Vector2 t)
        {
            target = t;
            agent.destination = target;
        }

        public override void FixedUpdate()
        {
            Vector2 pos = rigidBody.position;
           
            if((pos-target).magnitude<=0.01)
            {
               // agent.ResetPath();
                provider.RemoveActorBehaviour<MoveAtBehaviour>();
            }
        }

        public override void OnRemoved()
        {

        }
    }
}
  