Imports PERSONA.Utils

Public Class Persona
    Inherits System.Web.UI.Page
    Private dbHelper As New DbHelper()

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
        persona.TipoDocumento = DdlTipoDocumento.SelectedItem.Value
        persona.NumeroDocumento = TxtNumeroDoc.Text
        'LblMensaje.Text = persona.Resumen()
        'LblMensaje.CssClass = "alert alert-success"

        Dim ID As Integer = dbHelper.CrearPersona(persona)
        If ID > 0 Then
            LblMensaje.Text = $"Persona creada con ID: {ID}"
            LblMensaje.CssClass = "alert alert-success"
            'actualizar gridview con la base de datos
            GvPersonas.DataBind()
            SwalUtils.ShowSwal(Me, "Éxito", $"Persona creada con ID: {ID}")
        Else
            LblMensaje.Text = "Error al crear la persona."
            LblMensaje.CssClass = "alert alert-danger"
        End If




    End Sub
End Class