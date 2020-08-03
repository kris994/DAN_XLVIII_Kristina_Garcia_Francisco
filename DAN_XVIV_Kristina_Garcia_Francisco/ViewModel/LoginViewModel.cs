using DAN_XLVIII_Kristina_Garcia_Francisco.Commands;
using DAN_XLVIII_Kristina_Garcia_Francisco.Model;
using DAN_XLVIII_Kristina_Garcia_Francisco.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLVIII_Kristina_Garcia_Francisco.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        Login view;
        Service service = new Service();

        #region Constructor
        public LoginViewModel(Login loginView)
        {
            view = loginView;
            user = new tblUser();
            UserList = service.GetAllUsers().ToList();
        }
        #endregion

        #region Property
        private string infoLabel;
        public string InfoLabel
        {
            get
            {
                return infoLabel;
            }
            set
            {
                infoLabel = value;
                OnPropertyChanged("InfoLabel");
            }
        }

        private tblUser user;
        public tblUser User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private List<tblUser> userList;
        public List<tblUser> UserList
        {
            get
            {
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Command used to log te user into the application
        /// </summary>
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
        }

        /// <summary>
        /// Checks if its possible to login depending on the given username and password and saves the logged in user to a list
        /// </summary>
        /// <param name="obj"></param>
        private void LoginExecute(object obj)
        {
            Helper.Validation validation = new Helper.Validation();
            string password = (obj as PasswordBox).Password;
            if (User.JMBG == validation.JMBGChecker(User.JMBG) && password == "Gost")
            {
                InfoLabel = "Logged in";
                service.AddUser(User);
                UserList.Add(User);

                LoggedUser.CurrentUser = new tblUser
                {
                    UserID = User.UserID,
                    JMBG = User.JMBG
                };

                MainWindow mw = new MainWindow();
                view.Close();
                mw.Show();
            }
            else
            {
                InfoLabel = "Wrong Username or Password";
            }

            if (User.JMBG == "Zaposleni" && password == "Zaposleni")
            {
                Worker worker = new Worker();
                view.Close();
                worker.Show();
            }
        }
        #endregion
    }
}
