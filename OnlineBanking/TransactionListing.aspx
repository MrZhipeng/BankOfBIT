<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TransactionListing.aspx.cs" Inherits="OnlineBanking.TransactionListing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="lblClientName" runat="server" Font-Bold="True" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblAccountNumber" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblAccountNumberValue" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblBalance" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="lblBalanceValue" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="gvTransactionList" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="DateCreated" HeaderText="Date" DataFormatString="{0:d}">
                <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TransactionType.Description" HeaderText="Transaction Type">
                <ItemStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="Deposit" DataFormatString="{0:c}" HeaderText="Amount In">
                <ItemStyle HorizontalAlign="Right" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Withdrawal" DataFormatString="{0:c}" HeaderText="Amount Out">
                <ItemStyle HorizontalAlign="Right" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Notes" HeaderText="Details">
                <ItemStyle Width="400px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </p>
    <p>
        <asp:LinkButton ID="lbtnTransaction" runat="server" OnClick="lbtnTransaction_Click">Pay Bills and Transfer Funds</asp:LinkButton>
        <asp:LinkButton ID="lbtnAccountListing" runat="server" OnClick="lbtnAccountListing_Click">Return to Account Listing</asp:LinkButton>
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
</asp:Content>
