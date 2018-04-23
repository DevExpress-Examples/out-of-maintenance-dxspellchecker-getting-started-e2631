Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Windows
Imports System.Reflection
Imports System.Globalization
Imports DevExpress.Xpf.SpellChecker
Imports DevExpress.XtraSpellChecker

Namespace WpfApplication1
	Partial Public Class MainWindow
		Inherits Window
		Private checker As SpellChecker
		Public Sub New()
			InitializeComponent()
			checker = New SpellChecker()

			' Obtain information about the Polish dictionary from the assembly.
            Dim dict As Stream = System.Reflection.Assembly.GetExecutingAssembly(). _
                GetManifestResourceStream("pl_PL.dic")
            Dim grammar As Stream = System.Reflection.Assembly.GetExecutingAssembly(). _
                GetManifestResourceStream("pl_PL.aff")

			' Create the dictionary and load information into it.
			Dim dictionary As New SpellCheckerOpenOfficeDictionary()
			dictionary.LoadFromStream(dict, grammar, Nothing)

			' Define the dictionary culture.
			Dim culture As New CultureInfo("pl-PL")
			dictionary.Culture = culture

			' Add the dictionary to the spell checker's collection.
			checker.Dictionaries.Add(dictionary)

			' Set the default culture of the spell checker.
			checker.Culture = culture
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Start checking the text within a text edit control.
			checker.Check(textEdit1)
		End Sub
	End Class
End Namespace
