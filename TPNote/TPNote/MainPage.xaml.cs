using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using Xamarin.Forms.Maps;
using System.Diagnostics.CodeAnalysis;

namespace TPNote
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [SuppressMessage("TypesThatOwnDisposableFieldsShouldBeDisposable", "CA1001")]
    public partial class MainPage : ContentPage
    {

        private int count = 0;
        private short counter = 0;
        private int slidePosition = 0;
        readonly int heightRowsList = 100;
        private const string Url = "https://hmin309-embedded-systems.herokuapp.com/message-exchange/messages/";
        // This handles the Web data request
        private readonly HttpClient _client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            // We call the OnGetList from Here 
            Task.Delay(2000);
            OnGetList();
        }


        protected async void OnGetList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {

                try
                {
                    //Activity indicator visibility on
                    activity_indicator.IsRunning = true;
                    //Getting JSON data from the Web
                    string content = await _client.GetStringAsync(Url).ConfigureAwait(true);
                    //We deserialize the JSON data from this line
                    var tr = JsonConvert.DeserializeObject<List<Student>>(content);
                    //After deserializing , we store our data in the List called ObservableCollection
                    ObservableCollection<Student> trends = new ObservableCollection<Student>(tr);

                    //Then finally we attach the List to the ListView. Seems Simple :)
                    myList.ItemsSource = trends;


                    //We check the number of Items in the Observable Collection
                    int i = trends.Count;
                    if (i > 0)
                    {
                        // If they are greater than Zero we stop the activity indicator
                        activity_indicator.IsRunning = false;
                    }

                    //Here we Wrap  the size of the ListView according to the number of Items which have been retrieved 
                    i = (trends.Count * heightRowsList);
                    activity_indicator.HeightRequest = i;

                    UpdateMap(tr);
                }
                catch (Exception ey)
                {
                    Debug.WriteLine("" + ey);
                }

            }
        }

        readonly List<Student> studentsList = new List<Student>();

        public short Counter { get => counter; set => counter = value; }
        public int Count { get => count; set => count = value; }
        public int SlidePosition { get => slidePosition; set => slidePosition = value; }

        private void UpdateMap(List<Student> listeIssueDuSite)
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;

                foreach (var student in listeIssueDuSite)
                {
                    studentsList.Add(new Student
                    {
                        PlaceName = student.Student_message,
                        Position = new Position(student.Gps_lat, student.Gps_long),
                    });
                }

                MyMap.ItemsSource = studentsList;

                //var loc = await Xamarin.Essentials.Geolocation.GetLocationAsync();
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(43.633877, 3.865064), Distance.FromKilometers(5)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}