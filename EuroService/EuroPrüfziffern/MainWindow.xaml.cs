﻿using ServiceReference1;
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

namespace EuroPrüfziffern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client(ServiceReference1.Service1Client.EndpointConfiguration.BasicHttpBinding_IService1);

        
        public MainWindow()
        {
            InitializeComponent();
            Dictionary<string, string> languages = client.GetAllLanguages();

            languageBox.ItemsSource = languages;
            languageBox.DisplayMemberPath = "Value"; // zb: Deutsch
            languageBox.SelectedValuePath = "Key";   // zb: deu
            languageBox.SelectedIndex = 0;

            setTexts();
        }
        
        public void setTexts()
        {
            window.Title = getText("title");
            oldTitle.Content = getText(oldTitle.Name);
            newTitle.Content = getText(newTitle.Name);
            oldDescription.Content = getText(oldDescription.Name);
            newDescription.Content = getText(newDescription.Name);
            serialNo1.Content = getText("serialNo") + ":";
            serialNo2.Content = getText("serialNo") + ":";
            printeryCode1.Content = getText("printeryCode") + ":";
            printeryCode2.Content = getText("printeryCode") + ":";
            checkButtonOld.Content = getText("checkButton");
            checkButtonNew.Content = getText("checkButton");
            changeLanguage.Content = getText(changeLanguage.Name) + ":";
        }
        
        public string getText(string desc)
        {
            return client.getMessage(desc, languageBox.SelectedValue.ToString());
        }

        private void languageBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setTexts();
        }

        private void checkButtonOld_Click(object sender, RoutedEventArgs e)
        {
            oldResults.Content = "";
            if(!client.CheckOldSerialFormat(serialNoOld.Text))
            {
                oldResults.Content = getText("error") + ": " + getText("serialFormatError") + "\n";
            }
            
            if(!client.CheckPrinteryFormat(printeryCodeOld.Text))
            {
                oldResults.Content += getText("error") + ": " + getText("printeryFormatError") + "\n";
            }
            
            if(!oldResults.Content.Equals(""))
            {
                return;
            }
            
            if (client.CheckOldSerial(serialNoOld.Text))
            {
                oldResults.Content += getText("validSerial") + "\n\n";
                oldResults.Content += getText("oldCountryResult") + ": " + client.getCountry(serialNoOld.Text, languageBox.SelectedValue.ToString()) + "\n";
                oldResults.Content += getText("oldPrinteryResult") + ": ";
                Printery printery = client.getOldPrintery(printeryCodeOld.Text, languageBox.SelectedValue.ToString());
                oldResults.Content += printery.Name + " (" + printery.City + ", " + printery.Country + ")\n";
                if (!printery.Circulation)
                {
                    oldResults.Content += getText("warning") + ": " + getText("circulationWarning");
                }
            }

            else
            {
                oldResults.Content += getText("error") + ": " + getText("serialInvalidError");
            }
        }
        
        private void checkButtonNew_Click(object sender, RoutedEventArgs e)
        {
            newResults.Content = "";
            if (!client.CheckNewSerialFormat(serialNoNew.Text))
            {
                newResults.Content = getText("error") + ": " + getText("serialFormatError") + "\n";
            }

            if (!client.CheckPrinteryFormat(printeryCodeNew.Text))
            {
                newResults.Content += getText("error") + ": " + getText("printeryFormatError") + "\n";
            }

            else if (!serialNoNew.Text.ToUpper()[0].Equals(printeryCodeNew.Text.ToUpper()[0]))
            {
                newResults.Content += getText("error") + ": " + getText("codeMatchError") + "\n";
            }
            
            if (!newResults.Content.Equals(""))
            {
                return;
            }
            
            if (client.CheckNewSerial(serialNoNew.Text))
            {
                
                newResults.Content += getText("validSerial") + "\n\n";
                newResults.Content += getText("newResult") + ": \n";
                Printery printery = client.getNewPrintery(printeryCodeNew.Text, languageBox.SelectedValue.ToString());
                newResults.Content += printery.Name + "\n" + printery.City + ", " + printery.Country + "\n";
                if (!printery.Circulation)
                {
                    newResults.Content += getText("warning") + ": " + getText("circulationWarning");
                }
            }

            else
            {
                newResults.Content += getText("error") + ": " + getText("serialInvalidError");
            }
        }
    }
}
