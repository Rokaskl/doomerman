using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server.Visitor
{
    public class PlayerPowerUpsLogger : IVisitor
    {
        private string path;

        public PlayerPowerUpsLogger(string fileName)
        {
            string subPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Logs");
            path = Path.Combine(subPath, fileName + ".txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void Visit(IElement element)
        {

            Player player = (Player) element;
            StreamWriter streamWriter = new StreamWriter(path, true);
            using (streamWriter)
            {
                streamWriter.Write("Player " + player.User.Id + " Power ups : " );
                for (int i = 0; i < player.PowerUps.Count; i++)
                {
                    streamWriter.Write(" " + player.PowerUps[i] + ", ");
                }
                streamWriter.Write('\n'.ToString());

            }




        }
    }
}
