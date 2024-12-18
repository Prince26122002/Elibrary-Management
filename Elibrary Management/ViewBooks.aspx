<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ViewBooks.aspx.vb" Inherits="Elibrary_Management.ViewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>  <div class="col-md-8">
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
                                            <asp:Image class="img-fluid p-2"  ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
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
       
    </div> </center> 
</asp:Content>
