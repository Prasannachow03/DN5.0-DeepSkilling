using System;

// Abstract Product
public abstract class Document
{
    public abstract void Open();
    public abstract void Save();
    public abstract string GetDocumentType();
}

// Concrete Products
public class WordDocument : Document
{
    public override void Open() => Console.WriteLine("Opening Word Document (.docx)");
    public override void Save() => Console.WriteLine("Saving Word Document (.docx)");
    public override string GetDocumentType() => "Word Document";
}

public class PdfDocument : Document
{
    public override void Open() => Console.WriteLine("Opening PDF Document (.pdf)");
    public override void Save() => Console.WriteLine("Saving PDF Document (.pdf)");
    public override string GetDocumentType() => "PDF Document";
}

public class ExcelDocument : Document
{
    public override void Open() => Console.WriteLine("Opening Excel Document (.xlsx)");
    public override void Save() => Console.WriteLine("Saving Excel Document (.xlsx)");
    public override string GetDocumentType() => "Excel Document";
}

// Abstract Creator (Factory)
public abstract class DocumentFactory
{
    // Factory Method
    public abstract Document CreateDocument();

    // Template method using the factory method
    public void OpenAndSaveDocument()
    {
        Document doc = CreateDocument();
        Console.WriteLine($"\nDocument Type: {doc.GetDocumentType()}");
        doc.Open();
        doc.Save();
    }
}

// Concrete Factories
public class WordDocumentFactory : DocumentFactory
{
    public override Document CreateDocument() => new WordDocument();
}

public class PdfDocumentFactory : DocumentFactory
{
    public override Document CreateDocument() => new PdfDocument();
}

public class ExcelDocumentFactory : DocumentFactory
{
    public override Document CreateDocument() => new ExcelDocument();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Factory Method Pattern Demo ===\n");

        DocumentFactory[] factories = {
            new WordDocumentFactory(),
            new PdfDocumentFactory(),
            new ExcelDocumentFactory()
        };

        foreach (var factory in factories)
        {
            factory.OpenAndSaveDocument();
        }
    }
}
