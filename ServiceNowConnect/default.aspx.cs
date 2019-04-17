﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceNowConnect
{
	public partial class _default : System.Web.UI.Page
	{
		protected void Page_Load( object sender , EventArgs e )
		{
			try
			{
				Response.Write( "Connection String: " + Environment.GetEnvironmentVariable( "ServiceNowConnectConnectionString" ) );
			}
			catch( Exception ex )
			{
				Response.Write( ex.ToString() );
			}
		}
	}
}