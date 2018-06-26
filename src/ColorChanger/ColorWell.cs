using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ColorChanger.Controls
{
	/* TODO:
	 *		- Add support for multiple selections.
	 *		- Draw properly-styled border from visual style.
	 *		- Add drag-n-drop support for moving color tiles around.
	 */

	class ColorWell : FlowLayoutPanel
	{
		private const string DEFAULT_PLACEHOLDER_TEXT = "Feed me colors!";
		private const int TILE_PADDING = 6;

		private ColorTile activeItem = null;
		private ColorTile selectedItem = null;
		private int activeIndex = -1;
		private int selectedIndex = -1;
		private Size itemSize = new Size(64, 64);
		private bool uniqueOnly = true;
		private string placeholderText = DEFAULT_PLACEHOLDER_TEXT;
		private ToolTip tooltip = new ToolTip();

		public event EventHandler ActiveItemChanged;
		public event EventHandler SelectionChanged;

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		private ColorTile SelectedItem
		{
			get { return GetSelectedColorBox(); }
			set
			{
				if (this.selectedItem != value)
				{
					SetSelectedColorTile(value);
					this.Refresh();
				}
			}
		}

		[Browsable(true)]
		[Description("Determines the size of the tiles contained within the well.")]
		[DefaultValue(typeof(Size), "64, 64")]
		public Size ItemSize
		{
			get { return this.itemSize; }
			set { this.itemSize = value; }
		}

		/// <summary>
		/// Gets or sets the selected ColorBox control based on index. Set to -1 to clear the control's selection.
		/// </summary>
		[Browsable(false)]
		public int SelectedIndex
		{
			get { return this.selectedIndex; }
			set
			{
				if (this.selectedIndex != value)
				{
					SetSelectedColorTile(value);
					this.Refresh();
				}
			}
		}

		/// <summary>
		/// Gets or sets the selected ColorBox control based on index. Set to -1 to clear the control's selection.
		/// </summary>
		[Browsable(false)]
		public int ActiveIndex
		{
			get { return this.activeIndex; }
			set
			{
				if (this.activeIndex != value)
				{
					SetActiveColorTile(value);
					this.Refresh();
				}
			}
		}

		[Browsable(true)]
		[Description("Determines whether duplicate colors are able to be added to the well.")]
		[DefaultValue(true)]
		public bool UniqueOnly
		{
			get { return this.uniqueOnly; }
			set { this.uniqueOnly = value; }
		}

		[Browsable(true)]
		[Description("The text that is displayed when there are no items in the well.")]
		[DefaultValue("Add some colors!")]
		public string PlaceholderText
		{
			get { return this.placeholderText; }
			set
			{
				this.placeholderText = value;
				this.Refresh();
			}
		}

		public ColorWell() : base()
		{
			// Enable ResizeRedraw to properly resize the empty text
			// and the others to reduce flickering:
			this.SetStyle(ControlStyles.ResizeRedraw
				| ControlStyles.DoubleBuffer
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.UserPaint
				| ControlStyles.AllPaintingInWmPaint
				| ControlStyles.SupportsTransparentBackColor,
				true);

			this.BackColor = Color.Transparent;
		}

		protected override void OnControlAdded(ControlEventArgs e)
		{
			// Restrict child controls to only ColorBoxes:
			if (!e.Control.GetType().Equals(typeof(ColorTile)))
			{
				throw new NotSupportedException("Only ColorBox controls can be added to a ColorWell control.");
			}

			base.OnControlAdded(e);

			if (this.Controls.Count == 1)
			{
				this.Refresh();
			}
		}

		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);

			if (this.Controls.Count > 0)
			{
				if (this.selectedIndex == 0)
				{
					SetSelectedColorTile(0);
				}
				else if (this.selectedIndex == this.Controls.Count)
				{
					SetSelectedColorTile(this.Controls.Count - 1);
				}
				else
				{
					SetSelectedColorTile(this.selectedIndex);
				}
			}
			else
			{
				SetSelectedColorTile(null);
				this.Refresh();
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			// Deselect the currently-selected child control if user clicks in empty space:
			if (this.GetChildAtPoint(e.Location) == null && this.selectedItem != null)
			{
				this.SelectedItem = null;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Draw placeholder text if the well is empty:
			if (this.Controls.Count == 0)
			{
				TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
				TextRenderer.DrawText(e.Graphics, this.placeholderText, SystemFonts.CaptionFont, this.ClientRectangle,
					SystemColors.GrayText, this.BackColor, flags);
			}

			if (!this.Enabled)
			{
				using (SolidBrush disabledBrush = new SolidBrush(Color.FromArgb(128, SystemColors.Control)))
				{
					e.Graphics.FillRectangle(disabledBrush, this.ClientRectangle);
				}
			}
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			base.OnEnabledChanged(e);

			this.BackColor = this.Enabled ? SystemColors.Window : SystemColors.Control;
			this.VScroll = !this.Enabled;
		}

		private ColorTile GetSelectedColorBox()
		{
			if (this.Controls.Count > 0)
			{
				// Loop over all child controls until we find one that's selected:
				foreach (Control control in this.Controls)
				{
					if (control.GetType() == typeof(ColorTile))
					{
						if ((control as ColorTile).Selected)
						{
							return control as ColorTile;
						}
					}
				}
			}

			return null;
		}

		private void SetSelectedColorTile(int index)
		{
			if (this.Controls.Count > 0)
			{
				if (index == -1)
				{
					// Clear selection:
					SetSelectedColorTile(null);
				}
				else if (index > -1 && index < this.Controls.Count)
				{
					// Select based on index:
					SetSelectedColorTile(this.Controls[index] as ColorTile);
				}
				else
				{
					// Index out of range:
					throw new ArgumentOutOfRangeException("index");
				}
			}
		}

		private void SetSelectedColorTile(ColorTile colorTile)
		{
			ClearSelection();

			if (colorTile == null)
			{
				this.selectedItem = null;
				this.selectedIndex = -1;

				if (this.SelectionChanged != null)
				{
					this.SelectionChanged(null, EventArgs.Empty);
				}
			}
			else
			{
				foreach (Control control in this.Controls)
				{
					if (control.GetType() == typeof(ColorTile))
					{
						ColorTile tile = control as ColorTile;

						// Select the argument ColorTile:
						if (tile.Equals(colorTile))
						{
							tile.Selected = true;
							this.selectedItem = tile;
							this.selectedIndex = this.Controls.IndexOf(tile);

							if (this.SelectionChanged != null)
							{
								this.SelectionChanged(tile, EventArgs.Empty);
							}
							break;
						}
					}
				}
			}
		}

		private void SetActiveColorTile(int index)
		{
			if (this.Controls.Count > 0)
			{
				if (index == -1)
				{
					// Clear selection:
					SetActiveColorTile(null);
				}
				else if (index > -1 && index < this.Controls.Count)
				{
					// Select based on index:
					SetActiveColorTile(this.Controls[index] as ColorTile);
				}
				else
				{
					// Index out of range:
					throw new ArgumentOutOfRangeException("index");
				}
			}
		}

		private void SetActiveColorTile(ColorTile colorTile)
		{
			ClearActive();

			if (colorTile == null)
			{
				this.activeItem = null;
				this.activeIndex = -1;

				if (this.ActiveItemChanged != null)
				{
					this.ActiveItemChanged(null, EventArgs.Empty);
				}
			}
			else
			{
				foreach (Control control in this.Controls)
				{
					if (control.GetType() == typeof(ColorTile))
					{
						ColorTile tile = control as ColorTile;

						// Set tile as active:
						if (tile.Equals(colorTile))
						{
							tile.Active = true;
							this.activeItem = tile;
							this.activeIndex = this.Controls.IndexOf(tile);
							tooltip.SetToolTip(tile, "#" + string.Format("{0:X}\nActive", tile.Color.ToArgb()).Remove(0, 2));

							if (this.ActiveItemChanged != null)
							{
								this.ActiveItemChanged(tile, EventArgs.Empty);
							}
							break;
						}
					}
				}
			}
		}

		internal void ClearSelection()
		{
			foreach (Control control in this.Controls)
			{
				if (control.GetType() == typeof(ColorTile))
				{
					(control as ColorTile).Selected = false;
				}
			}
		}

		internal void ClearActive()
		{
			foreach (Control control in this.Controls)
			{
				if (control.GetType() == typeof(ColorTile))
				{
					(control as ColorTile).Active = false;
					tooltip.SetToolTip(control, "#" + string.Format("{0:X}", (control as ColorTile).Color.ToArgb()).Remove(0, 2));
				}
			}
		}

		/// <summary>
		/// Adds a new color tile to the well with the specified color.
		/// </summary>
		/// <param name="color">The color of the new tile.</param>
		public void Add(Color color)
		{
			if (this.uniqueOnly)
			{
				// Instead of adding a duplicate tile, select the existing tile with the user's color:
				foreach (Control control in this.Controls)
				{
					if (control.GetType().Equals(typeof(ColorTile)))
					{
						ColorTile tile = control as ColorTile;

						if (tile.BackColor.ToArgb() == color.ToArgb())
						{
							this.SelectedItem = tile;
							return;
						}
					}
				}
			}

			// Otherwise, just add the new tile:
			ColorTile newTile = new ColorTile(color);
			newTile.Size = this.itemSize;
			newTile.Parent = this;
			newTile.Margin = new Padding(0);
			tooltip.SetToolTip(newTile, "#" + string.Format("{0:X}", color.ToArgb()).Remove(0, 2));
			newTile.Color = color;
			this.Controls.Add(newTile);
		}

		public void MoveLeft(int index)
		{
			if (index > 0)
			{
				Color tempColor = (this.Controls[index - 1] as ColorTile).Color;
				(this.Controls[index - 1] as ColorTile).Color = (this.Controls[index] as ColorTile).Color;
				(this.Controls[index] as ColorTile).Color = tempColor;
				this.SelectedIndex = index - 1;
				this.ActiveIndex = index - 1;
			}
		}

		public void MoveRight(int index)
		{
			if (index < this.Controls.Count - 1)
			{
				Color tempColor = (this.Controls[index + 1] as ColorTile).Color;
				(this.Controls[index + 1] as ColorTile).Color = (this.Controls[index] as ColorTile).Color;
				(this.Controls[index] as ColorTile).Color = tempColor;
				this.SelectedIndex = index + 1;
				this.ActiveIndex = index + 1;
			}
		}

		public Color GetColorAtIndex(int index)
		{
			if (this.Controls.Count > 0 && index > -1 && index < this.Controls.Count)
			{
				return (this.Controls[index] as ColorTile).Color;
			}
			else
			{
				// Index out of range:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		private class ColorTile : Control
		{
			private bool isMouseOver = false;
			private bool active = false;
			private bool selected = false;
			private Color color = Color.Black;

			[Browsable(false)]
			internal bool Active
			{
				get { return this.active; }
				set
				{
					if (this.active != value)
					{
						this.active = value;
						this.Refresh();
					}
				}
			}

			[Browsable(false)]
			internal bool Selected
			{
				get { return this.selected; }
				set
				{
					if (this.selected != value)
					{
						this.selected = value;
						this.Refresh();
					}
				}
			}

			[Browsable(true)]
			public Color Color
			{
				get { return this.color; }
				set
				{
					if (this.color != value)
					{
						this.color = value;
						this.Refresh();
						// TODO: raise event
					}
				}
			}

			public ColorTile(Color color) : base()
			{
				// We'll be handling painting ourselves:
				this.SetStyle(ControlStyles.AllPaintingInWmPaint
				   | ControlStyles.OptimizedDoubleBuffer
				   | ControlStyles.ResizeRedraw
				   | ControlStyles.DoubleBuffer
				   | ControlStyles.UserPaint
				   | ControlStyles.SupportsTransparentBackColor,
				   true);

				// Disable double clicking:
				this.SetStyle(ControlStyles.StandardDoubleClick, false);

				this.color = color;
				this.BackColor = Color.Transparent;
			}

			protected override void OnMouseEnter(EventArgs e)
			{
				base.OnMouseEnter(e);
				this.isMouseOver = true;
				this.Refresh();
			}

			protected override void OnMouseLeave(EventArgs e)
			{
				base.OnMouseLeave(e);
				this.isMouseOver = false;
				this.Refresh();
			}

			protected override void OnMouseClick(MouseEventArgs e)
			{
				base.OnMouseClick(e);

				if (this.Parent.GetType() == typeof(ColorWell))
				{
					(this.Parent as ColorWell).SelectedItem = this;
					this.Parent.Focus();
				}
			}

			protected override void OnPaint(PaintEventArgs e)
			{
				Rectangle colorRectangle = new Rectangle(ColorWell.TILE_PADDING, ColorWell.TILE_PADDING,
					this.Width - 2 * ColorWell.TILE_PADDING, this.Height - 2 * ColorWell.TILE_PADDING);

				// Draw selection rectangle:
				if (this.selected)
				{
					using (SolidBrush selectionBrush = new SolidBrush(Color.FromArgb(200, SystemColors.MenuHighlight)))
					{
						e.Graphics.FillRectangle(selectionBrush, this.ClientRectangle);
					}
				}

				// Draw highlight rectangle:
				if (this.isMouseOver)
				{
					using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(128, SystemColors.MenuHighlight)))
					{
						e.Graphics.FillRectangle(highlightBrush, this.ClientRectangle);
					}
				}
				
				// Draw color:
				using (SolidBrush colorBrush = new SolidBrush(this.color))
				{
					e.Graphics.FillRectangle(colorBrush, colorRectangle);
				}

				// Draw inner border:
				Rectangle innerBorderRectangle = new Rectangle(colorRectangle.Left + 1, colorRectangle.Top + 1,
					colorRectangle.Width - 3, colorRectangle.Height - 3);
				using (Pen innerBorderBrush = new Pen(Color.FromArgb(200, SystemColors.ControlLightLight)))
				{
					e.Graphics.DrawRectangle(innerBorderBrush, innerBorderRectangle);
				}

				// Draw outer border:
				if (this.active)
				{
					Rectangle outerBorderRectangle = new Rectangle(colorRectangle.Left + 1, colorRectangle.Top + 1,
						colorRectangle.Width - 2, colorRectangle.Height - 2);
					using (Pen HotTrackPen = new Pen(SystemColors.ControlDarkDark, 2F))
					{
						e.Graphics.DrawRectangle(HotTrackPen, outerBorderRectangle);
					}
				}
				else
				{
					Rectangle outerBorderRectangle = new Rectangle(colorRectangle.Left, colorRectangle.Top,
						colorRectangle.Width - 1, colorRectangle.Height - 1);
					e.Graphics.DrawRectangle(SystemPens.ControlDark, outerBorderRectangle);
				}

				// Draw disabled state:
				if (!this.Parent.Enabled)
				{
					using (SolidBrush disabledBrush = new SolidBrush(Color.FromArgb(191, SystemColors.Control)))
					{
						e.Graphics.FillRectangle(disabledBrush, this.ClientRectangle);
					}
				}
			}

			public override string ToString()
			{
				return string.Format("ColorTile: {0:X6}", this.BackColor.ToArgb());
			}
		}
	}
}
