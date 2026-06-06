using System.Text;
using FloatPanel.Controls;

namespace FloatPanel.ViewModels;

internal static class DemoXamlBuilder
{
    public static string BuildPlayground(
        bool row,
        bool reverse,
        int spacing,
        Justify justify,
        AlignItems alignItems,
        Wrap wrap,
        StretchItems stretchItems,
        Breakpoint breakpoint)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<FloatPanel");

        if (row)
            sb.AppendLine("    Row=\"True\"");

        if (reverse)
            sb.AppendLine("    Reverse=\"True\"");

        if (spacing != 3)
            sb.AppendLine($"    Spacing=\"{spacing}\"");

        if (justify != Justify.FlexStart)
            sb.AppendLine($"    Justify=\"{justify}\"");

        if (alignItems != AlignItems.Stretch)
            sb.AppendLine($"    AlignItems=\"{alignItems}\"");

        if (wrap != Wrap.NoWrap)
            sb.AppendLine($"    Wrap=\"{wrap}\"");

        if (stretchItems != StretchItems.None)
            sb.AppendLine($"    StretchItems=\"{stretchItems}\"");

        if (breakpoint != Breakpoint.None)
            sb.AppendLine($"    Breakpoint=\"{breakpoint}\"");

        sb.AppendLine("    >");
        sb.AppendLine("    <Border Background=\"#5C6BC0\" CornerRadius=\"4\" Padding=\"12,8\">");
        sb.AppendLine("        <TextBlock Text=\"Item 1\" Foreground=\"White\" />");
        sb.AppendLine("    </Border>");
        sb.AppendLine("    <Border Background=\"#26A69A\" CornerRadius=\"4\" Padding=\"12,8\">");
        sb.AppendLine("        <TextBlock Text=\"Item 2\" Foreground=\"White\" />");
        sb.AppendLine("    </Border>");
        sb.AppendLine("    <Border Background=\"#FFA726\" CornerRadius=\"4\" Padding=\"12,8\">");
        sb.AppendLine("        <TextBlock Text=\"Item 3\" Foreground=\"White\" />");
        sb.AppendLine("    </Border>");
        sb.Append("</FloatPanel>");
        return sb.ToString();
    }

    public const string SpacerExample = """
<FloatPanel Row="True" Spacing="2" AlignItems="Center">
    <Button Content="Settings" />
    <Spacer />
    <Button Content="Apply" Classes="accent" />
</FloatPanel>
""";

    public const string VerticalExample = """
<FloatPanel Spacing="2">
    <TextBlock Text="Title" FontWeight="SemiBold" />
    <TextBlock Text="Description goes here." Opacity="0.7" TextWrapping="Wrap" />
    <Spacer />
    <Button Content="OK" HorizontalAlignment="Stretch" />
</FloatPanel>
""";

    public const string WrapExample = """
<FloatPanel Row="True" Wrap="Wrap" Spacing="2">
    <Border Background="#EF5350" CornerRadius="4" Padding="10,6">
        <TextBlock Text="Tag 1" Foreground="White" />
    </Border>
    <Border Background="#AB47BC" CornerRadius="4" Padding="10,6">
        <TextBlock Text="Tag 2" Foreground="White" />
    </Border>
    <!-- ... more tags ... -->
</FloatPanel>
""";

    public const string BreakpointExample = """
<FloatPanel Row="True" Breakpoint="Md" Spacing="2">
    <Border Background="#5C6BC0" CornerRadius="4" Padding="12,8">
        <TextBlock Text="Left" Foreground="White" />
    </Border>
    <Border Background="#26A69A" CornerRadius="4" Padding="12,8">
        <TextBlock Text="Center" Foreground="White" />
    </Border>
    <Border Background="#FFA726" CornerRadius="4" Padding="12,8">
        <TextBlock Text="Right" Foreground="White" />
    </Border>
</FloatPanel>
""";
}
