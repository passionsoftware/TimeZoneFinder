using Hardcodet.Wpf.TaskbarNotification;
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
using System.Windows.Threading;
using TimeZoneFinder.helper;
using TimeZoneFinder.models;

namespace TimeZoneFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskbarIcon tbi = new TaskbarIcon();
        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            dt.Tick += Dt_Tick;
            dt.Interval += new TimeSpan(0, 0, 1);
            dt.Start();

            lstFirst.ItemsSource = models.CountryList.countryList;
            lstFirst.SelectedIndex = 0;

            lstSecond.ItemsSource = models.CountryList.countryList;
            lstSecond.SelectedIndex = 1;

            Left = System.Windows.SystemParameters.WorkArea.Width - Width;
            Top = System.Windows.SystemParameters.WorkArea.Height - Height;

            tbi = (TaskbarIcon)FindName("MyNotifyIcon");
            tbi.ToolTip = "Click to get time";
            CalculateTime();
        }

        private void CalculateTime()
        {

            string firstItem = ((CountryList)lstFirst.SelectedItem).Name;
            string secondItem = ((CountryList)lstSecond.SelectedItem).Name;

            TimeZoneInfo firstTimeZoneInfo = ((CountryList)lstFirst.SelectedItem).TimeZone;
            DateTime firstTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (((CountryList)lstFirst.SelectedItem).TimeZone));
            bool IsDayLightTimeAvilable_First = firstTimeZoneInfo.IsDaylightSavingTime(firstTime);

            TimeZoneInfo secondTimeZoneInfo = ((CountryList)lstSecond.SelectedItem).TimeZone;
            DateTime secondTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (((CountryList)lstSecond.SelectedItem).TimeZone));
            bool IsDayLightTimeAvilable_Second = secondTimeZoneInfo.IsDaylightSavingTime(secondTime);

            var country1 = CountryTimeZone.countryTimeDiffernceList.Where(m => m.Country == firstItem && m.isDayLightSaving == IsDayLightTimeAvilable_First).FirstOrDefault().UTCTime;
            var country2 = CountryTimeZone.countryTimeDiffernceList.Where(m => m.Country == secondItem && m.isDayLightSaving == IsDayLightTimeAvilable_Second).FirstOrDefault().UTCTime;

            var timeDiffrence = new StringTime(country1).Subtract(new StringTime(country2));


            for(int i = 1;i <= 24;i++)
            {
              if(stkRowIndia.Children.Count > 1)
                {
                    stkRowIndia.Children.Remove(stkRowIndia.Children[1]);
                    stkRowUS.Children.Remove(stkRowUS.Children[1]);
                }
            }

            CreateButtonsforTime(timeDiffrence, firstItem, secondItem);
        }

        private void CreateButtonsforTime(TimeSpan timedifference, string firstTimeChart, string secondTimeChart)
        {
            for(int i = 1; i <= 24; i++)
            {
                string time = i.ToString() + ":00";
                Button btnFirst = new Button();
                btnFirst.Name = "First_" + i;
                btnFirst.Content = time;
                SetButtonInitalStyle(ref btnFirst);
                btnFirst.MouseEnter += BtnFirst_MouseEnter;
                btnFirst.MouseLeave += BtnFirst_MouseLeave;
                stkRowIndia.Children.Add(btnFirst);
                lblFirstTimeChart.Content = firstTimeChart;

                Button btnSecond = new Button();
                btnSecond.Name = "Second_" + i;
                SetButtonInitalStyle(ref btnSecond);

                TimeSpan timeValue;

                if(new TimeSpan(new StringTime(timedifference.ToString()).Hours, new StringTime(timedifference.ToString()).Minutes,0) < new TimeSpan(0,0,0))
                {
                    timedifference = new StringTime("23:00").Add(new StringTime(timedifference.ToString()));
                }

                if(new StringTime(time).Subtract(new StringTime(timedifference.ToString())) < new TimeSpan(0,0,0))
                {
                    timeValue = (new StringTime("23:00").Add(new StringTime((new StringTime(time).Subtract(new StringTime(timedifference.ToString()))).ToString())));
                }
                else
                {
                    timeValue = (new StringTime(time).Subtract(new StringTime(timedifference.ToString())));
                }

                btnSecond.Content = timeValue.ToString(@"hh\:mm");
                stkRowUS.Children.Add(btnSecond);
                lblSecondTimeChart.Content = secondTimeChart;
            }
        }

        private void BtnFirst_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            SetButtonInitalStyle(ref btn);

            string second_Button = "Second_" + btn.Name.Split('_')[1];

            foreach(var v in stkRowUS.Children)
            {
                if(v is Button)
                {
                    Button btnSecond = v as Button;
                    if(btnSecond.Name == second_Button)
                    {
                        
                        SetButtonInitalStyle(ref btn);
                    }
                }
            }
        }

        private void BtnFirst_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            SetButtonMouseOverStyle(ref btn);

            string second_Button = "Second_" + btn.Name.Split('_')[1];

            foreach (var v in stkRowUS.Children)
            {
                if (v is Button)
                {
                    Button btnSecond = v as Button;
                    if (btnSecond.Name == second_Button)
                    {

                        SetButtonMouseOverStyle(ref btn);
                    }
                }
            }
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            DateTime firstItem = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (((CountryList)lstFirst.SelectedItem).TimeZone));
            DateTime secondItem = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, (((CountryList)lstSecond.SelectedItem).TimeZone));

            lblIndiaTime.Content = firstItem.ToLongTimeString();
            lblUSTime.Content = secondItem.ToLongTimeString();


        }

        private void SetButtonInitalStyle(ref Button button)
        {
            button.Width = 29;
            button.Height = 20;
            button.FontSize = 9;
            button.Background = Brushes.White;
            button.BorderBrush = Brushes.Blue;
            button.Foreground = Brushes.Black;
            button.FontWeight = FontWeights.Normal;
        }

        private void SetButtonMouseOverStyle(ref Button button)
        {
            button.FontSize = 10;
            button.Background = Brushes.LightBlue;
            button.FontWeight = FontWeights.Bold;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void LstFirst_DropDownClosed(object sender, EventArgs e)
        {
            string firstItem = ((CountryList)lstFirst.SelectedItem).Name;
            string secondItem = ((CountryList)lstSecond.SelectedItem).Name;
            CalculateTime();
        }

        private void MyNotifyIcon_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Focus();
            this.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void LstSecond_DropDownClosed(object sender, EventArgs e)
        {
            string firstItem = ((CountryList)lstFirst.SelectedItem).Name;
            string secondItem = ((CountryList)lstSecond.SelectedItem).Name;
            CalculateTime();
        }
    }
}
