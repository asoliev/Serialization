using System.Runtime.Serialization;

namespace OwnBinarySerialization
{
    [Serializable]
    class SimpleClass : ISerializable
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string? name;
        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        public SimpleClass() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id, typeof(int));
            info.AddValue("name", name, typeof(string));
        }

        public SimpleClass(SerializationInfo info, StreamingContext context)
        {
            object? id_obj = info.GetValue("id", typeof(int));
            if (id_obj != null) id = (int)id_obj;

            object? name_obj = info.GetValue("name", typeof(string));
            if (name_obj != null) name = (string)name_obj;
        }
    }
}