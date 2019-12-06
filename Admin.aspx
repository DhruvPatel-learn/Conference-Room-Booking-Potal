<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="Admin.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="drdo" %>



  
<!DOCTYPE html>

<html>
<head runat="server">
<title>CRB Portal</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

<style>
body,h1,h2,h3,h4,h5,h6 {font-family: "Raleway", Arial, Helvetica, sans-serif}
.mySlides {display: none}
</style>

<script type="text/javascript"  lang="Javascript">
     function DisableBackButton() {
       window.history.forward()
      }
     DisableBackButton();
     window.onload = DisableBackButton;
     window.onpageshow = function(evt) { if (evt.persisted) DisableBackButton() }
     window.onunload = function () { void (0) }


        
         }
</script>
</head>

<body  runat="server">
<form runat="server" >     
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

  

             <!-- Sidebar/menu -->    
<nav class=" w3-light-grey " style="z-index:0;width:280px; left: 0px;position:page" id="mySidebar">  
            

<hr />
<div class="w3-container w3-disaply-container ">

      <p><label><i class="fa fa-id-badge"></i> Ps. No</label></p>
      <asp:TextBox ID="txtno" class="w3-input w3-border" runat="server" ReadOnly="true" ValidateRequestMode="Disabled" OnTextChanged="txtno_TextChanged1" ></asp:TextBox>     
      <p><label><i class="fa fa-user-circle"></i> Name</label></p>
      <asp:TextBox ID="TextBox4"  runat="server"  class="w3-input w3-border" ReadOnly="true" ></asp:TextBox>  
      <p><label><i class="fa fa-envelope"></i> E-mail</label></p> 
      <asp:TextBox ID="TextBox5"  runat="server" class="w3-input w3-border"  ReadOnly="true" ></asp:TextBox>
<hr />
<hr />

<hr />  
<hr />
<hr />
<hr />
<hr />
<hr />


<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />
<hr />

<p><asp:button runat="server" Text="Room Management"  ID="rid"   Class="w3-button w3-block  w3-left-justify" OnClick="rid_Click"></asp:button></p>  
<p><asp:Button ID="Button2" runat="server" Text="Request Management"  Class="w3-button w3-block  w3-left-justify" OnClick="rit_Click"></asp:button></p>  
<p><asp:button runat="server" ID="rem"  Text="Admin Recruitment"  class=" w3-button w3-block  w3-left-justify" OnClick="Unnamed_Click1"></asp:button></p>
<p><asp:button runat="server" Text="Logout"  class=" w3-button w3-block w3-green w3-left-justify"  OnClick="Unnamed_Click" ></asp:button></p>




</div>
   
</nav>
 

             <!-- Slideshow Header -->
             <div class="w3-bar w3-top w3-white w3-card">
             <a class="w3-text-blue w3-left w3-padding-large"  >Conference Room Booking Portal  </a>
             </div>



            <!------Admin Recruitment---->
            <div  class="w3-card" style="margin-left:292px;margin-top:-830px;position:fixed;width:1428px;height:93%"    id="reqm" runat="server"  visible="false" >
             <asp:UpdatePanel runat="server" ID="updatepanel1" >       
           <ContentTemplate>
          <div class="w3-full" >
            <p><a class="w3-text-red w3-padding" style="align-content:center;font-size:medium"  >System Administrator</a></p>
            </div>
          
          <div class="w3-row-padding">
          <div class="w3-half">
          <p> <label>Conference Room</label></p>
          <asp:TextBox class="w3-input w3-border " runat="server" ID="TBRMC" ReadOnly="true" OnTextChanged="TBRMC_TextChanged"  AutoPostBack="true" placeholder="Select Room From Table Below"></asp:TextBox>
          </div>

          <div class="w3-half">
          <p> <label>Assign Status</label></p>
          <asp:DropDownList class="w3-input w3-border"  ID="DDLRM1" AppendDataBoundItems="true" OnSelectedIndexChanged="DDLRM1_SelectedIndexChanged" runat="server"  AutoPostBack="true"  >
          <asp:ListItem Value="0">--Select YES/NO--</asp:ListItem>  
          <asp:ListItem Value="1">--YES--</asp:ListItem> 
          <asp:ListItem Value="2">--NO--</asp:ListItem>      
          </asp:DropDownList>
          </div>     
          </div>
          
          <div class="w3-row-padding" >
          <div class="w3-half">
          <p>
          <asp:TextBox class="w3-input w3-border"  ID="DDLRM2" runat="server" ReadOnly="true" AutoPostBack="true" placeholder="Select Block"></asp:TextBox>
         </p>
          </div>
         
         
         
          <div class="w3-half">
           <p>
          <asp:TextBox class="w3-input w3-border" ID="DDLRM3" runat="server" ReadOnly="true" AutoPostBack="true" placeholder="Select Floor"></asp:TextBox>
           </p>
          </div>     
           </div>      
  
          <div class="w3-row-padding">
          <div class="w3-half" >      
          <p><asp:TextBox class="w3-input w3-border" Width="100%" AutoPostBack="true" Visible="false" runat="server" ID="TextBox3"  OnTextChanged="TextBox3_TextChanged"   placeholder="Enter PsNo."></asp:TextBox></p>
          </div>
          <div class="w3-half" >     
          <p><asp:TextBox class="w3-input w3-border " Width="100%" AutoPostBack="true" Visible="false" runat="server" ID="TextBox6" placeholder="Employee Name" ReadOnly="true"></asp:TextBox></p>
          </div>       
          </div>
      
          <div class="w3-row-padding" >
          <asp:TextBox class="w3-input w3-border " Width="100%" runat="server" ID="TBRME" Visible="false" AutoPostBack="true"  placeholder="E-Mail"></asp:TextBox>
          </div>
          
          <div  class="form-row" style="margin-top:5%" Visible="false" >
          <asp:button  runat="server" Text="Assign" style="margin-left:17px"  class="w3-left w3-button"  Visible="false" Width="5%" ID="Button6"  OnClick="Button6_Click"  ></asp:button>  
          <asp:button  runat="server" Text="Resign" style="margin-right:17px" class="w3-right w3-button" Visible="false"  Width="5%"  ID="Button7"  OnClick="Button7_Click" ></asp:button> 
          </div>
     
     <div  class="form-row w3-center" style="margin-top:9%">
     <asp:GridView ID="GridView5" runat="server" OnRowDataBound="GridView5_RowDataBound"  AutoGenerateSelectButton="True" style="margin-left:420px"  AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Roomid"  OnSelectedIndexChanged="GridView5_SelectedIndexChanged" AllowPaging="True" PageSize="6"  OnPageIndexChanging="GridView5_PageIndexChanging">    
     <Columns>
  
      
                       <asp:BoundField DataField="Roomid" HeaderText="Sr No" InsertVisible="False" ReadOnly="True" SortExpression="Roomid" />
                       <asp:BoundField DataField="ConfRoom" HeaderText="Conference Room" SortExpression="ConfRoom" />
                       <asp:BoundField DataField="Block" HeaderText="Block" SortExpression="Block" />
                       <asp:BoundField DataField="Floor" HeaderText="Floor" SortExpression="Floor" />
                       <asp:BoundField DataField="AsNo" HeaderText=" Assigned User PsNo "   />
                

        </Columns>
        </asp:GridView>
       
</ContentTemplate>
</asp:UpdatePanel>

  <div  class="w3-center"  style="margin-left:48%;margin-top:10%;position:fixed">

    <div  class="w3-row-padding" ><p style="color:black" class="w3-right"  >© 2019. All Rights Reserved | Design by: Under Internship in LTHE Onshore IT, Baroda</p></div>          
     </div>
   </div>       
                      
  



            <!----Room Managemet -->
           <div  class="w3-card" style="margin-left:292px;margin-top:-830px;position:fixed;width:1428px;height:93%"   id="rmit" runat="server"  visible="false" >
           <asp:UpdatePanel runat="server" ID="updatepanel2" >       
           <ContentTemplate>
           <div class="w3-row-padding" >
          
               
           <div class="w3-full" id="div4">

         <p><a class="w3-text-red w3-padding" style="align-content:center;font-size:medium"  >Check/Update Room Details</a></p>
       
          </div> 
          <asp:TextBox class="w3-input w3-border w3-block-small"  runat="server" ID="TextBox2"   OnTextChanged="TextBox2_TextChanged1" placeholder="Select Room From Below Table To Update or Write Name & Select Parameter's To Insert a New Room"></asp:TextBox>
          <div class="w3-row-padding" >
          <div class="w3-half">
          <p> <label>Block</label></p>
          <asp:DropDownList class="w3-input w3-border" DatatextField="Block" DataValueField="Block" ID="DropDownList2" AppendDataBoundItems="true" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
          <asp:ListItem Value="0">--Select Block--</asp:ListItem>  
      
          </asp:DropDownList>
          </div>
         
         
         
          <div class="w3-half">
          <p> <label>Floor</label></p>
          <asp:DropDownList class="w3-input w3-border" DatatextField="Floor" DataValueField="Floor" ID="DropDownList3" AppendDataBoundItems="true" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
          <asp:ListItem Value="0">--Select Floor--</asp:ListItem>  
                                
          </asp:DropDownList>
          </div>     
           </div>
          
          <div class="w3-row-padding" >
          <div class="w3-half ">
          <p><label>Room Status</label></p>
          <asp:DropDownList class="w3-input w3-border" DatatextField="RoomSt" DataValueField="RoomSt" ID="DropDownList4" AppendDataBoundItems="true" runat="server"  AutoPostBack="true"   OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
          <asp:ListItem Value="0" >--Check Availability--</asp:ListItem>  
      
          </asp:DropDownList>
          </div>
          
          <div class="w3-half">
          <p><label>No Of Seats</label></p> 
          <asp:TextBox ID="TextBox7" class="w3-input w3-border" DatatextField="Nos" Minimum="1"  OnTextChanged="TextBox7_TextChanged" AutoPostBack="true" runat="server" TextMode="Number"></asp:TextBox>
            <!--   
      <asp:DropDownList class="w3-input w3-border" DatatextField="Nos" DataValueField="Nos" ID="DropDownList5" AppendDataBoundItems="true" runat="server"  AutoPostBack="true"   OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
          <asp:ListItem value="0">--Select No Of Seats--</asp:ListItem> 
         
         
          </asp:DropDownList> -->
          </div>
          </div>
          
          <div class="w3-row-padding" >
          <div class="w3-half">
          <p><label>WebEx</label>    </p>
          <asp:DropDownList class="w3-input w3-border" DatatextField="WebEx" DataValueField="WebEx" ID="DropDownList6" AppendDataBoundItems="true"  runat="server" AutoPostBack="true"    OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
          <asp:ListItem value="0">--Check Availability--</asp:ListItem> 
     
          </asp:DropDownList>
          </div>
        
          <div class="w3-half ">
          <p><label>Sparkboard</label></p>
          <asp:DropDownList class="w3-input w3-border" DatatextField="Sparkboard" DataValueField="Sparkboard" ID="DropDownList7" AppendDataBoundItems="true" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
          <asp:ListItem value="0">--Check Availability--</asp:ListItem> 
       
          </asp:DropDownList>
          </div>
          </div>

          <div class="w3-row-padding" >
          <div class="w3-half">
          <p><label>Desktop</label>    </p>
          <asp:DropDownList class="w3-input w3-border" DatatextField="Desktop" DataValueField="Desktop" ID="DropDownList8" AppendDataBoundItems="true" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged">
          <asp:ListItem value="0">--Check Availability--</asp:ListItem> 

          </asp:DropDownList>
          </div>
          <div class="w3-half">
       <p>   <label>Projector</label>    </p>
          <asp:DropDownList class="w3-input w3-border" DatatextField="Projector" DataValueField="Projector" ID="DropDownList9" AppendDataBoundItems="true" runat="server"  AutoPostBack="true"  OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged">
          <asp:ListItem value="0">--Check Availability--</asp:ListItem> 
          </asp:DropDownList>
          </div>
          </div> 
      
           <div  class="form-row" style="margin-top:2%">
           <asp:button  runat="server" Text="Update" Width="90px" ID="Button1"  Class="w3-left w3-button"  OnClick="Button1_Click"></asp:button>
           <asp:button  runat="server" Text="Insert" Width="90px"  ID="Button3" Class="w3-right w3-button" OnClick="Button3_Click1"></asp:button> 
           </div>
           <div  class="form-row w3-center" style="margin-top:3.5%;margin-left:195px">
                <br />
         <table class="table table-bordered" cellspacing="0" rules="all" border="1" id="ContentPlaceHolder1_GridView3" >

         <asp:GridView ID="GridView3" runat="server" AutoGenerateSelectButton="True" AutoPostback="true" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="Roomid"  OnSelectedIndexChanged="GridView3_SelectedIndexChanged" AllowPaging="True" PageSize="6" OnPageIndexChanging="GridView3_PageIndexChanging">
             
          <Columns>
                       <asp:BoundField DataField="Roomid" HeaderText="Sr No" InsertVisible="False" ReadOnly="True" SortExpression="Roomid" />
                       <asp:BoundField DataField="ConfRoom" HeaderText="Conferrence Room" SortExpression="ConfRoom" />
                       <asp:BoundField DataField="Block" HeaderText="Block" SortExpression="Block" />
                       <asp:BoundField DataField="Floor" HeaderText="Floor" SortExpression="Floor" />
                       <asp:BoundField DataField="RoomSt" HeaderText="Room Status" SortExpression="RoomSt" />
                       <asp:BoundField DataField="Nos" HeaderText="No Of Seat" SortExpression="Nos" />
                       <asp:BoundField DataField="WebEx" HeaderText="WebEx" SortExpression="WebEx" />
                       <asp:BoundField DataField="Sparkboard" HeaderText="Sparkboard" SortExpression="Sparkboard" />
                       
                       <asp:BoundField DataField="Desktop" HeaderText="Desktop" SortExpression="Desktop" />
                       <asp:BoundField DataField="Projector" HeaderText="Projector" SortExpression="Projector" />
         </Columns>   
                

    
        </asp:GridView>
        </tbody></table>       
        
         </div>

        </ContentTemplate>
        </asp:UpdatePanel> 
          <div  class="w3-padding" style="margin-bottom:0.5%"><p style="color:black" class="w3-right" >© 2019. All Rights Reserved | Design by: Under Internship in LTHE Onshore IT, Baroda</p></div>             
        </div>



            <!----Request Approval--->
            <div class="w3-card" style="margin-left:292px;margin-top:-830px;position:fixed;width:1428px;height:93%" runat="server" visible="false" id="rit" >
            <br />
            <div class="w3-full"  >
    <a class="w3-text-red w3-padding" style="align-content:center;font-size:medium"  >Booking Request Management</a>
    <div  class="w3-center"  style="margin-left:20px;margin-top:5%">
    <asp:button  runat="server" Text="Approve" style="margin-left:15px"  class="w3-bar-item w3-button w3-green  w3-border "  Width="30.33%" ID="Button4" OnClick="Button4_Click1"  ></asp:button>
    <asp:button  runat="server" Text="Reject" style="margin-right:95px" class="w3-bar-item w3-button w3-green  w3-border"  Width="30.33%"  ID="Button5"  OnClick="Button5_Click"></asp:button> 
          </div>       
          </div> 
<div  class="w3-middle" style="margin-left:145px;margin-top:3%;margin-bottom:5%">
            <table class="table table-bordered" cellspacing="0" rules="all" border="1" id="ContentPlaceHolder2_GridView4" >
     <asp:GridView ID="GridView4" runat="server" AutoPostback="False" AutoGenerateColumns="False"  BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  DataKeyNames="eid" OnSelectedIndexChanged="GridView4_SelectedIndexChanged" OnPageIndexChanging="GridView4_PageIndexChanging" AllowPaging="True" PageSize="10" >   
     <Columns>
     <asp:TemplateField HeaderText="Select Request">
     <ItemTemplate>
     <asp:CheckBox ID="CheckBox1" runat="server"  HeaderText="Select" />
     </ItemTemplate>
     </asp:TemplateField>
                       <asp:BoundField DataField="eid" HeaderText="Sr No"  SortExpression="Sr No" />
                       <asp:BoundField DataField="PsNo" HeaderText="Ps. No" SortExpression="Ps. No" />
                       <asp:BoundField DataField="Name" HeaderText="Employee Name" SortExpression="Employee Name" />
                       <asp:BoundField DataField="email" HeaderText="E-mail" SortExpression="E-mail" />
                       <asp:BoundField DataField="date" HeaderText="Date" SortExpression="Date" />
                       <asp:BoundField DataField="confroom" HeaderText="Conferrence Room" SortExpression="Conferrence Room" />
                       <asp:BoundField DataField="Checkin" HeaderText="Check-In" SortExpression="Check-In" />
                       <asp:BoundField DataField="Checkout" HeaderText="Check-Out" SortExpression="Check-Out" />
                       <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                      
    </Columns>   
    </asp:GridView>
    </table>       
       <br/>     
    


  
         
        

       
           <div id="zoom" style="margin-top:9%;margin-bottom:5" >
         <asp:Label ID="Label1" runat="server" Visible="false" >
        <a class="w3-text-red w3-padding" style="margin-left:490px;font-size:medium"  >Note*: Reject by stating valid reason and click "Submit" button!</a>
       </asp:Label>
        </div>
        
   <asp:TextBox Visible="false" ID="txtComment" style="margin-left:145px;margin-right:130px" Class="w3-center" runat="server" Height="150px" Width="1070px" TextMode="MultiLine" ></asp:TextBox>
     <br/>  
    <asp:button Visible="false" runat="server" Text="Submit" style="margin-right:95px;margin-left:145px;margin-top:2px;margin-bottom:7%" class="w3-bar-item w3-button w3-yellow  w3-border"  Width="75%"  ID="submit"  OnClick="submit_Click"></asp:button> 

    
    
    <div  class="w3-row-padding" style="margin-top:17%;margin-bottom:0.5%" ><p style="color:black" class="w3-right"> © 2019. All Rights Reserved | Design by: Under Internship in LTHE Onshore IT, Baroda</p></div>          

            </div>
          
            
            </div>
            
       



           

</form>
</body>
</html>
