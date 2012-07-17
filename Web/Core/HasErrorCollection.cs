using System.Collections.Generic;

namespace Web.Core
{
    public abstract class HasErrorCollection
    {
        protected HasErrorCollection()
        {
            Errors = new List<KeyValuePair<string, string>>();
        }

        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }
    }
}