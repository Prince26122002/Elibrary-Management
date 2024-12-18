<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="adminbookinventory.aspx.vb" Inherits="Elibrary_Management.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <script type="text/javascript">
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#imgview').attr('src', e.target.result);
            };
            reader.readAsDataURL(input.files[0]);
        }
    }

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
.row{
margin-bottom:12px;
}
label
{
margin-bottom:2px;  
}
</style>

<div class="container-fluid">
  <div class="row">
     <div class="col-md-5">
       <div class="card">
         <div class="card-body">
           <div class="row">
              <div class="col">
                <center>
                    <h4>Book Details</h4>
                </center>
              </div>
           </div>
           <div class="row">
              <div class="col">
                <center>
                    <img id="imgview" height="150px" Width="100px" src="books/books1.png"  />
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
                  <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
              </div>
           </div>
           
           <div class="row">
              <div class="col-3">
                <label>Book ID</label>
                 <div class="form-group">
                   <div class="input-group">
                     <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton4" class="btn btn-primary" runat="server" Text="Go"></asp:LinkButton>
                   </div>
                 </div>
               </div>
              <div class="col-md-9">
                <label>Book Name</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Book Name"></asp:TextBox>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-4">
                <label>Language</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                     <asp:ListItem Text="English" Value="English" ></asp:ListItem>
                     <asp:ListItem Text="Hindi" Value="Hindi" ></asp:ListItem>
                     <asp:ListItem Text="Marathi" Value="Marathi" ></asp:ListItem>
                     <asp:ListItem Text="French" Value="French" ></asp:ListItem>
                     <asp:ListItem Text="German" Value="German" ></asp:ListItem>
                     <asp:ListItem Text="Urdu" Value="Urdu" ></asp:ListItem>
                    
                    </asp:DropDownList>  
                </div>
                <label>Publisher Name</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                     <asp:ListItem Text="Publisher 1" Value="Publisher 1" ></asp:ListItem>
                     <asp:ListItem Text="Publisher 2" Value="Publisher 2" ></asp:ListItem>
                    </asp:DropDownList>  
                </div>
              </div>

              <div class="col-md-4">
                <label>Author Name</label>
                <div class="form-group">
                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                     <asp:ListItem Text="A1" Value="a1" ></asp:ListItem>
                     <asp:ListItem Text="A2" Value="a2" ></asp:ListItem>
                    </asp:DropDownList>  
                </div>
                <label>Publish Date</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                </div>
              </div>
              
              <div class="col-md-4">
                <label>Genre</label>
                <div class="form-group">
                    <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="4">
                              <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Comic Book" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />
                     </asp:ListBox> 
                </div>
              </div>
            </div> 
            
            <div class="row"> 
              <div class="col-md-4">
                <label>Edition</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server" placeholder="Edition"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Book Cost(per unit)</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Pages</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                </div>
              </div>
              
            </div>

            <div class="row">
              <div class="col-md-4">
                <label>Actual Stock</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox11" CssClass="form-control" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Current Stock</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox12" CssClass="form-control" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="True"></asp:TextBox>
                </div>
              </div>
              <div class="col-md-4">
                <label>Issued Books</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox13" CssClass="form-control" runat="server" placeholder="Issued Books"  TextMode="Number" ReadOnly="true"></asp:TextBox>
                </div>
              </div>
              
            </div>

           <div class="row">
              <div class="col-md-12">
                <label>Book Description</label>
                <div class="form-group">
                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" placeholder="Book Description" TextMode="Multiline" Rows="2"></asp:TextBox>
                </div>
              </div>
            </div>
            
            <div class="row">
              <div class="col-4">
                 <div class="form-group">
                   <asp:Button ID="Button3" class="btn btn-success btn-lg form-control" runat="server" Text="Add" />
                </div>
              </div>
              <div class="col-4">
                 <div class="form-group">
                   <asp:Button ID="Button1" class="btn btn-warning btn-lg form-control" runat="server" Text="Update" />
                </div>
              </div>
              <div class="col-4">
                 <div class="form-group">
                   <asp:Button ID="Button2" class="btn btn-danger btn-lg form-control" runat="server" Text="Delete" />
                </div>
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
                    <h4>Book Inventory List</h4>
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
                  <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" 
                      SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                  <asp:GridView ID="GridView1" class="table table-striped table-bordered" 
                      runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" 
                      DataSourceID="SqlDataSource1">
                      <Columns>
                          <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" 
                              SortExpression="book_id" >
                          
                          <ItemStyle Font-Bold="True" Wrap="True" />
                          </asp:BoundField>
                          
                          <asp:TemplateField>
                              <ItemTemplate>
                                 <div class="container-fluid">
                                     <div class="row">
                                        <div class="col-lg-10">
                                            <div class="row">
                                               <div class="col-lg-12">
                                                   <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' 
                                                       Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                               </div>
                                            </div>
                                            <div class="row">
                                               <div class="col-lg-12">
                                                  
                                                   Author -
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("author_name") %>'></asp:Label>
                                                   &nbsp;| Genre -
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("genre") %>'></asp:Label>
                                                   &nbsp;| Language -
                                                   <asp:Label ID="Label4" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("language") %>'></asp:Label>
                                                  
                                               </div>
                                            </div>
                                            <div class="row">
                                               <div class="col-lg-12">
                                                  
                                                   Publisher -
                                                   <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                   &nbsp;| Publish Date -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("publish_date") %>'></asp:Label>
                                                   &nbsp;| Pages -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                   &nbsp;| Edition -
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("edition") %>'></asp:Label>
                                                   &nbsp;</div>
                                            </div>
                                            <div class="row">
                                               <div class="col-lg-12">
                                                  
                                                   Cost -
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("book_cost") %>'></asp:Label>
                                                   &nbsp;| Actual Stock -
                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                   &nbsp;| Current Stock -
                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("current_stock") %>'></asp:Label>
                                                  
                                               </div>
                                            </div>
                                            <div class="row">
                                               <div class="col-lg-12">
                                
                                                   Description - <asp:Label ID="Label12" runat="server" Font-Bold="True" 
                                                       Text='<%# Eval("book_description") %>' Font-Italic="True" 
                                                       Font-Size="Smaller"></asp:Label>
                      
                                               </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                        </div>
                                     </div>
                                 </div>
                              </ItemTemplate>
                          </asp:TemplateField>
                          
                      </Columns>
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
