using System.Collections.Generic;
using System.Windows.Media;

namespace MoviesServiceClient.WPF.Controls
{
    public class NavigationContext
    {
        private readonly Dictionary<string, object> _parameters;

        public Dictionary<string, object> Parameters
        {
            get { return _parameters; }
            set
            {
                if (value == null)
                    return;

                foreach (var kp in value)
                {
                    _parameters.Add(kp.Key, kp.Value);
                }
            }
        }

        public NavigationContext()
        {
            _parameters = new Dictionary<string, object>();
        }
    }
}