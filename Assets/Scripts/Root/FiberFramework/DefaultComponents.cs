using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FiberFramework;

namespace FiberFramework
{
    public class TransformComponent : ActorData
    {
        public Transform transform;
        public TransformComponent(Transform t)
        {
            transform = t;
        }

    }
    public class RigidBody2DComponent : ActorData
    {
        public Rigidbody2D rigidbody;
        public RigidBody2DComponent(Rigidbody2D rb)
        {
            rigidbody = rb;
        }

    }


    public class DefaultComponent<T> : ActorData
    {
        public T component;

        public DefaultComponent(T c)
        {
            component = c;
        }

    }

    public class DefaultComponents<T1,T2> : ActorData
    {
        public T1 component;
        public T2 component2;

        public DefaultComponents(T1 c,T2 c2)
        {
            component = c;
            component2 = c2;
        }

    }
    public class DefaultComponents<T1, T2,T3> : ActorData
    {
        public T1 component;
        public T2 component2;
        public T3 component3;
        public DefaultComponents(T1 c, T2 c2, T3 c3)
        {
            component = c;
            component2 = c2;
            component3 = c3;
        }
    }

}
