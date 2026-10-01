using System.Collections.Generic;

namespace TopuClient.Models
{
    public class ModSearchResponse
    {
        public List<ModResult> Hits { get; set; } = new();
    }

    public class ModResult
    {
        public string ProjectId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public List<string> Versions { get; set; } = new();
    }
}
