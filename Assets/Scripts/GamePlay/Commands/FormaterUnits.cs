using FiberFramework;
using Outworld.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRavljen.UnitFormation;
using TRavljen.UnitFormation.Formations;
using UnityEngine;

namespace Outworld.GamePlay.Commands
{
    public class FormaterUnitsMBD : ICommand
    {
        private IComponentProvider[] selectableUnits;

        public FormaterUnitsMBD(IComponentProvider[] providers)
        {
            selectableUnits = providers;
        }

        public void Execute()
        {
            handler();
        }
        private async void handler()
        {
            bool clicked = false;
            while (!clicked)
            {
                if (Input.GetMouseButtonDown(1))
                {

                    List<Vector3> positons = new List<Vector3>();
                    foreach(var p in selectableUnits)
                    {
                        positons.Add(p.GetActorComponent<TransformComponent>().transform.position);
                    }
                    clicked = true;
                    var points = FormationPositioner.GetPositions(
                        positons,
                        new RectangleFormation(7,0.16f), WorldCameraCashed.Get().ScreenToWorldPoint(Input.mousePosition));
                    for(int i = 0;i<points.UnitPositions.Count;i++)
                    {
                        MoveAtBehaviour moveAt = new MoveAtBehaviour();
                        selectableUnits[i].AddActorBehaviour(moveAt);
                        moveAt.SetTargetInWorld(points.UnitPositions[i]);
                    }
                    

                }
                await Task.Delay(5);
            }

        }
    }
}
