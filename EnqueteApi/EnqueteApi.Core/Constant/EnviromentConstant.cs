using System;
using System.Collections.Generic;
using System.Text;

namespace EnqueteApi.Core.Constant
{
    public static class EnviromentConstant
    {
        public static readonly string DATABASE_CONNECTION_STRING = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
    }
}
