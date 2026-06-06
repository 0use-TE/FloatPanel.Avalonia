namespace FloatPanel.Controls;

/// <summary>
/// Indicates how items in a <see cref="FloatPanel"/> are wrapped.
/// </summary>
public enum Wrap
{
    /// <summary>No wrapping occurs; items may overflow the container.</summary>
    NoWrap,

    /// <summary>Items wrap to fit the container.</summary>
    Wrap,

    /// <summary>Items wrap with reversed cross-axis direction.</summary>
    WrapReverse
}
