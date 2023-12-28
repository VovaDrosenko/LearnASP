using Microsoft.AspNetCore.Mvc.Rendering;

namespace asd.Models.Entities
{
    public class FilterStudent
    {
            public List<SheetData>? Students { get; set; }
            public SelectList? Filter { get; set; }
            public string? StudentFilter { get; set; }
            public string? SearchName { get; set; }   
    }
}
