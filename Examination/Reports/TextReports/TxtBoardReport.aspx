<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TxtBoardReport.aspx.vb" Inherits="CollegeBoard.TxtBoardReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>TxtSectionWiseReportNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK id="Link1" href="../../../Images/Login/StyleSheet_Report.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" type="text/javascript" src="../../Include/Report.js"></script>
	    <style type="text/css">
            .auto-style1 {
                width: 81px;
            }
            .auto-style2 {
                width: 180px;
            }
            #Table3 {
                width: 257px;
            }
            .auto-style3 {
                width: 129px;
            }
        </style>
	</HEAD>
	<body onscroll="javascript:setcoords()" topMargin="0" onload="javascript:ScrollIt()" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 8px" cellSpacing="0"
				cellPadding="0" align="center" border="0">
				<TR>
					<TD class="DarkColor" style="HEIGHT: 11px">
						<TABLE id="Table13" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="WIDTH: 12px" vAlign="top" width="12"><IMG height="11" src="../../../Images/Login/table-lcorw.gif" width="11"></TD>
								<TD class="SubHeading1" vAlign="middle" align="center">Board Students Information 
									Report</TD>
								<TD vAlign="top" width="11"><IMG height="11" src="../../../Images/Login/table-rcorw.gif" width="11"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 202px" vAlign="top" align="center" colSpan="4">
						<TABLE id="Table12" cellSpacing="0" cellPadding="0" border="1">
							<TR>
								<TD vAlign="middle" align="center" colSpan="9">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="91" border="0">
										<TR>
											<TD nowrap="nowrap"><asp:radiobutton id="rdbDivision" runat="server" Text="Division" AutoPostBack="True" GroupName="0"
													Checked="True" CssClass="Lables"></asp:radiobutton></TD>
											<TD nowrap="nowrap"><asp:radiobutton id="rdbRegion" runat="server" Text="Region" GroupName="0" CssClass="Lables" Visible="False"
													Enabled="False" EnableViewState="False"></asp:radiobutton></TD>
											<TD nowrap="nowrap"><asp:radiobutton id="rdbZone" runat="server" Text="Zone" AutoPostBack="True" GroupName="0" CssClass="Lables"></asp:radiobutton></TD>
											<TD nowrap="nowrap"><asp:radiobutton id="rdbDos" runat="server" Text="VC" AutoPostBack="True" GroupName="0" CssClass="Lables"></asp:radiobutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center" colSpan="9">
									<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="169" border="0">
										<TR>
											<TD nowrap="nowrap"><asp:label id="lblRZ" runat="server" CssClass="Lables" Width="48px"> Division</asp:label></TD>
											<TD nowrap="nowrap"><asp:dropdownlist id="drpRZ" runat="server" AutoPostBack="True" CssClass="DropDownList" Width="150px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><asp:label id="Label10" runat="server" CssClass="Lables" Width="100%">Exam Branch</asp:label></TD>
								<TD></TD>
								<TD><asp:label id="Label3" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></TD>
								<TD>
									<asp:label id="Label1" runat="server" CssClass="Lables" Width="100%">Course</asp:label></TD>
								<TD></TD>
								<TD>
									<asp:label id="Label5" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></TD>
								<TD>
									<asp:label id="Label13" runat="server" CssClass="Lables" Width="100%">Board Code</asp:label></TD>
								<TD></TD>
								<TD>
									<asp:label id="Label2" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top"><asp:listbox id="LSTExamBranch" runat="server" CssClass=" " Width="140px" Height="150px" Rows="100"
										SelectionMode="Multiple"></asp:listbox></TD>
								<TD vAlign="top">
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="30" border="0">
										<TR>
											<TD><asp:imagebutton id="BtnSelEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD><asp:imagebutton id="BtnSelEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD><asp:imagebutton id="BtnRemEB" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD><asp:imagebutton id="BtnRemEBAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top"><asp:listbox id="LSTSelEBranch" runat="server" CssClass=" " Width="140px" Height="150px" Rows="100"
										SelectionMode="Multiple"></asp:listbox></TD>
								<TD vAlign="top">
									<asp:listbox id="LstCourse" runat="server" CssClass=" " Width="140px" SelectionMode="Multiple"
										Rows="100" Height="150px"></asp:listbox></TD>
								<TD vAlign="top">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="30" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelCourse" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelCourseAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemCourse" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemCourseAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top">
									<asp:listbox id="LstSelCourse" runat="server" CssClass=" " Width="140px" SelectionMode="Multiple"
										Rows="100" Height="150px"></asp:listbox></TD>
								<TD vAlign="top">
									<asp:listbox id="LSTBoardCode" runat="server" CssClass=" " Width="140px" SelectionMode="Multiple"
										Rows="100" Height="150px"></asp:listbox></TD>
								<TD>
									<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="30" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelBoardCode" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelBoardCodeAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemBoardCode" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemBoardCodeAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top">
									<asp:listbox id="LSTSelBoardCode" runat="server" CssClass=" " Width="140px" SelectionMode="Multiple"
										Rows="100" Height="150px"></asp:listbox></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:label id="Label4" runat="server" CssClass="Lables" Width="100%">Board District</asp:label></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top">
									<asp:label id="Label8" runat="server" CssClass="Lables" Width="100%">Selected</asp:label></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top"></TD>
								<TD></TD>
								<TD vAlign="top"></TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<asp:listbox id="LSTBoardDist" runat="server" CssClass=" " Width="140px" SelectionMode="Multiple"
										Rows="20" Height="150px"></asp:listbox></TD>
								<TD vAlign="top">
									<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="30" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelBoardDist" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Select.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnSelBoardDistAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/SelectAll.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemBoardDist" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/Remove.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="BtnRemBoardDistAll" runat="server" Width="30px" Height="30px" ImageUrl="../../../Images/NewImages/RemoveAll.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top">
									<asp:listbox id="LSTSelBoardDist" runat="server" CssClass=" " Width="140px" SelectionMode="Multiple"
										Rows="20" Height="150px"></asp:listbox></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top"></TD>
								<TD vAlign="top"></TD>
								<TD></TD>
								<TD vAlign="top"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="center" colSpan="4">
						<TABLE id="Table17" cellSpacing="1" cellPadding="1" width="100%" border="1">
						</TABLE>
						<TABLE id="Table3" border="1">
							<TR>
								<TD class="auto-style3">
									<asp:checkbox id="ChkAdmNo" runat="server" CssClass="Lables" Text="Adm&amp;nbsp;No" Width="247%"></asp:checkbox></TD>
								<TD class="auto-style2">
									<asp:checkbox id="ChkBoardAdmNo" runat="server" CssClass="Lables" Text="Board&amp;nbsp;AdmNo"
										Width="97%"></asp:checkbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
                <tr>
                    <td align="center">
                        <table class="auto-style1">
                            <tr>
                                <td>
									<asp:label id="Label14" runat="server" CssClass="Lables" Width="100px">Format</asp:label></td>
                                <td>
                                    <asp:DropDownList ID="drpFormat" runat="server">
                                        <asp:ListItem Selected="True" Value="1">Admissions</asp:ListItem>
                                        <asp:ListItem Value="2">Reservations</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
									<asp:label id="Label6" runat="server" CssClass="Lables" Width="100px">Format</asp:label></td>
                                <td>
                                    <asp:DropDownList ID="drpCode" runat="server">
                                        <asp:ListItem Selected="True" Value="1">Branch Wise</asp:ListItem>
                                        <asp:ListItem Value="2">Code Wise</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
									<asp:label id="Label7" runat="server" CssClass="Lables" Width="100px">Order</asp:label></td>
                                <td>
                                    <asp:DropDownList ID="drpOrder" runat="server">
                                        <asp:ListItem Selected="True" Value="1">ADMNO</asp:ListItem>
                                        <asp:ListItem Value="2">NAME</asp:ListItem>
                                        <asp:ListItem Value="3">PRV_HTNO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
				<TR>
					<TD vAlign="top" align="right" colSpan="4"><asp:textbox id="PageY" runat="server" Visible="false" Width="0px"></asp:textbox><asp:textbox id="PageX" runat="server" Visible="false" Width="0px"></asp:textbox><asp:imagebutton id="iBtnReport" runat="server" Width="80px" Height="20px" ImageUrl="../../../Images/NewImages/report.gif"></asp:imagebutton></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
