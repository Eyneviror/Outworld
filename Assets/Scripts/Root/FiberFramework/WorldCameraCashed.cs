using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FiberFramework;
namespace FiberFramework
{
    public class WorldCameraCashed
    {
        private static Camera camera;
        public WorldCameraCashed()
        {
            camera = Camera.main;
        }

        public WorldCameraCashed(Camera cam)
        {
            camera = cam;
        }

        public static Camera Get()
        {
            return camera;
        }
    }
}
