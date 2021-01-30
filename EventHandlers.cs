using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScpSwitch
{
    public class EventHandlers
    {
        public static bool RoundStarted { get; set; } = false;
        public static bool CanSwitch { get; set; } = false;
        public static Dictionary<Player, bool> PlayerHasSwitched { get; set; } = new Dictionary<Player, bool>();

        public static ScpSwitch plugin;
        public EventHandlers(ScpSwitch pl)
        {
            plugin = pl;
        }

        public async void OnRoundStart()
        {
            PlayerHasSwitched = new Dictionary<Player, bool>();
            CanSwitch = true;
            RoundStarted = true;
            await Task.Delay(TimeSpan.FromSeconds(plugin.Config.SwitchTime));
            CanSwitch = false;
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            CanSwitch = false;
            RoundStarted = false;
        }
    }
}
