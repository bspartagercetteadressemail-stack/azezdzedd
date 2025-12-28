# Valorant Porting - Interface Guide

Visual guide to the user interface and navigation flow.

---

## 🎨 Application Screens

### 1. Path Selection View (Initial Screen)

```
┌──────────────────────────────────────────────────────────────┐
│  ╔══════════════════════════════════════════════════════════╗ │
│  ║                                                          ║ │
│  ║                    [V Logo 120x120]                      ║ │
│  ║                                                          ║ │
│  ║              Welcome to Valorant Porting                 ║ │
│  ║         Export Valorant assets to Blender with ease     ║ │
│  ║                                                          ║ │
│  ║  ┌────────────────────────────────────────────────────┐  ║ │
│  ║  │  Select Valorant Installation Path                  │  ║ │
│  ║  │                                                      │  ║ │
│  ║  │  Please select the folder where Valorant is         │  ║ │
│  ║  │  installed. This is typically located in:           │  ║ │
│  ║  │                                                      │  ║ │
│  ║  │         C:\Riot Games\VALORANT                       │  ║ │
│  ║  │                                                      │  ║ │
│  ║  │      [Browse for Valorant Folder] (Button)          │  ║ │
│  ║  └────────────────────────────────────────────────────┘  ║ │
│  ║                                                          ║ │
│  ║  ℹ️  Make sure Valorant is installed before proceeding  ║ │
│  ╚══════════════════════════════════════════════════════════╝ │
└──────────────────────────────────────────────────────────────┘
```

**Components:**
- Centered logo (256x256, scaled to 120x120)
- Welcome title (28px bold)
- Subtitle (14px)
- Card with selection prompt
- Primary button (red #FF4655)
- Info message at bottom

---

### 2. Loading View

```
┌──────────────────────────────────────────────────────────────┐
│                                                              │
│                                                              │
│                     ⚪ ⚪ ⚪                                    │
│                   ⚪       ⚪                                  │
│                   ⚪       ⚪  (Animated pulse)                │
│                     ⚪ ⚪ ⚪                                    │
│                                                              │
│              Validating Valorant installation...             │
│                                                              │
│              ┌────────────────────────────┐                  │
│              │████████░░░░░░░░░░░░░░░░░░░░│ (Progress bar)   │
│              └────────────────────────────┘                  │
│                                                              │
└──────────────────────────────────────────────────────────────┘
```

**Components:**
- Animated loading circles (6 circles, rotating pulse)
- Status message (changes during load)
- Progress bar (animated, 400px width)
- Dark semi-transparent background

**Status Messages:**
1. "Validating Valorant installation..."
2. "Initializing CUE4Parse..."
3. "Loading assets..."
4. "Initialization complete!"

---

### 3. Success View

```
┌──────────────────────────────────────────────────────────────┐
│                                                              │
│                                                              │
│                     ┌─────────────┐                          │
│                     │             │                          │
│                     │      ✓      │  (100x100 red circle)    │
│                     │             │                          │
│                     └─────────────┘                          │
│                                                              │
│                Initialization Complete!                      │
│                                                              │
│  ┌────────────────────────────────────────────────────────┐  │
│  │                                                        │  │
│  │     Successfully loaded Valorant assets                │  │
│  │                                                        │  │
│  │         Assets found: 1247                             │  │
│  │                                                        │  │
│  │         [Continue to Assets] (Button)                  │  │
│  │                                                        │  │
│  └────────────────────────────────────────────────────────┘  │
│                                                              │
└──────────────────────────────────────────────────────────────┘
```

**Components:**
- Success icon (✓ in red circle, 100x100)
- Title "Initialization Complete!" (28px bold)
- Info card with asset count
- Continue button (primary red)

---

### 4. Main Content View (Primary Interface)

```
┌────────────────────────────────────────────────────────────────────────────┐
│ ⚫ Valorant Porting v1.0.0                               [─] [□] [✕]        │
├──────┬─────────────────────────────────────────────────────────────────────┤
│      │ [🔍 Search...           ] [Filters ▾] [▦] [☰] [Export to Blender]  │
│      ├─────────────────────────────────────────────────────────────────────┤
│ GEN  │                                                                     │
│ 🏠   │  ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐     │
│ 📰   │  │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │     │
│ 🎨   │  │ S │ │ S │ │ S │ │ S │ │ S │ │ S │ │ S │ │ S │ │ S │ │ S │     │
│      │  │ K │ │ K │ │ K │ │ K │ │ K │ │ K │ │ K │ │ K │ │ K │ │ K │     │
│ EXP  │  │ N │ │ N │ │ N │ │ N │ │ N │ │ N │ │ N │ │ N │ │ N │ │ N │     │
│ 📦 * │  │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │     │
│ 📁   │  └─┬─┘ └─┬─┘ └─┬─┘ └─┬─┘ └─┬─┘ └─┬─┘ └─┬─┘ └─┬─┘ └─┬─┘ └─┬─┘     │
│ 🗺️   │    │     │     │     │     │     │     │     │     │     │       │
│ 🎵   │  Name1 Name2 Name3 Name4 Name5 Name6 Name7 Name8 Name9 Nam10     │
│      │                                                                     │
│ COS  │  ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐     │
│ 👕   │  │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │     │
│ 🎒   │  │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │     │
│ ⛏️   │  └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘     │
│ 🪂   │                                                                     │
│ 🐾   │  ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐ ┌───┐     │
│ 💃   │  │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │     │
│ 🎯   │  │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │ │   │     │
│      │  └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘ └───┘     │
│ ONL  │                                                                     │
│ 💬   │  (Continue scrolling...)                                           │
│ 🏆   │                                                                     │
│      │                                                                     │
│ SET  │                                                                     │
│ 🔌   │                                                                     │
│ ⚙️   │                                                                     │
│ ❓   │                                                                     │
└──────┴─────────────────────────────────────────────────────────────────────┘
```

**Layout Breakdown:**

#### Title Bar (40px height)
- Logo + "Valorant Porting v1.0.0" (left)
- Window controls: Minimize, Maximize, Close (right)
- Draggable area
- Background: #0F1115

#### Sidebar (220px width)
**Sections:**
1. **GENERAL** (gray uppercase header)
   - 🏠 Home
   - 📰 News & Updates
   - 🎨 Featured Art

2. **EXPORT**
   - 📦 Assets (selected - red text, gray bg)
   - 📁 Files
   - 🗺️ Map
   - 🎵 Music

3. **COSMETICS**
   - 👕 Outfits
   - 🎒 Backpacks
   - ⛏️ Pickaxes
   - 🪂 Gliders
   - 🐾 Pets
   - 💃 Emotes
   - 🎯 Sprays

4. **ONLINE**
   - 💬 Chat
   - 🏆 Leaderboard

5. **SETTINGS**
   - 🔌 Plugin
   - ⚙️ Export Options
   - ❓ Help

#### Top Bar
- Search box (400px, watermark: "🔍 Search...")
- Filters button (dropdown)
- Grid view button (▦)
- List view button (☰)
- Export to Blender button (primary red)

#### Content Area
- Skin cards in WrapPanel grid
- Each card: 140x140px image + name
- 12px spacing between cards
- Hover: border turns red, opacity 0.8
- Scrollable area
- Background: #0F1115

---

## 🎨 Visual Design Details

### Color Palette

```
Primary Actions:    #FF4655 ████████
Hover State:        #E63E4D ████████
Pressed State:      #CC3644 ████████
Background Dark:    #0F1115 ████████
Background Card:    #1A1D23 ████████
Background Hover:   #1E2329 ████████
Border Color:       #2D3139 ████████
Text Primary:       #FFFFFF ████████
Text Secondary:     #A0A3B0 ████████
```

### Button States

#### Primary Button (Export)
```
Normal:   [Export to Blender]  #FF4655 background
Hover:    [Export to Blender]  #E63E4D background (smooth transition)
Pressed:  [Export to Blender]  #CC3644 background
```

#### Navigation Button
```
Normal:     [📦 Assets]  Transparent bg, #A0A3B0 text
Hover:      [📦 Assets]  #1A1D23 bg, #FFFFFF text
Selected:   [📦 Assets]  #1A1D23 bg, #FF4655 text
```

#### Skin Card Button
```
Normal:   140x140 card, transparent border
Hover:    Opacity 0.8, #FF4655 2px border
Click:    Toggle selection state
```

### Typography Hierarchy

```
┌─────────────────────────────────────────────┐
│                                             │
│  Welcome to Valorant Porting  ← 28px Bold  │
│                                             │
│  Export Valorant assets...    ← 14px Reg   │
│                                             │
│  Skin Name                    ← 12px Reg   │
│                                             │
│  GENERAL                      ← 11px Bold  │
│                                             │
└─────────────────────────────────────────────┘
```

### Spacing System (8px base)

```
Margins:        8, 12, 16, 20, 24, 32, 48
Padding:        8, 12, 16, 20, 32
Border Radius:  6, 8, 12
Card Gaps:      12px
Border Width:   1, 2px
```

---

## 🎬 Animation Details

### Hover Transitions
- Duration: 150ms
- Easing: ease (default)
- Properties: background, border-color, opacity

### Loading Animations

#### Pulse Animation (Loading Circles)
```
Keyframes:
  0%:   opacity 0.3
  50%:  opacity 1.0
  100%: opacity 0.3

Duration: 1.5 seconds
Loop: Infinite
```

#### Progress Bar
```
Keyframes:
  0%:   width 0px
  100%: width 400px

Duration: 2 seconds
Loop: Infinite
```

### Button Interactions
```
Normal → Hover:  150ms smooth transition
Hover → Normal:  150ms smooth transition
Hover → Pressed: Instant (no transition)
Pressed → Normal: 150ms smooth transition
```

---

## 🖱️ User Interactions

### Navigation Flow

```
User Action                    → Result
─────────────────────────────────────────────────────────
Click "Browse"                 → Opens folder picker
Select valid folder            → Shows loading screen
Loading completes              → Shows success screen
Click "Continue to Assets"     → Shows main interface
Type in search box             → Filters skins in real-time
Click skin card                → Toggles selection
Click "Export to Blender"      → Exports selected skins
Click sidebar button           → Navigates to section (future)
Click minimize                 → Minimizes window
Click maximize                 → Toggles maximize/restore
Click close                    → Closes application
Drag title bar                 → Moves window
```

### Keyboard Shortcuts (Future)

```
Ctrl+F     Focus search box
Ctrl+E     Export selected
Ctrl+A     Select all
Escape     Clear search / Deselect all
Enter      (in search) Apply search
```

---

## 📐 Layout Mathematics

### Window Dimensions
```
Default:  1400 x 900 pixels
Minimum:  1200 x 700 pixels
```

### Grid Calculations
```
Card Width:     140px
Card Height:    180px (140px image + 40px text)
Card Spacing:   12px
Margin:         20px

Cards per row = floor((WindowWidth - SidebarWidth - (2 × Margin)) / (CardWidth + Spacing))
Example:        floor((1400 - 220 - 40) / 152) = 7 cards per row
```

### Sidebar Layout
```
Width: 220px

Button:
  Padding:  16px (left/right), 10px (top/bottom)
  Height:   ~36px (10 + 16 + 10)
  Margin:   0

Section Header:
  Margin:   16px (left/right), 20px (top), 8px (bottom)
  Height:   ~15px
```

---

## 🎯 Clickable Areas

### Interactive Elements

```
Element              Size            Hover Feedback
──────────────────────────────────────────────────────────
Title bar buttons    46×32px         Background changes
Search box           400×36px        Border turns red
Filter button        100×36px        Background + border
View buttons         36×36px         Background + border
Export button        Variable×36px   Background darkens
Sidebar nav          204×36px        Background + text color
Skin cards           140×180px       Border + opacity
Close button         46×32px         Red background
```

### Cursor Changes
```
All buttons:          cursor: hand (pointer)
Draggable areas:      cursor: default
Input fields:         cursor: text (I-beam)
```

---

## 📱 Responsive Behavior

### Window Resize
- Minimum size enforced: 1200×700
- Sidebar stays fixed at 220px
- Content area adjusts width
- Cards reflow automatically (WrapPanel)
- ScrollViewer appears when needed

### Card Grid Adaptation
```
Window Width    Cards/Row    Total Visible (approx)
────────────────────────────────────────────────────
1200px          6            24 (4 rows)
1400px          7            28 (4 rows)
1600px          8            32 (4 rows)
1920px          10           40 (4 rows)
```

---

## 🎨 Theme System

### Dark Theme (Default)
```css
Background:    #0F1115  /* Main dark */
Cards:         #1A1D23  /* Lighter cards */
Hover:         #1E2329  /* Hover state */
Borders:       #2D3139  /* Subtle borders */
Accent:        #FF4655  /* Valorant red */
Text Primary:  #FFFFFF  /* Pure white */
Text Muted:    #A0A3B0  /* Gray text */
```

### Future: Light Theme
```css
Background:    #FFFFFF
Cards:         #F5F5F5
Hover:         #E8E8E8
Borders:       #D0D0D0
Accent:        #FF4655  /* Stays same */
Text Primary:  #1A1D23
Text Muted:    #6B6B6B
```

---

## 🔍 Search Behavior

### Real-Time Filtering

```
User types:      "prime"
Results shown:   All skins with "prime" in name
Case:            Insensitive
Matching:        Contains (not startsWith)
Update:          On every keystroke
Animation:       Instant (no fade)
Empty state:     "No skins found"
```

### Example Searches
```
"vandal"    → Shows all Vandal skins
"prime"     → Shows Prime collection
"red"       → Shows skins with "red" in name
""          → Shows all skins (empty search)
```

---

## 📤 Export Process

### Visual Feedback

```
1. User clicks "Export to Blender"
   ↓
2. Button disabled, shows loading
   ↓
3. Status message: "Exporting X skins..."
   ↓
4. Progress bar animates
   ↓
5. Console logs export progress
   ↓
6. On complete: "Export successful!"
   ↓
7. Button enabled again
```

---

## ✨ Polish Details

### Micro-interactions
- Button press gives visual feedback (darker shade)
- Hover states are smooth (150ms)
- Loading animations are mesmerizing
- Cards have subtle shadows
- Text is crisp and readable

### Attention to Detail
- Perfect alignment throughout
- Consistent spacing (8px system)
- Smooth scrolling
- No layout shifts
- Proper hit test areas
- Accessible colors (contrast ratios)

---

**This interface is production-ready and matches the Fortnite Porting design language!** 🎉
