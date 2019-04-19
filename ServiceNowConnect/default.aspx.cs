using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Dac;

namespace ServiceNowConnect
{
	public partial class _default : System.Web.UI.Page
	{

		string _connstringName = "ServiceNowDBConnectionString";
		string _appConnString = "";
		string _directory = "";
		string _directoryBACPACFolder = "~/install/SQL/bacpac/";
		string _directoryBACPACFile = "ServiceNowConnect.bacpac";
		string _directoryBACPACDBName = "ServiceNowConnectDB";

		protected void Page_Load( object sender , EventArgs e )
		{
			
			try
			{
				
				try
				{
					_appConnString = ConfigurationManager.ConnectionStrings[ _connstringName ].ConnectionString;
				}
				catch
				{
					_appConnString = "Config Connection String " + _connstringName + " not found!";
				}

				try
				{
					_directory = Server.MapPath( _directoryBACPACFolder );
				}
				catch
				{
					_directory = "Directory not found!";
				}

				_lblConnectionString.Text = _appConnString;
				_lblDirectoryPath.Text = _directory;

				_btnRestoreDB.Click += EventHandlerButtonClickRestoreDB;

			}
			catch( Exception ex )
			{
				Response.Write( ex.ToString() );
			}

		}

		private void EventHandlerButtonClickRestoreDB( object sender , EventArgs e )
		{
			
			try
			{
				SQLDBBacPacImportFromFile( DacAzureEdition.Basic , true , _appConnString , _directoryBACPACDBName , _directory + _directoryBACPACFile );
			}
			catch( Exception ex )
			{

				_txtRestoreDBLog.Text = ex.ToString();
					
			}

		}

		private void SQLDBBacPacImportFromFile( DacAzureEdition edition , bool importBlockOnPossibleDataLoss , string importDBConnectionString , string importDBName , string importFileFullPath )
		{

			DacDeployOptions dacOptions = new DacDeployOptions();

			dacOptions.BlockOnPossibleDataLoss = importBlockOnPossibleDataLoss;
			
			DacServices dacServiceInstance = new DacServices( importDBConnectionString );

			// There are two events to get feed back during import.
			//dacServiceInstance.Message += EventHandlerDACMessage;
			//dacServiceInstance.ProgressChanged += EventHandlerDacServiceInstanceProgressChanged;

			using( BacPackage dacpac = BacPackage.Load( importFileFullPath ) )
			{

				DacAzureDatabaseSpecification dbSpec = new DacAzureDatabaseSpecification();

				dbSpec.Edition = edition;

				dacServiceInstance.ImportBacpac( dacpac , importDBName );

				dacpac.Dispose();

			}

		}

		private void EventHandlerDacServiceInstanceProgressChanged( object sender , DacProgressEventArgs e )
		{
			try
			{
				_txtRestoreDBServer.Text += "DAC Progress Changed" + Environment.NewLine;
				_txtRestoreDBServer.Text += "	Status: " + e.Status.ToString();
				_txtRestoreDBServer.Text += "	Message: " + e.Message.ToString();
				_txtRestoreDBServer.Text += "	OperationId: " + e.OperationId.ToString();
				_txtRestoreDBServer.Text += Environment.NewLine;
			}
			catch( Exception ex )
			{
				_txtRestoreDBLog.Text = ex.ToString();
			}
		}

		private void EventHandlerDACMessage( object sender , DacMessageEventArgs e )
		{
			try
			{
				_txtRestoreDBServer.Text += "DAC Message" + Environment.NewLine;
				_txtRestoreDBServer.Text += "	Message: " + e.Message.ToString();
			}
			catch( Exception ex )
			{
				_txtRestoreDBLog.Text = ex.ToString();
			}
		}
	}

}