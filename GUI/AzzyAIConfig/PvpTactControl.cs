// PvpTactControl.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains partial code for the PvpTactControl class, which is
// used as the graphical user interface object for PVP_Tact.

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
    public partial class PvpTactControl : UserControl
    {
        // The default configuration file
        string _file = "H_PVP_Tact.lua";

        // An event handler for when the tactics are changed
        public event EventHandler PvpTacticsChanged;

        public PvpTactControl()
        {
            // Check if the file does not exist
            if (File.Exists(_file))
            {
                PVP_Tact.Load(_file);
            }
            else
            {
                // Throw a new file not found exception
                // throw new FileNotFoundException("Default file could not be located.", _file);
            }


            // Pregenerated designer code
            InitializeComponent();
        }

        public PvpTactControl(string file)
        {
            // Check if the file does not exist
            if (!File.Exists(file))
            {
                // Throw a new file not found exception
                throw new FileNotFoundException("Specified file could not be located.", file);
            }

            // Set the file
            _file = file;

            // Load the configurations
            PVP_Tact.Load(_file);

            // Pregenerated designer code
            InitializeComponent();
        }

        public void Save()
        {
            // Save the file
            PVP_Tact.Save(_file);
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
            PVP_Tact.Save(file);
        }

        public void Open(string file)
        {
            // Load the configurations from the file
            PVP_Tact.Load(file);

            // Create a new tactics array
            PvpTact[] items = new PvpTact[PVP_Tact.Tactics.Count];

            // Copy the old tactics to the new array
            PVP_Tact.Tactics.CopyTo(items, 0);

            // Clear the listBoxTactics items list
            listBoxTactics.Items.Clear();

            // Add the new tactics array to the listBoxTactics items array
            listBoxTactics.Items.AddRange(items);

            // Set the listBoxTactics selected index to 0
            listBoxTactics.SelectedIndex = 0;
        }

        #region Private Properties
        private string TACT_ID
        {
            get
            {
                return textBoxID.Text;
            }
            set
            {
                textBoxID.Text = value;
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
                switch (value)
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


        private TACT_DEBUFF TACT_DEBUFF
        {
            get
            {
                switch (comboBoxDebuff.SelectedIndex + comboBoxDebuff2.SelectedIndex * 2)
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
                    numericUpDownSkill.Value = Convert.ToInt32(0);
                }
                else if (value == "SKILL_ALWAYS")
                {
                    comboBoxSkill.SelectedIndex = 0;
                    numericUpDownSkill.Enabled = false;
                    numericUpDownSkill.Value = 100;
                }
                else if (Convert.ToInt32(value) < 0)
                {
                    comboBoxSkill.SelectedIndex = 3;
                    numericUpDownSkill.Enabled = true;
                    numericUpDownSkill.Value = Convert.ToInt32(value);
                }
                else if (Convert.ToInt32(value) > 0 && Convert.ToInt32(value) < 100)
                {
                    comboBoxSkill.SelectedIndex = 2;
                    numericUpDownSkill.Enabled = true;
                    numericUpDownSkill.Value = Convert.ToInt32(value);
                }
            }
        }

        private TACT_PUSHBACK TACT_PUSHBACK
        {
            get
            {
                switch (comboBoxPushback.SelectedIndex)
                {
                    case 0:
                        return TACT_PUSHBACK.PUSH_NEVER;
                    case 1:
                        return TACT_PUSHBACK.PUSH_SELF;
                    case 2:
                        return TACT_PUSHBACK.PUSH_FRIEND;
                }
                return TACT_PUSHBACK.PUSH_NEVER;
            }
            set
            {
                switch (value)
                {
                    case TACT_PUSHBACK.PUSH_NEVER:
                        {
                            comboBoxPushback.SelectedIndex = 0;
                        } break;
                    case TACT_PUSHBACK.PUSH_SELF:
                        {
                            comboBoxPushback.SelectedIndex = 1;
                        } break;
                    case TACT_PUSHBACK.PUSH_FRIEND:
                        {
                            comboBoxPushback.SelectedIndex = 2;
                        } break;
                }
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
        #endregion

        private void PvpTactControl_Load(object sender, EventArgs e)
        {
            // Create a new tactics array
            PvpTact[] items = new PvpTact[PVP_Tact.Tactics.Count];

            // Copy the old tactics to the new array
            PVP_Tact.Tactics.CopyTo(items, 0);

            // Clear the listBoxTactics items list
            listBoxTactics.Items.Clear();

            // Add the new tactics array to the listBoxTactics items array
            listBoxTactics.Items.AddRange(items);

            // Set the listBoxTactics selected index to 0
            listBoxTactics.SelectedIndex = 0;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Create a new tactic object
            PvpTact t = new PvpTact("new");

            // Add the new tactic to H_Tactics and the listBoxTactics items list
            PVP_Tact.Tactics.Add(t);
            listBoxTactics.Items.Add(t);

            // Select the new tactic
            listBoxTactics.SelectedItem = t;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
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
                PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

                // Remove the tactic from PVP_Tact and the listBoxTactics items list
                PVP_Tact.Tactics.Remove(t);
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

                // Check if the PvpTacticsChanged event handler is not null
                if (PvpTacticsChanged != null)
                {
                    // Raise the PvpTacticsChanged event
                    PvpTacticsChanged(this, new EventArgs());
                }
            }
        }

        private void listBoxTactics_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Remove event handlers
            buttonAdd.Click -= new EventHandler(buttonAdd_Click);
            buttonRemove.Click -= new EventHandler(buttonRemove_Click);
            textBoxID.TextChanged -= new EventHandler(textBoxID_TextChanged);
            comboBoxBasic.SelectedIndexChanged -= new EventHandler(comboBoxBasic_SelectedIndexChanged);
            comboBoxReact.SelectedIndexChanged -= new EventHandler(comboBoxReact_SelectedIndexChanged);
            comboBoxDebuff.SelectedIndexChanged -= new EventHandler(comboBoxDebuff_SelectedIndexChanged);
            comboBoxSkill.SelectedIndexChanged -= new EventHandler(comboBoxSkill_SelectedIndexChanged);
            numericUpDownSkill.ValueChanged -= new EventHandler(numericUpDownSkill_ValueChanged);
            comboBoxPushback.SelectedIndexChanged -= new EventHandler(comboBoxPushback_SelectedIndexChanged);
            comboBoxKite.SelectedIndexChanged -= new EventHandler(comboBoxKite_SelectedIndexChanged);
            comboBoxSize.SelectedIndexChanged -= new EventHandler(comboBoxSize_SelectedIndexChanged);
            comboBoxRescue.SelectedIndexChanged -= new EventHandler(comboBoxRescue_SelectedIndexChanged);

            // Check if the listBoxTactics selected item is not null
            if (listBoxTactics.SelectedItem != null)
            {
                // Get the listBoxTactics selected tactic
                PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

                // Update the graphical user interface with the values of the current tactic
                TACT_ID = t.ID;
                TACT_BASIC = t.TACT_BASIC;
                TACT_CAST = t.TACT_CAST;
                TACT_DEBUFF = t.TACT_DEBUFF;
                TACT_SKILL = t.TACT_SKILL;
                TACT_PUSHBACK = t.TACT_PUSHBACK;
                TACT_KITE = t.TACT_KITE;
                TACT_SKILLCLASS = t.TACT_SKILLCLASS;
                TACT_RESCUE = t.TACT_RESCUE;

                // Check if the TACT_ID is 0
                if (TACT_ID == "new")
                {
                    // Disable buttonRemove and textBoxID
                    buttonRemove.Enabled = true;
                    textBoxID.Enabled = true;
                }
                // If the TACT_ID is not 0
                else
                {
                    // Enable buttonRemove and textBoxID
                    textBoxID.Enabled = false;
                }
                if (TACT_ID == "0")
                {
                    buttonRemove.Enabled = false;
                }

            }

            // Add event handlers
            buttonAdd.Click += new EventHandler(buttonAdd_Click);
            buttonRemove.Click += new EventHandler(buttonRemove_Click);
            textBoxID.TextChanged += new EventHandler(textBoxID_TextChanged);
            comboBoxBasic.SelectedIndexChanged += new EventHandler(comboBoxBasic_SelectedIndexChanged);
            comboBoxReact.SelectedIndexChanged += new EventHandler(comboBoxReact_SelectedIndexChanged);
            comboBoxDebuff.SelectedIndexChanged += new EventHandler(comboBoxDebuff_SelectedIndexChanged);
            comboBoxSkill.SelectedIndexChanged += new EventHandler(comboBoxSkill_SelectedIndexChanged);
            numericUpDownSkill.ValueChanged += new EventHandler(numericUpDownSkill_ValueChanged);
            comboBoxPushback.SelectedIndexChanged += new EventHandler(comboBoxPushback_SelectedIndexChanged);
            comboBoxKite.SelectedIndexChanged += new EventHandler(comboBoxKite_SelectedIndexChanged);
            comboBoxSize.SelectedIndexChanged += new EventHandler(comboBoxSize_SelectedIndexChanged);
            comboBoxRescue.SelectedIndexChanged += new EventHandler(comboBoxRescue_SelectedIndexChanged);
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic ID
            t.ID = TACT_ID;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxBasic_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_BASIC
            t.TACT_BASIC = TACT_BASIC;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxReact_SelectedIndexChanged (object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_CAST
            t.TACT_CAST = TACT_CAST;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxDebuff_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_DEBUFF
            t.TACT_DEBUFF = TACT_DEBUFF;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            switch (comboBoxSkill.SelectedIndex)
            {
                // If the comboBoxSkill selected index is 0
                case 0:
                    {
                        numericUpDownSkill.Enabled = false;
                    } break;
                case 1:
                    {
                        numericUpDownSkill.Enabled = false;
                    } break;
                case 2:
                    {
                        numericUpDownSkill.Enabled = true;
                    } break;
                case 3:
                    {
                        numericUpDownSkill.Enabled = true;
                        numericUpDownSkill.Value = 5;
                    } break;
            }
            // Update the tactic TACT_SKILL
            t.TACT_SKILL = TACT_SKILL;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void numericUpDownSkill_ValueChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_SKILL
            t.TACT_SKILL = TACT_SKILL;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxPushback_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_PUSHBACK
            t.TACT_PUSHBACK = TACT_PUSHBACK;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxKite_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_KITE
            t.TACT_KITE = TACT_KITE;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_SKILLCLASS
            t.TACT_SKILLCLASS = TACT_SKILLCLASS;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void comboBoxRescue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the listBoxTactics selected tactic
            PvpTact t = (PvpTact)listBoxTactics.SelectedItem;

            // Update the tactic TACT_RESCUE
            t.TACT_RESCUE = TACT_RESCUE;

            // Check if the PvpTacticsChanged event handler is not null
            if (PvpTacticsChanged != null)
            {
                // Raise the PvpTacticsChanged event
                PvpTacticsChanged(this, new EventArgs());
            }
        }

        private void numericUpDownSkill_EnabledChanged(object sender, EventArgs e)
        {
            // Check which comboBoxSkill index is selected
            switch (comboBoxSkill.SelectedIndex)
            {
                // If the comboBoxSkill selected index is 0
                case 0:
                    {
                        // Set the numericUpDownSkill minimum to 0
                        numericUpDownSkill.Minimum = 0;

                        // Set the numericUpDownSkill maximum to 100
                        numericUpDownSkill.Maximum = 100;

                        // Check if the numericUpDownSkill value is not equal to the H_Config AutoSkillLimit
                        if (numericUpDownSkill.Value != H_Config.AutoSkillLimit)
                        {
                            // Update the numericUpDownSkill value to the H_Config AutoSkillLimit
                            numericUpDownSkill.Value = H_Config.AutoSkillLimit;
                        }
                    } break;
                // If the comboBoxSkill selected index is 1
                case 1:
                    {
                        // Set the numericUpDownSkill minimum to 0
                        numericUpDownSkill.Minimum = 0;

                        // Set the numericUpDownSkill maximum to 100
                        numericUpDownSkill.Maximum = 100;

                        // Check if the numericUpDownSkill value is not equal to 100
                        if (numericUpDownSkill.Value != 100)
                        {
                            // Set the numericUpDownSkill value to 100
                            numericUpDownSkill.Value = 100;
                        }
                    } break;
                // If the comboBoxSkill selected index is 2
                case 2:
                    {
                        // Set the numericUpDownSkill minimum to 0
                        numericUpDownSkill.Minimum = 0;

                        // Set the numericUpDownSkill maximum to 100
                        numericUpDownSkill.Maximum = 100;

                        // Check if the numericUpDownSkill value is not equal to 0
                        if (numericUpDownSkill.Value != 0)
                        {
                            // Set the numericUpDownSkill value to 0
                            numericUpDownSkill.Value = 0;
                        }
                    } break;
                // If the comboBoxSkill selected index is 3
                case 3:
                    {
                        // Set the numericUpDownSkill minimum to 1
                        numericUpDownSkill.Minimum = 1;

                        // Set the numericUpDownSkill maximum to 99
                        numericUpDownSkill.Maximum = 99;
                    } break;
                // If the comboBoxSkill selected index is 4
                case 4:
                    {
                        // Set the numericUpDownSkill minimum to 1
                        numericUpDownSkill.Minimum = 1;

                        // Set the numericUpDownSkill maximum to 5
                        numericUpDownSkill.Maximum = 5;
                    } break;
            }
        }

        private void textBoxID_Validated(object sender, EventArgs e)
        {
            // Check if the textBoxID text is empty
            if (textBoxID.Text == "" | textBoxID.Text == "new")
            {
                // Popup an error message for the target name
                MessageBox.Show("You must enter a name.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Change the focus to the textBoxID
                textBoxID.Focus();
            }
            // If the textBoxID text is not empty
            else
            {
                // Run through each object in the listBoxTactics items list
                foreach (object item in listBoxTactics.Items)
                {
                    // Check if the current item is not the listBoxTactics selected item
                    if (item != listBoxTactics.SelectedItem)
                    {
                        // Get the current tactic object
                        PvpTact t = (PvpTact)item;

                        // Check if the tactic ID matches the selected tactic ID
                        if (t.ID == TACT_ID)
                        {
                            // Popup a message for a unique name
                            MessageBox.Show("You must enter a unique name.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Change the focus to textBoxID
                            textBoxID.Focus();

                            // Break out of the loop
                            break;
                        }
                    }
                }

                // Refresh the listBoxTactics control
                listBoxTactics.Refresh();
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
