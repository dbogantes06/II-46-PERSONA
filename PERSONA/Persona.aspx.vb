Imports PERSONA.Models
Imports PERSONA.Utils

Public Class Persona
    Inherits System.Web.UI.Page
    Private dbPersona As New dbPersona()

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

        Dim ID As Integer = dbPersona.CrearPersona(persona)
        If ID Then
            SwalUtils.ShowSwal(Me, "Éxito", $"Persona creada con ID: {ID}", "success")
            GvPersonas.DataBind()  'actualizar gridview con la base de datos
            LimpiarFormulario()
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudo crear la persona.")
        End If




    End Sub

    Protected Sub GvPersonas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(GvPersonas.DataKeys(e.RowIndex).Value)
        Dim result As Integer = dbPersona.EliminarPersona(id)

        If result Then
            SwalUtils.ShowSwal(Me, "Éxito", "Persona eliminada correctamente.", "success")
        Else
            SwalUtils.ShowSwalError(Me, "Error", "No se pudo eliminar la persona.")
        End If
        GvPersonas.DataBind()
        e.Cancel = True



    End Sub


    Protected Sub GvPersonas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim persona As New Models.Persona()
        persona.Nombre = CType(GvPersonas.Rows(e.RowIndex).FindControl("txtNombreEdit"), TextBox).Text
        SwalUtils.ShowSwal(Me, persona.Nombre, "", "success")
        GvPersonas.DataBind()
        GvPersonas.EditIndex = -1

    End Sub

    Protected Sub GvPersonas_SelectedIndexChanged(sender As Object, e As EventArgs)
        hfIdPersona.Value = GvPersonas.DataKeys(GvPersonas.SelectedIndex).Value
        Dim id As Integer = Convert.ToInt32(hfIdPersona.Value)


        Dim errorMessage As String = ""
        Dim p As Models.Persona = dbPersona.ConsultarPersona(id, errorMessage)


        If p Is Nothing Then
            SwalUtils.ShowSwalError(Me, If(errorMessage = "", "No se pudo cargar la persona.", errorMessage))
            Return
        End If


        TxtNumeroDoc.Text = p.NumeroDocumento
        TxtNombre.Text = p.Nombre
        TxtApellido.Text = p.Apellidos
        DdlTipoDocumento.SelectedValue = p.TipoDocumento
        TxtCorreo.Text = p.Correo
        TxtfechaNacimiento.Text = DateTime.Parse(p.FechaNacimiento).ToString("yyyy-MM-dd")
        btnGuardar.Visible = False
        btnActualizar.Visible = True
        BtnCancelar.Visible = True

    End Sub

    Protected Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        btnGuardar.Visible = True
        btnActualizar.Visible = False
        BtnCancelar.Visible = False
        LimpiarFormulario()


    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)
        Dim persona As New Models.Persona()
        persona.ID_Persona = Convert.ToInt32(hfIdPersona.Value)
        persona.Nombre = TxtNombre.Text.Trim()
        persona.Apellidos = TxtApellido.Text.Trim()
        persona.TipoDocumento = DdlTipoDocumento.SelectedValue
        persona.NumeroDocumento = TxtNumeroDoc.Text.Trim()
        persona.Correo = TxtCorreo.Text.Trim()
        persona.FechaNacimiento = TxtfechaNacimiento.Text.Trim()

        Dim errorMessage As String = ""
        Dim resultado = dbPersona.ActualizarPersona(persona, errorMessage)

        If resultado Then
            SwalUtils.ShowSwal(Me, "Persona actualizada exitosamente.")
            GvPersonas.DataBind() ' Refrescar el GridView después de actualizar
            LimpiarFormulario()
        Else
            SwalUtils.ShowSwalError(Me, errorMessage)
        End If
    End Sub

    Protected Sub LimpiarFormulario()
        TxtNumeroDoc.Text = ""
        TxtNombre.Text = ""
        TxtApellido.Text = ""
        DdlTipoDocumento.SelectedIndex = 0
        TxtCorreo.Text = ""
        TxtfechaNacimiento.Text = ""
    End Sub

End Class