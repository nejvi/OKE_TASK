using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oke_task.Models;

namespace Oke_task.Abstract.interfaces {

	public interface ICountry {
		int Id { get; set; }
		string Name { get; set; }
		string Capitol { get; set; }
		List<Country> Countries { get; set; }
	}

}
