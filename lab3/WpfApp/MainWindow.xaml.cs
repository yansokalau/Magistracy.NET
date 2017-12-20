using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private AddStudent addStudentPopup = new AddStudent();

        public MainWindow()
        {
            InitializeComponent();
            RedrawCollection();

            addStudentPopup.Closed += (o, args) => RedrawCollection();
        }

        private void RedrawCollection()
        {
            int maxMark;
            int.TryParse(txtMaxMark.Text, out maxMark);
            if (maxMark > 10)
            {
                maxMark = 10;
            }
            else if (maxMark < 1)
            {
                maxMark = 1;
            }

            IEnumerable<StudentData> collection = App.storage.GetList();
            dataGrid.ItemsSource = (from student in collection
                                    where maxMark >= student.TestMark
                                    select student);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            RedrawCollection();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            addStudentPopup.Show();
        }
    }
}
