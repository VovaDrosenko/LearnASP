using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace asd
{
    public class SheetService
    {
        // Ваш файл ключа
        private static readonly string CredentialsPath = "testexcel-408911-735dcf5f5473.json";
        private static readonly string ApplicationName = "TestingSheets";

        public static SheetsService GetSheetsService()
        {
            GoogleCredential credential;

            using (var stream = new FileStream(CredentialsPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(new[] { SheetsService.Scope.SpreadsheetsReadonly });
            }

            // Створіть об'єкт SheetsService
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service; 
        }
    }
}
