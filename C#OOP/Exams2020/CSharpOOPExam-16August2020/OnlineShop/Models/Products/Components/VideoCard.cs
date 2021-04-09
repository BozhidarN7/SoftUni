﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class VideoCard : Component
    {
        private const double OverallPerformanceModifier = 1.15;
        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }
        public override double OverallPerformance => base.OverallPerformance * OverallPerformanceModifier;
    }
}
