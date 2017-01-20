using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using Oke_task.Abstract.interfaces;
using Oke_task.Models;

namespace Oke_task.Helpers {

	public class XMLReader {
		readonly Country _model;

		static readonly string __path = HttpContext.Current.Server.MapPath("~/App_Data/xml/countries2.xml");
		readonly XmlSerializer _xmlSerializer;
		StreamReader _reader;

		public XMLReader(Country model) {
			this._model = model;
			_xmlSerializer = new XmlSerializer(typeof(Country));
		}

		public void Writer() {
			var doc = XDocument.Load(__path);
			var country = doc.Element("Countries");
			var count = doc.Descendants("ID").Count();
			country?.Add(new XElement("Country",
									new XElement("ID", count + 1),
									new XElement("Name", _model.Name),
									new XElement("Capitol", _model.Capitol)));
			doc.Save(__path);
		}

		public Country Reader() {
			_reader = new StreamReader(__path);
			var model = (Country)_xmlSerializer.Deserialize(_reader);
			_reader.Close();
			return model;
		}

		public Country ReturnListofCountries() {
			_reader = new StreamReader(__path);
			var result = (Country)_xmlSerializer.Deserialize(_reader);
			_reader.Close();
			return result;
		}

		public Country ReturnSpecificCountry() {
			_reader = new StreamReader(__path);
			var result = (Country)_xmlSerializer.Deserialize(_reader);
			var specificCountry = (Country) result.Countries.FirstOrDefault(t => t.Id == _model.Id);
			_reader.Close();
			return specificCountry;
		}
	}

}
