using System.Threading.Tasks;
namespace H_W_Mod3_6
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            MessageBox messageBox = new MessageBox();
            var taskCompletionSource = new TaskCompletionSource();
            messageBox.OnWinClosed += (messageBox, state) =>
            {
                if (state == MessageBox.State.Ok)
                {
                    Console.WriteLine("the operation is confirmed");
                }
                if (state == MessageBox.State.Cancel)
                {
                    Console.WriteLine("the operation is canceled");
                }
                taskCompletionSource.SetResult();
            };

            messageBox.Open();
            await taskCompletionSource.Task;
            Console.WriteLine("****************");
        }
    }
}