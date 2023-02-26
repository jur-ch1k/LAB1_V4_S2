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
using LAB1_V4_S2_CLASSES;

namespace LAB1_V4_S2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ComboBox_CreateMod.ItemsSource = new List<FuncEnum> { FuncEnum.CreateLinGrid, FuncEnum.CreateSqrGrid };
            ComboBox_CreateMod.SelectedItem = FuncEnum.CreateLinGrid;
            Text_nItems.Text = "5";
            Text_Name.Text = "Name";
        }

        private void Btn_Handler(object sender, RoutedEventArgs e) {
            V4DataList list = new V4DataList(Text_Name.Text, DateTime.Now);
            //Text_BaseOutPut.Text = ComboBox_CreateMod.SelectedItem.GetType().ToString();
            list.AddDefaults(int.Parse(Text_nItems.Text), (FuncEnum)ComboBox_CreateMod.SelectedItem);
            List_ListOutPut.ItemsSource = list.DataList;
            Text_BaseOutPut.Text = list.ToString();
        }
    }
}
