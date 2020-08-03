using DAN_XLVIII_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DAN_XLVIII_Kristina_Garcia_Francisco.Helper
{
    /// <summary>
    /// Converts the input values to another needed in the models
    /// </summary>
    class Validation
    {
        /// <summary>
        /// Calculates the date of birth for the given jmbg
        /// </summary>
        /// <param name="jmbg">given jmbg</param>
        /// <returns>the date of birth</returns>
        public DateTime CountDateOfBirth(string jmbg)
        {
            DateTime dt = default(DateTime);

            // Get the date of birth
            if (jmbg[4] == '0')
            {
                string date = jmbg.Substring(0, 2) + "/" + jmbg.Substring(2, 2) + "/" + "2" + jmbg.Substring(4, 3);
                try
                {
                    dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                catch (FormatException)
                {
                    dt = default(DateTime);
                    return dt;
                }
            }
            if (jmbg[4] == '9')
            {
                string date = jmbg.Substring(0, 2) + "/" + jmbg.Substring(2, 2) + "/" + "1" + jmbg.Substring(4, 3);
                try
                {
                    dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                catch (FormatException)
                {
                    dt = default(DateTime);
                    return dt;
                }
            }
            return dt;
        }

        /// <summary>
        /// Checks if the jmbg is correct
        /// </summary>
        /// <param name="jmbg">the jmbg we are checking</param>
        /// <returns>jmbg if the input is correct or null if its wrong</returns>
        public string JMBGChecker(string jmbg)
        {
            Service service = new Service();

            List<tblUser> AllUsers = service.GetAllUsers();
            DateTime dt = default(DateTime);

            if (jmbg == null)
            {
                return null;
            }

            if (!(jmbg.Length == 13))
            {
                return null;
            }

            // Get date
            dt = CountDateOfBirth(jmbg);

            if (dt == default(DateTime))
            {
                return null;
            }

            return jmbg;
        }
        /// <summary>
        /// Valid positive int input
        /// </summary>
        public string ValidPositiveNumber(int number)
        {
            bool b = Int32.TryParse(number.ToString(), out number);
            while (!b || number < 0)
            {
                return "Not a valid number";
            }
            return null;
        }

        /// <summary>
        /// The input cannot be empty
        /// </summary>
        /// <param name="name">name of the input</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string CannotBeEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Cannot be empty";
            }
            else
            {
                return null;
            }
        }
    }
}
