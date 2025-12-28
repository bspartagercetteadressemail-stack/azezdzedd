# Valorant Porting

![Version](https://img.shields.io/badge/version-1.0.0-red)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Avalonia](https://img.shields.io/badge/Avalonia-11.0.10-blue)
![License](https://img.shields.io/badge/license-Educational-green)

A professional desktop application for exporting Valorant weapon skins and assets to Blender, built with .NET 8 and Avalonia UI.

<div align="center">
  <img src="Assets/logo.png" alt="Valorant Porting Logo" width="200"/>
</div>

## Features

- **Modern Dark UI**: Beautiful dark theme inspired by Fortnite Porting with Valorant red accents
- **Asset Browser**: Browse and search through all Valorant weapon skins with visual thumbnails
- **Batch Export**: Export multiple skins to Blender simultaneously
- **API Integration**: Real-time data from valorant-api.com
- **PAK Extraction**: Extract 3D models and textures using CUE4Parse
- **Smart Configuration**: Automatic config persistence in AppData
- **Smooth Animations**: Fluid transitions and loading states
- **Cross-Platform**: Runs on Windows, macOS, and Linux

## Screenshots

### Path Selection Screen
Clean initial setup flow to select Valorant installation directory.

### Main Asset Browser
Grid view of all weapon skins with search and filter capabilities.

### Export Process
Real-time progress feedback during asset extraction and export.

## Installation

### Prerequisites

- **.NET 8 SDK** or later ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- **Valorant** must be installed on your system
- **Visual Studio 2022** or **JetBrains Rider** (recommended for development)
- **Blender** (optional, for viewing exported assets)

### Building from Source

1. Clone the repository:
```bash
git clone https://github.com/yourusername/valorant-porting.git
cd valorant-porting
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run
```

### Creating a Release Build

```bash
dotnet publish -c Release -r win-x64 --self-contained
```

## Project Structure

```
ValorantPorting/
├── Assets/               # Application assets (logo, images)
├── Models/              # Data models (WeaponSkin, Agent, AppConfig)
├── Services/            # Business logic services
│   ├── ValorantApiService.cs    # API integration
│   ├── CUE4ParseService.cs      # PAK file extraction
│   ├── ExportService.cs         # Export functionality
│   └── ConfigService.cs         # Configuration management
├── ViewModels/          # MVVM view models with ReactiveUI
│   ├── MainWindowViewModel.cs
│   ├── PathSelectionViewModel.cs
│   ├── LoadingViewModel.cs
│   ├── SuccessViewModel.cs
│   └── MainContentViewModel.cs
├── Views/               # Avalonia UI views
│   ├── MainWindow.axaml
│   ├── PathSelectionView.axaml
│   ├── LoadingView.axaml
│   ├── SuccessView.axaml
│   └── MainContentView.axaml
├── Styles/              # Custom styles and themes
│   └── CustomStyles.axaml
├── App.axaml            # Application entry point
├── Program.cs           # Main program
└── ValorantPorting.csproj
```

## Usage

### 1. Initial Setup

1. Launch ValorantPorting
2. Click "Browse for Valorant Folder"
3. Navigate to your Valorant installation directory (typically `C:\Riot Games\VALORANT`)
4. The application will validate and initialize CUE4Parse

### 2. Browsing Assets

- Use the search bar to filter skins by name
- Click on the sidebar categories to navigate different asset types
- Hover over skin cards to see selection highlight
- Click cards to select/deselect skins for export

### 3. Exporting to Blender

1. Select one or more weapon skins
2. Click "Export to Blender" in the top-right corner
3. The export process will:
   - Download high-resolution icons
   - Extract 3D models from PAK files
   - Export as FBX format
   - Create metadata JSON files
4. Find exported files in your Documents folder

### 4. Configuration

The application automatically saves your settings in:
- **Windows**: `%APPDATA%\ValorantPorting\config.json`
- **macOS**: `~/Library/Application Support/ValorantPorting/config.json`
- **Linux**: `~/.config/ValorantPorting/config.json`

Configuration includes:
- Valorant installation path
- Last export directory
- Export settings (format, texture quality, etc.)
- View preferences (grid size, sort order)

## Technologies Used

### Frontend
- **Avalonia UI 11.0.10** - Cross-platform XAML-based UI framework
- **ReactiveUI** - MVVM framework with reactive extensions
- **FluentTheme** - Modern UI design system

### Backend
- **.NET 8.0** - Latest .NET runtime
- **CUE4Parse 3.0.0** - Unreal Engine asset extraction
- **Newtonsoft.Json 13.0.3** - JSON serialization

### APIs
- **Valorant API** (https://valorant-api.com) - Official Valorant data

## API Endpoints

The application uses the following Valorant API endpoints:

- `GET /v1/weapons/skins` - Fetch all weapon skins
- `GET /v1/agents` - Fetch all playable agents
- `GET /v1/buddies` - Fetch gun buddy charms

All API responses are cached locally for performance.

## Design System

### Colors
- **Primary**: #FF4655 (Valorant Red)
- **Background**: #0F1115 (Dark)
- **Cards**: #1A1D23 (Slightly lighter)
- **Borders**: #2D3139
- **Text**: #FFFFFF (Primary), #A0A3B0 (Secondary)

### Typography
- **Font**: Inter (system fallback)
- **Titles**: Bold, 28px
- **Body**: Regular, 14px
- **Small**: 12px

### Layout
- **Sidebar**: 220px fixed width
- **Cards**: 140x140px with 12px spacing
- **Border Radius**: 8-12px
- **Shadows**: Subtle 0 4px 16px rgba(0,0,0,0.25)

## Troubleshooting

### "PAK directory not found"
- Ensure you selected the correct Valorant installation folder
- The path should contain: `ShooterGame/Content/Paks`

### "No PAK files found"
- Verify Valorant is fully installed
- Try repairing Valorant through Riot Client

### "Failed to initialize CUE4Parse"
- Make sure you have read permissions for the Valorant directory
- Run as administrator if necessary (Windows)

### Assets not loading
- Check your internet connection (API requires connectivity)
- The app will fallback to sample data if API is unavailable

### Export fails
- Ensure you have write permissions to the output directory
- Check available disk space

## Development

### Debug Mode

Run in debug mode with hot reload:
```bash
dotnet watch run
```

### Code Style

- Follow Microsoft C# coding conventions
- Use async/await for all I/O operations
- Implement proper error handling with try-catch
- Add XML documentation comments for public APIs

### Adding New Features

1. Create model in `Models/`
2. Implement service in `Services/`
3. Create ViewModel in `ViewModels/`
4. Design View in `Views/`
5. Update styles if needed in `Styles/CustomStyles.axaml`

## Contributing

This is an educational project. Contributions are welcome:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is for **educational purposes only**.

**Valorant** and all related assets are property of **Riot Games, Inc.**

This application does not:
- Distribute Valorant game files
- Modify game files
- Enable cheating or unfair advantages
- Violate Riot Games Terms of Service

Use at your own risk. The developers are not responsible for any consequences of using this tool.

## Acknowledgments

- **Riot Games** - Creators of Valorant
- **valorant-api.com** - API provider
- **CUE4Parse** - Unreal Engine asset parser
- **Avalonia Team** - Cross-platform UI framework
- **Fortnite Porting** - UI design inspiration

## Support

For issues, questions, or suggestions:
- Open an issue on GitHub
- Check existing issues for solutions
- Consult the Troubleshooting section

## Roadmap

- [ ] Support for agent skins
- [ ] Weapon animation export
- [ ] Material editor
- [ ] Texture upscaling
- [ ] Direct Blender plugin integration
- [ ] Community asset sharing

---

**Made with ❤️ for the Valorant community**

**Version 1.0.0** | Last Updated: December 2024
