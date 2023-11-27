Imports System.Environment
Public Class Person
    Public ReadOnly Property PersonFirstName As String
    Public ReadOnly Property PersonLastName As String
    Public ReadOnly Property PersonDoB As Date
    Public ReadOnly Property VowelsInName As String
    Public ReadOnly Property PersonWelcomeMessage As String
    Public ReadOnly Property PersonAge As String
    Public ReadOnly Property PersonDaysBeforeNextBDay As String
    Public ReadOnly Property PersonRunUptoDOBs As Collection
    Public ReadOnly Property ErrorMessage As String
    Public ReadOnly Property RunUptoCaption As String

    Private Const RUNUPTOBDAY As Int16 = 14

    Public Sub New(firstName As String, lastName As String, birthDate As Date)
        Try
            _ErrorMessage = ""

            If firstName.Trim = "" Then _ErrorMessage = "Blank First Name not allowed." & NewLine
            If lastName.Trim = "" Then _ErrorMessage &= "Blank Last Name not allowed." & NewLine
            If Not IsDate(birthDate) Then _ErrorMessage &= "Invalid date of birth provided."
            If _ErrorMessage <> "" Then Return

            _PersonFirstName = firstName
            _PersonLastName = lastName
            _PersonDoB = birthDate

            _VowelsInName = HowManyVowels()
            _PersonWelcomeMessage = GetPersonWelcomeMessage()

            PersonAge = GetAgeAsFormattedText()
            PersonDaysBeforeNextBDay = CalculateDaysBeforeNextBDay()
            If RUNUPTOBDAY > 1 Then
                _RunUptoCaption = String.Format("Your {0} days run upto your birthday has the following history.", RUNUPTOBDAY)
            Else
                _RunUptoCaption = String.Format("Your {0} day run upto your birthday has the following history.", RUNUPTOBDAY)
            End If

            CreatePersonRunUptoDOBs()
            Return
        Catch ex As Exception
            AddToError(ex.Message)
            Return
        End Try
    End Sub

    Private Function HowManyVowels() As String
        Try
            Dim vowels() As Char = {"a", "e", "i", "o", "u", "A", "E", "I", "O", "U"}
            Dim totalCount As Integer = (_PersonFirstName & " " & _PersonLastName).Count(Function(c) vowels.Contains(c))
            Dim howManyVowelsAsString As String = "There are {0} vowels in your name." & NewLine
            Dim secondLine As String = ""

            howManyVowelsAsString = String.Format(howManyVowelsAsString, totalCount)

            If totalCount > 0 Then
                Dim x As Char
                For Each x In (_PersonFirstName & " " & _PersonLastName).ToCharArray
                    If vowels.Contains(x) Then
                        secondLine &= "[" & x & "]"
                    Else
                        secondLine &= x
                    End If
                Next
            End If

            Return howManyVowelsAsString & secondLine
        Catch ex As Exception
            AddToError(ex.Message)
            Return ""
        End Try
    End Function

    Private Function GetPersonWelcomeMessage() As String
        Try
            Dim welcomeMessage As String = "Hello {0}, welcome to your date of birth analysis."

            Return String.Format(welcomeMessage, _PersonFirstName)
        Catch ex As Exception
            AddToError(ex.Message)
            Return ""
        End Try
    End Function

    Private Function GetAgeAsFormattedText() As String
        Try
            Dim yearValue As Int16
            Dim monthValue As Int16
            Dim dayValue As Int16
            Dim ageAsText As String

            ageAsText = ""

            yearValue = Date.Now.Year - _PersonDoB.Year
            If (Date.Now.Month >= _PersonDoB.Month) Then
                monthValue = Date.Now.Month - _PersonDoB.Month
            Else
                monthValue = Date.Now.Month - _PersonDoB.Month + 12
            End If

            If (Date.Now.Day >= _PersonDoB.Day) Then
                dayValue = Date.Now.Day - _PersonDoB.Day
            Else
                monthValue -= 1
                dayValue = Date.Now.Day + (DateTime.DaysInMonth(_PersonDoB.Year, _PersonDoB.Month) - _PersonDoB.Day)
            End If

            If yearValue = 0 Then
                If monthValue = 0 Then
                    If dayValue = 0 Then
                        ageAsText = "You are born today! Happy Birthday."
                    End If
                End If
            End If

            Dim yearAsText As String = ""
            Dim monthAsText As String = ""
            Dim dayAsText As String = ""

            Select Case yearValue
                Case 0
                    yearAsText = ""
                Case 1
                    yearAsText = String.Format("{0} year", yearValue)
                Case Else
                    yearAsText = String.Format("{0} years", yearValue)
            End Select

            If yearAsText <> "" Then monthAsText = " "

            Select Case monthValue
                Case 0
                    monthAsText = ""
                Case 1
                    monthAsText &= String.Format("{0} month", monthValue)
                Case Else
                    monthAsText &= String.Format("{0} months", monthValue)
            End Select

            If ((yearAsText <> "") Or (monthAsText <> "")) Then
                dayAsText = " and "
            End If

            Select Case dayValue
                Case 0
                    dayAsText = ""
                Case 1
                    dayAsText &= String.Format("{0} day", dayValue)
                Case Else
                    dayAsText &= String.Format("{0} days", dayValue)
            End Select

            If ageAsText = "" Then ageAsText = String.Format("Your age is {0}{1}{2}", yearAsText, monthAsText, dayAsText)
            Return ageAsText
        Catch ex As Exception
            AddToError(ex.Message)
            Return ""
        End Try
    End Function

    Private Function CalculateDaysBeforeNextBDay() As String
        Try
            Dim nextBirthday As Date = GetNextBirthDay()
            Dim daysTillNextBDay As Int16

            daysTillNextBDay = nextBirthday.Subtract(Date.Now).Days
            If daysTillNextBDay > 1 Then
                Return String.Format("You have {0} days to your next birthday.", daysTillNextBDay)
            Else
                Return String.Format("You have {0} day to your next birthday.", daysTillNextBDay)
            End If

        Catch ex As Exception
            AddToError(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub CreatePersonRunUptoDOBs()
        Try
            Dim nextBirthday As Date = GetNextBirthDay()
            Dim runUptoCurrentDate As Date
            Dim runUptoBirthDay As PersonDaysRunUptoBirthDay

            _PersonRunUptoDOBs = New Collection

            For i As Int16 = RUNUPTOBDAY To 1 Step -1
                runUptoCurrentDate = nextBirthday.AddDays(-i)
                runUptoBirthDay = New PersonDaysRunUptoBirthDay(runUptoCurrentDate)
                _PersonRunUptoDOBs.Add(runUptoBirthDay)
            Next
        Catch ex As Exception
            AddToError(ex.Message)
            Return
        End Try
    End Sub

    Private Sub AddToError(errorMessage As String)
        Try
            _ErrorMessage &= errorMessage & NewLine
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Function GetNextBirthDay() As Date
        Try
            Dim currentYearBirthDay As Date
            Dim nextBirthday As Date

            currentYearBirthDay = New Date(Date.Now.Year, _PersonDoB.Month, _PersonDoB.Day)

            If (Date.Now >= currentYearBirthDay) Then
                nextBirthday = New Date(Date.Now.Year + 1, _PersonDoB.Month, _PersonDoB.Day)
            Else
                nextBirthday = currentYearBirthDay
            End If
            Return nextBirthday
        Catch ex As Exception
            AddToError(ex.Message)
            Return (New Date(vbNull))
        End Try
    End Function

End Class
