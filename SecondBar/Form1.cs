﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkAreaUtilityLib;

namespace SecondBar {
	public partial class Form1 : Form {
		private Rectangle oldWorkArea, newWorkArea;
		private HMonitor monitor;
		private int origHeight;

		public Form1() {
			InitializeComponent();
			Shown += Form1_Shown;
			FormClosed += Form1_FormClosed;
			origHeight = this.Height;
		}

		void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			if (monitor.WorkArea == newWorkArea) {
				monitor.SetWorkArea(oldWorkArea);
			}
		}

		void Form1_Shown(object sender, EventArgs e) {
			HMonitor[] monitors = HMonitor.GetAllScreens();
			monitor = monitors[0];
			oldWorkArea = newWorkArea = monitor.WorkArea;
			this.Height = origHeight;
			newWorkArea.Height -= this.Height;
			this.Location = new Point(newWorkArea.Left, newWorkArea.Bottom);
			this.Width = monitor.Width;

			monitor.SetWorkArea(newWorkArea);
		}

		private void btnClose_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void panel1_Click(object sender, EventArgs e) {
			textBox1.Focus();
		}

		void p_Exited(object sender, EventArgs e) {
			Process p = (Process)sender;
			MessageBox.Show(p.ExitCode.ToString());
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar == '\r' || e.KeyChar == '\n') {
				e.Handled = true;
				try {
					string text = textBox1.Text;
					if (text.Length == 0) return;
					if (text[0] == '\\' || text[0] == '!') {
						text = "https://duckduckgo.com/?q=" + WebUtility.UrlEncode(text);
					}
					Process p = Process.Start(text);
					textBox1.Text = "";
					if (p != null) {
						p.EnableRaisingEvents = true;
						p.Exited += p_Exited;
					}
				} catch (Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
		}
	}
}
