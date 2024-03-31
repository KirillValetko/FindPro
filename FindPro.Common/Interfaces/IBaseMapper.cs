using FindPro.Common.Models;

namespace FindPro.Common.Interfaces
{
    public interface IBaseMapper<TLowerLayerModel, TTopLayerModel>
        where TLowerLayerModel : class
        where TTopLayerModel : class
    {
        TTopLayerModel Map(TLowerLayerModel lowerLayerModel);
        TLowerLayerModel Map(TTopLayerModel topLayerModel);
        List<TTopLayerModel> Map(List<TLowerLayerModel> lowerLayerModels);
        List<TLowerLayerModel> Map(List<TTopLayerModel> topLayerModels);
        void Map(TTopLayerModel topLayerModel, TLowerLayerModel lowerLayerModel);
        PaginationResponse<TTopLayerModel> Map(PaginationResponse<TLowerLayerModel> paginationResponse);
    }
}
