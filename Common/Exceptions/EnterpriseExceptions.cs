using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class EnterpriseNotFoundException : Exception
    {
        public override string Message => "L'entreprise n'existe pas.";
    }
}
