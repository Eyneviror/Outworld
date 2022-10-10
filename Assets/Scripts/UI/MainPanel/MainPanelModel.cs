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
using TRavljen.UnitFormation;


namespace Outworld.UI.Models
{
    class MainPanelModel
    {
        private const int ALONE_TYPE = 1;
        private Button commandButton;
        private RectTransform parrent;
        FormaterUnitsMBD formaterUnits;

        private List<ICommand> actorCommands;
        private List<Button> buttonActions;

        public MainPanelModel(Button button,RectTransform par)
        {
            commandButton = button;
            parrent = par;
            actorCommands = new List<ICommand>();
            buttonActions = new List<Button>();
        }
        public void UnitsAlocated(IComponentProvider[] providers)
        {
            if(actorCommands.Count!=0)
            {
                actorCommands.Clear();
            }
            if(ActorsCollesction.ArrayValuesHasComponent<UnitTag>(providers))
            {
                CreateUnitsUI(providers);
            }
        }
        private void CreateUnitsUI(IComponentProvider[] providers)
        {
            List<UnitType> cashedTypes = new List<UnitType>();
            Dictionary<UnitType, int> countUnits = new Dictionary<UnitType, int>();

            int totalAlocated = providers.Length;

            if (buttonActions.Count != 0)
                ClearButtons();

            foreach (var provider in providers)
            {
                UnitInfo info = provider.GetActorComponent<UnitInfo>();
                if (cashedTypes.Contains(info.type))
                {
                    countUnits[info.type] += 1;
                }
                else
                {
                    countUnits.Add(info.type, 1);
                    cashedTypes.Add(info.type);
                }
            }
            if (cashedTypes.Count == ALONE_TYPE)
            {
                Button button = GameObject.Instantiate(commandButton, parrent);
                buttonActions.Add(button);
                formaterUnits = new FormaterUnitsMBD(providers);
                /*
                foreach(var c in providers)
                {
                    MoveAtBehaviour moveAt = new MoveAtBehaviour();
                    if (c.TryGetBehaviour<MoveAtBehaviour>())
                        c.RemoveActorBehaviour<MoveAtBehaviour>();
                    var command = new ActorCommandMBD( new ActorCommand(c, moveAt));
                    actorCommands.Add(command);
                    button.onClick.AddListener(command.Execute);
                }*/
               button.onClick.AddListener(formaterUnits.Execute);
                button.onClick.AddListener(ClearButtons);
                Debug.Log(buttonActions.Count);
            }
        }

        private void ClearButtons()
        {
            for (int i = 0;i<buttonActions.Count;i++)
            {
                GameObject.Destroy(buttonActions[i].gameObject);
            }
            buttonActions.Clear();
        }
    }
}
