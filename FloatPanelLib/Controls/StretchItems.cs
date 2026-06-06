namespace FloatPanel.Controls;

/// <summary>
/// Specifies how items in a <see cref="FloatPanel"/> are stretched along the main axis.
/// </summary>
public enum StretchItems
{
    /// <summary>No stretching is applied.</summary>
    None,

    /// <summary>The first item is stretched.</summary>
    Start,

    /// <summary>The last item is stretched.</summary>
    End,

    /// <summary>The first and last items are stretched.</summary>
    StartAndEnd,

    /// <summary>All items except the first and last are stretched.</summary>
    Middle,

    /// <summary>All items are stretched evenly.</summary>
    All
}
