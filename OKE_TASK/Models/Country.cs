using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Oke_task.Abstract.interfaces;

namespace Oke_task.Models 
{
	[Serializable]
	[XmlRoot("Countries")]
	[XmlType("Country")]
	public class Country: ICountry {

		[XmlElement("Country")]
		public List<Country> Countries { get; set; }

		[XmlElement("ID")]
		public int Id { get; set; }

		[XmlElement("Name")]
		public string Name { get; set; }

		[XmlElement("Capitol")]
		public string Capitol { get; set; }

	}

}