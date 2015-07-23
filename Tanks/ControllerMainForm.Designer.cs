namespace Tanks
{
    partial class ControllerMainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerMainForm));
            this.StartStop_pcbx = new System.Windows.Forms.PictureBox();
            this.Help_ttip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StartStop_pcbx)).BeginInit();
            this.SuspendLayout();
            // 
            // StartStop_pcbx
            // 
            this.StartStop_pcbx.Image = ((System.Drawing.Image)(resources.GetObject("StartStop_pcbx.Image")));
            this.StartStop_pcbx.Location = new System.Drawing.Point(260, 12);
            this.StartStop_pcbx.Name = "StartStop_pcbx";
            this.StartStop_pcbx.Size = new System.Drawing.Size(114, 118);
            this.StartStop_pcbx.TabIndex = 0;
            this.StartStop_pcbx.TabStop = false;
            this.Help_ttip.SetToolTip(this.StartStop_pcbx, "Нажми для старта");
            this.StartStop_pcbx.Click += new System.EventHandler(this.btnStartStop_Click);
            this.StartStop_pcbx.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.StartStop_pcbx_PreviewKeyDown);
            // 
            // Help_ttip
            // 
            this.Help_ttip.IsBalloon = true;
            this.Help_ttip.Tag = "";
            this.Help_ttip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Help_ttip.ToolTipTitle = "Tanks 1.0";
            // 
            // ControllerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(372, 343);
            this.Controls.Add(this.StartStop_pcbx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControllerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tanks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControllerMainForm_FormClosing);
            this.Click += new System.EventHandler(this.btnStartStop_Click);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ControllerMainForm_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.StartStop_pcbx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox StartStop_pcbx;
        private System.Windows.Forms.ToolTip Help_ttip;

    }
}

