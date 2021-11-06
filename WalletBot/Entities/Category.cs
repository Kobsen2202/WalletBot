using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletBot.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public OperationType Type { get; set; }
        [JsonIgnore]
        public AppUser User { get; set; }
        public long? UserId { get; set; }
    }
}
