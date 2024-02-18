using System;

namespace LeetCode.Problems._24
{
	internal class Problem2402
	{
		public int MostBooked(int totalRooms, int[][] meetings)
		{
			int[] meetingCountsPerRoom = new int[totalRooms];
			long[] lastMeetingEndTimePerRoom = new long[totalRooms];
			for (int i = 0; i < totalRooms; i++) lastMeetingEndTimePerRoom[i] = 0;

			Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

			foreach (var meeting in meetings)
			{
				int meetingStart = meeting[0], meetingEnd = meeting[1];
				bool roomAssigned = false;
				int roomIndexWithEarliestEndTime = -1;
				long earliestEndTime = long.MaxValue;

				for (int roomIndex = 0; roomIndex < totalRooms; roomIndex++)
				{
					if (lastMeetingEndTimePerRoom[roomIndex] < earliestEndTime)
					{
						earliestEndTime = lastMeetingEndTimePerRoom[roomIndex];
						roomIndexWithEarliestEndTime = roomIndex;
					}
					if (lastMeetingEndTimePerRoom[roomIndex] <= meetingStart)
					{
						roomAssigned = true;
						meetingCountsPerRoom[roomIndex]++;
						lastMeetingEndTimePerRoom[roomIndex] = meetingEnd;
						break;
					}
				}

				if (!roomAssigned)
				{
					meetingCountsPerRoom[roomIndexWithEarliestEndTime]++;
					lastMeetingEndTimePerRoom[roomIndexWithEarliestEndTime] += (meetingEnd - meetingStart);
				}
			}

			int maxMeetings = -1, roomWithMostMeetings = -1;
			for (int roomIndex = 0; roomIndex < totalRooms; roomIndex++)
			{
				if (meetingCountsPerRoom[roomIndex] > maxMeetings)
				{
					maxMeetings = meetingCountsPerRoom[roomIndex];
					roomWithMostMeetings = roomIndex;
				}
			}

			return roomWithMostMeetings;
		}
	}
}
