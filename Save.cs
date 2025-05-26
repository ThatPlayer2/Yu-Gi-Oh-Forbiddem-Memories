using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yu_Gi_Oh_FB_Save_Editor;
using Yu_Gi_Oh_FM_Save_Editor.Crc16;

namespace Yu_Gi_Oh_FM_Save_Editor
{
    public partial class Save : Form
    {
        private Main mainForm;
        public Save(Main callingForm)
        {
            InitializeComponent();
            mainForm = callingForm;
            Settings();
            LoadStarchipValue();
        }

        private void buttonCards_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in mainForm.dataGridViewCards.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["Column12"].Value = 1;
                }
            }

            MessageBox.Show("All Cards Obteined");
        }

        private void LoadStarchipValue()
        {       
            int value = mainForm.fileBytes[0x27E0] | (mainForm.fileBytes[0x27E1] << 8)| (mainForm.fileBytes[0x27E2] << 16);
            numericUpDownStarChip.ValueChanged -= numericUpDownStarChip_ValueChanged;
            numericUpDownStarChip.Value = Math.Min(value, numericUpDownStarChip.Maximum);
            numericUpDownStarChip.ValueChanged += numericUpDownStarChip_ValueChanged;
        }

        private void numericUpDownStarChip_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)numericUpDownStarChip.Value;

            mainForm.fileBytes[0x27E0] = (byte)(value & 0xFF);
            mainForm.fileBytes[0x27E1] = (byte)((value >> 8) & 0xFF);
            mainForm.fileBytes[0x27E2] = (byte)((value >> 16) & 0xFF);

        }


        public void Settings()
        {
            numericUpDownStarChip.Minimum = 0;
            numericUpDownStarChip.Maximum = 999999;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
