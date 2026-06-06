# Getting Started

## Installation

```bash
dotnet add package FloatPanel
```

Requirements:

- .NET 10+
- Avalonia 12.0+

No extra DI or theme setup — controls are in the default Avalonia XML namespace via `AssemblyInfo`.

## Column layout (default)

```xml
<FloatPanel Spacing="3">
    <TextBlock Text="Title"/>
    <TextBlock Text="Body"/>
    <Button Content="Action"/>
</FloatPanel>
```

## Row layout

```xml
<FloatPanel Row="True" Spacing="3">
    <Button Content="One"/>
    <Button Content="Two"/>
    <Button Content="Three"/>
</FloatPanel>
```

## Toolbar with Spacer

```xml
<FloatPanel Row="True" Spacing="2">
    <Button Content="Settings"/>
    <Spacer/>
    <Button Content="Apply"/>
</FloatPanel>
```

## Main properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `Row` | `bool` | `false` | Horizontal layout when true |
| `Reverse` | `bool` | `false` | Reverse item order |
| `Spacing` | `int` | `3` | Gap in 4 px steps |
| `Justify` | `Justify?` | `FlexStart` | Main-axis distribution |
| `AlignItems` | `AlignItems?` | `Stretch` | Cross-axis alignment |
| `Wrap` | `Wrap?` | `NoWrap` | Line wrapping |
| `StretchItems` | `StretchItems?` | `None` | Main-axis stretch |
| `Breakpoint` | `Breakpoint` | `None` | Responsive direction |

See the <xref:FloatPanel.Controls.FloatPanel> API for full details.

## Further reading

- [Basic layout tutorial](tutorials/basic-layout.md)
- [Architecture](architecture.md)
