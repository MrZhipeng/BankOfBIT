<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTransaction.aspx.cs" Inherits="OnlineBanking.CreateTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblAccountNumber" runat="server" Text="Account Number:  "></asp:Label>
        <asp:Label ID="lblAccountNumberValue" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblBalance" runat="server" Text="Balance:  "></asp:Label>
        <asp:Label ID="lblBalanceValue" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblTransactionType" runat="server" Text="Transaction Type: "></asp:Label>
        <asp:DropDownList ID="ddlTransactionType" runat="server" OnSelectedIndexChanged="ddlTransactionType_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblAmount" runat="server" Text="Amount: "></asp:Label>
        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount is Required"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="lblTo" runat="server" Text="To: "></asp:Label>
        <asp:DropDownList ID="ddlTo" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        <asp:LinkButton ID="lbtnCompleteTransaction" runat="server" OnClick="lbtnCompleteTransaction_Click">Complete Transaction</asp:LinkButton>
        <asp:LinkButton ID="lbtnReturnToAccountListing" runat="server" OnClick="lbtnReturnToAccountListing_Click">Return to Account Listing</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="lblException" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
