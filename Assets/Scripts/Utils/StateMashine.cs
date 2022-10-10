using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outworld.Utils.StateMashine
{
    public class SimpleStateMashine
    {
        private IState currentState;

        public void TransitionTo(IState state)
        {
            if (currentState != null)
            {
                currentState.Exit(this);
            }

            currentState = state;
            currentState.Enter(this);
        }

        public void UpdateState()
        {
            if (currentState != null)
                currentState.Update(this);
        }
        public void LateUpdateState()
        {
            if (currentState != null)
                currentState.Update(this);
        }
    }
}

