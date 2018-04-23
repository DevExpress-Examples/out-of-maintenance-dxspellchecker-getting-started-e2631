#Region "#code"
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
            checker = New SpellChecker()
            DataContext = Me

            InitializeComponent()

            ' Obtain information about the Polish dictionary from the assembly.
            Dim dict As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Dictionaries.pl_PL.dic")
            Dim grammar As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Dictionaries.pl_PL.aff")

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

            ' Set as-you-type mode.
            checker.SpellCheckMode = SpellCheckMode.AsYouType

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