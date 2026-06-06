namespace FloatPanel.Controls;

/// <summary>
/// The viewport width at which a <see cref="FloatPanel"/> switches between row and column layout.
/// </summary>
public enum Breakpoint
{
    /// <summary>Breakpoint is disabled; <see cref="FloatPanel.Row"/> is always used.</summary>
    None,

    /// <summary>Layout direction is always inverted from <see cref="FloatPanel.Row"/>.</summary>
    Always,

    Xs,
    Sm,
    Md,
    Lg,
    Xl,
    Xxl,

    SmAndDown,
    MdAndDown,
    LgAndDown,
    XlAndDown,

    SmAndUp,
    MdAndUp,
    LgAndUp,
    XlAndUp
}
