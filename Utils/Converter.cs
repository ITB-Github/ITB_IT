using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Utils
{
    public class Converter
    {

        public static T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T DeserializeJsonWithKey<T>(string json, string key)
        {
            try
            {
                JObject jo = JObject.Parse(json);
                var item = jo.SelectToken(key);
                return item.ToObject<T>();
            }
            catch
            {
                return default(T);
            }
            
        }
        public static List<T> DeserializeJsonToList<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static List<T> DeserializeJsonToListWithKey<T>(string json, string key)
        {
            try
            {
                JObject jo = JObject.Parse(json);
                var item = jo.SelectToken(key);
                return item.ToObject<List<T>>();
            }
            catch
            {
                return default(List<T>);
            }
        }

        public static byte[] FromBitmapToBytes(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        public static string FromBytesToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] FromBase64ToBytes(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public static Bitmap FromBytesToBitmap(byte[] bytes)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(bytes))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }
    }
}
