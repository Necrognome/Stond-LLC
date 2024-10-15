<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Games.aspx.vb" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <link href="/CSS/about.css" rel="stylesheet" type="text/css">
    </header>

    <h2><%: Title %>.</h2>
    <img src="Pictures/valheim.png" />
    <iframe src="http://www.wowarmory.com/character-model-embed.xml?r=skullcrusher&cn=nutpunch NAME&rhtml=true" scrolling="no" height="588" width="321" frameborder="0"></iframe>
</asp:Content>
