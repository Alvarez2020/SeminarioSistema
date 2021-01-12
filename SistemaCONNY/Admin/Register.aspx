<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SistMoropotenteWS.Administrador.Admin.Register" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <%--  <asp:Button ID="btnMRoles" CssClass="btn btn-warning" runat="server" OnClick="btnMRoles_Click" Text="Admionistrar Roles" />--%>

    <div class="white-box">
        <div class="row">
            <div class="panel-body">
                <asp:MultiView ID="MultiViewUser" runat="server">
                    <asp:View ID="ViewCreateUserWizard" runat="server">
                     
                        <div class=" col-md-12 login">
                            <center>  <h3><i class="glyphicon glyphicon-user"></i>Registro de Usuario</h3></center>
                            <div class="row">
                                <h3>Informacion de la cuenta</h3>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" placeholder="Nombre de Usuario" required runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Contraseña" required runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtPasswordCOnfirm" CssClass="form-control" placeholder="Confirmar Contraseña" required runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="DropPregunta" CssClass="form-control" runat="server">
                                            <asp:ListItem>--Seleccione una Pregunta</asp:ListItem>
                                            <asp:ListItem>Comida Favorita</asp:ListItem>
                                            <asp:ListItem>Nombre de Tu Mascota</asp:ListItem>
                                            <asp:ListItem>Equipo Favorito</asp:ListItem>
                                            <asp:ListItem>Fecha de Nacimiento de tu Mama</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtRespuesta" CssClass="form-control" placeholder="Respuesta de Seguridad" required runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox TextMode="Email" ID="txtEmail" CssClass="form-control" placeholder="Correo Electronico" required runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:DropDownList ID="DropRoles" CssClass="form-control" runat="server">
                                            <asp:ListItem>--Seleccione un Rol--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div>
                                        <asp:Button Text="Registrarse" OnClick="btnRegistrarse_Click" CssClass="btn btn-info pull-right" ID="btnRegistrarse" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="ViewVistaUserToRole" runat="server">
                        <div class="col-md-6">
                            <h4>Usuarios Registrados</h4>
                            <asp:GridView ID="UserLists" CssClass="table table-responsive" runat="server" AutoGenerateColumns="False"
                                OnRowDeleting="UserLists_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Usuario">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="UserNameLabel" Text='<%# Container.DataItem %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col-md-6">
                            <h4>Asignar Roles a Usuarios</h4>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <b>Seleccione un Rol:</b>
                                    <asp:DropDownList ID="RoleList" CssClass="form-control" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="RoleList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <b>Usuario:</b>
                                    <asp:TextBox CssClass="form-control" ID="UserNameToAddToRole" runat="server"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="AddUserToRoleButton" CssClass="btn btn-success" runat="server" Text="Agregar Usuario al Rol Seleccionado"
                                        OnClick="AddUserToRoleButton_Click" />
                                </div>
                                <div class="form-group" align="center">
                                    <asp:Label ID="ActionStatus" runat="server" CssClass="dropdown-messages"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <asp:GridView ID="RolesUserList" CssClass="table table-responsive" runat="server" AutoGenerateColumns="False"
                                    EmptyDataText="No hay Usuarios Asignados a un Rol."
                                    OnRowDeleting="RolesUserList_RowDeleting">
                                    <Columns>
                                        <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                                        <asp:TemplateField HeaderText="Usuarios">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="UserNameLabel" Text='<%# Container.DataItem %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>
