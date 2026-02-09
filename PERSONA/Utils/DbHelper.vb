Imports System.Data.SqlClient
Imports System.Web.WebSockets

Public Class DbHelper
   
    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

    Public Function Getconexion() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    Public Function CrearPersona() As Integer
        Dim Sql As String = "INSERT INTO Personas (Nombre, Apellidos, TipoDocumento, NumeroDocumento, FechaNacimiento, Correo)
        VALUES (@Nombre, @Apellidos, @TipoDocumento, @NumeroDocumento, @FechaNacimiento, @Correo)"

        'CONEXION A LA BASE DE DATOS
        Using conn As SqlConnection = Getconexion()
            Using cmd As New SqlCommand(Sql, conn)
                conn.Open()
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
        Return 0
    End Function




End Class
