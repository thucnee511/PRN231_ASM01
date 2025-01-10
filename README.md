## Install NuGet Package
``` terminal
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.5
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.5
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.5
dotnet add package Microsoft.Extensions.Configuration --version 8.0.0
dotnet add package Microsoft.Extensions.Configuration.Json --version 8.0.0
```
## Scaffold Database

## Configuration

``` C# Code
public static string GetConnectionString(string connectionStringName)
{
    var config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();

    string connectionString = config.GetConnectionString(connectionStringName);
    return connectionString;
}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
```

## Generic Repository Class

``` C#
public class GenericRepository<T> where T : class
{
    private DataContext? _context;
    private DbSet<T>? _dbSet;

    protected DataContext Context
    {
        get
        {
            return _context ??= new();
        }
    }

    protected DbSet<T> DbSet
    {
        get
        {
            return _dbSet ??= Context.Set<T>();
        }
    }

    public GenericRepository()
    {
    }

    public Task<List<T>> GetAllAsync() => DbSet.ToListAsync();

    public List<T> GetAll() => DbSet.ToList();

    public T? GetById(object id)
    {
        var entity = DbSet.Find(id);
        if (entity != null)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }
        return entity;
    }

    public async Task<T?> GetByIdAsync(object id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity != null)
        {
            Context.Entry(entity).State = EntityState.Detached;
        }
        return entity;
    }

    public int Insert(T entity)
    {
        DbSet.Add(entity);
        return Context.SaveChanges();
    }

    public async Task<int> InsertAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return await Context.SaveChangesAsync();
    }

    public int Update(T entity)
    {
        DbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        return Context.SaveChanges();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        Context.Entry(entity).State = EntityState.Modified;
        return await Context.SaveChangesAsync();
    }

    public int Delete(T entity)
    {
        DbSet.Remove(entity);
        return Context.SaveChanges();
    }

    public async Task<int> DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        return await Context.SaveChangesAsync();
    }
}
```