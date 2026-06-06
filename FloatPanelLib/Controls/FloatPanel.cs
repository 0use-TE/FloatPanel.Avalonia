using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;

namespace FloatPanel.Controls;

/// <summary>
/// Arranges child items along the vertical or horizontal axis with optional spacing,
/// alignment, wrapping, and responsive breakpoints. API mirrors MudBlazor's MudStack.
/// </summary>
public class FloatPanel : Panel
{
    public static readonly StyledProperty<bool> RowProperty =
        AvaloniaProperty.Register<FloatPanel, bool>(nameof(Row));

    public static readonly StyledProperty<bool> ReverseProperty =
        AvaloniaProperty.Register<FloatPanel, bool>(nameof(Reverse));

    public static readonly StyledProperty<int> SpacingProperty =
        AvaloniaProperty.Register<FloatPanel, int>(nameof(Spacing), 3);

    public static readonly StyledProperty<Justify?> JustifyProperty =
        AvaloniaProperty.Register<FloatPanel, Justify?>(nameof(Justify));

    public static readonly StyledProperty<AlignItems?> AlignItemsProperty =
        AvaloniaProperty.Register<FloatPanel, AlignItems?>(nameof(AlignItems));

    public static readonly StyledProperty<StretchItems?> StretchItemsProperty =
        AvaloniaProperty.Register<FloatPanel, StretchItems?>(nameof(StretchItems));

    public static readonly StyledProperty<Wrap?> WrapProperty =
        AvaloniaProperty.Register<FloatPanel, Wrap?>(nameof(Wrap));

    public static readonly StyledProperty<Breakpoint> BreakpointProperty =
        AvaloniaProperty.Register<FloatPanel, Breakpoint>(nameof(Breakpoint), Breakpoint.None);

    private bool _effectiveRow;
    private double _lastViewportWidth = double.NaN;

    static FloatPanel()
    {
        AffectsMeasure<FloatPanel>(
            RowProperty,
            ReverseProperty,
            SpacingProperty,
            JustifyProperty,
            AlignItemsProperty,
            StretchItemsProperty,
            WrapProperty,
            BreakpointProperty);

        AffectsArrange<FloatPanel>(
            RowProperty,
            ReverseProperty,
            SpacingProperty,
            JustifyProperty,
            AlignItemsProperty,
            StretchItemsProperty,
            WrapProperty,
            BreakpointProperty);
    }

    /// <summary>
    /// When <c>true</c>, items flow horizontally. Default is vertical (column), like MudStack.
    /// </summary>
    public bool Row
    {
        get => GetValue(RowProperty);
        set => SetValue(RowProperty, value);
    }

    /// <summary>
    /// Reverses the visual order of items along the main axis.
    /// </summary>
    public bool Reverse
    {
        get => GetValue(ReverseProperty);
        set => SetValue(ReverseProperty, value);
    }

    /// <summary>
    /// Gap between items in 4 px increments. Default is 3 (12 px), matching MudStack.
    /// </summary>
    public int Spacing
    {
        get => GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    /// <summary>
    /// Distribution of items along the main axis.
    /// </summary>
    public Justify? Justify
    {
        get => GetValue(JustifyProperty);
        set => SetValue(JustifyProperty, value);
    }

    /// <summary>
    /// Alignment of items along the cross axis.
    /// </summary>
    public AlignItems? AlignItems
    {
        get => GetValue(AlignItemsProperty);
        set => SetValue(AlignItemsProperty, value);
    }

    /// <summary>
    /// Stretching behaviour of children along the main axis.
    /// </summary>
    public StretchItems? StretchItems
    {
        get => GetValue(StretchItemsProperty);
        set => SetValue(StretchItemsProperty, value);
    }

    /// <summary>
    /// Wrapping behaviour when content exceeds the available space.
    /// </summary>
    public Wrap? Wrap
    {
        get => GetValue(WrapProperty);
        set => SetValue(WrapProperty, value);
    }

    /// <summary>
    /// Viewport breakpoint that toggles between row and column layout.
    /// </summary>
    public Breakpoint Breakpoint
    {
        get => GetValue(BreakpointProperty);
        set => SetValue(BreakpointProperty, value);
    }

    private double Gap => Math.Max(0, Spacing) * 4d;

    private Justify EffectiveJustify => Justify ?? Controls.Justify.FlexStart;

    private AlignItems EffectiveAlignItems => AlignItems ?? Controls.AlignItems.Stretch;

    private Wrap EffectiveWrap => Wrap ?? Controls.Wrap.NoWrap;

    private StretchItems EffectiveStretchItems => StretchItems ?? Controls.StretchItems.None;

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == BoundsProperty)
            UpdateEffectiveRow(forceInvalidate: true);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        UpdateEffectiveRow(forceInvalidate: false);

        if (EffectiveWrap != Controls.Wrap.NoWrap)
            return MeasureWrapped(availableSize);

        var items = FloatPanelLayout.CreateChildren(Children, Reverse, _effectiveRow, availableSize);
        var gap = Gap;
        var gapCount = CountGaps(items);
        var main = SumMain(items) + gapCount * gap;
        var cross = MaxCross(items);

        return _effectiveRow ? new Size(main, cross) : new Size(cross, main);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        UpdateEffectiveRow(forceInvalidate: false);

        if (EffectiveWrap != Controls.Wrap.NoWrap)
            return ArrangeWrapped(finalSize);

        var items = new List<LayoutChild>(FloatPanelLayout.CreateChildren(Children, Reverse, _effectiveRow, finalSize));
        ArrangeLine(items, finalSize);
        return finalSize;
    }

    private Size MeasureWrapped(Size availableSize)
    {
        var items = FloatPanelLayout.CreateChildren(Children, Reverse, _effectiveRow, availableSize);
        var availableMain = _effectiveRow ? availableSize.Width : availableSize.Height;
        if (double.IsInfinity(availableMain))
            availableMain = SumMain(items) + CountGaps(items) * Gap;

        var lines = FloatPanelLayout.BuildLines(items, _effectiveRow, Gap, availableMain, EffectiveWrap);
        var gap = Gap;
        var totalCross = 0d;
        var maxMain = 0d;

        foreach (var line in lines)
        {
            var lineMain = SumMain(line) + CountGaps(line) * gap;
            var lineCross = MaxCross(line);
            totalCross += lineCross;
            maxMain = Math.Max(maxMain, lineMain);
        }

        if (lines.Count > 1)
            totalCross += (lines.Count - 1) * gap;

        return _effectiveRow ? new Size(maxMain, totalCross) : new Size(totalCross, maxMain);
    }

    private Size ArrangeWrapped(Size finalSize)
    {
        var items = FloatPanelLayout.CreateChildren(Children, Reverse, _effectiveRow, finalSize);
        var availableMain = _effectiveRow ? finalSize.Width : finalSize.Height;
        var lines = FloatPanelLayout.BuildLines(items, _effectiveRow, Gap, availableMain, EffectiveWrap);
        var gap = Gap;
        var crossCursor = 0d;

        foreach (var line in lines)
        {
            var lineCross = MaxCross(line);
            var lineSize = _effectiveRow
                ? new Size(finalSize.Width, lineCross)
                : new Size(lineCross, finalSize.Height);

            ArrangeLine(line, lineSize, crossCursor);

            crossCursor += lineCross + gap;
        }

        return finalSize;
    }

    private void ArrangeLine(IList<LayoutChild> items, Size lineSize, double crossOrigin = 0)
    {
        var gap = Gap;
        var availableMain = _effectiveRow ? lineSize.Width : lineSize.Height;
        var availableCross = _effectiveRow ? lineSize.Height : lineSize.Width;
        var contentMain = SumMain(items);
        var gapCount = Math.Max(0, items.Count - 1);
        var hasSpacer = HasSpacer(items);

        FloatPanelLayout.DistributeSpacers(items, availableMain - contentMain - gapCount * gap);

        contentMain = SumMain(items);
        var extraMain = availableMain - contentMain - gapCount * gap;
        FloatPanelLayout.ApplyStretchItems(items, EffectiveStretchItems, extraMain);

        contentMain = SumMain(items);
        gap = FloatPanelLayout.ResolveGap(EffectiveJustify, gap, availableMain, contentMain + gapCount * gap, gapCount, hasSpacer);
        var mainOffset = FloatPanelLayout.ComputeMainOffset(
            EffectiveJustify,
            availableMain,
            contentMain + gapCount * gap,
            gapCount,
            hasSpacer);

        if (EffectiveJustify == Controls.Justify.SpaceAround && !hasSpacer && gapCount > 0)
            mainOffset = gap / 2;

        var cursor = mainOffset;

        for (var i = 0; i < items.Count; i++)
        {
            var item = items[i];
            var crossSize = FloatPanelLayout.ResolveCrossSize(EffectiveAlignItems, availableCross, item.CrossSize);
            var crossOffset = FloatPanelLayout.ComputeCrossOffset(EffectiveAlignItems, availableCross, item.CrossSize);

            if (_effectiveRow)
            {
                item.Control.Arrange(new Rect(cursor, crossOrigin + crossOffset, item.MainSize, crossSize));
            }
            else
            {
                item.Control.Arrange(new Rect(crossOrigin + crossOffset, cursor, crossSize, item.MainSize));
            }

            cursor += item.MainSize;

            if (i < items.Count - 1)
                cursor += gap;
        }
    }

    private void UpdateEffectiveRow(bool forceInvalidate)
    {
        var viewportWidth = double.IsNaN(Bounds.Width) ? 0 : Bounds.Width;
        var effectiveRow = BreakpointHelper.ResolveEffectiveRow(Row, Breakpoint, viewportWidth);

        if (Math.Abs(viewportWidth - _lastViewportWidth) > 0.5 || effectiveRow != _effectiveRow)
        {
            _lastViewportWidth = viewportWidth;
            _effectiveRow = effectiveRow;

            if (forceInvalidate)
                InvalidateMeasure();
        }
    }

    private static bool HasSpacer(IEnumerable<LayoutChild> items)
    {
        foreach (var item in items)
        {
            if (item.IsSpacer)
                return true;
        }

        return false;
    }

    private static int CountGaps(IReadOnlyCollection<LayoutChild> items)
        => Math.Max(0, items.Count - 1);

    private static double SumMain(IEnumerable<LayoutChild> items)
    {
        var total = 0d;
        foreach (var item in items)
            total += item.MainSize;
        return total;
    }

    private static double MaxCross(IEnumerable<LayoutChild> items)
    {
        var max = 0d;
        foreach (var item in items)
            max = Math.Max(max, item.CrossSize);
        return max;
    }
}
