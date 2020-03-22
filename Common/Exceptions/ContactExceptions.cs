using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public override string Message => "Le contact est introuvable.";
    }
}
