namespace CSWinFormSingleInstanceApp
{
    public class GlobleData
    {
        private static bool isUserLoggedIn;

        public static bool IsUserLoggedIn
        {
            get { return GlobleData.isUserLoggedIn; }
            set { GlobleData.isUserLoggedIn = value; }
        }

        private static string userName;

        public static string UserName
        {
            get { return GlobleData.userName; }
            set { GlobleData.userName = value; }
        }
    }
}