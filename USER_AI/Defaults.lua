---------------------------
--DO NOT MODIFY THIS FILE--
---------------------------
--TO CHANGE AI BEHAVIOR  --
--USE THE H_Config OR    --
--OR M_Config FILES      --
---------------------------
--THIS FILE PREVENTS     --
--DAMAGED, CORRUPTED OR  --
--MISSING CONFIG FILES   --
--FROM CRASHING          --
--THE CLIENT.		 --
---------------------------
MyTact={}
MyPVPTact={}

-- Basic Options
AggroHP                  = 60
AggroSP                  = 0
OldHomunType			= 3
UseSkillOnly			=-1 
UseAttackSkill			=1
OpportunisticTargeting  =0
DoNotChase				=0
UseDanceAttack			=0
SuperPassive			=0
PVPMode					=0
AttackLastHPSP			=80
UseIdleWalk				=0
IdleWalkDistance		=3
UseCastleRoute			=0
RelativeRoute			=1
UseCastleDefend			=0
CastleDefendThreshold	=4
AutoDetectPlant			=1
FleeHP					=0
DanceMinSP				=0
ChaseSPPause 			= 0
ChaseSPPauseSP 			= -80
ChaseSPPauseTime 		= 3000
RescueOwnerLowHP		=0
AOEFixedLevel		=1
LiveMobID=0

UseBlessingOwner		= 1
UseBlessingSelf			= 0
UseIncAgiSelf			= 0
UseIncAgiOwner			= 1
UseKyrieSelf			= 0
UseKyrieOwner			= 0
-- Attack skill options
AttackSkillReserveSP  = 0 
AutoMobMode			=1 
AutoMobCount		=5
AutoComboMode		=1
AutoComboSkill		=0
AutoComboSpheres	=10
UseAutoPushback		=0
AutoPushbackThreshold		=2
UseHomunSSkillChase 		= 1
UseHomunSSkillAttack 		= 1 
AutoSkillDelay          	= 400 
AoEMaximizeTargets					=  0
CastTimeRatio				= .5
UseEiraXenoSlasher			=0 
EiraXenoSlasherLevel		=4 
UseEiraEraseCutter			=1
EiraEraseCutterLevel		=4 
UseEiraSilentBreeze		= 0
EiraSilentBreezeLevel	=5 
UseBayeriStahlHorn			=1
BayeriStahlHornLevel		=5
UseBayeriHailegeStar		=1
BayeriHailegeStarLevel		=5
UseBayeriSteinWand			=0
BayeriSteinWandLevel		=5
UseSteinWandSelfMob			=2
UseSteinWandOwnerMob		=2
UseSteinWandTele			=0 
StienWandTelePause 			=3000
UseSeraParalyze				=1
SeraParalyzeLevel			=5
UseSeraPoisonMist			=0 
SeraPoisonMistLevel			=5
UseSeraCallLegion			=1 
SeraCallLegionLevel			=5
UseEleanorSonicClaw			=1
EleanorSonicClawLevel		=5
EleanorSilverveinLevel		=5
EleanorMidnightLevel		=5
UseDieterLavaSlide			=1 
DieterLavaSlideLevel		=5


--Autobuff options

UseDefensiveBuff		=1
UseOffensiveBuff		=1 
UseProvokeOwner     =0
DefensiveBuffOwnerMobbed	=0
DefensiveBuffOwnerHP		=80
UseProvokeSelf		=0
UseSacrificeOwner   =0
UseAutoMag			=0
UseAutoSight        =1
LifEscapeLevel  =5
FilirFlitLevel  =1
FilirAccelLevel =1
AmiBulwarkLevel =5
UseSeraPainkiller = 0

UseBayeriAngriffModus	=0
UseBayeriGoldenPherze	=0
UseDieterMagmaFlow	=0
UseDieterGraniticArmor	=0
UseDieterPyroclastic	=0
UseEiraOveredBoost		=0

--AutoHeal Options:
HealSelfHP		= 50 
HealOwnerHP              = 50 
UseAutoHeal              = 0 

FollowStayBack =1
StationaryAggroDist 	=12
MobileAggroDist			=7
StationaryMoveBounds    =14
MobileMoveBounds		=9
DoNotUseRest =0
RestXOff		=0
RestYOff		=-2	
AoEReserveSP=0

MoveSticky               = 0
MoveStickyFight          = 0

--Kiting options:
KiteMonsters 				=0
KiteBounds               = 10 
KiteStep                 = 5
KiteParanoidStep         = 2
KiteThreshold            = 3
KiteParanoidThreshold    = 2
KiteParanoid             = 0 

--Standby Behavior:
DefendStandby            = 0 
StickyStandby            = 1 


--Advanced Timing settings 
SpawnDelay               = 1000
AutoSkillDelay		= 400
ChaseGiveUp              = 6
AttackGiveUp		=10 
AtkPosbugTimeoutLimit  = 3 
FollowTryPanic		=3 
SphereTrackFactor	=3 

--Berzerk Settings:

UseBerzerkMobbed         = 0 
UseBerzerkSkill          = 0 
UseBerzerkAttack         = 0 
Berzerk_SkillAlways      = 0 
Berzerk_Dance            = 0
Berzerk_IgnoreMinSP      = 0 


--Misc settings:
StandbyFriending         = 1  
MirAIFriending           = 1  
UseAvoid		 = 0  
TankMonsterLimit	= 4
AttackTimeLimit		= 0
AggressiveRelogTracking = 0
AggressiveRelogPath = "./AI/USER_AI/"
AttackLastFullSP = 0










DoNotChase 		=0
KSMercHomun		=0
AssumeHomun		=1
UseAutoPushback		=0
AutoPushbackThreshold	=2
NewAutoFriend		=1
ProvokeOwnerTries	=5
ProvokeOwnerDelay	=400
SkillObjectCMDLimit = 12
RouteWalkCircle		=1

FastChange_C2I		=1
FastChange_C2A		=1
FastChange_A2C		=1
FastChange_A2I		=0
FastChange_I2C		=0
FastChange_F2I		=0

FastChangeLimit		=1

AttackDebuffLimit	=1


MagicNumber		=42000
MagicNumber2		=100000



-- Homun S stuff




FriendAttack={}			--Set these to 1 to have homun attack 
				--the target of a friend/owner when the friend is:
FriendAttack[MOTION_ATTACK]=1	--Attacking normally
FriendAttack[MOTION_ATTACK2]=1	--Attacking normally
FriendAttack[MOTION_SKILL]=1	--Uses a skill (which has the normal skill animation)
FriendAttack[MOTION_CASTING]=1	--Is casting a skill with a casting time
FriendAttack[MOTION_TOSS]=0	--Uses SpearBoom/AidPot/other "throwing" things
FriendAttack[MOTION_BIGTOSS]=1	--Uses Acid Bomb
FriendAttack[MOTION_FULLBLAST]=1	--Uses Full Blast

AtkSkillList={MA_DOUBLE,MA_SHARPSHOOTING,ML_PIERCE,ML_SPIRALPIERCE,MS_BASH}
MobSkillList={MA_SHOWER,MA_SHARPSHOOTING,ML_BRANDISH,MS_MAGNUM,MS_BOWLINGBASH}
GuardSkillList={ML_AUTOGUARD,MS_PARRYING,MS_REFLECTSHIELD} --,MS_DEFENDER}
PushSkillList={MA_CHARGEARROW,MA_SKIDTRAP}
DebuffSkillList={MER_CRASH,MER_PROVOKE,MER_DECAGI,MA_SANDMAN,MA_FREEZINGTRAP,MER_LEXDIVINA}

BasicDebuffs={}
BasicDebuffs[MER_CRASH]=	1
BasicDebuffs[MER_LEXDIVINA]=	1
BasicDebuffs[MER_DECAGI]=	1
BasicDebuffs[MA_SANDMAN]=	1
BasicDebuffs[MA_FREEZINGTRAP]=	1

SkillRetryLimit={4,4,4,3,3,3,3,0,2,2,3,3,3} --Guard, Quicken, Mag, SOffensive, SDefensive, SOwnerBuff, Sight/under-owner-ground, style change, Provoke/Painkiller
SkillRetryLimit[-1]=2 -- for atk skills

LogEnable={}
LogEnable["AAI_ERROR"]=1
LogEnable["AAI_SKILLFAIL"]=0
LogEnable["AAI_CLOSEST"]=0

LogEnable["AAI_Lag"]=0