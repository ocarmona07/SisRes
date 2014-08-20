<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="true"
    CodeBehind="Reservas.aspx.cs" Inherits="SisRes.Vista.Reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script language="javascript" type="text/javascript">
        function BuscarRut() {
            var rut = prompt('Ingrese el RUT sin digito verificador a buscar:');
            if (rut != null) {
                alert(rut);
            }
            
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <form id="frmReserva" runat="server">
    <asp:Panel runat="server" GroupingText="Cliente">
        <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
            <asp:TableRow runat="server" HorizontalAlign="Center">
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="40px">
                        <asp:Label runat="server" Text="RUT:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbRut" runat="server" Width="60px" MaxLength="8" />
                    <asp:Label runat="server" Text=" - " />
                    <asp:TextBox ID="tbDv" runat="server" Width="12px" MaxLength="1" />
                    <asp:ImageButton ID="ibBuscarRut" runat="server" ImageUrl="~/Images/buscar.png" OnClientClick="return BuscarRut()"
                        Style="margin-left: 15px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Nombres:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbNombres" runat="server" Width="170px" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Ap. Paterno:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbApPaterno" runat="server" Width="140px" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Ap. Materno:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbApMaterno" runat="server" Width="140px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Center">
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                        <asp:Label runat="server" Text="Dirección:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left" ColumnSpan="2">
                    <asp:TextBox ID="tbDireccion" runat="server" Width="210px" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    </form>
</asp:Content>
