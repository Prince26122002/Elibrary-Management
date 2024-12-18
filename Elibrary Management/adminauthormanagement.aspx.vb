Imports System.Data.SqlClient
Imports System.Configuration
Public Class adminauthormanagement
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GridView1.DataBind()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        If checkIfAuthorExists() Then
            Response.Write("<script>alert('Author with this ID already Exists. You cannot add another Author with the same Author ID')</script>")
        Else
            addNewAuthor()
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        If checkIfAuthorExists() Then
            updateAuthor()

        Else
            Response.Write("<script>alert('Author does not exist')</script>")
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button4.Click
        If checkIfAuthorExists() Then
            deleteAuthor()

        Else
            Response.Write("<script>alert('Author does not exist')</script>")
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        getAuthorByID()
    End Sub
    Sub deleteAuthor()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("DELETE from author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "'", con)

            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Author Deleted Successfully')</script>")
            clearForm()
            GridView1.DataBind()
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
    Sub updateAuthor()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("UPDATE author_master_tbl SET author_name=@author_name WHERE author_id='" + TextBox1.Text.Trim() + "'", con)

            cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim())
            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Author Updated Successfully')</script>")
            clearForm()
            GridView1.DataBind()
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
    Sub addNewAuthor()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) VALUES(@author_id,@author_name)", con)
            cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim())
            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Author added Successfully')</script>")
            clearForm()
            GridView1.DataBind()


        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Function checkIfAuthorExists() As Boolean
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "'", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then
                Return True
            Else
                Return False
            End If
            con.Close()
            Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login')</script>")
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
            Return False
        End Try
    End Function
    Sub clearForm()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Sub getAuthorByID()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "'", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)

            If dt.Rows.Count >= 1 Then
                TextBox2.Text = dt.Rows(0)(1).ToString()

            Else
                Response.Write("<script>alert('Invalid Author ID')</script>")
            End If
           
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub
End Class