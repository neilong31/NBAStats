using DPS926_A2.Model;
using DPS926_A2.Model.Players;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPS926_A2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavouritePlayersPage : ContentPage
    {
        ObservableCollection<Player> allPlayers;
        DBManager dbModel;
        public FavouritePlayersPage(DBManager dbModel)
        {
            InitializeComponent();
            this.dbModel = dbModel;
            favPlayersLV.ItemsSource = allPlayers;
        }

        protected async override void OnAppearing()
        {
            this.allPlayers = await dbModel.CreateTable();
            favPlayersLV.ItemsSource = null;
            favPlayersLV.ItemsSource = allPlayers;
            base.OnAppearing();

        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            var selectedItem = (Player)menuItem.BindingContext;
            await Navigation.PushAsync(new PlayerStatsPage(selectedItem, allPlayers, dbModel, true));
        }
    }
}