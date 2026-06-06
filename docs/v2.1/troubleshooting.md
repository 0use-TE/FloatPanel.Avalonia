# Troubleshooting

## Spacer does not push items apart

- Spacer only works on the **main axis** (horizontal when `Row="True"`, vertical when column).
- Ensure the parent has a defined size on the main axis so there is free space to absorb.

## Wrap not working

- Set `Wrap="Wrap"` (not a boolean).
- Constrain the main axis: width for `Row="True"`, height for column layout.

## Breakpoint not switching

- Breakpoints key off `FloatPanel.Bounds.Width`. Narrow the panel itself, not only the window chrome.
- Use `Breakpoint="None"` to debug with a fixed `Row` value first.

## Spacing looks wrong after upgrade

v2.1 uses **4 px increments**. Old `Spacing="8"` → new `Spacing="2"`.

## Cross-axis alignment

- `AlignItems="Stretch"` fills the cross axis (default).
- Use `FlexStart`, `Center`, or `FlexEnd` when children have natural sizes.

## Nested FloatPanels

Supported. Prefer `Spacing` on each panel instead of child margins for predictable gaps.
