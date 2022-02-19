using Exam.Entity;
using System;
using System.Collections.Generic;
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
    public sealed partial class CreateContactPage : Page
    {
        private int validateCheck;
        public CreateContactPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                return;
            }
            Contact contact = new Contact
            {
                Name = txtName.Text,
                PhoneNumber = txtPhone.Text,
            };
            ContentDialog contentDialog = new ContentDialog();
            if (Data.DatabaseInitialize.InsertContact(contact))
            {
                contentDialog.Title = "Action success";
                contentDialog.Content = "Added contact successfully";
                txtName.Text = "";
                txtPhone.Text = "";
            }
            else
            {
                contentDialog.Title = "Action fail";
                contentDialog.Content = "Transaction added fail";
            }
            contentDialog.CloseButtonText = "Close";
            await contentDialog.ShowAsync();
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
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                msgPhone.Text = "*Please enter phone";
                validateCheck++;
            }
            else
            {
                msgPhone.Text = "";
            }
            return validateCheck > 0;
        }
    }
}
