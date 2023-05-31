using Mopups.Services;

namespace SHClient;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        Client.OnUpdate += OnClientUpdate;
        Client.Initialize();
    }

    private void OnClientUpdate(SensorsModel sensors, ControlsModel controls)
    {
        tempLbl.Text = "Temperature: " + sensors.Temperature + "°C";
        lightLbl.Text = "Light: " + sensors.Light + "%";

        roomLightSwt.IsToggled = controls.RoomLight;
        garageDoorSwt.IsToggled = controls.GarageLight;
        hallLightSwt.IsToggled = controls.HallLight;
        fenceLightSwt.IsToggled = controls.FenceLight;

        fanSwt.IsToggled = controls.Fan;
        garageDoorSwt.IsToggled = controls.GarageDoor;

        if (controls.Alarm && MopupService.Instance.PopupStack.Count == 0)
        {
            MopupService.Instance.PushAsync(new AlarmPopup());
        }
    }

    public void OnToggled(object sender, EventArgs e)
    {
        Client.Controls = new ControlsModel
        {
            RoomLight = roomLightSwt.IsToggled,
            GarageLight = garageDoorSwt.IsToggled,
            HallLight = hallLightSwt.IsToggled,
            FenceLight = fenceLightSwt.IsToggled,

            Fan = fanSwt.IsToggled,
            GarageDoor = garageDoorSwt.IsToggled
        };

        Client.Send();
    }
}
