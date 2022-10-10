using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Outworld.Main.Interfaces;
using Outworld.UI.Controllers;
using Outworld.UI.Controllers.Menu;
using Outworld.UI.Models;
using Outworld.UI.Views;
using Outworld.Utils;

namespace Outworld.LevelScenario
{
    public class MainMenuScenario : Scenario, IScenarioBehaviour
    {

        public bool IsEnabled { get => isEnabled; set => isEnabled = value; }

        [SerializeField] private MenuView menuView;
        [SerializeField] private MenuModel menuModel;
        private IUserInterfaceController startGameController;
        private IUserInterfaceController settingsGameController;
        private IUserInterfaceController exitGameController;
        private bool isEnabled = true;

        public MainMenuScenario()
        {
        }

        public void Init(IRootProvider rootProvider)
        {
            scenarioName = nameof(MainMenuScenario);
            startGameController = new UIStartGameController(menuModel);
            settingsGameController = new UISettingsController(menuModel);
            exitGameController = new UIExitController(menuModel);

            menuView.OnButtonStartCliced += startGameController.HandleUserAction;
            menuView.OnButtonSettingsCliced += settingsGameController.HandleUserAction;
            menuView.OnButtonExitCliced += exitGameController.HandleUserAction;
        }

        public void Exit()
        {

        }
        public void UpdateScenario()
        {

        }

        public string GetName()
        {
            return scenarioName;
        }

        public void FixedUpdateScenario()
        {

        }
    }
}
