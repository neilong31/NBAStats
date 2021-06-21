using DPS926_A2.Model.Players;
using DPS926_A2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace DPS926_A2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerStatsPage : ContentPage
    {
        ObservableCollection<Player> allPlayers;
        Player currPlayer;
        Stats currStats;
        DBManager dbModel;
        NetworkingManager networkingManager = new NetworkingManager();
        public PlayerStatsPage(Player player, ObservableCollection<Player> allPlayers, DBManager dbModel, bool isFavourited)
        {
            InitializeComponent();
            currPlayer = player;
            firstNameSpan.Text = player.first_name+" ";
            lastNameSpan.Text = player.last_name;
            this.allPlayers = allPlayers;
            this.dbModel = dbModel;
            if (isFavourited)
            {
                favouriteBtn.IsEnabled = false;
                favouriteBtn.Text = "Already Favourited";
            }
        }

        protected async override void OnAppearing()
        {
            var stats = await networkingManager.GetPlayerStatsByID(currPlayer.id);
            this.currStats = stats[0];
            ppgSpan.Text = currStats.pts.ToString();
            astSpan.Text = currStats.ast.ToString();
            rebSpan.Text = currStats.reb.ToString();
            stlSpan.Text = currStats.stl.ToString();
            blkSpan.Text = currStats.blk.ToString();
            turnoverSpan.Text = currStats.turnover.ToString();
            base.OnAppearing();

        }

        private async void favouriteBtn_Clicked(object sender, EventArgs e)
        {
            allPlayers.Add(currPlayer);
            dbModel.insertNewPlayer(currPlayer);
            await Navigation.PopAsync();
        }
    }
}