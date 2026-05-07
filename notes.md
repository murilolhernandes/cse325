# Create a web API with ASP.NET Core controllers:

## 1. Additional record:

### Http Post (Create) Request:
`
POST {{ContosoPizza_HostAddress}}/pizza/
Content-Type: application/json

{
  "name": "Margherita",
  "isGlutenFree": false
}
`

### Http Response:
`
HTTP/1.1 201 Created
Connection: close
Content-Type: application/json; charset=utf-8
Date: Thu, 07 May 2026 18:38:33 GMT
Server: Kestrel
Location: http://localhost:5018/Pizza/3
Transfer-Encoding: chunked

{
  "id": 3,
  "name": "Margherita",
  "isGlutenFree": false
}
`

## 2. Returned status code for CRUD Operations:

### Http GET Request:
`
GET {{ContosoPizza_HostAddress}}/pizza/

Code:
HTTP/1.1 200 OK
`

### Http GET(id) Request:
`
GET {{ContosoPizza_HostAddress}}/pizza/1

Code:
HTTP/1.1 200 OK
`

### Http POST:
`
POST {{ContosoPizza_HostAddress}}/pizza/

Code:
HTTP/1.1 201 Created
`

### Http PUT:
`
PUT {{ContosoPizza_HostAddress}}/pizza/4

Code:
HTTP/1.1 204 No Content
`

### Http DELETE:
`
DELETE {{ContosoPizza_HostAddress}}/pizza/4

Code:
HTTP/1.1 204 No Content
`

# Sales Summary function:

`
var salesSummary = Path.Combine(currentDirectory, "salesSummary");
Directory.CreateDirectory(salesSummary);

CreateSummaryReport(salesFiles, salesTotal, salesSummary);

void CreateSummaryReport(IEnumerable<string> salesFiles, double totalSales, string outputDirectory)
{
    var reportPath = Path.Combine(outputDirectory, "summary-report.txt");
    var sb = new System.Text.StringBuilder();

    sb.AppendLine("Sales Summary");
    sb.AppendLine("----------------------------");
    sb.AppendLine($"Total Sales: {totalSales:C}");
    sb.AppendLine();
    sb.AppendLine("Details:");

    foreach (var file in salesFiles)
    {
        string salesJson = File.ReadAllText(file);
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        string fileName = Path.GetFileName(file);

        sb.AppendLine($" {fileName}: {data?.Total ?? 0:C}");
    }

    File.WriteAllText(reportPath, sb.ToString());
}
`