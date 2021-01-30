using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScpSwitch.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    class ScpSwitch : ICommand
    {
        public string Command { get; } = "scpswitch";

        public string[] Aliases { get; } = new string[] { "switch" };

        public string Description { get; } = "Switches to the specified scp.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player ply = Player.Get(((CommandSender)sender).Nickname);
            bool PlayerHasSwitched;
            EventHandlers.PlayerHasSwitched.TryGetValue(ply, out PlayerHasSwitched);
            IEnumerable<Player> PlayerList = Player.List.Where(x => x.Team == Team.SCP);
            if (arguments.Count < 1)
            {
                response = "Use the plugin like this: .switch {scp you want to switch to}";
                return false;
            }
            else if (!EventHandlers.RoundStarted)
            {
                response = "The round hasn't started.";
                return false;
            }
            else if (ply.Team != Team.SCP)
            {
                response = "Only SCPs can use this command.";
                return false;
            }
            else if (PlayerHasSwitched == true)
            {
                response = "You can only swap once.";
            }
            else if (!EventHandlers.CanSwitch)
            {
                response = "You can't switch anymore.";
                return false;
            }
            else if (arguments.Contains("doctor") || arguments.Contains("doc") || arguments.Contains("49") || arguments.Contains("049"))
            {
                if (PlayerList.Where(x => x.Role == RoleType.Scp049).Count() < 1)
                {
                    response = "Swapping to SCP-049";
                    Cassie.Message("Danger . SCP 0 4 9 containment breach detected .");
                    ply.SetRole(RoleType.Scp049);
                    EventHandlers.PlayerHasSwitched.Add(ply, true);
                    FreezePlayer(ply);
                }
                else
                {
                    response = "There's already an instance of SCP-049.";
                    return false;
                }
            }
            else if (arguments.Contains("pc") || arguments.Contains("computer") || arguments.Contains("79") || arguments.Contains("079"))
            {
                if (PlayerList.Where(x => x.Role == RoleType.Scp079).Count() < 1)
                {
                    response = "Swapping to SCP-079";
                    Cassie.Message("Danger . SCP 0 7 9 containment breach detected .");
                    ply.SetRole(RoleType.Scp079);
                    EventHandlers.PlayerHasSwitched.Add(ply, true);
                }
                else
                {
                    response = "There's already an instance of SCP-079.";
                    return false;
                }
            }
            else if (arguments.Contains("shy") || arguments.Contains("guy") || arguments.Contains("shyguy") || arguments.Contains("96") || arguments.Contains("096"))
            {
                if (PlayerList.Where(x => x.Role == RoleType.Scp096).Count() < 1)
                {
                    response = "Swapping to SCP-096";
                    Cassie.Message("Danger . SCP 0 9 6 containment breach detected .");
                    ply.SetRole(RoleType.Scp096);
                    EventHandlers.PlayerHasSwitched.Add(ply, true);
                    FreezePlayer(ply);
                }
                else
                {
                    response = "There's already an instance of SCP-096.";
                    return false;
                }
            }
            else if (arguments.Contains("peanut") || arguments.Contains("nut") || arguments.Contains("173"))
            {
                if (PlayerList.Where(x => x.Role == RoleType.Scp173).Count() < 1)
                {
                    response = "Swapping to SCP-173";
                    Cassie.Message("Danger . SCP 1 7 3 containment breach detected .");
                    ply.SetRole(RoleType.Scp173);
                    EventHandlers.PlayerHasSwitched.Add(ply, true);
                    FreezePlayer(ply);
                }
                else
                {
                    response = "There's already an instance of SCP-173.";
                    return false;
                }
            }
            else if (arguments.Contains("larry") || arguments.Contains("old") || arguments.Contains("man") || arguments.Contains("106"))
            {
                if (PlayerList.Where(x => x.Role == RoleType.Scp106).Count() < 1)
                {
                    response = "Swapping to SCP-106";
                    Cassie.Message("Danger . SCP 1 0 6 containment breach detected .");
                    ply.SetRole(RoleType.Scp106);
                    EventHandlers.PlayerHasSwitched.Add(ply, true);
                    FreezePlayer(ply);
                }
                else
                {
                    response = "There's already an instance of SCP-106.";
                    return false;
                }
            }
            else if (arguments.Contains("dog") || arguments.Contains("939"))
            {
                if (PlayerList.Where(x => x.Role == RoleType.Scp93953).Count() < 1)
                {
                    response = "Swapping to SCP-939-53";
                    Cassie.Message("Danger . SCP 9 3 9 5 3 containment breach detected .");
                    ply.SetRole(RoleType.Scp93953);
                    EventHandlers.PlayerHasSwitched.Add(ply, true);
                    FreezePlayer(ply);
                }
                else if (PlayerList.Where(x => x.Role == RoleType.Scp93989).Count() < 1)
                {
                    response = "Swapping to SCP-939-89";
                    Cassie.Message("Danger . SCP 9 3 9 8 9 containment breach detected .");
                    ply.SetRole(RoleType.Scp93989);
                    EventHandlers.PlayerHasSwitched.Add(ply, true);
                    FreezePlayer(ply);
                }
                else
                {
                    response = "There's already two instances of SCP-939.";
                    return false;
                }
            }
            else
            {
                response = "SCP not found, did you put the name / number in correctly? the plugin only works in all lowercase.";
                return false;
            }
            return true;
        }

        private async void FreezePlayer(Player ply)
        {
            ply.EnableEffect(Exiled.API.Enums.EffectType.Ensnared);
            for (int i = 0; i < EventHandlers.plugin.Config.FreezeTime; i++)
            {
                ply.EnableEffect(Exiled.API.Enums.EffectType.Ensnared);
                ply.Broadcast(2, $"<color=red>YOU WILL BE UNFROZEN IN {EventHandlers.plugin.Config.FreezeTime - i} SECONDS</color>");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            ply.ClearBroadcasts();
            ply.DisableEffect(Exiled.API.Enums.EffectType.Ensnared);
        }
    }
}
