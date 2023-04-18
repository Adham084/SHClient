using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SHClient;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

    }

    public void BtnClicked(object sender, EventArgs e)
    {
        System.Console.WriteLine(sender);
    }
}
