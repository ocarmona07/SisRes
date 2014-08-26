<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="True"
    CodeBehind="ListaReservas.aspx.cs" Inherits="SisRes.Vista.ListaReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <h2>
            Listado de Reservas</h2>
    <br />
    <asp:GridView ID="gvReservas" runat="server" AutoGenerateColumns="False" ShowHeader="True"
        HorizontalAlign="Center" OnRowCommand="ReservasRowCommand">
        <Columns>
            <asp:BoundField HeaderText="Usuario" DataField="RUTUsuario" ItemStyle-Width="90px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Cliente" DataField="RUTCliente" ItemStyle-Width="90px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Habitación" DataField="IdHabitacion" ItemStyle-Width="80px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Número" DataField="" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Fecha Reserva" DataField="HoraFechaRes" ItemStyle-Width="80px"
                DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Cant. Días" DataField="DiasReserva" ItemStyle-Width="80px"
                ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Servicios" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="ibServicios" ImageUrl="~/Images/servicio.jpg"
                        ToolTip="Servicios" CommandName="Servicios" CommandArgument='<%# Eval("IdReserva") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Total" DataField="" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="ibEditar" ImageUrl="~/Images/editar.gif" ToolTip="Editar"
                        CommandName="Editar" CommandArgument='<%# Eval("IdReserva") %>' Style="margin-right: 10px;" />
                    <asp:ImageButton runat="server" ID="ibEliminar" ImageUrl="~/Images/eliminar.gif"
                        ToolTip="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdReserva") %>'
                        OnClientClick="javascript: return confirm('¿Desea eliminar la reserva seleccionadad?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
