// PvpTact.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains code for the PvpTact class, which is used to store
// values for an individual PVPTact configuration structure.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace AzzyAIConfig
{
    class M_PvpTact : IComparable<M_PvpTact>
    {
        public M_PvpTact(string id, TACT_BASIC basic = TACT_BASIC.TACT_REACT_L, string skill = "SKILL_ALWAYS", TACT_KITE kite = TACT_KITE.KITE_NEVER, TACT_CAST cast = TACT_CAST.CAST_REACT, TACT_PUSHBACK push = TACT_PUSHBACK.PUSH_NEVER, TACT_DEBUFF debuff = TACT_DEBUFF.DEBUFF_NEVER, TACT_SKILLCLASS size = TACT_SKILLCLASS.CLASS_S, TACT_RESCUE rescue = TACT_RESCUE.RESCUE_NEVER)
        {
            // Set the tactic values
            _id = id;
            _basic = basic;
            _skill = skill;
            _kite = kite;
            _cast = cast;
            _push = push;
            _debuff = debuff;
            _size = size;
            _rescue = rescue;
        }

        public override string ToString()
        {
            // Override the ToString method to return the ID of this PVPTact
            return _id;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(M_PvpTact other)
        {
            // Return the comparison between the IDs of this PVPTact and the other PVPTact
            return ID.CompareTo(other.ID);
        }

        public static bool operator ==(M_PvpTact obj1, M_PvpTact obj2)
        {
            // Check if the first PVPTact ID is equal to the second PVPTact ID
            if (obj1.ID == obj2.ID)
            {
                // Return true
                return true;
            }

            // Return false
            return false;
        }

        public static bool operator !=(M_PvpTact obj1, M_PvpTact obj2)
        {
            // Check if the first PVPTact ID is equal to the second PVPTact ID
            if (obj1 == obj2)
            {
                // Return false
                return false;
            }

            // Return true
            return true;
        }

        string _id = "0";
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        TACT_BASIC _basic = TACT_BASIC.TACT_IGNORE;
        public TACT_BASIC TACT_BASIC
        {
            get { return _basic; }
            set { _basic = value; }
        }

        string _skill = "SKILL_ALWAYS";
        public string TACT_SKILL
        {
            get { return _skill; }
            set { _skill = value; }
        }

        TACT_KITE _kite = TACT_KITE.KITE_NEVER;
        public TACT_KITE TACT_KITE
        {
            get { return _kite; }
            set { _kite = value; }
        }

        TACT_CAST _cast = TACT_CAST.CAST_PASSIVE;
        public TACT_CAST TACT_CAST
        {
            get { return _cast; }
            set { _cast = value; }
        }

        TACT_PUSHBACK _push = TACT_PUSHBACK.PUSH_NEVER;
        public TACT_PUSHBACK TACT_PUSHBACK
        {
            get { return _push; }
            set { _push = value; }
        }

        TACT_DEBUFF _debuff = TACT_DEBUFF.DEBUFF_NEVER;
        public TACT_DEBUFF TACT_DEBUFF
        {
            get { return _debuff; }
            set { _debuff = value; }
        }

        TACT_SKILLCLASS _size = TACT_SKILLCLASS.CLASS_BOTH;
        public TACT_SKILLCLASS TACT_SKILLCLASS
        {
            get { return _size; }
            set { _size = value; }
        }

        TACT_RESCUE _rescue = TACT_RESCUE.RESCUE_NEVER;
        public TACT_RESCUE TACT_RESCUE
        {
            get { return _rescue; }
            set { _rescue = value; }
        }
    }
}