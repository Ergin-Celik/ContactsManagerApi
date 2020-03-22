using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class PersonNotFoundException: Exception
    {
        public override string Message => "La personne n'existe pas.";
    }

    public class VatNumberRequiredException : Exception
    {
        public override string Message => "Le numéro de TVA est obligatoire pour les indépendants.";
    }
}
