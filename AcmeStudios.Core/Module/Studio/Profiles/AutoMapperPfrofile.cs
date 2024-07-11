using AcmeStudios.Core.Module.Studio.Dtos;
using AcmeStudios.Models.Domain.StudioItems;
using AcmeStudios.Models.Domain.StudioItemTypes;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeStudios.Core.Module.Studio.Profiles
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudioItem, GetStudioItemDto>();
            CreateMap<AddStudioItemDto, StudioItem>();
            CreateMap<StudioItem, GetStudioItemHeaderDto>();
            CreateMap<StudioItemType, StudioItemTypeDto>();
        }
    }
}
