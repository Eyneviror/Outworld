using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FiberFramework
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InjectInitAttribute : Attribute
    {

    }

    public static class SimpleInject
    {
        public static bool CheckNeedDependencies(ActorBehaviour behaviour,List<ActorData> components, bool clearAllDependecies = false)
        {
            var method = FindInjectMethod(behaviour.GetType());
            if (method == null) { return false; }
            var methodParametrs = method.GetParameters();
            int sucsess = 0;

            foreach (var p in methodParametrs)
            {
                foreach (var c in components)
                {
                    if (p.ParameterType == c.GetType())
                    {
                        sucsess++;
                        continue;
                    }
                }

            }

            if (sucsess == methodParametrs.Length)
            {
                return false;
            }
            if (clearAllDependecies)
                method.Invoke(behaviour, null);
            return true;
        }
        public static void ResolveDependecies(ActorBehaviour behaviour, List<ActorData> components)
        {
            var method = FindInjectMethod(behaviour.GetType());
            if (method == null) { return; }
            var methodParametrs = method.GetParameters();

            object[] injectedParams =
                new object[methodParametrs.Length];

            for (int i = 0; i < methodParametrs.Length; i++)
            {
                foreach (var actorComponent in components)
                {
                    if (methodParametrs[i].ParameterType == actorComponent.GetType())
                    {
                        injectedParams[i] = actorComponent;
                        break;
                    }
                }
                if (injectedParams[i] == null)
                {
                    Debug.LogWarning("Cannot resolve dependence in: " +
                        behaviour.GetType().FullName + " Parametr: " + methodParametrs[i].ParameterType.Name);
                    return;
                }
            }
            try
            {
                method.Invoke(behaviour, injectedParams);
                behaviour.IsDependeciesInjected = true;
            }
            catch
            {
                Debug.LogError("Cannot resolve dependencies in: " + behaviour.GetType().FullName);
            }
        }
        public static System.Reflection.MethodInfo FindInjectMethod(Type type)
        {
            foreach (var method in type.GetMethods())
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (var atr in attributes)
                {
                    if (atr is InjectInitAttribute)
                    {
                        return method;
                    }
                }
            }
            return null;
        }
    }
}
