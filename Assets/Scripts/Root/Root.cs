using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outworld.UI.Views;
using Outworld.UI.Models;
using Outworld.UI.Controllers;
using Outworld.UI.Controllers.Menu;
using Outworld.Main.Interfaces;
using Outworld.Utils;
namespace Outworld
{
    public class Root : MonoBehaviour, IRootProvider
    {
        [SerializeField] private List<Scenario> currentScenarios;
        private readonly List<IScenarioBehaviour> scenarioBehaviours = new List<IScenarioBehaviour>();

        public void SetActiveScenario(string Name, bool active)
        {
            foreach (var sc in scenarioBehaviours)
            {
                if (sc.GetName() == Name) { sc.IsEnabled = active; }
            }
        }

        private void Awake()
        {

            for (int i = 0; i < currentScenarios.Count; i++)
            {
                scenarioBehaviours.Add(currentScenarios[i].GetComponent<IScenarioBehaviour>());
                scenarioBehaviours[i].Init(this);
            }
        }

        private void Update()
        {

            foreach (var sc in scenarioBehaviours)
            {
                if (sc.IsEnabled) { sc.UpdateScenario(); }
            }
        }
        private void FixedUpdate()
        {
            foreach (var sc in scenarioBehaviours)
            {
                if (sc.IsEnabled) { sc.FixedUpdateScenario(); }
            }
        }
    }
}

