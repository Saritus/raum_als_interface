using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TouchWalkthrough
{
    public abstract class Binary
    {
        public static T Load<T>(string filename)
        {
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var result = (T)bin.Deserialize(stream);
                    return result;
                }
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
        }

        public static void Save<T>(T ToSerialize, string filename)
        {
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Create))
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