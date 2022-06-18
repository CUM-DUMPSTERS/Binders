using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using KyaniteBinder.Properties;
using Microsoft.CSharp;

namespace KyaniteBinder
{
	public partial class Form1 : Form
	{
		[DllImport("user32")]
		private static extern bool ReleaseCapture();
		[DllImport("user32")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, int wp, int lp);
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
		public Form1()
		{
			this.InitializeComponent();
		}
		private void guna2Panel3_Paint(object sender, PaintEventArgs e) {}
		private void Form1_Load(object sender, EventArgs e)
		{
			base.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, base.Width, base.Height, 10, 10));
			new Guna2ShadowForm(this).ShadowColor = Color.FromArgb(130, 68, 255);
		}

		private void guna2Panel3_MouseDown(object sender, MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			this.fileList.Items.Add(this.openFileDialog1.FileName);
		}

		private void guna2Button5_Click(object sender, EventArgs e)
		{
			this.compilerPanel.BringToFront();
		}

		public void Compile()
		{
			string text = "";
			ResourceWriter resourceWriter = new ResourceWriter("Binded.Resources");
			foreach (object obj in this.fileList.Items)
			{
				FileInfo fileInfo = new FileInfo((string)obj);
				string name = fileInfo.Name;
				string text2 = name + "Resource";
				string text3 = Resources.ExtraCode.Replace("[FILENAME]", name);
				text3 = text3.Replace("[RESOURCENAME]", text2);
				text += text3;
				resourceWriter.AddResource(text2, File.ReadAllBytes(fileInfo.FullName));
			}
			resourceWriter.Close();
			string text4 = Resources.MainCode.Replace("[DROPCODE]", text);
			CompilerParameters compilerParameters = new CompilerParameters();
			compilerParameters.GenerateExecutable = true;
			compilerParameters.OutputAssembly = this.filenameTxt.Text + ".exe";
			compilerParameters.CompilerOptions = "/target:winexe";
			compilerParameters.EmbeddedResources.Add("Binded.Resources");
			compilerParameters.ReferencedAssemblies.Add("System.dll");
			CompilerResults compilerResults = new CSharpCodeProvider().CompileAssemblyFromSource(compilerParameters, new string[]
			{
				text4
			});
			File.Delete("Binded.Resources");
			if (compilerResults.Errors.Count > 0)
			{
				foreach (object obj2 in compilerResults.Errors)
				{
					MessageBox.Show(((CompilerError)obj2).ToString());
				}
			}
			if (!string.IsNullOrEmpty(this.iconPath))
			{
				compilerParameters.CompilerOptions = string.Format("/target:winexe /win32icon:{0}", this.iconPath);
			}
		}

		private void guna2Button6_Click(object sender, EventArgs e)
		{
			this.resultsTxt.Clear();
			TextBox textBox = this.resultsTxt;
			textBox.Text += "Compiling...\n";
			this.Compile();
		}

		private void compilerPanel_Paint(object sender, PaintEventArgs e)
		{
		}

		private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
		{
			this.iconPath = this.openFileDialog2.FileName;
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.fileList.Items.RemoveAt(this.fileList.SelectedIndex);
		}

		private void guna2Button3_Click(object sender, EventArgs e)
		{
			this.fileList.Items.Clear();
		}

		private void guna2Button4_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Fixing This Soon, Use an ICON Changer Off of githhub For Now", "D:");
		}

		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			this.openFileDialog1.ShowDialog();
		}

		private void guna2Button7_Click(object sender, EventArgs e)
		{
			this.builderPanel.BringToFront();
		}
		private string iconPath = "";
	}
}
