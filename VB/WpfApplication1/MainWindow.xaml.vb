#Region "#code"
Imports System.Windows
Imports System.Globalization
Imports DevExpress.Xpf.SpellChecker

Namespace WpfApplication1
	Partial Public Class MainWindow
		Inherits Window

		Private checker As SpellChecker

		Public Sub New()
			DataContext = Me
			checker = New SpellChecker()
			InitializeComponent()
			checker.Culture = New CultureInfo("pl-PL")
			SpellChecker = checker
		End Sub

		Public Property SpellChecker() As SpellChecker
			Get
				Return checker
			End Get
			Private Set(ByVal value As SpellChecker)
				checker = value
			End Set
		End Property

		Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Start checking the text within a text edit control.
			checker.Check(textEdit1)
		End Sub
	End Class
End Namespace
#End Region ' #code
