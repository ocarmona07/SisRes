<%@ Page Title="" Language="C#" MasterPageFile="~/Base.Master" AutoEventWireup="True"
    CodeBehind="IngresarReservas.aspx.cs" Inherits="SisRes.Vista.IngresarReservas" %>

<%@ Register TagPrefix="act" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.7.1213, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="cphMain" runat="server">
    <act:ToolkitScriptManager ID="tkmDate" runat="server" EnableScriptGlobalization="True"
        EnableScriptLocalization="True" />
    <asp:Panel runat="server" GroupingText="Cliente">
        <br />
        <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
            <asp:TableRow runat="server" HorizontalAlign="Center">
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="40px">
                        <asp:Label runat="server" Text="RUT:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbRutCliente" runat="server" Width="60px" MaxLength="8" />
                    <asp:Label runat="server" Text=" - " />
                    <asp:TextBox ID="tbDvCliente" runat="server" Width="12px" MaxLength="1" />
                    <asp:ImageButton ID="ibBuscarRut" runat="server" ImageUrl="~/Images/buscar.png" OnClick="BuscarCliente"
                        Style="margin-left: 15px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Nombres:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbNombres" runat="server" Width="160px" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Ap. Paterno:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbApPaterno" runat="server" Width="150px" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Ap. Materno:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbApMaterno" runat="server" Width="150px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Center">
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                        <asp:Label runat="server" Text="Teléfono:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbFono" runat="server" Width="110px" MaxLength="10" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                        <asp:Label runat="server" Text="Dirección:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbDireccion" runat="server" Width="160px" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                        <asp:Label runat="server" Text="Email:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left" ColumnSpan="3">
                    <asp:TextBox ID="tbEmail" runat="server" Width="180px" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Center">
                <asp:TableCell runat="server" ColumnSpan="2" />
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                        <asp:Label runat="server" Text="Tipo Cliente:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:DropDownList runat="server" ID="ddlTipoCliente" Width="130px" AutoPostBack="True"
                        OnSelectedIndexChanged="MostrarDescuento" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                    <asp:Label runat="server" Text="Estado:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:CheckBox ID="chkEstadoCliente" runat="server" Width="160px" Text="Activo" Checked="True" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>
    <br />
    <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
        <asp:TableRow runat="server" HorizontalAlign="Center">
            <asp:TableCell runat="server" Width="70%" HorizontalAlign="Left" Style="padding-right: 5px;">
                <asp:Panel runat="server" GroupingText="Habitación">
                    <br />
                    <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
                        <asp:TableRow runat="server" HorizontalAlign="Center">
                            <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                                <asp:Label runat="server" Text="Habitación:" Style="padding-right: 5px;" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                                <asp:DropDownList runat="server" ID="ddlTipoHabitacion" Width="130px" AutoPostBack="True"
                                    OnSelectedIndexChanged="CambioTipoHabitacion" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                                <asp:Label runat="server" Text="Número de Habitación:" Style="padding-right: 5px;" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                                <asp:DropDownList runat="server" ID="ddlHabitacion" Width="60px" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right" Height="30px">
                                <asp:Label runat="server" Text="Precio:" Style="padding-right: 5px;" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                                <asp:TextBox runat="server" ID="tbHabitacionPrecio" Width="80px" ReadOnly="True" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server" HorizontalAlign="Center">
                            <asp:TableCell runat="server" VerticalAlign="Top" HorizontalAlign="Right" Height="30px">
                                <asp:Label runat="server" Text="Observación:" Style="padding-right: 5px;" />
                            </asp:TableCell>
                            <asp:TableCell runat="server" VerticalAlign="Top" HorizontalAlign="Left" ColumnSpan="5">
                                <asp:TextBox runat="server" ID="tbObservacion" Width="510px" Height="66px" TextMode="MultiLine" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="30%" HorizontalAlign="Left" Style="padding-left: 5px;">
                <asp:Panel runat="server" GroupingText="Servicios">
                    <br />
                    <asp:GridView runat="server" ID="gvServicios" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="hdnServicio" Value='<%# Eval("IdServicio") %>' />
                                    <asp:CheckBox runat="server" ID="chkServicio" ToolTip='<%# Eval("Descripcion") %>'
                                        OnCheckedChanged="CambioServicio" AutoPostBack="True" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Servicio" DataField="Servicio" HeaderStyle-Width="170px" />
                            <asp:TemplateField HeaderText="Precio">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# "$ " + Eval("Precio") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Panel runat="server" GroupingText="Detalle">
        <br />
        <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
            <asp:TableRow runat="server" HorizontalAlign="Center" Height="30px">
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Fecha de Reserva:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox runat="server" ID="tbFechaReserva" Width="80px" ReadOnly="True" />
                    <asp:ImageButton runat="server" ID="ibFechaReserva" ImageUrl="~/Images/calendar.png"
                        Style="margin-left: 10px; margin-bottom: -5px;" OnClientClick="return false;" />
                    <act:CalendarExtender ID="calFechaReserva" runat="server" TargetControlID="tbFechaReserva"
                        PopupButtonID="ibFechaReserva" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Cant. Días:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:DropDownList runat="server" ID="ddlDias" Width="60px" AutoPostBack="True" OnSelectedIndexChanged="CambioServicio" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Descuento:" Style="padding-right: 5px;" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox runat="server" ID="tbDescuento" Width="70px" ReadOnly="True" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                        <asp:Label runat="server" Text="Precio Total:" Style="padding-right: 5px;" Font-Bold="True" />
                </asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Left">
                    <asp:TextBox ID="tbPrecioTotal" runat="server" Width="80px" ReadOnly="True" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>
    <br />
    <br />
    <div style="text-align: center;">
        <asp:HiddenField runat="server" ID="hdnIdReserva" />
        <asp:Button runat="server" ID="btnIngresarReserva" Text="Ingresar Reserva" Width="150px"
            Height="30px" OnClick="IngresarReserva" CausesValidation="True" ValidationGroup="Habitacion" />
    </div>
    <br />
    <div runat="server" id="divBuscarCliente" visible="False">
    </div>
</asp:Content>
