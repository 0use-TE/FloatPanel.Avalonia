using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;

namespace FloatPanel.Controls;

internal static class BreakpointHelper
{
    private const double Sm = 600;
    private const double Md = 960;
    private const double Lg = 1280;
    private const double Xl = 1920;
    private const double Xxl = 2560;

    public static bool ResolveEffectiveRow(bool row, Breakpoint breakpoint, double viewportWidth)
    {
        var defaultRow = row;
        var reverseRow = !row;

        return breakpoint switch
        {
            Breakpoint.None => defaultRow,
            Breakpoint.Always => reverseRow,
            Breakpoint.Xs => viewportWidth < Sm ? reverseRow : defaultRow,
            Breakpoint.Sm => viewportWidth < Md ? defaultRow : reverseRow,
            Breakpoint.Md => viewportWidth < Lg ? defaultRow : reverseRow,
            Breakpoint.Lg => viewportWidth < Xl ? defaultRow : reverseRow,
            Breakpoint.Xl => viewportWidth < Xxl ? defaultRow : reverseRow,
            Breakpoint.Xxl => reverseRow,
            Breakpoint.SmAndDown => viewportWidth < Md ? reverseRow : defaultRow,
            Breakpoint.MdAndDown => viewportWidth < Lg ? reverseRow : defaultRow,
            Breakpoint.LgAndDown => viewportWidth < Xl ? reverseRow : defaultRow,
            Breakpoint.XlAndDown => viewportWidth < Xxl ? reverseRow : defaultRow,
            Breakpoint.SmAndUp => viewportWidth >= Sm ? reverseRow : defaultRow,
            Breakpoint.MdAndUp => viewportWidth >= Md ? reverseRow : defaultRow,
            Breakpoint.LgAndUp => viewportWidth >= Lg ? reverseRow : defaultRow,
            Breakpoint.XlAndUp => viewportWidth >= Xl ? reverseRow : defaultRow,
            _ => defaultRow
        };
    }
}

internal readonly struct LayoutChild
{
    public LayoutChild(Control control, int index, bool isSpacer, double mainSize, double crossSize)
    {
        Control = control;
        Index = index;
        IsSpacer = isSpacer;
        MainSize = mainSize;
        CrossSize = crossSize;
    }

    public Control Control { get; }
    public int Index { get; }
    public bool IsSpacer { get; }
    public double MainSize { get; init; }
    public double CrossSize { get; init; }
}

internal static class FloatPanelLayout
{
    public static IReadOnlyList<LayoutChild> CreateChildren(
        IReadOnlyList<Control> children,
        bool reverse,
        bool isRow,
        Size availableSize)
    {
        var list = new List<LayoutChild>(children.Count);

        for (var i = 0; i < children.Count; i++)
        {
            var child = children[i];
            child.Measure(availableSize);

            var main = isRow ? child.DesiredSize.Width : child.DesiredSize.Height;
            var cross = isRow ? child.DesiredSize.Height : child.DesiredSize.Width;
            list.Add(new LayoutChild(child, i, child is Spacer, main, cross));
        }

        if (reverse)
            list.Reverse();

        return list;
    }

    public static void ApplyStretchItems(
        IList<LayoutChild> items,
        StretchItems stretch,
        double extraMainSpace)
    {
        if (extraMainSpace <= 0 || stretch == StretchItems.None)
            return;

        var stretchable = new List<int>();
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].IsSpacer)
                continue;

            var include = stretch switch
            {
                StretchItems.Start => i == 0,
                StretchItems.End => i == items.Count - 1,
                StretchItems.StartAndEnd => i == 0 || i == items.Count - 1,
                StretchItems.Middle => i > 0 && i < items.Count - 1,
                StretchItems.All => true,
                _ => false
            };

            if (include)
                stretchable.Add(i);
        }

        if (stretchable.Count == 0)
            return;

        var perItem = extraMainSpace / stretchable.Count;
        foreach (var index in stretchable)
        {
            var item = items[index];
            items[index] = item with { MainSize = item.MainSize + perItem };
        }
    }

    public static void DistributeSpacers(IList<LayoutChild> items, double remainingMain)
    {
        if (remainingMain <= 0)
            return;

        var spacerIndices = new List<int>();
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].IsSpacer)
                spacerIndices.Add(i);
        }

        if (spacerIndices.Count == 0)
            return;

        var perSpacer = remainingMain / spacerIndices.Count;
        foreach (var index in spacerIndices)
            items[index] = items[index] with { MainSize = perSpacer };
    }

    public static double ComputeMainOffset(
        Justify justify,
        double availableMain,
        double contentMain,
        int gapCount,
        bool hasSpacer)
    {
        if (hasSpacer)
            return 0;

        var free = availableMain - contentMain;
        if (free <= 0)
            return 0;

        return justify switch
        {
            Justify.Center => free / 2,
            Justify.FlexEnd => free,
            Justify.SpaceEvenly => free / (gapCount + 1),
            _ => 0
        };
    }

    public static double ResolveGap(Justify justify, double gap, double availableMain, double contentMain, int gapCount, bool hasSpacer)
    {
        if (hasSpacer || gapCount == 0)
            return gap;

        var free = availableMain - contentMain;
        if (free <= 0)
            return gap;

        return justify switch
        {
            Justify.SpaceBetween => free / gapCount,
            Justify.SpaceAround => free / (gapCount + 1),
            Justify.SpaceEvenly => free / (gapCount + 1),
            _ => gap
        };
    }

    public static double ComputeCrossOffset(AlignItems align, double availableCross, double itemCross)
    {
        if (align == AlignItems.Stretch)
            return 0;

        var free = availableCross - itemCross;
        if (free <= 0)
            return 0;

        return align switch
        {
            AlignItems.Center => free / 2,
            AlignItems.FlexEnd => free,
            _ => 0
        };
    }

    public static double ResolveCrossSize(AlignItems align, double availableCross, double itemCross)
        => align == AlignItems.Stretch ? availableCross : itemCross;

    public static List<List<LayoutChild>> BuildLines(
        IReadOnlyList<LayoutChild> items,
        bool isRow,
        double gap,
        double availableMain,
        Wrap wrap)
    {
        var lines = new List<List<LayoutChild>>();
        var current = new List<LayoutChild>();
        var currentMain = 0d;
        var firstInLine = true;

        foreach (var item in items)
        {
            var itemMain = item.IsSpacer ? 0 : item.MainSize;
            var projected = firstInLine ? itemMain : currentMain + gap + itemMain;

            if (!firstInLine && projected > availableMain && current.Count > 0)
            {
                lines.Add(current);
                current = new List<LayoutChild>();
                currentMain = itemMain;
                firstInLine = itemMain == 0;
            }
            else
            {
                if (!firstInLine)
                    currentMain += gap;
                currentMain += itemMain;
                firstInLine = false;
            }

            current.Add(item);
        }

        if (current.Count > 0)
            lines.Add(current);

        if (wrap == Wrap.WrapReverse)
            lines.Reverse();

        return lines;
    }
}
