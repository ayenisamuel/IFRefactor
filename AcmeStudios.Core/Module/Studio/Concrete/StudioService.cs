using AcmeStudios.Core.Module.Studio.Dtos;
using AcmeStudios.Core.Module.Studio.Interface;
using AcmeStudios.Models.Data;
using AcmeStudios.Models.Domain.StudioItems;
using AcmeStudios.Models.Domain.StudioItemTypes;
using AcmeStudios.Utilities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AcmeStudios.Core.Module.Studio.Concrete
{
    public class StudioService : IStudioService
    {
        private readonly Cont _contDbContext;
        private readonly ILogger<StudioService> _logger;
        private readonly IMapper _mapper;

        public StudioService(Cont contDbContext, ILogger<StudioService> logger, IMapper mapper)
        {
            _contDbContext = contDbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStudioItemDto>>> AddStudioItem(AddStudioItemDto request)
        {

                var itemAlreadyExist = await _contDbContext.StudioItems.FirstOrDefaultAsync(x => x.Name == request.Name);
                if (itemAlreadyExist != null)
                {
                    return ServiceResponse<List<GetStudioItemDto>>.ErrorMessage(400, $"Studio Item with the name {request.Name}, already exist");
                }

                StudioItem item = _mapper.Map<StudioItem>(request);
                await _contDbContext.StudioItems.AddAsync(item);
                await _contDbContext.SaveChangesAsync();

                var data = await _contDbContext.StudioItems.Select(c => _mapper.Map<GetStudioItemDto>(c)).ToListAsync();

                return ServiceResponse<List<GetStudioItemDto>>.SuccessMessage(message: $"New item added.  Id: {item.StudioItemId}", data: data);
        }

        public async Task<ServiceResponse<List<GetStudioItemHeaderDto>>> GetAllStudioHeaderItems()
        {
                var databaseQuery = await _contDbContext.StudioItems.Select(c => _mapper.Map<GetStudioItemHeaderDto>(c)).ToListAsync();

                return ServiceResponse<List<GetStudioItemHeaderDto>>.SuccessMessage(message: "Here's all the items in your studio", data: databaseQuery);
          
        }

        public async Task<ServiceResponse<GetStudioItemDto>> GetStudioItemById(int id)
        {
                var item = await _contDbContext.StudioItems
                .Where(item => item.StudioItemId == id)
                .Include(type => type.StudioItemType)
                .FirstOrDefaultAsync();

                if (item == null)
                {
                    return ServiceResponse<GetStudioItemDto>.ErrorMessage(400, $"Failed to fetch studio item with Id {id}");
                }

                var data = _mapper.Map<GetStudioItemDto>(item);
                return ServiceResponse<GetStudioItemDto>.SuccessMessage(message: "Here's your selected studio item", data: data);
        }

        public async Task<ServiceResponse<GetStudioItemDto>> UpdateStudioItem(UpdateStudioItemDto request)
        {

                StudioItem studioItem = await _contDbContext.StudioItems
                   .FirstOrDefaultAsync(c => c.StudioItemId == request.StudioItemId);

                if (studioItem == null)
                {
                    return ServiceResponse<GetStudioItemDto>.ErrorMessage(400, $"Failed to update studio item with Id {request.StudioItemId}");
                }

                studioItem.Acquired = request.Acquired;
                studioItem.Description = request.Description;
                studioItem.Eurorack = request.Eurorack;
                studioItem.Name = request.Name;
                studioItem.Price = request.Price;
                studioItem.SerialNumber = request.SerialNumber;
                studioItem.Sold = request.Sold;
                studioItem.SoldFor = request.SoldFor;
                studioItem.StudioItemType = _mapper.Map<StudioItemType>(request.StudioItemType);
                await _contDbContext.SaveChangesAsync();
                var data = _mapper.Map<GetStudioItemDto>(studioItem);
                return ServiceResponse<GetStudioItemDto>.SuccessMessage(message: "Update successful", data: data);
            
        }

        public async Task<ServiceResponse<List<GetStudioItemDto>>> DeleteStudioItem(int id)
        {
           
                StudioItem item = await _contDbContext.StudioItems.FirstAsync(c => c.StudioItemId == id);
                if (item == null)
                {
                    return ServiceResponse<List<GetStudioItemDto>>.ErrorMessage(400, $"Failed to delete studio item with Id {id}");
                }
                _contDbContext.Remove(item);
                await _contDbContext.SaveChangesAsync();
                var data = await _contDbContext.StudioItems.Select(c => _mapper.Map<GetStudioItemDto>(c)).ToListAsync();
                return ServiceResponse<List<GetStudioItemDto>>.SuccessMessage(message: "Item deleted", data: data);
           
        }

        public async Task<ServiceResponse<List<StudioItemTypeDto>>> GetAllStudioItemTypes()
        {
           
                var databaseQuery = await _contDbContext.StudioItemTypes.Select(c => _mapper.Map<StudioItemTypeDto>(c)).OrderBy(s => s.Value).ToListAsync();
                return ServiceResponse<List<StudioItemTypeDto>>.SuccessMessage(message: "Item types fetched", data: databaseQuery);

        }
    }
}
