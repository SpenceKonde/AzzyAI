// HomConf.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the class HomConf, which is used as a proxy to hold
// the data for H_Config, and enumerations for UseSkillOnlyOptions,
// UseAutoPushbackOptions, and UsePierceSizeOptions to restrict certain
// variables to specific values.

using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;


namespace AzzyAIConfig
{
    enum UseSkillOnlyOptions : sbyte
    {
        Attacking  = 0,
        Chasing = -1,
        SkillOnly = 1
    }
    enum UseAutoMagOptions : sbyte
    {
        Never = 0,
        Idle = 1,
        Chase = -1,
        Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
    }
    enum UseAutoPushbackOptions : sbyte
    {
        Off = 0,
        Self = 1,
        All = 2
    }

	enum OldHomunTypeOptions : sbyte
	{
		Lif = 1,
		Amistr = 2,
		Filir = 3
	}

	enum UseSeraPainkillerOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
    enum UseProvokeOwnerOptions : sbyte
    {
        Never = 0,
        Idle = 1,
        Chase = -1,
        Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
    }
	enum UseBayeriAngriffModusOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
		Berserk = 2,
        ASAP = 3
	}
    enum UseOffensiveBuffOptions : sbyte
    {
        Never = 0,
        Idle = 1,
        Chase = -1,
        Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
    }
    enum UseDefensiveBuffOptions : sbyte
    {
        Never = 0,
        Idle = 1,
        Chase = -1,
        Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
    }
	enum UseBayeriGoldenPherzeOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseDieterMagmaFlowOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseDieterGraniticArmorOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseDieterPyroclasticOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseEiraOveredBoostOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseAutoHealOptions : sbyte
	{
		Never = 0,
		Always = 1,
		Idle = 2,
		Idle_low= 3
	}
    enum HealOwnerBreezeOptions : sbyte
    {
        Disabled = 0,
        Enabled = 1
    }
	enum LavaSlideModeOptions : sbyte
	{
		Attack = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2
	}
	enum PoisonMistModeOptions : sbyte
	{
		Attack = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2
	}
	enum UseBayeriSteinWandOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
    	enum UseBlessingSelfOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseBlessingOwnerOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseKyrieSelfOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseKyrieOwnerOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseIncAgiSelfOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}
	enum UseIncAgiOwnerOptions : sbyte
	{
		Never = 0,
		Idle = 1,
		Chase = -1,
		Idle_Low = -2,
        Berserk = 2,
        ASAP = 3
	}


	enum AutoMobModeOptions : sbyte
	{
		Disabled = 0,
		Aggressive = 1,
		All = 2
	}
	enum AutoComboModeOptions : sbyte
	{
		Never = 0,
		Tactics = 1,
		Always = 2
	}

	enum UseIdleWalkOptions : sbyte
	{
		None = 0,
		Circle = 1,
		Cross = 2,
		Square = 3,
		Random = 4,
		Route_Linear= 5,
		Route_Circle= 6
	}

    enum StickyStandbyOptions
    {
        Disabled=0,
        Enabled=1,
        Enabled_Relog=2
    }

    class HomConf
    {
        // The default file
        string _file = "H_Config.lua";

        public HomConf()
        {
            // Check if the file does not exist
            if (!File.Exists(_file))
            {
                // Throw a new file not found exception
                throw new FileNotFoundException("The default file could not be found.", _file);
            }

            // Load configurations from the file
            H_Config.Load(_file);

            // Initialize this object's values
            InitValues();
        }

        public HomConf(string file)
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
            H_Config.Load(_file);

            // Initialize the values for this object
            InitValues();
        }

        public void Revert()
        {
            // Reload the configurations from the file
            H_Config.Load(_file);

            // Reinitialize the values for this object
            InitValues();
        }

        public void SetDefaults()
        {
            // Basic Options
            _AggroHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AggroHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AggroSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AggroSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _KiteMonsters = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["KiteMonsters"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _PainkillerFriends = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["PainkillerFriends"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _PainkillerFriendsSave = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["PainkillerFriendsSave"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _SuperPassive = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["SuperPassive"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseAttackSkill = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAttackSkill"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AssumeHomun = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AssumeHomun"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _DoNotChase = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DoNotChase"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseDanceAttack = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDanceAttack"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseAvoid = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAvoid"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _TankMonsterLimit = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["TankMonsterLimit"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _RescueOwnerLowHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["RescueOwnerLowHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _StationaryAggroDist = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["StationaryAggroDist"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _MobileAggroDist = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["MobileAggroDist"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _OldHomunType = (OldHomunTypeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["OldHomunType"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _OpportunisticTargeting = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["OpportunisticTargeting"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AttackLastFullSP = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AttackLastFullSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _DanceMinSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DanceMinSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AttackTimeLimit = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AttackTimeLimit"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _LagReduction = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["LagReduction"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _DoNotAttackMoving = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DoNotAttackMoving"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _LiveMobID = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["LiveMobID"].Attributes[typeof(DefaultValueAttribute)]).Value);
            

            // AutoSkill Options
            _AttackSkillReserveSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AttackSkillReserveSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSkillOnly = (UseSkillOnlyOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSkillOnly"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _AutoSkillDelay = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoSkillDelay"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AutoMobCount = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoMobCount"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AoEReserveSP = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AoEReserveSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AoEFixedLevel = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AoEFixedLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AutoMobMode = (AutoMobModeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoMobMode"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _AutoComboMode = (AutoComboModeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoComboMode"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _AutoComboSpheres = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AutoComboSpheres"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseHomunSSkillChase = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseHomunSSkillChase"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseHomunSSkillAttack = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseHomunSSkillAttack"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AoEMaximizeTargets = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AoEMaximizeTargets"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseEiraXenoSlasher = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseEiraXenoSlasher"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _EiraXenoSlasherLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["EiraXenoSlasherLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseEiraSilentBreeze = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseEiraSilentBreeze"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _EiraSilentBreezeLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["EiraSilentBreezeLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseEiraEraseCutter = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseEiraEraseCutter"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _EiraEraseCutterLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["EiraEraseCutterLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseBayeriStahlHorn = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBayeriStahlHorn"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _BayeriStahlHornLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["BayeriStahlHornLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseBayeriHailegeStar = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBayeriHailegeStar"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _BayeriHailegeStarLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["BayeriHailegeStarLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSeraParalyze = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSeraParalyze"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _SeraParalyzeLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["SeraParalyzeLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSeraPoisonMist = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSeraPoisonMist"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _SeraPoisonMistLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["SeraPoisonMistLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseEleanorSonicClaw = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseEleanorSonicClaw"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _EleanorSonicClawLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["EleanorSonicClawLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _EleanorSilverveinLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["EleanorSilverveinLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _EleanorMidnightLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["EleanorMidnightLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _EleanorDoNotSwitchMode = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["EleanorDoNotSwitchMode"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseDieterLavaSlide = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDieterLavaSlide"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseDieterVolcanicAsh = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDieterVolcanicAsh"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _DieterLavaSlideLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DieterLavaSlideLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSeraCallLegion = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSeraCallLegion"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _SeraCallLegionLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["SeraCallLegionLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);

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
            _UseCastleRoute = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseCastleRoute"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _RelativeRoute = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["RelativeRoute"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _IdleWalkDistance = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["IdleWalkDistance"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _ChaseSPPause = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["ChaseSPPause"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _ChaseSPPauseSP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["ChaseSPPauseSP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _ChaseSPPauseTime = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["ChaseSPPauseTime"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _StationaryMoveBounds = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["StationaryMoveBounds"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _MobileMoveBounds = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["MobileMoveBounds"].Attributes[typeof(DefaultValueAttribute)]).Value);

            // Autobuff Options
            _UseOffensiveBuff = (UseOffensiveBuffOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseOffensiveBuff"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseDefensiveBuff = (UseDefensiveBuffOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDefensiveBuff"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _LifEscapeLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["LifEscapeLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _FilirFlitLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["FilirFlitLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _AmiBulwarkLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["AmiBulwarkLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _HealOwnerHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["HealOwnerHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _FilirAccelLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["FilirAccelLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSeraPainkiller = (UseSeraPainkillerOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSeraPainkiller"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _DefensiveBuffOwnerMobbed = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DefensiveBuffOwnerMobbed"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseBayeriAngriffModus = (UseBayeriAngriffModusOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBayeriAngriffModus"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseBayeriGoldenPherze = (UseBayeriGoldenPherzeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBayeriGoldenPherze"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseDieterMagmaFlow = (UseDieterMagmaFlowOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDieterMagmaFlow"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseDieterGraniticArmor = (UseDieterGraniticArmorOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDieterGraniticArmor"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseDieterPyroclastic = (UseDieterPyroclasticOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseDieterPyroclastic"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _DieterPyroclasticLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["DieterPyroclasticLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseEiraOveredBoost = (UseEiraOveredBoostOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseEiraOveredBoost"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _HealSelfHP = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["HealSelfHP"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseAutoHeal = (UseAutoHealOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAutoHeal"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _HealOwnerBreeze = (HealOwnerBreezeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseAutoHeal"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _LavaSlideMode = (LavaSlideModeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["LavaSlideMode"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _PoisonMistMode = (PoisonMistModeOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["PoisonMistMode"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _UseBayeriSteinWand = (UseBayeriSteinWandOptions)((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseBayeriSteinWand"].Attributes[typeof(DefaultValueAttribute)]).Value;
            _BayeriSteinWandLevel = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["BayeriSteinWandLevel"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSteinWandSelfMob = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSteinWandSelfMob"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSteinWandOwnerMob = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSteinWandOwnerMob"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSteinWandTele = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSteinWandTele"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _SteinWandTelePause = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["SteinWandTelePause"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseCastleDefend = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseCastleDefend"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _CastleDefendThreshold = Convert.ToInt32(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["CastleDefendThreshold"].Attributes[typeof(DefaultValueAttribute)]).Value);
            _UseSmartBulwark = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["UseSmartBulwark"].Attributes[typeof(DefaultValueAttribute)]).Value);
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
            _Berserk_ComboAlways = Convert.ToBoolean(((DefaultValueAttribute)TypeDescriptor.GetProperties(this)["Berserk_ComboAlways"].Attributes[typeof(DefaultValueAttribute)]).Value);

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
            H_Config.AggroHP = _AggroHP;
            H_Config.AggroSP = _AggroSP;
            H_Config.KiteMonsters = Convert.ToInt32(_KiteMonsters);
            H_Config.PainkillerFriends = Convert.ToInt32(_PainkillerFriends);
            H_Config.PainkillerFriendsSave = Convert.ToInt32(_PainkillerFriendsSave);
            H_Config.SuperPassive = Convert.ToInt32(_SuperPassive);
            H_Config.UseAttackSkill = Convert.ToInt32(_UseAttackSkill);
            H_Config.AssumeHomun = Convert.ToInt32(_AssumeHomun);
            H_Config.DoNotChase = Convert.ToInt32(_DoNotChase);
            H_Config.UseDanceAttack = Convert.ToInt32(_UseDanceAttack);
            H_Config.UseAvoid = Convert.ToInt32(_UseAvoid);
            H_Config.TankMonsterLimit = _TankMonsterLimit;
            H_Config.RescueOwnerLowHP = _RescueOwnerLowHP;
            H_Config.StationaryAggroDist = _StationaryAggroDist;
            H_Config.MobileAggroDist = _MobileAggroDist;
            H_Config.OldHomunType = Convert.ToInt32(_OldHomunType);
            H_Config.OpportunisticTargeting = Convert.ToInt32(_OpportunisticTargeting);
            H_Config.AttackLastFullSP = Convert.ToInt32(_AttackLastFullSP);
            H_Config.DanceMinSP = _DanceMinSP;
            H_Config.AttackTimeLimit = _AttackTimeLimit;
            H_Config.LagReduction = Convert.ToInt32(_LagReduction);
            H_Config.DoNotAttackMoving = Convert.ToInt32(_DoNotAttackMoving);
            H_Config.LiveMobID = Convert.ToInt32(_LiveMobID);


            // AutoSkill Options
            H_Config.AttackSkillReserveSP = _AttackSkillReserveSP;
            H_Config.UseSkillOnly = Convert.ToInt32(_UseSkillOnly);
            H_Config.AutoSkillDelay = _AutoSkillDelay;
            H_Config.AutoMobCount = _AutoMobCount;
            H_Config.AoEReserveSP = Convert.ToInt32(_AoEReserveSP);
            H_Config.AoEFixedLevel = Convert.ToInt32(_AoEFixedLevel);
            H_Config.AutoMobMode = Convert.ToInt32(_AutoMobMode);
            H_Config.AutoComboMode = Convert.ToInt32(_AutoComboMode);
            H_Config.AutoComboSpheres = _AutoComboSpheres;
            H_Config.UseHomunSSkillChase = Convert.ToInt32(_UseHomunSSkillChase);
            H_Config.UseHomunSSkillAttack = Convert.ToInt32(_UseHomunSSkillAttack);
            H_Config.AoEMaximizeTargets = Convert.ToInt32(_AoEMaximizeTargets);
            H_Config.UseEiraXenoSlasher = Convert.ToInt32(_UseEiraXenoSlasher);
            H_Config.EiraXenoSlasherLevel = _EiraXenoSlasherLevel;
            H_Config.UseEiraSilentBreeze = Convert.ToInt32(_UseEiraSilentBreeze);
            H_Config.EiraSilentBreezeLevel = _EiraSilentBreezeLevel;
            H_Config.UseEiraEraseCutter = Convert.ToInt32(_UseEiraEraseCutter);
            H_Config.EiraEraseCutterLevel = _EiraEraseCutterLevel;
            H_Config.UseBayeriStahlHorn = Convert.ToInt32(_UseBayeriStahlHorn);
            H_Config.BayeriStahlHornLevel = _BayeriStahlHornLevel;
            H_Config.UseBayeriHailegeStar = Convert.ToInt32(_UseBayeriHailegeStar);
            H_Config.BayeriHailegeStarLevel = _BayeriHailegeStarLevel;
            H_Config.UseSeraParalyze = Convert.ToInt32(_UseSeraParalyze);
            H_Config.SeraParalyzeLevel = _SeraParalyzeLevel;
            H_Config.UseSeraPoisonMist = Convert.ToInt32(_UseSeraPoisonMist);
            H_Config.SeraPoisonMistLevel = _SeraPoisonMistLevel;
            H_Config.UseEleanorSonicClaw = Convert.ToInt32(_UseEleanorSonicClaw);
            H_Config.EleanorDoNotSwitchMode = Convert.ToInt32(_EleanorDoNotSwitchMode);
            H_Config.EleanorSonicClawLevel = _EleanorSonicClawLevel;
            H_Config.EleanorSilverveinLevel = _EleanorSilverveinLevel;
            H_Config.EleanorMidnightLevel = _EleanorMidnightLevel;
            H_Config.UseDieterLavaSlide = Convert.ToInt32(_UseDieterLavaSlide);
            H_Config.UseDieterVolcanicAsh = Convert.ToInt32(_UseDieterVolcanicAsh);
            H_Config.DieterLavaSlideLevel = _DieterLavaSlideLevel;
            H_Config.UseSeraCallLegion = Convert.ToInt32(_UseSeraCallLegion);
            H_Config.SeraCallLegionLevel = _SeraCallLegionLevel;

            // Walk/Follow Options
            H_Config.FollowStayBack = _FollowStayBack;
            H_Config.RestXOff = _RestXOff;
            H_Config.RestYOff = _RestYOff;
            H_Config.DoNotUseRest = Convert.ToInt32(_DoNotUseRest);
            H_Config.SpawnDelay = _SpawnDelay;
            H_Config.MoveSticky = Convert.ToInt32(_MoveSticky);
            H_Config.MoveStickyFight = Convert.ToInt32(_MoveStickyFight);
            H_Config.UseIdleWalk = Convert.ToInt32(_UseIdleWalk);
            H_Config.IdleWalkSP = _IdleWalkSP;
            H_Config.UseCastleRoute = Convert.ToInt32(_UseCastleRoute);
            H_Config.RelativeRoute = Convert.ToInt32(_RelativeRoute);
            H_Config.IdleWalkDistance = _IdleWalkDistance;
            H_Config.ChaseSPPause = Convert.ToInt32(_ChaseSPPause);
            H_Config.ChaseSPPauseSP = _ChaseSPPauseSP;
            H_Config.ChaseSPPauseTime = _ChaseSPPauseTime;
            H_Config.StationaryMoveBounds = _StationaryMoveBounds;
            H_Config.MobileMoveBounds = _MobileMoveBounds;

            // Autobuff Options
            H_Config.UseOffensiveBuff = Convert.ToInt32(_UseOffensiveBuff);
            H_Config.UseDefensiveBuff = Convert.ToInt32(_UseDefensiveBuff);
            H_Config.LifEscapeLevel = _LifEscapeLevel;
            H_Config.FilirFlitLevel = _FilirFlitLevel;
            H_Config.AmiBulwarkLevel = _AmiBulwarkLevel;
            H_Config.HealOwnerHP = _HealOwnerHP;
            H_Config.UseAutoHeal = Convert.ToInt32(_UseAutoHeal);
            H_Config.HealOwnerBreeze = Convert.ToInt32(_HealOwnerBreeze);
            H_Config.FilirAccelLevel = _FilirAccelLevel;
            H_Config.UseSeraPainkiller = Convert.ToInt32(_UseSeraPainkiller);
            H_Config.DefensiveBuffOwnerMobbed = _DefensiveBuffOwnerMobbed;
            H_Config.UseBayeriAngriffModus = Convert.ToInt32(_UseBayeriAngriffModus);
            H_Config.UseBayeriGoldenPherze = Convert.ToInt32(_UseBayeriGoldenPherze);
            H_Config.UseDieterMagmaFlow = Convert.ToInt32(_UseDieterMagmaFlow);
            H_Config.UseDieterGraniticArmor = Convert.ToInt32(_UseDieterGraniticArmor);
            H_Config.UseDieterPyroclastic = Convert.ToInt32(_UseDieterPyroclastic);
            H_Config.DieterPyroclasticLevel = _DieterPyroclasticLevel;
            H_Config.UseEiraOveredBoost = Convert.ToInt32(_UseEiraOveredBoost);
            H_Config.HealSelfHP = _HealSelfHP;
            H_Config.LavaSlideMode = Convert.ToInt32(_LavaSlideMode);
            H_Config.PoisonMistMode = Convert.ToInt32(_PoisonMistMode);
            H_Config.UseBayeriSteinWand = Convert.ToInt32(_UseBayeriSteinWand);
            H_Config.BayeriSteinWandLevel = _BayeriSteinWandLevel;
            H_Config.UseSteinWandSelfMob = _UseSteinWandSelfMob;
            H_Config.UseSteinWandOwnerMob = _UseSteinWandOwnerMob;
            H_Config.UseSteinWandTele = Convert.ToInt32(_UseSteinWandTele);
            H_Config.SteinWandTelePause = _SteinWandTelePause;
            H_Config.UseCastleDefend = Convert.ToInt32(_UseCastleDefend);
            H_Config.CastleDefendThreshold = _CastleDefendThreshold;
            H_Config.UseSmartBulwark = Convert.ToInt32(_UseSmartBulwark);
            // Kiting Options
            H_Config.KiteParanoid = Convert.ToInt32(_KiteParanoid);
            H_Config.KiteStep = _KiteStep;
            H_Config.KiteParanoidStep = _KiteParanoidStep;
            H_Config.KiteThreshold = _KiteThreshold;
            H_Config.KiteParanoidThreshold = _KiteParanoidThreshold;
            H_Config.KiteBounds = _KiteBounds;
            H_Config.ForceKite = Convert.ToInt32(_ForceKite);
            H_Config.FleeHP = _FleeHP;

            // Friending Options
            H_Config.StandbyFriending = Convert.ToInt32(_StandbyFriending);
            H_Config.MirAIFriending = Convert.ToInt32(_MirAIFriending);

            // Standby Options
            H_Config.DefendStandby = Convert.ToInt32(_DefendStandby);
            H_Config.StickyStandby = Convert.ToInt32(_StickyStandby);

            // Berserk Options
            H_Config.UseBerserkMobbed = _UseBerserkMobbed;
            H_Config.UseBerserkSkill = Convert.ToInt32(_UseBerserkSkill);
            H_Config.UseBerserkAttack = Convert.ToInt32(_UseBerserkAttack);
            H_Config.Berserk_SkillAlways = Convert.ToInt32(_Berserk_SkillAlways);
            H_Config.Berserk_Dance = Convert.ToInt32(_Berserk_Dance);
            H_Config.Berserk_IgnoreMinSP = Convert.ToInt32(_Berserk_IgnoreMinSP);
            H_Config.Berserk_ComboAlways = Convert.ToInt32(_Berserk_ComboAlways);
            // PVP Options
            H_Config.PVPmode = Convert.ToInt32(_PVPmode);

            // Save the file
            H_Config.Save(file);
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
            H_Config.Load(file);

            // Initialize the values for this object
            InitValues();
        }

        void InitValues()
        {
            // Basic Options
            _AggroHP = H_Config.AggroHP;
            _AggroSP = H_Config.AggroSP; 
            _KiteMonsters = Convert.ToBoolean(H_Config.KiteMonsters);
            _PainkillerFriends = Convert.ToBoolean(H_Config.PainkillerFriends);
            _PainkillerFriendsSave = Convert.ToBoolean(H_Config.PainkillerFriendsSave);
            _SuperPassive = Convert.ToBoolean(H_Config.SuperPassive);
            _UseAttackSkill = Convert.ToBoolean(H_Config.UseAttackSkill);
            _AssumeHomun = Convert.ToBoolean(H_Config.AssumeHomun);
            _DoNotChase = Convert.ToBoolean(H_Config.DoNotChase);
            _UseDanceAttack = Convert.ToBoolean(H_Config.UseDanceAttack);
            _UseAvoid = Convert.ToBoolean(H_Config.UseAvoid);
            _TankMonsterLimit = H_Config.TankMonsterLimit;
            _RescueOwnerLowHP = H_Config.RescueOwnerLowHP;
            _StationaryAggroDist = H_Config.StationaryAggroDist;
            _MobileAggroDist = H_Config.MobileAggroDist;
            _OldHomunType = (OldHomunTypeOptions)H_Config.OldHomunType;
            _OpportunisticTargeting = Convert.ToBoolean(H_Config.OpportunisticTargeting);
            _AttackLastFullSP = Convert.ToBoolean(H_Config.AttackLastFullSP);
            _DanceMinSP = H_Config.DanceMinSP;
            _AttackTimeLimit = H_Config.AttackTimeLimit;
            _LagReduction = H_Config.LagReduction;
            _DoNotAttackMoving = Convert.ToBoolean(H_Config.DoNotAttackMoving);
            _LiveMobID = Convert.ToBoolean(H_Config.LiveMobID);

            // AutoSkill Options
            _AttackSkillReserveSP = H_Config.AttackSkillReserveSP;
            _UseSkillOnly = (UseSkillOnlyOptions)H_Config.UseSkillOnly;
            _AutoSkillDelay = H_Config.AutoSkillDelay;
            _AoEReserveSP = Convert.ToBoolean(H_Config.AoEReserveSP);
            _AoEFixedLevel = Convert.ToBoolean(H_Config.AoEFixedLevel);
            _AutoMobMode = (AutoMobModeOptions)H_Config.AutoMobMode;
            _AutoMobCount = H_Config.AutoMobCount;
            _AutoComboMode = (AutoComboModeOptions)H_Config.AutoComboMode;
            _AutoComboSpheres = H_Config.AutoComboSpheres;
            _UseHomunSSkillChase = Convert.ToBoolean(H_Config.UseHomunSSkillChase);
            _UseHomunSSkillAttack = Convert.ToBoolean(H_Config.UseHomunSSkillAttack);
            _AoEMaximizeTargets = Convert.ToBoolean(H_Config.AoEMaximizeTargets);
            _UseEiraXenoSlasher = Convert.ToBoolean(H_Config.UseEiraXenoSlasher);
            _EiraXenoSlasherLevel = H_Config.EiraXenoSlasherLevel;
            _UseEiraSilentBreeze = Convert.ToBoolean(H_Config.UseEiraSilentBreeze);
            _EiraSilentBreezeLevel = H_Config.EiraSilentBreezeLevel;
            _UseEiraEraseCutter = Convert.ToBoolean(H_Config.UseEiraEraseCutter);
            _EiraEraseCutterLevel = H_Config.EiraEraseCutterLevel;
            _UseBayeriStahlHorn = Convert.ToBoolean(H_Config.UseBayeriStahlHorn);
            _BayeriStahlHornLevel = H_Config.BayeriStahlHornLevel;
            _UseBayeriHailegeStar = Convert.ToBoolean(H_Config.UseBayeriHailegeStar);
            _BayeriHailegeStarLevel = H_Config.BayeriHailegeStarLevel;
            _UseSeraParalyze = Convert.ToBoolean(H_Config.UseSeraParalyze);
            _SeraParalyzeLevel = H_Config.SeraParalyzeLevel;
            _UseSeraPoisonMist = Convert.ToBoolean(H_Config.UseSeraPoisonMist);
            _SeraPoisonMistLevel = H_Config.SeraPoisonMistLevel;
            _UseEleanorSonicClaw = Convert.ToBoolean(H_Config.UseEleanorSonicClaw);
            _EleanorDoNotSwitchMode = Convert.ToBoolean(H_Config.EleanorDoNotSwitchMode);
            _EleanorSonicClawLevel = H_Config.EleanorSonicClawLevel;
            _EleanorSilverveinLevel = H_Config.EleanorSilverveinLevel;
            _EleanorMidnightLevel = H_Config.EleanorMidnightLevel;
            _UseDieterLavaSlide = Convert.ToBoolean(H_Config.UseDieterLavaSlide);
            _UseDieterVolcanicAsh = Convert.ToBoolean(H_Config.UseDieterVolcanicAsh);
            _DieterLavaSlideLevel = H_Config.DieterLavaSlideLevel;
            _UseSeraCallLegion = Convert.ToBoolean(H_Config.UseSeraCallLegion);
            _SeraCallLegionLevel = H_Config.SeraCallLegionLevel;

            // Walk/Follow Options
            _FollowStayBack = H_Config.FollowStayBack;
            _RestXOff = H_Config.RestXOff;
            _RestYOff = H_Config.RestYOff;
            _DoNotUseRest = Convert.ToBoolean(H_Config.DoNotUseRest);
            _SpawnDelay = H_Config.SpawnDelay;
            _MoveSticky = Convert.ToBoolean(H_Config.MoveSticky);
            _MoveStickyFight = Convert.ToBoolean(H_Config.MoveStickyFight);
            _UseIdleWalk = (UseIdleWalkOptions)H_Config.UseIdleWalk;
            _UseCastleRoute = Convert.ToBoolean(H_Config.UseCastleRoute);
            _RelativeRoute = Convert.ToBoolean(H_Config.RelativeRoute);
            _UseCastleDefend = Convert.ToBoolean(H_Config.UseCastleDefend);
            _CastleDefendThreshold = H_Config.CastleDefendThreshold;
            _IdleWalkDistance = H_Config.IdleWalkDistance;
            _ChaseSPPause = Convert.ToBoolean(H_Config.ChaseSPPause);
            _ChaseSPPauseSP = H_Config.ChaseSPPauseSP;
            _ChaseSPPauseTime = H_Config.ChaseSPPauseTime;
            _StationaryMoveBounds = H_Config.StationaryMoveBounds;
            _MobileMoveBounds = H_Config.MobileMoveBounds;
            _IdleWalkSP = H_Config.IdleWalkSP;

            // Autobuff Options
            _UseOffensiveBuff = (UseOffensiveBuffOptions)H_Config.UseOffensiveBuff;
            _UseDefensiveBuff = (UseDefensiveBuffOptions)H_Config.UseDefensiveBuff;
            _LifEscapeLevel = H_Config.LifEscapeLevel;
            _FilirFlitLevel = H_Config.FilirFlitLevel;
            _FilirAccelLevel = H_Config.FilirAccelLevel;
            _AmiBulwarkLevel = H_Config.AmiBulwarkLevel;
            _HealOwnerHP = H_Config.HealOwnerHP;
            _UseSeraPainkiller = (UseSeraPainkillerOptions)H_Config.UseSeraPainkiller;
            _DefensiveBuffOwnerMobbed = H_Config.DefensiveBuffOwnerMobbed;
            _UseBayeriAngriffModus = (UseBayeriAngriffModusOptions)H_Config.UseBayeriAngriffModus;
            _UseBayeriGoldenPherze = (UseBayeriGoldenPherzeOptions)H_Config.UseBayeriGoldenPherze;
            _UseDieterMagmaFlow = (UseDieterMagmaFlowOptions)H_Config.UseDieterMagmaFlow;
            _UseDieterGraniticArmor = (UseDieterGraniticArmorOptions)H_Config.UseDieterGraniticArmor;
            _UseDieterPyroclastic = (UseDieterPyroclasticOptions)H_Config.UseDieterPyroclastic;
            _DieterPyroclasticLevel = H_Config.DieterPyroclasticLevel;
            _UseEiraOveredBoost = (UseEiraOveredBoostOptions)H_Config.UseEiraOveredBoost;
            _HealSelfHP = H_Config.HealSelfHP;
            _UseAutoHeal = (UseAutoHealOptions)H_Config.UseAutoHeal;
            _HealOwnerBreeze = (HealOwnerBreezeOptions)H_Config.HealOwnerBreeze;
            _LavaSlideMode = (LavaSlideModeOptions)H_Config.LavaSlideMode;
            _PoisonMistMode = (PoisonMistModeOptions)H_Config.PoisonMistMode;
            _UseBayeriSteinWand = (UseBayeriSteinWandOptions)H_Config.UseBayeriSteinWand;
            _BayeriSteinWandLevel = H_Config.BayeriSteinWandLevel;
            _UseSteinWandSelfMob = H_Config.UseSteinWandSelfMob;
            _UseSteinWandOwnerMob = H_Config.UseSteinWandOwnerMob;
            _UseSteinWandTele = Convert.ToBoolean(H_Config.UseSteinWandTele);
            _SteinWandTelePause = H_Config.SteinWandTelePause;
            _UseSmartBulwark = Convert.ToBoolean(H_Config.UseSmartBulwark);
            // Kiting Options
            _KiteParanoid = Convert.ToBoolean(H_Config.KiteParanoid);
            _KiteStep = H_Config.KiteStep;
            _KiteParanoidStep = H_Config.KiteParanoidStep;
            _KiteThreshold = H_Config.KiteThreshold;
            _KiteParanoidThreshold = H_Config.KiteParanoidThreshold;
            _KiteBounds = H_Config.KiteBounds;
            _ForceKite = Convert.ToBoolean(H_Config.ForceKite);
            _FleeHP = H_Config.FleeHP;

            // Friending Options
            _StandbyFriending = Convert.ToBoolean(H_Config.StandbyFriending);
            _MirAIFriending = Convert.ToBoolean(H_Config.MirAIFriending);

            // Standby Options
            _DefendStandby = Convert.ToBoolean(H_Config.DefendStandby);
            _StickyStandby = (StickyStandbyOptions)H_Config.StickyStandby;

            // Berserk Options
            _UseBerserkMobbed = H_Config.UseBerserkMobbed;
            _UseBerserkSkill = Convert.ToBoolean(H_Config.UseBerserkSkill);
            _UseBerserkAttack = Convert.ToBoolean(H_Config.UseBerserkAttack);
            _Berserk_SkillAlways = Convert.ToBoolean(H_Config.Berserk_SkillAlways);
            _Berserk_Dance = Convert.ToBoolean(H_Config.Berserk_Dance);
            _Berserk_IgnoreMinSP = Convert.ToBoolean(H_Config.Berserk_IgnoreMinSP);
            _Berserk_ComboAlways = Convert.ToBoolean(H_Config.Berserk_ComboAlways);
            // PVP Options
            _PVPmode = Convert.ToBoolean(H_Config.PVPmode);
        }

        #region Basic Options
        int _AggroHP = 60;
        [Category("Basic Options"),
        Description(
            "Your homunculus will seek out and attack monsters whenever its " +
            "HP percent (as percent of maximum HP; a number from 0-100) is " +
            "greater than this value. When it lacks HP, it will only fight " +
            "monsters if it is attacked.\n\nSet this value to 100 if you do " +
            "not want the homunculus to attack unless it, the owner, or a " +
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
            "Your homunculus will seek out and attack monsters whenever its " +
            "SP percent (as percent of maximum SP; a number from 0-100) is " +
            "greater than this value. When it lacks SP, it will only fight " +
            "monsters if it is attacked."
            ),
        DefaultValue(0)]
        public int AggroSP
        {
            get { return _AggroSP; }
            set
            {
                if (value < 0)
                {
                    _AggroSP = 0;
                }
                else if (value > 100)
                {
                    _AggroSP = 100;
                }
                else
                {
                    _AggroSP = value;
                }
            }
        }


        bool _KiteMonsters = false;
        [Category("Basic Options"),
        Description(
            "Set this to true if you want your homunculus to keep its " +
            "distance from monsters while attacking."
            ),
        DefaultValue(false)]
        public bool KiteMonsters
        {
            get { return _KiteMonsters; }
            set { _KiteMonsters = value; }
        }
        bool _PainkillerFriends = false;
        [Category("Basic Options"),
        Description(
            "Set this to true if you want your homunculus to use" +
            "painkiller of friended players. Manually casting painkiller" +
            "on a player with this enabled will add them to the list for" +
            "auto-painkiller. (Sera only)"
            ),
        DefaultValue(false)]
        public bool PainkillerFriends
        {
            get { return _PainkillerFriends; }
            set { _PainkillerFriends = value; }
        }

        bool _PainkillerFriendsSave = false;
        [Category("Basic Options"),
        Description(
            "If PainkillerFriends is enabled, set this to true if you " +
            "want the AI to remember players you have added to the" +
            "painkiller list by manually casting Painkiller on them." +
            "(Sera only)"
            ),
        DefaultValue(false)]
        public bool PainkillerFriendsSave
        {
            get { return _PainkillerFriendsSave; }
            set { _PainkillerFriendsSave = value; }
        }

        bool _SuperPassive = false;
        [Category("Basic Options"),
        Description(
            "If you want your homunculus to not fight or do anything other " +
            "than watch (and kite, if set to do so), set this value to " +
            "true. This is generally useless for a homunculus."
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
            "If you want your homunculus to automatically use offensive " +
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
            "same time, set this value to true.\n\nThe default is true."
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
            "If you want your homunculus to stand still and only use ranged " +
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
            "Set this to true if you want your homunculus to bypass ASPD by " +
            "dancing while attacking. Only recommended if your homun has no" +
            "offensive skills"
            ),
        DefaultValue(false)]
        public bool UseDanceAttack
        {
            get { return _UseDanceAttack; }
            set { _UseDanceAttack = value; }
        }

        bool _UseAvoid = false;
        [Category("Basic Options"),
        Description(
            "Set this to true if you want your homunculus to exit the client " +
            "if it sees a monster listed in H_Avoid.lua"
            ),
        DefaultValue(false)]
        public bool UseAvoid
        {
            get { return _UseAvoid; }
            set { _UseAvoid = value; }
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
            set
            {
                if (value < -100)
                {
                    _RescueOwnerLowHP = -100;
                }   
                else if (value > 100)
                {
                    _RescueOwnerLowHP = 100;
                }
                else
                {
                    _RescueOwnerLowHP = value;
                }
            }
        }

        int _StationaryAggroDist = 10;
        [Category("Basic Options"),
        Description(
            "When the owner is is not moving, attack monsters within this " +
            "distance of the owner. "
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
            "This should probably be relatively low so that the homun " +
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

        OldHomunTypeOptions _OldHomunType = OldHomunTypeOptions.Filir;
        [Category("Basic Options"),
        Description(
            "If you are using a Homun S that was NOT a vanilmirth, set this" +
            " to the type of homun that your homun s was prior to mutation." +
            "This will be disregarded if the homun was a Vanilmirth, or for" +
            "non-S homunculi"
            ),
        DefaultValue(OldHomunTypeOptions.Filir)]
        public OldHomunTypeOptions OldHomunType
        {
            get { return _OldHomunType; }
            set { _OldHomunType = value; }
        }

        bool _OpportunisticTargeting = false;
        [Category("Basic Options"),
        Description(
            "If enabled, the homunculus will switch targets if a better target" +
            "is closer."
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

        int _DanceMinSP = 0;
        [Category("Basic Options"),
        Description(
            "If UseDanceAttack is enabled, the homun will only 'dance' if " +
            "it has at least this much SP as a percent"
            ),
        DefaultValue(0)]
        public int DanceMinSP
        {
            get { return _DanceMinSP; }
            set
            {
                if (value < -100)
                {
                    _DanceMinSP = -100;
                }
                else if (value > 6000)
                {
                    _DanceMinSP = 6000;
                }
                else
                {
                    _DanceMinSP = value;
                }
            }
        }
        int _AttackTimeLimit = 10000;
        [Category("Basic Options"),
        Description(
            "This is the longest time, in milliseconds, that the " +
            "homunculus will spend trying to attack a target which it has already attacked - this is to prevent homun from getting hung up on posbugged or inaccessible monsters. As of 1.54, this timer is reset if we see the monster flinching while nothing else is targeting it - that should mean that we're successfully attacking it, and should keep going"
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
                else if (value > 60000)
                {
                    _AttackTimeLimit = 60000;
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
            "If you experience lag that appears only with homunculus out on some maps, try setting this to 1. This will reduce responsiveness on maps that do not lag." +
            "In severe cases, this can be set to 2, or even higher. This will greatly slow the homunculus' reaction time, and should be used only if truly necessary"
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
            "If set to true, homun will not attack monsters that are currently moving"
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
            "If enabled, and owner has merc out, and merc has LiveMobID enabled as well, the mercenary will be able to identify monsters on screen as long as the homun is alive. " +
            "See the documentation for more details and caveats. This may cause performance problems on some systems. "
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
            "To control SP use, you may not want your homunculus to use " +
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
            "If the homunculus has an anto-mob skill, the skill will be " +
            "automatically used if the number of monsters in close " +
            "proximity to the homunculus or owner is equal to or greater " +
            "than this value."
            ),
        DefaultValue(2)]
        public int AutoMobCount
        {
            get { return _AutoMobCount; }
            set
            {
                if (value < 1)
                {
                    _AutoMobCount = 1;
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
            "If you want your homunculus to use skills while attacking and " +
            "while chasing if their skill has a longer range than their " +
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
            "you are having problems with the homunculus \"double casting\" " +
            "skills, increase this value. Otherwise, leave it be."
            ),
        DefaultValue(400)]
        public int AutoSkillDelay
	{
		get { return _AutoSkillDelay; }
		set {
			if (value < 100)
			{
				_AutoSkillDelay=100;
			}
			else if (value > 600){
				_AutoSkillDelay=600;
			}
			else{
				_AutoSkillDelay= value;
			}
		}
	}


        

        UseAutoPushbackOptions _UseAutoPushback = UseAutoPushbackOptions.Off;
        [Category("AutoSkill Options"),
        Description(
            "If you want your homunculus to use pushback skills, set this " +
            "to self. If you want the homunculus to use pushback skills " +
            "when its owner or other friends are being attacked, set this " +
            "to all (not recommended). Otherwise, set this to Off."
            ),
        DefaultValue(UseAutoPushbackOptions.Off),
        Browsable(false)]
        public UseAutoPushbackOptions UseAutoPushback
        {
            get { return _UseAutoPushback; }
            set { _UseAutoPushback = value; }
        }


        int _AutoPushbackThreshold = 2;
        [Category("AutoSkill Options"),
        Description(
            "If UseAutoPushback is turned on, this is the distance between " +
            "a monster and its target that determins when the homunculus " +
            "will use its pushback skill."
            ),
        DefaultValue(2),
        Browsable(false)]
        public int AutoPushbackThreshold
        {
            get { return _AutoPushbackThreshold; }
            set { _AutoPushbackThreshold = value; }
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
        AutoComboModeOptions _AutoComboMode = AutoComboModeOptions.Never;
        [Category("AutoSkill Options"),
        Description(
            "Set whether to use combo skills other than Sonic Claw " +
            "either never, per tactics, or always regardless of tactics"
            ),
        DefaultValue(AutoComboModeOptions.Never)]
        public AutoComboModeOptions AutoComboMode
        {
            get { return _AutoComboMode; }
            set { _AutoComboMode = value; }
        }

        int _AutoComboSpheres = 10;
        [Category("AutoSkill Options"),
        Description(
            "If AutoComboMode is enabled, combo skills may be used if the " +
            "homun has at least this many spheres. Sphere counts are not " +
            "exact"
            ),
        DefaultValue(10)]
        public int AutoComboSpheres
        {
            get { return _AutoComboSpheres; }
            set
            {
                if (value < 1)
                {
                    _AutoComboSpheres = 1;
                }
                else if (value > 10)
                {
                    _AutoComboSpheres = 10;
                }
                else
                {
                    _AutoComboSpheres = value;
                }
            }
        }

        bool _UseHomunSSkillChase = true;
        [Category("AutoSkill Options"),
        Description(
            "If enabled, homun S skills will be used when chasing. "
            ),
        DefaultValue(true)]
        public bool UseHomunSSkillChase
        {
            get { return _UseHomunSSkillChase; }
            set { _UseHomunSSkillChase = value; }
        }

        bool _UseHomunSSkillAttack = true;
        [Category("AutoSkill Options"),
        Description(
            "If enabled, homun S skills will be used when attacking" +
            "It may be useful to turn this off if your homun gets" +
            "interrupted when trying to cast at short range, and" +
            "you would prefer it use caprice or moonlight then"
            ),
        DefaultValue(true)]
        public bool UseHomunSSkillAttack
        {
            get { return _UseHomunSSkillAttack; }
            set { _UseHomunSSkillAttack = value; }
        }

        bool _AoEMaximizeTargets = false;
        [Category("AutoSkill Options"),
        Description(
            "If enabled, we will try to hit as many targets as possible with" +
            "an AoE skill, even if that means we don't hit the target we were" +
            "currently attacking"
            ),
        DefaultValue(false)]
        public bool AoEMaximizeTargets
        {
            get { return _AoEMaximizeTargets; }
            set { _AoEMaximizeTargets = value; }
        }

        bool _UseEiraXenoSlasher = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to use the offensive AoE skill Xeno Slasher" +
            "                                                              "
            ),
        DefaultValue(true)]
        public bool UseEiraXenoSlasher
        {
            get { return _UseEiraXenoSlasher; }
            set { _UseEiraXenoSlasher = value; }
        }

        bool _UseEiraSilentBreeze = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to use the debuff skill Silent Breeze on monsters" +
            " for which appropriate tactics have been set "
            ),
        DefaultValue(true)]
        public bool UseEiraSilentBreeze
        {
            get { return _UseEiraSilentBreeze; }
            set { _UseEiraSilentBreeze = value; }
        }

        int _EiraXenoSlasherLevel = 4;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Xeno Slasher. Overridden by skill tactics " +
            "unless MobSkillFixedLevel is enabled"
            ),
        DefaultValue(4)]
        public int EiraXenoSlasherLevel
        {
            get { return _EiraXenoSlasherLevel; }
            set
            {
                if (value < 1)
                {
                    _EiraXenoSlasherLevel = 1;
                }
                else if (value > 5)
                {
                    _EiraXenoSlasherLevel = 5;
                }
                else
                {
                    _EiraXenoSlasherLevel = value;
                }
            }
        }
        int _EiraSilentBreezeLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Silent Breeze"
            ),
        DefaultValue(5)]
        public int EiraSilentBreezeLevel
        {
            get { return _EiraSilentBreezeLevel; }
            set
            {
                if (value < 1)
                {
                    _EiraSilentBreezeLevel = 1;
                }
                else if (value > 5)
                {
                    _EiraSilentBreezeLevel = 5;
                }
                else
                {
                    _EiraSilentBreezeLevel = value;
                }
            }
        }

        bool _UseEiraEraseCutter = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to use the attack skill Eraser Cutter." +
            "                                                              "
            ),
        DefaultValue(true)]
        public bool UseEiraEraseCutter
        {
            get { return _UseEiraEraseCutter; }
            set { _UseEiraEraseCutter = value; }
        }

        int _EiraEraseCutterLevel = 4;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Erase Cutter. Overridden by skill tactics" +
            "Try level 2, it's more practical than 4 in many cases"
            ),
        DefaultValue(4)]
        public int EiraEraseCutterLevel
        {
            get { return _EiraEraseCutterLevel; }
            set
            {
                if (value < 1)
                {
                    _EiraEraseCutterLevel = 1;
                }
                else if (value > 5)
                {
                    _EiraEraseCutterLevel = 5;
                }
                else
                {
                    _EiraEraseCutterLevel = value;
                }
            }
        }

        bool _UseBayeriStahlHorn = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to use the attack skill Stahl Horn" +
            "                                                              "
            ),
        DefaultValue(true)]
        public bool UseBayeriStahlHorn
        {
            get { return _UseBayeriStahlHorn; }
            set { _UseBayeriStahlHorn = value; }
        }

        int _BayeriStahlHornLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Stahl Horn. Overridden by skill tactics" +
            "Lower levels may work out better, as they cast faster"
            ),
        DefaultValue(5)]
        public int BayeriStahlHornLevel
        {
            get { return _BayeriStahlHornLevel; }
            set
            {
                if (value < 1)
                {
                    _BayeriStahlHornLevel = 1;
                }
                else if (value > 5)
                {
                    _BayeriStahlHornLevel = 5;
                }
                else
                {
                    _BayeriStahlHornLevel = value;
                }
            }
        }


        bool _UseBayeriHailegeStar = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to use the offensive AoE skill Hailage Star" +
            "                                                              "
            ),
        DefaultValue(true)]
        public bool UseBayeriHailegeStar
        {
            get { return _UseBayeriHailegeStar; }
            set { _UseBayeriHailegeStar = value; }
        }

        int _BayeriHailegeStarLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Hailage Star. Overridden by skill tactics " +
            "unless MobSkillFixedLevel is enabled"
            ),
        DefaultValue(5)]
        public int BayeriHailegeStarLevel
        {
            get { return _BayeriHailegeStarLevel; }
            set
            {
                if (value < 1)
                {
                    _BayeriHailegeStarLevel = 1;
                }
                else if (value > 5)
                {
                    _BayeriHailegeStarLevel = 5;
                }
                else
                {
                    _BayeriHailegeStarLevel = value;
                }
            }
        }

        bool _UseSeraParalyze = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to use the attack skill Needle of Paralyze." +
            "                                                              "
            ),
        DefaultValue(true)]
        public bool UseSeraParalyze
        {
            get { return _UseSeraParalyze; }
            set { _UseSeraParalyze = value; }
        }

        int _SeraParalyzeLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Needle of Paralyze. Overridden by skill tactics" +
            "                                                              "
            ),
        DefaultValue(5)]
        public int SeraParalyzeLevel
        {
            get { return _SeraParalyzeLevel; }
            set
            {
                if (value < 1)
                {
                    _SeraParalyzeLevel = 1;
                }
                else if (value > 5)
                {
                    _SeraParalyzeLevel = 5;
                }
                else
                {
                    _SeraParalyzeLevel = value;
                }
            }
        }

        bool _UseSeraPoisonMist = false;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to enable use of Poison Mist. To control whether Poison Mist is cast on monsters as an AoE attack, or at it's owner's feet, see PoisonMistMode."
            ),
        DefaultValue(false)]
        public bool UseSeraPoisonMist
        {
            get { return _UseSeraPoisonMist; }
            set { _UseSeraPoisonMist = value; }
        }

        int _SeraPoisonMistLevel = 0;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Poison Mist. Overridden by skill tactics " +
            "unless MobSkillFixedLevel is enabled"
            ),
        DefaultValue(5)]
        public int SeraPoisonMistLevel
        {
            get { return _SeraPoisonMistLevel; }
            set
            {
                if (value < 1)
                {
                    _SeraPoisonMistLevel = 1;
                }
                else if (value > 5)
                {
                    _SeraPoisonMistLevel = 5;
                }
                else
                {
                    _SeraPoisonMistLevel = value;
                }
            }
        }

        bool _UseEleanorSonicClaw = true;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to use the attack skill Sonic Claw." +
            "                                                              "
            ),
        DefaultValue(true)]
        public bool UseEleanorSonicClaw
        {
            get { return _UseEleanorSonicClaw; }
            set { _UseEleanorSonicClaw = value; }
        }
        bool _EleanorDoNotSwitchMode = false;
        [Category("AutoSkill Options"),
        Description(
            "If this is true, the homun will never automantically use style change." +
            "                                                              "
            ),
        DefaultValue(true)]
        public bool EleanorDoNotSwitchMode
        {
            get { return _EleanorDoNotSwitchMode; }
            set { _EleanorDoNotSwitchMode = value; }
        }

        int _EleanorSonicClawLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Sonic Claw. Overridden by skill tactics." +
            "                                                              "
            ),
        DefaultValue(5)]
        public int EleanorSonicClawLevel
        {
            get { return _EleanorSonicClawLevel; }
            set
            {
                if (value < 1)
                {
                    _EleanorSonicClawLevel = 1;
                }
                else if (value > 5)
                {
                    _EleanorSonicClawLevel = 5;
                }
                else
                {
                    _EleanorSonicClawLevel = value;
                }
            }
        }

        int _EleanorSilverveinLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Silvervein Rush. Overridden by skill tactics " +
            "                                                              "
            ),
        DefaultValue(5)]
        public int EleanorSilverveinLevel
        {
            get { return _EleanorSilverveinLevel; }
            set
            {
                if (value < 1)
                {
                    _EleanorSilverveinLevel = 1;
                }
                else if (value > 5)
                {
                    _EleanorSilverveinLevel = 5;
                }
                else
                {
                    _EleanorSilverveinLevel = value;
                }
            }
        }

        int _EleanorMidnightLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Midnight Frenzy. Overridden by skill tactics " +
            "                                                              "
            ),
        DefaultValue(5)]
        public int EleanorMidnightLevel
        {
            get { return _EleanorMidnightLevel; }
            set
            {
                if (value < 1)
                {
                    _EleanorMidnightLevel = 1;
                }
                else if (value > 5)
                {
                    _EleanorMidnightLevel = 5;
                }
                else
                {
                    _EleanorMidnightLevel = value;
                }
            }
        }

        bool _UseDieterLavaSlide = false;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to enable use of Lava Slide. To control whether Lava Slide is cast on monsters as an AoE attack, or at it's owner's feet, see LavaSlideMode."
            ),
        DefaultValue(false)]
        public bool UseDieterLavaSlide
        {
            get { return _UseDieterLavaSlide; }
            set { _UseDieterLavaSlide = value; }
        }
        bool _UseDieterVolcanicAsh = false;
        [Category("AutoSkill Options"),
        Description(
            "Enable this to enable use of Volcanic Ash as a debuff. In order to use this, you must still enable debuff use in tactics."
            ),
        DefaultValue(false)]
        public bool UseDieterVolcanicAsh
        {
            get { return _UseDieterVolcanicAsh; }
            set { _UseDieterVolcanicAsh = value; }
        }
        int _DieterLavaSlideLevel = 0;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Lava Slide. Overridden by skill tactics " +
            "unless MobSkillFixedLevel is enabled"
            ),
        DefaultValue(10)]
        public int DieterLavaSlideLevel
        {
            get { return _DieterLavaSlideLevel; }
            set
            {
                if (value < 1)
                {
                    _DieterLavaSlideLevel = 1;
                }
                else if (value > 10)
                {
                    _DieterLavaSlideLevel = 10;
                }
                else
                {
                    _DieterLavaSlideLevel = value;
                }
            }
        }

        bool _UseSeraCallLegion = true;
        [Category("AutoSkill Options"),
        Description(
            "Set this to true to use the minion summoning skill Call Legion" +
            "This will only be used on targets with the Skill Class tactic " +
            "set to CLASS_MINION"
            ),
        DefaultValue(true)]
        public bool UseSeraCallLegion
        {
            get { return _UseSeraCallLegion; }
            set { _UseSeraCallLegion = value; }
        }

        int _SeraCallLegionLevel = 5;
        [Category("AutoSkill Options"),
        Description(
            "Use this level of Call Legion. Overridden by skill tactics." +
            "                                                              "
            ),
        DefaultValue(5)]
        public int SeraCallLegionLevel
        {
            get { return _SeraCallLegionLevel; }
            set
            {
                if (value < 1)
                {
                    _SeraCallLegionLevel = 1;
                }
                else if (value > 5)
                {
                    _SeraCallLegionLevel = 5;
                }
                else
                {
                    _SeraCallLegionLevel = value;
                }
            }
        }

        
        #endregion


        #region Walk/Follow Options
        int _FollowStayBack = 2;
        [Category("Walk/Follow Options"),
        Description(
            "Your homunculus will stay this many cells behind you when " +
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
            "If set to rest, the homunculus will move this many cells east " +
            "of you when you sit.\n\nSetting this to a negative number will " +
            "cause the homunculus to move west instead."
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
            "If set to rest, the homunculus will move this many cells north " +
            "of you when you sit.\n\nSetting this to a negative number will " +
            "cause the homunculus to move south instead."
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
            "Set this to false if when you sit down, you want your homunculus to become passive, and, when it becomes idle, will move close to you."
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
            "Upon spawning, the homunculus will wait for this many " +
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
            "Set this to true if you want your homunculus to stay put when " +
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
            "Set this to true if you want your homunculus to fight normally " +
            "if MoveSticky is set to true."
            ),
        DefaultValue(false)]
        public bool MoveStickyFight // Set to 1 to fight normally in above mode
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

        bool _UseCastleRoute = false;
        [Category("Walk/Follow Options"),
        Description(
            "Enable this to use castling for route walk. See documentation." +
            "                                                              "
            ),
        DefaultValue(false)]
        public bool UseCastleRoute
        {
            get { return _UseCastleRoute; }
            set { _UseCastleRoute = value; }
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
            set
            {
                if (value < 0)
                {
                    _IdleWalkDistance = 0;
                }
                else if (value > 14)
                {
                    _IdleWalkDistance = 14;
                }
                else
                {
                    _IdleWalkDistance = value;
                }
            }
        }


        bool _ChaseSPPause = false;
        [Category("Walk/Follow Options"),
        Description(
            "Enable this to make the homun delay moving to a new target when it is below a specified SP level, AND is expecting an SP-regen tick in the near future. " +
            "This is an extreme measure to deal with SP problems resulting from the homun never staying still long enough to regen any SP (homuns do not regen sp while moving). " +
            "WARNING: This will make your homun pause after each kill, and this may be undesirable. Use this only if you understand this option. See documentation for details."
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
            "When ChaseSPPause is enabled, and SP is below this threshold, the homun may pause if near an SP tick." +
            "If set to a negative number, this is treated as a percentage. Otherwise, it is simply the number of SP."
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
            "if ChaseSPPause is enabled, and SP is below the specified threshold, the homun will pause if it is expecting an SP tick within this length of time." +
            "This is specified in milliseconds, ie, 2000 = 2 seconds. The homun SP tick is every 8 seconds"
            ),
        DefaultValue(2000)]
        public int ChaseSPPauseTime
        {
            get { return _ChaseSPPauseTime; }
            set
            {
                if (value < 100)
                {
                    _ChaseSPPauseTime = 100;
                }
                else if (value > 6000)
                {
                    _ChaseSPPauseTime = 6000;
                }
                else
                {
                    _ChaseSPPauseTime = value;
                }
            }
        }

        int _StationaryMoveBounds = 14;
        [Category("Walk/Follow Options"),
        Description(
            "This is the farthest from the owner that the homun will be allowed " +
            "to get before dropping all targets and moving back to the owner. This " +
            "value is used while the owner is NOT moving (see also MobileMoveBounds) " +
            "To control aggro range of homun, use the AggroDist options, not MoveBounds. " +
            "To set distance from owner that homun should return to after killing " +
            "use FollowStayBack, not MoveBounds. "

            ),
        DefaultValue(14)]
        public int StationaryMoveBounds
        {
            get { return _StationaryMoveBounds; }
            set
            {
                if (value < 1 )
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

            "This is the farthest from the owner that the homun will be allowed " +
            "to get before dropping all targets and moving back to the owner. This " +
            "value is used while the owner IS moving (see also StationaryMoveBounds) " +
            "To control aggro range of homun, use the AggroDist options, not MoveBounds. " +
            "This should probably be lower than StationaryMoveBounds to help keep homun " +
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
            "Set this to when you want your homunculus to use offensive buff" +
            "skills: Flitting, Mental Charge and Bloodlust"
            ),
        DefaultValue(UseOffensiveBuffOptions.Never)]
        public UseOffensiveBuffOptions UseOffensiveBuff
        {
            get { return _UseOffensiveBuff; }
            set { _UseOffensiveBuff = value; }
        }


        UseDefensiveBuffOptions _UseDefensiveBuff = UseDefensiveBuffOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Set this to when you want your homunculus to use defensive buff " +
            "skills like Amist Bulwark, Accellerated Flight and Urgent Escape"
            ),
        DefaultValue(UseDefensiveBuffOptions.Never)]
        public UseDefensiveBuffOptions UseDefensiveBuff
        {
            get { return _UseDefensiveBuff; }
            set { _UseDefensiveBuff = value; }
        }


        int _LifEscapeLevel = 5;
        [Category("Autobuff Options"),
        Description(
            "Set this value to the level of Lif Urgent Escape."
            ),
        DefaultValue(5)]
        public int LifEscapeLevel
        {
            get { return _LifEscapeLevel; }
            set
            {
                if (value < 1)
                {
                    _LifEscapeLevel = 1;
                }
                else if (value > 5)
                {
                    _LifEscapeLevel = 5;
                }
                else
                {
                    _LifEscapeLevel = value;
                }
            }
        }


        int _FilirFlitLevel = 1;
        [Category("Autobuff Options"),
        Description(
            "Set this value to the level of Filir Flitting."
            ),
        DefaultValue(1)]
        public int FilirFlitLevel
        {
            get { return _FilirFlitLevel; }
            set
            {
                if (value < 1)
                {
                    _FilirFlitLevel = 1;
                }
                else if (value > 5)
                {
                    _FilirFlitLevel = 5;
                }
                else
                {
                    _FilirFlitLevel = value;
                }
            }
        }


        int _AmiBulwarkLevel = 5;
        [Category("Autobuff Options"),
        Description(
            "Set this value to the level of Amistr Bulwark."
            ),
        DefaultValue(5)]
        public int AmiBulwarkLevel
        {
            get { return _AmiBulwarkLevel; }
            set
            {
                if (value < 1)
                {
                    _AmiBulwarkLevel = 1;
                }
                else if (value > 5)
                {
                    _AmiBulwarkLevel = 5;
                }
                else
                {
                    _AmiBulwarkLevel = value;
                }
            }
        }
        int _FilirAccelLevel = 1;
        [Category("Autobuff Options"),
        Description(
            "When autocasting the Filir skill Accellerated Flight use this" +
            "level. Note that only at level 1 can it be kept up full time."
            ),
        DefaultValue(1)]
        public int FilirAccelLevel
	{
		get { return _FilirAccelLevel; }
		set {
			if (value < 1)
			{
				_FilirAccelLevel=1;
			}
			else if (value > 5){
				_FilirAccelLevel=5;
			}
			else{
				_FilirAccelLevel= value;
			}
		}
	}



        int _HealOwnerHP = 40;
        [Category("Autobuff Options"),
        Description(
            "Set this value to the minimum HP (as a percent of maximum HP) " +
            "required for your homun to use healing skills."
            ),
        DefaultValue(40)]
        public int HealOwnerHP
	{
		get { return _HealOwnerHP; }
		set {
			if (value < 0)
			{
				_HealOwnerHP=0;
			}
			else if (value > 100){
				_HealOwnerHP=100;
			}
			else{
				_HealOwnerHP= value;
			}
		}
	}
        int _HealSelfHP = 0;
        [Category("Autobuff Options"),
        Description(
            "If your homun is a Vani, and UseAutoHeal is enabled then use" +
            "Chaotic Blessings to try to heal homun when it's below this" +
            "much hp"
            ),
        DefaultValue(0)]
        public int HealSelfHP
	{
		get { return _HealSelfHP; }
		set {
			if (value < 0)
			{
				_HealSelfHP=0;
			}
			else if (value > 100){
				_HealSelfHP=100;
			}
			else{
				_HealSelfHP= value;
			}
		}
	}


        UseAutoHealOptions _UseAutoHeal = UseAutoHealOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use healing skill (Healing Hands or Chaotic Blessing) to heal" +
            "owner or self. See HealSelfHP, HealOwnerHP to set at what HP" +
            "to start healing"
            ),
        DefaultValue(UseAutoHealOptions.Never)]
        public UseAutoHealOptions UseAutoHeal
        {
            get { return _UseAutoHeal; }
            set { _UseAutoHeal = value; }
        }

        HealOwnerBreezeOptions _HealOwnerBreeze = HealOwnerBreezeOptions.Disabled;
        [Category("Autobuff Options"),
        Description(
            "If this is enabled, we will use Silent Breeze to heal the owner. Obviously don't use this on servers without the Silent Breeze nerf, or if not immune to silence"
            ),
        DefaultValue(HealOwnerBreezeOptions.Disabled)]
        public HealOwnerBreezeOptions HealOwnerBreeze
        {
            get { return _HealOwnerBreeze; }
            set { _HealOwnerBreeze = value; }
        }
        UseSeraPainkillerOptions _UseSeraPainkiller = UseSeraPainkillerOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Painkiller on owner in the following states" +
            "Use DefensiveBuffOwnerMobbed and DefensiveBuffOwnerHP to only" +
            "use this skill when the owner is under attack"
            ),
        DefaultValue(UseSeraPainkillerOptions.Never)]
        public UseSeraPainkillerOptions UseSeraPainkiller
        {
            get { return _UseSeraPainkiller; }
            set { _UseSeraPainkiller = value; }
        }

        int _DefensiveBuffOwnerMobbed = 0;
        [Category("Autobuff Options"),
        Description(
            "Do not use use a defensive buff (Painkiller) on the owner unless" +
            "they have at least this many monsters attacking them, and the" +
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
                else if (value > 20)
                {
                    _DefensiveBuffOwnerMobbed = 20;
                }
                else
                {
                    _DefensiveBuffOwnerMobbed = value;
                }
            }
        }
        UseBayeriAngriffModusOptions _UseBayeriAngriffModus = UseBayeriAngriffModusOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Angriff Modus in the following states" +
            "                                                              "
            ),
        DefaultValue(UseBayeriAngriffModusOptions.Never)]
        public UseBayeriAngriffModusOptions UseBayeriAngriffModus
        {
            get { return _UseBayeriAngriffModus; }
            set { _UseBayeriAngriffModus = value; }
        }

        UseBayeriGoldenPherzeOptions _UseBayeriGoldenPherze = UseBayeriGoldenPherzeOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Golden Pherze in the following states" +
            "                                                              "
            ),
        DefaultValue(UseBayeriGoldenPherzeOptions.Never)]
        public UseBayeriGoldenPherzeOptions UseBayeriGoldenPherze
        {
            get { return _UseBayeriGoldenPherze; }
            set { _UseBayeriGoldenPherze = value; }
        }

        UseDieterMagmaFlowOptions _UseDieterMagmaFlow = UseDieterMagmaFlowOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Angriff Modus in the following states" +
            "                                                              "
            ),
        DefaultValue(UseDieterMagmaFlowOptions.Never)]
        public UseDieterMagmaFlowOptions UseDieterMagmaFlow
        {
            get { return _UseDieterMagmaFlow; }
            set { _UseDieterMagmaFlow = value; }
        }

        UseDieterGraniticArmorOptions _UseDieterGraniticArmor = UseDieterGraniticArmorOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Angriff Modus in the following states" +
            "Be aware that this skill drains hp when it wears off."
            ),
        DefaultValue(UseDieterGraniticArmorOptions.Never)]
        public UseDieterGraniticArmorOptions UseDieterGraniticArmor
        {
            get { return _UseDieterGraniticArmor; }
            set { _UseDieterGraniticArmor = value; }
        }

        UseDieterPyroclasticOptions _UseDieterPyroclastic = UseDieterPyroclasticOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Pyroclastic in the following states" +
            "Be aware that this skill breaks your weapon when it ends."
            ),
        DefaultValue(UseDieterPyroclasticOptions.Never)]
        public UseDieterPyroclasticOptions UseDieterPyroclastic
        {
            get { return _UseDieterPyroclastic; }
            set { _UseDieterPyroclastic = value; }
        }

int _DieterPyroclasticLevel = 10;
	[Category("Autobuff Options"),
	Description(
		"Use this level of Pyroclastic." +
		"                                                              "
		),
	DefaultValue(10)]
public int DieterPyroclasticLevel
{
    get { return _DieterPyroclasticLevel; }
    set
    {
        if (value < 1)
        {
            _DieterPyroclasticLevel = 1;
        }
        else if (value > 10)
        {
            _DieterPyroclasticLevel = 10;
        }
        else
        {
            _DieterPyroclasticLevel = value;
        }
    }
}

        UseEiraOveredBoostOptions _UseEiraOveredBoost = UseEiraOveredBoostOptions.Never;
        [Category("Autobuff Options"),
        Description(
            "Use the buff skill Overed Boost in the following states" +
            "                                                              "
            ),
        DefaultValue(UseEiraOveredBoostOptions.Never)]
        public UseEiraOveredBoostOptions UseEiraOveredBoost
        {
            get { return _UseEiraOveredBoost; }
            set { _UseEiraOveredBoost = value; }
        }
        
LavaSlideModeOptions _LavaSlideMode = LavaSlideModeOptions.Attack;
	[Category("Autobuff Options"),
	Description(
        "If set to anything except 'attack', Lava Slide will be cast at the owner's feet - This improves exp/hr while AFKing on maps like OD2, and also makes it easier for others on the map. This is handled like a buff skill; 'Idle' is the recommended setting." +
		"If set to 'attack', Lava Slide will be used as an AoE attack (controlled by the AutoMobMode AutoMobCount settings). This is recommended only for non-AFK leveling. " +
        "Note that the AI cannot detect when Lava Slide is canceled, so either way, it will assume it lasts 7.5 seconds, and may try to recast after that"
		),
	DefaultValue(LavaSlideModeOptions.Attack)]
	public LavaSlideModeOptions LavaSlideMode
	{
		get { return _LavaSlideMode; }
		set { _LavaSlideMode = value; }
	}

PoisonMistModeOptions _PoisonMistMode = PoisonMistModeOptions.Attack;
	[Category("Autobuff Options"),
    Description(
        "If set to anything except 'attack', Poison Mist will be cast at the owner's feet - This greatly improves exp/hr while AFKing on maps like OD2, and also makes it easier for others on the map. This is handled like a buff skill; 'Idle' is the recommended setting." +
        "If set to 'attack', Poison Mist will be used as an AoE attack (controlled by the AutoMobMode AutoMobCount settings). This is recommended only for non-AFK leveling (and even then, casting it on owner's feet is often better). "
        ),
	DefaultValue(PoisonMistModeOptions.Attack)]
	public PoisonMistModeOptions PoisonMistMode
	{
		get { return _PoisonMistMode; }
		set { _PoisonMistMode = value; }
	}

UseBayeriSteinWandOptions _UseBayeriSteinWand = UseBayeriSteinWandOptions.Never;
	[Category("Autobuff Options"),
	Description(
		"Use the skill Stien Wand in the following states if the owner" +
		"or homunculus are mobbed (see UseStienWandSelfMob and " +
		"UseStienWandOwnerMob to set at what mob size to cast it"
		),
	DefaultValue(UseBayeriSteinWandOptions.Never)]
	public UseBayeriSteinWandOptions UseBayeriSteinWand
	{
		get { return _UseBayeriSteinWand; }
		set { _UseBayeriSteinWand = value; }
	}

int _BayeriSteinWandLevel = 5;
	[Category("Autobuff Options"),
	Description(
		"Use this level of Stien Wand." +
		"                                                              "
		),
	DefaultValue(5)]
public int BayeriSteinWandLevel
{
    get { return _BayeriSteinWandLevel; }
    set
    {
        if (value < 1)
        {
            _BayeriSteinWandLevel = 1;
        }
        else if (value > 5)
        {
            _BayeriSteinWandLevel = 5;
        }
        else
        {
            _BayeriSteinWandLevel = value;
        }
    }
}


int _UseSteinWandSelfMob = 3;
	[Category("Autobuff Options"),
	Description(
		"If UseBayeriStienWand is enabled, use it when there are this " +
		"many monsters on the homun."
		),
	DefaultValue(3)]

public int UseSteinWandSelfMob
{
    get { return _UseSteinWandSelfMob; }
    set
    {
        if (value < 0)
        {
            _UseSteinWandSelfMob = 0;
        }
        else if (value > 20)
        {
            _UseSteinWandSelfMob = 20;
        }
        else
        {
            _UseSteinWandSelfMob = value;
        }
    }
}

int _UseSteinWandOwnerMob = 3;
	[Category("Autobuff Options"),
	Description(
		"If UseBayeriStienWand is enabled, use it when there are this " +
		"many monsters on the owner."
		),
	DefaultValue(3)]
public int UseSteinWandOwnerMob
{
    get { return _UseSteinWandOwnerMob; }
    set
    {
        if (value < 0)
        {
            _UseSteinWandOwnerMob = 0;
        }
        else if (value > 20)
        {
            _UseSteinWandOwnerMob = 20;
        }
        else
        {
            _UseSteinWandOwnerMob = value;
        }
    }
}

bool _UseSteinWandTele = false;
	[Category("Autobuff Options"),
	Description(
		"If enable this to use Stien Wand after teleporting or spawning" +
		"after SpawnDelay ends. Homun will pause after this for a short" +
		"time set by SteinWandTelePause before acting normally. The " +
		"idea is that you tele around looking for mobs, and then land " + 
		"and the bay casts stienwand, waits for the monsters to get near" +
		"and then kills them with Hailage Star."
		),
	DefaultValue(false)]
	public bool UseSteinWandTele
	{
		get { return _UseSteinWandTele; }
		set { _UseSteinWandTele = value; }
	}

int _SteinWandTelePause = 1000;
	[Category("Autobuff Options"),
	Description(
		"The time to pause after casting StienWand after teleporting" +
		"when UseStienWandTele is enabled. In milliseconds."
		),
	DefaultValue(1000)]
public int SteinWandTelePause
{
    get { return _SteinWandTelePause; }
    set
    {
        if (value < 0)
        {
            _SteinWandTelePause = 0;
        }
        else if (value > 5000)
        {
            _SteinWandTelePause = 5000;
        }
        else
        {
            _SteinWandTelePause = value;
        }
    }
}


bool _UseCastleDefend = false;
	[Category("Autobuff Options"),
	Description(
		"Enable this to use castling to defend the owner when he is" +
		"mobbed."
		),
	DefaultValue(false)]
	public bool UseCastleDefend
	{
		get { return _UseCastleDefend; }
		set { _UseCastleDefend = value; }
	}

int _CastleDefendThreshold = 3;
	[Category("Autobuff Options"),
	Description(
		"If UseCastleDefend is enabled, then it will be used when the " +
		"owner has this many monsters on him and the homun has less"
		),
	DefaultValue(3)]
	public int CastleDefendThreshold
	{
		get { return _CastleDefendThreshold; }
        set
        {
            if (value < 1)
            {
                _CastleDefendThreshold = 1;
            }
            else if (value > 20)
            {
                _CastleDefendThreshold = 20;
            }
            else
            {
                _CastleDefendThreshold = value;
            }
        }
	}

    bool _UseSmartBulwark = false;
    [Category("Autobuff Options"),
    Description(
        "Amistrs sometimes run themselves out of SP to keep up other buffs in order" +
        " to keep Amistr Bulwark up. If this is option is enabled, Bulwark will only be used if the Amistr has enough SP to cast all other buffs it is configured to."
        ),
    DefaultValue(false)]
    public bool UseSmartBulwark
    {
        get { return _UseSmartBulwark; }
        set { _UseSmartBulwark = value; }
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
        "Set this to true if you want your mercenary to kite away from" +
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
        "Move this many cells when kiting from a monster that." +
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
        "Kite when a monster that has not yet attacked " +
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
        "Set this to true if you want your homunculus to kite monsters." +
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
        bool _StandbyFriending = true;
        [Category("Friending Options"),
        Description(),
        DefaultValue(true)]
        public bool StandbyFriending
        {
            get { return _StandbyFriending; }
            set { _StandbyFriending = value; }
        }


        bool _MirAIFriending = false;
        [Category("Friending Options"),
        Description(
            "Set this to true if you want the homunculus to emulate MirAI " +
            "friending."
            ),
        DefaultValue(false)]
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
            "Set this to true if you want your homunculus to defend you " +
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
            "Set this to true if you want your homunculus to return to " +
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
            "If you want your homunculus to go berzerk while being " +
            "attacked, set this to a value greater than 0. Otherwise, set " +
            "it to 0 to disable berzerk mode while being mobbed."
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
            "Set to true to have your homunculus go berzerk when told to " +
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
            "Set this to true to have your homunculus go berzerk when told " +
            "to attack a target."
            ),
        DefaultValue(false)]
        public bool UseBerserkAttack
        {
            get { return _UseBerserkAttack; }
            set { _UseBerserkAttack = value; }
        }


        bool _Berserk_SkillAlways = false;
        [Category("Berserk Options"),
        Description(
            "Set this to true to ignore skill use limits while in berzerk " +
            "mode."
            ),
        DefaultValue(false)]
        public bool Berserk_SkillAlways
        {
            get { return _Berserk_SkillAlways; }
            set { _Berserk_SkillAlways = value; }
        }


        bool _Berserk_Dance = false;
        [Category("Berserk Options"),
        Description(
            "Set this to true if you want your homunculus to use dance " +
            "attack while in berzerk mode."
            ),
        DefaultValue(false)]
        public bool Berserk_Dance
        {
            get { return _Berserk_Dance; }
            set { _Berserk_Dance = value; }
        }
        bool _Berserk_IgnoreMinSP = false;
        [Category("Berserk Options"),
        Description(
            "Set this to true if you want your homunculus to use dance " +
            "attack while in berzerk mode."
            ),
        DefaultValue(false)]
        public bool Berserk_IgnoreMinSP
        {
            get { return _Berserk_IgnoreMinSP; }
            set { _Berserk_IgnoreMinSP = value; }
        }
        bool _Berserk_ComboAlways = false;
        [Category("Berserk Options"),
        Description(
            "Enable this to use full combos while in berserk mode." +
            "                                                              "
            ),
        DefaultValue(false)]
        public bool Berserk_ComboAlways
        {
            get { return _Berserk_ComboAlways; }
            set { _Berserk_ComboAlways = value; }
        }


        #endregion


        #region PVP Options
        bool _PVPmode = false;
        [Category("PVP Options"),
        Description(
            "Set this to true if you want to use your homunculus in PVP " +
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