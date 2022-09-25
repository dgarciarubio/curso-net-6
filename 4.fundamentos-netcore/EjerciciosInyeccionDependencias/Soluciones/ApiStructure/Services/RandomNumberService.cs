namespace ApiStructure.Services
{
    public class RandomNumberService : ISinglentonRandomNumberService, IScopeRandomNumberService, ITrasientRandomNumberService
    {
        private readonly int _randomNumber;

        public RandomNumberService() 
        {
            _randomNumber = new Random().Next(0, 100);
        }

        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
