using System.Drawing.Text;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using Yu_Gi_Oh_FM_Save_Editor;
using Yu_Gi_Oh_FM_Save_Editor.Crc16;
using Yu_Gi_Oh_FM_Save_Editor.Dictionary;

namespace Yu_Gi_Oh_FB_Save_Editor
{
    public partial class Main : Form
    {
        public byte[] fileBytes;

        public string currentFilePath;

        public Main()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Memcard File (*.mcd)|*.mcd",
                Title = "Select Yu-Gi-Oh Save File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileBytes = File.ReadAllBytes(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < Math.Min(512, fileBytes.Length); i++)
                    {
                        sb.Append(fileBytes[i].ToString("X2")).Append(" ");
                        if ((i + 1) % 16 == 0) sb.AppendLine();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Load file: " + ex.Message);
                }

                byte[] cardQuantities = new byte[720];
                Array.Copy(fileBytes, 0x2250, cardQuantities, 0, 720);
                LoadCard(cardQuantities);
            }
        }

        private void LoadCard(byte[] quantities)
        {
            dataGridViewCards.Rows.Clear();

            for (int i = 0; i < Cards.Carte.Count; i++)
            {
                var card = Cards.Carte[i];

                int quantity = (i < quantities.Length) ? quantities[i] : 0;

                dataGridViewCards.Rows.Add(
                    i,
                    card.ID,
                    card.Name,
                    card.CardType,
                    card.Type,
                    card.Elements,
                    card.Level,
                    card.ATK,
                    card.DEF,
                    card.Password,
                    card.StarchipCost,
                    quantity
                );
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridViewCards.Rows.Count; i++)
                {
                    if (i >= 720) break;

                    DataGridViewRow row = dataGridViewCards.Rows[i];
                    if (row.Cells["Column12"].Value != null && byte.TryParse(row.Cells["Column12"].Value.ToString(), out byte quantity))
                    {
                        fileBytes[0x2250 + i] = quantity;
                    }
                }

                UpdateCRCs(fileBytes);

                File.WriteAllBytes(currentFilePath, fileBytes);

                MessageBox.Show("File Saved.", "Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Save: " + ex.Message);
            }
        }

        private void informationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save saveForm = new Save(this);
            saveForm.Show();
        }

        void UpdateCRCs(byte[] fileBytes)
        {
            // Primo CRC: singolo, MSB → LSB
            {
                int startOffset = 0x2200;
                int endOffset = 0x253D;
                int length = endOffset - startOffset + 1;
                ushort crc = CalculateCustomCRC.CalculateCustomCRC16(fileBytes, startOffset, length);

                fileBytes[0x253E] = (byte)((crc >> 8) & 0xFF);  // MSB
                fileBytes[0x253F] = (byte)(crc & 0xFF);         // LSB

                for (int i = 0x2540; i <= 0x257F; i++)
                {
                    fileBytes[i] = 0x00;
                }
            }

            //Secondo Offset
           
            {
                int startOffset = 0x2600;
                int endOffset = 0x27FD;
                int length = endOffset - startOffset + 1;
                ushort crc = CalculateCustomCRC.CalculateCustomCRC16(fileBytes, startOffset, length);

                fileBytes[0x27FE] = (byte)((crc >> 8) & 0xFF);  // MSB
                fileBytes[0x27FF] = (byte)(crc & 0xFF);         // LSB

                for (int i = 0x2800; i <= 0x282F; i++)
                {
                    fileBytes[i] = 0x00;
                }
            }
     
        }
    }
}
