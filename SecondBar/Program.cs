﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondBar {
	static class Program {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) {
            int? monitorIndex = null;
            if (args.Length > 0) {
                int tmp;
                if (int.TryParse(args[0], out tmp)) {
                    monitorIndex = tmp;
                }
            }

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(monitorIndex));
		}
	}
}
