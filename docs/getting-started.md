# Getting Started

This guide will help you add FloatPanel.Avalonia to your project and create your first layout.

## Installation

### NuGet Package

```bash
dotnet add package FloatPanel
```

### Project Reference

```xml
<ProjectReference Include="path/to/FloatPanelLib/FloatPanelLib.csproj" />
```

## Prerequisites

- .NET 8.0 or later
- Avalonia 12.0.0 or later

## Adding the Namespace

Before using FloatPanel in your XAML, add the namespace:

```xml
xmlns:float="clr-namespace:FloatPanel.Controls;assembly=FloatPanelControls"
```

## Basic Usage

### Horizontal Layout

Create a horizontal layout with elements on left and right sides:

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Back"/>
    <Spacer/>
    <Button Content="Next"/>
</FloatPanel>
```

### Vertical Layout

Create a vertical layout with content stacked:

```xml
<FloatPanel Orientation="Vertical">
    <TextBlock Text="Title"/>
    <Spacer/>
    <Button Content="Action"/>
</FloatPanel>
```

## Examples

### Toolbar

```xml
<FloatPanel Orientation="Horizontal" Spacing="10">
    <Button Content="New"/>
    <Button Content="Open"/>
    <Button Content="Save"/>
    <Spacer/>
    <Button Content="Help"/>
</FloatPanel>
```

### Form Layout

```xml
<FloatPanel Orientation="Vertical" Spacing="8">
    <TextBlock Text="Username:"/>
    <TextBox Watermark="Enter username"/>
    <Spacer/>
    <TextBlock Text="Email:"/>
    <TextBox Watermark="Enter email"/>
    <Spacer/>
    <StackPanel Orientation="Horizontal" Spacing="8">
        <Button Content="Cancel"/>
        <Button Content="Submit"/>
    </StackPanel>
</FloatPanel>
```

### Card Grid with Wrap

```xml
<FloatPanel Orientation="Horizontal" Wrap="True" Spacing="10">
    <Border Background="#f0f0f0" Padding="10" Margin="5">
        <TextBlock Text="Card 1"/>
    </Border>
    <Border Background="#f0f0f0" Padding="10" Margin="5">
        <TextBlock Text="Card 2"/>
    </Border>
    <Border Background="#f0f0f0" Padding="10" Margin="5">
        <TextBlock Text="Card 3"/>
    </Border>
</FloatPanel>
```

## API Reference

### FloatPanel Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Orientation` | `Orientation` | `Horizontal` | Layout direction |
| `Spacing` | `double` | `8` | Space between children in pixels |
| `Justify` | `JustifyContent` | `Start` | Main axis alignment |
| `Align` | `AlignItems` | `Stretch` | Cross axis alignment |
| `Wrap` | `bool` | `false` | Enable wrapping |

### JustifyContent Enum

| Value | Description |
|-------|-------------|
| `Start` | Children placed at the start |
| `Center` | Children centered in available space |
| `End` | Children placed at the end |
| `SpaceBetween` | Equal space between consecutive children |
| `SpaceAround` | Equal space around each child |
| `SpaceEvenly` | Uniform spacing between all points |

### AlignItems Enum

| Value | Description |
|-------|-------------|
| `Start` | Children aligned to the start of cross axis |
| `Center` | Children centered on cross axis |
| `End` | Children aligned to the end of cross axis |
| `Stretch` | Children stretched to fill cross axis |

### Spacer Properties

Spacer has no configurable properties. It simply consumes all available space.