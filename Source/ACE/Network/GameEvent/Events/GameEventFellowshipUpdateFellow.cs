using ACE.Entity;
using ACE.Network.GameMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACE.Network.GameEvent.Events
{
    public class GameEventFellowshipUpdateFellow : GameMessage
    {
        public GameEventFellowshipUpdateFellow(Session session, Player player, bool sharexp)
            : base(GameMessageOpcode.GameEvent, GameMessageGroup.Group09)
        {
            Writer.Write(session.Player.Guid.Full);
            Writer.Write(session.GameEventSequence++);
            Writer.Write((uint)GameEventType.FellowshipUpdateFellow);

            // Information about fellow being added
            Writer.Write(player.Guid.Full);
            Writer.Write(0u);
            Writer.Write(0u);
            Writer.Write(player.Level);
            Writer.Write(player.Health.MaxValue);
            Writer.Write(player.Stamina.MaxValue);
            Writer.Write(player.Mana.MaxValue);
            Writer.Write(player.Health.Current);
            Writer.Write(player.Stamina.Current);
            Writer.Write(player.Mana.Current);
            if (sharexp)
            {
                Writer.Write((uint)0x1);
            }
            else
            {
                Writer.Write((uint)0x0);
            }
            Writer.WriteString16L(player.Name);
            Writer.Write(1u);

        }
    }
}
