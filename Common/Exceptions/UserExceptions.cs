using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public override string Message => "L'utilisateur n'existe pas.";
    }

    public class IncorrectPasswordException: Exception
    {
        public override string Message => "Le mot de passe est incorrect.";
    }
}
