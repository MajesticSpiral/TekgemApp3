using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekgemApp
{
	using System.Collections.Generic;

	public interface ICityResult
	{   
		ICollection<string> NextLetters { get; set; }

		ICollection<string> NextCities { get; set; }
	}
}

namespace TekgemApp
{
	public interface ICityFinder
	{
		ICityResult Search(string searchString);
	}
}
