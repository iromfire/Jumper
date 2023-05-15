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
using System.Xml.Linq;

namespace Попрыженок
{
    /// <summary>
    /// Логика взаимодействия для Agents.xaml
    /// </summary>
    public partial class Agents : Window
    {
        JumperEntities db = new JumperEntities();
        public Agents()
        {
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            dataGrid.ItemsSource = db.Agent.Select(a => new {
                Наименование = a.Name,
                Тип = a.Type,
                Приоритет = a.Prioritet,
                Телефон = a.Phone              
            }).ToList();
            comboBoxType.ItemsSource= db.Agent.Select(a => a.Type).ToList().Distinct();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string option = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            var agents = db.Agent.Select(a => new
            {
                Наименование = a.Name,
                Тип = a.Type,
                Приоритет = a.Prioritet,
                Телефон = a.Phone
            });
            switch (option)
            {
                case "По наименованию (по возрастанию)":
                    dataGrid.ItemsSource = agents.OrderBy(a => a.Наименование).ToList();
                    break;
                case "По наименованию (по убыванию)":
                    dataGrid.ItemsSource = agents.OrderByDescending(a => a.Наименование).ToList();
                    break;
                case "По приоритету (по возрастанию)":
                    dataGrid.ItemsSource = agents.OrderBy(a => a.Приоритет).ToList();
                    break;
                case "По приоритету (по убыванию)":
                    dataGrid.ItemsSource = agents.OrderByDescending(a => a.Приоритет).ToList();
                    break;
            }
        }

        private void comboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string option = comboBoxType.SelectedItem.ToString();
            var items = db.Agent.ToList().Where(a => a.Type == option);
            dataGrid.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddAgent().Show();
            Close();
        }
    }
}
