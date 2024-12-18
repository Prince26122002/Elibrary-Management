Imports System.Data.SqlClient
Imports System.Configuration
Public Class userlogin
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        ' Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login')</script>")
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con)
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                While dr.Read
                    Response.Write("<script>alert('Login Successfully')</script>")
                    Session("username") = dr.GetValue(8).ToString()
                    Session("fullname") = dr.GetValue(0).ToString()
                    Session("role") = "user"
                    Session("status") = dr.GetValue(10).ToString()

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