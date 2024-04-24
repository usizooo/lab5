using ComputerClub.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ComputerClub
{
    public class AdminConverter : JsonCreationConverter<Admin>
    {
        protected override Admin Create(Type objectType, JObject jObject)
        {
            var login = (jObject["Login"] ?? throw new ArgumentNullException()).Value<string>()
                ?? throw new ArgumentNullException();
            var password = (jObject["Password"] ?? throw new ArgumentNullException()).Value<string>()
                ?? throw new ArgumentNullException();

            Type[] constructorParams = { typeof(string), typeof(string) };
            ConstructorInfo constructor = typeof(Admin)
                .GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic, 
                    null,
                    constructorParams, 
                    null);

            if (constructor == null)
            {
                throw new MissingMethodException($"Type {typeof(Admin).FullName} does not have a private parameterless constructor.");
            }

            return (Admin)constructor.Invoke(new object[] {login, password});
        }
    }

    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T) == objectType;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            try
            {
                var jObject = JObject.Load(reader);
                var target = Create(objectType, jObject) ?? throw new ArgumentNullException();
                serializer.Populate(jObject.CreateReader(), target);
                return target;
            }
            catch (JsonReaderException)
            {
                throw new ArgumentException();
            }
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
