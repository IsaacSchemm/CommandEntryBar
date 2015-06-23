using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkAreaUtilityLib;

namespace WorkAreaUtility {
	public partial class WorkAreaEditorForm : Form {
		private HMonitor currentMonitor;

		public WorkAreaEditorForm() {
			InitializeComponent();

			monitorsListBox.Items.AddRange(HMonitor.GetAllScreens());

			numTop.LostFocus += (o, e) => pnlPreview.Invalidate();
			numLeft.LostFocus += (o, e) => pnlPreview.Invalidate();
			numRight.LostFocus += (o, e) => pnlPreview.Invalidate();
			numBottom.LostFocus += (o, e) => pnlPreview.Invalidate();

			pnlPreview.Paint += pnlPreview_Paint;
		}

		void pnlPreview_Paint(object sender, PaintEventArgs e) {
			e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, pnlPreview.Width, pnlPreview.Height);
			if (currentMonitor == null) return;

			int top = (int)(numTop.Value * pnlPreview.Height / currentMonitor.Height);
			int bottom = (int)(numBottom.Value * pnlPreview.Height / currentMonitor.Height);
			int left = (int)(numLeft.Value * pnlPreview.Width / currentMonitor.Width);
			int right = (int)(numRight.Value * pnlPreview.Width / currentMonitor.Width);

			Brush brush = new SolidBrush(Color.DarkBlue);
			if (top > 0) e.Graphics.FillRectangle(brush, 0, 0, pnlPreview.Width, top);
			if (bottom > 0) e.Graphics.FillRectangle(brush, 0, pnlPreview.Height - bottom, pnlPreview.Width, bottom);
			if (left > 0) e.Graphics.FillRectangle(brush, 0, 0, left, pnlPreview.Height);
			if (right > 0) e.Graphics.FillRectangle(brush, pnlPreview.Width - right, 0, pnlPreview.Height - right, pnlPreview.Height);
		}

		private void monitorsListBox_SelectedIndexChanged(object sender, EventArgs e) {
			currentMonitor = (HMonitor)monitorsListBox.SelectedItem;

			Padding r = currentMonitor.WorkAreaPadding;
			numTop.Value = r.Top;
			numLeft.Value = r.Left;
			numRight.Value = r.Right;
			numBottom.Value = r.Bottom;

			pnlPreview.Invalidate();
		}

		private void btnApply_Click(object sender, EventArgs e) {
			Padding r = new Padding((int)numTop.Value, (int)numTop.Value, (int)numRight.Value, (int)numBottom.Value);
			currentMonitor.SetWorkAreaPadding(r);
			monitorsListBox_SelectedIndexChanged(monitorsListBox, null);
		}
	}
}
