using CQRSService.Client.Domain.Events;
using CQRSService.Domain.Events;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace CQRSService.Client
{
    [DataContract]
    public class Client : EventSourcedAggregate, ICloneable
    {
        [JsonConstructor]
        private Client() { }

        public Client(string name)
        {
            Name = name;
            Append(new ClientCreated(this));
        }

        public void SetName(string name)
        {
            var before = (Client)Clone();
            Name = name;
            Append(new ClientUpdated(before, this));
        }

        public void Disable()
        {
            IsEnabled = false;
            Append(new ClientRemoved(this));
        }

        public object Clone()
        {
            var client = new Client(Name)
            {
                Id = Id
            };
            return client;
        }

        [JsonProperty]
        public string Name { get; private set; }
    }
}
