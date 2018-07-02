namespace ColorChanger
{
	partial class SettingsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panel_form_spacer2 = new System.Windows.Forms.Panel();
            this.panel_controls = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.splitButton_settings = new ColorChanger.Controls.SplitButton();
            this.contextMenu_settings = new System.Windows.Forms.ContextMenu();
            this.menuItem_import = new System.Windows.Forms.MenuItem();
            this.menuItem_export = new System.Windows.Forms.MenuItem();
            this.menuItem_reset = new System.Windows.Forms.MenuItem();
            this.menuItem_separator1 = new System.Windows.Forms.MenuItem();
            this.menuItem_showTrayIcon = new System.Windows.Forms.MenuItem();
            this.menuItem_startWithWindows = new System.Windows.Forms.MenuItem();
            this.panel_top = new System.Windows.Forms.Panel();
            this.colorWell_colors = new ColorChanger.Controls.ColorWell();
            this.toolStrip_colors = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_addColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_removeColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_moveLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_moveRight = new System.Windows.Forms.ToolStripButton();
            this.label_colorsInstruction = new System.Windows.Forms.Label();
            this.label_transitionInstructions = new System.Windows.Forms.Label();
            this.panel_transition = new System.Windows.Forms.Panel();
            this.panel_transition_options = new System.Windows.Forms.Panel();
            this.radioButton_fade_fast = new System.Windows.Forms.RadioButton();
            this.radioButton_fade_medium = new System.Windows.Forms.RadioButton();
            this.radioButton_fade_slow = new System.Windows.Forms.RadioButton();
            this.radioButton_transition_fade = new System.Windows.Forms.RadioButton();
            this.radioButton_transition_instant = new System.Windows.Forms.RadioButton();
            this.label_durationInstructions = new System.Windows.Forms.Label();
            this.panel_duration = new System.Windows.Forms.Panel();
            this.panel_duration_options = new System.Windows.Forms.Panel();
            this.comboBox_timeIntervals = new System.Windows.Forms.ComboBox();
            this.panel_duration_options_spacer = new System.Windows.Forms.Panel();
            this.numericUpDown_timeInterval = new System.Windows.Forms.NumericUpDown();
            this.radioButton_duration_schedule = new System.Windows.Forms.RadioButton();
            this.radioButton_duration_manual = new System.Windows.Forms.RadioButton();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_shuffle = new System.Windows.Forms.Panel();
            this.radioButton_shuffle_off = new System.Windows.Forms.RadioButton();
            this.radioButton_suffle_on = new System.Windows.Forms.RadioButton();
            this.label_orderingInstructions = new System.Windows.Forms.Label();
            this.panel_form_spacer1 = new System.Windows.Forms.Panel();
            this.contextMenu_notifyIcon = new System.Windows.Forms.ContextMenu();
            this.menuItem_nextColor = new System.Windows.Forms.MenuItem();
            this.menuItem_settings = new System.Windows.Forms.MenuItem();
            this.menuItem_separator = new System.Windows.Forms.MenuItem();
            this.menuItem_exit = new System.Windows.Forms.MenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel_controls.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.toolStrip_colors.SuspendLayout();
            this.panel_transition.SuspendLayout();
            this.panel_transition_options.SuspendLayout();
            this.panel_duration.SuspendLayout();
            this.panel_duration_options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_timeInterval)).BeginInit();
            this.panel_bottom.SuspendLayout();
            this.panel_shuffle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_form_spacer2
            // 
            this.panel_form_spacer2.BackColor = System.Drawing.Color.Transparent;
            this.panel_form_spacer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_form_spacer2.Location = new System.Drawing.Point(5, 452);
            this.panel_form_spacer2.Name = "panel_form_spacer2";
            this.panel_form_spacer2.Size = new System.Drawing.Size(339, 8);
            this.panel_form_spacer2.TabIndex = 54;
            // 
            // panel_controls
            // 
            this.panel_controls.Controls.Add(this.button_cancel);
            this.panel_controls.Controls.Add(this.button_ok);
            this.panel_controls.Controls.Add(this.splitButton_settings);
            this.panel_controls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_controls.Location = new System.Drawing.Point(5, 460);
            this.panel_controls.Name = "panel_controls";
            this.panel_controls.Padding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.panel_controls.Size = new System.Drawing.Size(339, 31);
            this.panel_controls.TabIndex = 53;
            // 
            // button_cancel
            // 
            this.button_cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_cancel.Location = new System.Drawing.Point(184, 0);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 26);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_ok.Location = new System.Drawing.Point(259, 0);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 26);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // splitButton_settings
            // 
            this.splitButton_settings.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitButton_settings.DropdownMenu = this.contextMenu_settings;
            this.splitButton_settings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.splitButton_settings.Location = new System.Drawing.Point(0, 0);
            this.splitButton_settings.Name = "splitButton_settings";
            this.splitButton_settings.Size = new System.Drawing.Size(85, 26);
            this.splitButton_settings.Splitter = false;
            this.splitButton_settings.TabIndex = 0;
            this.splitButton_settings.Text = "Settings";
            this.splitButton_settings.UseVisualStyleBackColor = true;
            // 
            // contextMenu_settings
            // 
            this.contextMenu_settings.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_import,
            this.menuItem_export,
            this.menuItem_reset,
            this.menuItem_separator1,
            this.menuItem_showTrayIcon,
            this.menuItem_startWithWindows});
            // 
            // menuItem_import
            // 
            this.menuItem_import.Index = 0;
            this.menuItem_import.Text = "&Import...";
            // 
            // menuItem_export
            // 
            this.menuItem_export.Index = 1;
            this.menuItem_export.Text = "&Export...";
            // 
            // menuItem_reset
            // 
            this.menuItem_reset.Index = 2;
            this.menuItem_reset.Text = "&Reset";
            // 
            // menuItem_separator1
            // 
            this.menuItem_separator1.Index = 3;
            this.menuItem_separator1.Text = "-";
            // 
            // menuItem_showTrayIcon
            // 
            this.menuItem_showTrayIcon.Checked = true;
            this.menuItem_showTrayIcon.Index = 4;
            this.menuItem_showTrayIcon.Text = "Show &tray icon";
            this.menuItem_showTrayIcon.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem_startWithWindows
            // 
            this.menuItem_startWithWindows.Index = 5;
            this.menuItem_startWithWindows.Text = "Start with &Windows";
            this.menuItem_startWithWindows.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.colorWell_colors);
            this.panel_top.Controls.Add(this.toolStrip_colors);
            this.panel_top.Controls.Add(this.label_colorsInstruction);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_top.Location = new System.Drawing.Point(5, 5);
            this.panel_top.Name = "panel_top";
            this.panel_top.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel_top.Size = new System.Drawing.Size(339, 207);
            this.panel_top.TabIndex = 58;
            // 
            // colorWell_colors
            // 
            this.colorWell_colors.ActiveIndex = -1;
            this.colorWell_colors.AutoScroll = true;
            this.colorWell_colors.BackColor = System.Drawing.SystemColors.Window;
            this.colorWell_colors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorWell_colors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorWell_colors.Location = new System.Drawing.Point(0, 30);
            this.colorWell_colors.Margin = new System.Windows.Forms.Padding(0);
            this.colorWell_colors.Name = "colorWell_colors";
            this.colorWell_colors.PlaceholderText = "Feed me colors!";
            this.colorWell_colors.SelectedIndex = -1;
            this.colorWell_colors.Size = new System.Drawing.Size(334, 152);
            this.colorWell_colors.TabIndex = 18;
            this.colorWell_colors.SelectionChanged += new System.EventHandler(this.colorWell_colors_SelectionChanged);
            // 
            // toolStrip_colors
            // 
            this.toolStrip_colors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_colors.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip_colors.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_colors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_addColor,
            this.toolStripButton_removeColor,
            this.toolStripSeparator1,
            this.toolStripButton_moveLeft,
            this.toolStripButton_moveRight});
            this.toolStrip_colors.Location = new System.Drawing.Point(0, 182);
            this.toolStrip_colors.Name = "toolStrip_colors";
            this.toolStrip_colors.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip_colors.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_colors.Size = new System.Drawing.Size(334, 25);
            this.toolStrip_colors.Stretch = true;
            this.toolStrip_colors.TabIndex = 58;
            this.toolStrip_colors.Text = "Color list controls";
            // 
            // toolStripButton_addColor
            // 
            this.toolStripButton_addColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_addColor.Image = global::ColorChanger.Properties.Resources.add;
            this.toolStripButton_addColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addColor.Name = "toolStripButton_addColor";
            this.toolStripButton_addColor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_addColor.Text = "Add";
            this.toolStripButton_addColor.ToolTipText = "Add a new color";
            this.toolStripButton_addColor.Click += new System.EventHandler(this.toolStripButton_addColor_Click);
            // 
            // toolStripButton_removeColor
            // 
            this.toolStripButton_removeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_removeColor.Enabled = false;
            this.toolStripButton_removeColor.Image = global::ColorChanger.Properties.Resources.remove;
            this.toolStripButton_removeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_removeColor.Name = "toolStripButton_removeColor";
            this.toolStripButton_removeColor.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_removeColor.Text = "Remove";
            this.toolStripButton_removeColor.ToolTipText = "Remove the selected color";
            this.toolStripButton_removeColor.Click += new System.EventHandler(this.toolStripButton_removeColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_moveLeft
            // 
            this.toolStripButton_moveLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_moveLeft.Enabled = false;
            this.toolStripButton_moveLeft.Image = global::ColorChanger.Properties.Resources.move_left;
            this.toolStripButton_moveLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_moveLeft.Name = "toolStripButton_moveLeft";
            this.toolStripButton_moveLeft.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_moveLeft.Text = "Move left";
            this.toolStripButton_moveLeft.ToolTipText = "Move the selected color left";
            this.toolStripButton_moveLeft.Click += new System.EventHandler(this.toolStripButton_moveLeft_Click);
            // 
            // toolStripButton_moveRight
            // 
            this.toolStripButton_moveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_moveRight.Enabled = false;
            this.toolStripButton_moveRight.Image = global::ColorChanger.Properties.Resources.move_right;
            this.toolStripButton_moveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_moveRight.Name = "toolStripButton_moveRight";
            this.toolStripButton_moveRight.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_moveRight.Text = "Move right";
            this.toolStripButton_moveRight.ToolTipText = "Move the selected color right";
            this.toolStripButton_moveRight.Click += new System.EventHandler(this.toolStripButton_moveRight_Click);
            // 
            // label_colorsInstruction
            // 
            this.label_colorsInstruction.AutoEllipsis = true;
            this.label_colorsInstruction.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_colorsInstruction.Location = new System.Drawing.Point(0, 0);
            this.label_colorsInstruction.Name = "label_colorsInstruction";
            this.label_colorsInstruction.Size = new System.Drawing.Size(334, 30);
            this.label_colorsInstruction.TabIndex = 60;
            this.label_colorsInstruction.Text = "Pick some colors for me to use:";
            // 
            // label_transitionInstructions
            // 
            this.label_transitionInstructions.AutoEllipsis = true;
            this.label_transitionInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_transitionInstructions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_transitionInstructions.Location = new System.Drawing.Point(0, 0);
            this.label_transitionInstructions.Name = "label_transitionInstructions";
            this.label_transitionInstructions.Size = new System.Drawing.Size(322, 30);
            this.label_transitionInstructions.TabIndex = 53;
            this.label_transitionInstructions.Text = "How should I change colors?";
            // 
            // panel_transition
            // 
            this.panel_transition.Controls.Add(this.panel_transition_options);
            this.panel_transition.Controls.Add(this.radioButton_transition_fade);
            this.panel_transition.Controls.Add(this.radioButton_transition_instant);
            this.panel_transition.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_transition.Location = new System.Drawing.Point(0, 30);
            this.panel_transition.Name = "panel_transition";
            this.panel_transition.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel_transition.Size = new System.Drawing.Size(322, 105);
            this.panel_transition.TabIndex = 55;
            // 
            // panel_transition_options
            // 
            this.panel_transition_options.Controls.Add(this.radioButton_fade_fast);
            this.panel_transition_options.Controls.Add(this.radioButton_fade_medium);
            this.panel_transition_options.Controls.Add(this.radioButton_fade_slow);
            this.panel_transition_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_transition_options.Location = new System.Drawing.Point(3, 40);
            this.panel_transition_options.Name = "panel_transition_options";
            this.panel_transition_options.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.panel_transition_options.Size = new System.Drawing.Size(319, 65);
            this.panel_transition_options.TabIndex = 35;
            // 
            // radioButton_fade_fast
            // 
            this.radioButton_fade_fast.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_fade_fast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_fade_fast.Location = new System.Drawing.Point(15, 40);
            this.radioButton_fade_fast.Name = "radioButton_fade_fast";
            this.radioButton_fade_fast.Size = new System.Drawing.Size(304, 20);
            this.radioButton_fade_fast.TabIndex = 35;
            this.radioButton_fade_fast.Text = "Quick";
            this.radioButton_fade_fast.UseVisualStyleBackColor = true;
            this.radioButton_fade_fast.CheckedChanged += new System.EventHandler(this.radioButton_fade_fast_CheckedChanged);
            // 
            // radioButton_fade_medium
            // 
            this.radioButton_fade_medium.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_fade_medium.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_fade_medium.Location = new System.Drawing.Point(15, 20);
            this.radioButton_fade_medium.Name = "radioButton_fade_medium";
            this.radioButton_fade_medium.Size = new System.Drawing.Size(304, 20);
            this.radioButton_fade_medium.TabIndex = 34;
            this.radioButton_fade_medium.Text = "Medium";
            this.radioButton_fade_medium.UseVisualStyleBackColor = true;
            this.radioButton_fade_medium.CheckedChanged += new System.EventHandler(this.radioButton_fade_medium_CheckedChanged);
            // 
            // radioButton_fade_slow
            // 
            this.radioButton_fade_slow.Checked = true;
            this.radioButton_fade_slow.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_fade_slow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_fade_slow.Location = new System.Drawing.Point(15, 0);
            this.radioButton_fade_slow.Name = "radioButton_fade_slow";
            this.radioButton_fade_slow.Size = new System.Drawing.Size(304, 20);
            this.radioButton_fade_slow.TabIndex = 33;
            this.radioButton_fade_slow.TabStop = true;
            this.radioButton_fade_slow.Text = "Slow";
            this.radioButton_fade_slow.UseVisualStyleBackColor = true;
            this.radioButton_fade_slow.CheckedChanged += new System.EventHandler(this.radioButton_fade_slow_CheckedChanged);
            // 
            // radioButton_transition_fade
            // 
            this.radioButton_transition_fade.Checked = true;
            this.radioButton_transition_fade.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_transition_fade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_transition_fade.Location = new System.Drawing.Point(3, 20);
            this.radioButton_transition_fade.Name = "radioButton_transition_fade";
            this.radioButton_transition_fade.Size = new System.Drawing.Size(319, 20);
            this.radioButton_transition_fade.TabIndex = 33;
            this.radioButton_transition_fade.TabStop = true;
            this.radioButton_transition_fade.Text = "Fade from color to color:";
            this.radioButton_transition_fade.UseVisualStyleBackColor = true;
            this.radioButton_transition_fade.Click += new System.EventHandler(this.radioButton_transition_fade_CheckedChanged);
            // 
            // radioButton_transition_instant
            // 
            this.radioButton_transition_instant.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_transition_instant.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_transition_instant.Location = new System.Drawing.Point(3, 0);
            this.radioButton_transition_instant.Name = "radioButton_transition_instant";
            this.radioButton_transition_instant.Size = new System.Drawing.Size(319, 20);
            this.radioButton_transition_instant.TabIndex = 34;
            this.radioButton_transition_instant.Text = "Instantly";
            this.radioButton_transition_instant.UseVisualStyleBackColor = true;
            this.radioButton_transition_instant.CheckedChanged += new System.EventHandler(this.radioButton_transition_instant_CheckedChanged);
            this.radioButton_transition_instant.Click += new System.EventHandler(this.radioButton_transition_instant_CheckedChanged);
            // 
            // label_durationInstructions
            // 
            this.label_durationInstructions.AutoEllipsis = true;
            this.label_durationInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_durationInstructions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_durationInstructions.Location = new System.Drawing.Point(0, 135);
            this.label_durationInstructions.Name = "label_durationInstructions";
            this.label_durationInstructions.Size = new System.Drawing.Size(322, 30);
            this.label_durationInstructions.TabIndex = 54;
            this.label_durationInstructions.Text = "When should I change colors?";
            // 
            // panel_duration
            // 
            this.panel_duration.Controls.Add(this.panel_duration_options);
            this.panel_duration.Controls.Add(this.radioButton_duration_schedule);
            this.panel_duration.Controls.Add(this.radioButton_duration_manual);
            this.panel_duration.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_duration.Location = new System.Drawing.Point(0, 165);
            this.panel_duration.Name = "panel_duration";
            this.panel_duration.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel_duration.Size = new System.Drawing.Size(322, 73);
            this.panel_duration.TabIndex = 56;
            // 
            // panel_duration_options
            // 
            this.panel_duration_options.Controls.Add(this.comboBox_timeIntervals);
            this.panel_duration_options.Controls.Add(this.panel_duration_options_spacer);
            this.panel_duration_options.Controls.Add(this.numericUpDown_timeInterval);
            this.panel_duration_options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_duration_options.Location = new System.Drawing.Point(3, 40);
            this.panel_duration_options.Name = "panel_duration_options";
            this.panel_duration_options.Padding = new System.Windows.Forms.Padding(15, 3, 5, 0);
            this.panel_duration_options.Size = new System.Drawing.Size(319, 33);
            this.panel_duration_options.TabIndex = 40;
            // 
            // comboBox_timeIntervals
            // 
            this.comboBox_timeIntervals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_timeIntervals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_timeIntervals.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox_timeIntervals.FormattingEnabled = true;
            this.comboBox_timeIntervals.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "hours",
            "days"});
            this.comboBox_timeIntervals.Location = new System.Drawing.Point(105, 3);
            this.comboBox_timeIntervals.Name = "comboBox_timeIntervals";
            this.comboBox_timeIntervals.Size = new System.Drawing.Size(209, 23);
            this.comboBox_timeIntervals.TabIndex = 43;
            this.comboBox_timeIntervals.SelectedIndexChanged += new System.EventHandler(this.comboBox_timeIntervals_SelectedIndexChanged);
            // 
            // panel_duration_options_spacer
            // 
            this.panel_duration_options_spacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_duration_options_spacer.Location = new System.Drawing.Point(95, 3);
            this.panel_duration_options_spacer.Name = "panel_duration_options_spacer";
            this.panel_duration_options_spacer.Size = new System.Drawing.Size(10, 30);
            this.panel_duration_options_spacer.TabIndex = 44;
            // 
            // numericUpDown_timeInterval
            // 
            this.numericUpDown_timeInterval.Dock = System.Windows.Forms.DockStyle.Left;
            this.numericUpDown_timeInterval.Location = new System.Drawing.Point(15, 3);
            this.numericUpDown_timeInterval.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_timeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_timeInterval.Name = "numericUpDown_timeInterval";
            this.numericUpDown_timeInterval.Size = new System.Drawing.Size(80, 23);
            this.numericUpDown_timeInterval.TabIndex = 42;
            this.numericUpDown_timeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_timeInterval.ValueChanged += new System.EventHandler(this.numericUpDown_timeInterval_ValueChanged);
            // 
            // radioButton_duration_schedule
            // 
            this.radioButton_duration_schedule.Checked = true;
            this.radioButton_duration_schedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_duration_schedule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_duration_schedule.Location = new System.Drawing.Point(3, 20);
            this.radioButton_duration_schedule.Name = "radioButton_duration_schedule";
            this.radioButton_duration_schedule.Size = new System.Drawing.Size(319, 20);
            this.radioButton_duration_schedule.TabIndex = 38;
            this.radioButton_duration_schedule.TabStop = true;
            this.radioButton_duration_schedule.Text = "According to a schedule:";
            this.radioButton_duration_schedule.UseVisualStyleBackColor = true;
            this.radioButton_duration_schedule.Click += new System.EventHandler(this.radioButton_duration_interval_CheckedChanged);
            // 
            // radioButton_duration_manual
            // 
            this.radioButton_duration_manual.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_duration_manual.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_duration_manual.Location = new System.Drawing.Point(3, 0);
            this.radioButton_duration_manual.Name = "radioButton_duration_manual";
            this.radioButton_duration_manual.Size = new System.Drawing.Size(319, 20);
            this.radioButton_duration_manual.TabIndex = 39;
            this.radioButton_duration_manual.Text = "Only when you tell me";
            this.radioButton_duration_manual.UseVisualStyleBackColor = true;
            this.radioButton_duration_manual.Click += new System.EventHandler(this.radioButton_duration_manual_CheckedChanged);
            // 
            // panel_bottom
            // 
            this.panel_bottom.AutoScroll = true;
            this.panel_bottom.AutoScrollMinSize = new System.Drawing.Size(0, 225);
            this.panel_bottom.Controls.Add(this.panel_shuffle);
            this.panel_bottom.Controls.Add(this.label_orderingInstructions);
            this.panel_bottom.Controls.Add(this.panel_duration);
            this.panel_bottom.Controls.Add(this.label_durationInstructions);
            this.panel_bottom.Controls.Add(this.panel_transition);
            this.panel_bottom.Controls.Add(this.label_transitionInstructions);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(5, 220);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(339, 232);
            this.panel_bottom.TabIndex = 51;
            // 
            // panel_shuffle
            // 
            this.panel_shuffle.Controls.Add(this.radioButton_shuffle_off);
            this.panel_shuffle.Controls.Add(this.radioButton_suffle_on);
            this.panel_shuffle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_shuffle.Location = new System.Drawing.Point(0, 268);
            this.panel_shuffle.Name = "panel_shuffle";
            this.panel_shuffle.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.panel_shuffle.Size = new System.Drawing.Size(322, 45);
            this.panel_shuffle.TabIndex = 60;
            // 
            // radioButton_shuffle_off
            // 
            this.radioButton_shuffle_off.Checked = true;
            this.radioButton_shuffle_off.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_shuffle_off.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_shuffle_off.Location = new System.Drawing.Point(3, 20);
            this.radioButton_shuffle_off.Name = "radioButton_shuffle_off";
            this.radioButton_shuffle_off.Size = new System.Drawing.Size(319, 20);
            this.radioButton_shuffle_off.TabIndex = 38;
            this.radioButton_shuffle_off.TabStop = true;
            this.radioButton_shuffle_off.Text = "No, stick to the order above";
            this.radioButton_shuffle_off.UseVisualStyleBackColor = true;
            this.radioButton_shuffle_off.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton_suffle_on
            // 
            this.radioButton_suffle_on.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton_suffle_on.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton_suffle_on.Location = new System.Drawing.Point(3, 0);
            this.radioButton_suffle_on.Name = "radioButton_suffle_on";
            this.radioButton_suffle_on.Size = new System.Drawing.Size(319, 20);
            this.radioButton_suffle_on.TabIndex = 39;
            this.radioButton_suffle_on.Text = "Yes, shuffle the colors";
            this.radioButton_suffle_on.UseVisualStyleBackColor = true;
            this.radioButton_suffle_on.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label_orderingInstructions
            // 
            this.label_orderingInstructions.AutoEllipsis = true;
            this.label_orderingInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_orderingInstructions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_orderingInstructions.Location = new System.Drawing.Point(0, 238);
            this.label_orderingInstructions.Name = "label_orderingInstructions";
            this.label_orderingInstructions.Size = new System.Drawing.Size(322, 30);
            this.label_orderingInstructions.TabIndex = 59;
            this.label_orderingInstructions.Text = "Should I shuffle colors randomly?";
            // 
            // panel_form_spacer1
            // 
            this.panel_form_spacer1.BackColor = System.Drawing.Color.Transparent;
            this.panel_form_spacer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_form_spacer1.Location = new System.Drawing.Point(5, 212);
            this.panel_form_spacer1.Name = "panel_form_spacer1";
            this.panel_form_spacer1.Size = new System.Drawing.Size(339, 8);
            this.panel_form_spacer1.TabIndex = 60;
            // 
            // contextMenu_notifyIcon
            // 
            this.contextMenu_notifyIcon.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_nextColor,
            this.menuItem_settings,
            this.menuItem_separator,
            this.menuItem_exit});
            // 
            // menuItem_nextColor
            // 
            this.menuItem_nextColor.Index = 0;
            this.menuItem_nextColor.Text = "&Next color";
            this.menuItem_nextColor.Click += new System.EventHandler(this.menuItem_nextColor_Click);
            // 
            // menuItem_settings
            // 
            this.menuItem_settings.DefaultItem = true;
            this.menuItem_settings.Index = 1;
            this.menuItem_settings.Text = "&Settings...";
            this.menuItem_settings.Click += new System.EventHandler(this.menuItem_settings_Click);
            // 
            // menuItem_separator
            // 
            this.menuItem_separator.Index = 2;
            this.menuItem_separator.Text = "-";
            // 
            // menuItem_exit
            // 
            this.menuItem_exit.Index = 3;
            this.menuItem_exit.Text = "&Exit";
            this.menuItem_exit.Click += new System.EventHandler(this.menuItem_exit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 491);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_form_spacer1);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_form_spacer2);
            this.Controls.Add(this.panel_controls);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(285, 476);
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorChanger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel_controls.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.toolStrip_colors.ResumeLayout(false);
            this.toolStrip_colors.PerformLayout();
            this.panel_transition.ResumeLayout(false);
            this.panel_transition_options.ResumeLayout(false);
            this.panel_duration.ResumeLayout(false);
            this.panel_duration_options.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_timeInterval)).EndInit();
            this.panel_bottom.ResumeLayout(false);
            this.panel_shuffle.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel_form_spacer2;
		private System.Windows.Forms.Panel panel_controls;
		private System.Windows.Forms.Button button_cancel;
		private System.Windows.Forms.Button button_ok;
		private System.Windows.Forms.Panel panel_top;
		private Controls.ColorWell colorWell_colors;
		private System.Windows.Forms.ToolStrip toolStrip_colors;
		private System.Windows.Forms.ToolStripButton toolStripButton_addColor;
		private System.Windows.Forms.ToolStripButton toolStripButton_removeColor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton_moveLeft;
		private System.Windows.Forms.ToolStripButton toolStripButton_moveRight;
		private System.Windows.Forms.Label label_transitionInstructions;
		private System.Windows.Forms.Panel panel_transition;
		private System.Windows.Forms.Panel panel_transition_options;
		private System.Windows.Forms.RadioButton radioButton_fade_fast;
		private System.Windows.Forms.RadioButton radioButton_fade_medium;
		private System.Windows.Forms.RadioButton radioButton_fade_slow;
		private System.Windows.Forms.RadioButton radioButton_transition_fade;
		private System.Windows.Forms.RadioButton radioButton_transition_instant;
		private System.Windows.Forms.Label label_durationInstructions;
		private System.Windows.Forms.Panel panel_duration;
		private System.Windows.Forms.Panel panel_duration_options;
		private System.Windows.Forms.ComboBox comboBox_timeIntervals;
		private System.Windows.Forms.Panel panel_duration_options_spacer;
		private System.Windows.Forms.NumericUpDown numericUpDown_timeInterval;
		private System.Windows.Forms.RadioButton radioButton_duration_schedule;
		private System.Windows.Forms.RadioButton radioButton_duration_manual;
		private System.Windows.Forms.Panel panel_bottom;
		private System.Windows.Forms.Label label_colorsInstruction;
		private System.Windows.Forms.Panel panel_shuffle;
		private System.Windows.Forms.RadioButton radioButton_shuffle_off;
		private System.Windows.Forms.RadioButton radioButton_suffle_on;
		private System.Windows.Forms.Label label_orderingInstructions;
		private Controls.SplitButton splitButton_settings;
		private System.Windows.Forms.ContextMenu contextMenu_settings;
		private System.Windows.Forms.MenuItem menuItem_import;
		private System.Windows.Forms.MenuItem menuItem_export;
		private System.Windows.Forms.MenuItem menuItem_reset;
		private System.Windows.Forms.MenuItem menuItem_separator1;
		private System.Windows.Forms.MenuItem menuItem_showTrayIcon;
		private System.Windows.Forms.MenuItem menuItem_startWithWindows;
		private System.Windows.Forms.Panel panel_form_spacer1;
		private System.Windows.Forms.ContextMenu contextMenu_notifyIcon;
		private System.Windows.Forms.MenuItem menuItem_nextColor;
		private System.Windows.Forms.MenuItem menuItem_settings;
		private System.Windows.Forms.MenuItem menuItem_separator;
		private System.Windows.Forms.MenuItem menuItem_exit;
		private System.Windows.Forms.NotifyIcon notifyIcon;




	}
}

