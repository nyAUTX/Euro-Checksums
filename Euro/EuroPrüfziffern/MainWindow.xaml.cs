using ServiceReference1;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace EuroPrüfziffern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly Service1Client _client = new(Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);


        public MainWindow()
        {
            InitializeComponent();
            Dictionary<string, string> languages = _client.GetAllLanguages();

            languageBox.ItemsSource = languages;
            languageBox.DisplayMemberPath = "Value"; // zb: Deutsch
            languageBox.SelectedValuePath = "Key"; // zb: deu
            languageBox.SelectedIndex = 0;

            SetOld("clear");
            SetNew("clear");
            SetTexts();
        }

        #region Texts

        private void SetTexts()
        {
            window.Title = GetText("title");
            oldTitle.Content = GetText(oldTitle.Name);
            newTitle.Content = GetText(newTitle.Name);
            oldDescription.Content = GetText(oldDescription.Name);
            newDescription.Content = GetText(newDescription.Name);
            serialNo1.Content = GetText("serialNo") + ":";
            serialNo2.Content = GetText("serialNo") + ":";
            printeryCode1.Content = GetText("printeryCode") + ":";
            printeryCode2.Content = GetText("printeryCode") + ":";
            checkButtonOld.Content = GetText("checkButton");
            checkButtonNew.Content = GetText("checkButton");
            changeLanguage.Content = GetText(changeLanguage.Name) + ":";
        }

        private string GetText(string desc)
        {
            return _client.getMessage(desc, languageBox.SelectedValue.ToString());
        }

        #endregion

        private void languageBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetOld("clear");
            SetNew("clear");
            SetTexts();
        }

        #region old Euro

        private void checkButtonOld_Click(object sender, RoutedEventArgs e)
        {
            oldResults.Content = "";
            if (!_client.CheckOldSerialFormat(serialNoOld.Text))
            {
                oldResults.Content = GetText("error") + ": " + GetText("serialFormatError") + "\n";
            }

            if (!_client.CheckPrinteryFormat(printeryCodeOld.Text))
            {
                oldResults.Content += GetText("error") + ": " + GetText("printeryFormatError") + "\n";
            }

            if (!oldResults.Content.Equals(""))
            {
                SetOld("error");
                return;
            }

            if (_client.CheckOldSerial(serialNoOld.Text))
            {
                Printery printery = _client.getOldPrintery(printeryCodeOld.Text, languageBox.SelectedValue.ToString());
                var country = _client.getCountry(serialNoOld.Text, languageBox.SelectedValue.ToString());
                if (printery.Name != null && country != null)
                {
                    SetOld("valid");
                    oldResults.Content += GetText("oldCountryResult") + ": " + country + "\n";
                    oldResults.Content += GetText("oldPrinteryResult") + ": ";
                    oldResults.Content += printery.Name + " (" + printery.City + ", " + printery.Country + ")\n";

                    if (printery.Circulation) return;

                    SetOld("warning");
                    oldResults.Content += GetText("warning") + ": " + GetText("circulationWarning");
                }
                else
                {
                    SetOld("error");
                    oldResults.Content = GetText("error") + ": " + GetText("noDataError");
                }
            }

            else
            {
                SetOld("error");
                oldResults.Content += GetText("error") + ": " + GetText("serialInvalidError");
            }
        }

        private void SetOld(string type)
        {
            switch (type)
            {
                case "error":
                    oldGroupBox.Header = GetText("invalidSerial");
                    ColorZoneAssist.SetBackground(oldGroupBox, Brushes.Red);
                    break;
                case "valid":
                    oldGroupBox.Header = GetText("validSerial");
                    ColorZoneAssist.SetBackground(oldGroupBox, Brushes.Green);
                    break;
                case "warning":
                    ColorZoneAssist.SetBackground(oldGroupBox, Brushes.Orange);
                    break;
                case "clear":
                    ColorZoneAssist.SetBackground(oldGroupBox, Brushes.DodgerBlue);
                    oldResults.Content = "";
                    oldGroupBox.Header = GetText("info");
                    break;
            }
        }

        #endregion

        #region new Euro

        private void checkButtonNew_Click(object sender, RoutedEventArgs e)
        {
            newResults.Content = "";
            if (!_client.CheckNewSerialFormat(serialNoNew.Text))
            {
                newResults.Content = GetText("error") + ": " + GetText("serialFormatError") + "\n";
            }

            if (!_client.CheckPrinteryFormat(printeryCodeNew.Text))
            {
                newResults.Content += GetText("error") + ": " + GetText("printeryFormatError") + "\n";
            }

            else if (!serialNoNew.Text.ToUpper()[0].Equals(printeryCodeNew.Text.ToUpper()[0]))
            {
                newResults.Content += GetText("error") + ": " + GetText("codeMatchError") + "\n";
            }

            if (!newResults.Content.Equals(""))
            {
                SetNew("error");
                return;
            }

            if (_client.CheckNewSerial(serialNoNew.Text))
            {
                Printery printery = _client.getNewPrintery(printeryCodeNew.Text, languageBox.SelectedValue.ToString());
                if (printery.Country != null)
                {
                    SetNew("valid");
                    newResults.Content += GetText("newResult") + ": \n";
                    newResults.Content += printery.Name + "\n" + printery.City + ", " + printery.Country + "\n";
                    if (printery.Circulation) return;
                    SetNew("warning");
                    newResults.Content += GetText("warning") + ": " + GetText("circulationWarning");
                }
                else
                {
                    SetNew("error");
                    newResults.Content = GetText("error") + ": " + GetText("noDataError");
                }
            }

            else
            {
                SetNew("error");
                newResults.Content += GetText("error") + ": " + GetText("serialInvalidError");
            }
        }

        private void SetNew(string type)
        {
            switch (type)
            {
                case "error":
                    newGroupBox.Header = GetText("invalidSerial");
                    ColorZoneAssist.SetBackground(newGroupBox, Brushes.Red);
                    break;
                case "valid":
                    newGroupBox.Header = GetText("validSerial");
                    ColorZoneAssist.SetBackground(newGroupBox, Brushes.Green);
                    break;
                case "warning":
                    ColorZoneAssist.SetBackground(newGroupBox, Brushes.Orange);
                    break;
                case "clear":
                    ColorZoneAssist.SetBackground(newGroupBox, Brushes.DodgerBlue);
                    newResults.Content = "";
                    newGroupBox.Header = GetText("info");
                    break;
            }
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}