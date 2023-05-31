namespace SHClient;

public partial class NotificationsPage : ContentPage
{
	public NotificationsPage()
	{
		InitializeComponent();
	}

	/*public void Asd()
	{
        var request = new NotificationRequest
        {
            NotificationId = 1000,
            Title = "Subscribe for me",
            Subtitle = "Hello Friends",
            Description = "Stay Tuned",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5),
                NotifyRepeatInterval = TimeSpan.FromDays(1)
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }*/
}