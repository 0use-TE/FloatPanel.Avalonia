# FloatPanel

Flex-style layout for Avalonia UI — MudStack-inspired `FloatPanel` and `Spacer`.

## Try it in your browser

**[Open Live Demo →](https://0use.net/FloatPanel.Avalonia/demo/)**

Interactive playground: tweak `Row`, `Spacing`, `Justify`, and more — preview updates instantly with matching XAML on the side. No install required.

![FloatPanel Demo](docs/images/floatpanel-demo.png)

**Documentation:** [0use.net/FloatPanel.Avalonia](https://0use.net/FloatPanel.Avalonia/)

## Install

```bash
dotnet add package FloatPanel --version 2.1.0
```

Requires .NET 10+ and Avalonia 12+.

## Quick start

```xml
<!-- Vertical stack (default, like MudStack) -->
<FloatPanel Spacing="3">
    <TextBlock Text="Item 1"/>
    <TextBlock Text="Item 2"/>
</FloatPanel>

<!-- Toolbar with Spacer -->
<FloatPanel Row="True" Spacing="2">
    <Button Content="Settings"/>
    <Spacer/>
    <Button Content="Apply"/>
</FloatPanel>
```

## MudStack API parity

| Property | Description |
|----------|-------------|
| `Row` | Horizontal layout when `true` |
| `Spacing` | Gap in 4 px steps (default `3`) |
| `Justify` | Main-axis distribution |
| `AlignItems` | Cross-axis alignment |
| `Wrap` | `NoWrap`, `Wrap`, `WrapReverse` |
| `Reverse` | Reverse item order |
| `StretchItems` | Stretch children on main axis |
| `Breakpoint` | Responsive row/column switch |
| `Spacer` | Consumes remaining main-axis space |

## Supported platforms

| Platform | Status |
|----------|--------|
| Windows / macOS / Linux | Supported |
| WebAssembly | Supported |
| iOS / Android | Supported |

## Upgrade from v2.0

See [upgrade guide](docs/v2.1/upgrade-from-2.0.md). Key changes: `Orientation` → `Row`, pixel `Spacing` → 4 px increments, `Align` → `AlignItems`.

## License

MIT
