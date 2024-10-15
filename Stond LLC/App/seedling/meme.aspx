<%@ Page Title="Meme" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="meme.aspx.vb" Inherits="App_seedling_Default" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!-- Compressed CSS -->
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/foundation-sites@6.8.1/dist/css/foundation.min.css" crossorigin="anonymous">

<!-- Compressed JavaScript -->
<script src="https://cdn.jsdelivr.net/npm/foundation-sites@6.8.1/dist/js/foundation.min.js" crossorigin="anonymous"></script>
<link href="../../CSS/grocery.css" rel="stylesheet" />


<div class="">&nbsp;</div>
<div class="">&nbsp;</div>
            <div class="medium-12" align="center">
                <h1 ForeColor="WhiteSmoke">Grocery List</h1>
            </div>

            <div align="center">
            <div class="jumbotron" style="width:950px;">
                <div class="grid-x grid-padding-x">
                        <div class="medium-4">
                            <asp:label id="lbItem_Name" runat="server" Text="Item Name" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtItem_Name" runat="server" placeholder="Enter Item Name" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbPurchase_Location" runat="server" Text="Purchase Location" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtPurchase_Location" runat="server" placeholder="Enter Location" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbPurchase_Price" runat="server" Text="Purchase Price" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtPurchase_Price" runat="server" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbPurchase_Date" runat="server" Text="Purchase Date" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtPurchase_Date" runat="server" TextMode="Date"/>
                        </div>

                        <div class="medium-4">
                            <asp:label id="lbItem_Category" runat="server" Text="Item Category" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:DropDownList ID="ddlItem_Category" runat="server" />
                        </div>
                        <div class="medium-4">
                            <asp:label id="lbItem_Description" runat="server" Text="Item Description" ForeColor="black" BackColor="WhiteSmoke"/>
                            <asp:TextBox ID="txtItem_Description" runat="server" TextMode="Multiline" />
                        </div>
                        <div class="medium-4">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                        </div>
                </div>
            </div>
            </div>

            <div class="large-12">
                <h1>Previous Purchased Items</h1>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=192.168.254.16;Initial Catalog=StondLLC;Integrated Security=True;MultipleActiveResultSets=True" SelectCommand="usp_Grocery_Maint" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:QueryStringParameter Name="Action_Type" Type="Int32" QueryStringField="Action_Type" DefaultValue="1" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:ControlParameter ControlID="Item_Name" ConvertEmptyStringToNull="False" DefaultValue="string" Name="Item_Name" PropertyName="string" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            
    
            <asp:GridView ID="gvGrocery_List" runat="server" DataSourceID="SqlDataSource1" EmptyDataText="Enter Grocery Items">
                <Columns>
                    <asp:BoundField datafield="Item_Name" runat="server" HeaderText="Item Name" />
                    <asp:BoundField datafield="Purchase_Location" runat="server" HeaderText="Purchased At"/>
                    <asp:BoundField datafield="Purchase_Price" runat="server" HeaderText="Purchased Price"/>
                    <asp:BoundField datafield="Purchase_Date" runat="server" HeaderText="Purchased Date"/>
                    <asp:BoundField datafield="Previous_Purchase_Location" runat="server" HeaderText="Previous Purchase Location"/>
                    <asp:BoundField datafield="Previous_Price" runat="server" HeaderText="Previous_Purchase_Price"/>
                    <asp:BoundField datafield="Previous_Purchase_Date" runat="server" HeaderText="Previous_Purchase_Date"/>
                    <asp:BoundField datafield="Item_Description" runat="server" HeaderText="Item Description"/>                 
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


</asp:Content>
