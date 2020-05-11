using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json.Linq;
using ParkingLotKata2;
using JsonConvert = Newtonsoft.Json.JsonConvert;


namespace ConsoleApp2
{
    public class ParkingLotSerializer : SerializerBase<Vehicle>
    {
        public override Vehicle Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var serializer = BsonSerializer.LookupSerializer(typeof(BsonDocument));
            var document = serializer.Deserialize(context, args);

            var bsonDocument = document.ToBsonDocument();
            var result = BsonExtensionMethods.ToJson(bsonDocument);
            var jObject = JObject.Parse(result);
            jObject.Remove("_id");
            var documentWithNoId = jObject.ToString();
            //switch (mvnt.GetType().Name)
            //{
            //    case "Tiger":
            //        //your serialization here
            //        break;
            //    case "Zebra":
            //        //your serialization here
            //        break;
            //    default:
            //        break;
            //}
            return JsonConvert.DeserializeObject<Vehicle>(documentWithNoId);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Vehicle value)
        {
            var name = value.GetType().Name;
            var baseTypeName = value.GetType().BaseType?.Name;
            var typesArray = new[] { baseTypeName, name };

            var document = JsonConvert.SerializeObject(value);
            var json = JObject.Parse(document);
            var test = json.First;

            json.Add("_t", JArray.FromObject(typesArray));
            json["_id"] = value.License;

            var bsonDocument = BsonSerializer.Deserialize<BsonDocument>(json.ToString());
            var serializer = BsonSerializer.LookupSerializer(typeof(BsonDocument));
            serializer.Serialize(context, bsonDocument.AsBsonValue);
        }
    }
}
