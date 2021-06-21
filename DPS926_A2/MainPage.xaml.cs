using DPS926_A2.Model;
using DPS926_A2.Model.Players;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DPS926_A2
{
    public partial class MainPage : ContentPage
    {
        DBManager dbModel = new DBManager();
        ObservableCollection<Player> allPlayers;
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            allPlayers = await dbModel.CreateTable();
            base.OnAppearing();

        }

        async private void playersPageBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlayersPage(allPlayers, dbModel));
        }

        async private void teamsPageBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeamsPage());
        }

        async private void favouritePlayersPageBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavouritePlayersPage(dbModel));
        }



    }
}
