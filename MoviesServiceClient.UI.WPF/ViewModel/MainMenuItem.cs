using MoviesServiceClient.WPF.ContainerConfiguration;

namespace MoviesServiceClient.WPF.ViewModel
{
    public class MainMenuItem
    {
        public string Group { get; set; }
        public object GroupIcon { get; set; }
        public string Title { get; set; }
        public ViewName ViewName { get; set; }
        public object Icon { get; set; }
    }
}