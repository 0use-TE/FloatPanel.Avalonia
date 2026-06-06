using Avalonia;
using Avalonia.Controls;

namespace FloatPanel.Controls;

/// <summary>
/// A lightweight component that consumes remaining space along the main axis of a <see cref="FloatPanel"/>.
/// Similar to MudBlazor's MudSpacer.
/// </summary>
public class Spacer : Control
{
    protected override Size MeasureOverride(Size availableSize) => new(0, 0);
}
