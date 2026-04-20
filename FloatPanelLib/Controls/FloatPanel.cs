using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

namespace FloatPanel.Controls;

public enum JustifyContent
{
    Start,
    Center,
    End,
    SpaceBetween,
    SpaceAround,
    SpaceEvenly
}

public enum AlignItems
{
    Start,
    Center,
    End,
    Stretch
}

public class FloatPanel : Panel
{
    public static readonly StyledProperty<Orientation> OrientationProperty =
        AvaloniaProperty.Register<FloatPanel, Orientation>(nameof(Orientation), Orientation.Horizontal);

    public static readonly StyledProperty<double> SpacingProperty =
        AvaloniaProperty.Register<FloatPanel, double>(nameof(Spacing), 8);

    public static readonly StyledProperty<JustifyContent> JustifyProperty =
        AvaloniaProperty.Register<FloatPanel, JustifyContent>(nameof(Justify), JustifyContent.Start);

    public static readonly StyledProperty<AlignItems> AlignProperty =
        AvaloniaProperty.Register<FloatPanel, AlignItems>(nameof(Align), AlignItems.Stretch);

    public static readonly StyledProperty<bool> WrapProperty =
        AvaloniaProperty.Register<FloatPanel, bool>(nameof(Wrap), false);

    public Orientation Orientation
    {
        get => GetValue(OrientationProperty);
        set => SetValue(OrientationProperty, value);
    }

    public double Spacing
    {
        get => GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }

    public JustifyContent Justify
    {
        get => GetValue(JustifyProperty);
        set => SetValue(JustifyProperty, value);
    }

    public AlignItems Align
    {
        get => GetValue(AlignProperty);
        set => SetValue(AlignProperty, value);
    }

    public bool Wrap
    {
        get => GetValue(WrapProperty);
        set => SetValue(WrapProperty, value);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        double width = 0;
        double height = 0;

        foreach (var child in Children)
        {
            child.Measure(availableSize);

            if (Orientation == Orientation.Horizontal)
            {
                width += child.DesiredSize.Width;
                height = Math.Max(height, child.DesiredSize.Height);
            }
            else
            {
                width = Math.Max(width, child.DesiredSize.Width);
                height += child.DesiredSize.Height;
            }
        }

        int spacerCount = Children.Count(c => c is Spacer);
        int gapCount = Math.Max(0, Children.Count - spacerCount - 1);
        double totalSpacing = gapCount * Spacing;

        if (Orientation == Orientation.Horizontal)
            width += totalSpacing;
        else
            height += totalSpacing;

        return new Size(width, height);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        if (!Wrap)
        {
            return ArrangeNoWrap(finalSize);
        }

        if (Orientation == Orientation.Horizontal)
        {
            return ArrangeWrapHorizontal(finalSize);
        }
        else
        {
            return ArrangeWrapVertical(finalSize);
        }
    }

    private Size ArrangeNoWrap(Size finalSize)
    {
        int spacerCount = Children.Count(c => c is Spacer);
        int nonSpacerCount = Children.Count - spacerCount;
        int gapCount = Math.Max(0, nonSpacerCount - 1);

        double totalContentSize = 0;
        foreach (var child in Children)
        {
            totalContentSize += Orientation == Orientation.Horizontal
                ? child.DesiredSize.Width
                : child.DesiredSize.Height;
        }

        double totalSpacing = gapCount * Spacing;
        double totalSize = totalContentSize + totalSpacing;
        double available = Orientation == Orientation.Horizontal ? finalSize.Width : finalSize.Height;

        double offset = 0;
        if (spacerCount == 0)
        {
            switch (Justify)
            {
                case JustifyContent.Center:
                    offset = (available - totalSize) / 2;
                    break;
                case JustifyContent.End:
                    offset = available - totalSize;
                    break;
                case JustifyContent.SpaceBetween:
                    if (nonSpacerCount > 1 && available > totalSize)
                        totalSpacing = (available - totalContentSize) / gapCount;
                    break;
                case JustifyContent.SpaceAround:
                case JustifyContent.SpaceEvenly:
                    if (nonSpacerCount > 0 && available > totalSize)
                    {
                        double space = (available - totalSize) / (nonSpacerCount + 1);
                        offset = space;
                        totalSpacing = space;
                    }
                    break;
            }
        }

        offset = Math.Max(0, offset);

        double crossSize = Orientation == Orientation.Horizontal ? finalSize.Height : finalSize.Width;
        double crossOffset = 0;

        if (Align != AlignItems.Stretch)
        {
            foreach (var child in Children)
            {
                double childCrossSize = Orientation == Orientation.Horizontal
                    ? child.DesiredSize.Height
                    : child.DesiredSize.Width;
                if (childCrossSize < crossSize)
                {
                    crossOffset = Align switch
                    {
                        AlignItems.Center => (crossSize - childCrossSize) / 2,
                        AlignItems.End => crossSize - childCrossSize,
                        _ => 0
                    };
                    break;
                }
            }
        }

        double x = offset;
        double y = Orientation == Orientation.Horizontal ? crossOffset : offset;

        for (int i = 0; i < Children.Count; i++)
        {
            var child = Children[i];
            double childWidth = child.DesiredSize.Width;
            double childHeight = child.DesiredSize.Height;
            double childMainSize = Orientation == Orientation.Horizontal ? childWidth : childHeight;

            if (child is Spacer)
            {
                int itemsAfter = 0;
                double sizeAfter = 0;
                for (int j = i + 1; j < Children.Count; j++)
                {
                    if (Children[j] is Spacer) continue;
                    itemsAfter++;
                    sizeAfter += Orientation == Orientation.Horizontal
                        ? Children[j].DesiredSize.Width
                        : Children[j].DesiredSize.Height;
                }
                int gapsAfter = Math.Max(0, itemsAfter - 1);
                double remaining = available - x - sizeAfter - gapsAfter * Spacing;
                childMainSize = Math.Max(0, remaining);
            }

            Rect bounds;
            if (Orientation == Orientation.Horizontal)
            {
                bounds = new Rect(x, Align == AlignItems.Stretch ? 0 : crossOffset,
                    childMainSize, Align == AlignItems.Stretch ? finalSize.Height : childHeight);
                x += childMainSize;
            }
            else
            {
                bounds = new Rect(Align == AlignItems.Stretch ? 0 : crossOffset, y,
                    Align == AlignItems.Stretch ? finalSize.Width : childWidth, childMainSize);
                y += childMainSize;
            }

            child.Arrange(bounds);

            if (!(child is Spacer) && i < Children.Count - 1)
            {
                if (Orientation == Orientation.Horizontal)
                    x += Spacing;
                else
                    y += Spacing;
            }
        }

        return finalSize;
    }

    private Size ArrangeWrapHorizontal(Size finalSize)
    {
        double y = 0;
        double rowHeight = 0;
        double x = 0;
        bool firstInRow = true;

        var rows = new List<List<Control>>();
        var currentRow = new List<Control>();
        double currentRowWidth = 0;

        foreach (var child in Children)
        {
            double childWidth = child.DesiredSize.Width;

            if (!firstInRow)
                currentRowWidth += Spacing;

            if (currentRowWidth + childWidth > finalSize.Width && !firstInRow)
            {
                rows.Add(currentRow);
                currentRow = new List<Control>();
                currentRowWidth = childWidth;
                firstInRow = true;
            }
            else
            {
                currentRowWidth += childWidth;
                firstInRow = false;
            }

            currentRow.Add(child);
        }

        if (currentRow.Count > 0)
            rows.Add(currentRow);

        foreach (var row in rows)
        {
            rowHeight = 0;
            foreach (var child in row)
            {
                rowHeight = Math.Max(rowHeight, child.DesiredSize.Height);
            }

            double rowContentSize = 0;
            foreach (var child in row)
            {
                rowContentSize += child.DesiredSize.Width;
            }

            x = 0;
            for (int i = 0; i < row.Count; i++)
            {
                var child = row[i];
                double childWidth = child.DesiredSize.Width;
                double childHeight = child.DesiredSize.Height;
                double width = childWidth;

                if (child is Spacer)
                {
                    int itemsAfter = 0;
                    double sizeAfter = 0;
                    for (int j = i + 1; j < row.Count; j++)
                    {
                        if (row[j] is Spacer) continue;
                        itemsAfter++;
                        sizeAfter += row[j].DesiredSize.Width;
                    }
                    int gapsAfter = Math.Max(0, itemsAfter - 1);
                    double remaining = finalSize.Width - x - sizeAfter - gapsAfter * Spacing;
                    width = Math.Max(0, remaining);
                }

                var bounds = new Rect(x, y, width, rowHeight);
                child.Arrange(bounds);

                if (!(child is Spacer))
                {
                    x += childWidth + Spacing;
                }
                else
                {
                    x += width;
                }
            }

            y += rowHeight + Spacing;
        }

        return finalSize;
    }

    private Size ArrangeWrapVertical(Size finalSize)
    {
        double x = 0;
        double colWidth = 0;
        double y = 0;
        bool firstInCol = true;

        var cols = new List<List<Control>>();
        var currentCol = new List<Control>();
        double currentColHeight = 0;

        foreach (var child in Children)
        {
            double childHeight = child.DesiredSize.Height;

            if (!firstInCol)
                currentColHeight += Spacing;

            if (currentColHeight + childHeight > finalSize.Height && !firstInCol)
            {
                cols.Add(currentCol);
                currentCol = new List<Control>();
                currentColHeight = childHeight;
                firstInCol = true;
            }
            else
            {
                currentColHeight += childHeight;
                firstInCol = false;
            }

            currentCol.Add(child);
        }

        if (currentCol.Count > 0)
            cols.Add(currentCol);

        foreach (var col in cols)
        {
            colWidth = 0;
            foreach (var child in col)
            {
                colWidth = Math.Max(colWidth, child.DesiredSize.Width);
            }

            y = 0;
            for (int i = 0; i < col.Count; i++)
            {
                var child = col[i];
                double childWidth = child.DesiredSize.Width;
                double childHeight = child.DesiredSize.Height;
                double height = childHeight;

                if (child is Spacer)
                {
                    int itemsAfter = 0;
                    double sizeAfter = 0;
                    for (int j = i + 1; j < col.Count; j++)
                    {
                        if (col[j] is Spacer) continue;
                        itemsAfter++;
                        sizeAfter += col[j].DesiredSize.Height;
                    }
                    int gapsAfter = Math.Max(0, itemsAfter - 1);
                    double remaining = finalSize.Height - y - sizeAfter - gapsAfter * Spacing;
                    height = Math.Max(0, remaining);
                }

                var bounds = new Rect(x, y, colWidth, height);
                child.Arrange(bounds);

                if (!(child is Spacer))
                {
                    y += childHeight + Spacing;
                }
                else
                {
                    y += height;
                }
            }

            x += colWidth + Spacing;
        }

        return finalSize;
    }
}
