using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;


namespace Fourier_transform
{
    
    public partial class Form1 : Form
    {
        
        string reference;
        public Form1()
        {
            InitializeComponent();
            chart1.Series.Add("f(x)");
            chart1.Series["f(x)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["f(x)"].Color = Color.DarkRed;
            chart1.Series["f(x)"].BorderWidth = 7;
            chart2.Series.Add("F(x)");
            chart2.Series["F(x)"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["F(x)"].Color = Color.DarkRed;
            chart2.Series["F(x)"].BorderWidth = 7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chart1.Series["f(x)"].Points.Count != 0) chart1.Series["f(x)"].Points.Clear();
            if (chart2.Series["F(x)"].Points.Count != 0) chart2.Series["F(x)"].Points.Clear();
            openTxtFileDialog.Filter = "Txt|*.txt";
            openTxtFileDialog.ShowDialog();
            reference = openTxtFileDialog.FileName;
            textBox1.Text = reference;
            string[] lines = File.ReadAllLines(reference);
            foreach (string line in lines)
            {
                chart1.Series["f(x)"].Points.Add(Convert.ToDouble(line));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(reference);
            Complex[] dataInputComplex = new Complex[lines.Length];
            for (int c = 0; c < dataInputComplex.Length; c++)
            {
                dataInputComplex[c] = new Complex(c, Convert.ToDouble(lines[c]));
            }
            FFT Fft = new FFT();
            for (int i = 0; i < dataInputComplex.Length; i++)
            {
                chart2.Series["F(x)"].Points.Add(Fft.fft(dataInputComplex)[i].Imaginary);
            }
        }
    }
}
