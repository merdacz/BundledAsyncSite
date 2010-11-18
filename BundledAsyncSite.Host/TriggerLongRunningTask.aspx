<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TriggerLongRunningTask.aspx.cs" Inherits="BundledAsyncSite.Host.TriggerLongRunningTask" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FFormData" runat="server">
    <div>
        <p>
            <asp:Label ID="ExecutionTimeLabel" AssociatedControlID="ExecutionTime" Text="Time to spent: " runat="server" />:
            <asp:TextBox ID="ExecutionTime" runat="server" />
            <asp:RangeValidator 
                ID="ExecutionTimeValidator" 
                ControlToValidate="ExecutionTime"
                Type="Integer" 
                MinimumValue="1" 
                MaximumValue="10000" 
                Display="Dynamic"
                ErrorMessage="Execution time must be integer number between 1 and 10000. "
                runat="server"/>
        </p>
        <p>
        <asp:Button ID="Execute" OnClick="OnExecuteClicked" Text="Execute" runat="server" />
        </p>
    </div>
    </form>
</body>
</html>
