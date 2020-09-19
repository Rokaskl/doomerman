using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Server
{
    public class DataUnit
    {
        public int Id;//Object identifier
        public Coordinates XY;//Object possition

        public DataUnit()
        {

        }

        public byte[] ToBytes()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, this);
                return ms.ToArray();
            }
        }

        public override string ToString()
        {
            return this.Id.ToString() + " " + this.XY.ToString();
        }
    }
}
