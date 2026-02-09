<%@ Page Title="Persona" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Persona.aspx.vb" Inherits="PERSONA.Persona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--nombre--%>
    <div>
        <asp:Label ID="LblNombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" Text="" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
    </div>
    <%--apellido--%>
    <div>
        <asp:Label ID="LblApellido" runat="server" Text="Apellido:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtApellido" runat="server" placeholder="Apellido" CssClass="form-control"></asp:TextBox>
    </div>
    <%--fechaNacimiento--%>
    <div>
        <asp:Label ID="LblfechaNacimiento" runat="server" Text="Fecha Nacimiento:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtfechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <%--Validar fecha de nacimiento--%>
    <asp:RequiredFieldValidator ID="RfvFecha" runat="server"
        CssClass="text-danger"
        ControlToValidate="TxtfechaNacimiento"
        ErrorMessage="Es necesario indicar la fecha"></asp:RequiredFieldValidator>
    <%--correo--%>
    <div>
        <asp:Label ID="Lblcorreo" runat="server" Text="Correo:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtCorreo" runat="server" placeholder="Correo" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
    </div>
    <%--tipoDocumento--%>
    <asp:Label ID="LblTipoDoc" runat="server" Text="Tipo de Documento:" CssClass="control-label"></asp:Label>
    <asp:DropDownList ID="DdlTipoDocumento" runat="server" CssClass="form-control">
        <asp:ListItem Text="Cedula Juridica" Value="0"></asp:ListItem>
        <asp:ListItem Text="Cedula Fisica" Value="1"></asp:ListItem>
        <asp:ListItem Text="Pasaporte" Value="2"></asp:ListItem>
    </asp:DropDownList>
    <%--Numero Documento--%>
    <div>
        <asp:Label ID="LblNumeroDoc" runat="server" Text="Numero Docuemnto:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtNumeroDoc" runat="server" placeholder="Numero Documento" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="py-3">
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardar_Click" />
    </div>
    <asp:Label ID="LblMensaje" runat="server" Text="Mensaje:" CssClass="dnone"></asp:Label>

</asp:Content>

