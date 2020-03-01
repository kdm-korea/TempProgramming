Sub BeforeExecuteFunctionSpeedUp()
    Application.ScreenUpdating = False
    
    Application.DisplayStatusBar = False
    
    Application.Calculation = xlCalculationManual
    
    Application.EnableEvents = False
End Sub
    
Sub AfterExecuteFunctionSpeedUp()
    Application.ScreenUpdating = True

    Application.DisplayStatusBar = True
    
    Application.Calculation = xlCalculationAutomatic
    
    Application.EnableEvents = True
End Sub

Function CallWorksheetEmptyRowNumber(ByVal sheetName As String, ByVal columnIdx As Integer) As Integer
    CallWorksheetEmptyRowNumber = Worksheets(sheetName).Cells(Rows.count, columnIdx).End(xlUp).Row + 1
End Function

Function CallSheetUsedRange(ByVal sheetName As String) As Range
    With Worksheets(CStr(sheetName)).UsedRange
        Set CallSheetUsedRange = .Offset(1).Resize(.Rows.count)
    End With
End Function

Function ChkHaveSamePerson(ByVal name As String) As Boolean
    Dim rngName, rngNames As Range
    
    Set rngNames = Worksheets("고객관리명단").Range("C5:C1000")
    
    For Each rngName In rngNames
        If (rngName = name) Then
            ChkHaveSamePerson = True
            Exit For
        ElseIf (rngName = "") Then
            ChkHaveSamePerson = False
            Exit For
        End If
    Next
End Function
