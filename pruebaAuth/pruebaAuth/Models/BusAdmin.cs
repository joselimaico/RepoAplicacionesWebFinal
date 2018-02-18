using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
	public static class BusAdmin
	{
		public static string getUserRole(this HtmlHelper html)
		{
			string currentUserRole = "Admin";
			return currentUserRole;
		}

	}
}