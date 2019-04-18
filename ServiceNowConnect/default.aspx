<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ServiceNowConnect._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			DB Connection Read From Azure Configuration of the Web App/SQL Server and SQL DB that was dynamically generated during the deployment.
			<br /><br />
			&nbsp;&nbsp;&nbsp;&nbsp;<strong>Connection String:</strong><asp:Label ID="_lblConnectionString" runat="server"></asp:Label>
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
    </form>
</body>
</html>
