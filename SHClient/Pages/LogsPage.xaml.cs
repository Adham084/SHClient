namespace SHClient;

public partial class LogsPage : ContentPage
{
	public static LogsPage Instance;
    public Editor Editor => logs;

	public LogsPage ()
	{
		Instance = this;
		InitializeComponent();
    }
}