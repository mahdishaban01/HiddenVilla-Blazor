namespace HiddenVilla_Server
{
    public class DependencyInjection
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();
        }
    }
}
