<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="True"
    CodeBehind="ListaReservas.aspx.cs" Inherits="SisRes.Vista.ListaReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h1>
        Listado de Reservas</h1>
    <br />
    <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="False" ShowHeader="True" OnRowCommand="ReservasRowCommand">
        <Columns>
            <asp:BoundField HeaderText="Usuario" DataField="RUTUsuario" ItemStyle-Width="90px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Cliente" DataField="RUTCliente" ItemStyle-Width="90px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Habitación" DataField="TipoHabitacion" ItemStyle-Width="80px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Número" DataField="Numero" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Fecha Reserva" DataField="HoraFechaRes" ItemStyle-Width="80px"
                DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Cant. Días" DataField="DiasReserva" ItemStyle-Width="80px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Servicios">
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="ibServicios" ImageUrl="~/Images/servicio.jpg" ToolTip="Servicios"
                        CommandName="Servicios" CommandArgument='<%# Eval("IdDetalleReserva") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle Width="60px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Total" DataField="Total" ItemStyle-Width="80px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="ibEditar" ImageUrl="~/Images/editar.gif" ToolTip="Editar"
                        CommandName="Editar" CommandArgument='<%# Eval("IdReserva") %>' />
                    <asp:Label runat="server" Text=" / " />
                    <asp:ImageButton runat="server" ID="ibEliminar" ImageUrl="~/Images/eliminar.gif"
                        ToolTip="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdReserva") %>'
                        OnClientClick="javascript: return confirm('¿Desea eliminar la reserva seleccionadad?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle Width="60px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
