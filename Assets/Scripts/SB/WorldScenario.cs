using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outworld.Utils;
using Outworld.Main;
using Outworld.Main.Interfaces;
using Outworld.GamePlay;
using Outworld.UI.Controllers;
using Outworld.UI.Models;
using UnityEngine;
using UnityEngine.UI;
using FiberFramework;

namespace Outworld.LevelScenario
{
    class WorldScenario : Scenario, IScenarioBehaviour
    {
        public bool IsEnabled { get => isEnabled; set { isEnabled = value; OnActiveChanged(); } }

        [SerializeField] private UnitsAlocaterUI unitsAlocaterUI;
        [SerializeField] private Button exampleButton;
        [SerializeField] private RectTransform parrentButtons;
        private bool isEnabled = true;
        private TickManager tickManager = new TickManager();
        private ActorsCollesction actorsCollesction;
        private AllocationActorsService allocationActorsService;
        private MainPanelController panelController;
        private WorldCameraCashed cameraCashed;

        public void Exit()
        {

        }

        public string GetName()
        {
            return scenarioName;
        }

        public void Init(IRootProvider rootProvider)
        {

            cameraCashed = new WorldCameraCashed();
            actorsCollesction = new ActorsCollesction();
            allocationActorsService = new AllocationActorsService(Camera.main);
            unitsAlocaterUI.Init(allocationActorsService);

            panelController = new MainPanelController(
                new MainPanelModel(exampleButton,parrentButtons)
                );
            unitsAlocaterUI.OnUnitsAlocated += panelController.UnitsAlocate;
;
        }

        public void UpdateScenario()
        {
            tickManager.Tick();
        }

        

        public void FixedUpdateScenario()
        {
            tickManager.TickFixed();
        }

        private void OnActiveChanged()
        {
            if (isEnabled)
                unitsAlocaterUI.OnUnitsAlocated += panelController.UnitsAlocate;
            if (!isEnabled)
                unitsAlocaterUI.OnUnitsAlocated -= panelController.UnitsAlocate;
        }
    }
}
