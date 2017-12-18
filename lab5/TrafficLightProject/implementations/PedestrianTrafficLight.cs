using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject.implementations
{
    class PedestrianTrafficLight : TrafficLightBase
    {
        public PedestrianTrafficLight()
        {
            states = new TrafficLightState[] {
                new TrafficLightState(ColorIndicator.RED, 60.0f, Icon.STOP_MAN),
                new TrafficLightState(ColorIndicator.GREEN, 30.0f, Icon.WALK_MAN)
            };
        }
    }
}
