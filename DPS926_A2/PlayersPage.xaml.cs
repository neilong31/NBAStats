using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DPS926_A2.Model.Players;
using System.Collections.ObjectModel;
using DPS926_A2.Model;

namespace DPS926_A2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayersPage : ContentPage
    {
        ObservableCollection<Player> playerData;
        ObservableCollection<Player> allPlayers;
        DBManager dbModel;
        NetworkingManager networkingManager = new NetworkingManager();
        public PlayersPage(ObservableCollection<Player> allPlayers, DBManager dbModel)
        {
            InitializeComponent();
            this.allPlayers = allPlayers;
            this.dbModel = dbModel;
            playersLV.ItemsSource = playerData;

        }

        protected async override void OnAppearing()
        {
            playersLV.ItemsSource = null;
            var list = await networkingManager.GetAllPlayers();
            playerData = new ObservableCollection<Player>(list);
            playersLV.ItemsSource = playerData;
            base.OnAppearing();

        }
        private async void searchBtn_Clicked(object sender, EventArgs e)
        {
            playersLV.ItemsSource = null;
            var list = await networkingManager.GetAllPlayerByNames(firstNameEntry.Text, lastNameEntry.Text);
            playerData = new ObservableCollection<Player>(list);
            playersLV.ItemsSource = playerData;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var selectedItem = (Player)menuItem.BindingContext;
            await Navigation.PushAsync(new PlayerStatsPage(selectedItem, allPlayers, dbModel, false));
        }
    }
}