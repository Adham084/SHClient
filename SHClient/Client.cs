using Mopups.Pages;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SHClient;

public static class Client
{
    private const string Host = "https://shserver.onrender.com/api/";
    private const string SensorsApi = Host + "sensors";
    private const string ControlsApi = Host + "controls";
    private const int GetInterval = 5000; // ms

    public static SensorsModel Sensors;
    public static ControlsModel Controls;

    public static StringBuilder LogString;
    public static event Action<SensorsModel, ControlsModel> OnUpdate;

    private static Timer _timer;
    private static HttpClient _client;

    public static void Initialize()
    {
        _client = new HttpClient();
        LogString = new StringBuilder();

        _timer = new Timer(GetInterval)
        {
            AutoReset = true
        };

        _timer.Elapsed += Elapsed;
        _timer.Start();
    }

    private static async void Elapsed(object sender, ElapsedEventArgs e)
    {
        try
        {
            // Sensors
            Log("Sending GET request for sensors.");
            HttpResponseMessage response = await _client.GetAsync(SensorsApi);

            Log("Received HTTP code: {0}", response.StatusCode);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();
                Log(data);

                Sensors = JsonSerializer.Deserialize<SensorsModel>(data);
            }

            // Controls
            Log("Sending GET request for controls.");
            response = await _client.GetAsync(ControlsApi);

            Log("Received HTTP code: {0}", response.StatusCode);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();
                Log(data);

                Controls = JsonSerializer.Deserialize<ControlsModel>(data);
            }

            // Event
            OnUpdate?.Invoke(Sensors, Controls);
        }
        catch (Exception ex)
        {
            Log("Connection failed: {0}", ex.Message);
        }
    }

    public static async void Send()
    {
        try
        {
            Log("Sending PUT request.");
            HttpResponseMessage response = await _client.PutAsync(ControlsApi, new StringContent(JsonSerializer.Serialize(Controls)));

            Log("Received HTTP code: ", response.StatusCode);
        }
        catch (Exception ex)
        {
            Log("Connection failed: ", ex.Message);
        }
    }

    public static void Log(string message, object info = null)
    {
        Console.WriteLine("[{0}] {1}\n{2}", DateTime.Now, message, info);
        LogString.Append('[').Append(DateTime.Now).Append("] ").Append(message).Append('\n');

        if (info != null)
        {
            LogString.Append(info).Append('\n');
        }
    }
}