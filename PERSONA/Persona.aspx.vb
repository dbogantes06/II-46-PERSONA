Public Class Persona
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs)
        Dim persona = New Models.Persona()
        'Validar fecha nacimiento desde el codebehind- Tiene prioridad el aspx sobre el codebehind
        If IsDate(TxtfechaNacimiento.Text) = False Then
            LblMensaje.Text = "La fecha de nacimiento no es válida."
            Return
        End If
        persona.Nombre = TxtNombre.Text
        persona.Apellidos = TxtApellido.Text
        persona.FechaNacimiento = TxtfechaNacimiento.Text
        persona.Correo = TxtCorreo.Text
        persona.TipoDocumento = DdlTipoDocumento.SelectedItem.Text
        persona.NumeroDocumento = TxtNumeroDoc.Text
        LblMensaje.Text = persona.Resumen()
    End Sub
End Class