﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
