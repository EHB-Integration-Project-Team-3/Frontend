using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Integration_Project.Extensions {
    public static class ModelHelper<T> {
        public static byte[] ObjectToByteArray(object obj) {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream()) {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T ObjectFromByteArray(byte[] bytes) {
            var binaryFormatter = new BinaryFormatter();
            using (var ms = new MemoryStream(bytes)) {
                object obj = binaryFormatter.Deserialize(ms);
                return (T) obj;
            }
        }
    }
}
