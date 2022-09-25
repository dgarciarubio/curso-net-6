namespace MyProject.Api.Services
{
    public class TimeService : ITimeServiceSingleton, ITimeServiceTrasient, ITimeServiceScoped
    {
        private DateTime _date = DateTime.Now;

        public string GetTime() 
        {
            return _date.ToString("dd/MM/yyyy hh:mm:ss");
        }
    }
}
