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
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        List<Книги> BooksList = DataClass.DataShop.Книги.ToList();
        List<Книги> BooksList_Zakaz = new List<Книги>();

        int i = -1;

        int count_book_zakaz = 0;
        double price_zakaz = 0;
        int discount_zakaz = 0;
        public ShopPage()
        {
            InitializeComponent();
            DG_Books.ItemsSource = BooksList;
            DG_BookZ.ItemsSource = BooksList_Zakaz;
        }
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            i++;
            if (i < BooksList.Count)
            {
                MediaElement img = (MediaElement)sender;
                Книги book = BooksList[i];
                string path1 = BooksList[i].Обложка;
                Uri PathImg = new Uri(path1, UriKind.RelativeOrAbsolute);
                img.Source = PathImg;
            }
        }
        private void NameBook_Initialized(object sender, EventArgs e)
        {
            if (i < BooksList.Count)
            {
                TextBlock TBNameBook = (TextBlock)sender;
                Книги book = BooksList[i];
                TBNameBook.Text = "Название: " + book.Название;
            }

        }
        private void PositionBook_Initialized(object sender, EventArgs e)
        {
            if(i < BooksList.Count)
            {
                StackPanel SPPositionBook = (StackPanel)sender;
                Книги book = BooksList[i];
            }
        }
       
        
        private void AutorBook_Initialized(object sender, EventArgs e)
        {
            if (i < BooksList.Count)
            {
                TextBlock TBAutorBook = (TextBlock)sender;
                Книги book = BooksList[i];
                TBAutorBook.Text = "Автор: " + book.Авторы.Автор;
            }
        }

        private void PriceBook_Initialized(object sender, EventArgs e)
        {
            if (i < BooksList.Count)
            {
                TextBlock TBPriceBook = (TextBlock)sender;
                Книги book = BooksList[i];
                TBPriceBook.Text = "Цена: " + Convert.ToString(book.Цена) + " руб.";
            }
        }

        private void CountInShop_Initialized(object sender, EventArgs e)
        {
            if (i < BooksList.Count)
            {
                TextBlock TBCountInShop = (TextBlock)sender;
                Книги book = BooksList[i];
                TBCountInShop.Text = "Наличие в магазине: " + Convert.ToString(book.Количество_магазин);
            }
        }

        private void CountInSklad_Initialized(object sender, EventArgs e)
        {
            if (i < BooksList.Count)
            {
                TextBlock TBCountInSklad = (TextBlock)sender;
                Книги book = BooksList[i];
                TBCountInSklad.Text = "Наличие на складе: " + Convert.ToString(book.Количество_склад);
            }
        }

        private void AddInKorzina_Initialized(object sender, EventArgs e)
        {
            Button BAdd = (Button)sender;
            if(BAdd != null)
            {
                BAdd.Uid = Convert.ToString(i);
            }
        }

        private void DeleteInKorzina_Initialized(object sender, EventArgs e)
        {
            Button BDel = (Button)sender;
            if (BDel != null)
            {
                BDel.Uid = Convert.ToString(i);
            }
        }

        private void AddInKorzina_Click(object sender, RoutedEventArgs e)
        {
            Button BAdd = (Button)sender;
            int index = Convert.ToInt32(BAdd.Uid);
            BooksList_Zakaz.Add(BooksList[index]);
            count_book_zakaz = BooksList_Zakaz.Count;
            TB_CountBook.Text = "Количество выбранных книг: " + Convert.ToString(count_book_zakaz);
            price_zakaz += BooksList[index].Цена;
            TB_PriceSum.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
            if(discount_zakaz== 0)
            {
                TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
            }
            //double rez = price_zakaz / 500;
            if (price_zakaz > 500 )
            {
                discount_zakaz += 1;
                TB_Discount.Text = "Скидка составила: " + discount_zakaz + " %";
                TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
                TB_PriceSum.Text = Convert.ToString(price_zakaz - ((price_zakaz * discount_zakaz) / 100));
            }
            if ((3 <= count_book_zakaz) && (count_book_zakaz < 5) )
            {
                discount_zakaz = 5;
                TB_Discount.Text = "Скидка составила: " + discount_zakaz + " %";
                TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
                TB_PriceSum.Text = Convert.ToString(price_zakaz - ((price_zakaz * discount_zakaz) / 100));
                if (price_zakaz > 500)
                {
                    discount_zakaz += 1;
                    TB_Discount.Text = "Скидка составила: " + discount_zakaz + " %";
                    TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
                    TB_PriceSum.Text = Convert.ToString(price_zakaz - ((price_zakaz * discount_zakaz) / 100));
                }
            }
            if( (5 <= count_book_zakaz) && (count_book_zakaz <10))
            {
                discount_zakaz = 15;
                TB_Discount.Text = "Скидка составила: " + discount_zakaz + " %";
                TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
                TB_PriceSum.Text = Convert.ToString(price_zakaz - ((price_zakaz * discount_zakaz) / 100));
                if (price_zakaz > 500)
                {
                    discount_zakaz += 1;
                    TB_Discount.Text = "Скидка составила: " + discount_zakaz + " %";
                    TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
                    TB_PriceSum.Text = Convert.ToString(price_zakaz - ((price_zakaz * discount_zakaz) / 100));
                }
            }
            if (10 <= count_book_zakaz)
            {
                discount_zakaz = 25;
                TB_Discount.Text = "Скидка составила: " + discount_zakaz + " %";
                TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
                TB_PriceSum.Text = Convert.ToString(price_zakaz - ((price_zakaz * discount_zakaz) / 100));
                if (price_zakaz > 500)
                {
                    discount_zakaz += 1;
                    TB_Discount.Text = "Скидка составила: " + discount_zakaz + " %";
                    TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz);
                    TB_PriceSum.Text = Convert.ToString(price_zakaz - ((price_zakaz * discount_zakaz) / 100));
                }
            }

        }

        private void DeleteInKorzina_Click(object sender, RoutedEventArgs e)
        {
            Button BAdd = (Button)sender;
            int index = Convert.ToInt32(BAdd.Uid);
            BooksList_Zakaz.Remove(BooksList[index]);
            count_book_zakaz = BooksList_Zakaz.Count;
            TB_CountBook.Text = "Количество выбранных книг: " + Convert.ToString(count_book_zakaz);
            TB_FalsePriceSumm.Text = "Цена покупки: " + Convert.ToString(price_zakaz - BooksList[index].Цена);


        }

        private void Otpravit_Click(object sender, RoutedEventArgs e)
        {
           
                MessageBox.Show("Закз отправлен");
                BooksList_Zakaz = null;
                TB_CountBook.Text = " ";
                TB_FalsePriceSumm.Text = " ";
                TB_PriceSum.Text = " ";
                TB_Discount.Text = " ";
                DG_BookZ = null;
            
        }
    }
}
