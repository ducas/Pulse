using System.Collections.Generic;

namespace Web.Core
{
    public class CreateBusinessEntityResponse
    {
        public CreateBusinessEntityResponse()
        {
            Errors = new List<KeyValuePair<string, string>>();
        }
        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }
    }
}