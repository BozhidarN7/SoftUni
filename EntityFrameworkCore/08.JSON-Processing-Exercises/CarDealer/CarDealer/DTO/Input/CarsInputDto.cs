using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Input
{
    public class CarsInputDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public long TravelledDistance { get; set; }
        public int[] PartsId { get; set; }

    }
}
