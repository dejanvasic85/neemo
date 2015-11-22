using System.Collections.Generic;
using System.Web.Mvc;

namespace Neemo.Web.Models
{
    public interface IPagingModel
    {
        IEnumerable<SelectListItem> PageSizeItems { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        int TotalResultCount { get; set; }
        int TotalPageCount { get; }
        bool HasPages { get; }
    }
}