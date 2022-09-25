namespace MyProject.Api.Middlewares
{
    public class FormatLanguage : IFormatLanguage
    {
        private string _language = "en";
        public void SetLanguage(string language)
        {
            this._language = language;
        }
    }
}
