using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TouchWalkthrough
{
    public abstract class Binary
    {
        public static T Load<T>(string filename)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string file = Path.Combine(path, filename);

            try
            {
                using (FileStream strm = File.OpenRead(file))
                {
                    BinaryFormatter ser = new BinaryFormatter();
                    T something = (T)ser.Deserialize(strm);
                    return something;
                }
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
        }

        public static void Save<T>(T ToSerialize, string filename)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string file = Path.Combine(path, filename);

            try
            {
                using (Stream stream = File.Open(file, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, ToSerialize);
                }
            }
            catch (IOException)
            {
            }
        }
    }
}