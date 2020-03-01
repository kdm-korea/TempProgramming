Sub ExecuteClearContents()
    Call ClearContents_InputSheet
    MsgBox "삭제가 완료되었습니다.", vbOKOnly + vbInformation
End Sub

Sub ExecuteAddCustomer()
    Dim name As String

    name = CStr(Range("C6"))

    If (name = vbNullString) Then
        MsgBox "고객명은 필수 요소입니다", vbOKOnly + vbCritical
        End
        
    ElseIf (MsgBox("정말 추가하시겠습니까?", vbOKCancel + vbQuestion) = vbCancel) Then
        MsgBox "취소되었습니다", vbOKOnly + vbInformation
        End
        
    ElseIf (ChkHaveSamePerson(name)) Then
        MsgBox "이미 해당 고객의 정보가 있습니다.", vbOKOnly + vbCritical
        End
        
    Else
        Call BeforeExecuteFunctionSpeedUp
        
        Call AddCustomer(name)
        
        Call AfterExecuteFunctionSpeedUp
        
        MsgBox "완료되었습니다", vbOKOnly + vbInformation
    End If
End Sub

Private Sub AddCustomer(ByVal name As String)
    Dim rowPos As Integer
    
    With Worksheets("고객관리명단")
        rowPos = .Cells(Rows.count, 3).End(xlUp).Row + 1
        .Cells(rowPos, 3) = name
    End With
End Sub

Sub ClearContents_InputSheet()
    Range("C6").ClearContents
    Range("B9:F9").ClearContents
    Range("B12:F12").ClearContents
End Sub
