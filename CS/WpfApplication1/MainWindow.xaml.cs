#region #code
using System.IO;
using System.Windows;
using System.Reflection;
using System.Globalization;
using DevExpress.Xpf.SpellChecker;
using DevExpress.XtraSpellChecker;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        SpellChecker checker;

        public MainWindow()
        {
            checker = new SpellChecker();
            DataContext = this;

            InitializeComponent();

            // Obtain information about the Polish dictionary from the assembly.
            Stream dict = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("WpfApplication1.Dictionaries.pl_PL.dic");
            Stream grammar = Assembly.GetExecutingAssembly().
                GetManifestResourceStream("WpfApplication1.Dictionaries.pl_PL.aff");

            // Create the dictionary and load information into it.
            SpellCheckerOpenOfficeDictionary dictionary = new SpellCheckerOpenOfficeDictionary();
            dictionary.LoadFromStream(dict, grammar, null);

            // Define the dictionary culture.
            CultureInfo culture = new CultureInfo("pl-PL");
            dictionary.Culture = culture;

            // Add the dictionary to the spell checker's collection.
            checker.Dictionaries.Add(dictionary);

            // Set the default culture of the spell checker.
            checker.Culture = culture;

            // Set as-you-type mode.
            checker.SpellCheckMode = SpellCheckMode.AsYouType;

            SpellChecker = checker;

        }

        public SpellChecker SpellChecker
        {
            get { return checker; }
            private set { checker = value; }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Start checking the text within a text edit control.
            checker.Check(textEdit1);
        }

    }
}
#endregion #code