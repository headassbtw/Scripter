using System;
using IPA.Config.Data;
using IPA.Config.Stores;
using IPA.Config.Stores.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Scripter.OS;

namespace Scripter.Configuration
{
    /*
    public class ScriptTypeConversion : ValueConverter<Script.Script>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Script.Script c = (Script.Script)value;
            string a = c.Type.ToString();
            var objValue = new {c.Path, a, c.GameLoad, c.GameExit};
            serializer.Serialize(writer, objValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return new Script.Script("");
            }
            else
            {
                JObject obj = JObject.Load(reader);
                //(string, string, bool, bool) tmps = (obj["Path"].ToString(), obj["Type"].ToString(), bool.Parse(obj["GameLoad"].ToString()), bool.Parse(obj["GameExit"].ToString()));
                Script.Script tmp = new Script.Script("");
                tmp.Path = obj["Path"].ToString();
                tmp.Type = (ScriptInterface.ScriptType)Enum.Parse(typeof(ScriptInterface.ScriptType), obj["Type"].ToString());
                tmp.GameLoad = bool.Parse(obj["GameLoad"].ToString());
                tmp.GameExit = bool.Parse(obj["GameExit"].ToString());

                return tmp;
            }
        }

        public override Value ToValue(Script.Script obj, object parent)
        {
            Value.Text()
            return ("string", "bool");
        }

        public override Script.Script FromValue(Value value, object parent)
        {
            throw new NotImplementedException();
        }
    }
    */
}