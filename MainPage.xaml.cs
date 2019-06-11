using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using training.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace training
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        //private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    ViewModel.StudentViewModel studentViewModelObject =
        //       new ViewModel.StudentViewModel();
        //    studentViewModelObject.LoadStudents();

        //    StudentViewControl.DataContext = studentViewModelObject;
        //}

        /*private void Option_Checked(object sender, RoutedEventArgs e)
        {
            SetCheckedState();
        }

        private void Option_Unchecked(object sender, RoutedEventArgs e)
        {
            SetCheckedState();
        }

        private void SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            cbOp1.IsChecked = cbOp2.IsChecked = cbOp3.IsChecked = true;
        }

        private void SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            cbOp1.IsChecked = cbOp2.IsChecked = cbOp3.IsChecked = false;
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            // If the SelectAll box is checked (all options are selected), 
            // clicking the box will change it to its indeterminate state.
            // Instead, we want to uncheck all the boxes,
            // so we do this programatically. The indeterminate state should
            // only be set programatically, not by the user.

            if (cbOp1.IsChecked == true &&
                cbOp2.IsChecked == true &&
                cbOp3.IsChecked == true)
            {
                // This will cause SelectAll_Unchecked to be executed, so
                // we don't need to uncheck the other boxes here.
                cbAllCheck.IsChecked = false;
            }
        }

        private void SetCheckedState()
        {
            // Controls are null the first time this is called, so we just 
            // need to perform a null check on any one of the controls.
            if (cbOp1 != null)
            {
                if (cbOp1.IsChecked == true &&
                    cbOp2.IsChecked == true &&
                    cbOp3.IsChecked == true)
                {
                    cbAllCheck.IsChecked = true;
                }
                else if (cbOp1.IsChecked == false &&
                    cbOp2.IsChecked == false &&
                    cbOp3.IsChecked == false)
                {
                    cbAllCheck.IsChecked = false;
                }
                else
                {
                    // Set third state (indeterminate) by setting IsChecked to null.
                    cbAllCheck.IsChecked = null;
                }
            }
        }

        private void BtnSetText_Click(object sender, RoutedEventArgs e)
        {
            if (cbOp1.IsChecked == true)
            {
                tbOp1.Text = "Checked";
            }
            else
            {
                tbOp1.Text = "Not checked";
            }

            if (cbOp2.IsChecked == true)
            {
                tbOp2.Text = "Checked";
            }
            else
            {
                tbOp2.Text = "Not checked";
            }

            if (cbOp3.IsChecked == true)
            {
                tbOp3.Text = "Checked";
            }
            else
            {
                tbOp3.Text = "Not checked";
            }
        }

        private void TbOp2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }*/
    }
}
