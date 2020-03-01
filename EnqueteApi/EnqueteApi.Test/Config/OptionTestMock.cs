using EnqueteApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnqueteApi.Test.Config
{
   public static class OptionTestMock
    {
        private static Option CreateOption()
        {
            return new Option()
            {
                Id = 1,                                
                OptionDescription = "Teste 1",
                Count = 0 
            };
        }

        public static Option GetOptionMock()
        {
            return CreateOption();
        }
    }
}
