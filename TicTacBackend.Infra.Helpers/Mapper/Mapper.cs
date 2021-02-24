using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Infra.Helpers.Mapper
{
    public static class Mapper
    {
        public static Target MapTo<Target>(object source)
        {
            var sourceJson = JsonConvert.SerializeObject(source, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All });

            return JsonConvert.DeserializeObject<Target>(sourceJson);
        }

    }
}
