//////////////////////////////////////////////////////////////////
//  Domestic Telephone System (DTS)                             //
//    Written by Masaaki Mizuno, (c) 2007, 2008                 //
//      for K-State Course cis501                               //
//      also for Learning Tree Course, 123P, 230Y               //
//////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DTS_Project
{
    public partial class DTS : Form
    {
        TelephoneDevice telephoneDevice;
        TelephoneController telephoneController;
        TerminalDevice terminalDevice;
        TerminalController terminalController;
        // Add your classes that need initial connections from TelephoneController or 
        // TerminalController objects

        public DTS()
        {
            InitializeComponent();
        }

        private void DTS_Load(object sender, EventArgs e)
        {
            telephoneDevice = new TelephoneDevice();
            telephoneController = new TelephoneController(telephoneDevice);
            terminalDevice = new TerminalDevice();
            terminalController = new TerminalController(terminalDevice);

            // Write code to make necessary object connections to/from the TerminalController
            // and TelephoneController objects in the following static method "Initialize()"
            // in the static class "DTSInitlializer"
            DTSInitializer.Initialize(telephoneController, terminalController);
        }

        private void btnTerminal_Click(object sender, EventArgs e)
        {
            terminalController.Activate();
        }

        private void btnTelephone_Click(object sender, EventArgs e)
        {
            telephoneController.Activate();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}