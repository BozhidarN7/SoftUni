﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;
        private readonly bool inclusive;
        public MyRangeAttribute(int minValue, int maxValue, bool inclusive = false)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.inclusive = inclusive;
        }
        public override bool IsValid(object obj)
        {
            int number = (int)obj;
            if (inclusive)
            {
                return number >= minValue && number <= maxValue;
            }
            return number > minValue && number < maxValue;
        }
    }
}
