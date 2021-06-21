
using DPS926_A2.Model.Players;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DPS926_A2.Model
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;
        public DBManager()
        {
            this._connection = DependencyService.Get<ISOLiteDb>().GetConnection();
        }
        public async Task<ObservableCollection<Player>> CreateTable()
        {
            await _connection.CreateTableAsync<Player>();
            var players = await _connection.Table<Player>().ToListAsync();
            var plyers = new ObservableCollection<Player>(players);
            return plyers;
        }

        public void insertNewPlayer(Player player)
        {
            _connection.InsertAsync(player);
        }

        public void deletePlayer(Player player)
        {
            _connection.DeleteAsync(player);
        }

        public void updatePlayer(Player player)
        {
            _connection.UpdateAsync(player);

        }

    }
}
