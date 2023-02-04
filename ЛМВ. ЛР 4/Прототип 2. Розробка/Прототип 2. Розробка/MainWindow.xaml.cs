using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Прототип_2._Розробка
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsSoundOn = true;
        bool IsVoiceOn = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void How_Click(object sender, RoutedEventArgs e)
        {
            HowDialog howDialog = new HowDialog();
            howDialog.ShowDialog();
            
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog();
        }

        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string what;
            if (Radio1.IsChecked==true)
            {
                what = "2";
            }
            else if (Radio2.IsChecked == true)
            {
                what = "8";
            }
            else
            {
                what = "16";
            }
            File.AppendAllText("history.txt", InputBox.Text + $" | {what} | " + ResultBox.Text + "\n");
            
            if (IsVoiceOn)
            {
                var sound = new SoundPlayer(@"Voices/save.wav");
                sound.Play();
            }

        }

        private void Clear_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            InputBox.Clear();
            ResultBox.Clear();
            Radio1.IsChecked = false;
            Radio2.IsChecked = false;
            Radio3.IsChecked = false;

            if (IsVoiceOn)
            {
                var sound = new SoundPlayer(@"Voices/clear.wav");
                sound.Play();
            }
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (IsSoundOn)
            {
                var sound = new SoundPlayer(@"Sounds/button_sound.wav");
                sound.Play();
            }
            if (Regex.IsMatch(InputBox.Text, @"^\d+$") && (Radio1.IsChecked == true || Radio2.IsChecked == true || Radio3.IsChecked == true))
            {
                
                string number = InputBox.Text;
                int fromBase = 10;
                int toBase;

                
                if (Radio1.IsChecked == true)
                {
                    toBase = 2;
                }
                else if (Radio2.IsChecked == true)
                {
                    toBase = 8;
                }
                else
                {
                    toBase = 16;
                }
                string result = Convert.ToString(Convert.ToInt32(number, fromBase), toBase);
                ResultBox.Text = result;
            }
            else
            {
                MessageBox.Show("Не правильно введено дані", "Помилка");           
            }
            
        }

        private void ChangeOption_Checked(object sender, RoutedEventArgs e)
        {
            if (IsSoundOn)
            {
                var sound = new SoundPlayer(@"Sounds/radio_sound.wav");
                sound.Play();
            }
        }


        private void Sound_Click(object sender, RoutedEventArgs e)
        {
            if (sender == SoundOn)
            {
                SoundOn.IsChecked = true;
                SoundOff.IsChecked = false;
                IsSoundOn = true;
            }
            else
            {
                SoundOn.IsChecked = false;
                SoundOff.IsChecked = true;
                IsSoundOn = false;
                IsVoiceOn = false;
                VoiceOn.IsChecked = false;
                VoiceOff.IsChecked = true;
            }
        }

        private void Voice_Click(object sender, RoutedEventArgs e)
        {
            if (sender == VoiceOn)
            {
                IsVoiceOn = true;
                VoiceOn.IsChecked = true;
                VoiceOff.IsChecked = false;
            }
            else
            {
                IsVoiceOn = false;
                VoiceOn.IsChecked = false;
                VoiceOff.IsChecked = true;
            }
        }

        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();

            if (sender==LightCheck)
            {
                LightCheck.IsChecked = true;
                DarkCheck.IsChecked = false;

                WindowPanel.Background = (Brush)bc.ConvertFrom("#f1f1f2");
                MenuPanel.Background = (Brush)bc.ConvertFrom("#1995ad");
                MenuPanel.Foreground = (Brush)bc.ConvertFrom("#1e1f26");

                Header.Foreground = (Brush)bc.ConvertFrom("#1e1f26");
                InputText.Foreground = (Brush)bc.ConvertFrom("#1e1f26");
                RadioText.Foreground = (Brush)bc.ConvertFrom("#1e1f26");
                ResultText.Foreground = (Brush)bc.ConvertFrom("#1e1f26");

                InputBox.Background = (Brush)bc.ConvertFrom("#a1d6e2");
                InputBox.Foreground = (Brush)bc.ConvertFrom("#1e1f26");

                Button1.Background = (Brush)bc.ConvertFrom("#a1d6e2");


                ResultBox.Background = (Brush)bc.ConvertFrom("#a1d6e2");
                ResultBox.Foreground = (Brush)bc.ConvertFrom("#1e1f26");

                Radio1.Foreground = (Brush)bc.ConvertFrom("#1e1f26");
                Radio2.Foreground = (Brush)bc.ConvertFrom("#1e1f26");
                Radio3.Foreground = (Brush)bc.ConvertFrom("#1e1f26");
                if (IsVoiceOn)
                {
                    var sound = new SoundPlayer(@"Voices/light.wav");
                    sound.Play();
                }

            }
            else
            {
                LightCheck.IsChecked = false;
                DarkCheck.IsChecked = true;
                WindowPanel.Background = (Brush)bc.ConvertFrom("#1e1f26");
                MenuPanel.Background = (Brush)bc.ConvertFrom("#1e1f26");
                MenuPanel.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");

                Header.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");
                InputText.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");
                RadioText.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");
                ResultText.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");

                InputBox.Background = (Brush)bc.ConvertFrom("#283655");
                InputBox.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");

                Button1.Background = (Brush)bc.ConvertFrom("#4d648d");

                ResultBox.Background = (Brush)bc.ConvertFrom("#283655");
                ResultBox.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");

                Radio1.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");
                Radio2.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");
                Radio3.Foreground = (Brush)bc.ConvertFrom("#d0f1e9");
                if (IsVoiceOn)
                {
                    var sound = new SoundPlayer(@"Voices\dark.wav");
                    sound.Play();
                }
            }
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Input | notation | result\n"+File.ReadAllText("history.txt"), "History");
        }
    }
}
