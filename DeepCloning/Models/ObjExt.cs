using System.Runtime.Serialization.Formatters.Binary;

namespace DeepCloning.Models
{
    public static class ObjExt
    {
        public static T Clone<T>(this object objSource)
        {
            using (MemoryStream stream = new())
            {
                BinaryFormatter formatter = new();
                formatter.Serialize(stream, objSource);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
