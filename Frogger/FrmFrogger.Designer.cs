namespace Frogger
{
    partial class FrmFrogger
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrGameTick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrGameTick
            // 
            this.tmrGameTick.Tick += new System.EventHandler(this.tmrGameTick_Tick);
            // 
            // FrmFrogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 579);
            this.Location = new System.Drawing.Point(100, 150);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFrogger";
            this.Text = "Frogger";
            this.Load += new System.EventHandler(this.FrmFrogger_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmFrogger_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFrogger_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameTick;
    }
}

