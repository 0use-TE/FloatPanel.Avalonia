# Getting Started (v2.0 Legacy)

> Migrate to [v2.1](../v2.1/getting-started.md) for the MudStack-style API.

## Installation (v2.0.x)

```bash
dotnet add package FloatPanel --version 2.0.1
```

## Horizontal layout

```xml
<FloatPanel Orientation="Horizontal">
    <Button Content="Back"/>
    <Spacer/>
    <Button Content="Next"/>
</FloatPanel>
```

## Properties

| Property | Type | Default |
|----------|------|---------|
| `Orientation` | `Orientation` | `Horizontal` |
| `Spacing` | `double` | `8` |
| `Justify` | `JustifyContent` | `Start` |
| `Align` | `AlignItems` | `Stretch` |
| `Wrap` | `bool` | `false` |
