# Introduction (v2.0 Legacy)

> **Current version:** [v2.1](../v2.1/introduction.md) — MudStack-aligned API with `Row`, responsive breakpoints, and more.

FloatPanel v2.0 used `Orientation`, `Align`, and pixel-based `Spacing`. See [Upgrade from v2.0](../v2.1/upgrade-from-2.0.md) to migrate.

## v2.0 API summary

- `Orientation` — `Horizontal` (default) or `Vertical`
- `Spacing` — gap in pixels (default 8)
- `Justify` — `JustifyContent` enum (`Start`, `Center`, `End`, …)
- `Align` — `AlignItems` enum
- `Wrap` — boolean

## Quick example (v2.0)

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Settings"/>
    <Spacer/>
    <Button Content="Apply"/>
</FloatPanel>
```
