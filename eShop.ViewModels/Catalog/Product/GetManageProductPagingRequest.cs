using eShop.ViewModels.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShop.ViewModels.Catalog.Product
{
   public class GetManageProductPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
