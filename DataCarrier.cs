using System;
using System.Collections.Generic;
using System.Text;

namespace UpdatingDateApp
{
	// This class is used as a data carrier for multiple threads.
	public class DataCarrier
	{
		public string CurrentDate { get; }
		public string CurrentSurname { get; }
		public DateOnly LimitDate { get; }
		public bool UpdateAll { get; }
		public string OutputNew_FullName { get; }
		public UnitOfTaskScheduler TaskScheduler { get; }
		public List<StringBuilder> ErrorSBList { get; }



		public DataCarrier(string currentDate, string currentSurname, DateOnly limitDate, bool updateAll, string outputNew_FullName, UnitOfTaskScheduler taskScheduler)
		{
			CurrentDate = currentDate;
			CurrentSurname = currentSurname;
			LimitDate = limitDate;
			UpdateAll = updateAll;
			OutputNew_FullName = outputNew_FullName;
			TaskScheduler = taskScheduler;

			ErrorSBList = new();
		}

		public void AddErrorSB(StringBuilder sb)
		{
			lock (this)
			{
				ErrorSBList.Add(sb);
			}
		}
	}
}
