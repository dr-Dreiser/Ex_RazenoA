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

namespace Ex_RazenoA
{
    /// <summary>
    /// Логика взаимодействия для AutorizPage.xaml
    /// </summary>
    public partial class AutorizPage : Page
    {
        public AutorizPage()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //Видела, что в БД появилась таблица "Пользователи", но в проекте эта таблица не отразилась, так что вот...
            if(LoginAuto.Text=="admin" && PassAuto.Text == "admin")
            {
                ClassFrame.MF.Navigate(new ShopPage());
            }
            else
            {
                MessageBox.Show("Пользователя нет в системе");
            }
        }
    }
}
