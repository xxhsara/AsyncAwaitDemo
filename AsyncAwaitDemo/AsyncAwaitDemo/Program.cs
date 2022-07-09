// See https://aka.ms/new-console-template for more information
//杨中科老师举例餐馆点菜的例子来说明异步的这个事还是很形象的
//不能保证await 前后的线程是否是同一个。await只是等待了，然后线程会回到线程池。
//尽量不要使用Thread.Sleep  而是使用 await Task.Delay();
using AsyncAwaitDemo;


Console.WriteLine($"program，线程Id为{Thread.CurrentThread.ManagedThreadId.ToString()}");

//线程取消
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
cancellationTokenSource.CancelAfter(1000);
await AsyncDemo.FileAsync(cancellationTokenSource.Token);
Console.WriteLine($"program111，线程Id为{Thread.CurrentThread.ManagedThreadId.ToString()}");

Console.ReadKey();
