<%@ Page Title="Grocery List" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="calendar_maint.aspx.vb" Inherits="App_seedling_Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!-- Compressed CSS -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/foundation-sites@6.8.1/dist/css/foundation.min.css" crossorigin="anonymous">

<!-- Compressed JavaScript -->
<script src="https://cdn.jsdelivr.net/npm/foundation-sites@6.8.1/dist/js/foundation.min.js" crossorigin="anonymous"></script>
<link href="../../CSS/grocery.css" rel="stylesheet" />

<div class="">&nbsp;</div>
<div class="">&nbsp;</div>
            <div class="medium-12" align="center">
                <h1 ForeColor="WhiteSmoke">Calendar Event Maintanence</h1>
            </div>

            <div align="center">
            <div class="jumbotron" style="width:950px;">
                <div class="grid-x grid-padding-x">
                        <div class="medium-4">
                            <asp:label id="lbCalendar_Type" runat="server" Text="Calendar Type" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:DropDownList ID="ddlCalendar_Type" runat="server" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbDate" runat="server" Text="Date of Event" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtDate" runat="server" TextMode="Date" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbDescription" runat="server" Text="Event Description" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbLocation" runat="server" Text="Location" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtLocation" runat="server" />
                        </div>

<%--                        <div class="medium-4">
                            <asp:label id="lbItem_Category" runat="server" Text="Item Category" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:DropDownList ID="ddlItem_Category" runat="server" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbItem_Description" runat="server" Text="Item Description" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtItem_Description" runat="server" TextMode="Multiline" />
                        </div>--%>
                        <div class="medium-4">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                        </div>
                </div>
            </div>
            </div>


</asp:Content>
