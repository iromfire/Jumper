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
using System.Windows.Shapes;

namespace Попрыженок
{
    /// <summary>
    /// Логика взаимодействия для AddAgent.xaml
    /// </summary>
    public partial class AddAgent : Window
    {
        JumperEntities db = new JumperEntities();
        public AddAgent()
        {
            InitializeComponent();
            comboBoxType.ItemsSource = db.Agent.Select(a => a.Type).ToList().Distinct();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
