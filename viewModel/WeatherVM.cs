using MyWeatherApp.Model;
using MyWeatherApp.viewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherApp.viewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;

        public string Query
        {
            get { return query; }
            set 
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        private CurrentConditions currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set 
            { 
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City selectedCity;

        public City SelectedCity
        {
            get { return selectedCity; }
            set 
            {
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
            }
        }

        public WeatherVM()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "New Work"
                };
                currentConditions = new CurrentConditions
                {
                    WeatherText = "Partly Cloudy",
                    Temperature = new Temperature
                    {
                        Metric = new Units 
                        {
                            Value = 21
                        }
                    }

                };
            }
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
