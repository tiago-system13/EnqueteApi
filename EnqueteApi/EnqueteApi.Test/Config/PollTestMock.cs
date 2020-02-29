using EnqueteApi.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnqueteApi.Test.Config
{
  public static class PollTestMock
    {
        private static Poll CreatePoll()
        {
            return new Poll()
            {
                Id = 1,
                PollDescription = "",
                Options = new List<Option>()
                {
                    new Option()
                    {
                        Id = 1,
                        OptionDescription = "Teste 1"
                    }                   
                }                
            };
        }

        public static Poll GetPollMock()
        {
            return CreatePoll();
        }  
    }
}
