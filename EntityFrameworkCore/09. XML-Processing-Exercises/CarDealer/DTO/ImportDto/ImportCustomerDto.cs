﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.ImportDto
{
    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public string BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public string IsYoungDriver { get; set; }
    }
}
