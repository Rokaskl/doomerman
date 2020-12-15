using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server.Visitor
{
    public class PlayerStatusLogger : IVisitor
    {
        private string path;

        public PlayerStatusLogger(string fileName)
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
                streamWriter.WriteLine("Player " + player.User.Id + " is  " + (player.Alive? "Alive" : "Dead"));
            }
        }
    }
}
