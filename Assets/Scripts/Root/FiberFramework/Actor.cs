using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Outworld.Main.Interfaces;
using Outworld.Main;

namespace FiberFramework
{
    public sealed class Actor : MonoBehaviour, ITick,ITickFixed, IComponentProvider
    {
        private List<ActorBehaviour> behaviours = new List<ActorBehaviour>();
        private List<ActorData> components = new List<ActorData>();

        public void Init()
        {
            ActorsCollesction.Add(this);
            components.Add(new TransformComponent(transform));
            InitWrapper();
            foreach (var b in behaviours)
            {
                b.Init(this);
            }
        }

        public T GetActorComponent<T>() where T : ActorData
        {
            foreach (var c in components)
            {
                if (c is T component)
                {
                    return component;
                }
            }
            return null;
        }


        public void RemoveActorComponent<T>() where T : ActorData
        {
            ActorData actorData = null;

            foreach (var c in components)
            {
                if (c is T component)
                {
                    actorData = component;
                }
            }

            if (actorData != null)
                components.Remove(actorData);
        }

        public bool TryGetActorComponent<T>()
        {
            foreach (var c in components)
            {
                if (c is T component)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddActorBehaviour<T>(T component, bool checkDependesInBehaviours = true) where T : ActorBehaviour
        {
            behaviours.Add(component);
            SimpleInject.ResolveDependecies(component, components);
            if (component.IsDependeciesInjected)
            {
                component.Init(this);
                component.isInited = true;
            }
        }

        public void RemoveActorBehaviour<T>() where T : ActorBehaviour
        {
            ActorBehaviour beh = null;

            foreach (var c in behaviours)
            {
                if (c is T component)
                {
                    beh = component;
                }
            }

            if (beh != null)
               // beh.OnRemoved();
                behaviours.Remove(beh);
        }

        public bool TryGetBehaviour<T>() where T : ActorBehaviour
        {
            foreach (var c in behaviours)
            {
                if (c is T component)
                {
                    return true;
                }
            }
            return false;
        }

        public void Tick()
        {
            for (int i =0;i<behaviours.Count;i++)
            {
                if (behaviours[i] == null)
                    continue;
                if (behaviours[i].isEnabled & behaviours[i].IsDependeciesInjected & behaviours[i].isInited)
                    behaviours[i].Update();
            }
        }
        public void TickFixed()
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                if (behaviours[i] == null)
                    continue;
                if (behaviours[i].isEnabled & behaviours[i].IsDependeciesInjected & behaviours[i].isInited)
                    behaviours[i].FixedUpdate();
            }
        }

        public void AddActorComponent<T>(T component, bool checkDependesInBehaviours = true) where T : ActorData
        {
            components.Add(component);
            if (checkDependesInBehaviours)
            {
                foreach (var behaviour in behaviours)
                {
                    if (!behaviour.IsDependeciesInjected)
                    {
                        SimpleInject.ResolveDependecies(behaviour, components);
                        behaviour.Init(this);
                        behaviour.isInited = true;
                    }


                }
            }
        }

        private void Start()
        {
            Init();
        }

        private void OnEnable()
        {
            TickManager.Register(this,this);
        }

        private void OnDisable()
        {
            TickManager.Remove((ITick)this);
            TickManager.Remove((ITickFixed)this);
        }

        private void OnDestroy()
        {
            ActorsCollesction.Reomove(this);
        }

        private void InitWrapper()
        {
            if (TryGetComponent(out IActorWrapper actorWrapper))
            {
                actorWrapper.InitWrapper(this);
            }
        }

        public T GetActorBehaviour<T>() where T : ActorBehaviour
        {
            foreach (var c in behaviours)
            {
                if (c is T component)
                {
                    return component;
                }
            }
            return null;
        }


    }
}
