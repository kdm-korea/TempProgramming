
Sub ExecuteDateSave()
    Dim num, name, day, store, carkind, inputKind, workContent As String
    Dim price As Double
    
    num = Range("B6")
    name = CStr(Range("C6"))
    day = CStr(Range("B9"))
    store = Range("C9")
    carkind = Range("D9")
    inputKind = Range("E9")
    price = Range("F9")
    workContent = Trim(Range("B12"))
    
    If (num = vbNullString) Then
        MsgBox "저장되지 않은 고객입니다.", vbOKOnly + vbCritical
        
    ElseIf (name = vbNullString) Then
        MsgBox "고객명은 필수 입력사항입니다.", vbOKOnly + vbCritical
        
    ElseIf (day = vbNullString Or inputKind = vbNullString Or price = Null Or workContent = vbNullString) Then
        MsgBox "일자, 입금분류, 금액, 작업내용은 필수 항목입니다", vbOKOnly + vbInformation
        
    ElseIf (ChkHaveSamePerson(name)) Then
        Call SaveManageSheet(num, name, day, store, carkind, inputKind, price, workContent)
        
        If (inputKind = "미수금" Or inputKind = "미수결제") Then
            Call AddReceivable(name, IIf(inputKind = "미수금", price, price * -1))
        End If
        
        Call ClearContents_InputSheet
        
        MsgBox "완료되었습니다", vbOKOnly + vbInformation
        
    Else
        MsgBox "해당하는 고객의 정보가 없습니다", vbOKOnly + vbCritical
    End If
End Sub

Sub AddReceivable(ByVal name As String, ByVal price As Double)
    Dim rngCells, rngHR As Range
    Dim lastRowNum As Integer
    
    lastRowNum = CallWorksheetEmptyRowNumber("고객관리명단", 3)
    
    With Worksheets("고객관리명단")
        Set rngHR = .Range(.Cells(5, 3), .Cells(lastRowNum, 3))
        
        For Each rngCells In rngHR
            If (rngCells = name) Then
                .Cells(rngCells.Row, 4) = .Cells(rngCells.Row, 4) + price
                Exit For
            End If
        Next
    End With
End Sub

Sub SaveManageSheet(ByVal num As String, ByVal name As String, ByVal day As String, ByVal store As String, ByVal carkind As String, ByVal inputKind As String, ByVal price As Double, ByVal workContent As String)
    Dim rowPos As Integer
    
    With Worksheets("거래관리대장")
        rowPos = CallWorksheetEmptyRowNumber("거래관리대장", 2)
        .Cells(rowPos, 2) = day
        .Cells(rowPos, 3) = store
        .Cells(rowPos, 4) = carkind
        .Cells(rowPos, 5) = workContent
        .Cells(rowPos, 6) = num
        .Cells(rowPos, 7) = name
        .Cells(rowPos, 8) = inputKind
        .Cells(rowPos, 9) = price
    End With
End Sub
