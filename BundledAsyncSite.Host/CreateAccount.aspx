<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="BundledAsyncSite.Host.CreateAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormData" runat="server">
    <div>
        <p>
            <asp:Label ID="UserNameLabel" AssociatedControlID="UserName" Text="User name:" runat="server" />
            <asp:TextBox ID="UserName" runat="server" />
        </p>
        <p>
            <asp:Label ID="EmailLabel" AssociatedControlID="Email" Text="Email:" runat="server" />
            <asp:TextBox ID="Email" runat="server" />
        </p>
        <p>
        <asp:Button ID="Register" OnClick="OnRegisterClicked" Text="Register" runat="server" />
        </p>
    </div>
    </form>
</body>
</html>
