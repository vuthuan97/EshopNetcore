using eShop.ViewModels.Catalog.Common;

namespace eShop.ViewModels.Catalog.Product
{


    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
