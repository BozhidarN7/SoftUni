using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class ImportOfficerPrisonerArrayDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
}
