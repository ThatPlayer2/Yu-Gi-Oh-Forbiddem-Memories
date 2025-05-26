using System.Resources;

namespace Yu_Gi_Oh_FM_Save_Editor
{
    partial class Save
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Save));
            buttonCards = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            numericUpDownStarChip = new NumericUpDown();
            labelStarChip = new Label();
            button1 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStarChip).BeginInit();
            SuspendLayout();
            // 
            // buttonCards
            // 
            buttonCards.Location = new Point(6, 91);
            buttonCards.Name = "buttonCards";
            buttonCards.Size = new Size(116, 23);
            buttonCards.TabIndex = 0;
            buttonCards.Text = "Give Me All Cards";
            buttonCards.UseVisualStyleBackColor = true;
            buttonCards.Click += buttonCards_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(255, 148);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(numericUpDownStarChip);
            tabPage1.Controls.Add(labelStarChip);
            tabPage1.Controls.Add(buttonCards);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(247, 120);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Yu-Gi-Oh";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownStarChip
            // 
            numericUpDownStarChip.Location = new Point(64, 13);
            numericUpDownStarChip.Name = "numericUpDownStarChip";
            numericUpDownStarChip.Size = new Size(120, 23);
            numericUpDownStarChip.TabIndex = 2;
            numericUpDownStarChip.ValueChanged += numericUpDownStarChip_ValueChanged;
            // 
            // labelStarChip
            // 
            labelStarChip.AutoSize = true;
            labelStarChip.Location = new Point(6, 15);
            labelStarChip.Name = "labelStarChip";
            labelStarChip.Size = new Size(52, 15);
            labelStarChip.TabIndex = 1;
            labelStarChip.Text = "StarChip";
            // 
            // button1
            // 
            button1.Location = new Point(188, 166);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Save
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 194);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Save";
            Text = "Save";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStarChip).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCards;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private NumericUpDown numericUpDownStarChip;
        private Label labelStarChip;
        private Button button1;
    }
}