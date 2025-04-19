using System.Drawing;
using System.Windows.Forms;

namespace UpdatingDateApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			groupBox1_InputFolder = new GroupBox();
			button1_InputFolder = new Button();
			textBox1_InputFolder = new TextBox();
			groupBox3_CurrentDate = new GroupBox();
			textBox3_CurrentDate = new TextBox();
			groupBox4_CurrentSurname = new GroupBox();
			textBox4_CurrentSurname = new TextBox();
			textBox0_Answer = new TextBox();
			button0_Update = new Button();
			groupBox2_OutputFolder = new GroupBox();
			button2_OutputFolder = new Button();
			textBox2_OutputFolder = new TextBox();
			groupBox5_LimitDate = new GroupBox();
			textBox5_LimitDate = new TextBox();
			groupBox6_UpdateAll = new GroupBox();
			checkBox6_UpdateAll = new CheckBox();
			backgroundWorker0 = new System.ComponentModel.BackgroundWorker();
			groupBox7_AdditionalDate = new GroupBox();
			checkBox7_AdditionalDate = new CheckBox();
			textBox7_AdditionalDate = new TextBox();
			groupBox1_InputFolder.SuspendLayout();
			groupBox3_CurrentDate.SuspendLayout();
			groupBox4_CurrentSurname.SuspendLayout();
			groupBox2_OutputFolder.SuspendLayout();
			groupBox5_LimitDate.SuspendLayout();
			groupBox6_UpdateAll.SuspendLayout();
			groupBox7_AdditionalDate.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1_InputFolder
			// 
			groupBox1_InputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1_InputFolder.Controls.Add(button1_InputFolder);
			groupBox1_InputFolder.Controls.Add(textBox1_InputFolder);
			groupBox1_InputFolder.Location = new Point(15, 15);
			groupBox1_InputFolder.Name = "groupBox1_InputFolder";
			groupBox1_InputFolder.Size = new Size(855, 75);
			groupBox1_InputFolder.TabIndex = 0;
			groupBox1_InputFolder.TabStop = false;
			groupBox1_InputFolder.Text = "Выбор папки с файлами для обновления";
			// 
			// button1_InputFolder
			// 
			button1_InputFolder.Location = new Point(15, 30);
			button1_InputFolder.Name = "button1_InputFolder";
			button1_InputFolder.Size = new Size(120, 30);
			button1_InputFolder.TabIndex = 1;
			button1_InputFolder.Text = "Выбрать";
			button1_InputFolder.UseVisualStyleBackColor = true;
			// 
			// textBox1_InputFolder
			// 
			textBox1_InputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox1_InputFolder.BorderStyle = BorderStyle.None;
			textBox1_InputFolder.Location = new Point(150, 35);
			textBox1_InputFolder.Name = "textBox1_InputFolder";
			textBox1_InputFolder.Size = new Size(690, 19);
			textBox1_InputFolder.TabIndex = 0;
			textBox1_InputFolder.WordWrap = false;
			// 
			// groupBox3_CurrentDate
			// 
			groupBox3_CurrentDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox3_CurrentDate.Controls.Add(textBox3_CurrentDate);
			groupBox3_CurrentDate.Location = new Point(15, 215);
			groupBox3_CurrentDate.Name = "groupBox3_CurrentDate";
			groupBox3_CurrentDate.Size = new Size(420, 75);
			groupBox3_CurrentDate.TabIndex = 1;
			groupBox3_CurrentDate.TabStop = false;
			groupBox3_CurrentDate.Text = "Ввод текущей даты: \"DD.MM.YYYY\"";
			// 
			// textBox3_CurrentDate
			// 
			textBox3_CurrentDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox3_CurrentDate.BorderStyle = BorderStyle.None;
			textBox3_CurrentDate.Location = new Point(15, 35);
			textBox3_CurrentDate.Name = "textBox3_CurrentDate";
			textBox3_CurrentDate.Size = new Size(390, 19);
			textBox3_CurrentDate.TabIndex = 0;
			textBox3_CurrentDate.WordWrap = false;
			// 
			// groupBox4_CurrentSurname
			// 
			groupBox4_CurrentSurname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox4_CurrentSurname.Controls.Add(textBox4_CurrentSurname);
			groupBox4_CurrentSurname.Location = new Point(15, 415);
			groupBox4_CurrentSurname.Name = "groupBox4_CurrentSurname";
			groupBox4_CurrentSurname.Size = new Size(420, 75);
			groupBox4_CurrentSurname.TabIndex = 2;
			groupBox4_CurrentSurname.TabStop = false;
			groupBox4_CurrentSurname.Text = "Текущая фамилия";
			// 
			// textBox4_CurrentSurname
			// 
			textBox4_CurrentSurname.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox4_CurrentSurname.BorderStyle = BorderStyle.None;
			textBox4_CurrentSurname.Location = new Point(15, 35);
			textBox4_CurrentSurname.Name = "textBox4_CurrentSurname";
			textBox4_CurrentSurname.Size = new Size(390, 19);
			textBox4_CurrentSurname.TabIndex = 0;
			textBox4_CurrentSurname.WordWrap = false;
			// 
			// textBox0_Answer
			// 
			textBox0_Answer.Anchor = AnchorStyles.None;
			textBox0_Answer.BorderStyle = BorderStyle.None;
			textBox0_Answer.Location = new Point(15, 515);
			textBox0_Answer.MaximumSize = new Size(855, 325);
			textBox0_Answer.MinimumSize = new Size(855, 325);
			textBox0_Answer.Multiline = true;
			textBox0_Answer.Name = "textBox0_Answer";
			textBox0_Answer.ScrollBars = ScrollBars.Vertical;
			textBox0_Answer.Size = new Size(855, 325);
			textBox0_Answer.TabIndex = 3;
			// 
			// button0_Update
			// 
			button0_Update.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			button0_Update.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
			button0_Update.Location = new Point(730, 415);
			button0_Update.Name = "button0_Update";
			button0_Update.Size = new Size(140, 75);
			button0_Update.TabIndex = 4;
			button0_Update.Text = "ОБНОВИТЬ";
			button0_Update.UseVisualStyleBackColor = true;
			// 
			// groupBox2_OutputFolder
			// 
			groupBox2_OutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2_OutputFolder.Controls.Add(button2_OutputFolder);
			groupBox2_OutputFolder.Controls.Add(textBox2_OutputFolder);
			groupBox2_OutputFolder.Location = new Point(15, 115);
			groupBox2_OutputFolder.Name = "groupBox2_OutputFolder";
			groupBox2_OutputFolder.Size = new Size(855, 75);
			groupBox2_OutputFolder.TabIndex = 5;
			groupBox2_OutputFolder.TabStop = false;
			groupBox2_OutputFolder.Text = "Выбор папки для сохранения результатов обновления";
			// 
			// button2_OutputFolder
			// 
			button2_OutputFolder.Location = new Point(15, 30);
			button2_OutputFolder.Name = "button2_OutputFolder";
			button2_OutputFolder.Size = new Size(120, 30);
			button2_OutputFolder.TabIndex = 1;
			button2_OutputFolder.Text = "Выбрать";
			button2_OutputFolder.UseVisualStyleBackColor = true;
			// 
			// textBox2_OutputFolder
			// 
			textBox2_OutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox2_OutputFolder.BorderStyle = BorderStyle.None;
			textBox2_OutputFolder.Location = new Point(150, 35);
			textBox2_OutputFolder.Name = "textBox2_OutputFolder";
			textBox2_OutputFolder.Size = new Size(690, 19);
			textBox2_OutputFolder.TabIndex = 0;
			textBox2_OutputFolder.WordWrap = false;
			// 
			// groupBox5_LimitDate
			// 
			groupBox5_LimitDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox5_LimitDate.Controls.Add(textBox5_LimitDate);
			groupBox5_LimitDate.Location = new Point(450, 215);
			groupBox5_LimitDate.Name = "groupBox5_LimitDate";
			groupBox5_LimitDate.Size = new Size(420, 75);
			groupBox5_LimitDate.TabIndex = 8;
			groupBox5_LimitDate.TabStop = false;
			groupBox5_LimitDate.Text = "Обновить только даты до: \"DD.MM.YYYY\"";
			// 
			// textBox5_LimitDate
			// 
			textBox5_LimitDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox5_LimitDate.BorderStyle = BorderStyle.None;
			textBox5_LimitDate.Location = new Point(15, 35);
			textBox5_LimitDate.Name = "textBox5_LimitDate";
			textBox5_LimitDate.Size = new Size(390, 19);
			textBox5_LimitDate.TabIndex = 0;
			textBox5_LimitDate.WordWrap = false;
			// 
			// groupBox6_UpdateAll
			// 
			groupBox6_UpdateAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox6_UpdateAll.Controls.Add(checkBox6_UpdateAll);
			groupBox6_UpdateAll.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
			groupBox6_UpdateAll.Location = new Point(450, 415);
			groupBox6_UpdateAll.Name = "groupBox6_UpdateAll";
			groupBox6_UpdateAll.Size = new Size(265, 75);
			groupBox6_UpdateAll.TabIndex = 9;
			groupBox6_UpdateAll.TabStop = false;
			groupBox6_UpdateAll.Text = "Обновить все даты в файле если есть хотя бы одна старая";
			// 
			// checkBox6_UpdateAll
			// 
			checkBox6_UpdateAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			checkBox6_UpdateAll.AutoSize = true;
			checkBox6_UpdateAll.Location = new Point(124, 45);
			checkBox6_UpdateAll.Name = "checkBox6_UpdateAll";
			checkBox6_UpdateAll.Size = new Size(15, 14);
			checkBox6_UpdateAll.TabIndex = 0;
			checkBox6_UpdateAll.UseVisualStyleBackColor = true;
			// 
			// groupBox7_AdditionalDate
			// 
			groupBox7_AdditionalDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox7_AdditionalDate.Controls.Add(checkBox7_AdditionalDate);
			groupBox7_AdditionalDate.Controls.Add(textBox7_AdditionalDate);
			groupBox7_AdditionalDate.Location = new Point(15, 315);
			groupBox7_AdditionalDate.Name = "groupBox7_AdditionalDate";
			groupBox7_AdditionalDate.Size = new Size(855, 75);
			groupBox7_AdditionalDate.TabIndex = 10;
			groupBox7_AdditionalDate.TabStop = false;
			groupBox7_AdditionalDate.Text = "Если есть хотя бы одна старая дата, также обновить все даты до: \"DD.MM.YYYY\"";
			// 
			// checkBox7_AdditionalDate
			// 
			checkBox7_AdditionalDate.AutoSize = true;
			checkBox7_AdditionalDate.Location = new Point(15, 39);
			checkBox7_AdditionalDate.Name = "checkBox7_AdditionalDate";
			checkBox7_AdditionalDate.Size = new Size(15, 14);
			checkBox7_AdditionalDate.TabIndex = 1;
			checkBox7_AdditionalDate.UseVisualStyleBackColor = true;
			// 
			// textBox7_AdditionalDate
			// 
			textBox7_AdditionalDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBox7_AdditionalDate.BorderStyle = BorderStyle.None;
			textBox7_AdditionalDate.Enabled = false;
			textBox7_AdditionalDate.Location = new Point(45, 35);
			textBox7_AdditionalDate.Name = "textBox7_AdditionalDate";
			textBox7_AdditionalDate.Size = new Size(795, 19);
			textBox7_AdditionalDate.TabIndex = 0;
			textBox7_AdditionalDate.WordWrap = false;
			// 
			// Form1
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(884, 861);
			Controls.Add(groupBox7_AdditionalDate);
			Controls.Add(groupBox6_UpdateAll);
			Controls.Add(groupBox5_LimitDate);
			Controls.Add(groupBox2_OutputFolder);
			Controls.Add(button0_Update);
			Controls.Add(textBox0_Answer);
			Controls.Add(groupBox4_CurrentSurname);
			Controls.Add(groupBox3_CurrentDate);
			Controls.Add(groupBox1_InputFolder);
			Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
			MaximizeBox = false;
			MaximumSize = new Size(900, 900);
			MinimumSize = new Size(900, 900);
			Name = "Form1";
			Text = "Программа обновления дат";
			groupBox1_InputFolder.ResumeLayout(false);
			groupBox1_InputFolder.PerformLayout();
			groupBox3_CurrentDate.ResumeLayout(false);
			groupBox3_CurrentDate.PerformLayout();
			groupBox4_CurrentSurname.ResumeLayout(false);
			groupBox4_CurrentSurname.PerformLayout();
			groupBox2_OutputFolder.ResumeLayout(false);
			groupBox2_OutputFolder.PerformLayout();
			groupBox5_LimitDate.ResumeLayout(false);
			groupBox5_LimitDate.PerformLayout();
			groupBox6_UpdateAll.ResumeLayout(false);
			groupBox6_UpdateAll.PerformLayout();
			groupBox7_AdditionalDate.ResumeLayout(false);
			groupBox7_AdditionalDate.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBox1_InputFolder;
		private Button button1_InputFolder;
		private TextBox textBox1_InputFolder;
		private GroupBox groupBox3_CurrentDate;
		private TextBox textBox3_CurrentDate;
		private GroupBox groupBox4_CurrentSurname;
		private TextBox textBox4_CurrentSurname;
		private TextBox textBox0_Answer;
		private Button button0_Update;
		private GroupBox groupBox2_OutputFolder;
		private Button button2_OutputFolder;
		private TextBox textBox2_OutputFolder;
		private GroupBox groupBox5_LimitDate;
		private TextBox textBox5_LimitDate;
		private GroupBox groupBox6_UpdateAll;
		private CheckBox checkBox6_UpdateAll;
		private System.ComponentModel.BackgroundWorker backgroundWorker0;
		private GroupBox groupBox7_AdditionalDate;
		private TextBox textBox7_AdditionalDate;
		private CheckBox checkBox7_AdditionalDate;
	}
}
