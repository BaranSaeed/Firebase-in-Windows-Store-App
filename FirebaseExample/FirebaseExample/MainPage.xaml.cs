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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FirebaseExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        DispatcherTimer timer;
        public MainPage()
        {
            this.InitializeComponent();
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 0, 5, 0);
            timer.Tick += Timer_Tick;

        }

        private async void Timer_Tick(object sender, object e)
        {
            await web.InvokeScriptAsync("f", null);
            timer.Stop();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            String html = @"
            
            <script src='https://www.gstatic.com/firebasejs/3.7.1/firebase.js'></script>
            <script>

            function f(){
            // Initialize Firebase
            var config = {
            apiKey: 'APi-Key',
            authDomain: 'Your-App.firebaseapp.com',
            databaseURL: 'https://Your-App.firebaseio.com',
            storageBucket: 'Your-App.appspot.com',
            messagingSenderId: 'Sender-ID'
            };
            firebase.initializeApp(config);

            firebase.database().ref('myTable').push({ Name:'"+fname.Text+"', LName: '"+lname.Text+"'});}</script><body></body>";

            web.NavigateToString(html);
            timer.Start();
            await new Windows.UI.Popups.MessageDialog("inserted").ShowAsync();
        }
    }
}
