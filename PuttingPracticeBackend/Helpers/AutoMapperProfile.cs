using AutoMapper;
using PuttingPracticeBackend.Models;

namespace PuttingPracticeBackend.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    switch (prop)
                    {
                        case null:
                        case string arg3 when string.IsNullOrEmpty(arg3):
                            return false;
                        default:
                            return true;
                    }
                }));
    }
}