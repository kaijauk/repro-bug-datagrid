# repro_wpffluent_datagrid

Minimal reproduction for [dotnet/wpf#10962](https://github.com/dotnet/wpf/issues/10962)

## How to Reproduce

1. Clone the repo:
```
git clone https://github.com/kaijauk/repro-bug-datagrid/
cd repro-bug-datagrid
```

2. Open the solution in Visual Studio (ensure you're using a version with .NET support for WPF).

3. Build and run the application.

4. Observe the issue:
- The ScrollViewer of the DataGrid resets its offset to 0 when switching between the tabs

## Environment

- .NET version: NET 9.0
- Style: Fluent.xaml (see App.xaml)
