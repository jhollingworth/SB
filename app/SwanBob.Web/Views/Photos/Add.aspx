<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" 
    Inherits="ViewPage<AddPhotosViewModel>" %>
<%@ Import Namespace="SwanBob.Web.Controllers" %>




<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <% foreach(var album in Model.Albums) { %>
        
        <%= album.name %>
        
    <% } %>
    
</asp:Content>
