using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Outworld.Main.Interfaces;
using FiberFramework;

namespace Outworld.GamePlay.Commands
{

    class ActorCommandMBD : ICommand
    {
        ICommand command;

        public ActorCommandMBD(ICommand cmd)
        {
            command = cmd;
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
                    clicked = true;
                    command.Execute();
                }
                await Task.Delay(5);
            }

        }
        
    }
}
