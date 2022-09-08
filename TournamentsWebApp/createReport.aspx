<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createReport.aspx.cs" Inherits="TournamentsWebApp.createReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Report</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="text-center">Create report</h1>
            <h2>Filter by tournament</h2>
            <hr />
            <div class="d-flex flex-row justify-content-between">
                    <div class="col-5">
                        <lable for="startDate">Start date</lable>
                        <asp:TextBox ID="startDate" type="date" CssClass="form-control" runat="server" required/>
                    </div>

                    <br />

                    <div class="col-5">
                        <lable for="startDate">End date</lable>
                        <asp:TextBox ID="endDate" type="date" CssClass="form-control" runat="server" required/>
                    </div>
                </div>
            <div>
                <div>                   
                            <div>
                                <label for="game">Game</label>
                                <asp:DropDownList ID="game" CssClass="form-control" runat="server" />
                            </div>
                            <div>
                                <label for="platform">platform</label>
                                <asp:DropDownList ID="platform" CssClass="form-control" runat="server" />
                            </div>
                        <div/>
                    </div>
                <div class="d-flex flex-row justify-content-between">
                        <div class="col-5">
                            <lable for="minParticipants">Minimum participants</lable>
                            <asp:TextBox ID="minParticipants" type="number" CssClass="form-control" runat="server" min="4" max="64" step="2" value="4"/>
                        </div>

                        <br />

                        <div class="col-5">
                            <lable for="maxParticipants">Maximum Participants</lable>
                            <asp:TextBox ID="maxParticipants" type="number" CssClass="form-control" runat="server" min="4" max="64" step="2" value="4"/>
                        </div>
                    </div>
                <div>
                    <label for="venue">Select venue:</label>
                    <asp:DropDownList ID="venue" CssClass="form-control" runat="server" />
                </div>
            </div>

            <asp:CheckBox ID="summerizedReport" CssClass="form-check-input mt-2" Text="Summerized report" runat="server" />

            <div class="d-flex justify-content-center mt-4">
                <asp:Button ID="btnGenerateReport" Text="Generate report" CssClass="btn-outline-primary col-3 p-2 rounded" runat="server" OnClick="btnGenerateReport_Click"/>
            </div>
            <hr />
                <h2>View report</h2>
            <hr />
            <asp:Label CssClass="text-lg-center" runat="server" ID="reportTitle" Text=""/>

            <asp:GridView ID="dgvData" CssClass="table-responsive-lg" runat="server"></asp:GridView>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>   
    </form>
</body>
</html>
