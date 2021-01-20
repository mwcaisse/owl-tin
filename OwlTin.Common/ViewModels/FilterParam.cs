using System;
using System.Collections.Generic;
using System.Text;
using OwlTin.Common.Enums;

namespace OwlTin.Common.ViewModels
{
    public class FilterParam
    {

        public string ColumnName { get; set; }

        public FilterOperation Operation { get; set; }

        public string Value { get; set; }

    }
}
