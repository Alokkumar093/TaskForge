using AutoMapper;

namespace TaskForge.Application.Common.Mappings;

/// <summary>
/// AutoMapper profiles. After scaffold, map EF entities from Persistence layer to Application DTOs here.
/// </summary>
public sealed class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        // Example after scaffold:
        // CreateMap<Project, ProjectDto>();
    }
}
