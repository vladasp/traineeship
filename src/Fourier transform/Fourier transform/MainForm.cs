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


namespace FourierTransform
{
    
    public partial class MainForm : Form
    {
        
        string reference;
        //Primiry function name on chart
        string primiryFuncName = "f(x)";
        //Transformed function name on chart      
        string transformedFuncName = "F(x)";  
        int borderWidthLine = 7;
        public MainForm()
        {
            InitializeComponent();
            primiryChart.Series.Add(primiryFuncName);
            primiryChart.Series[primiryFuncName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            primiryChart.Series[primiryFuncName].Color = Color.DarkRed;
            primiryChart.Series[primiryFuncName].BorderWidth = borderWidthLine;
            transformedChart.Series.Add(transformedFuncName);
            transformedChart.Series[transformedFuncName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            transformedChart.Series[transformedFuncName].Color = Color.DarkRed;
            transformedChart.Series[transformedFuncName].BorderWidth = borderWidthLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (primiryChart.Series[primiryFuncName].Points.Count != 0) primiryChart.Series[primiryFuncName].Points.Clear();
            if (transformedChart.Series[transformedFuncName].Points.Count != 0) transformedChart.Series[transformedFuncName].Points.Clear();
            openTxtFileDialog.Filter = "Txt|*.txt";
            openTxtFileDialog.ShowDialog();
            reference = openTxtFileDialog.FileName;
            textBoxFileName.Text = reference;
            string[] lines = File.ReadAllLines(reference);
            int countLines = 0;
            foreach (string line in lines)
            {
                try
                {
                    countLines++;
                    primiryChart.Series[primiryFuncName].Points.Add(Convert.ToDouble(line));
                }
                catch
                {
                    MessageBox.Show("Can't read line! " + countLines);
                }
                
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
            for (int i = 0; i < dataInputComplex.Length; i++)
            {
                transformedChart.Series[transformedFuncName].Points.Add(FFT.fft(dataInputComplex)[i].Imaginary);
            }
        }
    }
}
