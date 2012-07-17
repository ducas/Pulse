using System.Collections.Generic;
using Web.Data;

namespace Web.Core
{
    public static class Context
    {
        public static readonly List<BusinessEntity> Entities = new List<BusinessEntity>
            {
                new BusinessEntity{Id = 1, Name = "Test 1", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 2, Name = "Test 2", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 3, Name = "Test 3", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 4, Name = "Test 4", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 5, Name = "Test 5", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 6, Name = "Test 6", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 7, Name = "Test 7", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 8, Name = "Test 8", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 9, Name = "Test 9", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 10, Name = "Test 10", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 11, Name = "Test 11", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 12, Name = "Test 12", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 13, Name = "Test 13", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 14, Name = "Test 14", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 15, Name = "Test 15", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 16, Name = "Test 16", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 17, Name = "Test 17", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 18, Name = "Test 18", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 19, Name = "Test 19", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 20, Name = "Test 20", ShortDescription = "Short", LongDescription = "Long" },
                new BusinessEntity{Id = 11, Name = "Test 21", ShortDescription = "Short", LongDescription = "Long" },
            };
    }
}