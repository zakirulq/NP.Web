using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NP.Persistence.Definition.Repositories;
using System.Security.AccessControl;
using System.Security.Principal;
using log4net;

namespace NP.Persistence.PersistenceContext
{
	public class FilePersistenceContext : IPersistenceContext
	{
		readonly string _filePath = string.Empty;
		readonly string _fileNameWithFullPath = string.Empty;
		static readonly ILog logger = LogManager.GetLogger(typeof(FilePersistenceContext));

		public FilePersistenceContext(string fileNameWithFullPath)
		{
			_filePath = Path.GetDirectoryName(fileNameWithFullPath);
			_fileNameWithFullPath = fileNameWithFullPath;
			Set = new List<object>();
		}

		public List<object> Set { get; set; }

		public bool Delete(object entity)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			logger.Debug("Starting the Save process");
			var isSuccessful = false;
			if (Set.Any())
			{
				try
				{
					var input = string.Empty;
					foreach (var entity in Set)
					{
						input += $"{ (string)entity}{Environment.NewLine}";
					}

					if (!Directory.Exists(_filePath))
					{
						var directory = Directory.CreateDirectory(_filePath);
						var dSecurity = directory.GetAccessControl();
						dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
						directory.SetAccessControl(dSecurity);
					}

					File.AppendAllText(_fileNameWithFullPath, input);
					isSuccessful = true;
					logger.Debug("Ending the Save process successfully");
				}
				catch (Exception ex)
				{
					logger.Error($"Exception: {ex.Message}");
					throw;
				}
			}

			return isSuccessful;
		}
	}
}
