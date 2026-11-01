namespace AMSPROJECT
{
    public sealed class UserSession
    {
        private static readonly UserSession instance = new UserSession();

        private int _userId;
        private string userRole;
        private string _userName;

        private UserSession() { }

        public static UserSession Instance => instance;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string AccessRole
        {
            get { return userRole; }
            set { userRole = value; }
        }

    }
}
