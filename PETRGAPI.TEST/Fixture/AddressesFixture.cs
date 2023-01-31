using petrgAPI.Data.Dto.AddressDto;
using petrgAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrgAPITest.Fixture
{
    static class AddressesFixture
    {
        public static List<ReadAddressDto> GetAddressesTest() => new()
        {
            new ReadAddressDto
            {
                City = "teste 1", Country = "Teste 2", State = "Teste 3", Street = "teste 4"
            },
            new ReadAddressDto
            {
                City = "ABC", Country = "AAA 2", State = "aSDAS 3", Street = "ASDASDD 4"
            },
            new ReadAddressDto
            {
                City = "teste 1", Country = "Strasdasd 2", State = "Teste 3", Street = "teste 4"
            }
        };
    }
}
