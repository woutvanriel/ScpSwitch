using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;

namespace ScpSwitch
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The time the scps get to switch.")]
        public float SwitchTime { get; set; } = 30f;

        [Description("The time scps are frozen.")]
        public float FreezeTime { get; set; } = 30f;
    }
}
