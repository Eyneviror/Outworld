using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiberFramework;
namespace Outworld.GamePlay
{
    public class AllocationActorsService
    {
        private Camera mainCamera;
        public AllocationActorsService(Camera camera)
        {
            mainCamera = camera;
        }

        public IComponentProvider[] GetAllocationActorsOnScreenRectangle(Vector2 startPoint, Vector2 endPoint)
        {

            Collider2D[] coliders = Physics2D.OverlapAreaAll(
                mainCamera.ScreenToWorldPoint(startPoint),
                mainCamera.ScreenToWorldPoint(endPoint)
                );
            List<IComponentProvider> providers = new List<IComponentProvider>();

            foreach(var col in coliders)
            {
                if(col.TryGetComponent(out ActorColider actorColider))
                {
                    providers.Add(actorColider.AtachedActor);
                }
            }
            return providers.ToArray();
        }

        public IComponentProvider GetUnitFromMousePosition()
        {

            Vector2 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(pos, Vector3.forward);
            if(hit.collider.TryGetComponent(out ActorColider actorColider))
            {
                return actorColider.AtachedActor;
            }
            return null;
        }
    }
}
