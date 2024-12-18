Imports System.Data.SqlClient
Imports System.Configuration
Public Class userprofile
    Inherits System.Web.UI.Page
    Dim strcon As String = ConfigurationManager.ConnectionStrings("con").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If String.IsNullOrEmpty(Session("username").ToString()) Then
                Response.Write("<script>alert('Session Expired Login Again')</script>")
                Response.Redirect("userlogin.aspx")
            Else
                getUserBookData()
                If Not Page.IsPostBack Then
                    getUserPersonalDetails()
                End If
            End If
        Catch ex As Exception
            Response.Write("<script>alert('Session Expired Login Again')</script>")
            Response.Redirect("userlogin.aspx")

        End Try
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(Session("username").ToString()) Then
            Response.Write("<script>alert('Session Expired Login Again')</script>")
            Response.Redirect("userlogin.aspx")
        Else
            updateUserPersonalDetails()


        End If
    End Sub

    Sub updateUserPersonalDetails()
        Dim password As String = ""
        If TextBox10.Text.Trim = "" Then
            password = TextBox9.Text.Trim()
        Else
            password = TextBox10.Text.Trim()
        End If
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim cmd As SqlCommand = New SqlCommand("UPDATE member_master_tbl SET full_name=@full_name,dob=@dob,contact_no=@contact_no,email=@email,state=@state,city=@city,pincode=@pincode,full_address=@full_address,password=@password,account_status=@account_status WHERE member_id='" + Session("username".ToString()) + "'", con)
            cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim())
            cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim())
            cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim())
            cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim())
            cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value)
            cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim())
            cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim())
            cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim())
            cmd.Parameters.AddWithValue("@password", password)
            cmd.Parameters.AddWithValue("@account_status", "pending")
            Dim result As Int32 = cmd.ExecuteNonQuery()
            con.Close()
            If result > 0 Then


                Response.Write("<script>alert('Your details updated successfully')</script>")
                getUserPersonalDetails()
                getUserBookData()
            Else
                Response.Write("<script>alert('Invalid entry')</script>")
            End If

        Catch ex As Exception
             Response.Write("<script>alert('"+ex.Message+"')</script>")
        End Try
    End Sub

    Sub getUserBookData()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from book_issue_tbl where member_id='" + Session("username").ToString() + "'", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)

            GridView1.DataSource = dt
            GridView1.DataBind()

        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Sub getUserPersonalDetails()
        Try
            Dim con As New SqlConnection(strcon)
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim cmd As SqlCommand = New SqlCommand("SELECT * from member_master_tbl where member_id='" + Session("username").ToString() + "'", con)
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As DataTable = New DataTable()
            da.Fill(dt)
            TextBox1.Text = dt.Rows(0)("full_name").ToString()
            TextBox2.Text = dt.Rows(0)("dob").ToString()
            TextBox3.Text = dt.Rows(0)("contact_no").ToString()
            TextBox4.Text = dt.Rows(0)("email").ToString()
            DropDownList1.SelectedValue = dt.Rows(0)("state").ToString().Trim()
            TextBox6.Text = dt.Rows(0)("city").ToString()
            TextBox7.Text = dt.Rows(0)("pincode").ToString()
            TextBox5.Text = dt.Rows(0)("full_address").ToString()
            TextBox8.Text = dt.Rows(0)("member_id").ToString()
            TextBox9.Text = dt.Rows(0)("password").ToString()

            Label1.Text = dt.Rows(0)("account_status").ToString().Trim()
            If dt.Rows(0)("account_status").ToString().Trim() = "active" Then
                Label1.Attributes.Add("class", "badge badge-pill badge-success")
            ElseIf dt.Rows(0)("account_status").ToString().Trim() = "pending" Then
                Label1.Attributes.Add("class", "badge badge-pill badge-warning")
            ElseIf dt.Rows(0)("account_status").ToString().Trim() = "deactive" Then
                Label1.Attributes.Add("class", "badge badge-pill badge-danger")
            Else
                Label1.Attributes.Add("class", "badge badge-pill badge-secondary")
            End If

        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dt As DateTime = Convert.ToDateTime(e.Row.Cells(5).Text)
                Dim today As DateTime = DateTime.Today
                If today > dt Then
                    e.Row.BackColor = System.Drawing.Color.PaleVioletRed
                End If
            End If
        Catch ex As Exception
            Response.Write("<script>alert('" + ex.Message + "')</script>")
        End Try

    End Sub
End Class