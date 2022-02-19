using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Exam.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchContactPage : Page
    {
        private int validateCheck;
        public SearchContactPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
              {
                return;
            }
            var contact = Data.DatabaseInitialize.getContactByName(txtName.Text);
            if (contact == null)
            {
                txtNotFound.Visibility = Visibility.Visible;
                txtFound.Visibility = Visibility.Collapsed;
                Debug.WriteLine("notfound");
            }
            else
            {
                txtNotFound.Visibility = Visibility.Collapsed;
                txtFound.Visibility = Visibility.Visible;
                foundName.Text = contact.Name;
                foundPhone.Text = contact.PhoneNumber;
                Debug.WriteLine("found");

            }
        }
        private bool ValidateForm()
        {
            validateCheck = 0;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msgName.Text = "*Please enter name";
                validateCheck++;
            }
            else
            {
                msgName.Text = "";
            }
            return validateCheck > 0;
        }

        private void TextBlock_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pages.CreateContactPage));
        }
    }
}
