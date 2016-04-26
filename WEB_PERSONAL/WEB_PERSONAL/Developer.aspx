<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Developer.aspx.cs" Inherits="WEB_PERSONAL.Developer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="default_page_style">

        <div>
            <div>
                <asp:listbox runat="server" id="lbo1"></asp:listbox>
            </div>
            <div>
                <asp:textbox runat="server" id="tbc1" cssclass="ps-textbox"></asp:textbox>
            </div>
            <div>
                <asp:textbox runat="server" id="tbc2" TextMode="MultiLine" cssclass="ps-textbox"></asp:textbox>
            </div>
            <div>
                <asp:linkbutton runat="server" id="lbc" cssclass="ps-button" OnClick="lbc_Click">Send</asp:linkbutton>
            </div>
            
            
        </div>
        

        <asp:Table ID="Table1" runat="server">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Col1</asp:TableHeaderCell>
                <asp:TableHeaderCell>Col2</asp:TableHeaderCell>
            </asp:TableHeaderRow>

        </asp:Table>

        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />

        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    v1
                </asp:View>
                <asp:View ID="View2" runat="server">
                    v2
                </asp:View>
            </asp:MultiView>
            <asp:Button ID="Button1" runat="server" Text="View AAA" OnClick="Button1_Click" />
        </div>

        <div>
            <asp:BulletedList ID="BulletedList1" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
            </asp:BulletedList>
        </div>

        <input type="button" value="555" onclick="openPopup('popup1')" />

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="popup" id="popup1">
                    <div class="popup_content_pre">

                    
                    <div class="popup_content">
                        <div class="popup_content_head">
                            <div class="popup_content_head_left">
                                รายชื่อพนักงาน
                            </div>
                            <div class="popup_content_head_right">
                                <input type="button" onclick="closePopup('popup1')" class="close" />
                            </div>

                        </div>
                        <div class="popup_content_center">
                            <div>
                                111<asp:TextBox ID="TextBox1" runat="server" CssClass="textbox textbox_default"></asp:TextBox>
                                <asp:LinkButton ID="lbuSearchCitizenID" runat="server" OnClick="lbuSearchCitizenID_Click" CssClass="button button_default"><img src="Image/Small/search.png" class="icon_left"/>ค้นหา</asp:LinkButton>
                            </div>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Random</asp:LinkButton>

                            <div>
                                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                            </div>

                        </div>


                    </div>
                        </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>





        <asp:Panel ID="Panel1" runat="server" DefaultButton="lbuSQL">
            <asp:TextBox ID="tbSQL" runat="server" CssClass="textbox textbox_default" placeHolder="Select ..."></asp:TextBox>
            <asp:LinkButton ID="lbuSQL" runat="server" CssClass="button button_default" OnClick="lbuSQL_Click">View Select SQL</asp:LinkButton>
        </asp:Panel>

        <div>
            <asp:TextBox ID="tbSqlUpdate" runat="server" placeHolder="Sql Update Here"></asp:TextBox>
            <asp:Button ID="btnSqlUpdate" runat="server" Text="Execute SQL Update" OnClick="btnSqlUpdate_Click" />
        </div>

        <div>

            <asp:ListBox ID="ListBox1" runat="server" Height="300"></asp:ListBox>
            <br />
            <asp:LinkButton ID="lbuTableSQL" runat="server" CssClass="button button_default" OnClick="lbuTableSQL_Click">View Table</asp:LinkButton>

            <asp:GridView ID="GridView1" runat="server" ShowHeaderWhenEmpty="true"></asp:GridView>

        </div>
        <div style="clear: both;"></div>



    </div>


</asp:Content>
