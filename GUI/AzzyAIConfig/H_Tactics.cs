// H_Tactics.csf
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the static class H_Tactics, which is used to store
// the values of the H_Tactics.lua configuration variables.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;

namespace AzzyAIConfig
{
    static class H_Tactics
    {
        public static void Load(string fileName)
        {
            // Read the file contents from fileName and split them into an array of lines
            string file = File.ReadAllText(fileName);
            string[] lines = file.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // Check if the file does not contain "MyTact[0]"
            if (!Regex.IsMatch(file, "MyTact\\[0\\]"))
            {
                // Add the default tactic to the tactics collection
                _tacts.Add(new Tact(0, "Default"));
            }

            // Run through each string object in the lines array
            foreach (string line in lines)
            {
                // Check if the current line contains "MyTact[*]={*}*--*"
                if (Regex.IsMatch(line, "MyTact\\[(.*?)\\]=\\{(.*?)\\}.*?--(.*?)"))
                {
                    // Get the set of values from the line
                    string[] values = Regex.Replace(line, "MyTact\\[(.*?)\\]=\\{(.*?)\\}.*?--(.*?)", "$1,$2,$3").Split(',');

                    // Create a new tactic object
                    Tact t = new Tact(Convert.ToInt32(values[0]), values[14]);

                    // Set the tactic properties
                    if (values[1] == "TACT_TANK")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_TANK;
                    }
                    else if (values[1] == "TACT_IGNORE")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_IGNORE;
                    }
                    else if (values[1] == "TACT_ATTACK_L")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_L;
                    }
                    else if (values[1] == "TACT_ATTACK_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_M;
                    }
                    else if (values[1] == "TACT_ATTACK_H")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_H;
                    }
                    else if (values[1] == "TACT_REACT_L")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_L;
                    }
                    else if (values[1] == "TACT_REACT_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_M;
                    }
                    else if (values[1] == "TACT_REACT_H")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_H;
                    }
                    else if (values[1] == "TACT_REACT_SELF")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_REACT_SELF;
                    }
                    else if (values[1] == "TACT_SNIPE_L")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_SNIPE_L;
                    }
                    else if (values[1] == "TACT_SNIPE_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_SNIPE_M;
                    }
                    else if (values[1] == "TACT_SNIPE_H")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_SNIPE_H;
                    }
                    else if (values[1] == "TACT_ATK_L_REACT_M")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATK_L_REACT_M;
                    }
                    else if (values[1] == "TACT_ATTACK_LAST")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_LAST;
                    }
                    else if (values[1] == "TACT_ATTACK_TOP")
                    {
                        t.TACT_BASIC = TACT_BASIC.TACT_ATTACK_TOP;
                    }

                    t.TACT_SKILL = values[2];

                    if (values[3] == "KITE_ALWAYS")
                    {
                        t.TACT_KITE = TACT_KITE.KITE_ALWAYS;
                    }
                    else if (values[3] == "KITE_REACT")
                    {
                        t.TACT_KITE = TACT_KITE.KITE_REACT;
                    }
                    else if (values[3] == "KITE_NEVER")
                    {
                        t.TACT_KITE = TACT_KITE.KITE_NEVER;
                    }

                    if (values[4] == "CAST_REACT")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT;
                    }
                    else if (values[4] == "CAST_PASSIVE")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_PASSIVE;
                    }
                    else if (values[4] == "CAST_REACT_MAIN")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_MAIN;
                    }
                    else if (values[4] == "CAST_REACT_S")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_S;
                    }
                    else if (values[4] == "CAST_REACT_MOB")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_MOB;
                    }
                    else if (values[4] == "CAST_REACT_DEBUFF")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_DEBUFF;
                    }
                    else if (values[4] == "CAST_REACT_MINION")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_MINION;
                    }
                    else if (values[4] == "CAST_REACT_ANY")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_ANY;
                    }
                    else if (values[4] == "CAST_REACT_BREEZE")
                    {
                        t.TACT_CAST = TACT_CAST.CAST_REACT_BREEZE;
                    }

                    if (values[5] == "PUSH_NEVER")
                    {
                        t.TACT_PUSHBACK = TACT_PUSHBACK.PUSH_NEVER;
                    }
                    else if (values[5] == "PUSH_FRIEND")
                    {
                        t.TACT_PUSHBACK = TACT_PUSHBACK.PUSH_FRIEND;
                    }
                    else if (values[5] == "PUSH_SELF")
                    {
                        t.TACT_PUSHBACK = TACT_PUSHBACK.PUSH_SELF;
                    }

                    if (values[6] == "DEBUFF_NEVER")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_NEVER;
                    }
                    else if (values[6] == "DEBUFF_ANY_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_ANY_C;
                    }
                    else if (values[6] == "DEBUFF_BREEZE_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_BREEZE_C;
                    }
                    else if (values[6] == "DEBUFF_ANY_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_ANY_A;
                    }
                    else if (values[6] == "DEBUFF_BREEZE_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_BREEZE_A;
                    }
                    else if (values[6] == "DEBUFF_ASH_C")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_ASH_C;
                    }
                    else if (values[6] == "DEBUFF_ASH_A")
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_ASH_A;
                    }
                    else
                    {
                        t.TACT_DEBUFF = TACT_DEBUFF.DEBUFF_NEVER;
                    }

                    if (values[7] == "CLASS_BOTH")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_BOTH;
                    }
                    else if (values[7] == "CLASS_OLD")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_OLD;
                    }
                    else if (values[7] == "CLASS_S")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_S;
                    }
                    else if (values[7] == "CLASS_MOB")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_MOB;
                    }
                    else if (values[7] == "CLASS_COMBO_1")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_COMBO_1;
                    }
                    else if (values[7] == "CLASS_COMBO_2")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_COMBO_2;
                    }
                    else if (values[7] == "CLASS_MINION")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_MINION;
                    }
                    else if (values[7] == "CLASS_GRAPPLE")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_GRAPPLE;
                    }
                    else if (values[7] == "CLASS_GRAPPLE_1")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_GRAPPLE_1;
                    }
                    else if (values[7] == "CLASS_GRAPPLE_2")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_GRAPPLE_2;
                    }
                    else if (values[7] == "CLASS_MIN_OLD")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_MIN_OLD;
                    }
                    else if (values[7] == "CLASS_MIN_S")
                    {
                        t.TACT_SKILLCLASS = TACT_SKILLCLASS.CLASS_MIN_S;
                    }
                    if (values[8] == "RESCUE_NEVER")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_NEVER;
                    }
                    else if (values[8] == "RESCUE_FRIEND")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_FRIEND;
                    }
                    else if (values[8] == "RESCUE_RETAINER")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_RETAINER;
                    }
                    else if (values[8] == "RESCUE_SELF")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_SELF;
                    }
                    else if (values[8] == "RESCUE_OWNER")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_OWNER;
                    }
                    else if (values[8] == "RESCUE_ALL")
                    {
                        t.TACT_RESCUE = TACT_RESCUE.RESCUE_ALL;
                    }

                    t.TACT_SP = Convert.ToInt32(values[9]);

                    if (values[10] == "SNIPE_OK")
                    {
                        t.TACT_SNIPE = TACT_SNIPE.SNIPE_OK;
                    }
                    else if (values[10] == "SNIPE_DISABLE")
                    {
                        t.TACT_SNIPE = TACT_SNIPE.SNIPE_DISABLE;
                    }

                    if (values[11] == "KS_NEVER")
                    {
                        t.TACT_KS = TACT_KS.KS_NEVER;
                    }
                    else if (values[11] == "KS_ALWAYS")
                    {
                        t.TACT_KS = TACT_KS.KS_ALWAYS;
                    }
                    else if (values[11] == "KS_POLITE")
                    {
                        t.TACT_KS = TACT_KS.KS_POLITE;
                    }

                    t.TACT_WEIGHT = Convert.ToDecimal(values[12], new CultureInfo("en-US"));

                    if (values[13] == "CHASE_NORMAL")
                    {
                        t.TACT_CHASE = TACT_CHASE.CHASE_NORMAL;
                    }
                    else if (values[13] == "CHASE_ALWAYS")
                    {
                        t.TACT_CHASE = TACT_CHASE.CHASE_ALWAYS;
                    }
                    else if (values[13] == "CHASE_NEVER")
                    {
                        t.TACT_CHASE = TACT_CHASE.CHASE_NEVER;
                    }
                    else if (values[13] == "CHASE_CLEVER")
                    {
                        t.TACT_CHASE = TACT_CHASE.CHASE_CLEVER;
                    }
                    // Add the tactic to the tactics collection
                    _tacts.Add(t);
                }
            }

            // Output to the console "Loading complete."
            Program.WriteLine("Loading complete.");
        }


        public static void Save(string fileName)
        {
            // Set the file contents to "MyTact={}"
            string file = "MyTact={}";

            // Run through each tactic object in the tactics collection
            foreach (Tact t in _tacts)
            {
                // Check if the file contents contains "MyTact[t.ID]"
                if (Regex.IsMatch(file, string.Format("MyTact\\[{0}\\]", t.ID)))
                {
                    // Update the tactic
                    file = Regex.Replace(file, string.Format("(MyTact\\[{0}\\]=\\{{).*?(\\}}.*?--).*", t.ID), string.Format("$1{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}$2{13}", t.TACT_BASIC, t.TACT_SKILL, t.TACT_KITE, t.TACT_CAST, t.TACT_PUSHBACK, t.TACT_DEBUFF, t.TACT_SKILLCLASS, t.TACT_RESCUE, t.TACT_SP, t.TACT_SNIPE, t.TACT_KS, t.TACT_WEIGHT, t.TACT_CHASE, t.Name));
                }
                // If the file does not contain the tactic
                else
                {
                    // Add it to the file
                    file = string.Format("{1}{0}MyTact[{2}]={{{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}}} --{16}", Environment.NewLine, file, t.ID, t.TACT_BASIC, t.TACT_SKILL, t.TACT_KITE, t.TACT_CAST, t.TACT_PUSHBACK, t.TACT_DEBUFF, t.TACT_SKILLCLASS, t.TACT_RESCUE, t.TACT_SP, t.TACT_SNIPE, t.TACT_KS, Convert.ToString(t.TACT_WEIGHT, new CultureInfo("en-US")), t.TACT_CHASE, t.Name);
                }
            }
            if (Regex.IsMatch(file, "TactLastSavedDate\\s*=\\s*\".*\"", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "TactLastSavedDate\\s*=\\s*\".*\"", string.Format("{0,-25}= {1}", "TactLastSavedDate", "\"" + DateTime.Now + "\""), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "TactLastSavedDate", "\"" + DateTime.Now + "\"");
            }
            // Output to the console "Saving to file: fileName"
            Program.WriteLine("Saving to file: {0}", fileName);

            // Save the file
            File.WriteAllText(fileName, file);

            // Output to the console "Saving complete."
            Program.WriteLine("Saving complete.");
        }


        static TactCollection _tacts = new TactCollection();
        public static TactCollection Tactics
        {
            get { return _tacts; }
        }
    }
}