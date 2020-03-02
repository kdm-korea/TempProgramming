Sub ExecuteClear_CustomerWorkingContents()
    Range("G3:J4").ClearContents
    MsgBox "삭제되었습니다", vbOKOnly + vbInformation
End Sub

Sub Clear_Contents()
    Range(Cells(11, 2), Cells(CallWorksheetEmptyRowNumber("고객별 매출 및 작업내용", 2), 11)).ClearContents
    Range("G6:G8").ClearContents
    Range("I6:I8").ClearContents
    Range("K6").ClearContents
End Sub

Sub ExecuteCustomerWorkingContents()
    Dim startYear, startMonth, startDay, endYear, endMonth, endDay, name, DB_Name, DB_Day As String
    Dim rngAll, rngMove(10000) As Range
    Dim idx As Integer
    Dim phoneNum, DB_phoneNum As Double
    Dim endDate As Date
    Dim startDate As Date
    
    idx = 1
    startDate = 0
    startYear = Trim(CStr(Range("G3")))
    startMonth = Trim(Range("H3"))
    startDay = Trim(Range("I3"))
    
    endDate = 0
    endYear = Trim(CStr(Range("G4")))
    endMonth = Trim(Range("H4"))
    endDay = Trim(Range("I4"))
    
    name = Trim(Range("J3"))
    
    Call Clear_Contents
    
    ActiveSheet.ListObjects("작업내용검색표").Resize Range("$B$10:$K$11")
    
    If (startYear <> vbNullString) Then
        startDate = DateValue(startYear _
             & "-" & IIf(startMonth <> vbNullString, startMonth, "1") _
             & "-" & IIf(startDay <> vbNullString, startDay, "1"))

        endYear = IIf(endYear <> vbNullString, endYear, startYear)
    
        endMonth = IIf(endMonth <> vbNullString, endMonth, IIf(startMonth <> vbNullString, startMonth, "12"))
     
        endDay = day(DateSerial(endYear, endMonth + 1, IIf(endDay <> vbNullString, endDay, 0)))
        
        endDate = DateValue(endYear & "-" & endMonth & "-" & endDay)
    End If
    
    If (startYear = vbNullString And name = vbNullString) Then
        MsgBox "일자나 이름 중 하나는 무조건 입력하셔야 합니다.", vbOKOnly + vbCritical
        End
    ElseIf (startDate <> 0 And endDate <> 0 And startDate > endDate) Then
        MsgBox "시작일자는 종료일자보다 클 수 없습니다.", vbOKOnly + vbCritical
        End
    End If
    
    Range("B4").Value = "※ 잠시만 기다려주세요 ※"
    
    Call BeforeExecuteFunctionSpeedUp
    
    Set rngAll = CallSheetUsedRange("거래관리대장")

    With Worksheets("거래관리대장")
        For i = 5 To rngAll.Rows.count
            DB_Day = CDate(.Cells(i, 2))
            DB_Name = CStr(.Cells(i, 7).Value)
            
            If (Find_Condition(startDate, endDate, name, DB_Day, DB_Name)) Then
                Set rngMove(idx) = Range(.Cells(i, 2), .Cells(i, 11))
                    idx = idx + 1
            End If
        Next
    End With

    With Worksheets("고객별 매출 및 작업내용")
        For i = 1 To idx - 1
            Range(Cells(10 + i, 2), Cells(10 + i, rngMove(i).Columns.count + 1)) = rngMove(i).Value
        Next
    End With

    ActiveSheet.ListObjects("작업내용검색표").Resize Range(Cells(10, 2), Cells(9 + idx + IIf(idx = 1, 1, 0), 11))
    Columns("B:I").EntireColumn.AutoFit
    
    Call ResultFunction(idx)
    
    Call AfterExecuteFunctionSpeedUp
    
    Range("B11").Select
    
    MsgBox "완료되었습니다.", vbOKOnly + vbInformation
End Sub

Sub ResultFunction(lastRow As Integer)
    Dim str As String
    Dim emptyRowNum As Integer
    
    With Application.WorksheetFunction
        Range("B4").Value = "=A1"
        Range("G6").Value = .SumIf(Range(Cells(11, 8), Cells(lastRow + 10, 8)), "<>미수결제", Range(Cells(11, 9), Cells(lastRow + 10, 9)))
        Range("G8").Value = .SumIf(Range(Cells(11, 8), Cells(lastRow + 10, 8)), "미수결제", Range(Cells(11, 9), Cells(lastRow + 10, 9)))
        Range("I6").Value = .SumIf(Range(Cells(11, 8), Cells(lastRow + 10, 8)), "<>미수금", Range(Cells(11, 9), Cells(lastRow + 10, 9)))
        Range("I8").Value = .Sum(Range(Cells(11, 10), Cells(lastRow + 10, 10)))
        
        
        emptyRowNum = CallWorksheetEmptyRowNumber("고객관리명단", 3)
        
        If (Range("J3") = vbNullString) Then
            str = .Sum(Worksheets("고객관리명단").Range(Worksheets("고객관리명단").Cells(5, 4), Worksheets("고객관리명단").Cells(emptyRowNum, 4)))
            
        Else
            str = .IfError(.VLookup(Range("J3"), _
                    Worksheets("고객관리명단").Range(Worksheets("고객관리명단").Cells(5, 3), Worksheets("고객관리명단").Cells(emptyRowNum, 4)), _
                    2, _
                    False), "")
        End If
         
        Range("K6") = IIf(str = vbNullString, 0, str)
    End With
End Sub

Function Find_Condition(ByVal startDate As Date, ByVal endDate As Date, ByVal name As String, ByVal DB_Day As Date, ByVal DB_Name As String) As Boolean
    If (startDate <> 0 And name <> vbNullString) Then
        Find_Condition = (DB_Day >= startDate) * _
                         (DB_Day <= endDate) * _
                         (DB_Name = name)
        '이름과 일자로 체크
    ElseIf (name <> vbNullString) Then
        Find_Condition = (DB_Name = name)
    ElseIf (startDate <> 0) Then
        Find_Condition = (DB_Day >= startDate) * _
                         (DB_Day <= endDate)
    Else
        Find_Condition = False
    End If
End Function
