Public Class PersonDaysRunUptoBirthDay
    Private Const URLLINK As String = "https://www.historynet.com/today-in-history/"
    Public Sub New(runDate As Date)
        _RunDate = runDate
        _RunDateDayOfWeek = runDate.ToString("dddd")
        _RunDateLink = URLLINK & runDate.ToString("MMMM-dd")
    End Sub
    Public Sub ClearObject()
        Try
            _RunDate = Nothing
            _RunDateDayOfWeek = ""
            _RunDateLink = ""
        Catch ex As Exception
            Return
        End Try
    End Sub
    Public ReadOnly Property RunDate As Date
    Public ReadOnly Property RunDateDayOfWeek As String
    Public ReadOnly Property RunDateLink As String


End Class
