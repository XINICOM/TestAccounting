using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TA_UI.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TA_UI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            if (ExtendsContentIntoTitleBar)
            {
                AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
            }

            //控制窗口的最小尺寸
            if (AppWindow.Presenter is OverlappedPresenter presenter)
            {
                presenter.PreferredMinimumWidth = 1080;
                presenter.PreferredMinimumHeight = 720;
            }

            //SystemBackdrop = new MicaBackdrop()
            //{
            //    Kind = MicaKind.Base
            //};
        }

        private async void DialogButton_Click(object sender , RoutedEventArgs e)
        {
            ContentDialog cd = new ContentDialog()
            {
                Title = "Content Dialog" ,
                Content = new Dialog1() ,
                PrimaryButtonText = "OK" ,
                SecondaryButtonText = "Cancel" ,
                CloseButtonText = "Close" ,
                DefaultButton = ContentDialogButton.Primary ,
                Style = (Style)Application.Current.Resources["DefaultContentDialogStyle"] ,
            };
            cd.XamlRoot = this.Content.XamlRoot;
            var result = await cd.ShowAsync();
        }

        //实现运行中对backdrop进行切换
        private void BackdropButton_Click(object sender , RoutedEventArgs e)
        {
            if (SystemBackdrop == null)
            {
                SystemBackdrop = new MicaBackdrop()
                {
                    Kind = MicaKind.Base
                };
            }
            else if (SystemBackdrop is MicaBackdrop)
            {
                SystemBackdrop = new DesktopAcrylicBackdrop();
            }
            else
            {
                SystemBackdrop = null;
            }
        }
    }
}
