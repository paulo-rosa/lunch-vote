using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;
using LunchVote.LIB.Services;
using LunchVote.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LunchVote.Tests
{
    public class ProfessionalServiceUnitTest
    {
        [Fact]
        public async void Get_Professionals_ReturnsProfessionalList()
        {
            var professionals = VoteMock.ProfessionalList;
            var mock = new Mock<IProfessionalRepository>();
            IProfessionalService professionalService = new ProfessionalService(mock.Object);
            mock.Setup(p => p.GetProfessionalsAsync()).ReturnsAsync(professionals);

            var result = await professionalService.GetProfessionalsAsync();

            Assert.NotNull(result);

            Assert.Equal("Dev Senior", result.FirstOrDefault().Name);
        }
    }
}
