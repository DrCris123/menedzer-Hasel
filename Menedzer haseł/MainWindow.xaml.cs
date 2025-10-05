using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Menedzer_haseł
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string NumberChars = "0123456789";
        private const string SymbolChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";
        private const string SimilarChars = "0Ol1";

        public MainWindow()
        {
            InitializeComponent();
            GeneratePassword();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            GeneratePassword();
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordTextBox.Text) && PasswordTextBox.Text != "Kliknij 'Generuj' aby utworzyć hasło")
            {
                Clipboard.SetText(PasswordTextBox.Text);
                MessageBox.Show("Hasło zostało skopiowane do schowka!", "Skopiowano", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LengthLabel != null)
            {
                LengthLabel.Text = ((int)e.NewValue).ToString();
                if (PasswordTextBox != null && PasswordTextBox.Text != "Kliknij 'Generuj' aby utworzyć hasło")
                {
                    GeneratePassword();
                }
            }
        }

        private void GeneratePassword()
        {
            try
            {
                string charSet = BuildCharacterSet();
                
                if (string.IsNullOrEmpty(charSet))
                {
                    MessageBox.Show("Musisz wybrać przynajmniej jeden typ znaków!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int length = (int)LengthSlider.Value;
                string password = GenerateSecurePassword(charSet, length);
                
                PasswordTextBox.Text = password;
                UpdatePasswordStrength(password);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas generowania hasła: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string BuildCharacterSet()
        {
            StringBuilder charSet = new StringBuilder();

            if (UppercaseCheckBox?.IsChecked == true)
                charSet.Append(UppercaseChars);
            
            if (LowercaseCheckBox?.IsChecked == true)
                charSet.Append(LowercaseChars);
            
            if (NumbersCheckBox?.IsChecked == true)
                charSet.Append(NumberChars);
            
            if (SymbolsCheckBox?.IsChecked == true)
                charSet.Append(SymbolChars);

            string result = charSet.ToString();

            // Usuń podobne znaki jeśli opcja jest zaznaczona
            if (ExcludeSimilarCheckBox?.IsChecked == true)
            {
                foreach (char similarChar in SimilarChars)
                {
                    result = result.Replace(similarChar.ToString(), "");
                }
            }

            return result;
        }

        private string GenerateSecurePassword(string charSet, int length)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                StringBuilder password = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    password.Append(charSet[randomBytes[i] % charSet.Length]);
                }

                return password.ToString();
            }
        }

        private void UpdatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                StrengthProgressBar.Value = 0;
                StrengthLabel.Text = "Brak";
                StrengthProgressBar.Foreground = new SolidColorBrush(Colors.Gray);
                return;
            }

            int score = CalculatePasswordStrength(password);
            
            StrengthProgressBar.Value = score;
            
            if (score < 25)
            {
                StrengthLabel.Text = "Bardzo słabe";
                StrengthProgressBar.Foreground = new SolidColorBrush(Colors.Red);
            }
            else if (score < 50)
            {
                StrengthLabel.Text = "Słabe";
                StrengthProgressBar.Foreground = new SolidColorBrush(Colors.Orange);
            }
            else if (score < 75)
            {
                StrengthLabel.Text = "Średnie";
                StrengthProgressBar.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else if (score < 90)
            {
                StrengthLabel.Text = "Silne";
                StrengthProgressBar.Foreground = new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                StrengthLabel.Text = "Bardzo silne";
                StrengthProgressBar.Foreground = new SolidColorBrush(Colors.Green);
            }
        }

        private int CalculatePasswordStrength(string password)
        {
            int score = 0;
            
            // Długość
            if (password.Length >= 8) score += 10;
            if (password.Length >= 12) score += 10;
            if (password.Length >= 16) score += 10;
            if (password.Length >= 20) score += 10;

            // Różnorodność znaków
            if (password.Any(char.IsUpper)) score += 15;
            if (password.Any(char.IsLower)) score += 15;
            if (password.Any(char.IsDigit)) score += 15;
            if (password.Any(c => SymbolChars.Contains(c))) score += 15;

            // Brak powtarzających się znaków
            if (password.Distinct().Count() == password.Length) score += 10;

            return Math.Min(score, 100);
        }
    }
}