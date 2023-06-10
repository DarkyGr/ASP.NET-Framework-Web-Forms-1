<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP.NET_WebForm_1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-12">

            <asp:Button runat="server" OnClick="New_Click" CssClass="btn btn-sm btn-success" Text="New" />

            <asp:GridView ID="GVEmployee" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="employeeName" HeaderText="Full Name"/>
                    <asp:BoundField DataField="department.departmentName" HeaderText="Department Name"/>
                    <asp:BoundField DataField="salary" HeaderText="Salary"/>
                    <asp:BoundField DataField="contractDate" HeaderText="Contract Date"/>                    

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("employeeId") %>'
                                OnClick="Edit_Click" CssClass="btn btn-sm btn-primary">Edit</asp:LinkButton>

                            <asp:LinkButton runat="server" CommandArgument='<%# Eval("employeeId") %>'
                                OnClick="Delete_Click" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Are you sure to delete this employee?')"
                                >Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>


            </asp:GridView>

        </div>
    </div>

</asp:Content>
