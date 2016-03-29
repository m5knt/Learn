using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
using System.Threading;

namespace Rx {
    [TestClass]
    public class Defer {

        DateTime start;

        [TestMethod]
        public void Test() {
            start = DateTime.Now;
            // Deferは開始を遅らすことができる
            var o = Observable.Defer(() => Observable.Start(() => {
                Log("Start!");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Log("Return!");
                return "Value";
            }));
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
