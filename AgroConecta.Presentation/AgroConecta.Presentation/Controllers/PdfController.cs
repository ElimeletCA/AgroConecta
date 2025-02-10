namespace AgroConecta.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;

[Route("[controller]/[action]")]
[ApiController]
public class PdfController : ControllerBase
{
    [HttpGet]
    public IActionResult GeneratePdf()
    {
        QuestPDF.Settings.License = LicenseType.Community;
        string svgContent = GenerateSvg();
        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.Header().Svg(svgContent);
                
            
                // Aquí generamos la tabla
                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(); // Primera columna
                        columns.RelativeColumn(); // Segunda columna
                        columns.RelativeColumn(); // Tercera columna
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Columna 1").Bold();
                        header.Cell().Text("Columna 2").Bold();
                        header.Cell().Text("Columna 3").Bold();
                    });

                    // Contenido de la tabla
                    for (int i = 1; i <= 5; i++)
                    {
                        table.Cell().Text($"Fila {i}, Columna 1");
                        table.Cell().Text($"Fila {i}, Columna 2");
                        table.Cell().Text($"Fila {i}, Columna 3");
                    }
                });

                page.Footer().AlignCenter().Text("Página {number}");
            });
        });

        using var stream = new MemoryStream();
        document.GeneratePdf(stream);
        stream.Position = 0;

        // Convertir a Base64
        string base64Pdf = Convert.ToBase64String(stream.ToArray());

        return Ok(base64Pdf);
    }
    // Función para generar un SVG básico
    private string GenerateSvg()
    {
        string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200' viewBox='0 0 200 200'>
    <circle cx='100' cy='100' r='80' stroke='black' stroke-width='3' fill='yellow' />
    <text x='50%' y='50%' font-size='20' text-anchor='middle' fill='black' dy='.3em'>Ejemplo SVG</text>
</svg>";
        return svgContent;
    }

}