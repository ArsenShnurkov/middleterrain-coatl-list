using System;

namespace middleterraincoatllist
{
	public class CompanyInfo
	{
		public int? Id{ get; set; }
		public string Name{ get; set; }
		public string Url{ get; set; }
		public string Description{ get; set; }

		public CompanyInfo ()
		{
			Id = null;
		}
	}
}

