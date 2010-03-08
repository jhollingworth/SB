<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
    Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SwanBob.Web.Controllers" %>

<asp:Content ContentPlaceHolderID="ScriptContentPlaceHolder" runat="server">
    <script src="http://static.ak.connect.facebook.com/js/api_lib/v0.4/FeatureLoader.js.php" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <fb:login-button onlogin="window.location='/photos/add'"></fb:login-button>  
    
    <script type="text/javascript">
        FB.init("47d13050071c06326ca0ffed43f0f6ed", "xd_receiver.htm");
    </script>
</asp:Content>
