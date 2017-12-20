using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var student = new StudentData()
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                TestDate = testDatePicker.SelectedDate != null ? testDatePicker.SelectedDate.Value.Date : System.DateTime.Now,
                TestName = txtTestName.Text,
                TestMark = (int)sliderMark.Value
            };

            App.storage.AddAndSaveItem(student);

            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
