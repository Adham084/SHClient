namespace SHClient;

public struct ControlsModel
{
    public bool RoomLight { get; set; }
    public bool HallLight { get; set; }
    
    public bool GarageLight { get; set; }
    public bool FenceLight { get; set; }

    public bool GarageDoor { get; set; }
    public bool Fan { get; set; }

    public bool Alarm { get; set; }
    
    // TimeStamps
    
    public long GarageLightTS { get; set; }
    public long FenceLightTS { get; set; }

    public long GarageDoorTS { get; set; }
    public long FanTS { get; set; }

    public long AlarmTS { get; set; }
}
