namespace MoviesServiceClient.WPF.ContainerConfiguration
{
    public sealed class ViewName
    {
        private readonly string _name;

        private ViewName(string name)
        {
            this._name = name;
        }

        public override string ToString()
        {
            return _name;
        }

        public static bool operator ==(ViewName left, ViewName right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ViewName left, ViewName right)
        {
            return !Equals(left, right);
        }

        public bool Equals(ViewName other)
        {
            return _name == other._name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ViewName) obj);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public static implicit operator string(ViewName viewName)
        {
            return viewName.ToString();
        }
        
        internal static class Contacts
        {
            public static readonly ViewName ContactList = new ViewName("ContactList");
            public static readonly ViewName EditDetails = new ViewName("EditDetails");
            public static readonly ViewName AddContact = new ViewName("AddContact");
        }

        public static readonly ViewName Settings = new ViewName("Settings");
    }
}