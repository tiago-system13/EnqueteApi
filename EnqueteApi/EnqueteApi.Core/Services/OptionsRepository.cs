using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Core.Services.Interfaces;
using System;

namespace EnqueteApi.Core.Services
{
    public class OptionsRepository: IOptionsService
    {
        private readonly IOptionsRepository _optionsRepository;

        public OptionsRepository(IOptionsRepository optionsRepository)
        {
            _optionsRepository = optionsRepository;
        }

        public void Update(Option option)
        {
            throw new NotImplementedException();
        }
    }
}
