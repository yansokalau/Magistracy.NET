using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightProject
{
    enum ColorIndicator { RED, YELLOW, GREEN };

    enum Icon { NO_ICON, LEFT_ARROW, RIGHT_ARROW, STOP_MAN, WALK_MAN };

    class TrafficLightState
    {
        public readonly ColorIndicator color;

        public float switchTime;

        public readonly Icon icon;

        protected bool IsActive { get; private set; }

        public TrafficLightState(ColorIndicator color, float switchTime, Icon icon = Icon.NO_ICON)
        {
            this.color = color;
            this.switchTime = switchTime;
            this.icon = icon;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
