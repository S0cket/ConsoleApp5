using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5 {
	class Program {
		static void Main(string[] args) {
			TimeSpan begin = new TimeSpan(8, 0, 0);
			TimeSpan end = new TimeSpan(18, 0, 0);
			TimeSpan[] startTimes = new TimeSpan[] {
				new TimeSpan(10, 0, 0),
				new TimeSpan(12, 0, 0)
			};
			int[] durations = new int[] {
				60, 120
			};
			var a = Average(startTimes, durations, begin, end, 30);
			foreach (var b in a)
				Console.WriteLine(b);
		}

		static string[] Average(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultation) {
			List<TimeSpan> lst = new List<TimeSpan>();
			TimeSpan current = Copy(beginWorkingTime);
			for (int i = 0; i < durations.Length; ++ i) {
				while (current + new TimeSpan(0, consultation, 0) <= startTimes[i]) {
					lst.Add(Copy(current));
					current += new TimeSpan(0, consultation, 0);
				}
				current = startTimes[i] + new TimeSpan(0, durations[0], 0);
			}
			while (current + new TimeSpan(0, consultation, 0) <= endWorkingTime) {
				lst.Add(Copy(current));
				current += new TimeSpan(0, consultation, 0);
			}
			List<string> ret = new List<string>();
			foreach (var a in lst) {
				TimeSpan p = a + new TimeSpan(0, consultation, 0);
				DateTime x = new DateTime(1970, 1, 1, a.Hours, a.Minutes, a.Seconds);
				DateTime y = new DateTime(1970, 1, 1, p.Hours, p.Minutes, p.Seconds);
				ret.Add($"{x.ToString("HH:mm")}-{y.ToString("HH:mm")}");
			}
			return ret.ToArray();
		}

		static TimeSpan Copy(TimeSpan time) {
			return new TimeSpan(time.Hours, time.Minutes, time.Seconds);
		}

		///
	}
}
