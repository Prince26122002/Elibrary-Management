Imports System.Data.SqlClient
Imports System.Configuration
Public Class adminlogin
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from admin_login_tbl where username='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con)
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                While dr.Read
                    ' Response.Write("<script>alert('" + dr.GetValue(0).ToString() + "')</script>")
                    Session("username") = dr.GetValue(0).ToString()
                    Session("fullname") = dr.GetValue(2).ToString()
                    Session("role") = "admin"
                End While
                Response.Redirect("homepage.aspx")
            Else
                Response.Write("<script>alert('Invalid credential')</script>")
            End If


        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
End Class