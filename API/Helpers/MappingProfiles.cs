using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<Order, OrderShortInfo>()
            //    .ForMember(d => d.OrderId, o => o.MapFrom(s => s.OrderId))
            //    .ForMember(d => d.CustomerNumber, o => o.MapFrom(s => s.CustomerName))
            //    .ForMember(d => d.ObjectAddress, o => o.MapFrom(s => s.OrderObjectDetails.ObjectAddres))
            //    .ForMember(d => d.Time, o => o.MapFrom(x => x.OrderObjectDetails.CleaningDate))
            //    .ForMember(d => d.Status, o => o.MapFrom(x => x.OrderDescription.Status.ToString()))
            //    .ForMember(d => d.Price, o => o.MapFrom(x => x.Price));
        }
    }
}
