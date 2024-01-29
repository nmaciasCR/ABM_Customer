using AutoMapper;
using ABM_Customer;
using Microsoft.AspNetCore.Http;

namespace ABM_Customer.Business
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Services.CustomerData, Data.Entities.Customers>()
                .ForMember(dest => dest.created,
                           opt => opt.MapFrom(src => DateTime.ParseExact(src.created_at, "yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind)));
            CreateMap<Data.Entities.Customers, DTO.CustomerDTO>();
        }



    }
}
