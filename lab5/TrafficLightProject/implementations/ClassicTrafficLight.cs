using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.implementations
{
    class ClassicTrafficLight : TrafficLightBase
    {
        private bool fromRedToGreen; 

        public ClassicTrafficLight() {
            states = new TrafficLightState[] {
                new TrafficLightState(ColorIndicator.RED, 30.0f),
                new TrafficLightState(ColorIndicator.YELLOW, 1.5f),
                new TrafficLightState(ColorIndicator.GREEN, 45.0f)
            };
        }

        protected override void UpdateStateIndex() {
            switch(CurrentState.color)
            {
                case ColorIndicator.RED:
                    fromRedToGreen = true;
                    currentStateIndex = 1;
                    break;

                case ColorIndicator.YELLOW:
                    currentStateIndex = fromRedToGreen ? 2 : 0;
                    break;

                case ColorIndicator.GREEN:
                    fromRedToGreen = false;
                    currentStateIndex = 1;
                    break;
            }
        }
    }
}
