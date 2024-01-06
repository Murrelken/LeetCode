using System;

namespace LeetCode.Problems._12
{
	internal class Prolem1235
	{
		public class Solution
		{
			private Meeting[] _meetings;
			private int[] _dp;

			private const int EmptyState = -1;

			public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
			{
				Initialization(startTime, endTime, profit);
				return FindMaxProfit(0);
			}

			private int FindMaxProfit(int index)
			{
				if (index >= _meetings.Length)
					return 0;

				if (_dp[index] != EmptyState)
					return _dp[index];

				var nextMeetingIndex = FindNextAvailableMeeting(index + 1, _meetings[index].EndTime);

				var skip = FindMaxProfit(index + 1);
				var schedule = _meetings[index].Profit + FindMaxProfit(nextMeetingIndex);

				return _dp[index] = Math.Max(skip, schedule);
			}

			int FindNextAvailableMeeting(int currentIndex, int nextStartTime)
			{
				var start = currentIndex;
				var end = _meetings.Length - 1;
				var nextAvailableMeetingIndex = _meetings.Length;

				while (start <= end)
				{
					var mid = (start + end) / 2;
					if (_meetings[mid].StartTime >= nextStartTime)
					{
						nextAvailableMeetingIndex = mid;
						end = mid - 1;
					}
					else
					{
						start = mid + 1;
					}
				}

				return nextAvailableMeetingIndex;
			}

			void Initialization(int[] startTime, int[] endTime, int[] profit)
			{
				_meetings = new Meeting[startTime.Length];
				_dp = new int[startTime.Length + 1];

				for (int i = 0; i < startTime.Length; i++)
				{
					_meetings[i] = new Meeting(startTime[i], endTime[i], profit[i]);
				}

				Array.Fill(_dp, EmptyState);
				Array.Sort(_meetings);
			}

			record Meeting(int StartTime, int EndTime, int Profit) : IComparable<Meeting>
			{
				public int CompareTo(Meeting other)
				{
					return StartTime.CompareTo(other.StartTime);
				}
			}
		}
	}
}
