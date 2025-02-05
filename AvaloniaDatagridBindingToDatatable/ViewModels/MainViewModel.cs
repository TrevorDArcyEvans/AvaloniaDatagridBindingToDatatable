using System;

namespace AvaloniaDatagridBindingToDatatable.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        GenerateDatatableColumnsAndRows();
    }

    public System.Data.DataTable YourDT { get; set; } = new();

    private void GenerateDatatableColumnsAndRows()
    {
        // Here we create a DataTable.
        // ... We add 5 columns, each with a Type.
        YourDT.Columns.Add("Dosage", typeof(int));
        YourDT.Columns.Add("Drug", typeof(string));
        YourDT.Columns.Add("Diagnosis", typeof(string));
        YourDT.Columns.Add("Date", typeof(DateTime));
        YourDT.Columns.Add("Survived", typeof(bool));

        // Here we add rows.
        YourDT.Rows.Add(25, "Drug A", "Disease A", DateTime.Now.AddDays(-1), true);
        YourDT.Rows.Add(50, "Drug Z", "Problem Z", DateTime.Now.AddDays(-2).AddHours(-6), false);
        YourDT.Rows.Add(10, "Drug Q", "Disorder Q", DateTime.Now.AddDays(-3).AddMinutes(-12), true);
        YourDT.Rows.Add(21, "Medicine A", "Diagnosis A", DateTime.Now.AddDays(-4), true);
    }
}
