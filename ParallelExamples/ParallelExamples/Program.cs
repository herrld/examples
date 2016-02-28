using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Data;
using System.Diagnostics;

namespace ParallelExamples
{
    class Program
    {
        enum testEnum { number1, pickle };
        static void Main(string[] args)
        {
            
            Console.WriteLine("before");
            var cards = Task.Run(new Func<List<Card>>(getData));
            cards.Wait();
            Console.WriteLine("after");

        }
        private static List<Card> getData()
        {
            int iterations = 1000;
            List<Card> newCards = new List<Card>();
            for (var i = 0; i < iterations; i++)
            {
                newCards.Add(new Card());
            }
            int finalResult = 0;

            List<Task> buildTasks = new System.Collections.Generic.List<Task>();

            // basic foreach and it works
            //Parallel.ForEach(newCards, (curCard) => buildTasks.Add(curCard.build("s")));
            Parallel.ForEach<Card,int>(newCards,() => 0,(curCard,loop, id) =>{
                curCard.ID = id;
                curCard.name = id.ToString();
                return id++;
            },(finalId)=>{});
            
            // not working
            Parallel.For(0, iterations, () => newCards,(count,state,interimResult) => { 
                buildTasks.Add(interimResult.ElementAt(count).build("s"));
                return interimResult;
            }, (result) => result.Add(new Card()));

            Stopwatch sw = Stopwatch.StartNew();
            //Parallel.For(0, 100000, index =>
            //{
            //    newCards.Add(new Card
            //    {
            //        ID = index,
            //        name = index.ToString()
            //    });
            //});

            Task.WaitAll(buildTasks.ToArray());
            Console.WriteLine(sw.ElapsedMilliseconds);
            var holder = Console.ReadLine();
            return newCards;
        }
    }


}
