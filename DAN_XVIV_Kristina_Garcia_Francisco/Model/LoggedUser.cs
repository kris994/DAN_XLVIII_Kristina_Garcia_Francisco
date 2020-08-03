namespace DAN_XLVIII_Kristina_Garcia_Francisco.Model
{
    public static class LoggedUser
    {
        private static tblUser currentUser;
        public static tblUser CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
    }
}
