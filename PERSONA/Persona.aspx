<%@ Page Title="Persona" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Persona.aspx.vb" Inherits="PERSONA.Persona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--nombre--%>
    <div>
        <asp:Label ID="LblNombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" Text="" placeholder="Nombre" CssClass="form-control"></asp:TextBox>
    </div>
    <%--Validar nombre--%>
    <asp:RequiredFieldValidator ID="RfvNombre" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="TxtNombre"
        ErrorMessage="Es necesario indicar el Nombre"></asp:RequiredFieldValidator>

    <%--apellido--%>
    <div>
        <asp:Label ID="LblApellido" runat="server" Text="Apellido:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtApellido" runat="server" placeholder="Apellido" CssClass="form-control"></asp:TextBox>
    </div>
    <%--Validar apellido--%>
    <asp:RequiredFieldValidator ID="RfvApellido" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="TxtApellido"
        ErrorMessage="Es necesario indicar el Apellido"></asp:RequiredFieldValidator>

    <%--fechaNacimiento--%>
    <div>
        <asp:Label ID="LblfechaNacimiento" runat="server" Text="Fecha Nacimiento:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtfechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>
    <%--Validar fecha de nacimiento--%>
    <asp:RequiredFieldValidator ID="RfvFecha" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="TxtfechaNacimiento"
        ErrorMessage="Es necesario indicar la fecha"></asp:RequiredFieldValidator>
    <%--correo--%>
    <div>
        <asp:Label ID="Lblcorreo" runat="server" Text="Correo:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtCorreo" runat="server" placeholder="Correo" CssClass="form-control" TextMode="Email"></asp:TextBox>
    </div>

    <%--Validar correo--%>
    <asp:RequiredFieldValidator ID="RfvCorreo" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="TxtCorreo"
        ErrorMessage="Es necesario indicar el correo"></asp:RequiredFieldValidator>

    <div class="form-group">
    </div>
    <%--tipoDocumento--%>
    <asp:Label ID="LblTipoDoc" runat="server" Text="Tipo de Documento:" CssClass="control-label"></asp:Label>
    <asp:DropDownList ID="DdlTipoDocumento" runat="server" CssClass="form-control">
        <asp:ListItem Text="Cedula Juridica" Value="0"></asp:ListItem>
        <asp:ListItem Text="Cedula Fisica" Value="1"></asp:ListItem>
        <asp:ListItem Text="Pasaporte" Value="2"></asp:ListItem>
    </asp:DropDownList>

    <%--Validar tipo de documento--%>
    <asp:RequiredFieldValidator ID="RfvTipoDoc" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="DdlTipoDocumento"
        ErrorMessage="Es necesario indicar el tipo de documento"></asp:RequiredFieldValidator>

    <%--Numero Documento--%>
    <div>
        <asp:Label ID="LblNumeroDoc" runat="server" Text="Numero Docuemnto:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TxtNumeroDoc" runat="server" placeholder="Numero Documento" CssClass="form-control"></asp:TextBox>
    </div>
    <%--Validar numero de documento--%>
    <asp:RequiredFieldValidator ID="RfvNumeroDoc" runat="server"
        CssClass="text-danger"
        Display="Dynamic"
        ControlToValidate="TxtNumeroDoc"
        ErrorMessage="Es necesario indicar el numero de documento"></asp:RequiredFieldValidator>

    <div class="py-3">
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGuardar_Click" />
    </div>
    <asp:Label ID="LblMensaje" runat="server" Text="Mensaje:" CssClass="dnone"></asp:Label>

    <asp:GridView ID="GvPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_Persona" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ID_Persona" HeaderText="ID_Persona" InsertVisible="False" ReadOnly="True" SortExpression="ID_Persona" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" SortExpression="FechaNacimiento" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo" />
            <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" SortExpression="NumeroDocumento" />
            <asp:BoundField DataField="TipoDocumento" HeaderText="TipoDocumento" SortExpression="TipoDocumento" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II-46ConnectionString %>" ProviderName="<%$ ConnectionStrings:II-46ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Personas] ORDER BY [Apellidos]"></asp:SqlDataSource>
</asp:Content>

