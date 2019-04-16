// Defaults.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the static class Defaults, which is used to store the
// default values from the Defaults.lua config file.


using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace AzzyAIConfig
{
    static class Defaults
    {
        public static void Load(string fileName)
        {
            // Read the contents from fileName
            string file = File.ReadAllText(fileName);

            // Output to the console "Loading defaults."
            Program.WriteLine("Loading defaults.");

            // Search for the variables in the file contents and save their values if found
            if (Regex.IsMatch(file, "FollowStayBack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FollowStayBack = Convert.ToInt32(Regex.Match(file, "FollowStayBack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "RestXOff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _RestXOff = Convert.ToInt32(Regex.Match(file, "RestXOff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "RestYOff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _RestYOff = Convert.ToInt32(Regex.Match(file, "RestYOff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "SpawnDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _SpawnDelay = Convert.ToInt32(Regex.Match(file, "SpawnDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseOffensiveBuff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseOffensiveBuff = Convert.ToInt32(Regex.Match(file, "UseOffensiveBuff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseDefensiveBuff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseDefensiveBuff = Convert.ToInt32(Regex.Match(file, "UseDefensiveBuff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseAutoSight\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseAutoSight = Convert.ToInt32(Regex.Match(file, "UseAutoSight\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseAutoMag\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseAutoMag = Convert.ToInt32(Regex.Match(file, "UseAutoMag\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseProvokeOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseProvokeOwner = Convert.ToInt32(Regex.Match(file, "UseProvokeOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseSacrificeOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseSacrificeOwner = Convert.ToInt32(Regex.Match(file, "UseSacrificeOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KiteMonsters\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KiteMonsters = Convert.ToInt32(Regex.Match(file, "KiteMonsters\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KiteParanoid\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KiteParanoid = Convert.ToInt32(Regex.Match(file, "KiteParanoid\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KiteStep\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KiteStep = Convert.ToInt32(Regex.Match(file, "KiteStep\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KiteParanoidStep\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KiteParanoidStep = Convert.ToInt32(Regex.Match(file, "KiteParanoidStep\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KiteThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KiteThreshold = Convert.ToInt32(Regex.Match(file, "KiteThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KiteParanoidThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KiteParanoidThreshold = Convert.ToInt32(Regex.Match(file, "KiteParanoidThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KiteBounds\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KiteBounds = Convert.ToInt32(Regex.Match(file, "KiteBounds\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "ForceKite\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _ForceKite = Convert.ToInt32(Regex.Match(file, "ForceKite\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "PVPmode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _PVPmode = Convert.ToInt32(Regex.Match(file, "PVPmode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "DoNotChase\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _DoNotChase = Convert.ToInt32(Regex.Match(file, "DoNotChase\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "KSMercHomun\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _KSMercHomun = Convert.ToInt32(Regex.Match(file, "KSMercHomun\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AssumeHomun\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AssumeHomun = Convert.ToInt32(Regex.Match(file, "AssumeHomun\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AttackSkillReserveSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AttackSkillReserveSP = Convert.ToInt32(Regex.Match(file, "AttackSkillReserveSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AutoMobCount\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AutoMobCount = Convert.ToInt32(Regex.Match(file, "AutoMobCount\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseSkillOnly\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseSkillOnly = Convert.ToInt32(Regex.Match(file, "UseSkillOnly\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AutoSkillDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AutoSkillDelay = Convert.ToInt32(Regex.Match(file, "AutoSkillDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AutoSkillLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AutoSkillLimit = Convert.ToInt32(Regex.Match(file, "AutoSkillLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseAutoPushback\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseAutoPushback = Convert.ToInt32(Regex.Match(file, "UseAutoPushback\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AutoPushbackThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AutoPushbackThreshold = Convert.ToInt32(Regex.Match(file, "AutoPushbackThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "NewAutoFriend\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _NewAutoFriend = Convert.ToInt32(Regex.Match(file, "NewAutoFriend\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "ProvokeOwnerTries\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _ProvokeOwnerTries = Convert.ToInt32(Regex.Match(file, "ProvokeOwnerTries\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "ProvokeOwnerDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _ProvokeOwnerDelay = Convert.ToInt32(Regex.Match(file, "ProvokeOwnerDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "RouteWalkCircle\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _RouteWalkCircle = Convert.ToInt32(Regex.Match(file, "RouteWalkCircle\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FastChange_C2I\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FastChange_C2I = Convert.ToInt32(Regex.Match(file, "FastChange_C2I\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FastChange_C2A\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FastChange_C2A = Convert.ToInt32(Regex.Match(file, "FastChange_C2A\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FastChange_A2C\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FastChange_A2C = Convert.ToInt32(Regex.Match(file, "FastChange_A2C\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FastChange_A2I\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FastChange_A2I = Convert.ToInt32(Regex.Match(file, "FastChange_A2I\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FastChange_I2C\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FastChange_I2C = Convert.ToInt32(Regex.Match(file, "FastChange_I2C\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FastChange_F2I\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FastChange_F2I = Convert.ToInt32(Regex.Match(file, "FastChange_F2I\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FollowTryPanic\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FollowTryPanic = Convert.ToInt32(Regex.Match(file, "FollowTryPanic\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AttackGiveUp\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AttackGiveUp = Convert.ToInt32(Regex.Match(file, "AttackGiveUp\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FastChangeLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FastChangeLimit = Convert.ToInt32(Regex.Match(file, "FastChangeLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AttackDebuffLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AttackDebuffLimit = Convert.ToInt32(Regex.Match(file, "AttackDebuffLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "MirAIFriending\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _MirAIFriending = Convert.ToInt32(Regex.Match(file, "MirAIFriending\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "StandbyFriending\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _StandbyFriending = Convert.ToInt32(Regex.Match(file, "StandbyFriending\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "FilirFlitLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _FilirFlitLevel = Convert.ToInt32(Regex.Match(file, "FilirFlitLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "LifEscapeLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _LifEscapeLevel = Convert.ToInt32(Regex.Match(file, "LifEscapeLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AmiBulwarkLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AmiBulwarkLevel = Convert.ToInt32(Regex.Match(file, "AmiBulwarkLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "DoNotUseRest\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _DoNotUseRest = Convert.ToInt32(Regex.Match(file, "DoNotUseRest\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "StickyStandby\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _StickyStandby = Convert.ToInt32(Regex.Match(file, "StickyStandby\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "DefendStandby\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _DefendStandby = Convert.ToInt32(Regex.Match(file, "DefendStandby\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseAutoChaoticBless\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseAutoChaoticBless = Convert.ToInt32(Regex.Match(file, "UseAutoChaoticBless\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "ChaoticBlessLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _ChaoticBlessLevel = Convert.ToInt32(Regex.Match(file, "ChaoticBlessLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "ChaoticBlessHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _ChaoticBlessHP = Convert.ToInt32(Regex.Match(file, "ChaoticBlessHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseAvoid\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseAvoid = Convert.ToInt32(Regex.Match(file, "UseAvoid\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "MoveSticky\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _MoveSticky = Convert.ToInt32(Regex.Match(file, "MoveSticky\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "MoveStickyFight\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _MoveStickyFight = Convert.ToInt32(Regex.Match(file, "MoveStickyFight\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "MagicNumber\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _MagicNumber = Convert.ToInt32(Regex.Match(file, "MagicNumber\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "MagicNumber2\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _MagicNumber2 = Convert.ToInt32(Regex.Match(file, "MagicNumber2\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "AutoDetectPlant\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _AutoDetectPlant = Convert.ToInt32(Regex.Match(file, "AutoDetectPlant\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseBerserkSkill\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseBerserkSkill = Convert.ToInt32(Regex.Match(file, "UseBerserkSkill\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseBerserkAttack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseBerserkAttack = Convert.ToInt32(Regex.Match(file, "UseBerserkAttack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "UseBerserkMobbed\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _UseBerserkMobbed = Convert.ToInt32(Regex.Match(file, "UseBerserkMobbed\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "Berserk_SkillAlways\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _Berserk_SkillAlways = Convert.ToInt32(Regex.Match(file, "Berserk_SkillAlways\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }
            if (Regex.IsMatch(file, "Berserk_Dance\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            { _Berserk_Dance = Convert.ToInt32(Regex.Match(file, "Berserk_Dance\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline).Value.Split('=')[1].Trim()); }

            // Output to the console "Loading complete."
            Program.WriteLine("Loading complete.");
        }

        #region Properties
        static int _FollowStayBack = 2;
        public static int FollowStayBack
        {
            get { return _FollowStayBack; }
            set { _FollowStayBack = value; }
        }
        static int _RestXOff = 0;
        public static int RestXOff
        {
            get { return _RestXOff; }
            set { _RestXOff = value; }
        }
        static int _RestYOff = -2;
        public static int RestYOff
        {
            get { return _RestYOff; }
            set { _RestYOff = value; }
        }
        static int _SpawnDelay = 1000;
        public static int SpawnDelay
        {
            get { return _SpawnDelay; }
            set { _SpawnDelay = value; }
        }
        static int _UseOffensiveBuff = 1;
        public static int UseOffensiveBuff
        {
            get { return _UseOffensiveBuff; }
            set { _UseOffensiveBuff = value; }
        }
        static int _UseDefensiveBuff = 1;
        public static int UseDefensiveBuff
        {
            get { return _UseDefensiveBuff; }
            set { _UseDefensiveBuff = value; }
        }
        static int _UseAutoSight = 0;
        public static int UseAutoSight
        {
            get { return _UseAutoSight; }
            set { _UseAutoSight = value; }
        }
        static int _UseAutoMag = 1;
        public static int UseAutoMag
        {
            get { return _UseAutoMag; }
            set { _UseAutoMag = value; }
        }
        static int _UseProvokeOwner = 0;
        public static int UseProvokeOwner
        {
            get { return _UseProvokeOwner; }
            set { _UseProvokeOwner = value; }
        }
        static int _UseSacrificeOwner = 0;
        public static int UseSacrificeOwner
        {
            get { return _UseSacrificeOwner; }
            set { _UseSacrificeOwner = value; }
        }
        static int _KiteMonsters = 1;
        public static int KiteMonsters
        {
            get { return _KiteMonsters; }
            set { _KiteMonsters = value; }
        }
        static int _KiteParanoid = 1;
        public static int KiteParanoid
        {
            get { return _KiteParanoid; }
            set { _KiteParanoid = value; }
        }
        static int _KiteStep = 5;
        public static int KiteStep
        {
            get { return _KiteStep; }
            set { _KiteStep = value; }
        }
        static int _KiteParanoidStep = 2;
        public static int KiteParanoidStep
        {
            get { return _KiteParanoidStep; }
            set { _KiteParanoidStep = value; }
        }
        static int _KiteThreshold = 3;
        public static int KiteThreshold
        {
            get { return _KiteThreshold; }
            set { _KiteThreshold = value; }
        }
        static int _KiteParanoidThreshold = 2;
        public static int KiteParanoidThreshold
        {
            get { return _KiteParanoidThreshold; }
            set { _KiteParanoidThreshold = value; }
        }
        static int _KiteBounds = 8;
        public static int KiteBounds
        {
            get { return _KiteBounds; }
            set { _KiteBounds = value; }
        }
        static int _ForceKite = 0;
        public static int ForceKite
        {
            get { return _ForceKite; }
            set { _ForceKite = value; }
        }
        static int _PVPmode = 0;
        public static int PVPmode
        {
            get { return _PVPmode; }
            set { _PVPmode = value; }
        }
        static int _DoNotChase = 0;
        public static int DoNotChase
        {
            get { return _DoNotChase; }
            set { _DoNotChase = value; }
        }
        static int _KSMercHomun = 0;
        public static int KSMercHomun
        {
            get { return _KSMercHomun; }
            set { _KSMercHomun = value; }
        }
        static int _AssumeHomun = 1;
        public static int AssumeHomun
        {
            get { return _AssumeHomun; }
            set { _AssumeHomun = value; }
        }
        static int _AttackSkillReserveSP = 0;
        public static int AttackSkillReserveSP
        {
            get { return _AttackSkillReserveSP; }
            set { _AttackSkillReserveSP = value; }
        }
        static int _AutoMobCount = 2;
        public static int AutoMobCount
        {
            get { return _AutoMobCount; }
            set { _AutoMobCount = value; }
        }
        static int _UseSkillOnly = -1;
        public static int UseSkillOnly
        {
            get { return _UseSkillOnly; }
            set { _UseSkillOnly = value; }
        }
        static int _AutoSkillDelay = 400;
        public static int AutoSkillDelay
        {
            get { return _AutoSkillDelay; }
            set { _AutoSkillDelay = value; }
        }
        static int _AutoSkillLimit = 100;
        public static int AutoSkillLimit
        {
            get { return _AutoSkillLimit; }
            set { _AutoSkillLimit = value; }
        }
        static int _UseAutoPushback = 0;
        public static int UseAutoPushback
        {
            get { return _UseAutoPushback; }
            set { _UseAutoPushback = value; }
        }
        static int _AutoPushbackThreshold = 2;
        public static int AutoPushbackThreshold
        {
            get { return _AutoPushbackThreshold; }
            set { _AutoPushbackThreshold = value; }
        }
        static int _NewAutoFriend = 1;
        public static int NewAutoFriend
        {
            get { return _NewAutoFriend; }
            set { _NewAutoFriend = value; }
        }
        static int _ProvokeOwnerTries = 5;
        public static int ProvokeOwnerTries
        {
            get { return _ProvokeOwnerTries; }
            set { _ProvokeOwnerTries = value; }
        }
        static int _ProvokeOwnerDelay = 400;
        public static int ProvokeOwnerDelay
        {
            get { return _ProvokeOwnerDelay; }
            set { _ProvokeOwnerDelay = value; }
        }

        static int _RouteWalkCircle = 1;
        public static int RouteWalkCircle
        {
            get { return _RouteWalkCircle; }
            set { _RouteWalkCircle = value; }
        }

        static int _FastChange_C2I = 1;
        public static int FastChange_C2I
        {
            get { return _FastChange_C2I; }
            set { _FastChange_C2I = value; }
        }
        static int _FastChange_C2A = 1;
        public static int FastChange_C2A
        {
            get { return _FastChange_C2A; }
            set { _FastChange_C2A = value; }
        }
        static int _FastChange_A2C = 1;
        public static int FastChange_A2C
        {
            get { return _FastChange_A2C; }
            set { _FastChange_A2C = value; }
        }
        static int _FastChange_A2I = 0;
        public static int FastChange_A2I
        {
            get { return _FastChange_A2I; }
            set { _FastChange_A2I = value; }
        }
        static int _FastChange_I2C = 0;
        public static int FastChange_I2C
        {
            get { return _FastChange_I2C; }
            set { _FastChange_I2C = value; }
        }
        static int _FastChange_F2I = 0;
        public static int FastChange_F2I
        {
            get { return _FastChange_F2I; }
            set { _FastChange_F2I = value; }
        }
        static int _FollowTryPanic = 3;
        public static int FollowTryPanic		 //Try this many times to move to owner at FollowStayBack before panicing and moving right to him
        {
            get { return _FollowTryPanic; }
            set { _FollowTryPanic = value; }
        }
        static int _AttackGiveUp = 3;
        public static int AttackGiveUp
        {
            get { return _AttackGiveUp; }
            set { _AttackGiveUp = value; }
        }
        static int _FastChangeLimit = 1;
        public static int FastChangeLimit
        {
            get { return _FastChangeLimit; }
            set { _FastChangeLimit = value; }
        }

        static int _AttackDebuffLimit = 1;
        public static int AttackDebuffLimit
        {
            get { return _AttackDebuffLimit; }
            set { _AttackDebuffLimit = value; }
        }

        static int _MirAIFriending = 0;
        public static int MirAIFriending
        {
            get { return _MirAIFriending; }
            set { _MirAIFriending = value; }
        }
        static int _StandbyFriending = 0;
        public static int StandbyFriending
        {
            get { return _StandbyFriending; }
            set { _StandbyFriending = value; }
        }

        static int _FilirFlitLevel = 5;
        public static int FilirFlitLevel
        {
            get { return _FilirFlitLevel; }
            set { _FilirFlitLevel = value; }
        }
        static int _LifEscapeLevel = 5;
        public static int LifEscapeLevel
        {
            get { return _LifEscapeLevel; }
            set { _LifEscapeLevel = value; }
        }
        static int _AmiBulwarkLevel = 5;
        public static int AmiBulwarkLevel
        {
            get { return _AmiBulwarkLevel; }
            set { _AmiBulwarkLevel = value; }
        }

        static int _DoNotUseRest = 0;
        public static int DoNotUseRest
        {
            get { return _DoNotUseRest; }
            set { _DoNotUseRest = value; }
        }
        static int _StickyStandby = 0;
        public static int StickyStandby
        {
            get { return _StickyStandby; }
            set { _StickyStandby = value; }
        }
        static int _DefendStandby = 0;
        public static int DefendStandby
        {
            get { return _DefendStandby; }
            set { _DefendStandby = value; }
        }
        static int _UseAutoChaoticBless = 0;
        public static int UseAutoChaoticBless		 // not reccomended/not implemented
        {
            get { return _UseAutoChaoticBless; }
            set { _UseAutoChaoticBless = value; }
        }
        static int _ChaoticBlessLevel = 3;
        public static int ChaoticBlessLevel
        {
            get { return _ChaoticBlessLevel; }
            set { _ChaoticBlessLevel = value; }
        }
        static int _ChaoticBlessHP = 0;
        public static int ChaoticBlessHP
        {
            get { return _ChaoticBlessHP; }
            set { _ChaoticBlessHP = value; }
        }
        static int _UseAvoid = 0;
        public static int UseAvoid
        {
            get { return _UseAvoid; }
            set { _UseAvoid = value; }
        }
        static int _MoveSticky = 0;
        public static int MoveSticky
        {
            get { return _MoveSticky; }
            set { _MoveSticky = value; }
        }
        static int _MoveStickyFight = 0;
        public static int MoveStickyFight
        {
            get { return _MoveStickyFight; }
            set { _MoveStickyFight = value; }
        }

        static int _MagicNumber = 40000;
        public static int MagicNumber
        {
            get { return _MagicNumber; }
            set { _MagicNumber = value; }
        }
        static int _MagicNumber2 = 100000;
        public static int MagicNumber2
        {
            get { return _MagicNumber2; }
            set { _MagicNumber2 = value; }
        }

        static int _AutoDetectPlant = 1;
        public static int AutoDetectPlant
        {
            get { return _AutoDetectPlant; }
            set { _AutoDetectPlant = value; }
        }
        static int _UseBerserkSkill = 0;
        public static int UseBerserkSkill
        {
            get { return _UseBerserkSkill; }
            set { _UseBerserkSkill = value; }
        }
        static int _UseBerserkAttack = 0;
        public static int UseBerserkAttack
        {
            get { return _UseBerserkAttack; }
            set { _UseBerserkAttack = value; }
        }
        static int _UseBerserkMobbed = 0;
        public static int UseBerserkMobbed
        {
            get { return _UseBerserkMobbed; }
            set { _UseBerserkMobbed = value; }
        }
        static int _Berserk_SkillAlways = 0;
        public static int Berserk_SkillAlways
        {
            get { return _Berserk_SkillAlways; }
            set { _Berserk_SkillAlways = value; }
        }
        static int _Berserk_Dance = 0;
        public static int Berserk_Dance
        {
            get { return _Berserk_Dance; }
            set { _Berserk_Dance = value; }
        }
        #endregion
    }
}