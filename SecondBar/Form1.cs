using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkAreaUtilityLib;

namespace SecondBar {
	public partial class Form1 : Form {
		private Rectangle oldWorkArea, newWorkArea;
        private HMonitor[] monitors;
        private int monitorIndex;
		private int origHeight;

        private LinkedList<string> history = new LinkedList<string>();
        private LinkedListNode<string> historyNode = null;

        private HMonitor monitor {
            get {
                return monitors[monitorIndex];
            }
        }

		public Form1() {
			InitializeComponent();
			Shown += Form1_Shown;
			FormClosed += Form1_FormClosed;
			origHeight = this.Height;

            try {
                foreach (string s in File.ReadAllLines("history.txt").Take(10)) {
                    history.AddLast(s);
                }
            } catch (Exception) { }
		}

		void Form1_Shown(object sender, EventArgs e) {
			monitors = HMonitor.GetAllScreens();
			oldWorkArea = newWorkArea = monitor.WorkArea;
			this.Height = origHeight;
			newWorkArea.Height -= this.Height;
			this.Location = new Point(newWorkArea.Left, newWorkArea.Bottom);
			this.Width = monitor.Width;

			monitor.SetWorkArea(newWorkArea);
		}

		private void panel1_Click(object sender, EventArgs e) {
			textBox1.Focus();
		}

		void p_Exited(object sender, EventArgs e) {
			Process p = (Process)sender;
		}

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            lock (history) {
                if (e.KeyCode == Keys.Enter) {
                    e.Handled = e.SuppressKeyPress = true;
				    try {
					    string text = textBox1.Text;
					    if (text.Length == 0) return;
					    if (text[0] == '\\' || text[0] == '!') {
						    text = "https://duckduckgo.com/?q=" + WebUtility.UrlEncode(text);
					    }

                        string[] split = SplitOnce(text);
					    Process p = Process.Start(split[0], split[1]);
                        if (text != history.First.Value) {
                            if (history.Count >= 10) history.RemoveLast();
                            history.AddFirst(text);
                        }
                        historyNode = null;
					    textBox1.Text = "";
					    if (p != null) {
						    p.EnableRaisingEvents = true;
						    p.Exited += p_Exited;
					    }
				    } catch (Exception ex) {
					    MessageBox.Show(ex.Message);
				    }
                } else if (e.KeyCode == Keys.Up) {
                    e.Handled = e.SuppressKeyPress = true;
                    if (historyNode == null) {
                        historyNode = history.First;
                    } else {
                        historyNode = historyNode.Next;
                    }
                    if (historyNode == null) {
                        textBox1.Text = "";
                    } else {
                        textBox1.Text = historyNode.Value;
                    }
                } else if (e.KeyCode == Keys.Down) {
                    e.Handled = e.SuppressKeyPress = true;
                    if (historyNode == null) {
                        historyNode = history.Last;
                    } else {
                        historyNode = historyNode.Previous;
                    }
                    if (historyNode == null) {
                        textBox1.Text = "";
                    } else {
                        textBox1.Text = historyNode.Value;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                File.WriteAllLines("history.txt", history.ToArray());
            } catch (Exception) { }

            if (monitor.WorkArea == newWorkArea) {
                monitor.SetWorkArea(oldWorkArea);
            }
        }

        /// <summary>
        /// http://stackoverflow.com/questions/298830/split-string-containing-command-line-parameters-into-string-in-c-sharp
        /// </summary>
        public static string[] SplitOnce(string str) {
            bool inQuotes = false;

            for (int c = 0; c < str.Length; c++) {
                if (str[c] == '"') inQuotes = !inQuotes;
                if (!inQuotes && str[c] == ' ') {
                    return new string[] { str.Substring(0, c), str.Substring(c + 1) };
                }
            }

            return new string[] { str, null };
        }
	}
}
