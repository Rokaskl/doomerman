using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Visitor
{
    class LoggablePlayers
    {
        private List<IElement> elements;
        public LoggablePlayers(List<Player> players)
        {
            foreach (Player player in players)
            {
                elements.Add((IElement) player);
            }
        }
        public LoggablePlayers()
        {
            elements = new List<IElement>();
        }
        public void AddPlayer(Player player)
        {
            elements.Add((IElement) player);
        }
        public void PerformLogging(IVisitor visitor)
        {
            foreach (var player in elements)
            {
                player.Accept(visitor);
            }
        }
    }
}
