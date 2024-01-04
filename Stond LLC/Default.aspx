<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <header>
        <link href="/CSS/about.css" rel="stylesheet" type="text/css">
    </header>

    <div id="fb-root"></div>
    <script async defer crossorigin="anonymous" src="https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v18.0" nonce="ETlc03Ek"></script>
        
    <style>
        .twitter-timeline {
            width:500px;
            height:500px;
        }
    </style>
    
    <div class="jumbotron" style="background-color: transparent;">
        <font color="white">
        <h1>Welcome to the Crypt</h1>
        <p class="lead">Enter if you dare. There are many site to forsee within the wall of the crypt. Your soul is your username with your password being your essence of being.</p>
        </font>
    </div>

    <div align="center">
        <!-- Add a placeholder for the Twitch embed -->
        <div id="twitch-embed"></div>

        <!-- Load the Twitch embed JavaScript file -->
        <script src="https://embed.twitch.tv/embed/v1.js"></script>

        <!-- Create a Twitch.Embed object that will render within the "twitch-embed" element -->
        <script type="text/javascript">
          new Twitch.Embed("twitch-embed", {
            width: 854,
            height: 480,
            channel: "necro_gnome",
            // Only needed if this page is going to be embedded on other websites
            parent: ["embed.example.com", "othersite.example.com"]
          });
        </script>

    </div>

<div class="">&nbsp;</div>

    <div class="grid-x grid-padding-x">
        <div class="medium-3" align="center">
            <a name="twitter-timeline" class="twitter-timeline" href="https://twitter.com/Stondgnome420?ref_src=twsrc%5Etfw">Tweets by Stondgnome420</a> 
            <script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
        </div>
    </div>

</asp:Content>
