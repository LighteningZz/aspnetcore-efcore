using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_efcore.Models.Api.Corp
{
    public partial class Field
    {
        public class Corp
        {
            public string CORP_ID { get; set; }
            public string CORP_CODE { get; set; }
            public string CORP_NAME { get; set; }
        }

        public class Filter
        {
            public string SEARCH { get; set; }
        }

    }
}
