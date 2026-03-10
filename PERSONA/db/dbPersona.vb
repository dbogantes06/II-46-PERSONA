Imports System.Data.SqlClient

Public Class dbPersona
    Private ReadOnly dbHelper = New DbHelper() 'clase para manejar la conexion y consultas a la base de datos

    Public Function CrearPersona(persona As Models.Persona) As Integer
        Dim Sql As String = "INSERT INTO Personas (Nombre, Apellidos, Correo, FechaNacimiento, NumeroDocumento, TipoDocumento) " &
                    "VALUES (@Nombre, @Apellidos, @Correo, @FechaNacimiento, @NumeroDocumento, @TipoDocumento); " &
                    "SELECT SCOPE_IDENTITY();"

        Dim parametros As New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", persona.Nombre),
            New SqlParameter("@Apellidos", persona.Apellidos),
            New SqlParameter("@Correo", persona.Correo),
            New SqlParameter("@FechaNacimiento", persona.FechaNacimiento),
            New SqlParameter("@NumeroDocumento", persona.NumeroDocumento),
            New SqlParameter("@TipoDocumento", persona.TipoDocumento)
        }
        Return dbHelper.ExecuteScalar(Sql, parametros)
    End Function

    Public Function EliminarPersona(id As Integer) As Boolean
        Dim Sql As String = "DELETE FROM Personas WHERE Id_Persona = @Id"

        Dim parametros As New List(Of SqlParameter) From {
        New SqlParameter("@Id", id)
    }
        Return dbHelper.ExecuteNonQuery(Sql, parametros)

    End Function
    Public Function ConsultarPersona(id As String, errorMessage As String) As Models.Persona
        Dim query As String = "SELECT * FROM Personas WHERE id_Persona = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }
        Dim dt As DataTable = dbHelper.ExecuteQuery(query, parameters, errorMessage)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            Dim persona As New Models.Persona() With {
                .Nombre = row("Nombre").ToString(),
                .Apellidos = row("Apellidos").ToString(),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Correo = row("Correo").ToString(),
                .NumeroDocumento = row("NumeroDocumento").ToString(),
                .TipoDocumento = row("TipoDocumento").ToString()
            }
            Return persona
        End If
        Return Nothing
    End Function

    Public Function ActualizarPersona(ByVal pPersona As Models.Persona, ByRef errorMessage As String) As Boolean
        ' 1. Sentencia SQL
        Dim query As String = "UPDATE Personas 
        SET TipoDocumento = @TipoDocumento, 
        NumeroDocumento = @Documento, 
        Nombre = @Nombre, 
        Apellidos = @Apellidos, 
        FechaNacimiento = @FechaNacimiento, 
        Correo = @Correo
        WHERE id_Persona = @Id"

        ' 2. Parámetros
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", pPersona.ID_Persona},
            {"@Nombre", pPersona.Nombre},
            {"@FechaNacimiento", pPersona.FechaNacimiento},
            {"@Correo", pPersona.Correo},
            {"@Apellidos", pPersona.Apellidos},
            {"@Documento", pPersona.NumeroDocumento},
            {"@TipoDocumento", pPersona.TipoDocumento}
        }
        '3. Ejecutar la consulta
        Return dbHelper.ExecuteNonQuery(query, parameters, errorMessage)
    End Function


End Class
