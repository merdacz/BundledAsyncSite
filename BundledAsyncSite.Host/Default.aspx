<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BundledAsyncSite.Host.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Authenticated as <asp:Label ID="LoggedInAs" runat="server" /></h1>
    <ul>
        <li>
            <asp:HyperLink ID="CreateAccountLink" runat="server" NavigateUrl="~/CreateAccount.aspx" Text="Register new account"/>
        </li>
        <li>
            <asp:HyperLink ID="LongRunningTaskLink" runat="server" NavigateUrl="~/TriggerLongRunningTask.aspx" Text="Execute task"/>
        </li>
        <li>

        <asp:MultiView ID="AuthenticationPane" runat="server">
            <asp:View ID="NotAuthenticated" runat="server">
                <asp:TextBox ID="UserName" runat="server" />
                <asp:Button ID="Authenticate" runat="server" OnClick="OnAuthenticate" Text="Authenticate" />
            </asp:View>
            <asp:View ID="Authenticated" runat="server">
                <asp:Button ID="SignOut" runat="server" OnClick="OnSignOut" Text="Sign out" />
            </asp:View>
        </asp:MultiView>

        </li>
    </ul>
    </div>
    </form>
</body>
</html>
