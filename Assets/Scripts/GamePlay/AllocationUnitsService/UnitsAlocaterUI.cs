using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Outworld.Main;
using Outworld.Main.Interfaces;
using FiberFramework;

namespace Outworld.GamePlay
{
    class UnitsAlocaterUI : MonoBehaviour, ITick
    {
        public event Action<IComponentProvider[]> OnUnitsAlocated;
        [SerializeField] private GUISkin uiskin;
        private AllocationActorsService allocationActors;
        private bool isPressed = false;
        private Vector2 startPos;
        private Vector2 endPos;



        public void Init(AllocationActorsService allocationActorsService)
        {
            allocationActors = allocationActorsService;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPressed = true;
                Vector2 pos = Input.mousePosition;
                startPos = pos;
            }


            if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;
                isPressed = false;
                var actors = allocationActors.GetAllocationActorsOnScreenRectangle(startPos, endPos);

                OnUnitsAlocated?.Invoke(actors);
                Debug.Log("Count Selecteblae unitus = " + actors.Length);
            }


        }

        private void OnEnable()
        {
            TickManager.Register(this);
        }
        private void OnDisable()
        {
            TickManager.Remove(this);
        }

        private void OnGUI()
        {
            GUI.skin = uiskin;

            if(isPressed)
            {
                endPos = Input.mousePosition;
                Rect rect = new Rect(Mathf.Min(endPos.x, startPos.x),
                Screen.height - Mathf.Max(endPos.y, startPos.y),
                Mathf.Max(endPos.x, startPos.x) - Mathf.Min(endPos.x, startPos.x),
                Mathf.Max(endPos.y, startPos.y) - Mathf.Min(endPos.y, startPos.y)
                );
                GUI.Box(rect, GUIContent.none);
            }
        }


    }
}
