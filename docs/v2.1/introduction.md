# Introduction

FloatPanel is a layout component library for [Avalonia UI](https://avaloniaui.net/) with an API modeled after [MudBlazor MudStack](https://mudblazor.com/components/stack). Install via [NuGet](https://www.nuget.org/packages/FloatPanel).

## Why FloatPanel?

Building toolbars, forms, and responsive layouts in Avalonia often means nesting `StackPanel`, `Grid`, and manual margins. FloatPanel gives you flex-style layout with familiar MudStack properties:

| MudStack | FloatPanel |
|----------|------------|
| `Row` | `Row` |
| `Spacing` (×4 px) | `Spacing` (×4 px) |
| `Justify` | `Justify` |
| `AlignItems` | `AlignItems` |
| `Wrap` | `Wrap` |
| `Reverse` | `Reverse` |
| `StretchItems` | `StretchItems` |
| `Breakpoint` | `Breakpoint` |
| `MudSpacer` | `Spacer` |

## Default behaviour

Like MudStack, **FloatPanel stacks vertically by default** (`Row="False"`). Set `Row="True"` for a horizontal row.

```xml
<FloatPanel Spacing="3">
    <TextBlock Text="Item 1"/>
    <TextBlock Text="Item 2"/>
    <TextBlock Text="Item 3"/>
</FloatPanel>
```

## Supported platforms

| Platform | Status |
|----------|--------|
| Windows / macOS / Linux | Supported |
| WebAssembly | Supported |
| iOS / Android | Supported |

## Live demo

Try the interactive demo at [0use.net/FloatPanel.Avalonia/demo/](https://0use.net/FloatPanel.Avalonia/demo/).
