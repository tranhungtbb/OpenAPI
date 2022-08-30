namespace DbContextHelper.WriteDbContext
{
    public class AppWriteDbContext : AppDbContext, IAppWriteDbContext
    {
        public AppWriteDbContext(IAppSettings appSettings) : base(appSettings)
        {
        }
    }
}
