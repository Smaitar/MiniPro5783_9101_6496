﻿using BlApi;
using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
     public static class Factory
    {
        public static IBL Get()
        {
            return new Bl();
        }
    }
}
