-- This is the Extra Options file
-- NewAutoFriend = 0 -- uncomment this if you're not using AzzyAI for your homun.
-- AggressiveRelogTracking = 1               -- see documentation
-- AggressiveRelogPath = "./AI/USER_AI/data" -- do not uncomment without reading applicable documentation
-- AggressiveAutofriend = 1 				-- see documentation


MyRoute={{0,0}}

FriendAttack={}			--Set these to 1 to have homun attack 
				--the target of a friend/owner when the friend is:
FriendAttack[MOTION_ATTACK]=1	--Attacking normally
FriendAttack[MOTION_ATTACK2]=1	--Attacking normally
FriendAttack[MOTION_SKILL]=1	--Uses a skill (which has the normal skill animation)
FriendAttack[MOTION_CASTING]=1	--Is casting a skill with a casting time
FriendAttack[MOTION_TOSS]=0	--Uses SpearBoom/AidPot/other "throwing" things
FriendAttack[MOTION_BIGTOSS]=1	--Uses Acid Bomb
FriendAttack[MOTION_FULLBLAST]=1	--Uses Full Blast


BasicDebuffs={}
BasicDebuffs[MER_CRASH]=	1
BasicDebuffs[MER_LEXDIVINA]=	1
BasicDebuffs[MER_DECAGI]=	1
BasicDebuffs[MA_SANDMAN]=	1
BasicDebuffs[MA_FREEZINGTRAP]=	1


--Uncomment the lines below to enable logging of skill failure detection and Closest() (respectively)
--LogEnable["AAI_SKILLFAIL"]=1 
--LogEnable["AAI_CLOSEST"]=1
--LogEnable["AAI_DANCE"]=1
--LogEnable["AAI_ACTORS"]=1
--LogEnable["AAI_LAG"]=1

--Uncomment this line to suppress AAI_ERROR logging. This should only be done as a stop-gap measure; if your AAI_ERROR log is filling up with messages, please report this to the developer. 
--LogEnable["AAI_ERROR"]=0