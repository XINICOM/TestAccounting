using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TA_UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dialog1 : Page
    {
        public Dialog1()
        {
            InitializeComponent();
        }

        private void allCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            checkBox1.IsChecked = checkBox2.IsChecked = checkBox3.IsChecked = true;
        }

        private void allCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true && checkBox2.IsChecked == true && checkBox3.IsChecked == true)
            {
                checkBox1.IsChecked = checkBox2.IsChecked = checkBox3.IsChecked = false;
            }
            else if(checkBox1.IsChecked==true|| checkBox2.IsChecked == true || checkBox3.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
        }

        private void allCheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            if(checkBox1.IsChecked == true && checkBox2.IsChecked == true && checkBox3.IsChecked == true)
            {
                allCheckBox.IsChecked = false;
            }
        }


        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            if(checkBox2.IsChecked == true && checkBox3.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
            else
            {
                allCheckBox.IsChecked = null;
            }
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBox2.IsChecked == false && checkBox3.IsChecked == false)
            {
                allCheckBox.IsChecked = false;
            }
            else
            {
                allCheckBox.IsChecked = null;
            }
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true && checkBox3.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
            else
            {
                allCheckBox.IsChecked = null;
            }

        }

        private void checkBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            if(checkBox1.IsChecked == false && checkBox3.IsChecked == false)
            {
                allCheckBox.IsChecked = false;
            }
            else
            {
                allCheckBox.IsChecked = null;
            }
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox2.IsChecked == true && checkBox1.IsChecked == true)
            {
                allCheckBox.IsChecked = true;
            }
            else
            {
                allCheckBox.IsChecked = null;
            }

        }

        private void checkBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            if(checkBox2.IsChecked == false && checkBox1.IsChecked == false)
            {
                allCheckBox.IsChecked = false;
            }
            else
            {
                allCheckBox.IsChecked = null;
            }
        }
    }
}
