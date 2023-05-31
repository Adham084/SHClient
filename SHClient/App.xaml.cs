namespace SHClient;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();

        Shell.Current.Navigated += Current_Navigated;
    }

    private void Current_Navigated(object sender, ShellNavigatedEventArgs e)
    {
        if (e.Current.Location.ToString() == "//D_FAULT_ShellContent6")
        {
            if (LogsPage.Instance != null)
                LogsPage.Instance.Editor.Text = Client.LogString?.ToString();
        }
    }
}
