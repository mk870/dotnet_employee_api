using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentApi.Config
{
    
    public class JwtConfig
    {
        public required string Secret { get; set; }
    }
}