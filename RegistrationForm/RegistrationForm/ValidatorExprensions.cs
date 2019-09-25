using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegistrationForm
{
    public static class ValidatorExprensions
    {
        public static bool IsValidEmail(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+)((\.(\w){2,3})+)$");

            return regex.IsMatch(s);
        }
    }
}
