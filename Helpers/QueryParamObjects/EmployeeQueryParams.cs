using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.Helpers.QueryParamObjects
{
    public class EmployeeQueryParams
    {
        public string? Department { get; set; } = null;
        public string? Title { get; set; } = null;
    }
}