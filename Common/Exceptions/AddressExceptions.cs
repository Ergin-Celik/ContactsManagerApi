﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public override string Message => "L'addresse n'existe pas.";
    }
}
