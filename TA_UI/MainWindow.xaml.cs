using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using TA_UI.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CommunityToolkit.WinUI.Controls;
using System.Diagnostics;


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

            SelectedTokens = [];
            //    new()
            //{
            //    //SuggestItemsList[0],
            //    //SuggestItemsList[1]
            //};
        }

        private async void DialogButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog cd = new ContentDialog()
            {
                Title = "Content Dialog",
                Content = new Dialog1(),
                PrimaryButtonText = "OK",
                SecondaryButtonText = "Cancel",
                CloseButtonText = "Close",
                DefaultButton = ContentDialogButton.Primary,
                Style = (Style)Application.Current.Resources["DefaultContentDialogStyle"],
            };
            cd.XamlRoot = this.Content.XamlRoot;
            var result = await cd.ShowAsync();
        }

        //实现运行中对backdrop进行切换
        private void BackdropButton_Click(object sender, RoutedEventArgs e)
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

        //tokenTextBox
        public ObservableCollection<SampleDataType> SuggestItems = [];
        public List<SampleDataType> SuggestItemsList = new List<SampleDataType>()
        {
            new SampleDataType() { Text = "Account", Icon = Symbol.Account },
            new SampleDataType() { Text = "Add friend", Icon = Symbol.AddFriend },
            new SampleDataType() { Text = "Attach", Icon = Symbol.Attach },
            new SampleDataType() { Text = "Attach camera", Icon = Symbol.AttachCamera },
            new SampleDataType() { Text = "Audio", Icon = Symbol.Audio },
            new SampleDataType() { Text = "Block contact", Icon = Symbol.BlockContact },
            new SampleDataType() { Text = "Calculator", Icon = Symbol.Calculator },
            new SampleDataType() { Text = "Calendar", Icon = Symbol.Calendar },
            new SampleDataType() { Text = "Camera", Icon = Symbol.Camera },
            new SampleDataType() { Text = "Contact", Icon = Symbol.Contact },
            new SampleDataType() { Text = "Favorite", Icon = Symbol.Favorite },
            new SampleDataType() { Text = "Link", Icon = Symbol.Link },
            new SampleDataType() { Text = "Mail", Icon = Symbol.Mail },
            new SampleDataType() { Text = "Map", Icon = Symbol.Map },
            new SampleDataType() { Text = "Phone", Icon = Symbol.Phone },
            new SampleDataType() { Text = "Pin", Icon = Symbol.Pin },
            new SampleDataType() { Text = "Rotate", Icon = Symbol.Rotate },
            new SampleDataType() { Text = "Rotate camera", Icon = Symbol.RotateCamera },
            new SampleDataType() { Text = "Send", Icon = Symbol.Send },
            new SampleDataType() { Text = "Tags", Icon = Symbol.Tag },
            new SampleDataType() { Text = "UnFavorite", Icon = Symbol.UnFavorite },
            new SampleDataType() { Text = "UnPin", Icon = Symbol.UnPin },
            new SampleDataType() { Text = "Zoom", Icon = Symbol.Zoom },
            new SampleDataType() { Text = "ZoomIn", Icon = Symbol.ZoomIn },
            new SampleDataType() { Text = "ZoomOut", Icon = Symbol.ZoomOut },
            new SampleDataType() { Text = "ZYC", Icon = Symbol.Account},
            new SampleDataType() { Text = "a", Icon = Symbol.Admin},
        };

        public ObservableCollection<SampleDataType> SelectedTokens { get; set; }

        //public TokenizingTextBoxSample()
        //{
        //    this.InitializeComponent();


        //}

        private void TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //Debug.WriteLine($"TextChanged:{sender.Text}");
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<SampleDataType> suitableItems = [];
                var splitText = sender.Text.ToLower().TrimEnd(',').Split(" ");
                foreach (var item in SuggestItemsList)
                {
                    var found = splitText.All((key) => item.Text!.ToLower().Contains(key));
                    if (found)
                    {
                        suitableItems.Add(item);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    if (sender.Text.Contains('-'))
                    {
                        string[] Numbers = [];
                        Numbers = sender.Text.Split('-');
                        if (float.TryParse(Numbers[0], out float i0) && float.TryParse(Numbers[1], out float i1))
                        {
                            suitableItems.Add(new SampleDataType() { Text = sender.Text, Icon = Symbol.Edit, RangeLow = i0, RangeHigh = i1 });
                        }
                    }
                    else
                    {
                        suitableItems.Add(new SampleDataType() { Text = sender.Text, Icon = Symbol.Add });
                    }

                }
                //suitableItems.OrderBy(x => x.Text);
                suitableItems.Sort((x, y) => StringComparer.Ordinal.Compare(x.Text!.ToLower(), y.Text!.ToLower()));
                SuggestItems.Clear();
                foreach (var item in suitableItems)
                {
                    SuggestItems.Add(item);
                    Debug.WriteLine(item.Text);
                }
                Debug.WriteLine("#######################");

            }
            //currentEdit.Text = TokenBox.Text;
            //SetSelectedTokenText();
        }



        private void SetSelectedTokenText()
        {
            Debug.WriteLine("SetSelectedTokenText");

            //selectedItemsString.Text = TokenBox.SelectedTokenText;
        }

        private void TokenItemCreating(object sender, TokenItemAddingEventArgs e)
        {
            Debug.WriteLine("TokenItemCreating");
            // Take the user's text and convert it to our data type (if we have a matching one).
#if !HAS_UNO
            if (SuggestItems[0].Icon != Symbol.Add)
            {
                e.Item = SuggestItems.OrderBy(x => x.Text).FirstOrDefault((item) => item.Text!.Contains(e.TokenText, StringComparison.CurrentCultureIgnoreCase));
            }
            else
            {
                e.Item = new SampleDataType()
                {
                    Text = e.TokenText,
                    Icon = Symbol.OutlineStar,

                };
            }
            //e.Item = SuggestItems.FirstOrDefault((item) => item.Text!.Contains(e.TokenText, StringComparison.CurrentCultureIgnoreCase));
#else
            e.Item = _samples.FirstOrDefault((item) => item.Text!.Contains(e.TokenText));
#endif
            // Otherwise, create a new version of our data type
            //if (e.Item == null)
            //{
            //    e.Item = new SampleDataType()
            //    {
            //        Text = e.TokenText,
            //        Icon = Symbol.OutlineStar,

            //    };
            //}
        }

        private void TokenBox_ItemClick(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("TokenBox_ItemClick");
            if (e.ClickedItem is SampleDataType selectedItem)
            {
                //clickedItem.Text = selectedItem.Text!;
            }
        }

        private void TokenBox_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("TokenBox_Loaded");
            SuggestItems.Clear();
            foreach (var item in SuggestItemsList)
            {
                SuggestItems.Add(item);
            }
            //SuggestItems = SuggestItemsList;
            SetSelectedTokenText();
        }

    }

    public class SampleDataType
    {
        public string? Text { get; set; }
        public Symbol? Icon { get; set; }
        public float? RangeLow { get; set; }
        public float? RangeHigh { get; set; }

        //fi
        public FontIcon? FontIcon { get; set; }

    }
}
