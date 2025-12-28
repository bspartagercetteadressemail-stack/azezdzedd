# Getting Started with Valorant Porting

## Opening the Project in Visual Studio 2022

1. **Open Visual Studio 2022**
2. Click **File → Open → Project/Solution**
3. Navigate to the project folder and select `ValorantPorting.sln`
4. Wait for Visual Studio to restore NuGet packages (automatic)

## Building and Running

### Option 1: Using Visual Studio UI
1. Select **Debug** or **Release** configuration from the dropdown
2. Press **F5** to build and run with debugging
3. Or press **Ctrl+F5** to run without debugging

### Option 2: Using Command Line
```bash
# From project directory
dotnet restore
dotnet build
dotnet run
```

## First Launch

When you first launch the application, you'll see:

1. **Path Selection Screen**
   - Click "Browse for Valorant Folder"
   - Navigate to your Valorant installation (e.g., `C:\Riot Games\VALORANT`)
   - Click "Select Folder"

2. **Loading Screen**
   - The app will validate your Valorant installation
   - CUE4Parse will initialize and scan PAK files
   - This may take 10-30 seconds

3. **Success Screen**
   - Shows the number of assets found
   - Click "Continue to Assets" to proceed

4. **Main Application**
   - Browse weapon skins in the grid
   - Use the search bar to filter
   - Select skins by clicking on cards
   - Click "Export to Blender" to export selected items

## Project Structure Overview

```
ValorantPorting/
├── ValorantPorting.sln          ← Open this in Visual Studio
├── ValorantPorting.csproj        ← Project file
├── Program.cs                    ← Entry point
├── App.axaml                     ← Application setup
├── Models/                       ← Data structures
├── Services/                     ← Business logic
├── ViewModels/                   ← MVVM ViewModels
├── Views/                        ← UI Views (XAML)
├── Styles/                       ← Custom styles
└── Assets/                       ← Images, icons
```

## Key Technologies

- **.NET 8.0** - Modern C# runtime
- **Avalonia UI 11.0.10** - Cross-platform XAML UI
- **ReactiveUI** - Reactive MVVM framework
- **CUE4Parse** - Unreal Engine asset extraction
- **Newtonsoft.Json** - JSON serialization

## Configuration Location

Your settings are automatically saved in:

**Windows:**
```
%APPDATA%\ValorantPorting\config.json
```

**Example path:**
```
C:\Users\YourName\AppData\Roaming\ValorantPorting\config.json
```

## Troubleshooting Build Issues

### Missing NuGet Packages

If packages fail to restore:
```bash
dotnet nuget locals all --clear
dotnet restore --force
```

### Avalonia Designer Not Working

1. Make sure you have **Avalonia for Visual Studio 2022** extension installed
2. Tools → Extensions and Updates → Search "Avalonia"
3. Install and restart Visual Studio

### Can't Build/Run

1. Verify .NET 8 SDK is installed: `dotnet --version`
2. Should show 8.0.x or higher
3. Download from: https://dotnet.microsoft.com/download/dotnet/8.0

### Runtime Errors

If the app crashes on launch:
1. Check Output window for error details
2. Ensure Avalonia packages are correctly restored
3. Try Clean Solution → Rebuild Solution

## Development Tips

### Hot Reload

Enable hot reload for faster development:
```bash
dotnet watch run
```

Changes to C# code will automatically reload the app.

### XAML Preview

The Avalonia designer provides real-time preview:
1. Open any `.axaml` file
2. View → Designer
3. See live preview while editing

### Debugging

Set breakpoints in C# code:
1. Click in the left margin of code editor
2. Press F5 to start debugging
3. App will pause at breakpoints

## Architecture Overview

### MVVM Pattern

The app follows the Model-View-ViewModel pattern:

- **Models** (`Models/`) - Data structures (WeaponSkin, AppConfig)
- **Views** (`Views/`) - XAML UI files (.axaml)
- **ViewModels** (`ViewModels/`) - Logic and state management

### Service Layer

Services handle business logic:

- **ValorantApiService** - Fetches data from API
- **CUE4ParseService** - Extracts assets from PAK files
- **ExportService** - Handles export to Blender
- **ConfigService** - Manages application settings

### Data Flow

```
User Interaction → ViewModel → Service → API/Files
                    ↓
                  View Updates (via ReactiveUI)
```

## Next Steps

1. **Explore the code** - Start with `Program.cs` and `App.axaml.cs`
2. **Run the app** - Press F5 and test the workflow
3. **Customize** - Modify colors in `Styles/CustomStyles.axaml`
4. **Extend** - Add new features following the existing patterns

## Resources

- [Avalonia Documentation](https://docs.avaloniaui.net/)
- [ReactiveUI Documentation](https://www.reactiveui.net/)
- [.NET 8 Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [Valorant API](https://valorant-api.com/docs)

## Support

For issues or questions:
- Check the main [README.md](README.md)
- Review the Troubleshooting section
- Open an issue on GitHub

---

**Happy coding!** 🚀
