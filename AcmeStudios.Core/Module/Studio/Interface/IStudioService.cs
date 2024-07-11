using AcmeStudios.Core.Module.Studio.Dtos;
using AcmeStudios.Utilities;

namespace AcmeStudios.Core.Module.Studio.Interface
{
    public interface IStudioService
    {
        Task<ServiceResponse<List<GetStudioItemDto>>> AddStudioItem(AddStudioItemDto request);
        Task<ServiceResponse<List<GetStudioItemDto>>> DeleteStudioItem(int id);
        Task<ServiceResponse<List<GetStudioItemHeaderDto>>> GetAllStudioHeaderItems();
        Task<ServiceResponse<List<StudioItemTypeDto>>> GetAllStudioItemTypes();
        Task<ServiceResponse<GetStudioItemDto>> GetStudioItemById(int id);
        Task<ServiceResponse<GetStudioItemDto>> UpdateStudioItem(UpdateStudioItemDto request);
    }
}