<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ServiceNowConnect._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		<br /><br /><br />
		<div align="center">
		<fieldset style="width:500px;">
			<legend>ServiceNow Connect Setup - <strong>Step 1</strong></legend>
			<br /><br />
			<div>
			<asp:Label ID="_lblLicenseKey" runat="server" Text="License Key:" Font-Bold="true"></asp:Label>	: <asp:TextBox ID="_txtLicenseKey" runat="server"></asp:TextBox>
			<br /><br /><br />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="_btnRestoreDB" runat="server" Text="Next (Actually restores DB from bacpac)" />
			<br /><br />

		</div>
		</fieldset>
			</div>
		<br /><br /><br />
        <div style="visibility:hidden;">
			DB Connection Read From Azure Configuration of the Web App/SQL Server and SQL DB that was dynamically generated during the deployment.
			<br /><br />
			&nbsp;&nbsp;&nbsp;&nbsp;<strong>Connection String:</strong><asp:Label ID="_lblConnectionString" runat="server"></asp:Label>
			<br />
			<br />
			<br /><br />
			&nbsp;&nbsp;&nbsp;&nbsp;<strong>Directory Path:</strong><asp:Label ID="_lblDirectoryPath" runat="server"></asp:Label>
			<br />
			<br />
			<strong>Next Steps</strong>
			<br /><br />
			&nbsp;&nbsp;&nbsp;&nbsp;1. Check if there are no tables. If not, this is a new setup.
			<br />
			&nbsp;&nbsp;&nbsp;&nbsp;2. Restore/Run SQL Script to populate initial database. Can you restore a bacpac from disk with code?
			<br />
			&nbsp;&nbsp;&nbsp;&nbsp;3. Provide user with Setup/Configuration of Azure keys, ServiceNow API information, etc.
			<br />
			&nbsp;&nbsp;&nbsp;&nbsp;4. Start the WebJob?
			<br />
        </div>
		<br /><br />
		<strong>Database Restore Steps</strong>
		<br /><br />
		DB Server: <asp:TextBox ID="_txtRestoreDBServer" runat="server"></asp:TextBox>
		<br />
		DB Server Login: <asp:TextBox ID="_txtRestoreDBServerLogin" runat="server"></asp:TextBox>
		<br />
		DB Server Password: <asp:TextBox ID="_txtRestoreDBServerPassword" runat="server"></asp:TextBox>
		<br />
		
		<asp:TextBox ID="_txtRestoreDBLog" TextMode="MultiLine" runat="server" Width="700" Height="250"></asp:TextBox>
    </form>
</body>
</html>
