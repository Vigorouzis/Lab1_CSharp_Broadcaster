using System.Net;
using Data;
using Provider;
using Providers.interfaces;

namespace ConsoleApp;

public class Project : IProject
{
    private static Project? instance;


    private ISettingsProvider<Settings> _provider;
    private IOProvider _IOprovider;
    private Settings _settings;

    public Project(ISettingsProvider<Settings> settingsProvider, IOProvider provider, Settings settings)
    {
        _provider = settingsProvider;
        _IOprovider = provider;
        _settings = settings;
    }

    public static Project GetInstance(ISettingsProvider<Settings> settingsProvider, IOProvider provider, Settings settings)
    {
        return instance ??= new Project(settingsProvider, provider, settings);
    }

    public void Run()
    {
        Broadcaster broadcaster = new Broadcaster(_settings);
        broadcaster.AddHandler((sender) =>
        {
            var request = WebRequest.Create("https://jsonplaceholder.typicode.com/posts");
            request.Method = "GET";
            using var webResponse = request.GetResponse();
            
            Console.WriteLine(webResponse);
        });

        broadcaster.AddHandler((sender) =>
        {
            var request = WebRequest.Create("https://jsonplaceholder.typicode.com/posts");
            request.Method = "GET";
            using var webResponse = request.GetResponse();
            _IOprovider.WriteLine(webResponse.ToString());
        });
        broadcaster.Run();
    }
}