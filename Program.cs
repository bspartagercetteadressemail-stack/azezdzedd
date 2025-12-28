using Avalonia;
using Avalonia.ReactiveUI;
using System;

namespace ValorantPorting;

class Program
{
    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseReactiveUI() // 🔥 OBLIGATOIRE
            .WithInterFont()
            .LogToTrace();
}