<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="userlogin.aspx.vb" Inherits="Elibrary_Management.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

.form-group
{
margin-bottom:15px;  
}
label
{
margin-bottom:5px;    
}
</style>
<div class="container">
  <div class="row">
    <div class="col-md-6 mx-auto">
       <div class="card">
         <div class="card-body">
           <div class="row">
              <div class="col">
                <center>
                    <img width="150px" src="imgs/generaluser.png" />
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <center>
                    <h3>Member Login</h3>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <hr>
              </div>
           </div>
           <div class="row">
              <div class="col">
               <label>MemberID</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Member ID"></asp:TextBox>
                </div>
                <label>Password</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>
                 <div class="form-group">
                     <asp:Button ID="Button1" class="btn btn-success  btn-lg form-control" runat="server" Text="Login" Onclick="Button1_Click"/>
                </div>
                <div class="form-group">
                   <a href="usersignup.aspx"><input id="Button2" class="btn btn-info btn-lg form-control" type="button" value="Sign Up " /></a>
                </div>
              </div>
           </div>
        
         </div>
       </div>
       <a href="homepage.aspx"><< Back to Home</a><br />
       <br />
    </div>
  </div>
</div>
</asp:Content>
