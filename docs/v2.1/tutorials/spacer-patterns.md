# Spacer Patterns

`Spacer` pushes content to opposite edges — the Avalonia equivalent of `MudSpacer`.

## Toolbar

```xml
<FloatPanel Row="True" Spacing="2">
    <Button Content="Menu"/>
    <Spacer/>
    <Button Content="Help"/>
    <Button Content="Profile"/>
</FloatPanel>
```

## Footer actions

```xml
<FloatPanel Row="True" Spacing="2">
    <Button Content="Cancel"/>
    <Spacer/>
    <Button Content="Save" Classes="accent"/>
</FloatPanel>
```

## Vertical fill

```xml
<FloatPanel Spacing="2" MinHeight="200">
    <TextBlock Text="Header"/>
    <Spacer/>
    <TextBlock Text="Footer"/>
</FloatPanel>
```

## Multiple spacers

Two spacers share remaining space equally:

```xml
<FloatPanel Row="True">
    <Button Content="A"/>
    <Spacer/>
    <Button Content="B"/>
    <Spacer/>
    <Button Content="C"/>
</FloatPanel>
```

## Justify vs Spacer

`Justify` distributes free space between items. `Spacer` consumes free space explicitly. If any `Spacer` is present, `Justify` spacing modes are ignored for gap expansion — the spacer takes the slack.

## Further reading

> **How it works:** [Architecture — Spacer](../architecture.md#spacer)
