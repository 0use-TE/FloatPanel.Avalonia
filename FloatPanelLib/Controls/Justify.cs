namespace FloatPanel.Controls;

/// <summary>
/// The distribution of child items along the main axis in a <see cref="FloatPanel"/>.
/// </summary>
public enum Justify
{
    /// <summary>Items are aligned to the start of the main axis.</summary>
    FlexStart,

    /// <summary>Items are centered on the main axis.</summary>
    Center,

    /// <summary>Items are aligned to the end of the main axis.</summary>
    FlexEnd,

    /// <summary>Space is applied between items; first and last items touch the edges.</summary>
    SpaceBetween,

    /// <summary>Space is applied around each item, including half-space at the edges.</summary>
    SpaceAround,

    /// <summary>Space is applied evenly between all items and edges.</summary>
    SpaceEvenly
}
