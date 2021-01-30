using Exiled.API.Features;
using Exiled.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handlers = Exiled.Events.Handlers;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace ScpSwitch
{
    public class ScpSwitch : Plugin<Config>
    {
        public EventHandlers Handler { get; private set; }
        public override string Name => nameof(ScpSwitch);
        public override string Author => "Written by TheLazyKitten";
        public override Version Version { get; } = new Version(1, 0, 0);
        public ScpSwitch() { }

        public override void OnEnabled()
        {
            Handler = new EventHandlers(this);
            Server.RoundStarted += Handler.OnRoundStart;
            Server.RoundEnded += Handler.OnRoundEnd;
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= Handler.OnRoundStart;
            Server.RoundEnded -= Handler.OnRoundEnd;
            Handler = null;
        }
    }
}
