using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.Domain.Enum
{
	public enum StatusCode
	{
		Ok = 200,
		CharacterNotFound = 404,
		ScenesAreAbsent = 410,//Номер не соответсвует
		InternalServerError = 500
	}
}
