<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopMenu.ascx.cs" Inherits="Control_TopMenu" %>
<script language="JavaScript">
    $(document).ready(function () {
        $('#amenu-list').amenu({
            'speed': 100,
            'animation': 'show'
        });
    });
                            </script>
                            <%--<ul id="amenu-list">
                                <li><a href="#" class="style5">Home</a> </li>
                                <li><a href="#" class="style5">About Us</a>
                                    <ul>
                                        <li><a href="#">Item 2-1</a></li>
                                        <li><a href="#">Item 2-2</a></li>
                                        <li><a href="#">Item 2-3</a>
                                            <ul>
                                                <li><a href="#">Item 2-3-1</a> </li>
                                                <li><a href="#">Item 2-3-2</a> </li>
                                                <li><a href="#">Item 2-3-3</a>
                                                    <ul>
                                                        <li><a href="#">Item 2-3-3-1</a> </li>
                                                        <li><a href="#">Item 2-3-3-2</a> </li>
                                                        <li><a href="#">Item 2-3-3-3</a> </li>
                                                    </ul>
                                                </li>
                                                <li><a href="#">Item 2-3-4</a> </li>
                                                <li><a href="#">Item 2-3-5</a>
                                                    <ul>
                                                        <li><a href="#">Item 2-3-5-1</a> </li>
                                                        <li><a href="#">Item 2-3-5-2</a> </li>
                                                        <li><a href="#">Item 2-3-5-3</a> </li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </li>
                                        <li><a href="#">Item 2-4</a> </li>
                                        <li><a href="#">Item 2-5</a> </li>
                                    </ul>
                                </li>
                                <li><a href="#" class="style5">Membership</a> </li>
                                <li><a href="#" class="style5">Publication</a> </li>
                                <li><a href="#" class="style5">Convention</a>
                                    <ul>
                                        <li><a href="#">Item 5-1</a> </li>
                                        <li><a href="#">Item 5-2</a> </li>
                                        <li><a href="#">Item 5-3</a> </li>
                                        <li><a href="#" class="style5">Events</a></li>
                                        <li><a href="#" class="style5">Centre</a></li>
                                        <li><a href="#" class="style5">News</a></li>
                                        <li><a href="#" class="style5">Contact</a></li>
                                    </ul>
                            </ul>--%>

<asp:Literal ID="lblMenu" runat="server"></asp:Literal>