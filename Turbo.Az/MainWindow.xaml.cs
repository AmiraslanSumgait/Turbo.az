
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Turbo.Az
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        public DataClasses1DataContext dtx { get; set; } = new DataClasses1DataContext();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dataGrid.ItemsSource = dtx.Cars;
            foreach (var model in dtx.Models)
            {
                cbx_Models.Items.Add(model.Name);
            }
            foreach (var make in dtx.Makes)
            {
                cbx_Makes.Items.Add(make.Name);
            }
            foreach (var color in dtx.Colors)
            {
                cbx_Colors.Items.Add(color.Name);
            }
            foreach (var banType in dtx.BanTypes)
            {
                cbx_BanTypes.Items.Add(banType.Name);
            }
            foreach (var city in dtx.Regions)
            {
                cbx_Cities.Items.Add(city.Name);
            }
            foreach (var gear in dtx.Gears)
            {
                cbx_Gears.Items.Add(gear.Name);
            }
            foreach (var transmission in dtx.Transmissions)
            {
                cbx_Transmissions.Items.Add(transmission.Name);
            }
            foreach (var fuelType in dtx.FuelTypes)
            {
                cbx_FuelTypes.Items.Add(fuelType.Name);
            }


        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {

           
            IQueryable<Car> carsResult = dtx.Cars;
            try
            {
                if (cbx_Colors.SelectedItem != null)
                {
                    carsResult = dtx.Cars.Where(c => c.Color.Name.Equals(cbx_Colors.SelectedItem));
                }
                if (cbx_Makes.SelectedItem != null)
                {
                    carsResult = carsResult.Where(c => c.Make.Name.Equals(cbx_Makes.SelectedItem));
                }
                if (cbx_BanTypes.SelectedItem != null)
                {
                    carsResult = carsResult.Where(c => c.BanType.Name.Equals(cbx_BanTypes.SelectedItem));
                }
                if (cbx_Cities.SelectedItem != null)
                {
                    carsResult = carsResult.Where(c => c.Region.Name.Equals(cbx_Cities.SelectedItem));
                }
                if (cbx_Models.SelectedItem != null)
                {
                    carsResult = carsResult.Where(c => c.Model.Name.Equals(cbx_Models.SelectedItem));
                }
                if (cbx_Gears.SelectedItem != null)
                {
                    carsResult = carsResult.Where(c => c.Gear.Name.Equals(cbx_Gears.SelectedItem));
                }
                if (cbx_FuelTypes.SelectedItem != null)
                {
                    carsResult = carsResult.Where(c => c.FuelType.Name.Equals(cbx_FuelTypes.SelectedItem));
                }
                if (cbx_Transmissions.SelectedItem != null)
                {
                    carsResult = carsResult.Where(c => c.Transmission.Name.Equals(cbx_Transmissions.SelectedItem));
                }
                if (txb_minPrice.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value > decimal.Parse(txb_minPrice.Text.ToString()));
                }
                if (txb_maxPrice.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value < decimal.Parse(txb_maxPrice.Text.ToString()));
                }
                if (txb_minMileage.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value > int.Parse(txb_minMileage.Text.ToString()));
                }
                if (txb_maxMileage.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value < int.Parse(txb_maxMileage.Text.ToString()));
                }
                if (txb_minYear.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value > int.Parse(txb_minYear.Text.ToString()));
                }
                if (txb_maxYear.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value < int.Parse(txb_maxYear.Text.ToString()));
                }
                if (txb_minEngVol.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value > int.Parse(txb_minEngVol.Text.ToString()));
                }
                if (txb_maxEngVol.Text != "")
                {
                    carsResult = carsResult.Where(c => c.Price.Value < int.Parse(txb_maxEngVol.Text.ToString()));
                }

                var cars = from car in carsResult
                           select new
                           {
                               City = car.Region.Name,
                               Make = car.Make.Name,
                               Model = car.Model.Name,
                               Price = car.Price,
                               RegistrationYear = car.RegYear,
                               BanType = car.BanType.Name,
                               Mileage = car.Mileage,
                               Color = car.Color.Name,
                               EngineVolume = car.EngineVolume.Volume,
                               FuelType = car.FuelType.Name,
                               Gear = car.Gear.Name,
                               Transmission = car.Transmission.Name
                           };
                dataGrid.ItemsSource = cars;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
