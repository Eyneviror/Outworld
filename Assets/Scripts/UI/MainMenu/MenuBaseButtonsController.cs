using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Outworld.UI.Models;
namespace Outworld.UI.Controllers.Menu
{
    public class UIStartGameController : IUserInterfaceController
    {
        MenuModel menuModel;

        public UIStartGameController(MenuModel model)
        {
            menuModel = model;
        }

        public void HandleUserAction()
        {
            menuModel.LoadNextLevel();
        }
    }
    public class UISettingsController : IUserInterfaceController
    {
        private MenuModel menuModel;

        public UISettingsController(MenuModel model)
        {
            menuModel = model;
        }
        public void HandleUserAction()
        {
            menuModel.HideSettingsPanel();
        }
    }
    public class UIExitController : IUserInterfaceController
    {
        private MenuModel menuModel;
        public UIExitController(MenuModel model)
        {
            menuModel = model;
        }

        public void HandleUserAction()
        {
            menuModel.QuitGame();
        }
    }
}

