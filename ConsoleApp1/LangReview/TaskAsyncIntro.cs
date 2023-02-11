namespace ConsoleApp1.LangReview
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class TaskAsyncIntro
    {
        public async Task TestSimpleTaskFunc()
        {
            await Print();
            var answer = await GetAnswer();
        }

        private async Task Print()
        {
            await Task.Delay(1000);
            int i = 3 * 2;
            Console.WriteLine(i);
        }

        private async Task<int> GetAnswer()
        {
            await Task.Delay(1000);
            int i = 3 * 2;

            return i;
        }
    }
}
