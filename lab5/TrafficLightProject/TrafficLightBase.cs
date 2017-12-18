using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject
{
    class TrafficLightBase
    {
        public TrafficLightState[] states;

        public TrafficLightState CurrentState {
            get
            {
                if (currentStateIndex < 0)
                {
                    currentStateIndex = 0;
                }
                else if (currentStateIndex >= states.Length)
                {
                    currentStateIndex = states.Length - 1;
                }

                return states[currentStateIndex];
            }
        }

        public bool isActive = true;

        protected int currentStateIndex;

        private float switchStateTimer;

        public TrafficLightBase() {
            
        }

        public void Reset() {
            isActive = true;
            currentStateIndex = 0;
            switchStateTimer = CurrentState.switchTime;
        }

        public void Tick(float deltaTime)
        {
            if (isActive)
            {
                switchStateTimer -= deltaTime;
            }

            if (switchStateTimer <= 0)
            {
                SwitchState();
            }
        }

        private void SwitchState() {
            CurrentState.Deactivate();

            UpdateStateIndex();

            CurrentState.Activate();

            switchStateTimer = CurrentState.switchTime;
        }

        protected virtual void UpdateStateIndex() {
            currentStateIndex++;

            if (currentStateIndex >= states.Length)
            {
                currentStateIndex = 0;
            }
        }     
    }
}
