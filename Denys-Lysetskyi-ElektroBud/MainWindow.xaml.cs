using Denys_Lysetskyi_ElektroBud.Models;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace Denys_Lysetskyi_ElektroBud
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Product> _products = new();

        private int _nextProductId = 1;

        public MainWindow()
        {
            InitializeComponent();

            ProductsGrid.ItemsSource = _products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string unit = UnitTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Wprowadź nazwę produktu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(unit))
            {
                unit = "szt.";
            }

            if (!TryReadNumber(QuantityTextBox.Text, out decimal quantity)
                || quantity < 0)
            {
                MessageBox.Show("Podaj prawidłową ilość początkową.");
                return;
            }

            if (!TryReadNumber(MinimumTextBox.Text, out decimal minimum)
                || minimum < 0)
            {
                MessageBox.Show("Podaj prawidłowy stan minimalny.");
                return;
            }

            if (!TryReadNumber(PriceTextBox.Text, out decimal price)
                || price < 0)
            {
                MessageBox.Show("Podaj prawidłową cenę.");
                return;
            }

            Product product = new Product
            {
                Id = _nextProductId++,
                Name = name,
                Unit = unit,
                Quantity = quantity,
                MinimumQuantity = minimum,
                Price = price
            };

            _products.Add(product);

            NameTextBox.Clear();
            QuantityTextBox.Clear();
            MinimumTextBox.Clear();
            PriceTextBox.Clear();
            UnitTextBox.Text = "szt.";
        }

        private void Receive_Click(object sender, RoutedEventArgs e)
        {
            ChangeStock(true);
        }

        private void Issue_Click(object sender, RoutedEventArgs e)
        {
            ChangeStock(false);
        }

        private void ChangeStock(bool isReceipt)
        {
            if (ProductsGrid.SelectedItem is not Product product)
            {
                MessageBox.Show("Najpierw wybierz produkt z tabeli.");
                return;
            }

            if (!TryReadNumber(
                    OperationQuantityTextBox.Text,
                    out decimal quantity)
                || quantity <= 0)
            {
                MessageBox.Show("Podaj ilość większą od zera.");
                return;
            }

            if (!isReceipt && quantity > product.Quantity)
            {
                MessageBox.Show(
                    "Brak wystarczającej ilości produktu w magazynie.");
                return;
            }

            product.Quantity += isReceipt ? quantity : -quantity;

            ProductsGrid.Items.Refresh();

            OperationQuantityTextBox.Clear();

            MessageBox.Show(
                isReceipt
                    ? "Przyjęcie produktu zakończone."
                    : "Wydanie produktu zakończone.");
        }

        private static bool TryReadNumber(
            string text,
            out decimal value)
        {
            text = text.Trim().Replace(',', '.');

            return decimal.TryParse(
                text,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out value);
        }
    }
}