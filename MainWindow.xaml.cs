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

namespace gamerpc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rendeles(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IsNameValid())
                {
                    return;
                }

                int age = Convert.ToInt32(Age.Text);
                if (age <= 13)
                {
                    MessageBox.Show("Az életkor nem lehet 14-nél kisebb!");
                    Age.Focus();
                    return;
                }
                if (age >= 120)
                {
                    MessageBox.Show("Az életkor nem lehet 120-nál nagyobb!");
                    Age.Focus();
                    return;
                }


                if (!IsEmailValid())
                {
                    return;
                }

                if (!IsCPUValid())
                {
                    return;
                }
                if (!IsGPUValid())
                {
                    return;
                }
                if (!IsRAMValid())
                {
                    return;
                }

                if(!IsDarabValid())
                {
                    return;
                }
                if(!IsTermsValid())
                {
                    return;
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Az életkor mezőbe számot kell írni!");
                Age.Focus();
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Az életkor mezőbe túl nagy számot írtál!");
                Age.Focus();
                return;
            }

            SikeresRendeles();
        }

        private bool IsNameValid()
        {
            string name = Name.Text;

            if (name == null || name == "")
            {
                MessageBox.Show("A név nem lehet üres!");
                Name.Focus();
                return false;
            }
            if (name.Length < 3)
            {
                MessageBox.Show("A névnek legalább 3 karakter hosszúnak kell lennie!");
                Name.Focus();
                return false;
            }



            return true;
        }

        private bool IsEmailValid()
        {
            string email = Email.Text;
            if (email == null || email == "")
            {
                MessageBox.Show("Az email nem lehet üres!");
                Email.Focus();
                return false;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("Az email címnek tartalmaznia kell '@' jelet!");
                Email.Focus();
                return false;
            }
            if (!email.Contains("."))
            {
                MessageBox.Show("Az email címnek tartalmaznia kell '.' jelet!");
                Email.Focus();
                return false;

            }
            if (email.Contains(" "))
            {
                MessageBox.Show("Az email cím nem tartalmazhat szóközt!");
                Email.Focus();
                return false;
            }

            return true;
        }

        private bool IsCPUValid()
        {
            string cpu = Processor.Text;
            if (cpu == null || cpu == "")
            {
                MessageBox.Show("Válasszon processzort!");
                Processor.Focus();
                return false;
            }
            return true;
        }

        private bool IsGPUValid()
        {
            if (!(GPU1.IsChecked == true || GPU2.IsChecked == true || GPU3.IsChecked == true))
            {
                MessageBox.Show("Válasszon videókártyát!");
                GPU1.Focus();
                return false;
            }
            return true;

        }

        private bool IsRAMValid()
        {
            if (!(RAM1.IsChecked == true || RAM2.IsChecked == true || RAM3.IsChecked == true))
            {
                MessageBox.Show("Válasszon memóriát!");
                RAM1.Focus();
                return false;
            }
            return true;

        }

        private bool IsDarabValid()
        {

            try
            {
                int darab = Convert.ToInt32(Darab.Text);
                if (darab < 1 || darab > 5)
                {
                    MessageBox.Show("A darabszám 1 és 5 között legyen!");
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("A darabszám mezőbe számot kell írni!");
                Darab.Focus();
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("A darabszám mezőbe túl nagy számot írtál!");
                Darab.Focus();
                return false;
            }




            return true;
        }

        private bool IsTermsValid()
        {
            if (Feltetel.IsChecked == false)
            {
                MessageBox.Show("El kell fogadni a feltételeket!");
                Feltetel.Focus();
                return false;
            }
            return true;
        }

        private int Pricecalc()
        {
            int price = 0;

            if (Processor.SelectedIndex == 0)
            {
                price += 70000;

            }
            else if (Processor.SelectedIndex == 1)
            {
                price += 110000;
            }
            else if (Processor.SelectedIndex == 2)
            {
                price += 65000;
            }
            else if (Processor.SelectedIndex == 3)
            {
                price += 105000;
            }


            if (GPU1.IsChecked == true)
            {
                price += 130000;
            }
            else if (GPU2.IsChecked == true)
            {
                price += 220000;
            }
            else if (GPU3.IsChecked == true)
            {
                price += 400000;
            }


            if (RAM1.IsChecked == true)
            {
                price += 20000;
            }
            else if (RAM2.IsChecked == true)
            {
                price += 35000;
            }
            else if (RAM3.IsChecked == true)
            {
                price += 65000;
            }

            if(Extra1.IsChecked == true)
            {
                price += 15000;
            }
            else if (Extra2.IsChecked == true)
            {
                price += 45000;
            }
            else if (Extra3.IsChecked == true)
            {
                price += 25000;
            }
            else if (Extra4.IsChecked == true)
            {
                price += 18000;
            }

            if (Gari1.IsChecked == true)
            {
                price += 0;
            }
            else if (Gari2.IsChecked == true)
            {
                price += 30000;
            }
            else if (Gari3.IsChecked == true)
            {
                price += 60000;
            }

            int darab = Convert.ToInt32(Darab.Text);
            price *= darab;

            return price;
        }

        private void SikeresRendeles()
        {
            string processzor = "";
            if (Processor.SelectedIndex == 0)
            {
                processzor ="Intel Core i5";

            }
            else if (Processor.SelectedIndex == 1)
            {
                processzor = "Intel Core i7";
            }
            else if (Processor.SelectedIndex == 2)
            {
                processzor = "AMD Ryzen 5";
            }
            else if (Processor.SelectedIndex == 3)
            {
                processzor = "AMD Ryzen 5";
            }

            int price = Pricecalc();
            string videokartya = "";
            if (GPU1.IsChecked == true)
            {
                videokartya= "RTX 4060";
            }
            else if (GPU2.IsChecked == true)
            {
                videokartya = "RTX 4070";
            }
            else if (GPU3.IsChecked == true)
            {
                videokartya = "RTX 4080";
            }



            string memoria = "";
            if (RAM1.IsChecked == true)
            {
                memoria = "16 GB";
            }
            else if (RAM2.IsChecked == true)
            {
                memoria = "32 GB";
            }
            else if (RAM3.IsChecked == true)
            {
                memoria = "64 GB";
            }

            string extrak = "";
            if (Extra1.IsChecked == true)
            {
                extrak += "RGB világítás ";
            }
            if (Extra1.IsChecked == true)
            {
                extrak += "Windows 11 ";
            }
            if (Extra1.IsChecked == true)
            {
                extrak += "Gamer billentyűzet ";
            }
            if (Extra1.IsChecked == true)
            {
                extrak += "Gamer egér ";
            }

            string garancia = "";
            if (Gari1.IsChecked == true)
            {
                garancia = "1 év";
            }
            else if (Gari2.IsChecked == true)
            {
                garancia = "3 év";
            }
            else if (Gari3.IsChecked == true)
            {
                garancia = "5 év";
            }

            int ar = Pricecalc();
            string stringar = "";

            if (ar>=500000)
            { 
                ar= (int)(ar * 0.95);
                stringar = ar.ToString();
                stringar+= " Ft (5% kedvezmény)";
            }
            else
            {
                stringar = ar.ToString();
                stringar += " Ft";
            }


            int sorszam= r.Next(0, 10000);

            MessageBox.Show($"Sikeres rendelés!\nNév: {Name.Text}\nE-mail: {Email.Text}\nProcesszor: {processzor}\nVideókártya: {videokartya}\nMemória: {memoria}\nDarabszám: {Darab.Text}\nExtrák: {extrak}\nGarancia: {garancia}\n\nFizetendő: {stringar}\nRendelési azonosító: {sorszam}");
        }
    }
}