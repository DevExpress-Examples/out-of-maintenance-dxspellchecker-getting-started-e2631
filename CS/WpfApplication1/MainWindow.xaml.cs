#region #code
using System.Windows;
using System.Globalization;
using DevExpress.Xpf.SpellChecker;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        SpellChecker checker;

        public MainWindow()
        {
            DataContext = this;
            checker = new SpellChecker();
            InitializeComponent();
            checker.Culture = new CultureInfo("pl-PL");
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
