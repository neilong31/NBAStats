using SQLite;
using System;

namespace DPS926_A2
{
    public interface ISOLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
