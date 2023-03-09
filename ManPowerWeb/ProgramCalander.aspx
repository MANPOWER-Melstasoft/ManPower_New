<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgramCalander.aspx.cs" Inherits="ManPowerWeb.ProgramCalander" EnableEventValidation="false" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <asp:ScriptManager runat="server" ID="Scriptmanger1"></asp:ScriptManager>
    <div class="container mb-4">
        <div class="card p-4 m-4">
            <h2><b>Program Calendar</b></h2>
            <div class="mt-4">

                <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#00000"
                    BorderWidth="1px" DayNameFormat="Full" Font-Names="Verdana" Font-Size="14pt"
                    ForeColor="#663399" ShowGridLines="True" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TodayDayStyle BackColor="#1cc88a" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="10px" />
                    <TitleStyle BackColor="#3a60d0" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />

                </asp:Calendar>
            </div>
        </div>
    </div>

</asp:Content>
