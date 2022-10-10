using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FiberFramework
{
    public class ActorsCollesction
    {
        private static List<IComponentProvider> actors = new List<IComponentProvider>();
        /// <summary>
        /// Do not use at GameLogic! It's inside Actor static method. 
        /// Better to use ActorsCollesction.CreateEmptyActor().
        /// </summary>
        /// <param name="provider"></param>
        public static void Add(IComponentProvider provider)
        {
            actors.Add(provider);
        }
        /// <summary>
        /// Do not use at GameLogic! It's inside Actor static method. 
        /// Better to use ActorsCollesction.CreateEmptyActor().
        /// </summary>
        /// <param name="provider"></param>
        public static void Reomove(IComponentProvider provider)
        {
            actors.Remove(provider);
        }
        public static List<IComponentProvider> FindWith<T>() where T :ActorData
        {

            List<IComponentProvider> selectedComponents = new List<IComponentProvider>();
            foreach(var actor in actors)
            {
                if(actor.TryGetActorComponent<T>())
                {
                    selectedComponents.Add(actor);
                }
            }
            return selectedComponents;
            
        }
        public static List<IComponentProvider> ExecuteWith<T>()
        {
            List<IComponentProvider> selectedComponents = new List<IComponentProvider>();
            foreach (var actor in actors)
            {
                if (!actor.TryGetActorComponent<T>())
                {
                    selectedComponents.Add(actor);
                }
            }
            return selectedComponents;

        }
        public static IComponentProvider CreateActorEmpty()
        {
            GameObject go = GameObject.Instantiate(new GameObject());
            Actor actor = go.AddComponent<Actor>();
            actor.Init();
            return actor;
        }

        public static IComponentProvider CreateActorFromPerfab(Actor prefab)
        {
            Actor actor = GameObject.Instantiate(prefab);
            actor.Init();
            return actor;
        }

        public static bool ArrayValuesHasComponent<T>(IComponentProvider[] providers)
        {
            foreach(var provider in providers)
            {
                if (!provider.TryGetActorComponent<T>())
                    return false;
            }
            return true;
        }
    }
}
