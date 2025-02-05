using Avalonia.Controls;
using AvaloniaDatagridBindingToDatatable.ViewModels;

namespace AvaloniaDatagridBindingToDatatable.Views;

public partial class MainView : UserControl
{
  public MainView()
  {
    InitializeComponent();
    ClickMe.Click += (o, e) =>
    {
      if (DataContext is MainViewModel vm)
      {
        //clear out any existing columns
        while (ExampleDatagrid.Columns.Count > 0)
        {
          ExampleDatagrid.Columns.RemoveAt(ExampleDatagrid.Columns.Count - 1);
        }

        //assign the datatable to the grid
        ExampleDatagrid.ItemsSource = vm.YourDT.DefaultView;

        // create the grid columns based on the datatables columns
        foreach (System.Data.DataColumn x in vm.YourDT.Columns)
        {
          DataGridBoundColumn gridCol = x.DataType == typeof(bool) ? new DataGridCheckBoxColumn() : new DataGridTextColumn();

          gridCol.Header = x.ColumnName;
          gridCol.Binding = new Avalonia.Data.Binding($"Row.ItemArray[{x.Ordinal}]");
          ExampleDatagrid.Columns.Add(gridCol);
        }
      }
    };
  }
}
