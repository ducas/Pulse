using System.Collections.Generic;
using Web.Data;

namespace Web.Core
{
    public static class Context
    {
        public static readonly List<BusinessEntity> Entities = new List<BusinessEntity>
            {
                new BusinessEntity{Id = 1, Name = "Test", ShortDescription = "Short", LongDescription = "Long" }
            };
    }
}