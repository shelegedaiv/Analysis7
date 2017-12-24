using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Analysis7.Model
{
    class DataSerializer
    {
        public static void SerializeData(string fileName, ModelStarter data)
        {
            var formatter = new BinaryFormatter();
            var s = new FileStream(fileName, FileMode.OpenOrCreate);
            formatter.Serialize(s, data);
            s.Close();
        }

        public static ModelStarter DeserializeState(string fileName)
        {
            var s = new FileStream(fileName, FileMode.Open);
            var formatter = new BinaryFormatter();
            var modelStarter= (ModelStarter)formatter.Deserialize(s);
            s.Close();
            return modelStarter;
        }
    }
}
