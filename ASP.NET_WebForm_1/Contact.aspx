<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ASP.NET_WebForm_1.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="LblTitle" runat="server" CssClass="fs-4 fw-bold"></asp:Label>

    <div class="mb-3">
        <label class="form-label">Full Name</label>
        <asp:TextBox ID="TxtFullName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label class="form-label">Departments</label>
        <asp:DropDownList ID="DdlDepartments" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label class="form-label">Salary</label>
        <asp:TextBox ID="TxtSalary" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
    </div>
    <div class="mb-3">
        <label class="form-label">Contract Date</label>
        <asp:TextBox ID="TxtContractDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <asp:Button ID="BtnSubmit" runat="server" Text="Send" CssClass="btn btn-sm btn-primary" OnClick="BtnSubmit_Click"/>
    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-warning">Back</asp:LinkButton>

</asp:Content>
