using AutoMapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Batter, BatterSimpleViewModel>();
    }
}