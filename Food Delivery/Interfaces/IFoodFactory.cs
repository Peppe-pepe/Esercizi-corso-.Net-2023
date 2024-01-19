﻿using Food_Delivery.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery.Interfaces
{
    internal interface IFoodFactory
    {
        public Order CreateOrder();
    }
}