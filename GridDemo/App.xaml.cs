using GridDemo.Model;
using GridDemo.Service;
using GridDemo.View;
using GridDemo.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace GridDemo;

public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; }

    public App()
    {
        var serviceCollection = new ServiceCollection();

        // 서비스와 ViewModel 등록
        serviceCollection.AddSingleton<IUserDataService, UserDataService>();
        serviceCollection.AddTransient<MainViewModel>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        List<Person> persons = new List<Person>();
        persons.Add(new Person { Name = "John Doe", Age = 42 });
        persons.Add(new Person { Name = "Jane Doe", Age = 39 });
        persons.Add(new Person { Name = "Sammy Doe", Age = 13 });

        var userDataService = ServiceProvider.GetRequiredService<IUserDataService>();

        // 외부 데이터를 서비스에 전달
        userDataService.SetUserDataList(persons);

        var mainWindow = new MainWindow
        {
            DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
        };

        mainWindow.Show();
    }
}
