﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_CW2
{
    class OverFillException : Exception
    {
        public OverFillException(string msg): base(msg) { }
    }
}
