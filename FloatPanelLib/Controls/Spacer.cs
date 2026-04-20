using Avalonia;
using Avalonia.Controls;

namespace FloatPanel.Controls;

public class Spacer : Control
{
    protected override Size MeasureOverride(Size availableSize)
    {
        return new Size(0, 0);
    }
}
