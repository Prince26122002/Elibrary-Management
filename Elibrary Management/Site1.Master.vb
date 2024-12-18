Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("role").Equals("") Then
                LinkButton3.Visible = True
                LinkButton4.Visible = True
                LinkButton5.Visible = False
                LinkButton2.Visible = False
                LinkButton6.Visible = True
                LinkButton11.Visible = False
                LinkButton12.Visible = False
                LinkButton8.Visible = False
                LinkButton9.Visible = False
                LinkButton10.Visible = False

            ElseIf Session("role").Equals("user") Then
                LinkButton3.Visible = False
                LinkButton4.Visible = False
                LinkButton5.Visible = True
                LinkButton2.Visible = True
                LinkButton2.Text = "Hello " + Session("username").ToString()
                LinkButton6.Visible = True
                LinkButton11.Visible = False
                LinkButton12.Visible = False
                LinkButton8.Visible = False
                LinkButton9.Visible = False
                LinkButton10.Visible = False

            ElseIf Session("role").Equals("admin") Then
                LinkButton3.Visible = False
                LinkButton4.Visible = False
                LinkButton5.Visible = True
                LinkButton2.Visible = True
                LinkButton2.Text = "Hello Admin"
                LinkButton6.Visible = False
                LinkButton11.Visible = True
                LinkButton12.Visible = True
                LinkButton8.Visible = True
                LinkButton9.Visible = True
                LinkButton10.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    
    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton6.Click
        Response.Redirect("~/adminlogin.aspx")
    End Sub

    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton11.Click
        Response.Redirect("adminauthormanagement.aspx")
    End Sub

    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton12.Click
        Response.Redirect("adminpublishermanagement.aspx")
    End Sub

    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton8.Click
        Response.Redirect("adminbookinventory.aspx")
    End Sub

    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton9.Click
        Response.Redirect("adminbookissuing.aspx")
    End Sub

    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton10.Click
        Response.Redirect("adminmembermanagement.aspx")
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton3.Click
        Response.Redirect("userlogin.aspx")
    End Sub

    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton4.Click
        Response.Redirect("usersignup.aspx")
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton2.Click
        Response.Redirect("userprofile.aspx")
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("ViewBooks.aspx")
    End Sub

    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LinkButton5.Click
        Session("username") = ""
        Session("fullname") = ""
        Session("role") = ""
        Session("status") = ""

        LinkButton3.Visible = True
        LinkButton4.Visible = True
        LinkButton5.Visible = False
        LinkButton2.Visible = False
        LinkButton6.Visible = True
        LinkButton11.Visible = False
        LinkButton12.Visible = False
        LinkButton8.Visible = False
        LinkButton9.Visible = False
        LinkButton10.Visible = False

        Response.Redirect("homepage.aspx")


    End Sub
End Class