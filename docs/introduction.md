# Introduction

FloatPanel.Avalonia is a layout component library for [Avalonia UI](https://avaloniaui.net/), providing flexible panel-based layout capabilities similar to MudBlazor's MudStack and MudSpacer. Available as a [NuGet package](https://www.nuget.org/packages/FloatPanel).

## Why FloatPanel?

When building Avalonia 11 applications, you often need to create layouts with elements spaced apart, with optional wrapping behavior. Traditional approaches using nested Panels or Grid can become complex and hard to maintain.

FloatPanel simplifies this by providing:

- **Simple semantics** - Just specify orientation and spacing
- **Spacer-driven layout** - Use Spacer components to push elements to edges
- **Flexible alignment** - Control both main-axis and cross-axis alignment
- **Wrap support** - Automatically wrap children when they exceed available space

## Core Concepts

### FloatPanel

The main container component that arranges its children based on:

- **Orientation** - Horizontal or vertical flow direction
- **Spacing** - Fixed gap between consecutive children
- **Justify** - How children are distributed along the main axis
- **Align** - How children are positioned along the cross axis
- **Wrap** - Whether children wrap to additional lines/columns when space is limited

### Spacer

A zero-sized component that consumes all remaining space in the main axis direction. Multiple Spacers distribute available space equally among themselves.

## Demo

![FloatPanel Demo](images/floatpanel-demo.png)

[Watch Video Demo](images/floatpanel-demo.mp4)

## Quick Example

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Settings"/>
    <Spacer/>
    <Button Content="Apply"/>
</FloatPanel>
```

This creates a horizontal layout where "Settings" is on the left, and "Apply" is pushed to the right edge.

## Supported Platforms

| Platform | Status |
|----------|--------|
| Windows | Supported |
| macOS | Supported |
| Linux | Supported |
| WebAssembly (WASM) | Supported |
| iOS | Supported |
| Android | Supported |