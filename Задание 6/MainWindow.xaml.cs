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

namespace Задание_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string windDirection;
        private int windSpeed;

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public string WindDirection
        {
            get => windDirection;
            set => windDirection = value;
        }
        public int WindSpeed
        {
            set
            {
                if (value >= 0)
                {
                    windSpeed = value;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            get
            {
                return windSpeed;
            }
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
            nameof(Temperature),
            typeof(int),
            typeof(WeatherControl),
             new FrameworkPropertyMetadata(
                 0,
                 FrameworkPropertyMetadataOptions.AffectsRender |
                 FrameworkPropertyMetadataOptions.Journal,
                 null,
                 new CoerceValueCallback(CoerceTemperature)),
             new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t < -50 && t > 50)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t < -50 && t > 50)
            {
                return t;
            }
            else
                return 0;
        }

        public enum Precipitation
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 3
        }
    }
}
