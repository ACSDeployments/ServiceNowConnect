using System;
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
				//Get ConnectionString
				string connstringName = "SQLAZURECONNSTRING_ServiceNowDBConnectionString";
				string envConnString = "";
				string appConnString = "";

				try
				{
					envConnString = Environment.GetEnvironmentVariable( connstringName );
				}
				catch
				{
					envConnString = "Environment Variable " + connstringName + " not found!";
				}

				try
				{
					appConnString = ConfigurationManager.ConnectionStrings[ connstringName ].ConnectionString;
				}
				catch
				{
					appConnString = "Config Connection String " + connstringName + " not found!";
				}

				Response.Write( "Connection String With Environment Variable " + connstringName + " : " + envConnString + "</br></br>" );

				Response.Write( "Connection String With Web.Config Connection String " + connstringName + " : " + appConnString + "</br></br>" );



			}
			catch( Exception ex )
			{
				Response.Write( ex.ToString() );
			}
		}
	}
}