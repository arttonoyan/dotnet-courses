namespace _004_AsyncDisposable;

//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-disposeasync
internal class Program
{
    static async Task Main(string[] args)
    {
        var exampleAsyncDisposable = new ExampleAsyncDisposable();
        await using (exampleAsyncDisposable.ConfigureAwait(false))
        {
            // Interact with the exampleAsyncDisposable instance.
        }

        Console.ReadLine();
    }
}
public class ExampleAsyncDisposable : IAsyncDisposable
{
    private IAsyncDisposable? _example;

    public ExampleAsyncDisposable() =>
        _example = new NoopAsyncDisposable();

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_example is not null)
        {
            await _example.DisposeAsync().ConfigureAwait(false);
        }

        _example = null;
    }
}

public sealed class NoopAsyncDisposable : IAsyncDisposable
{
    ValueTask IAsyncDisposable.DisposeAsync() => ValueTask.CompletedTask;
}
