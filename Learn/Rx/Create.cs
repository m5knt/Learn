using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive.Linq;
using System.Threading;
using System.Reactive.Disposables;

namespace Rx {
    [TestClass]
    public class Create {

        DateTime start;

        [TestMethod]
        public void Test() {
            start = DateTime.Now;
            // Startは自動でスタート
            var o = Observable.Create<string>(_ => {
                Log("OnNext Value0");
                _.OnNext("Value0");
                Log("OnNext Value1");
                _.OnNext("Value1");
                return Disposable.Empty;
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
