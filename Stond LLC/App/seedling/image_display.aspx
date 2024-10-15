<%@ Page Language="VB" AutoEventWireup="false" CodeFile="image_display.aspx.vb" Inherits="App_seedling_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../CSS/image-display.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <img src="../../Pictures/valheim.png" />
        </div>

        <div class="grid-x grid-padding-x">
        <div class="medium-6" style="border:solid; border-color:black;">
            <label asp-for="FileUpload.FormFile"></label>
        </div>
        <div class="medium-6">
            <input asp-for="FileUpload.FormFile" type="file">
            <span asp-validation-for="FileUpload.FormFile"></span>
        </div>
    </div>
    <input asp-page-handler="Upload" class="btn" type="submit" value="Upload" />




    </form>
</body>
</html>
