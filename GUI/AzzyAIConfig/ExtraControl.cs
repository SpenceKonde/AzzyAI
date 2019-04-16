// ExtraControl.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains partial class code for the ExtraControl class object.


using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace AzzyAIConfig
{
    public partial class ExtraControl : UserControl
    {
        // These are used to store the file contents of H_Extra.lua and M_Extra.lua respectively
        string _hextra = "";
        string _mextra = "";

        // An event handler for when the contents of either file have been changed
        public event EventHandler ExtraChanged;

        public ExtraControl()
        {
            // Check if the file H_Extra.lua exists
            if (File.Exists("H_Extra.lua"))
            {
                // Read the contents of H_Extra.lua
                _hextra = File.ReadAllText("H_Extra.lua");
            }
           // Check if the file M_Extra.lua exists
           if (File.Exists("M_Extra.lua"))
           {
                // Read the contents of M_Extra.lua
                _mextra = File.ReadAllText("M_Extra.lua");
            }

            InitializeComponent();
        }

        public void Save()
        {
            // Save the contents to H_Extra.lua and M_Extra.lua
            Save("H_Extra.lua", "M_Extra.lua");
        }

        public void Save(string hfile, string mfile)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                _hextra = textBox1.Text;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                _mextra = textBox1.Text;
            }
            // Check if hfile does not exist
            if (!File.Exists(hfile))
            {
                // Create hfile
                File.CreateText(hfile);
            }
            // Check if mfile does not exist
            if (!File.Exists(mfile))
            {
                // Create mfile
                File.CreateText(mfile);
            }

            // Save the contents of each file
            File.WriteAllText(hfile, _hextra);
            File.WriteAllText(mfile, _mextra);
        }

        private void ExtraControl_Load(object sender, EventArgs e)
        {
            // Check if the file H_Extra.lua exists
            if (File.Exists("H_Extra.lua"))
            {
                // Read the contents of H_Extra.lua
                _hextra = File.ReadAllText("H_Extra.lua");
                textBox1.Text = _hextra;
            }
            // Check if the file M_Extra.lua exists
            if (File.Exists("M_Extra.lua"))
            {
                // Read the contents of M_Extra.lua
                _mextra = File.ReadAllText("M_Extra.lua");
            }

            // Remove the event handler from the comboBox1 SelectedIndexChanged event
            comboBox1.SelectedIndexChanged -= new EventHandler(comboBox1_SelectedIndexChanged);

            // Set the comboBox1 selected item to the first item in the list
            comboBox1.SelectedIndex = 0;

            // Add an event handler to the comboBox1 SelectedIndexChanged event
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Remove the event handler from the textBox1 TextChanged event
            textBox1.TextChanged -= new EventHandler(textBox1_TextChanged);

            // Check which item in comboBox1 is selected
            switch (comboBox1.SelectedIndex)
            {
                    // If the item is the first in the item list
                case 0:
                    {
                        // Save the contents of textBox1 to _mextra
                        _mextra = textBox1.Text;
                        // Set the contents of textBox1 to _hextra
                        textBox1.Text = _hextra;
                    } break;

                    // if the item is the second in the item list
                case 1:
                    {
                        // Save the contents of textBox1 to _hextra
                        _hextra = textBox1.Text;
                        // Set the contents of textBox1 to _mextra
                        textBox1.Text = _mextra;
                    } break;
            }

            // Add an event handler to the textBox1 TextChanged event
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Check if the event handler ExtraChanged is not null
            if (ExtraChanged != null)
            {
                // Fire the ExtraChanged event
                ExtraChanged(this, new EventArgs());
            }
        }
    }
}
