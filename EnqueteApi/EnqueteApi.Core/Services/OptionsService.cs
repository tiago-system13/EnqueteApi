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

        public Option Update(int id)
        {
            var optionDb = _optionsRepository.GetbyId(id);

            if (optionDb == null)
            {
                throw new ArgumentException("Opção não encontrada!");
            }

            var optionOld = new Option(optionDb);

            optionDb.Count = CalculateVote(optionDb);

           return _optionsRepository.Update(optionDb, optionOld);
        }

        private int CalculateVote(Option option)
        {
            
            return option.Count == null ? 0 : (int)option.Count + 1;
        }
    }
}
