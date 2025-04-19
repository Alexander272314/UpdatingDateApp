using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdatingDateApp
{
	public partial class Form1 : Form
	{
		private const string _outputCopyFolderName = "Output unchanged copy";
		private const string _outputNewFolderName = "Output new";



		public Form1()
		{
			InitializeComponent();

			textBox2_OutputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			button0_Update.Click += Button0_Update_Click;
			button1_InputFolder.Click += Button1_InputFolder_Click;
			button2_OutputFolder.Click += Button2_OutputFolder_Click;
			checkBox6_UpdateAll.CheckedChanged += OptionSelector;
			checkBox7_AdditionalDate.CheckedChanged += OptionSelector;

			backgroundWorker0.WorkerReportsProgress = false;
			backgroundWorker0.WorkerSupportsCancellation = false;
			backgroundWorker0.DoWork += Update;
			backgroundWorker0.RunWorkerCompleted += UpdateFinalization;
		}



		#region Methods for EventHandlers
		private void Button0_Update_Click(object? sender, EventArgs e)
		{
			SetControlState(false);
			PrintResult("Идет обновление дат");

			backgroundWorker0.RunWorkerAsync();
		}

		private void Button1_InputFolder_Click(object? sender, EventArgs e)
		{
			textBox1_InputFolder.Clear();

			using (FolderBrowserDialog folderBrowserDialog = new())
			{
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
					textBox1_InputFolder.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void Button2_OutputFolder_Click(object? sender, EventArgs e)
		{
			textBox2_OutputFolder.Clear();

			using (FolderBrowserDialog folderBrowserDialog = new())
			{
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
					textBox2_OutputFolder.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void OptionSelector(object? sender, EventArgs e)
		{
			CheckBox? checkBox = sender as CheckBox;

			if (checkBox == checkBox6_UpdateAll && checkBox6_UpdateAll.Checked && checkBox7_AdditionalDate.Checked)
				checkBox7_AdditionalDate.Checked = false;

			if (checkBox == checkBox7_AdditionalDate && checkBox7_AdditionalDate.Checked && checkBox6_UpdateAll.Checked)
				checkBox6_UpdateAll.Checked = false;

			if (checkBox7_AdditionalDate.Checked)
				textBox7_AdditionalDate.Enabled = true;
			else
				textBox7_AdditionalDate.Enabled = false;
		}

		private void Update(object? sender, DoWorkEventArgs e)
		{
			DirectoryInfo directoryInfo_Input, directoryInfo_OutputCopy, directoryInfo_OutputNew;
			FileInfo[] fileInfoArray;
			DateOnly limitDate, currentDate;
			DateOnly additionalDate = new();

			try
			{
				if (!(DateOnly.TryParseExact(textBox3_CurrentDate.Text.Trim(), "dd.MM.yyyy", out currentDate)))
					throw new Exception("Недопустимая текущая дата!");

				if (!(DateOnly.TryParseExact(textBox5_LimitDate.Text.Trim(), "dd.MM.yyyy", out limitDate)))
					throw new Exception("Недопустимая основная дата!");

				if (checkBox7_AdditionalDate.Checked && !(DateOnly.TryParseExact(textBox7_AdditionalDate.Text.Trim(), "dd.MM.yyyy", out additionalDate)))
					throw new Exception("Недопустимая дополнительная дата!");

				if (string.IsNullOrWhiteSpace(textBox4_CurrentSurname.Text))
					throw new Exception("Поле текущей фамилии не может быть пустым!");

				directoryInfo_Input = new(textBox1_InputFolder.Text);
				directoryInfo_OutputCopy = new(textBox2_OutputFolder.Text + @"\" + _outputCopyFolderName);
				directoryInfo_OutputNew = new(textBox2_OutputFolder.Text + @"\" + _outputNewFolderName);

				fileInfoArray = directoryInfo_Input.GetFiles();

				if (directoryInfo_OutputCopy.Exists)
					directoryInfo_OutputCopy.Delete(true);

				directoryInfo_OutputCopy.Create();

				if (directoryInfo_OutputNew.Exists)
					directoryInfo_OutputNew.Delete(true);

				directoryInfo_OutputNew.Create();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Result = null;
				return;
			}

			StringBuilder errorSB = new();

			List<FileInfo> marckedFiles = GetFilesToUpdate(fileInfoArray, limitDate, errorSB);

			if (marckedFiles.Count == 0)
			{
				MessageBox.Show("Нет файлов для обновления!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				e.Result = null;
				return;
			}

			foreach (FileInfo fileInfo in marckedFiles)
				fileInfo.CopyTo(directoryInfo_OutputCopy.FullName + @"\" + fileInfo.Name);

			directoryInfo_OutputCopy.Refresh();

			GC.Collect();
			GC.WaitForPendingFinalizers();

			try
			{
				fileInfoArray = directoryInfo_OutputCopy.GetFiles();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Result = null;
				return;
			}

			UnitOfTaskScheduler taskScheduler = new(fileInfoArray);

			string currentDateStr = textBox3_CurrentDate.Text.Trim();
			string currentSurname = textBox4_CurrentSurname.Text.Trim();
			bool updateAll = checkBox6_UpdateAll.Checked;

			if (checkBox7_AdditionalDate.Checked && additionalDate > limitDate)
				limitDate = additionalDate;

			DataCarrier dataCarrier = new(currentDateStr, currentSurname, limitDate, updateAll, directoryInfo_OutputNew.FullName, taskScheduler);

			Task task1 = Task.Factory.StartNew(RunUpdateTask, dataCarrier);
			Task task2 = Task.Factory.StartNew(RunUpdateTask, dataCarrier);
			Task task3 = Task.Factory.StartNew(RunUpdateTask, dataCarrier);

			Task.WaitAll(task1, task2, task3);

			foreach (StringBuilder sb in dataCarrier.ErrorSBList)
				if (sb.Length > 0)
					errorSB.AppendLine(sb.ToString());

			e.Result = errorSB;
		}

		private void UpdateFinalization(object? sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Result == null)
			{
				SetControlState(true);
				textBox0_Answer.Clear();
			}
			else
			{
				string text = "Обновление дат завершено";

				PrintResult(text, (StringBuilder)e.Result);

				SetControlState(true);
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
		#endregion



		#region Methods
		private void SetControlState(bool state)
		{
			groupBox1_InputFolder.Enabled = state;
			groupBox2_OutputFolder.Enabled = state;
			groupBox3_CurrentDate.Enabled = state;
			groupBox4_CurrentSurname.Enabled = state;
			groupBox5_LimitDate.Enabled = state;
			groupBox6_UpdateAll.Enabled = state;
			groupBox7_AdditionalDate.Enabled = state;

			button0_Update.Enabled = state;
		}

		private void PrintResult(string text, StringBuilder? errorSB = null)
		{
			textBox0_Answer.Text = Environment.NewLine
								 + text;

			if (errorSB != null && errorSB.Length > 0)
				textBox0_Answer.Text += Environment.NewLine
									 + Environment.NewLine
									 + "=== ERRORS ===========================================================================" + Environment.NewLine
									 + Environment.NewLine
									 + errorSB.ToString();

			textBox0_Answer.Text += Environment.NewLine;
			textBox0_Answer.Select(0, 0);
		}

		private static List<FileInfo> GetFilesToUpdate(FileInfo[] fileInfoArray, DateOnly limitDate, StringBuilder errorSB)
		{
			List<FileInfo> marckedFiles = new();
			DateOnly readDate;
			IWorkbook workbook;
			ISheet sheet;
			IRow row;
			ICell cellDate;

			foreach (FileInfo fileInfo in fileInfoArray)
			{
				if (fileInfo.Name.EndsWith(".xlsx", true, null))
				{
					try
					{
						using (FileStream fs = new(fileInfo.FullName, FileMode.Open, FileAccess.Read))
						{
							workbook = new XSSFWorkbook(fs, true);
						}
					}
					catch (Exception ex)
					{
						try
						{
							errorSB.AppendLine(fileInfo.FullName + Environment.NewLine + ex.Message + Environment.NewLine);
						}
						catch
						{
							errorSB.AppendLine(ex.Message + Environment.NewLine);
						}

						continue;
					}
				}
				else if (fileInfo.Name.EndsWith(".xls", true, null))
				{
					errorSB.AppendLine(fileInfo.FullName + Environment.NewLine + "Файлы .xls не поддерживаются! Только .xlsx" + Environment.NewLine);
					continue;
				}
				else
					continue;

				sheet = workbook.GetSheetAt(0);

				for (int i = 7; i < sheet.LastRowNum + 1; i++)
				{
					row = sheet.GetRow(i);

					if (row != null)
						cellDate = row.GetCell(7);
					else
						continue;

					if (cellDate != null)
					{
						try
						{
							if (string.IsNullOrWhiteSpace(cellDate.StringCellValue))
								continue;
							else
							{
								bool isParsed = DateOnly.TryParseExact(cellDate.StringCellValue.Trim(), "dd.MM.yyyy", out readDate);

								if (!isParsed)
								{
									errorSB.AppendLine($"Недопустимая дата на строке: {i + 1} в файле: {fileInfo.FullName}" + Environment.NewLine);
									continue;
								}
								else if (readDate < limitDate)
								{
									marckedFiles.Add(fileInfo);
									break;
								}
							}
						}
						catch (Exception ex)
						{
							errorSB.AppendLine(ex.Message + Environment.NewLine + $"! Ошибка на строке: {i + 1} в файле: {fileInfo.FullName}" + Environment.NewLine);
							continue;
						}
					}
				}
			}

			return marckedFiles;
		}

		private static void RunUpdateTask(object? dataCarrierObject)
		{
			if (dataCarrierObject == null)
				return;

			DataCarrier dataCarrier = (DataCarrier)dataCarrierObject;
			UnitOfTaskScheduler taskScheduler = dataCarrier.TaskScheduler;

			FileInfo? fileInfo = taskScheduler.GetFile();

			StringBuilder errorSB = new();
			IWorkbook workbook;
			ISheet sheet;
			IRow row;
			ICell cellDate, cellSurname;
			DateOnly readDate;
			DateOnly limitDate = dataCarrier.LimitDate;
			string currentDate = dataCarrier.CurrentDate;
			string currentSurname = dataCarrier.CurrentSurname;

			while (fileInfo != null)
			{
				try
				{
					using (FileStream fs = new(fileInfo.FullName, FileMode.Open, FileAccess.ReadWrite))
					{
						workbook = new XSSFWorkbook(fs, false);
					}
				}
				catch (Exception ex)
				{
					string fileName;

					try
					{
						fileName = fileInfo.FullName;
					}
					catch
					{
						fileName = string.Empty;
					}

					errorSB.AppendLine($"Не удалось открыть файл: {fileName}" + Environment.NewLine + ex.Message + Environment.NewLine);
					continue;
				}

				sheet = workbook.GetSheetAt(0);
				sheet.DefaultRowHeight = 255;

				for (int rowIndex = 7; rowIndex < sheet.LastRowNum + 1; rowIndex++)
				{
					row = sheet.GetRow(rowIndex);

					if (row != null)
						cellDate = row.GetCell(7);
					else
						continue;

					if (cellDate != null)
					{
						try
						{
							if (string.IsNullOrWhiteSpace(cellDate.StringCellValue))
								continue;
							else if (dataCarrier.UpdateAll)
							{
								cellDate.SetCellValue(dataCarrier.CurrentDate);
								cellSurname = row.GetCell(6);
								cellSurname.SetCellValue(dataCarrier.CurrentSurname);
							}
							else
							{
								bool isParsed = DateOnly.TryParseExact(cellDate.StringCellValue.Trim(), "dd.MM.yyyy", out readDate);

								if (!isParsed)
								{
									errorSB.AppendLine($"Недопустимая дата на строке: {rowIndex + 1} в файле: {fileInfo.FullName}" + Environment.NewLine);
									continue;
								}
								else if (readDate < limitDate)
								{
									cellDate.SetCellValue(currentDate);
									cellSurname = row.GetCell(6);
									cellSurname.SetCellValue(currentSurname);
								}
							}
						}
						catch (Exception ex)
						{
							errorSB.AppendLine(ex.Message + Environment.NewLine + $"! Ошибка на строке: {rowIndex + 1} в файле: {fileInfo.FullName}" + Environment.NewLine);
							continue;
						}
					}
				}

				for (int rowIndex = 0; rowIndex < sheet.LastRowNum + 1; rowIndex++)
				{
					row = sheet.GetRow(rowIndex);

					if (row != null)
					{
						row.Height = rowIndex switch
						{
							0 => 255,
							1 => 255,
							2 => 375,
							3 => 375,
							4 => 255,
							5 => 1020,
							6 => 255,
							_ => 255,
						};
					}
				}

				try
				{
					using (FileStream fs = new(dataCarrier.OutputNew_FullName + @"\" + fileInfo.Name, FileMode.Create, FileAccess.Write))
					{
						workbook.Write(fs);
					}
				}
				catch (Exception ex)
				{
					try
					{
						errorSB.AppendLine(fileInfo.FullName + Environment.NewLine + ex.Message + Environment.NewLine);
					}
					catch
					{
						errorSB.AppendLine(dataCarrier.OutputNew_FullName + Environment.NewLine + ex.Message + Environment.NewLine);
					}
				}

				fileInfo = taskScheduler.GetFile();
			}

			dataCarrier.AddErrorSB(errorSB);
		}
		#endregion
	}
}
