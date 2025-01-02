using DinkToPdf;
using DinkToPdf.Contracts;

public class PdfService
{
    private readonly IConverter _pdfConverter;

    public PdfService(IConverter pdfConverter)
    {
        _pdfConverter = pdfConverter;
    }

    public byte[] GeneratePdfFromHtml(string htmlContent)
    {
        var globalSettings = new GlobalSettings
        {
            PaperSize = PaperKind.A4,
            Orientation = Orientation.Portrait,
            Margins = new MarginSettings { Top = 10, Bottom = 10, Left = 10, Right = 10 }
        };

        var objectSettings = new ObjectSettings
        {
            PagesCount = true,
            HtmlContent = htmlContent
        };

        var pdfDocument = new HtmlToPdfDocument()
        {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        return _pdfConverter.Convert(pdfDocument);
    }
}
