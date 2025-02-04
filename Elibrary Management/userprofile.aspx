﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="userprofile.aspx.vb" Inherits="Elibrary_Management.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-fluid">
  <div class="row">
     <div class="col-md-5">
       <div class="card">
         <div class="card-body">
           <div class="row">
              <div class="col">
                <center>
                    <img width="100px" src="imgs/generaluser.png" />
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <center>
                    <h4>Your Profile</h4>
                    <span>Account Status - </span>
                    <asp:Label ID="Label1" CssClass="badge rounded-pill bg-info text-dark" runat="server" Text="Your Status"></asp:Label>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <hr>
              </div>
           </div>
           <br />
           <div class="row">
              <div class="col-md-6">
                <label>Full Name</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-6">
                <label>Date of Birth</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                </div>
              </div>
           </div>
           <br />
           <div class="row">
              <div class="col-md-6">
                <label>Contact No</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-6">
                <label>Email Id</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Email Id" TextMode="Email"></asp:TextBox>
                </div>
              </div>
            </div>
           <br />

           <div class="row">
              <div class="col-md-4">
                <label>State</label>
                <div class="form-group">
                    <asp:DropDownList ID="DropDownList1" Class="form-control" runat="server">
                        <asp:ListItem Text="Select" Value="Select"></asp:ListItem>
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                    </asp:DropDownList>
                </div>
              </div>
              <div class="col-md-4">
                <label>City</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox6" class="form-control" runat="server" placeholder="City"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Pincode</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox7" class="form-control" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                </div>
              </div>

           </div>
           <br />
           <div class="row">
             <div class="col">
                <label>Full Address</label>
                   <div class="form-group">
                       <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                   </div>
             </div>
           </div>
           
           <br />
           <div class="row">
              <div class="col">
                <center>
                 <span class="badge rounded-pill bg-info text-dark">Login Credential</span>
                </center>
              </div>
           </div>
           <br />
           <div class="row">
              <div class="col-md-4">
                <label>User ID</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox8" class="form-control" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Old Password</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox9" class="form-control" runat="server" placeholder="Old Password"  ReadOnly="True"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>New Password</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox10" class="form-control" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                </div>
              </div>
            </div>
            <br /> 
           <div class="row">
              <div class="col-8 mx-auto">
              <center>
                 <div class="form-group">
                   
                     <asp:Button ID="Button1" class="btn btn-primary btn-lg form-control" runat="server" Text="Update" />
                   
                </div>
                </center>
                <br />
              </div>
           </div>
        
         </div>
       </div>
       <a href="homepage.aspx"><< Back to Home</a><br />
       <br />
    </div>

    <div class="col-md-7">
       <div class="card">
         <div class="card-body">
           <div class="row">
              <div class="col">
                <center>
                    <img width="100px" src="imgs/books1.png" />
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <center>
                    <h4>Your Isuued Books</h4>
                    <asp:Label ID="Label2" class="badge rounded-pill bg-info" runat="server" Text="your books info"></asp:Label>
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
                  <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" class="table table-striped table-bordered"  runat="server">
                  </asp:GridView>
              </div>
           </div>
           <br />
          
           
        
       </div>  
       </div>
       
    </div>
  </div>
</div>
</asp:Content>
