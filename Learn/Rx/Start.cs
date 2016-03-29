using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
using System.Threading;

namespace Rx {
    [TestClass]
    public class Start {

        DateTime start;

        [TestMethod]
        public void Test() {
            start = DateTime.Now;
            // Startは自動でスタート
            var o = Observable.Start(() => {
                Log("Start!");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Log("Return!");
                return "Value";
            });
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Log("Subscribe");
            var d = o.Subscribe(_ => {
                Log("Subscribed " + _);
            });
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Log("End!");
        }

        void Log(string msg) {
            Console.WriteLine((DateTime.Now - start).ToString() + ": " + msg);
        }
    }
}
