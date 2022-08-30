using AutoMapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<Batter, BatterSimpleViewModel>();
        CreateMap<Batter, BatterEnhancedViewModel>();
        CreateMap<Pitcher, PitcherSimpleViewModel>();
        CreateMap<Pitcher, PitcherEnhancedViewModel>();
    }
}