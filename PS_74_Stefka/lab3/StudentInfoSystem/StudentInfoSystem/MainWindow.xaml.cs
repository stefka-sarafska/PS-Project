using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;


namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StudentData.addStudents();

        }

        private void DisableAllControl(object sender, RoutedEventArgs e)
        {
            
            Panel mainContainer = (Panel)this.Content;
            UIElementCollection element = mainContainer.Children;
            List<FrameworkElement> lstElement = element.Cast<FrameworkElement>().ToList();
            var lstControl = lstElement.OfType<Control>();

            foreach (Control control in lstControl)
            {
                if (!(control is Button))
                {
                    control.IsEnabled = false;
                }
            }
        }
        private void ClearAllControl(object sender, RoutedEventArgs e)
        {

            Panel mainContainer = (Panel)this.Content;
            UIElementCollection element = mainContainer.Children;
            List<FrameworkElement> lstElement = element.Cast<FrameworkElement>().ToList();
            var lstControl = lstElement.OfType<Control>();

            foreach (Control control in lstControl)
            {
                if (control is TextBox)
                {
                    TextBox texBox = (TextBox)control; 
                    texBox.Clear();
                }
            }
        }
        private void EnableAllControl(object sender, RoutedEventArgs e)
        {

            Panel mainContainer = (Panel)this.Content;
            UIElementCollection element = mainContainer.Children;
            List<FrameworkElement> lstElement = element.Cast<FrameworkElement>().ToList();
            var lstControl = lstElement.OfType<Control>();

            foreach (Control contol in lstControl)
            {
                contol.IsEnabled = true;
            }
        }

        public void PopulateData(object sender, RoutedEventArgs e)
        {
            String studentName = txtName.Text;
           foreach(Student student in StudentData.getStudents()) {
                if (studentName.Equals(student.firstName)) { 
            txtName.Text = student.firstName;
            txtMiddlename.Text = student.middleName;
            txtLastname.Text = student.lastName;
            txtFaculty.Text = student.faculty;
            txtSpeciality.Text = student.speciality;
            txtOKS.Text = student.degree;
            txtStatus.Text = student.status;
            txtFacNumber.Text = student.facultyNumber.ToString();
            txtCourse.Text = student.course.ToString();
            txtStream.Text = student.stream.ToString();
            txtGroup.Text = student.group.ToString();
                }
            }
        }
    }
}
