// File: Gio3Demo.cs
using System;
using System.Threading;
using System.Threading.Tasks;

namespace tuan2.asyn_task_await
{
    internal class cancellationToken
    {
        public async Task DemLuiAsync(CancellationToken token)
        {
            for (int i = 10; i >= 0; i--)
            {
                token.ThrowIfCancellationRequested(); 
                Console.WriteLine($"Đem: {i}");
                await Task.Delay(1000, token); 
            }
        }

        public async Task RunAsync()
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(13000);

            try
            {
                await DemLuiAsync(cts.Token);
                Console.WriteLine("Đem xong!");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("da huy dem nguoc!");
            }
        }
    }
}