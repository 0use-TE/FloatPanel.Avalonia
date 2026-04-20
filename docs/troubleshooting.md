# Troubleshooting

Common issues and solutions when using FloatPanel.Avalonia.

## Installation Issues

### Package restore fails

Make sure you have the correct package name:

```bash
dotnet add package FloatPanel
```

### Version compatibility

FloatPanel requires:
- .NET 8.0 or later
- Avalonia 11.0.0 or later

## Layout Issues

### Elements are not spaced correctly

- Ensure you are using `Spacing` property (not Margin) for consistent gaps
- `Spacing` only affects gaps between non-Spacer children
- Spacer elements consume space but don't add spacing themselves

### Spacer does not push elements to edges

- Spacer only works along the main axis (horizontal in Horizontal orientation, vertical in Vertical)
- Make sure Spacer is placed between the elements you want to push apart
- Multiple Spacers will share the remaining space equally

### Wrap is not working

- Make sure `Wrap="True"` is set (not `Wrap="true"` or other variations)
- For horizontal wrap, ensure the parent has a constrained width
- For vertical wrap, ensure the parent has a constrained height

### Elements are clipped or overflowing

- Set explicit Width/Height on FloatPanel when needed
- Use `HorizontalScrollBarVisibility="Auto"` or `VerticalScrollBarVisibility="Auto"` inside a ScrollViewer
- Check if parent containers are constraining the size

## Alignment Issues

### Cross-axis alignment not working

- `Align` property controls cross-axis (perpendicular to Orientation)
- In Horizontal mode, Align affects vertical positioning
- In Vertical mode, Align affects horizontal positioning
- `Align="Stretch"` is the default and may appear to do nothing if children have explicit size

### Justify does not distribute space evenly

- `Justify` only applies when there are no Spacer elements
- If you have Spacers, they will consume available space instead
- Use `Justify="SpaceBetween"` for equal gaps between elements without Spacers

## Platform-Specific Issues

### WebAssembly (WASM) performance

If layout feels slow on WASM:
- Minimize the number of nested FloatPanels
- Avoid very complex wrap scenarios with many children
- Consider using compiled bindings (`x:DataType`)

### Mobile platforms (iOS/Android)

- Test layouts with different screen orientations
- Wrap behavior may need adjustment for portrait vs landscape
- Consider using Grid for complex two-dimensional layouts

## Debugging Tips

### Inspect visual tree

Use Avalonia DevTools to inspect the visual tree and see actual sizes being used.

### Add borders for debugging

Temporarily add borders to see where elements are placed:

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Test" BorderBrush="Red" BorderThickness="1"/>
    <Spacer/>
    <Button Content="Test2" BorderBrush="Blue" BorderThickness="1"/>
</FloatPanel>
```

## Common Questions

### Q: Can I use FloatPanel inside FloatPanel?

Yes, nested FloatPanels work correctly. Example:

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Menu"/>
    <Spacer/>
    <FloatPanel Orientation="Horizontal" Spacing="10">
        <Button Content="Settings"/>
        <Button Content="Help"/>
    </FloatPanel>
</FloatPanel>
```

### Q: How do I create a centered layout?

Use `Justify="Center"` without any Spacers:

```xml
<FloatPanel Orientation="Horizontal" Justify="Center">
    <Button Content="Centered"/>
</FloatPanel>
```

### Q: How do I create space-between with items on edges?

Use Spacers on both sides:

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Left"/>
    <Spacer/>
    <Button Content="Right"/>
</FloatPanel>
```

### Q: Can Spacer have a specific size?

No, Spacer is always zero-sized and consumes all remaining space. For fixed-size gaps, use Margin on child elements or set Spacing on the parent.

### Q: How does Wrap interact with Spacer?

Spacers within wrapped rows/columns only consume space within their own line. Each line is arranged independently.
