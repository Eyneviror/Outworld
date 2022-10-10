using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outworld.Main.Interfaces;
using Outworld.Main;

namespace Outworld.Models
{
    public class WorkerModel : MonoBehaviour, ITick
    {
        [SerializeField] private WorkerView view;
        private Vector2 direction;

        public void Init()
        {
            direction = Vector2.zero;
            view.Init();
        }
        private void Start()
        {
            Init();
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir;
            Debug.Log("Direction :" + direction);
            view.DirectionChanged(dir);
        }

        public void Tick()
        {

        }

        private void OnEnable()
        {
            TickManager.Register(this);
        }
        private void OnDisable()
        {
            TickManager.Remove(this);
        }
    }
}
