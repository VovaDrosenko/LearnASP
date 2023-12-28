using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using Microsoft.AspNetCore.Mvc;
using asd.Models.Entities;

namespace asd.Controllers
{
    public class ExcelController : Controller
    {
        SheetsService sheetService = SheetService.GetSheetsService();
        string spreadsheetId = "13Sx-M05nYt7q7CQHTs74kKy4lYxb2iuQ5e26mMtmPpo";
        string range = "form!B2:F";

        public IActionResult Index()
        {
            SpreadsheetsResource.ValuesResource.GetRequest request = sheetService.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            IList<IList<object>> values = response.Values;


            List<SheetData> sheetDataList = new List<SheetData>();
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    int.TryParse(row[3]?.ToString(), out int roomValue);
                    int.TryParse(row[4]?.ToString(), out int dormintoryValue);
                    var sheetData = new SheetData
                    {
                        firstName = row[0].ToString(),
                        lastName = row[1].ToString(),
                        midleName = row[2].ToString(),
                        room = roomValue,
                        dormintory = dormintoryValue
                };
                    sheetDataList.Add(sheetData);
                }
            }

            return View(sheetDataList);
        }

    }
}
