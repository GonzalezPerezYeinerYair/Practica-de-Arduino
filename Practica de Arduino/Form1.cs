using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Practica_de_Arduino
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoPort { get; }

        public Form1()
        {
            InitializeComponent();
            ArduinoPort = new SerialPort();
            ArduinoPort.PortName = "COM4";
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();

            this.FormClosing += CerrandoForm1;
            this.btnApagar.Click += Apagar_Click;
            this.btnEncender.Click += Encender_Click;
        }

        private void Apagar_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }

        private void Encender_Click (object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }
       /* private void CerrandoForm1(object sender, EventArgs e)
        {
            if (ArduinoPort.IsOpen) ArduinoPort.Close();

        }*/

        private void CerrandoForm1(object sender, FormClosingEventArgs e)
        {
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
        }
    }
}
 