using DPS926_A2.Model;
using DPS926_A2.Model.Teams;
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
    public partial class TeamsPage : ContentPage
    {
        ObservableCollection<Team> teamData;
        NetworkingManager networkingManager = new NetworkingManager();
        public TeamsPage()
        {
            InitializeComponent();
            teamsLV.ItemsSource = teamData;
        }

        protected async override void OnAppearing()
        {
            teamsLV.ItemsSource = null;
            var list = await networkingManager.GetAllTeams();
            teamData = new ObservableCollection<Team>(list);
            teamsLV.ItemsSource = teamData;
            base.OnAppearing();

        }
    }
}