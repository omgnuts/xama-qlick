using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace api.Controllers.Common
{
    abstract class AbstractJsonContractResolver : DefaultContractResolver
    {
        protected Dictionary<string, string> PropertyMappings { get; set; }

        protected override string ResolvePropertyName(string propertyName)
        {
            string resolvedName;
            bool resolved = PropertyMappings.TryGetValue(propertyName, out resolvedName);
            return (resolved) ? resolvedName : base.ResolvePropertyName(propertyName);
        }
    }

    class JsonContractResolver : AbstractJsonContractResolver
    {
        public JsonContractResolver()
        {
            PropertyMappings = new Dictionary<string, string>
            {
                { "TaskID", "task_id" },
                { "Title", "title" },
                { "Description", "descr" },
                { "UserID", "user_id" },
                { "CreatedDT", "created_dt" },
                { "DueDT", "due_dt" },
                { "Priority", "priority" },
                { "Platform", "platform" }
            };
        }
    }
}
