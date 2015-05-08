<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CloudP3PSA.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>Source</td>
                <td><asp:TextBox ID="txtSource" runat="server" placeholder="Enter Source"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Destination</td>
                <td><asp:TextBox ID="txtDestination" runat="server" placeholder="Enter Destination"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Travel Mode</td>
                <td><asp:DropDownList ID="ddlTravelMode" runat="server">
                    <asp:ListItem>---Select---</asp:ListItem>
                    <asp:ListItem>Driving</asp:ListItem>
                    <asp:ListItem>Walking</asp:ListItem>
                    <asp:ListItem>Bicycling</asp:ListItem>
                    <asp:ListItem>Transit</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblDistance" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lblDistanceValue" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblTimeTaken" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lblTimeTakenValue" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblDestinationTemperature" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="lblDestinationTemperatureValue" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblTimeZoneChange" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
