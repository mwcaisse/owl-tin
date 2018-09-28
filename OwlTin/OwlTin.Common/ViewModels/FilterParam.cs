using System;
using System.Collections.Generic;
using System.Text;
using Mitchell.Common.Enums;

namespace Mitchell.Common.ViewModels
{
    public class FilterParam
    {

        public string ColumnName { get; set; }

        public FilterOperation Operation { get; set; }

        public string Value { get; set; }

    }
}
