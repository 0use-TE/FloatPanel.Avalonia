# Upgrade from v2.0

v2.1 realigns the API with MudStack. Most v2.0 apps need small XAML updates.

## Property mapping

| v2.0 | v2.1 |
|------|------|
| `Orientation="Horizontal"` | `Row="True"` |
| `Orientation="Vertical"` | `Row="False"` (default) |
| `Align` | `AlignItems` |
| `Justify="Start"` | `Justify="FlexStart"` |
| `Justify="End"` | `Justify="FlexEnd"` |
| `Wrap="True"` | `Wrap="Wrap"` |
| `Spacing="8"` (pixels) | `Spacing="2"` (2 × 4 px = 8 px) |

## New in v2.1

- `Reverse` — flip item order along the main axis
- `StretchItems` — grow specific children on the main axis
- `Breakpoint` — responsive row/column switching by viewport width
- `Wrap="WrapReverse"` — wrap with reversed cross direction

## Example migration

**v2.0**

```xml
<FloatPanel Orientation="Horizontal" Spacing="8" Justify="Start" Align="Center">
    <Button Content="Back"/>
    <Spacer/>
    <Button Content="Next"/>
</FloatPanel>
```

**v2.1**

```xml
<FloatPanel Row="True" Spacing="2" Justify="FlexStart" AlignItems="Center">
    <Button Content="Back"/>
    <Spacer/>
    <Button Content="Next"/>
</FloatPanel>
```

## Package update

```bash
dotnet add package FloatPanel --version 2.1.0
```

Requires Avalonia 12.0+ and .NET 10+.
