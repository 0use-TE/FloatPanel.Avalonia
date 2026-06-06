using System.Text;
using FloatPanel.Controls;

namespace FloatPanel.ViewModels;

internal static class DemoXamlBuilder
{
    private const int DefaultSpacing = 2;

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
        sb.AppendLine(row ? "    Row=\"True\"" : "    Row=\"False\"");
        sb.AppendLine($"    Spacing=\"{spacing}\"");
        sb.AppendLine($"    AlignItems=\"{alignItems}\"");

        if (reverse)
            sb.AppendLine("    Reverse=\"True\"");

        if (justify != Justify.FlexStart)
            sb.AppendLine($"    Justify=\"{justify}\"");

        if (wrap != Wrap.NoWrap)
            sb.AppendLine($"    Wrap=\"{wrap}\"");

        if (stretchItems != StretchItems.None)
            sb.AppendLine($"    StretchItems=\"{stretchItems}\"");

        if (breakpoint != Breakpoint.None)
            sb.AppendLine($"    Breakpoint=\"{breakpoint}\"");

        sb.AppendLine("    >");
        sb.AppendLine("    <Button Content=\"Settings\" />");
        sb.AppendLine("    <Spacer />");
        sb.AppendLine("    <Button Content=\"Cancel\" />");
        sb.AppendLine("    <Button Content=\"Apply\" Classes=\"accent\" />");
        sb.AppendLine("</FloatPanel>");
        return sb.ToString();
    }

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
    <Border Background="#42A5F5" CornerRadius="4" Padding="10,6">
        <TextBlock Text="Tag 3" Foreground="White" />
    </Border>
    <Border Background="#66BB6A" CornerRadius="4" Padding="10,6">
        <TextBlock Text="Tag 4" Foreground="White" />
    </Border>
    <Border Background="#FFCA28" CornerRadius="4" Padding="10,6">
        <TextBlock Text="Tag 5" Foreground="White" />
    </Border>
    <Border Background="#8D6E63" CornerRadius="4" Padding="10,6">
        <TextBlock Text="Tag 6" Foreground="White" />
    </Border>
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
