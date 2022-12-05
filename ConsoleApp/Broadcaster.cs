using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace ConsoleApp;

internal class Broadcaster
{
    public delegate void BroadcastHandler(object sender);

    private List<BroadcastHandler> _handlers = new();

    public void AddHandler(BroadcastHandler handler)
    {
        _handlers.Add(handler);
    }

    private Settings _settings;

    public Broadcaster(Settings settings)
    {
        _settings = settings;
    }

    public void RemoveHandler(BroadcastHandler handler)
    {
        _handlers.Remove(handler);
    }

    public void Run()
    {
        var counter = 0;
        while (true)
        {
            Thread.Sleep(_settings.Delay * 1000);
            foreach (var handler in _handlers)
                handler?.Invoke(this);

        }
    }
}