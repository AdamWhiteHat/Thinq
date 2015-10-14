using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using System.Reactive.Threading;
using System.Reactive.Subjects;
using System.Reactive.PlatformServices;
using System.Reactive.Joins;
using System.Reactive.Disposables;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Linq.Observαble;

using ThinqCore;

namespace ThinqCore.Sandbox
{
	public class Sandbox
	{

		public static IEnumerable<int> FindFactorsOf7and3(Action<long> foundEventHandler)
		{
			Range.Multiples multiplesOf3 = new Range.Multiples(3, 100);
			Range.Multiples multiplesOf7 = new Range.Multiples(7, 100);

			IEnumerable<int> enumerablesOf3 = multiplesOf3.GetNextMultipleInSet();
			IEnumerable<int> enumerablesOf7 = multiplesOf7.GetNextMultipleInSet();

			// Larger number out
			return enumerablesOf7.Intersect(enumerablesOf3);
		}

		public static IDisposable SequenceOf7and3(Action<long> foundEventHandler)
		{


			IObservable<long> observable7 = Observable.Interval(TimeSpan.FromSeconds(7));
			IObservable<long> observable3 = Observable.Interval(TimeSpan.FromSeconds(3));
			IObservable<long> commonMultipleOf7and3 = Observable.Merge<long>(observable7, observable3);

			Pattern<long, long> pattern7and3 = observable7.And(observable3);

			Plan<string> plan7and3 = pattern7and3.Then<string>((a, b) => (a == b) ? a.ToString() : string.Format("a={0} b={1}", a, b)); //new Func<long,long,string>(new  delegate(long a,long b) { return (a == b) ? a.ToString() : string.Format("a={0} b={1}", a, b); } ));


			IDisposable dispose7and3 = commonMultipleOf7and3.Subscribe(foundEventHandler);

			return dispose7and3;
		}
	}
}
