// MerConf.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the class MerConf, which is used as a proxy to hold
// the data for M_Config.

using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;


namespace AzzyAIConfig
{

    class MerConf
    {
        // The default file
        string _file = "M_Config.lua";

        public MerConf()
        {
            // Check if the file does not exist
            if (!File.Exists(_file))
            {
                // Throw a new file not found exception
                throw new FileNotFoundException("The default file could not be found.", _file);
            }

            // Load configurations from the file
            M_Config.Load(_file);

            // Initialize this object's values
            InitValues();
        }

        public MerConf(string file)
        {
            // Check if the file does not exist
            if (!File.Exists(file))
            {
                // Throw a new file not found exception
                throw new FileNotFoundException("The specified file could not be found.", _file);
            }
            // Set the file path
            _file = file;

            // Load configurations from the file
            M_Config.Load(_file);

            // Initialize this object's values
            InitValues();
        }

        public void Revert()
        {
            // Reload the configurations from the file
            M_Config.Load(_file);

            // Reinitialize the values for this object
            InitValues();
        }

        public void SetDefaults()
        {
            // Basic Options
            _AggroHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AggroHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AggroSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AggroSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _KiteMonsters = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteMonsters"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _SuperPassive = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["SuperPassive"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseAttackSkill = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAttackSkill"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AssumeHomun = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AssumeHomun"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _DoNotChase = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DoNotChase"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseDanceAttack = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDanceAttack"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AutoDetectPlant = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoDetectPlant"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _TankMonsterLimit = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["TankMonsterLimit"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _RescueOwnerLowHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["RescueOwnerLowHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _StationaryAggroDist = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["StationaryAggroDist"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _MobileAggroDist = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["MobileAggroDist"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _OpportunisticTargeting = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["OpportunisticTargeting"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AttackLastFullSP = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AttackLastFullSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AttackTimeLimit = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AttackTimeLimit"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _LagReduction = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["LagReduction"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _DoNotAttackMoving = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DoNotAttackMoving"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _LiveMobID = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["LiveMobID"].Attributes[typeof(DefaultValueAttribute)]).Value);
            
            // AutoSkill Options
            _AttackSkillReserveSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AttackSkillReserveSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AutoMobCount = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoMobCount"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSkillOnly = (UseSkillOnlyOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSkillOnly"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _AutoSkillDelay = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoSkillDelay"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseAutoPushback = (UseAutoPushbackOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAutoPushback"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _AutoPushbackThreshold = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoPushbackThreshold"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AoEReserveSP = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AoEReserveSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AoEFixedLevel = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AoEFixedLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AutoMobMode = (AutoMobModeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoMobMode"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _AoEMaximizeTargets = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AoEMaximizeTargets"].Attributes[typeof(DefaultValueAttribute)]).Value);


            // Walk/Follow Options
            _FollowStayBack = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["FollowStayBack"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _RestXOff = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["RestXOff"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _RestYOff = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["RestYOff"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _DoNotUseRest = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DoNotUseRest"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _SpawnDelay = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["SpawnDelay"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _MoveSticky = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["MoveSticky"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _MoveStickyFight = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["MoveStickyFight"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseIdleWalk = (UseIdleWalkOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseIdleWalk"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _IdleWalkSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["IdleWalkSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _RelativeRoute = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["RelativeRoute"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _IdleWalkDistance = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["IdleWalkDistance"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _ChaseSPPause = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["ChaseSPPause"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _ChaseSPPauseSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["ChaseSPPauseSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _ChaseSPPauseTime = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["ChaseSPPauseTime"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _StationaryMoveBounds = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["StationaryMoveBounds"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _MobileMoveBounds = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["MobileMoveBounds"].Attributes[typeof(DefaultValueAttribute)]).Value);

            // Autobuff Options
            _UseOffensiveBuff = (UseOffensiveBuffOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseOffensiveBuff"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseProvokeOwner = (UseProvokeOwnerOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseProvokeOwner"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _DefensiveBuffOwnerMobbed = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DefensiveBuffOwnerMobbed"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseDefensiveBuff = (UseDefensiveBuffOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDefensiveBuff"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseAutoMag = (UseAutoMagOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAutoMag"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseAutoSight = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAutoSight"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSacrificeOwner = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSacrificeOwner"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseBlessingSelf = (UseBlessingSelfOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBlessingSelf"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseBlessingOwner = (UseBlessingOwnerOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBlessingOwner"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseKyrieSelf = (UseKyrieSelfOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseKyrieSelf"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseKyrieOwner = (UseKyrieOwnerOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseKyrieOwner"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseIncAgiSelf = (UseIncAgiSelfOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseIncAgiSelf"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseIncAgiOwner = (UseIncAgiOwnerOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseIncAgiOwner"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _DefensiveBuffOwnerHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DefensiveBuffOwnerHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            // Kiting Options
            _KiteParanoid = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteParanoid"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _KiteStep = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteStep"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _KiteParanoidStep = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteParanoidStep"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _KiteThreshold = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteThreshold"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _KiteParanoidThreshold = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteParanoidThreshold"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _KiteBounds = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteBounds"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _ForceKite = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["ForceKite"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _FleeHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["FleeHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            
            // Friending Options
            _StandbyFriending = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["StandbyFriending"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _MirAIFriending = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["MirAIFriending"].Attributes[typeof(DefaultValueAttribute)]).Value);

            // Standby Options
            _DefendStandby = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DefendStandby"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _StickyStandby = (StickyStandbyOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["StickyStandby"].Attributes[typeof(DefaultValueAttribute)]).Value;

            // Berserk Options
            _UseBerserkMobbed = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBerserkMobbed"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseBerserkSkill = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBerserkSkill"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseBerserkAttack = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBerserkAttack"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _Berserk_SkillAlways = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["Berserk_SkillAlways"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _Berserk_Dance = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["Berserk_Dance"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _Berserk_IgnoreMinSP = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["Berserk_IgnoreMinSP"].Attributes[typeof(DefaultValueAttribute)]).Value);

            // PVP Options
            _PVPmode = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["PVPmode"].Attributes[typeof(DefaultValueAttribute)]).Value);
        }

        public void Save()
        {
            // Save the file
            Save(_file);
        }

        public void Save(string file)
        {
            // Check if the does not file exist
            if (!File.Exists(file))
            {
                // Create the file
                File.CreateText(file);
            }

            // Set the configuration values

            // Basic Options
            M_Config.AggroHP = _AggroHP;
            M_Config.AggroSP = _AggroSP;
            M_Config.KiteMonsters = Convert.ToInt32(_KiteMonsters);
            M_Config.SuperPassive = Convert.ToInt32(_SuperPassive);
            M_Config.UseAttackSkill = Convert.ToInt32(_UseAttackSkill);
            M_Config.AssumeHomun = Convert.ToInt32(_AssumeHomun);
            M_Config.DoNotChase = Convert.ToInt32(_DoNotChase);
            M_Config.UseDanceAttack = Convert.ToInt32(_UseDanceAttack);
            M_Config.AutoDetectPlant = Convert.ToInt32(_AutoDetectPlant);
            M_Config.TankMonsterLimit = _TankMonsterLimit;
            M_Config.RescueOwnerLowHP = _RescueOwnerLowHP;
            M_Config.StationaryAggroDist = _StationaryAggroDist;
            M_Config.MobileAggroDist = _MobileAggroDist;
            M_Config.OpportunisticTargeting = Convert.ToInt32(_OpportunisticTargeting);
            M_Config.AttackLastFullSP = Convert.ToInt32(_AttackLastFullSP);
            M_Config.AttackTimeLimit = _AttackTimeLimit;
            M_Config.LagReduction = _LagReduction;
            M_Config.DoNotAttackMoving = Convert.ToInt32(_DoNotAttackMoving);
            M_Config.LiveMobID = Convert.ToInt32(_LiveMobID);


            // AutoSkill Options
            M_Config.AttackSkillReserveSP = _AttackSkillReserveSP;
            M_Config.AutoMobCount = _AutoMobCount;
            M_Config.UseSkillOnly = Convert.ToInt32(_UseSkillOnly);
            M_Config.AutoSkillDelay = _AutoSkillDelay;
            M_Config.UseAutoPushback = Convert.ToInt32(_UseAutoPushback);
            M_Config.AutoPushbackThreshold = _AutoPushbackThreshold;
            M_Config.AoEReserveSP = Convert.ToInt32(_AoEReserveSP);
            M_Config.AoEFixedLevel = Convert.ToInt32(_AoEFixedLevel);
            M_Config.AutoMobMode = Convert.ToInt32(_AutoMobMode);
            M_Config.AoEMaximizeTargets = Convert.ToInt32(_AoEMaximizeTargets);


            // Walk/Follow Options
            M_Config.FollowStayBack = _FollowStayBack;
            M_Config.RestXOff = _RestXOff;
            M_Config.RestYOff = _RestYOff;
            M_Config.DoNotUseRest = Convert.ToInt32(_DoNotUseRest);
            M_Config.SpawnDelay = _SpawnDelay;
            M_Config.MoveSticky = Convert.ToInt32(_MoveSticky);
            M_Config.MoveStickyFight = Convert.ToInt32(_MoveStickyFight);
            M_Config.UseIdleWalk = Convert.ToInt32(_UseIdleWalk);
            M_Config.IdleWalkSP = _IdleWalkSP;
            M_Config.RelativeRoute = Convert.ToInt32(_RelativeRoute);
            M_Config.IdleWalkDistance = _IdleWalkDistance;
            M_Config.ChaseSPPause = Convert.ToInt32(_ChaseSPPause);
            M_Config.ChaseSPPauseSP = _ChaseSPPauseSP;
            M_Config.ChaseSPPauseTime = _ChaseSPPauseTime;
            M_Config.StationaryMoveBounds = _StationaryMoveBounds;
            M_Config.MobileMoveBounds = _MobileMoveBounds;

            // Autobuff Options
            M_Config.UseOffensiveBuff = Convert.ToInt32(_UseOffensiveBuff);
            M_Config.UseProvokeOwner = Convert.ToInt32(_UseProvokeOwner);
            M_Config.DefensiveBuffOwnerMobbed = _DefensiveBuffOwnerMobbed;
            M_Config.UseDefensiveBuff = Convert.ToInt32(_UseDefensiveBuff);
            M_Config.UseAutoMag = Convert.ToInt32(_UseAutoMag);
            M_Config.UseAutoSight = Convert.ToInt32(_UseAutoSight);
            M_Config.UseProvokeOwner = Convert.ToInt32(_UseProvokeOwner);
            M_Config.UseSacrificeOwner = Convert.ToInt32(_UseSacrificeOwner);
            M_Config.UseBlessingSelf = Convert.ToInt32(_UseBlessingSelf);
            M_Config.UseBlessingOwner = Convert.ToInt32(_UseBlessingOwner);
            M_Config.UseKyrieSelf = Convert.ToInt32(_UseKyrieSelf);
            M_Config.UseKyrieOwner = Convert.ToInt32(_UseKyrieOwner);
            M_Config.UseIncAgiSelf = Convert.ToInt32(_UseIncAgiSelf);
            M_Config.UseIncAgiOwner = Convert.ToInt32(_UseIncAgiOwner);
            M_Config.DefensiveBuffOwnerHP = _DefensiveBuffOwnerHP;

            // Kiting Options
            M_Config.KiteParanoid = Convert.ToInt32(_KiteParanoid);
            M_Config.KiteStep = _KiteStep;
            M_Config.KiteParanoidStep = _KiteParanoidStep;
            M_Config.KiteThreshold = _KiteThreshold;
            M_Config.KiteParanoidThreshold = _KiteParanoidThreshold;
            M_Config.KiteBounds = _KiteBounds;
            M_Config.ForceKite = Convert.ToInt32(_ForceKite);
            M_Config.FleeHP = _FleeHP;

            // Friending Options
            M_Config.StandbyFriending = Convert.ToInt32(_StandbyFriending);
            M_Config.MirAIFriending = Convert.ToInt32(_MirAIFriending);

            // Standby Options
            M_Config.DefendStandby = Convert.ToInt32(_DefendStandby);
            M_Config.StickyStandby = Convert.ToInt32(_StickyStandby);

            // Berserk Options
            M_Config.UseBerserkMobbed = _UseBerserkMobbed;
            M_Config.UseBerserkSkill = Convert.ToInt32(_UseBerserkSkill);
            M_Config.UseBerserkAttack = Convert.ToInt32(_UseBerserkAttack);
            M_Config.Berserk_SkillAlways = Convert.ToInt32(_Berserk_SkillAlways);
            M_Config.Berserk_Dance = Convert.ToInt32(_Berserk_Dance);
            M_Config.Berserk_IgnoreMinSP = Convert.ToInt32(_Berserk_IgnoreMinSP);

            // PVP Options
            M_Config.PVPmode = Convert.ToInt32(_PVPmode);

            M_Config.Save(file);
        }

        public void Open(string file)
        {
            // Check if the file does not exist
            if (!File.Exists(file))
            {
                // Throw a new file not found exception
                throw new FileNotFoundException("The specified file could not be found.", _file);
            }

            // Load configurations from the file
            M_Config.Load(file);

            // Initialize the values for this object
            InitValues();
        }

        void InitValues()
        {
            // Basic Options
            _AggroHP = M_Config.AggroHP;
            _AggroSP = M_Config.AggroSP;
            _KiteMonsters = Convert.ToBoolean(M_Config.KiteMonsters);
            _SuperPassive = Convert.ToBoolean(M_Config.SuperPassive);
            _UseAttackSkill = Convert.ToBoolean(M_Config.UseAttackSkill);
            _AssumeHomun = Convert.ToBoolean(M_Config.AssumeHomun);
            _DoNotChase = Convert.ToBoolean(M_Config.DoNotChase);
            _UseDanceAttack = Convert.ToBoolean(M_Config.UseDanceAttack);
            _AutoDetectPlant = Convert.ToBoolean(M_Config.AutoDetectPlant);
            _TankMonsterLimit = M_Config.TankMonsterLimit;
            _RescueOwnerLowHP = M_Config.RescueOwnerLowHP;
            _StationaryAggroDist = M_Config.StationaryAggroDist;
            _MobileAggroDist = M_Config.MobileAggroDist;
            _OpportunisticTargeting = Convert.ToBoolean(M_Config.OpportunisticTargeting);
            _AttackLastFullSP = Convert.ToBoolean(M_Config.AttackLastFullSP);
            _AttackTimeLimit = M_Config.AttackTimeLimit;
            _LagReduction = M_Config.LagReduction;
            _DoNotAttackMoving = Convert.ToBoolean(M_Config.DoNotAttackMoving);
            _LiveMobID = Convert.ToBoolean(M_Config.LiveMobID);

            // AutoSkill Options
            _AttackSkillReserveSP = M_Config.AttackSkillReserveSP;
            _AutoMobCount = M_Config.AutoMobCount;
            _UseSkillOnly = (UseSkillOnlyOptions)M_Config.UseSkillOnly;
            _AutoSkillDelay = M_Config.AutoSkillDelay;
            _UseAutoPushback = (UseAutoPushbackOptions)M_Config.UseAutoPushback;
            _AutoPushbackThreshold = M_Config.AutoPushbackThreshold;
            _AoEReserveSP = Convert.ToBoolean(M_Config.AoEReserveSP);
            _AoEFixedLevel = Convert.ToBoolean(M_Config.AoEFixedLevel);
            _AutoMobMode = (AutoMobModeOptions)M_Config.AutoMobMode;
            _AoEMaximizeTargets = Convert.ToBoolean(M_Config.AoEMaximizeTargets);

            // Walk/Follow Options
            _FollowStayBack = M_Config.FollowStayBack;
            _RestXOff = M_Config.RestXOff;
            _RestYOff = M_Config.RestYOff;
            _DoNotUseRest = Convert.ToBoolean(M_Config.DoNotUseRest);
            _SpawnDelay = M_Config.SpawnDelay;
            _MoveSticky = Convert.ToBoolean(M_Config.MoveSticky);
            _MoveStickyFight = Convert.ToBoolean(M_Config.MoveStickyFight);
            _UseIdleWalk = (UseIdleWalkOptions)M_Config.UseIdleWalk;
            _IdleWalkSP = M_Config.IdleWalkSP;
            _RelativeRoute = Convert.ToBoolean(M_Config.RelativeRoute);
            _IdleWalkDistance = M_Config.IdleWalkDistance;
            _ChaseSPPause = Convert.ToBoolean(M_Config.ChaseSPPause);
            _ChaseSPPauseSP = M_Config.ChaseSPPauseSP;
            _ChaseSPPauseTime = M_Config.ChaseSPPauseTime;
            _StationaryMoveBounds = M_Config.StationaryMoveBounds;
            _MobileMoveBounds = M_Config.MobileMoveBounds;

            // Autobuff Options
            _UseOffensiveBuff = (UseOffensiveBuffOptions)M_Config.UseOffensiveBuff;
            _UseProvokeOwner = (UseProvokeOwnerOptions)M_Config.UseProvokeOwner;
            _DefensiveBuffOwnerMobbed = M_Config.DefensiveBuffOwnerMobbed;
            _UseDefensiveBuff = (UseDefensiveBuffOptions)M_Config.UseDefensiveBuff;
            _UseAutoMag = (UseAutoMagOptions)M_Config.UseAutoMag;
            _UseAutoSight = Convert.ToBoolean(M_Config.UseAutoSight);
            _UseSacrificeOwner = Convert.ToBoolean(M_Config.UseSacrificeOwner);
            _UseBlessingSelf = (UseBlessingSelfOptions)M_Config.UseBlessingSelf;
            _UseBlessingOwner = (UseBlessingOwnerOptions)M_Config.UseBlessingOwner;
            _UseKyrieSelf = (UseKyrieSelfOptions)M_Config.UseKyrieSelf;
            _UseKyrieOwner = (UseKyrieOwnerOptions)M_Config.UseKyrieOwner;
            _UseIncAgiSelf = (UseIncAgiSelfOptions)M_Config.UseIncAgiSelf;
            _UseIncAgiOwner = (UseIncAgiOwnerOptions)M_Config.UseIncAgiOwner;
            _DefensiveBuffOwnerHP = M_Config.DefensiveBuffOwnerHP;

            // Kiting Options
            _KiteParanoid = Convert.ToBoolean(M_Config.KiteParanoid);
            _KiteStep = M_Config.KiteStep;
            _KiteParanoidStep = M_Config.KiteParanoidStep;
            _KiteThreshold = M_Config.KiteThreshold;
            _KiteParanoidThreshold = M_Config.KiteParanoidThreshold;
            _KiteBounds = M_Config.KiteBounds;
            _ForceKite = Convert.ToBoolean(M_Config.ForceKite);
            _FleeHP = M_Config.FleeHP;

            // Friending Options
            _StandbyFriending = Convert.ToBoolean(M_Config.StandbyFriending);
            _MirAIFriending = Convert.ToBoolean(M_Config.MirAIFriending);

            // Standby Options
            _DefendStandby = Convert.ToBoolean(M_Config.DefendStandby);
            _StickyStandby = (StickyStandbyOptions)M_Config.StickyStandby;

            // Berserk Options
            _UseBerserkMobbed = M_Config.UseBerserkMobbed;
            _UseBerserkSkill = Convert.ToBoolean(M_Config.UseBerserkSkill);
            _UseBerserkAttack = Convert.ToBoolean(M_Config.UseBerserkAttack);
            _Berserk_SkillAlways = Convert.ToBoolean(M_Config.Berserk_SkillAlways);
            _Berserk_Dance = Convert.ToBoolean(M_Config.Berserk_Dance);
            _Berserk_IgnoreMinSP = Convert.ToBoolean(M_Config.Berserk_IgnoreMinSP);

            // PVP Options
            _PVPmode = Convert.ToBoolean(M_Config.PVPmode);
        }

        #region Basic Options
        int _AggroHP = 60;
        [Category("Basic Options"),
        Description(
            "Your mercenary will seek out and attack monsters whenever its " +
            "HP percent (as percent of maximum HP; a number from 0-100) is " +
            "greater than this value. When it lacks HP, it will only fight " +
            "monsters if it is attacked.\n\nSet this value to 100 if you do " +
            "not want the mercenary to attack unless it, the owner, or a " +
            "friend is attacked."
            ),
        DefaultValue(60)]
        public int AggroHP
        {
            get { return _AggroHP; }
            set
            {
                if (value < 0)
                {
                    _AggroHP = 0;
                }
                else if (value > 100)
                {
                    _AggroHP = 100;
                }
                else
                {
                    _AggroHP = value;
                }
            }
        }


        int _AggroSP = 0;
        [Category("Basic Options"),
        Description(
            "Your mercenary will seek out and attack monsters whenever its " +
            "SP percent (as percent of maximum SP; a number from 0-100) is " +
            "greater than this value. When it lacks SP, it will only fight " +
            "monsters if it is attacked."
            ),
        DefaultValue(0)]
        public int AggroSP
        {
            get { return _AggroSP; }
            set {
                if (value < 0)
                {
                    _AggroSP = 0;
                }
                else if (value > 100) {
                    _AggroSP=100;
                }
                else{
                    _AggroSP = value; 
                }
            }
        }


        


        bool _KiteMonsters = false;
        [Category("Basic Options"),
        Description(
            "Set this to true if you want your mercenary to keep its " +
            "distance from monsters while attacking."
            ),
        DefaultValue(false)]
        public bool KiteMonsters
        {
            get { return _KiteMonsters; }
            set { _KiteMonsters = value; }
        }


        bool _SuperPassive = false;
        [Category("Basic Options"),
        Description(
            "If you want your mercenary to not fight or do anything other " +
            "than watch (and kite, if set to do so), set this value to " +
            "true. This is generally useless for a mercenary."
            ),
        DefaultValue(false)]
        public bool SuperPassive
        {
            get { return _SuperPassive; }
            set { _SuperPassive = value; }
        }


        bool _UseAttackSkill = true;
        [Category("Basic Options"),
        Description(
            "If you want your mercenary to automatically use offensive " +
            "skills when attacking, set this to true."
            ),
        DefaultValue(true)]
        public bool UseAttackSkill
        {
            get { return _UseAttackSkill; }
            set { _UseAttackSkill = value; }
        }

        bool _AssumeHomun = true;
        [Category("Basic Options"),
        Description(
            "If you plan to have both a mercenary and homunculus out at the " +
            "same time, set this value to true. This can be safely left true" +
            "unless you're trying to do something very strange"
            ),
        DefaultValue(true)]
        public bool AssumeHomun
        {
            get { return _AssumeHomun; }
            set { _AssumeHomun = value; }
        }


        bool _DoNotChase = false;
        [Category("Basic Options"),
        Description(
            "If you want your mercenary to stand still and only use ranged " +
            "skills or attacks, set this value to true."
            ),
        DefaultValue(false)]
        public bool DoNotChase
        {
            get { return _DoNotChase; }
            set { _DoNotChase = value; }
        }


        bool _UseDanceAttack = false;
        [Category("Basic Options"),
        Description(
            "Set this to true if you want your mercenary to bypass ASPD by " +
            "dancing while attacking."
            ),
        DefaultValue(false),
        Browsable(false)]
        public bool UseDanceAttack
        {
            get { return _UseDanceAttack; }
            set { _UseDanceAttack = value; }
        }

        bool _AutoDetectPlant = true;
        [Category("Basic Options"),
        Description(
            "Attempt to recognize plant-type monsters, and treat them " +
            "differently. (defaults to ignoring) " + 
            "Leave this True unless fighting immobile monsters"
            ),
        DefaultValue(true)]
        public bool AutoDetectPlant
        {
            get { return _AutoDetectPlant; }
            set { _AutoDetectPlant = value; }
        }

        int _TankMonsterLimit = 4;
        [Category("Basic Options"),
        Description(
            "When set to tank monsters for others to kill, gather this many " +
            "monsters before waiting for them to be killed. "
            ),
        DefaultValue(4)]
        public int TankMonsterLimit
        {
            get { return _TankMonsterLimit; }
            set
            {
                if (value < 1)
                {
                    _TankMonsterLimit = 1;
                }
                else if (value > 20)
                {
                    _TankMonsterLimit = 20;
                }
                else
                {
                    _TankMonsterLimit = value;
                }
            }
        }

        int _RescueOwnerLowHP = 0;
        [Category("Basic Options"),
        Description(
            "When set to a positive value, when owners HP as a percent is " +
            "less than this, always rescue, regardless of TACT_RESCUE" +
            "When set to a negative value, when owners HP as a percent is " +
            "more than this, disable rescue entirely"
            ),
        DefaultValue(0)]
        public int RescueOwnerLowHP
        {
            get { return _RescueOwnerLowHP; }
            set { _RescueOwnerLowHP = value; }
        }

        int _StationaryAggroDist = 10;
        [Category("Basic Options"),
        Description(
            "When the owner is is NOT moving, attack monsters within this " +
            "distance of the owner. See also MobileAggroDist"
            ),
        DefaultValue(10)]
        public int StationaryAggroDist
        {
            get { return _StationaryAggroDist; }
            set
            {
                if (value < 1)
                {
                    _StationaryAggroDist = 1;
                }
                else if (value > 15)
                {
                    _StationaryAggroDist = 15;
                }
                else
                {
                    _StationaryAggroDist = value;
                }
            }
        }


        int _MobileAggroDist = 5;
        [Category("Basic Options"),
        Description(
            "When the owner is is moving, attack monsters within this " +
            "distance of the owner. See also StationaryAggroDist. " +
            "This should probably be relatively low so that the merc " +
            "does not get left behind after chasing something while the " +
            "owner is moving"
            ),
        DefaultValue(5)]
        public int MobileAggroDist
        {
            get { return _MobileAggroDist; }
            set
            {
                if (value < 1)
                {
                    _MobileAggroDist = 1;
                }
                else if (value > 15)
                {
                    _MobileAggroDist = 15;
                }
                else
                {
                    _MobileAggroDist = value;
                }
            }
        }


        bool _OpportunisticTargeting = false;
        [Category("Basic Options"),
        Description(
            "If enabled, the mercenary will switch targets if a better target" +
            "is closer. "
            ),
        DefaultValue(false)]
        public bool OpportunisticTargeting
        {
            get { return _OpportunisticTargeting; }
            set { _OpportunisticTargeting = value; }
        }

        bool _AttackLastFullSP = false;
        [Category("Basic Options"),
        Description(
            "If enabled, targets with the ATTACK_LAST tactic will only be" +
            "attacked if the homun is at full SP"
            ),
        DefaultValue(false)]
        public bool AttackLastFullSP
        {
            get { return _AttackLastFullSP; }
            set { _AttackLastFullSP = value; }
        }
        int _AttackTimeLimit = 10000;
        [Category("Basic Options"),
        Description(
            "This is the longest time, in milliseconds, that the "+
            "mercenary will spend trying to attack a target which it has already attacked - this is to prevent homun from getting hung up on posbugged or inaccessible monsters. As of 1.54, this timer is reset if we see the monster flinching while nothing else is targeting it - that should mean that we're successfully attacking it, and should keep going"
            ),
        DefaultValue(10000)]
        public int AttackTimeLimit
        {
            get { return _AttackTimeLimit; }
            set
            {
                if (value < 1000)
                {
                    _AttackTimeLimit = 1000;
                }
                else if (value > 30000)
                {
                    _AttackTimeLimit = 30000;
                }
                else
                {
                    _AttackTimeLimit = value;
                }
            }
        }
        int _LagReduction = 0;
        [Category("Basic Options"),
        Description(
            "If you experience lag that appears only with mercenary out on some maps, try setting this to 1. This will reduce responsiveness on maps that do not lag." +
            "In severe cases, this can be set to 2, or even higher. This will greatly slow the mercenary's reaction time, and should be used only if truly necessary"
            ),
        DefaultValue(0)]
        public int LagReduction
        {
            get { return _LagReduction; }
            set {
                if (value < 0)
                {
                    _LagReduction = 0;
                }
                else if (value > 5)
                {
                    _LagReduction = 5;
                }
                else
                {
                    _LagReduction = value;
                }
            }
        }
        bool _DoNotAttackMoving = false;
        [Category("Basic Options"),
        Description(
            "Enable this while on busy maps if you lag with merc out there. " +
            "Otherwise, turn it off, because it reduces performance"
            ),
        DefaultValue(false)]
        public bool DoNotAttackMoving
        {
            get { return _DoNotAttackMoving; }
            set { _DoNotAttackMoving = value; }
        }
        bool _LiveMobID = false;
        [Category("Basic Options"),
        Description(
            "If enabled, and owner has homun out, and homun has LiveMobID enabled as well, the mercenary will be able to identify monsters on screen as long as the homun is alive. "+
            "See the documentation for more details. This may cause performance problems on some systems. "
            ),
        DefaultValue(false)]
        public bool LiveMobID
        {
            get { return _LiveMobID; }
            set { _LiveMobID = value; }
        }
        #endregion


        #region AutoSkill Options
        int _AttackSkillReserveSP = 0;
        [Category("AutoSkill Options"),
        Description(
            "To control SP use, you may not want your mercenary to use " +
            "skills unless there would be enough SP left to recast some " +
            "sort of buff. Set this value to this minimum SP value to " +
            "control this this."
            ),
        DefaultValue(0)]
        public int AttackSkillReserveSP
        {
            get { return _AttackSkillReserveSP; }
            set
            {
                if (value < 0)
                {
                    _AttackSkillReserveSP = 0;
                }
                else if (value > 6000)
                {
                    _AttackSkillReserveSP = 6000;
                }
                else
                {
                    _AttackSkillReserveSP = value;
                }
            }
        }


        int _AutoMobCount = 2;
        [Category("AutoSkill Options"),
        Description(
            "If the mercenary has an anto-mob skill, the skill will be " +
            "automatically used if the number of monsters in close " +
            "proximity to the mercenary or owner is equal to or greater " +
            "than this value."
            ),
        DefaultValue(2)]
        public int AutoMobCount
        {
            get { return _AutoMobCount; }
            set
            {
                if (value < 0)
                {
                    _AutoMobCount = 0;
                }
                else if (value > 20)
                {
                    _AutoMobCount = 20;
                }
                else
                {
                    _AutoMobCount = value;
                }
            }
        }


        UseSkillOnlyOptions _UseSkillOnly = UseSkillOnlyOptions.Chasing;
        [Category("AutoSkill Options"),
        Description(
            "If you want your mercenary to use skills while attacking and " +
            "while chasing if their skill has a longer range than their "+ 
            "normal attack, set this to Chasing. If you want it to use skills " +
            "only while in melee range, set this to Attacking. If you want it to only use " +
            "skills and not attack normally, set this to SkillOnly."
            ),
        DefaultValue(UseSkillOnlyOptions.Chasing)]
        public UseSkillOnlyOptions UseSkillOnly
        {
            get { return _UseSkillOnly; }
            set { _UseSkillOnly = value; }
        }


        int _AutoSkillDelay = 400;
        [Category("AutoSkill Options"),
        Description(
            "This value is the delay (in ms) between uses of a skill. If " +
            "you are having problems with the mercenary \"double casting\" " +
            "skills, increase this value. Otherwise, leave it be."
            ),
        DefaultValue(400)]
        public int AutoSkillDelay
        {
            get { return _AutoSkillDelay; }
            set
            {
                if (value < 100)
                {
                    _AutoSkillDelay = 100;
                }
                else if (value > 750)
                {
                    _AutoSkillDelay = 750;
                }
                else
                {
                    _AutoSkillDelay = value;
                }
            }
        }


        UseAutoPushbackOptions _UseAutoPushback = UseAutoPushbackOptions.Off;
        [Category("AutoSkill Options"),
        Description(
            "If you want your mercenary to use pushback skills, set this " +
            "to self. If you want the mercenary to use pushback skills " +
            "when its owner or other friends are being attacked, set this " +
            "to all (not recommended). Otherwise, set this to Off."
            ),
        DefaultValue(UseAutoPushbackOptions.Off)]
        public UseAutoPushbackOptions UseAutoPushback
        {
            get { return _UseAutoPushback; }
            set { _UseAutoPushback = value; }
        }


        int _AutoPushbackThreshold = 2;
        [Category("AutoSkill Options"),
        Description(
            "If UseAutoPushback is turned on, this is the distance between " +
            "a monster and its target that determins when the mercenary " +
            "will use its pushback skill."
            ),
        DefaultValue(2)]
        public int AutoPushbackThreshold
        {
            get { return _AutoPushbackThreshold; }
            set
            {
                if (value < 1)
                {
                    _AutoPushbackThreshold = 1;
                }
                else if (value > 6)
                {
                    _AutoPushbackThreshold = 6;
                }
                else
                {
                    _AutoPushbackThreshold = value;
                }
            }
        }


        

        bool _AoEMaximizeTargets = true;
        [Category("AutoSkill Options"),
        Description(
            "Attempt to hit as mant targets as possible with FAS."
            ),
        DefaultValue(false)]
        public bool AoEMaximizeTargets
        {
            get { return _AoEMaximizeTargets; }
            set { _AoEMaximizeTargets = value; }
        }
        bool _AoEReserveSP = false;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to not use non-AoE skill attacks unless doing so " +
            "would leave enough SP to cast the homun's AoE attack. "
            ),
        DefaultValue(false)]
        public bool AoEReserveSP
        {
            get { return _AoEReserveSP; }
            set { _AoEReserveSP = value; }
        }

        bool _AoEFixedLevel = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to ignore skill level tactics when using  " +
            "AoE attacks. "
            ),
        DefaultValue(true)]
        public bool AoEFixedLevel
        {
            get { return _AoEFixedLevel; }
            set { _AoEFixedLevel = value; }
        }

        AutoMobModeOptions _AutoMobMode = AutoMobModeOptions.Aggressive;
        [Category("AutoSkill Options"),
        Description(
            "Select whether to automatically use anti-mob skills and whether" +
            "to base that decision on the number of aggressive monsters in the" +
            "AoE, or the number of ALL monsters, aggressive or not"
            ),
        DefaultValue(AutoMobModeOptions.Aggressive)]
        public AutoMobModeOptions AutoMobMode
        {
            get { return _AutoMobMode; }
            set { _AutoMobMode = value; }
        }

        #endregion


        #region Walk/Follow Options
        int _FollowStayBack = 2;
        [Category("Walk/Follow Options"),
        Description(
            "Your mercenary will stay this many cells behind you when " +
            "following you."
            ),
        DefaultValue(2)]
        public int FollowStayBack
        {
            get { return _FollowStayBack; }
            set
            {
                if (value < 0)
                {
                    _FollowStayBack = 0;
                }
                else if (value > 10)
                {
                    _FollowStayBack = 10;
                }
                else
                {
                    _FollowStayBack = value;
                }
            }
        }



        int _RestXOff = -2;
        [Category("Walk/Follow Options"),
        Description(
            "If set to rest, the mercenary will move this many cells east " +
            "of you when you sit.\n\nSetting this to a negative number will " +
            "cause the mercenary to move west instead."
            ),
        DefaultValue(-2)]
        public int RestXOff
        {
            get { return _RestXOff; }
            set
            {
                if (value < -8)
                {
                    _RestXOff = -8;
                }
                else if (value > 8)
                {
                    _RestXOff = 8;
                }
                else
                {
                    _RestXOff = value;
                }
            }
        }


        int _RestYOff = 0;
        [Category("Walk/Follow Options"),
        Description(
            "If set to rest, the mercenary will move this many cells north " +
            "of you when you sit.\n\nSetting this to a negative number will " +
            "cause the mercenary to move south instead."
            ),
        DefaultValue(0)]
        public int RestYOff
        {
            get { return _RestYOff; }
            set
            {
                if (value < -8)
                {
                    _RestYOff = -8;
                }
                else if (value > 8)
                {
                    _RestYOff = 8;
                }
                else
                {
                    _RestYOff = value;
                }
            }
        }


        bool _DoNotUseRest = false;
        [Category("Walk/Follow Options"),
        Description(
            "Set this to false if when you sit down, you want your mercenary to become passive, and, when it becomes idle, will move close to you."
            ),
        DefaultValue(false)]
        public bool DoNotUseRest
        {
            get { return _DoNotUseRest; }
            set { _DoNotUseRest = value; }
        }


        int _SpawnDelay = 1000;
        [Category("Walk/Follow Options"),
        Description(
            "Upon spawning, the mercenary will wait for this many " +
            "miliseconds before taking any actions. This prevents it from " +
            "wasting its immunity time and also prevents it from KSing " +
            "after teleporting or changing maps.\n\nSetting this value to " +
            "1000 (1 second) is a good idea."
            ),
        DefaultValue(1000)]
        public int SpawnDelay
        {
            get { return _SpawnDelay; }
            set
            {
                if (value < 100)
                {
                    _SpawnDelay = 100;
                }
                else if (value > 2000)
                {
                    _SpawnDelay = 2000;
                }
                else
                {
                    _SpawnDelay = value;
                }
            }
        }


        


        bool _MoveSticky = false;
        [Category("Walk/Follow Options"),
        Description(
            "Set this to true if you want your mercenary to stay put when " +
            "told to go somewhere."
            ),
        DefaultValue(false)]
        public bool MoveSticky
        {
            get { return _MoveSticky; }
            set { _MoveSticky = value; }
        }


        bool _MoveStickyFight = false;
        [Category("Walk/Follow Options"),
        Description(
            "Set this to true if you want your mercenary to fight normally " +
            "if MoveSticky is set to true."
            ),
        DefaultValue(false)]
        public bool MoveStickyFight
        {
            get { return _MoveStickyFight; }
            set { _MoveStickyFight = value; }
        }

        UseIdleWalkOptions _UseIdleWalk = UseIdleWalkOptions.None;
        [Category("Walk/Follow Options"),
        Description(
            "When at full hp with nothing better to do, set this option to " +
            "the pattern that it should walk in. See documentation for" +
            "more information before using Route walk"
            ),
        DefaultValue(UseIdleWalkOptions.None)]
        public UseIdleWalkOptions UseIdleWalk
        {
            get { return _UseIdleWalk; }
            set { _UseIdleWalk = value; }
        }
        int _IdleWalkSP = 80;
        [Category("Walk/Follow Options"),
        Description(
            "Only use IdleWalk when SP is above this, as a %" +
            "                                                              "
            ),
        DefaultValue(80)]
        public int IdleWalkSP
        {
            get { return _IdleWalkSP; }
            set
            {
                if (value < 0)
                {
                    _IdleWalkSP = 0;
                }
                else if (value > 100)
                {
                    _IdleWalkSP = 100;
                }
                else
                {
                    _IdleWalkSP = value;
                }
            }
        }
        bool _RelativeRoute = false;
        [Category("Walk/Follow Options"),
        Description(
            "Enable this to use relative routes. See documentation" +
            "                                                              "
            ),
        DefaultValue(false)]
        public bool RelativeRoute
        {
            get { return _RelativeRoute; }
            set { _RelativeRoute = value; }
        }

        int _IdleWalkDistance = 4;
        [Category("Walk/Follow Options"),
        Description(
            "When walking while idle, keep this distance from owner." +
            "                                                              "
            ),
        DefaultValue(4)]
        public int IdleWalkDistance
        {
            get { return _IdleWalkDistance; }
            set { _IdleWalkDistance = value; }
        }

        bool _ChaseSPPause = false;
        [Category("Walk/Follow Options"),
        Description(
            "Enable this to use Clever Chase unless tactics specify otherwise" +
            "this will also enable clever-chase behavior for returning to owner" +
            "after killing something. Clever chase helps SP recovery by delaying" +
            "movement if homun is about to regen sp."
            ),
        DefaultValue(false)]
        public bool ChaseSPPause
        {
            get { return _ChaseSPPause; }
            set { _ChaseSPPause = value; }
        }

        int _ChaseSPPauseSP = 0;
        [Category("Walk/Follow Options"),
        Description(
            "This is the SP threshold to enable clever-chase. " +
            "Set to a positive value to give the absolute value" +
            "and a negative vale for a percentage"
            ),
        DefaultValue(-20)]
        public int ChaseSPPauseSP
        {
            get { return _ChaseSPPauseSP; }
            set
            {
                if (value < -100)
                {
                    _ChaseSPPauseSP = -100;
                }
                else if (value > 6000)
                {
                    _ChaseSPPauseSP = 6000;
                }
                else
                {
                    _ChaseSPPauseSP = value;
                }
            }
        }

        int _ChaseSPPauseTime = 2000;
        [Category("Walk/Follow Options"),
        Description(
            "If clever-chase is used, it will delay movement if it expects" +
            "an sp regen tick within this many milliseconds"
            ),
        DefaultValue(2000)]
        public int ChaseSPPauseTime
	{
		get { return _ChaseSPPauseTime; }
		set {
			if (value < 100)
			{
				_ChaseSPPauseTime=100;
			}
			else if (value > 6000){
				_ChaseSPPauseTime=6000;
			}
			else{
				_ChaseSPPauseTime= value;
			}
		}
	}

        int _StationaryMoveBounds = 12;
        [Category("Walk/Follow Options"),
        Description(
            "This is the farthest from the owner that the merc will be allowed " +
            "to get before dropping all targets and moving back to the owner. This " +
            "value is used while the owner is NOT moving (see also MobileMoveBounds) " +
            "To control aggro range of merc, use the AggroDist options, not MoveBounds. " +
            "To set distance from owner that merc should return to after killing " +
            "use FollowStayBack, not MoveBounds. "
            ),
        DefaultValue(12)]
        public int StationaryMoveBounds
        {
            get { return _StationaryMoveBounds; }
            set
            {
                if (value < 1)
                {
                    _StationaryMoveBounds = 1;
                }
                else if (value > 15)
                {
                    _StationaryMoveBounds = 15;
                }
                else
                {
                    _StationaryMoveBounds = value;
                }
            }
        }
        int _MobileMoveBounds = 5;
        [Category("Walk/Follow Options"),
        Description(
            "This is the farthest from the owner that the merc will be allowed " +
            "to get before dropping all targets and moving back to the owner. This " +
            "value is used while the owner IS moving (see also StationaryMoveBounds) " +
            "To control aggro range of merc, use the AggroDist options, not MoveBounds. " +
            "This should probably be lower than StationaryMoveBounds to help keep merc " +
            "from being left behind."
            ),
        DefaultValue(5)]
        public int MobileMoveBounds
        {
            get { return _MobileMoveBounds; }
            set
            {
                if (value < 1)
                {
                    _MobileMoveBounds = 1;
                }
                else if (value > 15)
                {
                    _MobileMoveBounds = 15;
                }
                else
                {
                    _MobileMoveBounds = value;
                }
            }
        }
        #endregion


        #region Autobuff Options
        UseOffensiveBuffOptions _UseOffensiveBuff = UseOffensiveBuffOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Set this to true if you want your mercenary to use Weapon " +
            "Quicken or other offensive buffs"
            ),
        DefaultValue(true)]
        public UseOffensiveBuffOptions UseOffensiveBuff
        {
            get { return _UseOffensiveBuff; }
            set { _UseOffensiveBuff = value; }
        }


        UseDefensiveBuffOptions _UseDefensiveBuff = UseDefensiveBuffOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Set this to true if you want your mercenary to use Guard " +
            "Parrying, or other defensive buffs."
            ),
        DefaultValue(true)]
        public UseDefensiveBuffOptions UseDefensiveBuff
        {
            get { return _UseDefensiveBuff; }
            set { _UseDefensiveBuff = value; }
        }
        UseProvokeOwnerOptions _UseProvokeOwner = UseProvokeOwnerOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Provoke on owner in the following states" +
            "                                                              "
            ),
        DefaultValue(UseProvokeOwnerOptions.Never)]
        public UseProvokeOwnerOptions UseProvokeOwner
        {
            get { return _UseProvokeOwner; }
            set { _UseProvokeOwner = value; }
        }

        UseAutoMagOptions _UseAutoMag = UseAutoMagOptions.Idle;
        [Category("Autobuff Options"),
        Description(
            "Enable this if you want your level 4 archer mercenary" +
            "to use magnificat. This works like all other buffs"
            ),
        DefaultValue(UseAutoMagOptions.Idle)]
        public UseAutoMagOptions UseAutoMag
        {
            get { return _UseAutoMag; }
            set { _UseAutoMag = value; }
        }
        int _DefensiveBuffOwnerMobbed = 0;
        [Category("Autobuff Options"),
        Description(
            "Do not use use a defensive buff (Kyrie) on the owner unless" +
            "they have at least this many monsters attacking them, and the"+
            "the owner's HP as a percentage is below DefensiveBuffOwnerHP"
            ),
        DefaultValue(0)]
        public int DefensiveBuffOwnerMobbed
        {
            get { return _DefensiveBuffOwnerMobbed; }
            set
            {
                if (value < 0)
                {
                    _DefensiveBuffOwnerMobbed = 0;
                }
                else if (value > 10)
                {
                    _DefensiveBuffOwnerMobbed = 10;
                }
                else
                {
                    _DefensiveBuffOwnerMobbed = value;
                }
            }
        }
        

        bool _UseAutoSight = false;
        [Category("Autobuff Options"),
        Description(
            "Set this to true if you want your level 2 archer mercenary" +
            "to use sight."
            ),
        DefaultValue(false)]
        public bool UseAutoSight
        {
            get { return _UseAutoSight; }
            set { _UseAutoSight = value; }
        }


        bool _UseSacrificeOwner = true;
        [Category("Autobuff Options"),
        Description(
            "Set this to true if you want your mercenary to use Sacrifice " +
            "on you. Note that you must be within 10 levels of your mercenary " +
            "and that the skill is buggy."
            ),
        DefaultValue(true)]
        public bool UseSacrificeOwner
        {
            get { return _UseSacrificeOwner; }
            set { _UseSacrificeOwner = value; }
        }

        UseBlessingOwnerOptions _UseBlessingOwner = UseBlessingOwnerOptions.Idle;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Blessing on owner in this situation " +
            "                                                              "
            ),
        DefaultValue(UseBlessingOwnerOptions.Never)]
        public UseBlessingOwnerOptions UseBlessingOwner
        {
            get { return _UseBlessingOwner; }
            set { _UseBlessingOwner = value; }
        }
        UseBlessingSelfOptions _UseBlessingSelf = UseBlessingSelfOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Blessing on owner in this situation "  +
            "                                                              "
            ),
        DefaultValue(UseBlessingSelfOptions.Never)]
        public UseBlessingSelfOptions UseBlessingSelf
        {
            get { return _UseBlessingSelf; }
            set { _UseBlessingSelf = value; }
        }

        UseKyrieOwnerOptions _UseKyrieOwner = UseKyrieOwnerOptions.Idle;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Kyrie Eleison on owner in this situation " +
            "Use DefensiveBuffOwnerMobbed and DefensiveBuffOwnerHP to only"+
            "use this skill when the owner is under attack"
            ),
        DefaultValue(UseKyrieOwnerOptions.Never)]
        public UseKyrieOwnerOptions UseKyrieOwner
        {
            get { return _UseKyrieOwner; }
            set { _UseKyrieOwner = value; }
        }

        UseKyrieSelfOptions _UseKyrieSelf = UseKyrieSelfOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Kyrie Eleison on the mercenary in this situation " +
            "                                                              "
            ),
        DefaultValue(UseKyrieSelfOptions.Never)]
        public UseKyrieSelfOptions UseKyrieSelf
        {
            get { return _UseKyrieSelf; }
            set { _UseKyrieSelf = value; }
        }

        UseIncAgiOwnerOptions _UseIncAgiOwner = UseIncAgiOwnerOptions.Idle;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Increase Agi on owner in this situation " +
            "                                                              "
            ),
        DefaultValue(UseIncAgiOwnerOptions.Never)]
        public UseIncAgiOwnerOptions UseIncAgiOwner
        {
            get { return _UseIncAgiOwner; }
            set { _UseIncAgiOwner = value; }
        }

        UseIncAgiSelfOptions _UseIncAgiSelf = UseIncAgiSelfOptions.Idle;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Increase Agi on mercenary in this situation " +
            "                                                              "
            ),
        DefaultValue(UseIncAgiSelfOptions.Never)]
        public UseIncAgiSelfOptions UseIncAgiSelf
        {
            get { return _UseIncAgiSelf; }
            set { _UseIncAgiSelf = value; }
        }

        int _DefensiveBuffOwnerHP = 100;
        [Category("Autobuff Options"),
        Description(
            "If (and only if) DefensiveBuffOwnerMobbed is enabled (ie, set " +
            "to a non-zero value), defensive buffs (painkiller and Kyrie)" +
            "will be used only when there are at least the specified number" +
            "of monsters on the owner, and the owner's HP (as a percentage)" +
            "is lower than DefensiveBuffOwnerHP"
            ),
        DefaultValue(100)]
        public int DefensiveBuffOwnerHP
        {
            get { return _DefensiveBuffOwnerHP; }
            set
            {
                if (value < 0)
                {
                    _DefensiveBuffOwnerHP = 0;
                }
                else if (value > 100)
                {
                    _DefensiveBuffOwnerHP = 100;
                }
                else
                {
                    _DefensiveBuffOwnerHP = value;
                }
            }
        }


        #endregion


        #region Kiting Options
        bool _KiteParanoid = true;
        [Category("Kiting Options"),
        Description(
            "Set this to true if you want your mercenary to kite away from"+
            "monsters before being attacked by them"
            ),
        DefaultValue(true)]
        public bool KiteParanoid
        {
            get { return _KiteParanoid; }
            set { _KiteParanoid = value; }
        }


        int _KiteStep = 5;
        [Category("Kiting Options"),
        Description(
            "Move this many cells when kiting."
            ),
        DefaultValue(5)]
        public int KiteStep
        {
            get { return _KiteStep; }
            set
            {
                if (value < 2)
                {
                    _KiteStep = 2;
                }
                else if (value > 8)
                {
                    _KiteStep = 8;
                }
                else
                {
                    _KiteStep = value;
                }
            }
        }


        int _KiteParanoidStep = 2;
        [Category("Kiting Options"),
        Description(
            "Move this many cells when kiting from a monster that."+
            "has not yet attacked the mercenary."
            ),
        DefaultValue(2)]
        public int KiteParanoidStep
        {
            get { return _KiteParanoidStep; }
            set
            {
                if (value < 2)
                {
                    _KiteParanoidStep = 2;
                }
                else if (value > 8)
                {
                    _KiteParanoidStep = 8;
                }
                else
                {
                    _KiteParanoidStep = value;
                }
            }
        }


        int _KiteThreshold = 3;
        [Category("Kiting Options"),
        Description(
            "Kite when a monster is within this many cells." +
            ""
            ),
        DefaultValue(3)]
        public int KiteThreshold
        {
            get { return _KiteThreshold; }
            set
            {
                if (value < 1)
                {
                    _KiteThreshold = 1;
                }
                else if (value > 8)
                {
                    _KiteThreshold = 8;
                }
                else
                {
                    _KiteThreshold = value;
                }
            }
        }


        int _KiteParanoidThreshold = 2;
        [Category("Kiting Options"),
        Description(
            "Kite when a monster that has not yet attacked "+
            "is within this many cells."
            ),
        DefaultValue(2)]
        public int KiteParanoidThreshold
        {
            get { return _KiteParanoidThreshold; }
            set
            {
                if (value < 1)
                {
                    _KiteParanoidThreshold = 1;
                }
                else if (value > 8)
                {
                    _KiteParanoidThreshold = 8;
                }
                else
                {
                    _KiteParanoidThreshold = value;
                }
            }
        }


        int _KiteBounds = 8;
        [Category("Kiting Options"),
        Description(
            "When kiting do not exceed this distance from owner"
            ),
        DefaultValue(8)]
        public int KiteBounds
        {
            get { return _KiteBounds; }
            set
            {
                if (value < 0)
                {
                    _KiteBounds = 0;
                }
                else if (value > 15)
                {
                    _KiteBounds = 15;
                }
                else
                {
                    _KiteBounds = value;
                }
            }
        }


        bool _ForceKite = false;
        [Category("Kiting Options"),
        Description(
            "Set this to true if you want your mercenary to kite monsters." +
            "even if it has no ranged attack. This may result in odd behavior"
            ),
        DefaultValue(false)]
        public bool ForceKite
        {
            get { return _ForceKite; }
            set { _ForceKite = value; }
        }
        int _FleeHP = 0;
        [Category("Kiting Options"),
        Description("If non-zero and kiting is enabled, only kite below this percent HP"),
        DefaultValue(0)]
        public int FleeHP
        {
            get { return _FleeHP; }
            set
            {
                if (value < 0)
                {
                    _FleeHP = 0;
                }
                else if (value > 100)
                {
                    _FleeHP = 100;
                }
                else
                {
                    _FleeHP = value;
                }
            }
        }
        #endregion


        #region Friending Options
        bool _StandbyFriending = false;
        [Category("Friending Options"),
        Description(),
        DefaultValue(false)]
        public bool StandbyFriending
        {
            get { return _StandbyFriending; }
            set { _StandbyFriending = value; }
        }


        bool _MirAIFriending = true;
        [Category("Friending Options"),
        Description(
            "Set this to true if you want the mercenary to emulate MirAI " +
            "friending."
            ),
        DefaultValue(true)]
        public bool MirAIFriending
        {
            get { return _MirAIFriending; }
            set { _MirAIFriending = value; }
        }
        #endregion


        #region Standby Options
        bool _DefendStandby = false;
        [Category("Standby Options"),
        Description(
            "Set this to true if you want your mercenary to defend you " +
            "even while in standby."
            ),
        DefaultValue(false)]
        public bool DefendStandby
        {
            get { return _DefendStandby; }
            set { _DefendStandby = value; }
        }


        StickyStandbyOptions _StickyStandby = StickyStandbyOptions.Disabled;
        [Category("Standby Options"),
        Description(
            "Set this to true if you want your mercenary to return to " +
            "standby mode after attacking, using skills, etc."
            ),
        DefaultValue(StickyStandbyOptions.Disabled)]
        public StickyStandbyOptions StickyStandby
        {
            get { return _StickyStandby; }
            set { _StickyStandby = value; }
        }
        #endregion


        #region Berserk Options
        int _UseBerserkMobbed = 0;
        [Category("Berserk Options"),
        Description(
            "If you want your mercenary to go berserk while being " +
            "attacked, set this to a value greater than 0. Otherwise, set " +
            "it to 0 to disable berserk mode while being mobbed."
            ),
        DefaultValue(0)]
        public int UseBerserkMobbed
        {
            get { return _UseBerserkMobbed; }
            set { _UseBerserkMobbed = value; }
        }


        bool _UseBerserkSkill = false;
        [Category("Berserk Options"),
        Description(
            "Set to true to have your mercenary go berserk when told to " +
            "use a skill on a target."
            ),
        DefaultValue(false)]
        public bool UseBerserkSkill
        {
            get { return _UseBerserkSkill; }
            set { _UseBerserkSkill = value; }
        }


        bool _UseBerserkAttack = false;
        [Category("Berserk Options"),
        Description(
            "Set this to true to have your mercenary go berserk when told " +
            "to attack a target."
            ),
        DefaultValue(false)]
        public bool UseBerserkAttack
        {
            get { return _UseBerserkAttack; }
            set { _UseBerserkAttack = value; }
        }


        bool _Berserk_SkillAlways = true;
        [Category("Berserk Options"),
        Description(
            "Set this to true to ignore skill use limits while in berserk " +
            "mode."
            ),
        DefaultValue(true)]
        public bool Berserk_SkillAlways
        {
            get { return _Berserk_SkillAlways; }
            set { _Berserk_SkillAlways = value; }
        }


        bool _Berserk_Dance = false;
        [Category("Berserk Options"),
        Description(
            "Set this to true if you want your mercenary to use dance " +
            "attack while in berserk mode."
            ),
        DefaultValue(false)]
        public bool Berserk_Dance
        {
            get { return _Berserk_Dance; }
            set { _Berserk_Dance = value; }
        }
        
        bool _Berserk_IgnoreMinSP = true;
        [Category("Berserk Options"),
        Description(
            "Set this to true if you want your mercenary to use ignore " +
            "AttackSkillReserveSP when in berserk mode."
            ),
        DefaultValue(true)]
        public bool Berserk_IgnoreMinSP
        {
            get { return _Berserk_IgnoreMinSP; }
            set { _Berserk_IgnoreMinSP = value; }
        }
        #endregion


        #region PVP Options
        bool _PVPmode = false;
        [Category("PVP Options"),
        Description(
            "Set this to true if you want to use your mercenary in PVP " +
            "enabled maps."
            ),
        DefaultValue(false)]
        public bool PVPmode
        {
            get { return _PVPmode; }
            set { _PVPmode = value; }
        }
        #endregion
    }
}