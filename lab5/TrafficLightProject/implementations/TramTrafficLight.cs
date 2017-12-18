using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.implementations
{
    class TramTrafficLight : TrafficLightBase
    {
        public TramTrafficLight()
        {
            states = new TrafficLightState[] {
                new TrafficLightState(ColorIndicator.RED, 30.0f),
                new TrafficLightState(ColorIndicator.GREEN, 30.0f)
            };
        }
    }
}
