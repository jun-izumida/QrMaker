using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;

namespace QrMaker
{
    public partial class Form1 : Form
    {
        BarcodeWriter qrcode;
        public Form1()
        {
            InitializeComponent();

            qrcode = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.QrCode.QrCodeEncodingOptions
                {
                    ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.M,
                    CharacterSet = "Shift_JIS",
                    Height = 120,
                    Width = 120,
                    Margin = 4
                }
            };
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void handleTextChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            if (textbox.Text.Length > 0)
            {
                pictureBox1.Image = qrcode.Write(textbox.Text);
            } else
            {
                pictureBox1.Image = null;
            }
        }
    }
}
