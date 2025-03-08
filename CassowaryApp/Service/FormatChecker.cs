using System.Text.RegularExpressions;

namespace CassowaryApp.Service
{
    public static class FormatChecker
    {
        public static bool validateMail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return true;
            }

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            bool isValid = regex.IsMatch(email);
            return isValid;
        }

        public static bool validatePhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return true;
            }
            var phonePattern = @"^(?:\+7|8)\d{10}$";
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(phone, phonePattern);
            return isValid;
        }

        public static bool isDateValid(string mm, string yy)
        {
            if (!int.TryParse(mm, out int month) || !int.TryParse(yy, out int year))
                return false;
            if (month < 1 || month > 12)
                return false;

            return true;
        }

        public static bool isCvcValid(string cvc)
        {
            return Regex.IsMatch(cvc, @"^\d{3}$");
        }

        public static bool isNumValid(string number)
        {
            string cleanedNumber = Regex.Replace(number, @"[^\d]", "");

            if (cleanedNumber.Length != 16)
                return false;
            else return true;
        }
    }
}
