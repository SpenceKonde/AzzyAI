// HomTactControl.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains partial code for the class HomTactControl, which is
// used as the graphical user interface component for the homunculus tactics
// configurations.

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AzzyAIConfig
{
    public partial class HomTactControl : UserControl
    {
        // The default homunculus tactics file
        string _file = "H_Tactics.lua";

        // An event handler for when the tactics have been changed
        public event EventHandler TacticsChanged;

        public HomTactControl()
        {
            // Check if the file does not exist
            if (File.Exists(_file))
            {

                H_Tactics.Load(_file);
                // Throw a new file not found exception
                //throw new FileNotFoundException("Default file could not be located.", _file);
            }

            // Load the homunculus tactics from the file

            // Pregenerated designer code
            InitializeComponent();
        }

        public HomTactControl(string file)
        {
            // Check if the file does not exist
            if (!File.Exists(file))
            {
                // Throw a new file not found exception
                throw new FileNotFoundException("Specified file could not be located.", file);
            }
            // Set the file
            _file = file;

            // Load the homunculus tactics from the file
            H_Tactics.Load(_file);

            // Pregenerated designer code
            InitializeComponent();
        }

        public void Save()
        {
            // Save the file
            Save(_file);
        }

        public void Save(string file)
        {
            // Check if the file does not exist
            if (!File.Exists(file))
            {
                // Create the file
                File.CreateText(file);
            }

            // Save the file
            H_Tactics.Save(file);
        }

        public void Open(string file)
        {
            // Load the homunculus tactics from the file
            H_Tactics.Load(file);

            // Create a new array of tactics objects
            Tact[] items = new Tact[H_Tactics.Tactics.Count];

            // Copy the H_Tactics tactics to the new array
            H_Tactics.Tactics.CopyTo(items, 0);

            // Clear the listBoxTactics items list
            listBoxTactics.Items.Clear();

            // Add the new array of tactics to the listBoxTactics items list
            listBoxTactics.Items.AddRange(items);

            // Select the first item in the listBoxTactics items list
            listBoxTactics.SelectedIndex = 0;
        }
        #region Private Properties
        private int TACT_ID
        {
            get
            {
                return Convert.ToInt32(textBoxID.Text);
            }
            set
            {
                textBoxID.Text = value.ToString();
            }
        }

        private string TACT_NAME
        {
            get
            {
                return textBoxName.Text;
            }
            set
            {
                textBoxName.Text = value;
            }
        }

        private TACT_BASIC TACT_BASIC
        {
            get
            {
                switch (comboBoxBasic.SelectedIndex)
                {
                    case 0:
                        return TACT_BASIC.TACT_TANK;
                    case 1:
                        return TACT_BASIC.TACT_IGNORE;
                    case 2:
                        return TACT_BASIC.TACT_ATTACK_L;
                    case 3:
                        return TACT_BASIC.TACT_ATTACK_M;
                    case 4:
                        return TACT_BASIC.TACT_ATTACK_H;
                    case 5:
                        return TACT_BASIC.TACT_REACT_L;
                    case 6:
                        return TACT_BASIC.TACT_REACT_M;
                    case 7:
                        return TACT_BASIC.TACT_REACT_H;
                    case 8:
                        return TACT_BASIC.TACT_REACT_SELF;
                    case 9:
                        return TACT_BASIC.TACT_SNIPE_L;
                    case 10:
                        return TACT_BASIC.TACT_SNIPE_M;
                    case 11:
                        return TACT_BASIC.TACT_SNIPE_H;
                    case 12:
                        return TACT_BASIC.TACT_ATK_L_REACT_M;
                    case 13:
                        return TACT_BASIC.TACT_ATTACK_LAST;
                    case 14:
                        return TACT_BASIC.TACT_ATTACK_TOP;
                }
                return TACT_BASIC.TACT_IGNORE;
            }
            set
            {
                switch (value)
                {
                    case TACT_BASIC.TACT_TANK:
                        {
                            comboBoxBasic.SelectedIndex = 0;
                        } break;
                    case TACT_BASIC.TACT_IGNORE:
                        {
                            comboBoxBasic.SelectedIndex = 1;
                        } break;
                    case TACT_BASIC.TACT_ATTACK_L:
                        {
                            comboBoxBasic.SelectedIndex = 2;
                        } break;
                    case TACT_BASIC.TACT_ATTACK_M:
                        {
                            comboBoxBasic.SelectedIndex = 3;
                        } break;
                    case TACT_BASIC.TACT_ATTACK_H:
                        {
                            comboBoxBasic.SelectedIndex = 4;
                        } break;
                    case TACT_BASIC.TACT_REACT_L:
                        {
                            comboBoxBasic.SelectedIndex = 5;
                        } break;
                    case TACT_BASIC.TACT_REACT_M:
                        {
                            comboBoxBasic.SelectedIndex = 6;
                        } break;
                    case TACT_BASIC.TACT_REACT_H:
                        {
                            comboBoxBasic.SelectedIndex = 7;
                        } break;
                    case TACT_BASIC.TACT_REACT_SELF:
                        {
                            comboBoxBasic.SelectedIndex = 8;
                        } break;
                    case TACT_BASIC.TACT_SNIPE_L:
                        {
                            comboBoxBasic.SelectedIndex = 9;
                        } break;
                    case TACT_BASIC.TACT_SNIPE_M:
                        {
                            comboBoxBasic.SelectedIndex = 10;
                        } break;
                    case TACT_BASIC.TACT_SNIPE_H:
                        {
                            comboBoxBasic.SelectedIndex = 11;
                        } break;
                    case TACT_BASIC.TACT_ATK_L_REACT_M:
                        {
                            comboBoxBasic.SelectedIndex = 12;
                        } break;
                    case TACT_BASIC.TACT_ATTACK_LAST:
                        {
                            comboBoxBasic.SelectedIndex = 13;
                        } break;
                    case TACT_BASIC.TACT_ATTACK_TOP:
                        {
                            comboBoxBasic.SelectedIndex = 14;
                        } break;
                }
            }
        }

        private TACT_CAST TACT_CAST
        {
            get
            {
                switch (comboBoxReact.SelectedIndex)
                {
                    case 0:
                        return TACT_CAST.CAST_PASSIVE;
                    case 1: 
                        return TACT_CAST.CAST_REACT;
                    case 2:
                        return TACT_CAST.CAST_REACT_ANY;
                    case 3:
                        return TACT_CAST.CAST_REACT_BREEZE;
                    case 4:
                        return TACT_CAST.CAST_REACT_MAIN;
                    case 5:
                        return TACT_CAST.CAST_REACT_S;
                    case 6:
                        return TACT_CAST.CAST_REACT_MOB;
                    case 7:
                        return TACT_CAST.CAST_REACT_DEBUFF;
                    case 8:
                        return TACT_CAST.CAST_REACT_MINION;
                }
                return TACT_CAST.CAST_PASSIVE;
            }
            set
            {
                switch(value)
                {
                    case TACT_CAST.CAST_PASSIVE:
                        {
                        comboBoxReact.SelectedIndex = 0;
                        } break;
                    case TACT_CAST.CAST_REACT:
                        {
                        comboBoxReact.SelectedIndex = 1;
                        } break;
                    case TACT_CAST.CAST_REACT_ANY:
                        {
                            comboBoxReact.SelectedIndex = 2;
                        } break;
                    case TACT_CAST.CAST_REACT_BREEZE:
                        {
                            comboBoxReact.SelectedIndex = 3;
                        } break;
                    case TACT_CAST.CAST_REACT_MAIN:
                        {
                            comboBoxReact.SelectedIndex = 4;
                        } break;
                    case TACT_CAST.CAST_REACT_S:
                        {
                            comboBoxReact.SelectedIndex = 5;
                        } break;
                    case TACT_CAST.CAST_REACT_MOB:
                        {
                            comboBoxReact.SelectedIndex = 6;
                        } break;
                    case TACT_CAST.CAST_REACT_DEBUFF:
                        {
                            comboBoxReact.SelectedIndex = 7;
                        } break;
                    case TACT_CAST.CAST_REACT_MINION:
                        {
                            comboBoxReact.SelectedIndex = 8;
                        } break;

                }
            }
        }

        private TACT_SNIPE TACT_SNIPE
        {
            get
            {
                if (checkBoxFfa.Checked)
                {
                    return TACT_SNIPE.SNIPE_OK;
                }
                return TACT_SNIPE.SNIPE_DISABLE;
            }
            set
            {
                if (value == TACT_SNIPE.SNIPE_OK)
                {
                    checkBoxFfa.Checked = true;
                }
                else
                {
                    checkBoxFfa.Checked = false;
                }
            }
        }
        private TACT_KS TACT_KS
        {
            get
            {
                switch (comboBoxKS.SelectedIndex)
                {
                    case 0:
                        return TACT_KS.KS_NEVER;
                    case 1:
                        return TACT_KS.KS_ALWAYS;
                    case 2:
                        return TACT_KS.KS_POLITE;
                }
                return TACT_KS.KS_NEVER;
            }
            set
            {
                switch (value)
                {
                    case TACT_KS.KS_NEVER:
                        {
                            comboBoxKS.SelectedIndex = 0;
                        } break;
                    case TACT_KS.KS_ALWAYS:
                        {
                            comboBoxKS.SelectedIndex = 1;
                        } break;
                    case TACT_KS.KS_POLITE:
                        {
                            comboBoxKS.SelectedIndex = 2;
                        } break;
                }
            }
        }

        private string TACT_SKILL
        {
            get
            {
                switch (comboBoxSkill.SelectedIndex)
                {
                    case 0:
                        return "SKILL_ALWAYS";
                    case 1:
                        return "SKILL_NEVER";
                    case 2:
                        return numericUpDownSkill.Value.ToString();
                    case 3:
                        return (0 - (int)numericUpDownSkill.Value).ToString();
                }
                return "SKILL_ALWAYS";
            }
            set
            {
                
                if (value == "SKILL_NEVER")
                {
                    comboBoxSkill.SelectedIndex = 1;
                    numericUpDownSkill.Enabled = false;
                    numericUpDownSkill.Minimum = 0;
                    numericUpDownSkill.Maximum = 100;
                    numericUpDownSkill.Value = 0;
                }
                else if (value == "SKILL_ALWAYS")
                {
                    comboBoxSkill.SelectedIndex = 0;
                    numericUpDownSkill.Enabled = false;
                    numericUpDownSkill.Minimum = 0;
                    numericUpDownSkill.Maximum = 100;
                    numericUpDownSkill.Value = 100;
                }
                else if (Convert.ToInt32(value) < 0)
                {
                    comboBoxSkill.SelectedIndex = 3;
                    numericUpDownSkill.Enabled = true;
                    numericUpDownSkill.Minimum = 1;
                    numericUpDownSkill.Maximum = 5;
                    if (Convert.ToInt32(value) < -5)
                    {
                        numericUpDownSkill.Value = 5;
                    }
                    else
                    {
                        numericUpDownSkill.Value = 0 - Convert.ToInt32(value);
                    }
                }
                else if (Convert.ToInt32(value) > 0 && Convert.ToInt32(value) < 100)
                {
                    comboBoxSkill.SelectedIndex = 2;
                    numericUpDownSkill.Enabled = true;
                    numericUpDownSkill.Minimum = 0;
                    numericUpDownSkill.Maximum = 100;
                    numericUpDownSkill.Value = Convert.ToInt32(value);
                }
            }
        }
        private int TACT_SP
        {
            get
            {
                return Convert.ToInt32(numericUpDownSP.Value);
            }
            set
            {
                numericUpDownSP.Value = Convert.ToDecimal(value);
            }
        }
        private decimal TACT_WEIGHT
        {
            get
            {
                return numericUpDownWeight.Value;
            }
            set
            {
                numericUpDownWeight.Value = value;
            }
        }
        private TACT_KITE TACT_KITE
        {
            get
            {
                switch (comboBoxKite.SelectedIndex)
                {
                    case 0:
                        return TACT_KITE.KITE_NEVER;
                    case 1:
                        return TACT_KITE.KITE_REACT;
                    case 2:
                        return TACT_KITE.KITE_ALWAYS;
                }
                return TACT_KITE.KITE_NEVER;
            }
            set
            {
                switch (value)
                {
                    case TACT_KITE.KITE_NEVER:
                        {
                            comboBoxKite.SelectedIndex = 0;
                        } break;
                    case TACT_KITE.KITE_REACT:
                        {
                            comboBoxKite.SelectedIndex = 1;
                        } break;
                    case TACT_KITE.KITE_ALWAYS:
                        {
                            comboBoxKite.SelectedIndex = 2;
                        } break;
                }
            }
        }

        private TACT_SKILLCLASS TACT_SKILLCLASS
        {
            get
            {
                switch (comboBoxSize.SelectedIndex)
                {
                    case 0:
                        return TACT_SKILLCLASS.CLASS_BOTH;
                    case 1:
                        return TACT_SKILLCLASS.CLASS_OLD;
                    case 2:
                        return TACT_SKILLCLASS.CLASS_S;
                    case 3:
                        return TACT_SKILLCLASS.CLASS_MOB;
                    case 4:
                        return TACT_SKILLCLASS.CLASS_COMBO_1;
                    case 5:
                        return TACT_SKILLCLASS.CLASS_COMBO_2;
                    case 6:
                        return TACT_SKILLCLASS.CLASS_MINION;
                    case 7:
                        return TACT_SKILLCLASS.CLASS_GRAPPLE;
                    case 8:
                        return TACT_SKILLCLASS.CLASS_GRAPPLE_1;
                    case 9:
                        return TACT_SKILLCLASS.CLASS_GRAPPLE_2;
                    case 10:
                        return TACT_SKILLCLASS.CLASS_MIN_OLD;
                    case 11:
                        return TACT_SKILLCLASS.CLASS_MIN_S;
                }
                return TACT_SKILLCLASS.CLASS_BOTH;
            }
            set
            {
                switch (value)
                {
                    case TACT_SKILLCLASS.CLASS_BOTH:
                        {
                            comboBoxSize.SelectedIndex = 0;
                        } break;
                    case TACT_SKILLCLASS.CLASS_OLD:
                        {
                            comboBoxSize.SelectedIndex = 1;
                        } break;
                    case TACT_SKILLCLASS.CLASS_S:
                        {
                            comboBoxSize.SelectedIndex = 2;
                        } break;
                    case TACT_SKILLCLASS.CLASS_MOB:
                        {
                            comboBoxSize.SelectedIndex = 3;
                        } break;
                    case TACT_SKILLCLASS.CLASS_COMBO_1:
                        {
                            comboBoxSize.SelectedIndex = 4;
                        } break;
                    case TACT_SKILLCLASS.CLASS_COMBO_2:
                        {
                            comboBoxSize.SelectedIndex = 5;
                        } break;
                    case TACT_SKILLCLASS.CLASS_MINION:
                        {
                            comboBoxSize.SelectedIndex = 6;
                        } break;
                    case TACT_SKILLCLASS.CLASS_GRAPPLE:
                        {
                            comboBoxSize.SelectedIndex = 7;
                        } break;
                    case TACT_SKILLCLASS.CLASS_GRAPPLE_1:
                        {
                            comboBoxSize.SelectedIndex = 8;
                        } break;
                    case TACT_SKILLCLASS.CLASS_GRAPPLE_2:
                        {
                            comboBoxSize.SelectedIndex = 9;
                        } break;
                    case TACT_SKILLCLASS.CLASS_MIN_OLD:
                        {
                            comboBoxSize.SelectedIndex = 10;
                        } break;
                    case TACT_SKILLCLASS.CLASS_MIN_S:
                        {
                            comboBoxSize.SelectedIndex = 11;
                        } break;
                
                }
            }
        }

        private TACT_RESCUE TACT_RESCUE
        {
            get
            {
                switch (comboBoxRescue.SelectedIndex)
                {
                    case 0:
                        return TACT_RESCUE.RESCUE_NEVER;
                    case 1:
                        return TACT_RESCUE.RESCUE_FRIEND;
                    case 2:
                        return TACT_RESCUE.RESCUE_RETAINER;
                    case 3:
                        return TACT_RESCUE.RESCUE_SELF;
                    case 4:
                        return TACT_RESCUE.RESCUE_OWNER;
                    case 5:
                        return TACT_RESCUE.RESCUE_ALL;
                }
                return TACT_RESCUE.RESCUE_NEVER;
            }
            set
            {
                switch (value)
                {
                    case TACT_RESCUE.RESCUE_NEVER:
                        {
                            comboBoxRescue.SelectedIndex = 0;
                        } break;
                    case TACT_RESCUE.RESCUE_FRIEND:
                        {
                            comboBoxRescue.SelectedIndex = 1;
                        } break;
                    case TACT_RESCUE.RESCUE_RETAINER:
                        {
                            comboBoxRescue.SelectedIndex = 2;
                        } break;
                    case TACT_RESCUE.RESCUE_SELF:
                        {
                            comboBoxRescue.SelectedIndex = 3;
                        } break;
                    case TACT_RESCUE.RESCUE_OWNER:
                        {
                            comboBoxRescue.SelectedIndex = 4;
                        } break;
                    case TACT_RESCUE.RESCUE_ALL:
                        {
                            comboBoxRescue.SelectedIndex = 5;
                        } break;
                }
            }
        }
        private TACT_CHASE TACT_CHASE
        {
            get
            {
                switch (comboBoxChase.SelectedIndex)
                {
                    case 0:
                        return TACT_CHASE.CHASE_NORMAL;
                    case 1:
                        return TACT_CHASE.CHASE_ALWAYS;
                    case 2:
                        return TACT_CHASE.CHASE_NEVER;
                    case 3:
                        return TACT_CHASE.CHASE_CLEVER;
                }
                return TACT_CHASE.CHASE_NORMAL;
            }
            set
            {
                switch (value)
                {
                    case TACT_CHASE.CHASE_NORMAL:
                        {
                            comboBoxChase.SelectedIndex = 0;
                        } break;
                    case TACT_CHASE.CHASE_ALWAYS:
                        {
                            comboBoxChase.SelectedIndex = 1;
                        } break;
                    case TACT_CHASE.CHASE_NEVER:
                        {
                            comboBoxChase.SelectedIndex = 2;
                        } break;
                    case TACT_CHASE.CHASE_CLEVER:
                        {
                            comboBoxChase.SelectedIndex = 3;
                        } break;
                }
            }
        }
        private TACT_DEBUFF TACT_DEBUFF
        {
            get
            {
                switch (comboBoxDebuff.SelectedIndex + comboBoxDebuff2.SelectedIndex*3)
                {
                    case 0:
                        return TACT_DEBUFF.DEBUFF_NEVER;
                    case 1:
                        return TACT_DEBUFF.DEBUFF_ANY_C;
                    case 2:
                        return TACT_DEBUFF.DEBUFF_BREEZE_C;
                    case 3:
                        return TACT_DEBUFF.DEBUFF_ASH_C;
                    case 4:
                        return TACT_DEBUFF.DEBUFF_ANY_A;
                    case 5:
                        return TACT_DEBUFF.DEBUFF_BREEZE_A;
                    case 6:
                        return TACT_DEBUFF.DEBUFF_ASH_C;
                }
                return TACT_DEBUFF.DEBUFF_NEVER;
            }
            set
            {
                switch (value)
                {
                    case TACT_DEBUFF.DEBUFF_NEVER:
                        {
                            comboBoxDebuff.SelectedIndex = 0;
                            comboBoxDebuff2.SelectedIndex = 0;
                        } break;
                    case TACT_DEBUFF.DEBUFF_ANY_C:
                        {
                            comboBoxDebuff.SelectedIndex = 1;
                            comboBoxDebuff2.SelectedIndex = 0;
                        } break;
                    case TACT_DEBUFF.DEBUFF_BREEZE_C:
                        {
                            comboBoxDebuff.SelectedIndex = 2;
                            comboBoxDebuff2.SelectedIndex = 0;
                        } break;
                    case TACT_DEBUFF.DEBUFF_ASH_C:
                        {
                            comboBoxDebuff.SelectedIndex = 3;
                            comboBoxDebuff2.SelectedIndex = 0;
                        } break;
                    case TACT_DEBUFF.DEBUFF_ANY_A:
                        {
                            comboBoxDebuff.SelectedIndex = 1;
                            comboBoxDebuff2.SelectedIndex = 1;
                        } break;
                    case TACT_DEBUFF.DEBUFF_BREEZE_A:
                        {
                            comboBoxDebuff.SelectedIndex = 2;
                            comboBoxDebuff2.SelectedIndex = 1;
                        } break;
                    case TACT_DEBUFF.DEBUFF_ASH_A:
                        {
                            comboBoxDebuff.SelectedIndex = 3;
                            comboBoxDebuff2.SelectedIndex = 1;
                        } break;
                }
            }
        }
        #endregion

        private void HomTactControl_Load(object sender, EventArgs e)
        {
            // Create a new array of tactics objects
            Tact[] items = new Tact[H_Tactics.Tactics.Count];

            // Copy the H_Tactics tactics to the new array
            H_Tactics.Tactics.CopyTo(items, 0);

            // Add the new array of tactics to the listBoxTactics items list
            listBoxTactics.Items.AddRange(items);

            // Select  the first item in the listBoxTactics items list
            listBoxTactics.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Create a new tactic object
            Tact t = new Tact(1);

            // Add the new tactic to H_Tactics and the listBoxTactics items list
            H_Tactics.Tactics.Add(t);
            listBoxTactics.Items.Add(t);

            // Select the new tactic
            listBoxTactics.SelectedItem = t;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            // Check if the listBoxTactics selected item is not null
            if (listBoxTactics.SelectedItem != null)
            {
                // Get the listBoxTactics selected index
                int i = listBoxTactics.SelectedIndex;

                // Get the listBoxTactics selected tactic
                Tact t = (Tact)listBoxTactics.SelectedItem;

                // Remove the selected tactic from H_Tactics and the listBoxTactics items list
                H_Tactics.Tactics.Remove(t);
                listBoxTactics.Items.Remove(t);

                // Check if the selected index is less than the number of items in the listBoxTactics items list
                if (i < listBoxTactics.Items.Count)
                {
                    // Reset the listBoxTactics selected index
                    listBoxTactics.SelectedIndex = i;
                }
                // If the selected index is not less than the number of items in the listBoxTactics items list
                else
                {
                    // Reset the listBoxTactics selected index to the previous index
                    listBoxTactics.SelectedIndex = i - 1;
                }

                // Check if the TacticsChanged event handler is not null
                if (TacticsChanged != null)
                {
                    // Raise the TacticsChanged event
                    TacticsChanged(this, new EventArgs());
                }
            }
        }

        private void listBoxTactics_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Remove event handlers
            buttonAdd.Click -= new EventHandler(buttonAdd_Click);
            buttonRemove.Click -= new EventHandler(buttonRemove_Click);
            textBoxName.TextChanged -= new EventHandler(textBoxName_TextChanged);
            textBoxID.TextChanged -= new EventHandler(textBoxID_TextChanged);
            comboBoxBasic.SelectedIndexChanged -= new EventHandler(comboBoxBasic_SelectedIndexChanged);
            comboBoxReact.SelectedIndexChanged -= new EventHandler(comboBoxReact_SelectedIndexChanged);
            checkBoxFfa.CheckedChanged -= new EventHandler(checkBoxFfa_CheckedChanged);
            comboBoxSkill.SelectedIndexChanged -= new EventHandler(comboBoxSkill_SelectedIndexChanged);
            numericUpDownSkill.ValueChanged -= new EventHandler(numericUpDownSkill_ValueChanged);
            comboBoxKite.SelectedIndexChanged -= new EventHandler(comboBoxKite_SelectedIndexChanged);
            comboBoxSize.SelectedIndexChanged -= new EventHandler(comboBoxSize_SelectedIndexChanged);
            comboBoxRescue.SelectedIndexChanged -= new EventHandler(comboBoxRescue_SelectedIndexChanged);
            numericUpDownSP.ValueChanged -= new EventHandler(numericUpDownSP_ValueChanged);
            numericUpDownWeight.ValueChanged -= new EventHandler(numericUpDownWeight_ValueChanged);
            comboBoxChase.SelectedIndexChanged -= new EventHandler(comboBoxChase_SelectedIndexChanged);
            comboBoxKS.SelectedIndexChanged -= new EventHandler(comboBoxKS_SelectedIndexChanged);
            comboBoxDebuff2.SelectedIndexChanged -= new EventHandler(comboBoxDebuff2_SelectedIndexChanged);

            // Check if the listBoxTactics selected item is not null
            if (listBoxTactics.SelectedItem != null)
            {
                // Get the listBoxTactics selected tactic
                Tact t = (Tact)listBoxTactics.SelectedItem;

                // Update the graphical user interface with the values of the current tactic
                TACT_ID = t.ID;
                TACT_NAME = t.Name;
                TACT_BASIC = t.TACT_BASIC;
                TACT_CAST = t.TACT_CAST;
                TACT_KS = t.TACT_KS;
                TACT_SKILL = t.TACT_SKILL;
                TACT_KITE = t.TACT_KITE;
                TACT_SKILLCLASS = t.TACT_SKILLCLASS;
                TACT_RESCUE = t.TACT_RESCUE;
                TACT_SNIPE = t.TACT_SNIPE;
                TACT_WEIGHT = t.TACT_WEIGHT;
                TACT_CHASE = t.TACT_CHASE;
                TACT_DEBUFF = t.TACT_DEBUFF;
                TACT_SP = t.TACT_SP;

                // Check if the TACT_ID is 0
                if (TACT_ID == 0)
                {
                    // Disable buttonRemove, textBoxName, and textBoxID
                    buttonRemove.Enabled = false;
                    textBoxName.Enabled = false;
                    textBoxID.Enabled = false;
                }
                // If the TACT_ID is not 0
                else
                {
                    // Enable buttonRemove, textBoxName, and textBoxID
                    buttonRemove.Enabled = true;
                    textBoxName.Enabled = true;
                    textBoxID.Enabled = true;
                }
            }

            // Add event handlers
            buttonAdd.Click += new EventHandler(buttonAdd_Click);
            buttonRemove.Click += new EventHandler(buttonRemove_Click);
            textBoxName.TextChanged += new EventHandler(textBoxName_TextChanged);
            textBoxID.TextChanged += new EventHandler(textBoxID_TextChanged);
            comboBoxBasic.SelectedIndexChanged += new EventHandler(comboBoxBasic_SelectedIndexChanged);
            comboBoxReact.SelectedIndexChanged += new EventHandler(comboBoxReact_SelectedIndexChanged);
            checkBoxFfa.CheckedChanged += new EventHandler(checkBoxFfa_CheckedChanged);
            comboBoxSkill.SelectedIndexChanged += new EventHandler(comboBoxSkill_SelectedIndexChanged);
            numericUpDownSkill.ValueChanged += new EventHandler(numericUpDownSkill_ValueChanged);
            comboBoxKite.SelectedIndexChanged += new EventHandler(comboBoxKite_SelectedIndexChanged);
            comboBoxSize.SelectedIndexChanged += new EventHandler(comboBoxSize_SelectedIndexChanged);
            comboBoxRescue.SelectedIndexChanged += new EventHandler(comboBoxRescue_SelectedIndexChanged);
            numericUpDownSP.ValueChanged += new EventHandler(numericUpDownSP_ValueChanged);
            numericUpDownWeight.ValueChanged += new EventHandler(numericUpDownWeight_ValueChanged);
            comboBoxChase.SelectedIndexChanged += new EventHandler(comboBoxChase_SelectedIndexChanged);
            comboBoxKS.SelectedIndexChanged += new EventHandler(comboBoxKS_SelectedIndexChanged);
            comboBoxDebuff2.SelectedIndexChanged += new EventHandler(comboBoxDebuff2_SelectedIndexChanged);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic name
            t.Name = TACT_NAME;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic ID
            t.ID = TACT_ID;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxBasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_BASIC
            t.TACT_BASIC = TACT_BASIC;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxReact_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_CAST
            t.TACT_CAST = TACT_CAST;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void checkBoxFfa_CheckedChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_KS
            t.TACT_SNIPE = TACT_SNIPE;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_SKILL
            t.TACT_SKILL = TACT_SKILL;

            switch (comboBoxSkill.SelectedIndex)
            {
                // If the comboBoxSkill selected index is 0
                case 0:
                    {
                        numericUpDownSkill.Enabled = false;
                    }break;
                case 1:
                    {
                        numericUpDownSkill.Enabled = false;
                    }break;
                // If the comboBoxSkill selected index is 2
                case 2:
                    {
                        numericUpDownSkill.Enabled = true;
                        // Set the numericUpDownSkill minimum to 0
                        numericUpDownSkill.Minimum = 0;

                        // Set the numericUpDownSkill maximum to 100
                        numericUpDownSkill.Maximum = 100;
                    } break;
                // If the comboBoxSkill selected index is 3
                case 3:
                    {
                        numericUpDownSkill.Value = 5;
                        numericUpDownSkill.Enabled = true;
                        // Set the numericUpDownSkill minimum to 1
                        numericUpDownSkill.Minimum = 1;
                        // Set the numericUpDownSkill maximum to 5
                        numericUpDownSkill.Maximum = 5;
                    } break;
            }
            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void numericUpDownSkill_ValueChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_SKILL
            t.TACT_SKILL = TACT_SKILL;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxKite_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_KITE
            t.TACT_KITE = TACT_KITE;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_SKILLCLASS
            t.TACT_SKILLCLASS = TACT_SKILLCLASS;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxRescue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_RESCUE
            t.TACT_RESCUE = TACT_RESCUE;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }



        private void textBoxName_Validated(object sender, EventArgs e)
        {
            // Check if the textBoxName text is empty
            if (textBoxName.Text == "")
            {
                // Popup an error message for the monster name
                MessageBox.Show("You must enter a monster name.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Change the focus to the textBoxName
                textBoxName.Focus();
            }
            // If the textBoxName text is not empty
            else
            {
                // Update the listBoxTactics to redraw the control
                listBoxTactics.Update();
            }
        }

        private void textBoxID_Validated(object sender, EventArgs e)
        {
            // Run through each object in the listBoxTactics items list
            foreach (object item in listBoxTactics.Items)
            {
                // Check if the current item is not the listBoxTactics selected item
                if (item != listBoxTactics.SelectedItem)
                {
                    // Convert the item to a tactic object
                    Tact t = (Tact)item;

                    // Check if the tactic ID is equal to TACT_ID
                    if (t.ID == TACT_ID)
                    {
                        // Popup an error message for the monster ID
                        MessageBox.Show("You must enter a unique monster ID", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Change the focus to the textBoxID
                        textBoxID.Focus();

                        // Break out of the loop
                        break;
                    }
                }
            }
        }

        private void comboBoxChase_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                // Get the listBoxTactics selected tactic
                Tact t = (Tact)listBoxTactics.SelectedItem;

                // Update the tactic TACT_KITE
                t.TACT_CHASE = TACT_CHASE;

                // Check if the TacticsChanged event handler is not null
                if (TacticsChanged != null)
                {
                    // Raise the TacticsChanged event
                    TacticsChanged(this, new EventArgs());
                }
            }
        }

        private void comboBoxKS_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                // Get the listBoxTactics selected tactic
                Tact t = (Tact)listBoxTactics.SelectedItem;

                // Update the tactic TACT_KITE
                t.TACT_KS = TACT_KS;

                // Check if the TacticsChanged event handler is not null
                if (TacticsChanged != null)
                {
                    // Raise the TacticsChanged event
                    TacticsChanged(this, new EventArgs());
                }
            }
        }

        private void numericUpDownSP_ValueChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_KITE
            t.TACT_SP = TACT_SP;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void numericUpDownWeight_ValueChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_KITE
            t.TACT_WEIGHT = TACT_WEIGHT;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxDebuff_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_KITE
            t.TACT_DEBUFF = TACT_DEBUFF;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }
        private void comboBoxDebuff2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            Tact t = (Tact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_KITE
            t.TACT_DEBUFF = TACT_DEBUFF;

            // Check if the TacticsChanged event handler is not null
            if (TacticsChanged != null)
            {
                // Raise the TacticsChanged event
                TacticsChanged(this, new EventArgs());
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxReact_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

    }
}
