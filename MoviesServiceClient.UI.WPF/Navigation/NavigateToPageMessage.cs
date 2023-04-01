using System.Collections.Generic;

namespace MoviesServiceClient.WPF.Navigation
{
    public class NavigateToPageMessage
    {
        public string Page { get; set; }
        
        public Dictionary<string, object> Parameters { get; set; }
    }
}