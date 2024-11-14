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

namespace CommunityApp
{
    /// <summary>
    /// Interaction logic for ChangeStatusDialog.xaml
    /// </summary>
    public partial class ChangeStatusDialog : Window
    {
        public string NewStatus { get; private set; }

        public ChangeStatusDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = StatusComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                NewStatus = selectedItem.Content.ToString();
                DialogResult = true; // Set DialogResult to true to indicate OK was clicked
            }
            else
            {
                MessageBox.Show("Please select a status.");
            }
        }
    }
}
