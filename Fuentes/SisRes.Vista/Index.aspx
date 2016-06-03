<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Index.aspx.cs" Inherits="SisRes.Vista.Default" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>SisRes - Sistema de Reservas para Hotel</title>
    <meta charset="utf-8">
    <link rel="stylesheet" href="~/Css/reset.css" type="text/css" media="all" />
    <link rel="stylesheet" href="~/Css/layout.css" type="text/css" media="all" />
    <link rel="stylesheet" href="~/Css/style.css" type="text/css" media="all" />
    <script type="text/javascript" src="Scripts/jquery-1.11.1.js"></script>
    <script type="text/javascript" src="Scripts/cufon-yui.js"></script>
    <script type="text/javascript" src="Scripts/cufon-replace.js"></script>
    <script type="text/javascript" src="Scripts/Adamina_400.font.js"></script>
    <script type="text/javascript" src="Scripts/jquery.jqtransform.js"></script>
    <script type="text/javascript" src="Scripts/script.js"></script>
    <script type="text/javascript" src="Scripts/kwicks-1.5.1.pack.js"></script>
    <script type="text/javascript" src="Scripts/atooltip.jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.kwicks').kwicks({
                max: 500,
                spacing: 0,
                event: 'mouseover'
            });
        });

        Cufon.now();
    </script>
</head>
<body id="page1">
    <div class="bg1">
        <div class="bg2">
            <div class="main">
                <header>
                    <h1><a href="Index.aspx" id="logo">SisRes</a></h1>
				</header>
                <div class="box">
                    <div class="ic">
                        SisRes</div>
                    <nav>
                        <ul class="menu">
                            <li>
                                <a href="Index.aspx" class="menuItem1" style="text-decoration: none;">Inicio</a>
                            </li>
                        </ul>
				    </nav>
                </div>
                <article id="content" class="box1">
                    <form id="frmLogin" runat="server">
                        <asp:Table runat="server">
                            <asp:TableRow runat="server" Height="120px">
                                <asp:TableCell runat="server" HorizontalAlign="Right" VerticalAlign="Bottom" Width="440px">
                                    <asp:Label runat="server" Text="RUT:" Style="padding-right: 5px;" />
                                </asp:TableCell>
                                <asp:TableCell runat="server" VerticalAlign="Bottom" Width="500px">
                                    <asp:TextBox ID="tbRut" runat="server" Width="120px" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="50px">
                                <asp:TableCell runat="server" HorizontalAlign="Right" VerticalAlign="Middle">
                                    <asp:Label runat="server" Text="Contraseña:" Style="padding-right: 5px;" />                                
                                </asp:TableCell>
                                <asp:TableCell runat="server" VerticalAlign="Middle">
                                    <asp:TextBox ID="tbClave" runat="server" Width="120px" TextMode="Password" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="50px">
                                <asp:TableCell runat="server" HorizontalAlign="Center" ColumnSpan="2">
                                    <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" Width="130px" Height="30px"
                                        OnClick="Ingresar" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" Height="150px">
                                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Top" ColumnSpan="2">
                                    <br />
                                    <asp:Label runat="server" ID="lblMensaje" CssClass="Mensaje" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </form>
                </article>
            </div>
        </div>
    </div>
    <footer>
        <div id="divCopyright" runat="server" class="col2" style="text-align: center;" />
    </footer>
</body>
</html>
