using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        ByteReader bitReader;
        string fileName;

        private void Form1_Load(object sender, EventArgs e)
        {
            bitReader = new ByteReader();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
        }

        private void fileDialog_FileOk(object sender, CancelEventArgs e)
        {
            fileName = fileDialog.FileName;
            txtFile.Text = fileName;

            MidiResults results = bitReader.ReadMidiFile(fileName);

            PrintMidiData(results);
        }

        private void PrintMidiData(MidiResults results)
        {
            rtbData.Clear();

            rtbData.AppendText($"{results.GetData()}");
        }

        

    }
}
