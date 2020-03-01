using EnqueteApi.Core.Entity;
using EnqueteApi.Core.Interfaces;
using EnqueteApi.Core.Services.Interfaces;
using System;

namespace EnqueteApi.Core.Services
{
    public class OptionsService: IOptionsService
    {
        private readonly IOptionsRepository _optionsRepository;

        public OptionsService(IOptionsRepository optionsRepository)
        {
            _optionsRepository = optionsRepository;
        }

        public Option Update(Option option)
        {
            var optionDb = _optionsRepository.GetbyId(option.Id);

            if (optionDb == null)
            {
                throw new ArgumentException("Opção não encontrada!");
            }

            optionDb.Count = CalculateVote(option);

           return _optionsRepository.Update(optionDb);
        }

        private int CalculateVote(Option option)
        {
            return (int)option.Count + 1;
        }
    }
}
