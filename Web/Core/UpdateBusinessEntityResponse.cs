using System.Collections.Generic;

namespace Web.Core
{
    public class UpdateBusinessEntityResponse
    {
        public UpdateBusinessEntityResponse()
        {
            Errors = new List<KeyValuePair<string, string>>();
        }
        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }
    }
}