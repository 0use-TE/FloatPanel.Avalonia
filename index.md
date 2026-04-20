---
_layout: landing
---

# FloatPanel.Avalonia

A flexible layout panel for Avalonia UI, inspired by MudBlazor's MudStack and MudSpacer components.

## Features

- **FloatPanel** - A versatile layout container with support for:
  - Horizontal and vertical orientations
  - Configurable spacing between child elements
  - Justify content alignment (Start, Center, End, SpaceBetween, SpaceAround, SpaceEvenly)
  - Cross-axis alignment (Start, Center, End, Stretch)
  - Automatic wrapping when content overflows

- **Spacer** - A lightweight component that occupies remaining space in a FloatPanel

## Quick Example

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Settings"/>
    <Spacer/>
    <Button Content="Apply"/>
</FloatPanel>
```

## Navigation

- [Introduction](docs/introduction.md) - Overview and concepts
- [Getting Started](docs/getting-started.md) - Quick start guide
- [Troubleshooting](docs/troubleshooting.md) - Common issues and solutions
- [API Reference](api/) - Detailed API documentation