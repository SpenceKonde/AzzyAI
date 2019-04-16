// Tact.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the Tact class, which is used to hold data for a
// tactics object, and enumerations for TACT_BASIC, TACT_KITE, TACT_CAST,
// TACT_PUSHBACK, TACT_SKILLCLASS, TACT_RESCUE, and TACT_KS to restrict values
// for each data type.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;


namespace AzzyAIConfig
{

    enum TACT_BASIC : sbyte
    {
        TACT_TANKMOB = -2, //Tank until enough monsters to use AoE on them
        TACT_TANK = -1,	//(Hit monster once, and then hold it until something kills it)
        TACT_IGNORE = 0,	//(Do not attack the monster, at all)
        TACT_ATTACK_L = 2,	//(Seek out and attack this monster, low priority, do not give higher priority if attacking)
        TACT_ATTACK_M = 3,	//(Seek out and attack this monster, medium priority)
        TACT_ATTACK_H = 4,	//(Seek out and attack this monster, high priority)
        TACT_REACT_L = 5,	//(React to this monster when self/owner/friend attacked, low priority)
        TACT_REACT_M = 7,	//(React to this monster when self/owner/friend attacked, medium priority)
        TACT_REACT_H = 8,	//(React to this monster when self/owner/friend attacked, high priority)
        TACT_REACT_SELF = 9, //(React to this monster when self attacked only)
        TACT_SNIPE_L = 10,	//(Attempt to 1-shot this monster with bolts, even while attacking other monsters, low priority)
        TACT_SNIPE_M = 11,	//(Attempt to 1-shot this monster with bolts, even while attacking other monsters, medium priority)
        TACT_SNIPE_H = 12,	//(Attempt to 1-shot this monster with bolts, even while attacking other monsters, high priority)
        TACT_ATK_L_REACT_M = 13,
        TACT_ATTACK_LAST = 14,
        TACT_ATTACK_TOP = 15,
    }

    enum TACT_KITE : sbyte
    {
        KITE_ALWAYS = 2, //(always kite from this monster - recommended for aggressive monsters)
        KITE_REACT = 1, //(kite from this kind of monster only if attacked)
        KITE_NEVER = 0 //(never kite from this kind of monster)
    }

    enum TACT_CAST : sbyte
    {
        CAST_REACT = 1,
        CAST_PASSIVE = 0,
        CAST_REACT_MAIN   = 10,
        CAST_REACT_S    = 11,
        CAST_REACT_MOB    = 12,
        CAST_REACT_DEBUFF = 13,
        CAST_REACT_MINION = 15,
        CAST_REACT_ANY    = 9,
        CAST_REACT_CRASH  = 100,
        CAST_REACT_PROVOKE  = 101,
        CAST_REACT_SANDMAN  = 102,
        CAST_REACT_FREEZE   = 103,
        CAST_REACT_DECAGI   = 104,
        CAST_REACT_LEXDIV   = 105,
        CAST_REACT_BREEZE =106
    }

    enum TACT_DEBUFF : sbyte
    {
        DEBUFF_NEVER = 0,
        DEBUFF_ANY_C = -1,
        DEBUFF_CRASH_C = 1,
        DEBUFF_PROVOKE_C = 2,
        DEBUFF_SANDMAN_C = 3,
        DEBUFF_FREEZE_C = 4,
        DEBUFF_DECAGI_C = 5,
        DEBUFF_LEXDIV_C = 6,
        DEBUFF_ANY_A = 7,
        DEBUFF_CRASH_A = 8,
        DEBUFF_PROVOKE_A = 9,
        DEBUFF_SANDMAN_A = 10,
        DEBUFF_FREEZE_A = 11,
        DEBUFF_DECAGI_A = 12,
        DEBUFF_LEXDIV_A = 13,
        DEBUFF_BREEZE_C = 14,
        DEBUFF_BREEZE_A = 15,
        DEBUFF_ASH_C=16,
        DEBUFF_ASH_A=17

    }
    enum TACT_PUSHBACK : sbyte
    {
        PUSH_NEVER = 0,
        PUSH_SELF = 1,
        PUSH_FRIEND = 2
    }

    enum TACT_SKILLCLASS : sbyte
    {
        CLASS_BOTH	=-1,
        CLASS_OLD	=0,
        CLASS_S		=1,
        CLASS_MOB	=2,
        CLASS_COMBO_1 =3,
        CLASS_COMBO_2 =4,
        CLASS_MINION =5,
        CLASS_GRAPPLE	=6,
        CLASS_GRAPPLE_1 =7,
        CLASS_GRAPPLE_2 = 8,
        CLASS_MIN_OLD = 9,
        CLASS_MIN_S = 10
    }

    enum TACT_RESCUE : sbyte
    {
        RESCUE_NEVER =0,
        RESCUE_FRIEND = 1,
        RESCUE_RETAINER = 2,
        RESCUE_SELF = 3,
        RESCUE_OWNER = 4,
        RESCUE_ALL = 5
    }

    enum TACT_KS : sbyte
    {
        KS_POLITE = -1,
        KS_NEVER = 0,
        KS_ALWAYS = 1
    }
    enum TACT_SNIPE : sbyte
    {
        SNIPE_OK=1,
        SNIPE_DISABLE=0
    }
    enum TACT_CHASE : sbyte
    {
        CHASE_NORMAL = -1,
        CHASE_ALWAYS = 0,
        CHASE_NEVER  = 1,
        CHASE_CLEVER = 2
    }
    class Tact : IComparable<Tact>
    {
        public Tact(int id, string name = "", TACT_BASIC basic = TACT_BASIC.TACT_IGNORE, string skill = "SKILL_ALWAYS", TACT_KITE kite = TACT_KITE.KITE_NEVER, TACT_CAST cast = TACT_CAST.CAST_REACT, TACT_PUSHBACK push = TACT_PUSHBACK.PUSH_NEVER, TACT_DEBUFF debuff = TACT_DEBUFF.DEBUFF_NEVER, TACT_SKILLCLASS sclass = TACT_SKILLCLASS.CLASS_BOTH, TACT_RESCUE rescue = TACT_RESCUE.RESCUE_NEVER, int sp = -1, TACT_SNIPE snipe = TACT_SNIPE.SNIPE_OK, TACT_KS ffa = TACT_KS.KS_NEVER, decimal weight = 1, TACT_CHASE chase = TACT_CHASE.CHASE_NORMAL)
        {
            // Set the tactic variables
            _id = id;
            _basic = basic;
            _skill = skill;
            _kite = kite;
            _cast = cast;
            _push = push;
            _debuff = debuff;
            _sclass = sclass;
            _rescue = rescue; 
            _sp = sp;
            _snipe = snipe;
            _ffa = ffa;
            _weight = weight;
            _chase = chase;
            _name = name;
        }

        public override string ToString()
        {
            // Override the ToString method to return the name of this tactic
            return Name;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Tact other)
        {
            // Compare the ID of this tactic to the ID of the other tactic
            return ID.CompareTo(other.ID);
        }

        public static bool operator ==(Tact obj1, Tact obj2)
        {
            // Check if the first tactic ID is equal to the second tactic ID
            if (obj1.ID == obj2.ID)
            {
                // Return true
                return true;
            }

            // Return false
            return false;
        }

        public static bool operator !=(Tact obj1, Tact obj2)
        {
            // Check if the first tactic is equal to the second tactic
            if (obj1 == obj2)
            {
                // Return false
                return false;
            }

            // Return true
            return true;
        }

        int _id = 0;
        public int ID
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

        TACT_SKILLCLASS _sclass = TACT_SKILLCLASS.CLASS_BOTH;
        public TACT_SKILLCLASS TACT_SKILLCLASS
        {
            get { return _sclass; }
            set { _sclass = value; }
        }

        TACT_RESCUE _rescue = TACT_RESCUE.RESCUE_RETAINER;
        public TACT_RESCUE TACT_RESCUE
        {
            get { return _rescue; }
            set { _rescue = value; }
        }
        int _sp = -1;
        public int TACT_SP
        {
            get { return _sp; }
            set { _sp = value; }
        }
        TACT_SNIPE _snipe = TACT_SNIPE.SNIPE_OK;
        public TACT_SNIPE TACT_SNIPE
        {
            get { return _snipe; }
            set { _snipe = value; }
        }
        TACT_KS _ffa = TACT_KS.KS_NEVER;
        public TACT_KS TACT_KS
        {
            get { return _ffa; }
            set { _ffa = value; }
        }
        decimal _weight = 1;
        public decimal TACT_WEIGHT
        {
            get { return _weight; }
            set { _weight = value; }
        }
        TACT_CHASE _chase = TACT_CHASE.CHASE_NORMAL;
        public TACT_CHASE TACT_CHASE
        {
            get { return _chase; }
            set { _chase = value; }
        }
        string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}