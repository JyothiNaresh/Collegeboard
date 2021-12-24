<%@ Page Language="vb" AutoEventWireup="false" Codebehind="KeyObj_Combinations.aspx.vb" Inherits="CollegeBoard.KeyObj_Combinations" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>KeyObj_Combinations</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK id="Link1" rel="stylesheet" type="text/css" href="../../Images/Login/StyleSheet_Report.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server" autocomplete="off">
			<TABLE id="Table0" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table1" class="Panel" border="0" cellSpacing="0" cellPadding="0">
								<TR>
									<TD align="center">
										<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0">
											<TR>
												<TD class="DarkColor">
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-lcorw.gif" width="11" height="11"></TD>
															<TD class="SubHeading"><asp:label id="lblHeading" runat="server" Width="570px" Font-Bold="True" CssClass="SubHeading1"> Combinations for Key Objections Mapping </asp:label></TD>
															<TD vAlign="top" width="11"><IMG src="../../Images/Login/table-rcorw.gif" width="11" height="11"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="TdBorder"><IMG src="../../Images/Login/spacer.gif" width="1" height="1"></TD>
											</TR>
											<TR>
												<TD class="TableBorder" vAlign="top" align="center">
													<TABLE id="Table25" border="0" cellSpacing="0" cellPadding="0" align="center">
														<TR>
															<TD>
																<TABLE id="Table9" border="0" cellSpacing="0" cellPadding="1" width="100%" align="center">
																	<TR>
																		<TD><asp:label id="Label5" runat="server" Width="100%" CssClass="Lables">User&nbsp;Types&nbsp;*</asp:label></TD>
																		<TD style="WIDTH: 136px"><asp:dropdownlist id="DrpUserTypes" runat="server" Width="154px" CssClass="DropDownList"></asp:dropdownlist></TD>
																		<TD><asp:label id="Label6" runat="server" Width="100%" CssClass="Lables">Academic Year</asp:label></TD>
																		<TD style="WIDTH: 125px"><asp:dropdownlist id="drpAcaSlno" runat="server" Width="153px" CssClass="DropDownList"></asp:dropdownlist></TD>
																		<TD><asp:imagebutton accessKey="E" id="iBtnSearch" runat="server" Width="100%" ImageUrl="../../Images/NewImages/search.gif"></asp:imagebutton></TD>
																	</TR>
																</TABLE>
														<tr>
														</tr>
														<TR>
															<TD align="center"><asp:checkbox id="chkUser" runat="server" CssClass="Lables" Text="Users" AutoPostBack="True"></asp:checkbox></TD>
														</TR>
														<TR>
															<TD align="center"><asp:checkboxlist id="chklStuType" runat="server" Width="112px" CssClass="Lables" RepeatColumns="5"></asp:checkboxlist></TD>
														</TR>
														<tr>
														</tr>
														<TR>
															<TD align="center"><asp:checkbox id="chkAreaTypes" runat="server" Width="122px" CssClass="Lables" Text="Area Types"
																	AutoPostBack="True"></asp:checkbox></TD>
														</TR>
														<TR>
															<TD align="center"><asp:checkboxlist id="chklAreaType" runat="server" CssClass="Lables" RepeatColumns="6"></asp:checkboxlist></TD>
														</TR>
														<TR>
															<TD align="center"><asp:imagebutton accessKey="G" id="ibtGo" runat="server" Height="20px" Width="40px" CssClass="button"
																	ImageUrl="../../Images/NewImages/go.gif" BorderStyle="None"></asp:imagebutton></TD>
														</TR>
												</TD>
											</TR>
											<tr>
											</tr>
											<TR>
												<TD vAlign="middle" align="center"><asp:checkbox id="chkBranchs" runat="server" CssClass="Lables" Text="Combination Keys" AutoPostBack="True"></asp:checkbox></TD>
											</TR>
											<TR>
												<TD vAlign="middle" align="center"></TD>
											</TR>
											<TR>
												<TD align="center">
													<asp:checkboxlist id="chklBranch" runat="server" CssClass="Lables" RepeatColumns="3"></asp:checkboxlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableBorder" vAlign="middle" align="right"><asp:imagebutton accessKey="S" id="iBtnSave" tabIndex="5" runat="server" Width="92px" Height="20px"
											ImageUrl="../../Images/NewImages/save.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
										<asp:imagebutton accessKey="C" id="iBtnCancel" tabIndex="6" runat="server" Width="92px" Height="20px"
											ImageUrl="../../Images/NewImages/cancel.gif"></asp:imagebutton></TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
						</TD>
					</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
