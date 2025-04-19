using System.IO;

namespace UpdatingDateApp
{
	// This class is designed to control the operation of threads in which files are being read.
	public class UnitOfTaskScheduler
	{
		private readonly FileInfo[] _files;
		private int _next;

		public UnitOfTaskScheduler(FileInfo[] files)
		{
			_files = files;
			_next = 0;
		}

		public FileInfo? GetFile()
		{
			lock (this)
			{
				if (_next < _files.Length)
				{
					FileInfo fi = _files[_next];
					_next++;
					return fi;
				}
				else
					return null;
			}
		}
	}
}
