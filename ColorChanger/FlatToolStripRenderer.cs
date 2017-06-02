using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorChanger.Controls
{
	class FlatToolStripRenderer : ToolStripSystemRenderer
	{
		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			// Removes the 2-pixel white line from toolstrip:
			// base.OnRenderToolStripBorder(e);
		}
	}
}
