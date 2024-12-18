Imports System.Data.SqlClient
Imports System.Configuration
Public Class signup
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If checkMemberExists() Then
            Response.Write("<script>alert('Member already exists with this ID, try other ID')</script>")

        Else
            signUpNewUser()
        End If
    End Sub

    Sub signUpNewUser()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) VALUES(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con)
            cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim())
            cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim())
            cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim())
            cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim())
            cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim())
            cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim())
            cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim())
            cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim())
            cmd.Parameters.AddWithValue("@account_status", "pending")

            cmd.ExecuteNonQuery()
            con.Close()
            Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login')</script>")


        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Function checkMemberExists() As Boolean
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox8.Text.Trim() + "'", con)
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




End Class