# Responsive Breakpoints

Use `Breakpoint` to switch between row and column layout based on panel width — similar to MudStack's responsive flex direction.

## Example: stack on mobile, row on desktop

```xml
<FloatPanel Row="True" Breakpoint="Md" Spacing="2">
    <Button Content="Home"/>
    <Button Content="About"/>
    <Button Content="Contact"/>
</FloatPanel>
```

Below 960 px width the panel becomes a column; at 960 px and above it stays a row.

## Common breakpoints

| Value | Behaviour (with `Row="True"`) |
|-------|-------------------------------|
| `None` | Always use `Row` |
| `Md` | Column below 960 px, row at 960 px+ |
| `SmAndDown` | Column below 600 px |
| `LgAndUp` | Column from 1280 px+ |

See the <xref:FloatPanel.Controls.Breakpoint> enum in the API reference.

## Tips

- Breakpoints use the **FloatPanel control width**, not the window width. Put the panel in a full-width container for viewport-like behaviour.
- Changing width triggers `InvalidateMeasure` so layout updates live when resizing.

## Further reading

> **How it works:** [Architecture — Breakpoints](../architecture.md#breakpoints)
