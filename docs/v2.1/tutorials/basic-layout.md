# Basic Layout

## Direction

Vertical (default):

```xml
<FloatPanel>
    <Border Padding="8"><TextBlock Text="A"/></Border>
    <Border Padding="8"><TextBlock Text="B"/></Border>
</FloatPanel>
```

Horizontal:

```xml
<FloatPanel Row="True">
    <Border Padding="8"><TextBlock Text="A"/></Border>
    <Border Padding="8"><TextBlock Text="B"/></Border>
</FloatPanel>
```

## Spacing

Use `Spacing` instead of per-child margins for consistent gaps:

```xml
<FloatPanel Row="True" Spacing="4">
    <!-- 16 px between items -->
</FloatPanel>
```

## Justify

Center items without spacers:

```xml
<FloatPanel Row="True" Justify="Center">
    <Button Content="OK"/>
</FloatPanel>
```

Space between:

```xml
<FloatPanel Row="True" Justify="SpaceBetween">
    <Button Content="Left"/>
    <Button Content="Right"/>
</FloatPanel>
```

## AlignItems

```xml
<FloatPanel Row="True" AlignItems="Center" MinHeight="80">
    <Button Content="Short"/>
    <Button Content="Tall" Height="48"/>
</FloatPanel>
```

## Reverse

```xml
<FloatPanel Row="True" Reverse="True" Spacing="2">
    <TextBlock Text="First in XAML → rightmost on screen"/>
    <TextBlock Text="Second"/>
</FloatPanel>
```

## Further reading

> **How it works:** [Architecture — Layout pipeline](../architecture.md#layout-pipeline)
