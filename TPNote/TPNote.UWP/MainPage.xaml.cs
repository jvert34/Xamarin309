using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TPNote.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("v4HE54Olo4PhrckELFf8~pmcDfkwiY2bsrJ7esun7mQ~AhDFtmjkyUkP1boFvJqCyHH6jaYLyvx_DHocqGPb2TDOl4fV19MHEGKkhIelnWTx");

            LoadApplication(new TPNote.App());
        }
    }
}
