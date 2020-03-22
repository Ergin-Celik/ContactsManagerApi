using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class EmploymentStatusNotFound: Exception
    {
        public override string Message => "Le status de la personne n'existe pas.";
    }
}
