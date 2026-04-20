# FloatPanel.Avalonia

A flexible layout panel for Avalonia UI, similar to MudBlazor's MudStack and MudSpacer.

## Features

- **FloatPanel** - A layout container with support for:
  - Horizontal and vertical orientations
  - Configurable spacing between child elements
  - Justify content alignment (Start, Center, End, SpaceBetween, SpaceAround, SpaceEvenly)
  - Cross-axis alignment (Start, Center, End, Stretch)
  - Automatic wrapping when content overflows

- **Spacer** - A component that occupies remaining space in a FloatPanel

## Projects

- **FloatPanelLib** - The control library (FloatPanel and Spacer)
- **FloatPanel** - Main UI application with shared MainView
- **FloatPanel.Desktop** - Desktop application
- **FloatPanel.Browser** - WebAssembly application

## Quick Start

### Add Namespace

```xml
xmlns:float="clr-namespace:FloatPanel.Controls;assembly=FloatPanelControls"
```

### Horizontal Layout (Left-Space-Right)

```xml
<float:FloatPanel Orientation="Horizontal">
    <Button Content="Settings"/>
    <float:Spacer/>
    <Button Content="Apply"/>
</float:FloatPanel>
```

### Vertical Layout (Top-Space-Bottom)

```xml
<float:FloatPanel Orientation="Vertical">
    <TextBlock Text="Title"/>
    <float:Spacer/>
    <Button Content="OK"/>
</float:FloatPanel>
```

## API Reference

### FloatPanel Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Orientation` | `Orientation` | `Horizontal` | Layout direction |
| `Spacing` | `double` | `8` | Space between children |
| `Justify` | `JustifyContent` | `Start` | Main axis alignment |
| `Align` | `AlignItems` | `Stretch` | Cross axis alignment |
| `Wrap` | `bool` | `false` | Enable wrapping |

### JustifyContent Enum

- `Start` - Align to start
- `Center` - Align to center
- `End` - Align to end
- `SpaceBetween` - Equal space between items
- `SpaceAround` - Equal space around items
- `SpaceEvenly` - Uniform spacing

### AlignItems Enum

- `Start` - Align to start of cross axis
- `Center` - Align to center of cross axis
- `End` - Align to end of cross axis
- `Stretch` - Stretch to fill cross axis

## License

MIT
