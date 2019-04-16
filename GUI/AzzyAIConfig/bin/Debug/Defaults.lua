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


FollowStayBack 		=2
RestXOff		=0
RestYOff		=-2	
SpawnDelay		=1000
UseOffensiveBuff 	 	= 1
UseDefensiveBuff	 	= 1
UseAutoSight	 	= 0
UseAutoMag		= 1
UseProvokeOwner 	= 0
UseSacrificeOwner 	= 0
KiteMonsters		=1
KiteParanoid		=1
KiteStep		=5
KiteParanoidStep	=2
KiteThreshold		=3
KiteParanoidThreshold	=2	
KiteBounds		=8		
ForceKite		=0
PVPmode 		=0
DoNotChase 		=0
KSMercHomun		=0
AssumeHomun		=1
AttackSkillReserveSP	=0
AutoMobCount		=2
UseSkillOnly		=-1
AutoSkillDelay		=400 
AutoSkillLimit		=100 
UseAutoPushback		=0
AutoPushbackThreshold	=2
NewAutoFriend		=1
ProvokeOwnerTries	=5
ProvokeOwnerDelay	=400
UseSmartFAS		=0
UseSmartBrandish	=0
UseSmartBB		=0

RouteWalkCircle		=1

FastChange_C2I		=1
FastChange_C2A		=1
FastChange_A2C		=1
FastChange_A2I		=0
FastChange_I2C		=0
FastChange_F2I		=0

FollowTryPanic		=3 --Try this many times to move to owner at FollowStayBack before panicing and moving right to him
AttackGiveUp		=5
FastChangeLimit		=1

AttackDebuffLimit	=1

MirAIFriending		=0
StandbyFriending	=0

FilirFlitLevel		=5
LifEscapeLevel		=5
AmiBulwarkLevel		=5

DoNotUseRest		=0
StickyStandby		=0
DefendStandby		=0


UseAutoHeal		=0
HealOwnerHP		=0

UseAvoid		=0

MoveSticky		=0
MoveStickyFight		=0

MagicNumber		=40000
MagicNumber2		=100000

AutoDetectPlant		=1
UseBerserkSkill 	=0
UseBerserkAttack	=0
UseBerserkMobbed	=0
Berserk_SkillAlways	=0
Berserk_Dance		=0
Berserk_IgnoreMinSP 

FleeHP			=0
TankMonsterLimit	=4

FriendAttack={}			--Set these to 1 to have homun attack 
				--the target of a friend/owner when the friend is:
FriendAttack[MOTION_ATTACK]=1	--Attacking normally
FriendAttack[MOTION_ATTACK2]=1	--Attacking normally
FriendAttack[MOTION_SKILL]=1	--Uses a skill (which has the normal skill animation)
FriendAttack[MOTION_CASTING]=0	--Is casting a skill with a casting time
FriendAttack[MOTION_TOSS]=0	--Uses SpearBoom/AidPot/other "throwing" things
FriendAttack[MOTION_BIGTOSS]=1	--Uses Acid Bomb
FriendAttack[MOTION_FULLBLAST]=1	--Uses Full Blast


BasicDebuffs={}
BasicDebuffs[MER_CRASH]=	1
BasicDebuffs[MER_LEXDIVINA]=	1
BasicDebuffs[MER_DECAGI]=	1
BasicDebuffs[MA_SANDMAN]=	1
BasicDebuffs[MA_FREEZINGTRAP]=	1

