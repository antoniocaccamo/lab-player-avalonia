using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
//using Microsoft.Extensions.DependencyInjection;
using PlayerApp.Services;
using PlayerApp.ViewModels;
using PlayerApp.Views;
using ReactiveUI;
using Splat;


namespace PlayerApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        LibVLCSharp.Shared.Core.Initialize();

        //var serviceColleciolnt = new ServiceCollection();
        // serviceColleciolnt.AddCommonServices();

        //App.ServiceProvider = serviceColleciolnt.BuildServiceProvider();
        
        ServiceCollectionExtensions.AddCommonServices();

        var mainWindowViewModel = new MainWindowViewModel();
        Locator.CurrentMutable.RegisterLazySingleton(()=> mainWindowViewModel, typeof(IScreen));
        
        Locator.CurrentMutable.RegisterConstant(new LibraryViewModel());
        Locator.CurrentMutable.RegisterConstant(new ScreensViewModel());    
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    //public static ServiceProvider ServiceProvider { get; set; }


    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }


    private void NativeMenuItem_OnClick(object? sender, EventArgs e)
    {
        
    }
}