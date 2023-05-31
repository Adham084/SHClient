using Mopups.Pages;
using Mopups.Services;

namespace SHClient;

public partial class AlarmPopup : PopupPage
{
    public AlarmPopup()
    {
        InitializeComponent();
    }

    private void Dismiss(object sender, EventArgs e)
    {
        Client.Controls.Alarm = false;
        Client.Send();

        MopupService.Instance.PopAsync();
    }
}