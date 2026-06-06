using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FloatPanel.Controls;

namespace FloatPanel.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _row = true;

    [ObservableProperty]
    private bool _reverse;

    [ObservableProperty]
    private int _spacing = 2;

    [ObservableProperty]
    private Justify _justify = Justify.FlexStart;

    [ObservableProperty]
    private AlignItems _alignItems = AlignItems.Center;

    [ObservableProperty]
    private Wrap _wrap = Wrap.NoWrap;

    [ObservableProperty]
    private StretchItems _stretchItems = StretchItems.None;

    [ObservableProperty]
    private Breakpoint _breakpoint = Breakpoint.None;

    [ObservableProperty]
    private string _playgroundXaml = DemoXamlBuilder.BuildPlayground(
        true, false, 2, Justify.FlexStart, AlignItems.Center, Wrap.NoWrap, StretchItems.None, Breakpoint.None);

    [ObservableProperty]
    private bool _isPlaygroundCodeOpen = true;

    public Array JustifyValues { get; } = Enum.GetValues<Justify>();

    public Array AlignItemsValues { get; } = Enum.GetValues<AlignItems>();

    public Array WrapValues { get; } = Enum.GetValues<Wrap>();

    public Array StretchItemsValues { get; } = Enum.GetValues<StretchItems>();

    public Array BreakpointValues { get; } = Enum.GetValues<Breakpoint>();

    public string VerticalExampleXaml => DemoXamlBuilder.VerticalExample;

    public string WrapExampleXaml => DemoXamlBuilder.WrapExample;

    public string BreakpointExampleXaml => DemoXamlBuilder.BreakpointExample;

    partial void OnRowChanged(bool value) => RefreshPlaygroundXaml();

    partial void OnReverseChanged(bool value) => RefreshPlaygroundXaml();

    partial void OnSpacingChanged(int value) => RefreshPlaygroundXaml();

    partial void OnJustifyChanged(Justify value) => RefreshPlaygroundXaml();

    partial void OnAlignItemsChanged(AlignItems value) => RefreshPlaygroundXaml();

    partial void OnWrapChanged(Wrap value) => RefreshPlaygroundXaml();

    partial void OnStretchItemsChanged(StretchItems value) => RefreshPlaygroundXaml();

    partial void OnBreakpointChanged(Breakpoint value) => RefreshPlaygroundXaml();

    private void RefreshPlaygroundXaml()
    {
        PlaygroundXaml = DemoXamlBuilder.BuildPlayground(
            Row, Reverse, Spacing, Justify, AlignItems, Wrap, StretchItems, Breakpoint);
    }

    [RelayCommand]
    private void HidePlaygroundCode() => IsPlaygroundCodeOpen = false;

    [RelayCommand]
    private void ShowPlaygroundCode() => IsPlaygroundCodeOpen = true;
}
