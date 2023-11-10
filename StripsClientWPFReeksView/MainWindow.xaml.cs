//using StripsClientWPFReeksView.Model;
using StripsClientWPFReeksView.Services;
using StripsREST.Model.Output;
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

namespace StripsClientWPFReeksView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;
        private string path;
        public MainWindow()
        {
            InitializeComponent();
            stripService = new StripServiceClient();
        }

        private async void GetReeksButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(ReeksIdTextBox.Text);
                string path = $"api/Strips/beheer/Reeks/{id}";
                var reeks = await StripServiceClient.GetReeksAsync(path);

                var stripsWithoutUrl = reeks.Strips //? strips zonder URL
                    .Select(strip => new
                    {
                        Nr = strip.Nr.HasValue ? strip.Nr.Value.ToString() : "-",
                        Titel = strip.Titel
                    })
                    .OrderBy(strip => strip.Nr)
                    .ToList();

                NaamTextBox.Text = reeks.Naam;
                AantalTextBox.Text = stripsWithoutUrl.Count.ToString();

                StripsDataGrid.ItemsSource = stripsWithoutUrl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
