<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearRoles.aspx.cs" Inherits="SistMoropotenteWS.Administrador.Admin.CrearRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <div class="col-md-12">
            </div>
            <div class="col-md-6">
                <h2>Administracion de Rol</h2>
                <div class="col-lg-6">
                    <b>Crear nuevo Rol: </b>
                    <asp:TextBox ID="RoleName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RoleNameReqField" runat="server"
                        ControlToValidate="RoleName" Display="Dynamic"
                        ErrorMessage="Es nesesario el nombre del Rol."></asp:RequiredFieldValidator>

                    <br />
                    <asp:Button ID="CreateRoleButton" runat="server" Text="Crear"
                        OnClick="CreateRoleButton_Click" />
                </div>
            </div>
            <div class="col-md-6">
                <p>
                    <asp:GridView ID="RoleList" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False"
                        OnRowDeleting="RoleList_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="Roles">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </p>
            </div>
       
</asp:Content>
