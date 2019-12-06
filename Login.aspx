<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Login.aspx.cs" Inherits="Login"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>




<!DOCTYPE html>

<html>
<head runat="server">
<title>Login - LTHE</title>
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
     window.onunload = function() { void (0) }

</script>


</head>


<body   runat="server">
<form   runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

   



<!----LOGIN --->
<div style="width:28.5%;height:30%;margin-left:35%">
<div class="w3-card-2 w3-container w3-middle w3-white">
  
      <h3>LTHE - Conferrence Room Booking Portal</h3>
      <p><label><i class="fa fa-id-badge "></i>  Ps. No</label></p>
      <asp:TextBox ID="ps" class="w3-input w3-border" runat="server"   OnTextChanged="ps_TextChanged" ></asp:TextBox>     
      <asp:CompareValidator ID="psv" runat="server" ControlToValidate="ps" Type="Integer"   Operator="DataTypeCheck" ErrorMessage="PsNo is Invalid" />
      <p><label><i class="fa fa-key "></i>  Password</label></p>
      <asp:TextBox ID="pass" class="w3-input w3-border"  TextMode="Password" runat="server"  OnTextChanged="pass_TextChanged"  ></asp:TextBox>     
   
      <p><asp:button  runat="server" Text="Login" ID="sin"  Class="w3-button w3-block w3-green w3-left-justify" OnClick="sin_Click"></asp:button></p>  

</div>
</div>

    </form>
    </body>
    </html>

