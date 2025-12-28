# Changelog

All notable changes to Valorant Porting will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2024-12-28

### Added

#### Core Features
- Initial release of Valorant Porting application
- Full weapon skin browsing and export functionality
- Modern dark-themed UI with Valorant red accents
- Custom title bar with minimize, maximize, and close buttons

#### User Interface
- **Path Selection Screen** - Clean initial setup flow
- **Loading Screen** - Animated progress indicators
- **Success Screen** - Confirmation after initialization
- **Main Content View** - Grid-based asset browser
- **Sidebar Navigation** - Organized category sections
- **Search Functionality** - Real-time skin filtering
- **Responsive Layout** - Adapts to window resizing

#### Services
- **ValorantApiService** - Integration with valorant-api.com
  - Fetch weapon skins with metadata
  - Fetch agent information
  - Download asset images
  - Fallback sample data when offline
- **CUE4ParseService** - Unreal Engine asset extraction
  - PAK file validation
  - Asset extraction from game files
  - Export to Blender-compatible formats
- **ExportService** - Asset export functionality
  - Single and batch export support
  - FBX format export
  - Metadata JSON generation
  - Texture extraction
- **ConfigService** - Configuration management
  - Persistent settings in AppData
  - Automatic save/load
  - Cross-platform path handling

#### Design System
- Custom button styles (primary, secondary, icon, navigation, skin-card)
- Professional color palette (Valorant Red #FF4655)
- Smooth transitions and hover effects (150ms)
- Loading animations (pulse, progress bar)
- Card-based layout with shadows
- Inter font family with system fallback

#### Technical Features
- MVVM architecture with ReactiveUI
- Async/await for all I/O operations
- Proper error handling and logging
- Cross-platform compatibility (Windows, macOS, Linux)
- Compiled bindings for performance
- Memory-efficient image loading

### Documentation
- Comprehensive README.md with features and usage
- GETTING_STARTED.md for developers
- Inline code documentation (XML comments)
- Troubleshooting guide
- API endpoint documentation

### Assets
- Custom Valorant Porting logo (256x256 PNG)
- SVG source for logo
- Application icon

### Configuration
- AppData config storage
- Export settings (format, texture quality)
- View settings (grid size, sort order)
- Valorant path persistence
- Last export location memory

## [Unreleased]

### Planned Features
- Agent skin export support
- Weapon animation export
- Material editor
- Texture upscaling
- Direct Blender plugin integration
- Community asset sharing
- Import custom textures
- Skin preview 3D viewer
- Batch operations progress tracking
- Multi-language support

### Known Issues
- CUE4Parse integration is placeholder implementation
- No actual PAK file parsing yet (requires full CUE4Parse integration)
- Export creates placeholder FBX files
- Limited error recovery in network failures
- No cache management for downloaded images

### To Be Improved
- Add unit tests
- Implement CI/CD pipeline
- Add telemetry (opt-in)
- Improve loading performance
- Add keyboard shortcuts
- Implement undo/redo
- Add export queue management

---

## Version History

### Version Numbering

Versions follow Semantic Versioning:
- **Major** (1.x.x) - Breaking changes
- **Minor** (x.1.x) - New features, backwards compatible
- **Patch** (x.x.1) - Bug fixes

### Release Schedule

- Major releases: Quarterly
- Minor releases: Monthly
- Patch releases: As needed

### Upgrade Notes

When upgrading from a previous version:
1. Export your current configuration
2. Install the new version
3. Import configuration if needed
4. Check changelog for breaking changes

---

**[1.0.0]**: https://github.com/yourusername/valorant-porting/releases/tag/v1.0.0
