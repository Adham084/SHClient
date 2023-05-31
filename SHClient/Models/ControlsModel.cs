namespace SHClient;

public struct ControlsModel
{
    public bool RoomLight { get; set; }
    public bool GarageLight { get; set; }
    public bool HallLight { get; set; }
    public bool FenceLight { get; set; }

    public bool GarageDoor { get; set; }
    public bool Fan { get; set; }

    public bool Alarm { get; set; }
}
