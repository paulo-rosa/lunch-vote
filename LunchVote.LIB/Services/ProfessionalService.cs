using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;

namespace LunchVote.LIB.Services
{
    public class ProfessionalService : IProfessionalService
    {
        IProfessionalRepository _professionalRepository;

        public ProfessionalService(IProfessionalRepository professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }

        public async Task<List<Professional>> GetProfessionals()
        {
            return await  _professionalRepository.GetProfessionalsAsync();
        }
    }
}
