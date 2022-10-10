using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using FiberFramework;
using Outworld.GamePlay;
using Outworld.Main;
using Outworld.Main.Interfaces;
using Outworld.Actors;
using Outworld.GamePlay.Commands;
using Outworld.UI.Models;

namespace Outworld.UI.Controllers
{
    class MainPanelController
    {
        private MainPanelModel model;
        public MainPanelController(MainPanelModel m)
        {
            model = m;
        }
        public void UnitsAlocate(IComponentProvider[] components)
        {
            model.UnitsAlocated(components);
        }
    }
}
