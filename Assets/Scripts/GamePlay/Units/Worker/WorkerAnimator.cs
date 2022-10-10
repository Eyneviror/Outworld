using System.Collections;
using System.Collections.Generic;
using Outworld.Main;
using Outworld.Main.Interfaces;
using UnityEngine;


namespace Outworld.Anims
{
    public class WorkerAnimator
    {
        private Vector2 direction;
        private readonly Animator animator;
        public WorkerAnimator(Animator animatorTrget)
        {
            animator = animatorTrget;
        }

        public void Update()
        {
            if (direction.y > 0 & direction.x == 0) { animator.Play("Base Layer.WorkerRunUp"); }
            if (direction.y < 0 & direction.x == 0) { animator.Play("Base Layer.WorkerRunDown"); }
            if (direction.x > 0) { animator.Play("Base Layer.WorkerRunRight"); }
            if (direction.x < 0) { animator.Play("Base Layer.WorkerRunLeft"); }
            if (direction == Vector2.zero) { animator.Play("Base Layer.WorkerIdle"); }
        }

        public void UpdateDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
