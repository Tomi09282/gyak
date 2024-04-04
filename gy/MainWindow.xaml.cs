using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFelveszWrap_Click(object sender, RoutedEventArgs e) // létrehozás gomb
        {

            if (VanE() == false) //false -> nincs benne ilyen nev -> felveheto az element
            {
                if (rdoButton.IsChecked == true) // gomb
                {
                    Button btn = new Button(); // Button element letrehozasa
                    btn.Content = txtNev.Text; // szovegmezoben levo text beallitasa

                    wpPanel.Children.Add(btn); // element hozzaadasa

                }
                if (rdoTextBlock.IsChecked == true) // textblock
                {
                    TextBlock tb = new TextBlock(); // TextBlock element letrehozasa
                    tb.Text = txtNev.Text; // szovegmezoben levo text beallitasa 
                    tb.Background = new SolidColorBrush(Colors.Red);
                    wpPanel.Children.Add(tb); // element hozzaadasa

                }
            } else
            {
                MessageBox.Show("Már van ilyen nevu element");
            }
        }


        private bool VanE()
        {
            foreach (object? element in wpPanel.Children) // Elementek a wrappanel-ben (? -> lehet null(nincs ertek) is -> nem huzza ala)
            {
                if (element is Button) //gomb (kuldo)
                {
                    if ((string)(element as Button).Content == txtNev.Text) // element Gombként véve, annak a neve egyezik e a textboxxal
                    {
                        return true; // truet ad vissza -> van ilyen nev
                    }
                }

                if (element is TextBlock) //textblock
                {
                    if ((element as TextBlock).Text == txtNev.Text) // element TextBlock ként véve, annak a neve egyezik e a textboxxal
                    {
                        return true; // truet ad vissza -> van ilyen nev
                    }
                }
            }
        return false; // false -> Nincs benne ilyen nev
        }

        private void btnLetrehozGrid_Click(object sender, RoutedEventArgs e)
        {
            grdPanel.RowDefinitions.Clear(); // Minden gombra nyomáskor alaphelyzet visszaállítása
            grdPanel.ColumnDefinitions.Clear();

            for (int i = 0; i < sliSor.Value; i++) // annyiszor ad hozzá amennyi a sliSor értéke
            {
                grdPanel.RowDefinitions.Add(new RowDefinition()); // Sor hozzááadása a gridhez
            }

            for (int i = 0; i < sliOszlop.Value; i++) // annyiszor ad hozzá amennyi a sliOszlop értéke
            {
                grdPanel.ColumnDefinitions.Add(new ColumnDefinition()); // oszlop hozzáadása a gridhez
            }
        }

        private void btnFelveszGrid_Click(object sender, RoutedEventArgs e)
        {
            if (VanE() == false)
            {
                if (rdoButton.IsChecked == true) // gomb
                {
                    Button btn = new Button(); // Button element letrehozasa
                    btn.Content = txtNev.Text; // szovegmezoben levo text beallitasa
                    Grid.SetColumn(btn, int.Parse(txtOszlop.Text)-1); // btn elementnek az oszlop helye (-1 -> 1 esetén 0s indexbe)
                    Grid.SetRow(btn, int.Parse(txtSor.Text)-1); // btn elementnek a sor helye
                    grdPanel.Children.Add(btn); // element hozzaadasa

                }
                if (rdoTextBlock.IsChecked == true) // textblock
                {
                    TextBlock tb = new TextBlock(); // TextBlock element letrehozasa
                    tb.Text = txtNev.Text; // szovegmezoben levo text beallitasa 
                    tb.Background = new SolidColorBrush(Colors.Red);
                    Grid.SetColumn(tb, int.Parse(txtOszlop.Text)-1); // tb elementnek az oszlop helye
                    Grid.SetRow(tb, int.Parse(txtSor.Text)-1); // tb elementnek a sor helye
                    grdPanel.Children.Add(tb); // element hozzaadasa
                }
            }
        }
    }
}