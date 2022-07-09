using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    public class AsyncDemo
    {

        public static async Task FileAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"await 之前，线程Id为{Thread.CurrentThread.ManagedThreadId.ToString()}");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10000000; i++)
            {
                sb.AppendLine("hello");
            }
            var filename = "d:\\a\\1.txt";
            await File.WriteAllTextAsync(filename, sb.ToString());
            //await File.WriteAllTextAsync(filename, sb.ToString(), cancellationToken);
            Console.WriteLine($"await 之后111，线程Id为{Thread.CurrentThread.ManagedThreadId.ToString()}");

            //if(cancellationToken.IsCancellationRequested)
            //{
            //    Console.WriteLine($"线程已取消");
            //}

            cancellationToken.ThrowIfCancellationRequested();

           await File.ReadAllTextAsync(filename);
            Console.WriteLine($"await 之后222，线程Id为{Thread.CurrentThread.ManagedThreadId.ToString()}");
        }
    }
}
