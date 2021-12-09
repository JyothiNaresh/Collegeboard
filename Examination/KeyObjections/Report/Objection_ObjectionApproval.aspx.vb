'----------------------------------------------------------------------------------------------
'   DESIGN REFERENCE                  : NIMS 1.0
'   OBJECTIVE                         : OBJECTIONS APPROVAL 
'   AUTHOR                            : P.VENU
'   INITIAL BASELINE DATE             : 21.07.2011
'   FINAL BASELINE DATE               : 22.07.2011
'   COMPLETED DATE                    : 24.07.2011
'----------------------------------------------------------------------------------------------
Imports CollegeBoardDLL
Public Class Objection_ObjectionApproval
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents LbsPS As System.Web.UI.WebControls.Label
    Protected WithEvents DgSummary As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DrpExamName As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DrpExamDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtExpandedDivs As System.Web.UI.WebControls.TextBox
    Protected WithEvents IbtnSave As System.Web.UI.WebControls.ImageButton
    Protected WithEvents IbtnCancel As System.Web.UI.WebControls.ImageButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region " -> Form Variables"

    Dim SqlStr As String
    Dim ObjFetchDs As Utility
    Dim objTrans As NOETransaction
    Dim Dset, MaindSet As New DataSet
    Dim StrPaperSetter As Integer

#End Region

#Region " -> Fill Methods"

    Private Sub FillExamNames()
        Try
            SqlStr = "SELECT OBJEXAMSLNO,OBJEXAMNAME FROM OBJECTIONS_EXAMNAME_MT"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            DrpExamName.DataTextField = "OBJEXAMNAME"
            DrpExamName.DataValueField = "OBJEXAMSLNO"
            DrpExamName.DataSource = Dset
            DrpExamName.DataBind()

            FillExamDate()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillExamDate()
        Try
            SqlStr = "SELECT OBJTESTSLNO,TO_CHAR(OBJTESTDATE,'DD/MM/YYYY')||'/'||OBJTESTDESC OBJTESTDATE FROM OBJECTIONS_EXAM_DATE_MAP WHERE OBJEXAMSLNO=" & DrpExamName.SelectedItem.Value
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                DrpExamDate.BackColor = Color.Empty
                DrpExamDate.DataTextField = "OBJTESTDATE"
                DrpExamDate.DataValueField = "OBJTESTSLNO"
                DrpExamDate.DataSource = Dset
                DrpExamDate.DataBind()
                Papersetter()
                FillGrid()
               
            Else
                If DrpExamDate.Items.Count <> 0 Then
                    DrpExamDate.Items.Clear()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillGrid()
        Try
            SqlStr = " SELECT 1 SNO, OBJ.OBJSUBJECTSLNO,SBJ.NAME SBJNAME, OBJ.OBJQUESTIONNO QUESTIONNO,  OBJGIVENKEY,  OBJ.CNT OBJCNT FROM T_SUBJECT_MT SBJ," & _
                     " (SELECT OBJSUBJECTSLNO,OBJGIVENKEY,OBJQUESTIONNO,COUNT(*) CNT FROM OBJECTIONS_OBJECTION_DT WHERE " & _
                     " OBJMTSLNO IN(SELECT OBJMTSLNO FROM OBJECTIONS_OBJECTION_MT WHERE OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value & ") GROUP BY OBJSUBJECTSLNO, OBJGIVENKEY,OBJQUESTIONNO ) OBJ WHERE OBJ.OBJSUBJECTSLNO = SBJ.SUBJECTSLNO"

            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            If Dset.Tables(0).Rows.Count <> 0 Then
                If DgSummary.Visible = False Then
                    DgSummary.Visible = True
                End If
                DgSummary.DataSource = Dset.Tables(0)
                DgSummary.DataBind()
            Else
                DgSummary.Visible = False
            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " -> Methods"

    Private Sub StartUpScript(Optional ByVal focusCtrl As String = "", Optional ByVal strMessage As String = "")
        Try
            If focusCtrl <> "" And strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf strMessage <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript>alert('" & Replace(Replace(strMessage, "'", "\'"), vbCrLf, "") & "' ); </script>")
            ElseIf focusCtrl <> "" Then
                RegisterStartupScript("JavaScript", "<script language=javascript> if (document." & FormName & "." & focusCtrl & " == '[object]') { document." & FormName & "." & focusCtrl & ".focus(); } </script>")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function Papersetter()
        Try
            SqlStr = " SELECT EXAMBRANCHNAME,EXAMBRANCHSLNO FROM EXAM_EXAMBRANCH WHERE EXAMBRANCHSLNO IN (SELECT OBJEXAMPAPERSETTER FROM OBJECTIONS_OBJECTION_MT WHERE OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value & ")"
            ObjFetchDs = New Utility
            Dset = ObjFetchDs.DataSet_OneFetch(SqlStr)
            LbsPS.Text = "PAPER SETTER : " + Dset.Tables(0).Rows(0).Item(0).ToString
            StrPaperSetter = Dset.Tables(0).Rows(0).Item(1)
            Session("StrPaperSetter") = StrPaperSetter
        Catch ex As Exception

        End Try
    End Function

    Private Function DetailQuery(ByVal QueryString As String) As DataSet
        Try
            Dim DsDetails As New DataSet
            ObjFetchDs = New Utility
            DsDetails = ObjFetchDs.DataSet_OneFetch(QueryString)
            Return DsDetails
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function DetailGrid()
        Try
            Dim SubDg As New DataGrid
            SubDg.CssClass = "GridMain"
            SubDg.HeaderStyle.CssClass = "GridHeader"
            SubDg.BackColor = Color.White
            SubDg.BorderColor = Color.Black
            SubDg.HeaderStyle.Height.Pixel(20)
            SubDg.ItemStyle.Height.Pixel(20)

            SubDg.AutoGenerateColumns = False
            SubDg.GridLines = GridLines.Both
            SubDg.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
            SubDg.Width = Unit.Percentage(100)

            Dim Sno As BoundColumn = New BoundColumn
            Dim EB As BoundColumn = New BoundColumn
            Dim LctN As BoundColumn = New BoundColumn
            Dim LctMb As BoundColumn = New BoundColumn
            Dim RefKey As BoundColumn = New BoundColumn
            Dim Rmrk As BoundColumn = New BoundColumn

            MyGridProps(Sno, EB, LctN, LctMb, Rmrk, RefKey)

            SubDg.Columns.Add(Sno)
            SubDg.Columns.Add(EB)
            SubDg.Columns.Add(LctN)
            SubDg.Columns.Add(LctMb)
            SubDg.Columns.Add(RefKey)
            SubDg.Columns.Add(Rmrk)

            Return SubDg

        Catch ex As Exception

        End Try
    End Function

    Private Function MyGridProps(ByVal BC1 As BoundColumn, ByVal BC2 As BoundColumn, ByVal BC3 As BoundColumn, ByVal BC4 As BoundColumn, ByVal BC5 As BoundColumn, ByVal BC6 As BoundColumn)
        Try
            BC1.DataField = "Sno"
            BC1.HeaderText = "Sno"
            BC1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
            BC1.HeaderStyle.VerticalAlign = VerticalAlign.Middle
            BC1.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            BC1.ItemStyle.VerticalAlign = VerticalAlign.Middle

            BC2.DataField = "EB"
            BC2.HeaderText = "ExamBranch"
            BC2.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            BC2.ItemStyle.VerticalAlign = VerticalAlign.Middle

            BC3.DataField = "LctN"
            BC3.HeaderText = "Lect.Name"
            BC3.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            BC3.ItemStyle.VerticalAlign = VerticalAlign.Middle

            BC4.DataField = "LctMb"
            BC4.HeaderText = "Mobile"
            BC4.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            BC4.ItemStyle.VerticalAlign = VerticalAlign.Middle

            BC5.DataField = "RefKey"
            BC5.HeaderText = "Ref.Key"
            BC5.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
            BC5.HeaderStyle.VerticalAlign = VerticalAlign.Middle
            BC5.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            BC5.ItemStyle.VerticalAlign = VerticalAlign.Middle

            BC6.DataField = "Rmrk"
            BC6.HeaderText = "Remarks"
            BC6.ItemStyle.HorizontalAlign = HorizontalAlign.Left
            BC6.ItemStyle.VerticalAlign = VerticalAlign.Middle

        Catch ex As Exception

        End Try
    End Function

    Private Function GridValidation()
        Try
            Dim VDrpAction As DropDownList
            Dim VTBCorAns As TextBox
            Dim VTBGivAns As String
            Dim GridVal As Integer = 0

            For i As Integer = 0 To DgSummary.Items.Count - 1
                VDrpAction = DgSummary.Items(i).Cells(7).Controls(1)
                VTBGivAns = DgSummary.Items(i).Cells(4).Text
                VTBCorAns = DgSummary.Items(i).Cells(8).Controls(1)

                If VDrpAction.SelectedItem.Value = 1 And VTBCorAns.Text = Nothing Then
                    VTBCorAns.BorderColor = Color.Red
                    VTBCorAns.ToolTip = "You Must Enter Correct Answer.."
                    GridVal = 1
                Else
                    VTBCorAns.BorderColor = Color.Empty
                    VTBCorAns.ToolTip = ""
                End If
                If Trim(VTBGivAns) = Trim(VTBCorAns.Text) Then
                    VTBCorAns.BorderColor = Color.Red
                    VTBCorAns.ToolTip = "Given and FinalKey Should not be Same"
                    GridVal = 1
                Else
                    VTBCorAns.BorderColor = Color.Empty
                    VTBCorAns.ToolTip = ""
                End If
            Next

            If GridVal = 1 Then
                StartUpScript("Validation", " Verify Your Selection (Red Marked..!)")
                Return False
            Else
                Return True
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Function GridDataforSave()
        Try
            Dim S_Act, S_Sta As DropDownList
            Dim S_Fk, S_Rem, S_Lect, S_LMob As TextBox
            Dim GridValidation As Boolean = True
            Dim RtnSave, S_Sbj, S_Qno, S_Gk, S_ObCnt, S_ObjMt, AcceptCount As Integer
            StrPaperSetter = Session("StrPaperSetter")

            Dim VDt As New DataTable("GridData")
            Dim VDr As DataRow
            VDt.Columns.Add("USERSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJTESTSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJEXAMPAPERSETTER", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJSUBJECTSLNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJQUESTIONNO", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJGIVENKEY", Type.GetType("System.String"))
            VDt.Columns.Add("OBJCOUNT", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJSTATUS", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJACTION", Type.GetType("System.Int32"))
            VDt.Columns.Add("OBJFINALKEY", Type.GetType("System.String"))
            VDt.Columns.Add("OBJREMARKS", Type.GetType("System.String"))
            VDt.Columns.Add("OBJCOMACADEMICSLNO", Type.GetType("System.Int32"))

            For i As Integer = 0 To DgSummary.Items.Count - 1
                S_Sbj = Val(DgSummary.Items(i).Cells(10).Text)
                S_Qno = Val(DgSummary.Items(i).Cells(3).Text)
                S_Gk = Val(DgSummary.Items(i).Cells(4).Text)
                S_ObCnt = Val(DgSummary.Items(i).Cells(5).Text)
                S_Sta = DgSummary.Items(i).Cells(6).Controls(1)
                S_Act = DgSummary.Items(i).Cells(7).Controls(1)
                S_Fk = DgSummary.Items(i).Cells(8).Controls(1)
                S_Rem = DgSummary.Items(i).Cells(9).Controls(1)

                If S_Sta.SelectedItem.Value = 1 Then
                    VDr = VDt.NewRow
                    VDr("USERSLNO") = Session("USERSLNO")
                    VDr("OBJTESTSLNO") = DrpExamDate.SelectedItem.Value
                    VDr("OBJEXAMPAPERSETTER") = StrPaperSetter
                    VDr("OBJSUBJECTSLNO") = S_Sbj
                    VDr("OBJQUESTIONNO") = S_Qno
                    VDr("OBJGIVENKEY") = S_Gk
                    VDr("OBJCOUNT") = S_ObCnt
                    VDr("OBJSTATUS") = S_Sta.SelectedItem.Value
                    VDr("OBJACTION") = S_Act.SelectedItem.Value
                    If S_Act.SelectedItem.Value = 0 Then
                        VDr("OBJFINALKEY") = "Delete"
                    Else
                        VDr("OBJFINALKEY") = Trim(S_Fk.Text)
                    End If
                    VDr("OBJREMARKS") = Trim(S_Rem.Text)
                    VDr("OBJCOMACADEMICSLNO") = Session("COMACADEMICSLNO")
                    VDt.Rows.Add(VDr)
                    AcceptCount += 1
                End If
            Next

            If AcceptCount <> 0 Then
                MaindSet.Tables.Add(VDt)

                objTrans = New NOETransaction
                RtnSave = objTrans.OBJECTION_FINALKEYINSERT(MaindSet)

                Return RtnSave
            Else
                Return 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region " -> Page Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            If (Session("USERID") Is Nothing) OrElse (Session("USERID") = "") Then
                Response.Write("<script language=Javascript>Javascript:window.open('../../Home.aspx','_top');</script>")
                Exit Sub
            End If

            If Not IsPostBack Then
                FormInfo(Session("USERSLNO"), Session("USERLOGSLNO"), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName)
                FillExamNames()
                FillExamDate()
            Else
                For i As Integer = 0 To Me.DgSummary.Items.Count - 1
                    'After Postback ID's get lost. Javascript will not work without it, 
                    'so we must set them back. 
                    Me.DgSummary.Items(i).Cells(0).ID = "CellInfo" + i.ToString()
                Next
                If Request("__EVENTTARGET") Is Nothing Then
                    Return
                Else
                    Dim strEventTarget As String = Request("__EVENTTARGET").ToString().ToLower()
                    'datagrid1 is the name of the grid. If you modify the grid name, 
                    'make sure to modify this if statement. 
                    'If strEventTarget.IndexOf("DgSummary") = -1 Then
                    '    If Not Page.IsStartupScriptRegistered("ShowDataJS") Then
                    '        Page.RegisterStartupScript("ShowDataJS", "<script>ShowExpandedDivInfo('" + Me.txtExpandedDivs.ClientID + "','" + Me.DgSummary.ClientID + "');</script>")
                    '    End If
                    'End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " -> DropDown Events"

    Private Sub DrpExamName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamName.SelectedIndexChanged
        Try
            FillExamDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DrpExamDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpExamDate.SelectedIndexChanged
        Try
            FillGrid()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " -> Grid Dynamic DropDown Events"

    Protected Sub DrpStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim ddllist As DropDownList = CType(sender, DropDownList)
            Dim cell As TableCell = CType(ddllist.Parent, TableCell)
            Dim item As DataGridItem = CType(cell.Parent, DataGridItem)
            Dim content As String = item.ItemIndex
            Dim ddlStatus As DropDownList = CType(item.Cells(6).FindControl("DrpStatus"), DropDownList)
            Dim ddlAction As DropDownList = CType(item.Cells(7).FindControl("DrpAction"), DropDownList)

            If ddlStatus.SelectedItem.Value = 1 Then
                ddlAction.Enabled = True
            Else
                ddlAction.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DrpAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim ddllist As DropDownList = CType(sender, DropDownList)
            Dim cell As TableCell = CType(ddllist.Parent, TableCell)
            Dim item As DataGridItem = CType(cell.Parent, DataGridItem)
            Dim content As String = item.ItemIndex
            Dim ddlAction As DropDownList = CType(item.Cells(7).FindControl("DrpAction"), DropDownList)
            Dim TBCorAns As TextBox = CType(item.Cells(8).FindControl("TxtCorAns"), TextBox)
            Dim TBRemarks As TextBox = CType(item.Cells(9).FindControl("TxtGRem"), TextBox)

            If ddlAction.SelectedItem.Value = 1 Then
                TBCorAns.Enabled = True
                TBRemarks.Enabled = True
            Else
                TBCorAns.Enabled = False
                TBRemarks.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " -> Grid Events"

    Private Sub DgSummary_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DgSummary.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

                Dim DetailsQuery As String = " SELECT EB.EXAMBRANCHNAME EB, OBJDT.OBJLECTURER LctN,OBJDT.OBJLECTMOBILE LctMb, OBJDT.OBJCORRECTKEY RefKey, OBJDT.OBJREMARKS Rmrk,ROW_NUMBER() OVER (ORDER BY EB.EXAMBRANCHNAME) AS SNO " & _
                                             " FROM OBJECTIONS_OBJECTION_DT OBJDT,OBJECTIONS_OBJECTION_MT OBJMT,EXAM_EXAMBRANCH EB " & _
                                             " WHERE OBJMT.OBJEBSLNO = EB.EXAMBRANCHSLNO AND OBJDT.OBJMTSLNO = OBJMT.OBJMTSLNO AND OBJDT.OBJTESTSLNO=" & DrpExamDate.SelectedItem.Value & " AND OBJDT.OBJSUBJECTSLNO = '" & e.Item.Cells(10).Text & "' AND OBJDT.OBJQUESTIONNO='" & e.Item.Cells(3).Text + "' ORDER BY EB.EXAMBRANCHNAME"

                Dim dsDet As DataSet = Me.DetailQuery(DetailsQuery)
                Dim DetailGd As DataGrid = DetailGrid()
                DetailGd.DataSource = dsDet
                DetailGd.DataBind()

                Dim sw As New System.IO.StringWriter
                Dim htw As New System.Web.UI.HtmlTextWriter(sw)
                DetailGd.RenderControl(htw)

                Dim DivStart As String = "<DIV id='uniquename" + e.Item.ItemIndex.ToString() + "' style='DISPLAY: none;'>"
                Dim DivBody As String = sw.ToString()
                Dim DivEnd As String = "</DIV>"
                Dim FullDIV As String = DivStart + DivBody + DivEnd

                Dim LastCellPosition As Integer = e.Item.Cells.Count - 1
                Dim NewCellPosition As Integer = e.Item.Cells.Count - 2

                e.Item.Cells(0).ID = "CellInfo" + e.Item.ItemIndex.ToString()

                If e.Item.ItemType = ListItemType.Item Then
                    e.Item.Cells(LastCellPosition).Text() = e.Item.Cells(LastCellPosition).Text + "</td><tr><td bgcolor='f5f5f5'></td><td colspan='" + NewCellPosition.ToString() + "'>" + FullDIV
                Else
                    e.Item.Cells(LastCellPosition).Text = e.Item.Cells(LastCellPosition).Text + "</td><tr><td bgcolor='d3d3d3'></td><td colspan='" + NewCellPosition.ToString() + "'>" + FullDIV
                End If

                e.Item.Cells(0).Attributes("onclick") = "HideShowPanel('uniquename" + e.Item.ItemIndex.ToString() + "'); ChangePlusMinusText('" + e.Item.Cells(0).ClientID + "'); SetExpandedDIVInfo('" + e.Item.Cells(0).ClientID + "','" + Me.txtExpandedDivs.ClientID + "', 'uniquename" + e.Item.ItemIndex.ToString() + "');"
                e.Item.Cells(0).Attributes("onmouseover") = "this.style.cursor='pointer'"
                e.Item.Cells(0).Attributes("onmouseout") = "this.style.cursor='pointer'"

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " -> IBtn Events"

    Private Sub IbtnSave_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IbtnSave.Click
        Try
            If GridValidation() Then
                Dim Result As Integer = GridDataforSave()
                If Result <> 0 Then
                    StartUpScript(IbtnSave.ID, " Data Inserted Successfully..!")
                Else
                    StartUpScript(IbtnSave.ID, " Accepted Objections '0'")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
