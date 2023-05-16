using PRESMATIC2._0.Models;
using SQLite;

public class MaterialsDatabase : IDisposable
{
    private static MaterialsDatabase _instance;
    public readonly SQLiteAsyncConnection database;

    private MaterialsDatabase()
    {
        database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "materiales.db3"));
        database.CreateTableAsync<Materials>().Wait();
    }

    public static MaterialsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MaterialsDatabase();
            }

            return _instance;
        }
    }

    public async Task<List<Materials>> GetMaterialesAsync()
    {
        return await database.Table<Materials>().ToListAsync();
    }

    public async Task InsertOrUpdateMaterialAsync(Materials material)
    {
        if (material.MaterialId == 0)
        {
            await database.InsertAsync(material);
        }
        else
        {
            await database.UpdateAsync(material);
        }
    }

    public async Task DeleteMaterialAsync(Materials material)
    {
        await database.DeleteAsync(material);
    }


    public void Dispose()
    {
        database.CloseAsync();
    }
}

