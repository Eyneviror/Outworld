using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outworld.Anims;
using Outworld.Main.Interfaces;
namespace Outworld
{
    public class WorkerView : MonoBehaviour
    {
        private WorkerAnimator workerAnimator;
        private Vector2 direction;

        public void Init()
        {
            workerAnimator = new WorkerAnimator(GetComponent<Animator>());
        }
        private void Update()
        {
            workerAnimator.Update();
        }
        public void DirectionChanged(Vector2 direction)
        {
            workerAnimator.UpdateDirection(direction);
        }
    }
}
