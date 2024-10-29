namespace Circuits
{
    partial class Form1
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOr = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPad = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLamp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEvaluate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartCompound = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEndCompound = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAnd,
            this.toolStripButtonNot,
            this.toolStripButtonOr,
            this.toolStripButtonPad,
            this.toolStripButtonInput,
            this.toolStripButtonLamp,
            this.toolStripButtonEvaluate,
            this.toolStripButtonCopy,
            this.toolStripButtonStartCompound,
            this.toolStripButtonEndCompound,
            this.toolStripButtonRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAnd
            // 
            this.toolStripButtonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnd.Image = global::Circuits.Properties.Resources.AndIcon;
            this.toolStripButtonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnd.Name = "toolStripButtonAnd";
            this.toolStripButtonAnd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAnd.Text = "toolStripButton1";
            this.toolStripButtonAnd.Click += new System.EventHandler(this.toolStripButtonAnd_Click);
            // 
            // toolStripButtonNot
            // 
            this.toolStripButtonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNot.Image = global::Circuits.Properties.Resources.NotIcon;
            this.toolStripButtonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNot.Name = "toolStripButtonNot";
            this.toolStripButtonNot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNot.Text = "toolStripButton1";
            this.toolStripButtonNot.Click += new System.EventHandler(this.toolStripButtonNot_Click);
            // 
            // toolStripButtonOr
            // 
            this.toolStripButtonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOr.Image = global::Circuits.Properties.Resources.OrIcon;
            this.toolStripButtonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOr.Name = "toolStripButtonOr";
            this.toolStripButtonOr.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOr.Text = "toolStripButton1";
            this.toolStripButtonOr.Click += new System.EventHandler(this.toolStripButtonOr_Click);
            // 
            // toolStripButtonPad
            // 
            this.toolStripButtonPad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPad.Image = global::Circuits.Properties.Resources.PadIcon;
            this.toolStripButtonPad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPad.Name = "toolStripButtonPad";
            this.toolStripButtonPad.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPad.Text = "toolStripButton1";
            this.toolStripButtonPad.Click += new System.EventHandler(this.toolStripButtonPad_Click);
            // 
            // toolStripButtonInput
            // 
            this.toolStripButtonInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInput.Image = global::Circuits.Properties.Resources.InputIcon;
            this.toolStripButtonInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInput.Name = "toolStripButtonInput";
            this.toolStripButtonInput.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonInput.Text = "toolStripButton1";
            this.toolStripButtonInput.Click += new System.EventHandler(this.toolStripButtonInput_Click);
            // 
            // toolStripButtonLamp
            // 
            this.toolStripButtonLamp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLamp.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.toolStripButtonLamp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLamp.Name = "toolStripButtonLamp";
            this.toolStripButtonLamp.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLamp.Text = "toolStripButton1";
            this.toolStripButtonLamp.Click += new System.EventHandler(this.toolStripButtonLamp_Click);
            // 
            // toolStripButtonEvaluate
            // 
            this.toolStripButtonEvaluate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEvaluate.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.toolStripButtonEvaluate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEvaluate.Name = "toolStripButtonEvaluate";
            this.toolStripButtonEvaluate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEvaluate.Text = "toolStripButton1";
            this.toolStripButtonEvaluate.Click += new System.EventHandler(this.toolStripButtonEvaluate_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.Text = "toolStripButton1";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonStartCompound
            // 
            this.toolStripButtonStartCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartCompound.Image = global::Circuits.Properties.Resources.StartCompoundIcon;
            this.toolStripButtonStartCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartCompound.Name = "toolStripButtonStartCompound";
            this.toolStripButtonStartCompound.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStartCompound.Text = "toolStripButton1";
            this.toolStripButtonStartCompound.Click += new System.EventHandler(this.toolStripButtonStartCompound_Click);
            // 
            // toolStripButtonEndCompound
            // 
            this.toolStripButtonEndCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEndCompound.Image = global::Circuits.Properties.Resources.EndCompoundIcon;
            this.toolStripButtonEndCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEndCompound.Name = "toolStripButtonEndCompound";
            this.toolStripButtonEndCompound.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEndCompound.Text = "toolStripButton1";
            this.toolStripButtonEndCompound.Click += new System.EventHandler(this.toolStripButtonEndCompound_Click);
            // 
            // toolStripButtonRemove
            // 
            this.toolStripButtonRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemove.Image = global::Circuits.Properties.Resources.Remove_Icon;
            this.toolStripButtonRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemove.Name = "toolStripButtonRemove";
            this.toolStripButtonRemove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemove.Text = "toolStripButton1";
            this.toolStripButtonRemove.Click += new System.EventHandler(this.toolStripButtonRemove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circuits 2023";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnd;
        private System.Windows.Forms.ToolStripButton toolStripButtonNot;
        private System.Windows.Forms.ToolStripButton toolStripButtonOr;
        private System.Windows.Forms.ToolStripButton toolStripButtonPad;
        private System.Windows.Forms.ToolStripButton toolStripButtonInput;
        private System.Windows.Forms.ToolStripButton toolStripButtonLamp;
        private System.Windows.Forms.ToolStripButton toolStripButtonEvaluate;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartCompound;
        private System.Windows.Forms.ToolStripButton toolStripButtonEndCompound;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemove;
    }
}

