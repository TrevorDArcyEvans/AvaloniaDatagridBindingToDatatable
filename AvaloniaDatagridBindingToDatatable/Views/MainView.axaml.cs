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
      if (DataContext is MainViewModel)
      {
        //clear out any existing columns
        while (ExampleDatagrid.Columns.Count > 0)
        {
          ExampleDatagrid.Columns.RemoveAt(ExampleDatagrid.Columns.Count - 1);
        }

        //assign the datatable to the grid
        ExampleDatagrid.ItemsSource = (DataContext as MainViewModel).YourDT.DefaultView;

        // create the grid columns based on the datatables columns
        foreach (System.Data.DataColumn x in (DataContext as MainViewModel).YourDT.Columns)
        {
          if (x.DataType == typeof(bool))
          {
            ExampleDatagrid.Columns.Add(new DataGridCheckBoxColumn {Header = x.ColumnName, Binding = new Avalonia.Data.Binding($"Row.ItemArray[{x.Ordinal}]")});
          }
          else
          {
            ExampleDatagrid.Columns.Add(new DataGridTextColumn {Header = x.ColumnName, Binding = new Avalonia.Data.Binding($"Row.ItemArray[{x.Ordinal}]")});
          }
        }
      }
    };
  }
}
