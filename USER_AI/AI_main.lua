-----------------------------
-- Dr. Azzy's Merc/Homun AI
-- Written by Dr. Azzy of iRO Chaos
-- This AI is intended for use on official servers only
-- Permission granted to distribute in unmodified form.
-- You may expand the AI freely through the M_Extra and H_Extra files
MainVersion="1.56"

ResCmdList			= List.new()
-- As of dev 15, global variables are now in Const_.lua
AutoSkillCooldown		= {}
AutoSkillCooldown[HFLI_MOON]=0
AutoSkillCooldown[HVAN_CAPRICE]=0
AutoSkillCooldown[HVAN_CHAOTIC]=0
AutoSkillCooldown[HLIF_HEAL]=0
AutoSkillCooldown[MH_POISON_MIST]=0
AutoSkillCooldown[MH_LAVA_SLIDE]=0
AutoSkillCooldown[MH_STEINWAND]=0 	
AutoSkillCooldown[MH_SUMMON_LEGION]=0
-----------Config checking----------------

function doInit(myid)
	local logstring="Checking config..."
	if IsHomun(myid) == 0 then -- if the stupid devs made GetV(V_MERTYPE,id) work i wouldnt need this!
		MercType=GetMerType(myid)
	end
	if (UseAttackSkill==0 and UseSkillOnly==1) then
		UseSkillOnly = 0
		logstring=logstring.."\nUseAttackSkill==0, but UseSkillOnly==1. This will break the AI. UseSkillOnly set to 0. "
	end
	if DanceMinSP < 0 then
		DanceMinSP=math.floor(GetV(V_MAXSP,MyID)*DanceMinSP/100)*-1
	end
	if ChaseSPPauseSP < 0 then
		ChaseSPPauseSP=math.floor(GetV(V_MAXSP,MyID)*ChaseSPPauseSP/100)*-1
	end
	MyMaxSP=GetV(V_MAXSP,MyID)
	MyLastSP=GetV(V_SP,MyID)
	local loadtimesuccess = pcall(loadtimeouts)
	if loadtimesuccess==false then
		logstring=logstring.."\nfailed to load timeouts for owner "..GetV(V_OWNER,MyID).." if this is the first time you've used this account with AzzyAI, disregard this message"
	end
	if GetV(V_SKILLATTACKRANGE,myid,HVAN_CAPRICE) > 1 then -- it was a vani
		OldHomunType=VANILMIRTH
	end
	if GetV(V_SKILLATTACKRANGE,myid,MH_ERASER_CUTTER) == 1 then
		if UseEiraEraseCutter and GetV(V_HOMUNTYPE,myid)==EIRA  then
			logstring=logstring.."UseEiraEraseCutter disabled - you don't have the skill!"
		end
		UseEiraEraseCutter=0
	end
	if GetV(V_SKILLATTACKRANGE,myid,MH_XENO_SLASHER) == 1 then 
		if UseEiraXenoSlasher and GetV(V_HOMUNTYPE,myid)==EIRA then
			logstring=logstring.."UseEiraXenoSlasher disabled - you don't have the skill!"
		end
		UseEiraXenoSlasher=0
	end
	if GetV(V_SKILLATTACKRANGE,myid,MH_STAHL_HORN) == 1 then 
		if UseEiraEraseCutter and GetV(V_HOMUNTYPE,myid)==EIRA then
			logstring=logstring.."UseBayeriStahlHorn disabled - you don't have the skill!"
		end
		UseBayeriStahlHorn=0
	end
	if GetV(V_SKILLATTACKRANGE,myid,MH_HEILIGE_STANGE) == 1 then
		if UseBayeriHailegeStar and GetV(V_HOMUNTYPE,myid)==BAYERI then
			logstring=logstring.."UseBayeriHailegeStar disabled - you don't have the skill!"
		end
		UseBayeriHailegeStar=0
	end
	if GetV(V_SKILLATTACKRANGE,myid,MH_NEEDLE_OF_PARALYZE) == 1 then
		if UseSeraParalyze and GetV(V_HOMUNTYPE,myid)==SERA then
			UseSeraParalyze=0
			logstring=logstring.."UseSeraParalyze disabled - you don't have the skill!"
		end
		UseSeraParalyze=0
	end
	if GetV(V_SKILLATTACKRANGE,myid,MH_POISON_MIST) < 2 then 
		if UseSeraPoisonMist and GetV(V_HOMUNTYPE,myid)==SERA then
			logstring=logstring.."UseSeraPoisonMist disabled - you don't have the skill!"
		end
		if UseSeraPainkiller and GetV(V_HOMUNTYPE,myid)==SERA then
			logstring=logstring.."UseSeraPainkiller disabled - you don't have the skill!"
		end
		UseSeraPoisonMist=0
		UseSeraPainkiller=0
	end
	if GetV(V_SKILLATTACKRANGE,myid,MH_LAVA_SLIDE) == 1 then
		if UseDieterLavaSlide and GetV(V_HOMUNTYPE,myid)==DIETER then
			logstring=logstring.."UseDieterLavaSlide disabled - you don't have the skill!"
		end
		UseDieterLavaSlide=0
	end
	OutFile=io.open("AAIStartH.txt","a")
	if OutFile == nil then
		Error("No write permissions for RO folder, please fix permissions on the RO folder in order to use AzzyAI. Version Info: "..OutString)
	else
		OutFile:write(logstring)
		OutFile:close()
	end
	local mskill,mlevel=GetMobSkill(MyID)
	if mskill==0 and (GetV(V_HOMUNTYPE,MyID)==SERA and PoisonMistMode~=0) or (GetV(V_HOMUNTYPE,MyID)==DIETER and LavaSlideMode~=0) then
		mskill,mlevel=GetSightOrAoE(MyID)
	end
	if mskill~=0 and mlevel~=0 and AoEReserveSP==1 and AutoMobMode~=0 then
		ReserveSP=GetSkillInfo(mskill,3,mlevel)
	end
	OnInit()
	if AggressiveRelogTracking~=1 then
		MagTimeout=MagTimeout+500
		SOffensiveTimeout=SOffensiveTimeout+500
		SDefensiveTimeout=SDefensiveTimeout+500
		SOwnerBuffTimeout=SOwnerBuffTimeout+500
		GuardTimeout=GuardTimeout+500
		QuickenTimeout=QuickenTimeout+500
		OffensiveOwnerTimeout	= OffensiveOwnerTimeout+500
		DefensiveOwnerTimeout	= DefensiveOwnerTimeout+500
		OtherOwnerTimeout		= OtherOwnerTimeout+500
	else
		timelag=LastAITime_ART-GetTick()
		MagTimeout=MagTimeout+timelag
		SOffensiveTimeout=SOffensiveTimeout+timelag
		SDefensiveTimeout=SDefensiveTimeout+timelag
		SOwnerBuffTimeout=SOwnerBuffTimeout+timelag
		GuardTimeout=GuardTimeout+timelag
		QuickenTimeout=QuickenTimeout+timelag
		OffensiveOwnerTimeout	= OffensiveOwnerTimeout+timelag
		DefensiveOwnerTimeout	= DefensiveOwnerTimeout+timelag
		OtherOwnerTimeout		= OtherOwnerTimeout+timelag
	end
	AdjustCapriceLevel()
	UpdateTimeoutFile()
	DoneInit=1
end
function AdjustCapriceLevel()
	local msp=GetV(V_MAXSP,MyID)
	if msp < 30 and VanCapriceLevel==nil then 
		if msp >=28 then
			VanCapriceLevel=4
		elseif msp >=26 then
			VanCapriceLevel=3
		elseif msp >=24 then
			VanCapriceLevel=2
		else
			VanCapriceLevel=1
		end
	end
end
function loadtimeouts()
	if IsHomun(MyID)==1 then
		dofile(ConfigPath.."data/H_"..GetV(V_OWNER,MyID).."Timeouts.lua")
	else
		dofile(ConfigPath.."data/M_"..GetV(V_OWNER,MyID).."Timeouts.lua")
	end
	if AggressiveRelogTracking==1 then
		if IsHomun(MyID)==1 then
			dofile(AggressiveRelogPath.."H_"..GetV(V_OWNER,MyID).."Time.lua")
		else
			dofile(AggressiveRelogPath.."M_"..GetV(V_OWNER,MyID).."Time.lua")
		end
	end
end

--########################################
--### Friend the merc/homun - old one  ###
--### by Misch, new one by Dr. Azzy    ###
--########################################

if (AssumeHomun==1) then
	if (NewAutoFriend==0) then
		ff = {}
		Hactors = GetActors()
		Howner  = GetV(V_OWNER,Hactors[1])
		FX = 0
		FY = 0
		OX,OY = GetV(V_POSITION,Howner)
		for i,v in ipairs(Hactors) do
			if (v ~= Howner) then
				if (IsMonster(v)==0) then
					FX,FY = GetV(V_POSITION,v)
					if (FX==OX and FY==OY and v<100000) then --is not a player
						MyFriends[v]=2
					end
				end
			end
		end
	else
		NeedToDoAutoFriend=1
		TraceAI("Setting NeedToDoAutoFriend")
	end
end
--####################################
--######## Command Processing ########
--####################################

function	OnMOVE_CMD (x,y)
	TraceAI ("OnMOVE_CMD")
	if GetDistanceAPR(GetV(V_OWNER,MyID),x,y) > 15 or x==0 or y==0 then -- Bogus move command
		local ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
		logappend("AAI_ERROR","move command to invalid location "..formatpos(x,y).." owner pos "..formatpos(ox,oy))
		TraceAI("OnMOVE_CMD - Command disregarded; invalid location logged")
		return
	end
	
	ResetCounters()
	if ( x == MyDestX and y == MyDestY and MOTION_MOVE == GetV(V_MOTION,MyID)) then
		return
	end

	--local curX, curY = GetV (V_POSITION,MyID)
	--if (math.abs(x-curX)+math.abs(y-curY) > 15) then
	--	List.pushleft (ResCmdList,{MOVE_CMD,x,y})
	--	x = math.floor((x+curX)/2)  
	--	y = math.floor((y+curY)/2)
	--end
	MyMoveX,MyMoveY=x,y
	MyDestX,MyDestY=x,y
	Move (MyID,MyDestX,MyDestY)	
	MyState = MOVE_CMD_ST
	if (MirAIFriending==1) then --emulate MirAI's annoying friending process
		TraceAI("Starting Friend Routine")
		local actors = GetActors()
		for i,v in ipairs(actors) do
			if (IsMonster(v)~=1 and v~=GetV(V_OWNER,MyID) and v~=MyID) then
				xx,yy=GetV(V_POSITION,v)
				if (xx==x and (yy+1==y or yy-1==y)) then
					
					if (MyFriends[v]==nil) then
						MyFriends[v] = 1
						UpdateFriends()
						MyState=FRIEND_CIRCLE_ST
						TraceAI("Friend Addition")
						NewFriendX,NewFriendY=GetV(V_POSITION,v)
						return
					elseif (MyFriends[v]~=nil) then
						MyFriends[v] = nil
						UpdateFriends()
						MyState=FRIEND_CROSS_ST
						TraceAI("Friend Removal")
						NewFriendX,NewFriendY=GetV(V_POSITION,v)
						return
					end
				end
			end
		end
	end
end


function	OnSTOP_CMD ()

	TraceAI ("OnSTOP_CMD")
	logappend("AAI_ERROR","STOP_CMD sent! This should NEVER HAPPEN!")
	if (GetV(V_MOTION,MyID) ~= MOTION_STAND) then
		Move (MyID,GetV(V_POSITION,MyID))
	end
	MyState = IDLE_ST
	MyDestX = 0
	MyDestY = 0
	MyEnemy = 0
	EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
	EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
	MySkill = 0

end


function	OnATTACK_OBJECT_CMD (id)
	TraceAI ("OnATTACK_OBJECT_CMD")
	ResetCounters()
	MySkill = 0
	MyEnemy = id
	BypassKSProtect=1
	if (UseBerserkAttack==1) then
		BerserkMode=1
	end
	MyState = CHASE_ST
	OnCHASE_ST()
end


function	OnATTACK_AREA_CMD (x,y)

	TraceAI ("OnATTACK_AREA_CMD")
	logappend("AAI_ERROR","ATTACK_AREA_CMD sent! This should NEVER HAPPEN!")
	if (x ~= MyDestX or y ~= MyDestY or MOTION_MOVE ~= GetV(V_MOTION,MyID)) then
		Move (MyID,x,y)	
	end
	MyDestX = x
	MyDestY = y
	MyEnemy = 0
	EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
	EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
	MyState = ATTACK_AREA_CMD_ST
	
end

function	OnPATROL_CMD (x,y)

	TraceAI ("OnPATROL_CMD")
	logappend("AAI_ERROR","PATROL_CMD sent! This should NEVER HAPPEN!")
	MyPatrolX , MyPatrolY = GetV (V_POSITION,MyID)
	MyDestX = x
	MyDestY = y
	Move (MyID,x,y)
	MyState = PATROL_CMD_ST

end


function	OnHOLD_CMD ()

	TraceAI ("OnHOLD_CMD")
	logappend("AAI_ERROR","HOLD_CMD sent! This should NEVER HAPPEN!")
	MyDestX = 0
	MyDestY = 0
	MyEnemy = 0
	EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
	EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
	MyState = HOLD_CMD_ST

end


function	OnSKILL_OBJECT_CMD (level,skill,id)

	TraceAI ("OnSKILL_OBJECT_CMD"..skill.." "..id.." "..level)
	ResetCounters()
	if skill==MH_PAIN_KILLER and IsPlayer(id)==1 and PainkillerFriends~=0 and id~=GetV(V_OWNER,MyID) then
		MyPState = MyState
		MyState = PROVOKE_ST
		MyPEnemy = id
		MyPSkill = skill
		MyPSkillLevel = level
		MyPMode = id
		if MyFriends[id]~=FRIEND then
			MyFriends[id]=PKFRIEND
			if PainkillerFriendsSave==1 then
				UpdateFriends()
			end
		end
		return OnPROVOKE_ST()
	else
		MySkillLevel = level
		MySkill = skill
		MyEnemy = id
		if IsMonster(id)==1 and SuperPassive~=1 then
			BypassKSProtect=1
			if (UseBerserkSkill==1) then
				BerserkMode=1
			end
			MyState = CHASE_ST
			OnCHASE_ST()
		else
			MyState = SKILL_OBJECT_CMD_ST
		end
	end
end


function	OnSKILL_AREA_CMD (level,skill,x,y)
	ResetCounters()
	TraceAI ("OnSKILL_AREA_CMD")
	targetx,targety=Closest(MyID,x,y,AttackRange(MyID,skill,level))
	Move (MyID,targetx,targety)
	MyDestX = x
	MyDestY = y
	MySkillLevel = level
	MySkill = skill
	MyState = SKILL_AREA_CMD_ST
	
end

function	OnFOLLOW_CMD ()
	ReturnToMoveHold = 0 
	if (MyState ~= FOLLOW_CMD_ST) then
		if StickyStandby > 0 then
			ShouldStandby=1
		end
		BetterMoveToOwner (MyID,FollowStayBack)
		MyState = FOLLOW_CMD_ST
		MyEnemy = 0 
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MySkill = 0
		TraceAI ("OnFOLLOW_CMD")
	else
		if StickyStandby > 0 then
			ShouldStandby=0
		end
		MyState = IDLE_ST
		MyEnemy = 0 
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MySkill = 0
		TraceAI ("FOLLOW_CMD_ST --> IDLE_ST")
	end

end




function	ProcessCommand (msg)

	if	(msg[1] == MOVE_CMD) then
		TraceAI ("MOVE_CMD")
		OnMOVE_CMD (msg[2],msg[3])
	elseif	(msg[1] == STOP_CMD) then
		TraceAI ("STOP_CMD")
		OnSTOP_CMD ()
	elseif	(msg[1] == ATTACK_OBJECT_CMD) then
		TraceAI ("ATTACK_OBJECT_CMD")
		OnATTACK_OBJECT_CMD (msg[2])
	elseif	(msg[1] == ATTACK_AREA_CMD) then
		TraceAI ("ATTACK_AREA_CMD")
		OnATTACK_AREA_CMD (msg[2],msg[3])
	elseif	(msg[1] == PATROL_CMD) then
		TraceAI ("PATROL_CMD")
		OnPATROL_CMD (msg[2],msg[3])
	elseif	(msg[1] == HOLD_CMD) then
		TraceAI ("HOLD_CMD")
		OnHOLD_CMD ()
	elseif	(msg[1] == SKILL_OBJECT_CMD) then
		TraceAI ("SKILL_OBJECT_CMD")
		OnSKILL_OBJECT_CMD (msg[2],msg[3],msg[4],msg[5])
	elseif	(msg[1] == SKILL_AREA_CMD) then
		TraceAI ("SKILL_AREA_CMD")
		OnSKILL_AREA_CMD (msg[2],msg[3],msg[4],msg[5])
	elseif	(msg[1] == FOLLOW_CMD) then
		TraceAI ("FOLLOW_CMD")
		OnFOLLOW_CMD ()
	end
end

function ResetCounters()
	MyPState				= 0
	MyPSkill				= 0
	MyPEnemy				= 0
	MyPSkillLevel			= 0
	MySkillUsedCount		= 0
	ChaseGiveUpCount		= 0
	AttackGiveUpCount		= 0
	ChaseDebuffUsed			= 0
	AttackDebuffUsed		= 0
	BypassKSProtect			= 0
	BerserkMode				= 0
	ReturnToState			= 0
	NewFriend				= 0
	FriendMotionTime		= 0
	FriendCircleIter		= 0
	FriendCircleTimeout		= 0
	AtkPosbugFixTimeout		= 0
	SkillObjectCMDTimeout	= 0
	FollowTryCount			= 0
	MyMoveX,MyMoveY			= 0,0
	if CastSkillMode < 0 then
		CastSkill=0
		CastSkillLevel=0
		CastSkillMode=0
	end
	return
end

--###############################
--######## State Process ########
--###############################


function	OnIDLE_ST ()
	--if ReturnToMoveHold~=0 then 
	--	MyState=MOVE_CMD_HOLD_ST
	--	OnMOVE_CMD_HOLD_ST()
	--	return
	--end
	TraceAI ("OnIDLE_ST")
	ResetCounters()
	MySkill					= 0
	MyDestX					= 0
	MyDestY					= 0
	MyEnemy					= 0
	if (DoIdleTasks()==nil) then
		return
	end
	--StickyStandby handling
	if (ShouldStandby==1 and StickyStandby > 0) then
		MyState=FOLLOW_CMD_ST
		return
	end
	--Targeting
	if SuperPassive~=1 then
		local	object = SelectEnemy(GetFriendTargets())
		if (object ~= 0) then							-- MYOWNER_ATTACKED_IN
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("IDLE_ST -> CHASE_ST : MYOWNER_ATTACKED_IN")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				OnCHASE_ST()
			end
			return 
		end
		if (HPPercent(MyID) > AggroHP and (SPPercent(MyID) > AggroSP or AggroSP==0) and (ShouldStandby == 0 or StickyStandby ==0) ) then
			aggro=1
		else
			aggro=0
		end
		object=SelectEnemy(GetEnemyList(MyID,aggro))
		if object~=0 then
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("IDLE_ST -> CHASE_ST : ATTACKED_IN")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				return OnCHASE_ST()
			end
			return	
		end
		if (aggro==1 and TankMonsterCount < TankMonsterLimit) then
			object = SelectEnemy(GetEnemyList(MyID,-1))
			if (object ~= 0) then
				MyState = TANKCHASE_ST
				MyEnemy = object
				TraceAI ("IDLE_ST -> TANKCHASE_ST")
				return
			end
		end
	end
	--Following
	local distance
	if ReturnToMoveHold ~=0 then
		distance = GetDistanceAP(MyID,StickyX,StickyY)
	else
		distance = GetDistanceFromOwner(MyID)
	end
	if (UseIdleWalk~=0 and HPPercent(MyID) > AggroHP and SPPercent(MyID) > math.max(AggroSP,IdleWalkSP)) then -- CHECK
		if ( distance > GetMoveBounds() or distance == -1) then		-- MYOWNER_OUTSIGNT_IN
			MyState = FOLLOW_ST
			TraceAI ("IDLE_ST -> FOLLOW_ST")
			return
		else 
			TraceAI("IDLE_ST -> IDLEWALK_ST, idle walk mode ="..UseIdleWalk)
			MyState=IDLEWALK_ST
		end
	elseif (( distance > DiagonalDist(FollowStayBack+1) and not (ChaseSPPause==1 and GetV(V_SP,MyID) < ChaseSPPauseSP and GetTick() - math.max(LastMovedTime,LastSPTime) > (5000-ChaseSPPauseTime)))or distance == -1) then		-- MYOWNER_OUTSIGNT_IN
		MyState = FOLLOW_ST
		TraceAI ("IDLE_ST -> FOLLOW_ST")
		return OnFOLLOW_ST()
	end	
	if UseAutoHeal==3 then
		if DoHealingTasks(MyID) == 1 then 
			return
		end
	end
	DoAutoBuffs(-2)
	if UseIdleWalk ~=0 and HPPercent(MyID) > AggroHP and SPPercent(MyID) > math.max(AggroSP,IdleWalkSP) then
		TraceAI("IDLE_ST -> IDLEWALK_ST, idle walk mode ="..UseIdleWalk)
		MyState=IDLEWALK_ST
	end
end

function	OnFOLLOW_ST ()

	TraceAI ("OnFOLLOW_ST - follow try count: "..FollowTryCount.." ownerpos: "..formatpos(GetV(V_POSITION,GetV(V_OWNER,MyID))).."my pos history:"..formatmypos(10))
	local dist = GetDistanceFromOwner(MyID)
	if dist > GetMoveBounds() then 
		ReturnToMoveHold = 0
		StickyX,StickyY=0,0
	end
	if ReturnToMoveHold ~=0 then
		dist = GetDistanceAP(MyID,StickyX,StickyY)
	end
	if (dist <= DiagonalDist(FollowStayBack+1)) then		--  DESTINATION_ARRIVED_IN 
		FollowTryCount=0
		MyState = IDLE_ST
		TraceAI ("FOLLOW_ST -> IDLE_ST ownerpos: "..formatpos(GetV(V_POSITION,GetV(V_OWNER,MyID))).."my pos history:"..formatmypos(10))
		if (FastChangeCount < FastChangeLimit and FastChange_F2I==1) then
			FastChangeCount = FastChangeCount+1
			return OnIDLE_ST()
		end
	else
		if (FollowTryCount > FollowTryPanic and GetV(V_MOTION,MyID)~=MOTION_MOVE) then
			if FollowTryCount > 2*FollowTryPanic then
				if FollowTryCount > 3*FollowTryPanic then 
					TraceAI("FOLLOW_ST -> IDLE_ST - Can't follow even using panic'ed methods - Giving up")
					MyState=IDLE_ST
					if (FastChangeCount < FastChangeLimit and FastChange_F2I==1) then
						FastChangeCount = FastChangeCount+1
						return OnIDLE_ST()
					end
				else
					if ReturnToMoveHold ==0 then
						MoveToOwner(MyID)
						FollowTryCount=FollowTryCount+1
						TraceAI("Emergency follow - MoveToOwner() called")
					else 
						TraceAI("FOLLOW_ST -> IDLE_ST - Can't get to move sticky location even using panic'ed methods - Giving up")
						MyState=IDLE_ST
						if (FastChangeCount < FastChangeLimit and FastChange_F2I==1) then
							FastChangeCount = FastChangeCount+1
							return OnIDLE_ST()
						end
					end
				end
			else
				FollowTryCount=FollowTryCount+1
				if ReturnToMoveHold==0 then
					BetterMoveToOwner (MyID,1)
				else
					BetterMoveToLoc(MyID,1,StickyX,StickyY)
				end
			end
		else
			local dx,dy
			if ReturnToMoveHold==0 then
				dx,dy=BetterMoveToOwnerXY(MyID,FollowStayBack)
			else
				dx,dy=BetterMoveToLocXY(MyID,FollowStayBack,StickyX,StickyY)
			end
			local mx,my=GetV(V_POSITION,MyID)
			--TraceAI("followobstacle dest"..formatpos(dx,dy).." pos "..formatpos(mx,my))
			if math.abs(my-dy) <=1 then
				--TraceAI("math.abs(my-dy) <=1")
				if math.abs(mx-dx) <=1 then --We could be in a bounce loop, better see if we are
					--TraceAI("math.abs(my-dy) <=1")
					if MyPosY[1]==my then
						for v=2,5,1 do
							if MyPosX[v]==dx then
								MoveToOwner(MyID)
								FollowTryCount=FollowTryCount+1
								TraceAI("Bounce loop detected, emergency measures taken")
								break
							end
							if v==5 then
								MyDestX,MyDestY=dx,dy
								Move(MyID,MyDestX,MyDestY)
							end
						end
					else
						MyDestX,MyDestY=dx,dy
						Move(MyID,MyDestX,MyDestY)
					end
				else
					--TraceAI("math.abs(mx-dx) > 1"..math.abs(mx-dx))
					MyDestX,MyDestY=dx,dy
					Move(MyID,MyDestX,MyDestY)
				end
			else
				--TraceAI("math.abs(my-dy) > 1"..math.abs(my-dy))
				MyDestX,MyDestY=dx,dy
				Move(MyID,MyDestX,MyDestY)
			end
			if (GetV(V_MOTION,MyID) ~= MOTION_MOVE) then
				FollowTryCount=FollowTryCount+1
			else
				FollowTryCount=0
			end
		end
		TraceAI ("FOLLOW_ST -> FOLLOW_ST ownerpos: "..formatpos(GetV(V_POSITION,GetV(V_OWNER,MyID))).."my pos history:"..formatmypos(10).."dest cell"..formatpos(MyDestX,MyDestY))
		return
	end
end


function	OnCHASE_ST ()
	MyAttackStanceX,MyAttackStanceY = 0,0
	TraceAI ("OnCHASE_ST")
	aggro = GetAggroCount()
	if(aggro > UseBerserkMobbed and UseBerserkMobbed > 0)then
		BerserkMode=1
	end	
	if DoAutoBuffs(-1) == 1 then
		DoAutoBuffs(2)
	end
	if (UseSkillOnly==1 and MySkill ~= 0) then
		skill,level=GetAtkSkill(MyID)
	else
		skill=nil
		level=nil
	end
	if true==IsOutOfSight(MyID,MyEnemy) then
		value="true "
	else
		value="false"
	end
	if(IsNotKS(MyID,MyEnemy)==0) then
		local reason=GetKSReason(MyID,MyEnemy)
		TraceAI ("CHASE_ST -> IDLE_ST : Enemy is taken "..reason)
		MyState = IDLE_ST
		MyEnemy = 0
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MyDestX, MyDestY = 0,0
		ChaseGiveUpCount=0
		if (FastChangeCount < FastChangeLimit and FastChange_C2I == 1) then
			FastChangeCount = FastChangeCount+1
			return OnIDLE_ST()
		end
	end
	if (true == IsOutOfSight(MyID,MyEnemy)) then	-- ENEMY_OUTSIGHT_IN
	
		MyState = IDLE_ST
		MyEnemy = 0
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MyDestX, MyDestY = 0,0
		TraceAI ("CHASE_ST -> IDLE_ST : Enemy out of sight")
		ChaseGiveUpCount=0
		
		if (FastChangeCount < FastChangeLimit and FastChange_C2I == 1) then
			FastChangeCount = FastChangeCount+1
			return OnIDLE_ST()
		else
			return
		end
	end
	if GetV(V_MOTION,MyID)~=MOTION_MOVE then
		if ChaseGiveUpCount > ChaseGiveUp then
			Unreachable[MyEnemy]=1
			if SelectEnemy(GetEnemyList(MyID,-2)) == MyEnemy then --Oh crap, 
				TraceAI("CHASE_ST -> FOLLOW_ST : Target "..MyEnemy.." marked unreachable but is also rescue target! Trying follow state in hopes of a clean line of attack from owner")
				MyState = FOLLOW_ST
				MyEnemy = 0
				EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
				EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
				MyDestX,MyDestY=0,0
		        ChaseGiveUpCount=0
				return OnFOLLOW_ST()
			elseif AllTargetUnreachable==1 then
				MyState = FOLLOW_ST
				MyDestX, MyDestY = 0,0
				TraceAI ("CHASE_ST -> FOLLOW_ST : All targets marked unreachable, and can't reach "..MyEnemy)
				ChaseGiveUpCount=0
				MyEnemy = 0
				EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
				EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
				return OnFOLLOW_ST()
			else 
				MyState = IDLE_ST
				MyDestX, MyDestY = 0,0
				TraceAI ("CHASE_ST -> IDLE_ST : Marking target "..MyEnemy.." unreachable")
				ChaseGiveUpCount=0
				MyEnemy = 0
				EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
				EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
				if (FastChangeCount < FastChangeLimit and FastChange_C2I == 1) then
					FastChangeCount = FastChangeCount+1
					return OnIDLE_ST()
				else
					return
				end
			end
		end
		ChaseGiveUpCount=ChaseGiveUpCount+1
	elseif MyEnemies[3]==MyEnemy and GetDistanceAPR(MyEnemy,MyPosX[3],MyPosY[3]) <= GetDistanceAR(MyID,MyEnemy) then
		ChaseGiveUpCount=ChaseGiveUpCount+1
		TraceAI("CHASE_ST: We're not getting any closer - we were "..GetDistanceAPR(MyEnemy,MyPosX[3],MyPosY[3]).." cells away 2 cycles ago, now "..GetDistanceAR(MyID,MyEnemy).." Increment ChaseGiveUpCount")
	end
	OnChaseStart()
	if OpportunisticTargeting ==1 and MySkill==0 and SuperPassive~=1 and IsRescueTarget(MyEnemy)==0 then
		if (HPPercent(MyID) > AggroHP and (SPPercent(MyID) > AggroSP or AggroSP==0) and (ShouldStandby == 0 or StickyStandby ==0)) then
			aggro=1
		else
			aggro=0
		end
		object=SelectEnemy(GetEnemyList(MyID,aggro),MyEnemy)
		if object ~= 0 then
			TraceAI("Opportunistic target change - dropping target "..MyEnemy.." for target "..object)
			MyEnemy=object	
			EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
			EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		end
	elseif ((MySkill==MH_TINDER_BREAKER or MySkill==MH_EQC or MySkill==MH_CBC) and EleanorMode==0) or ((MySkill==MH_SONIC_CRAW or MySkill==MH_SILVERVEIN_RUSH or MySkill==MH_MIDNIGHT_FRENZY) and EleanorMode==1) then
		if EleanorDoNotSwitchMode == 1 then 
			TraceAI("Was told to use "..FormatSkill(MySkill,MyLevel).." but am in wrong mode for it, and EleanorDoNotSwitchMode==1")
			logappend("AAI_ERROR","Was told to use "..FormatSkill(MySkill,MyLevel).." but am in wrong mode for it, and EleanorDoNotSwitchMode==1")
		else
			if AutoSkillTimeout < GetTick() then
				DoSkill(MH_STYLE_CHANGE,1,MyID,8)
			end
		end
	end
	if (true == IsInAttackSight(MyID,MyEnemy,skill,level)) then  -- ENEMY_INATTACKSIGHT_IN
		MyState = ATTACK_ST
		AttackTimeout=GetTick()+AttackTimeLimit
		ExChaseGiveUpCount=ChaseGiveUpCount
		ChaseGiveUpCount=0
		TraceAI ("CHASE_ST -> ATTACK_ST : ENEMY_INATTACKSIGHT_IN")
		if (FastChangeCount < FastChangeLimit and FastChange_C2A == 1) then
			FastChangeCount = FastChangeCount+1
			return OnATTACK_ST()
		else
			return
		end
	elseif UseSkillOnly == -1 and (GetTick() >= AutoSkillTimeout) then
		dist=GetDistanceA(MyID,MyEnemy)
		local tact_skill,tact_debuff,tact_sp,tact_skillclass=GetTact(TACT_SKILL,MyEnemy),GetTact(TACT_DEBUFF,MyEnemy),GetTact(TACT_SP,MyEnemy),GetTact(TACT_SKILLCLASS,MyEnemy)
		skilltouse={-1,0,0}
		local SkillList=GetTargetedSkills(MyID)
		local availsp = GetV(V_SP,MyID)
		if BerserkMode~=1 or Berserk_IgnoreMinSP ~=1 then
			availsp = availsp - tact_sp
		end
		TraceAI("Begin autoskill while chasing routine")
		if (tact_skill < 0) then		-- Negative value of TACT_SKILL -> 1 cast of skill
			skill_level=tact_skill*-1	-- with level = to the absolute value of the
			tact_skill=1			-- value of TACT_SKILL.
		else
			skill_level=11
		end
		for i,v in ipairs(SkillList) do

			skilltype=v[1]
			if v[2]~=0 then
				if IsInAttackSight(MyID,MyEnemy,v[2],v[3])==true then
					if (skilltype == MOB_ATK and UseHomunSSkillChase==1 and AutoMobMode~=0  and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1))) then
						local mobskill_level=skill_level
						if AoEFixedLevel == 1 then
							mobskill_level=v[3]
						end
						local mobmode=0
						if AutoMobMode==2 then
							mobmode=1
						end
						mobskillcount=GetMobCount(v[2],math.min(v[3],mobskill_level),MyEnemy,mobmode)
						--TraceAI("mobskillcount="..mobskillcount.."tact_skillclass="..tact_skillclass.."class_mob="..CLASS_MOB.."AutoMobCount="..AutoMobCount.." "..FormatSkill(v[2],math.min(v[3],mobskill_level)))
						if (mobskillcount >= AutoMobCount or tact_skillclass == CLASS_MOB) then
							if (availsp >= GetSkillInfo(v[2],3,math.min(v[3],mobskill_level)))then
								if (skilltouse[1] < 2) then
									skilltouse=v
								end
							end
						end
					elseif (skilltype ==DEBUFF_ATK and ChaseDebuffUsed==0) then
							if (tact_debuff*-1 == v[2] or (tact_debuff==-1 and BasicDebuffs[v[2]]~=nil)) then
								if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
									skilltouse=v
								end
							end
					elseif (skilltype==MAIN_ATK and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (tact_skillclass < 1 or tact_skillclass==CLASS_MIN_OLD )) then
						if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
							skilltouse=v
						end
					elseif (skilltype==S_ATK and UseHomunSSkillChase==1 and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (tact_skillclass==CLASS_S or tact_skillclass==CLASS_BOTH or tact_skillclass==CLASS_MIN_S or ((tact_skillclass==CLASS_COMBO_1 or tact_skillclass==CLASS_COMBO_2) and v[2]==MH_SONIC_CLAW))) then
						if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
							skilltouse=v
						end
					elseif (skilltype==COMBO_ATK and UseHomunSSkillChase==1 and (AutoComboMode==2 or (AutoComboMode==1 and (tact_skillclass == CLASS_COMBO_1 or tact_skillclass==CLASS_COMBO_2)) or Berserk_ComboAlways==1) and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (v[2] == MH_SILVERVEIN_RUSH or tact_skillclass~=CLASS_COMBO_1)) then
						if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
							skilltouse=v
						end
					elseif (skilltype==GRAPPLE_ATK and UseHomunSSkillChase==1 and (AutoComboMode==2 or (AutoComboMode==1 and tact_skillclass > 5) or Berserk_ComboAlways==1) and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (v[2] == MH_TINDER_BREAKER or (v[2]==MH_CBC and tact_skillclass~=CLASS_GRAPPLE) or tact_skillclass==CLASS_GRAPPLE_2 )) then
						if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
							skilltouse=v
						end
					elseif (skilltype==MINION_ATK and UseHomunSSkillChase==1 and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (tact_skillclass==CLASS_MINION or tact_skillclass==CLASS_MIN_OLD or tact_skillclass==CLASS_MIN_S)) then
						if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
							skilltouse=v
						end
					end
				end
			end
		end
		if skilltouse[2]~=0 then
			TraceAI("Using skill while chasing:"..skilltouse[2])
			local slvl=skilltouse[3]
			if skill_level~=11 and ( AoEFixedLevel ~= 1 or skilltouse[1]~=MOB_ATK) then
				slvl=skill_level
			end
			DoSkill(skilltouse[2],slvl,MyEnemy)
			if skilltouse[1] == DEBUFF_ATK then
				ChaseDebuffUsed=1
			end
			MySkillUsedCount=MySkillUsedCount+1
		end
	else
		TraceAI("Not in range, and can't use chase skill")
	end
	if (GetTact(TACT_CHASE,MyEnemy)~=1) then
		local alt = 0
		if (ChaseGiveUpCount >= 4 and MyPosX[1] == MyPosX[3]  and MyPosY[1]==MyPosY[3]) then
			alt=math.random(2)
			TraceAI("Using alt movement"..alt)
		end
		ex,ey=GetV(V_POSITION,MyEnemy)
		TraceAI("State History: "..MyStates[1].." "..MyStates[2].." "..MyStates[3].." "..MyStates[4].." "..MyStates[5])
		TraceAI("Pos History: "..formatpos(MyPosX[1],MyPosY[1]).." "..formatpos(MyPosX[2],MyPosY[2]).." "..formatpos(MyPosX[3],MyPosY[3]).." "..formatpos(MyPosX[4],MyPosY[4]).." "..formatpos(MyPosX[5],MyPosY[5]))
		TraceAI("Enemy History: "..MyEnemies[1].." "..MyEnemies[2].." "..MyEnemies[3].." "..MyEnemies[4].." "..MyEnemies[5])
		TraceAI("Enemy Pos History: "..formatpos(EnemyPosX[1],EnemyPosY[1]).." "..formatpos(EnemyPosX[2],EnemyPosY[2]).." "..formatpos(EnemyPosX[3],EnemyPosY[3]).." "..formatpos(EnemyPosX[4],EnemyPosY[4]).." "..formatpos(EnemyPosX[5],EnemyPosY[5]))
		TraceAI("current enemy: "..MyEnemy.." "..formatpos(ex,ey))
		if MyStates[1]==CHASE_ST and MyStates[2]==ATTACK_ST and MyStates[3]==CHASE_ST and MyEnemy==MyEnemies[2] and IsPlayer(MyEnemy)~=1 and EnemyPosX[3]==ex and EnemyPosY[3]==ey then
			x,y=AdjustOpp(x,y,ex,ey)
		    Unreachable[MyEnemy]=1
		    TraceAI("CHASE_ST: We transitioned to attack state vs this target 2 cycles ago, now we're chasing it again, and it hasn't moved! Trying to do AdjustOpp, and deprioritizing monster to prevent loop.")
		elseif EnemyPosX[3]~=0 and EnemyPosY[3]~=0 and (ex~=EnemyPosX[3] or ey~=EnemyPosY[3]) and MyEnemy==MyEnemies[3] and alt==0 then
			dx,dy = ex-EnemyPosX[3],ey-EnemyPosY[3]
			r=AttackRange(MyID,MySkill,MySkillLevel)
			x,y = Closest(MyID,ex+dx,ey+dy,r,alt)
			x,y = AdjustStandPoint(x,y,ex,ey,r,alt)
		else
			x,y = GetStandPoint(MyID,MyEnemy,MySkill,MySkillLevel,alt)
			if x==-1 or y==-1 then
				if AttackRange(MyID,MySkill,MySkillLevel) < 2 or alt > 0 then 
					MyState = IDLE_ST
					Unreachable[MyEnemy]=1
					MyEnemy = 0
					EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
					EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
					MyDestX, MyDestY = 0,0
					TraceAI ("CHASE_ST -> IDLE_ST : Cannot attack this target, GetStandPoint() reports that all cells around it are occupied.")
					ChaseGiveUpCount=0
					if (FastChangeCount < FastChangeLimit and FastChange_C2I == 1) then
						FastChangeCount = FastChangeCount+1
						return OnIDLE_ST()
					end
				else
					x,y = GetStandPoint(MyID,MyEnemy,MySkill,MySkillLevel,1)
					if x==-1 or y==-1 then
						MyState = IDLE_ST
						Unreachable[MyEnemy]=1
						MyEnemy = 0
						EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
						EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
						MyDestX, MyDestY = 0,0
						TraceAI ("CHASE_ST -> IDLE_ST : Cannot attack this target, GetStandPoint() can't get an unoccupied cell")
						ChaseGiveUpCount=0
						if (FastChangeCount < FastChangeLimit and FastChange_C2I == 1) then
							FastChangeCount = FastChangeCount+1
							return OnIDLE_ST()
						end
					end
				end
			end
		end
		ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
		if GetDistanceAPR(GetV(V_OWNER,MyID),x,y) < GetMoveBounds() then
			if ((x~=MyDestX or y~=MyDestY) or GetV(V_MOTION,MyID)~=MOTION_MOVE)  then
				MyDestX, MyDestY=x,y
				Move (MyID,MyDestX,MyDestY)
				TraceAI ("CHASE_ST -> CHASE_ST : DESTCHANGED_IN "..MyDestX..","..MyDestY.."mypos "..MyPosX[1]..","..MyPosY[1].."owner pos"..ox..","..oy.." enemypos "..ex..","..ey.." GetDistanceAPR="..GetDistanceAPR(GetV(V_OWNER,MyID),x,y))
			else
				TraceAI("CHASE_ST -> CHASE_ST : Destination not changed "..MyDestX..","..MyDestY.."mypos "..MyPosX[1]..","..MyPosY[1].."owner pos"..ox..","..oy.." enemypos "..ex..","..ey.." GetDistanceAPR="..GetDistanceAPR(GetV(V_OWNER,MyID),x,y))
			end
		else --if ChaseGiveUpCount > 4 then
			MyState = IDLE_ST
			Unreachable[MyEnemy]=1
			MyEnemy = 0
			EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
			EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
			MyDestX, MyDestY = 0,0
			TraceAI ("CHASE_ST -> IDLE_ST : Following enemy would exceed move bounds."..x..","..y.."mypos "..MyPosX[1]..","..MyPosY[1].."owner pos"..ox..","..oy.." enemypos "..ex..","..ey.." GetDistanceAPR="..GetDistanceAPR(GetV(V_OWNER,MyID),x,y))
			ChaseGiveUpCount=0
			if (FastChangeCount < FastChangeLimit and FastChange_C2I == 1) then
				FastChangeCount = FastChangeCount+1
				
				return OnIDLE_ST()
			end
		end
	end
	return
end




function OnATTACK_ST ()
	TraceAI ("OnATTACK_ST MyEnemy: "..MyEnemy.." MyPos "..formatpos(GetV(V_POSITION,MyID)).." ("..GetV(V_MOTION,MyID)..") enemypos "..formatpos(GetV(V_POSITION,MyEnemy)).." ("..GetV(V_MOTION,MyEnemy)..") MyTarget: "..GetV(V_TARGET,MyID))	
	if (true == IsOutOfSight(MyID,MyEnemy)) then -- first thing's first, if enemy is gone drop it. 
		MyState = IDLE_ST
		MyEnemy = 0
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MySkillUseCount= 0
		TraceAI ("ATTACK_ST -> IDLE_ST -- target gone")
		return OnIDLE_ST()
	end
	if (MOTION_DEAD == GetV(V_MOTION,MyEnemy)) then   -- Enemy dead? Okay we're done here - drop it. 
		MyState = IDLE_ST
		MyEnemy = 0
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MySkillUseCount= 0
		TraceAI ("ATTACK_ST -> IDLE_ST  Enemy dead")
		return OnIDLE_ST()
	end
	local mytarg=GetV(V_TARGET,MyID)
	if mytarg~=MyEnemy and MyStates[1]==ATTACK_ST then
		AttackGiveUpCount=AttackGiveUpCount+1
		if AttackGiveUpCount > 4 then --MyEnemies[3]==MyEnemy and MyStates[3]==ATTACK_ST and MyStates[2]==ATTACK_ST then
			local tx,ty=GetV(V_POSITION,MyEnemy)
			local x,y=GetV(V_POSITION,MyID)
			if AttackGiveUpCount < 7 then
				Move(MyID,tx,ty)
				TraceAI("ATTACK_ST: We've been attacking for 5 cycles, but we still haven't attacked! Something is wrong - Moving to monster cell")
			elseif AttackGiveUpCount < AttackGiveUp then 
				nx,ny=AdjustOpp(x,y,tx,ty)
				Move(MyID,tx,ty)
				TraceAI("ATTACK_ST: We've been attacking for 3 cycles, but we still haven't attacked! Something is wrong - Moving to adjust opposite")
			elseif AttackGiveUpCount > AttackGiveUp and MyEnemies[AttackGiveUp]==MyEnemy and MyStates[AttackGiveUp]==ATTACK_ST then
				MyState = IDLE_ST
				Unreachable[MyEnemy]=1
				MyEnemy = 0
				EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
				EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
				MySkillUseCount= 0
				TraceAI("ATTACK_ST -> IDLE_ST - We've been attacking for 5 cycles, tried moving around, and still haven't attacked it. Marking unreachable")
				return OnIDLE_ST()
			end
		end
	else --We have attacked it successfully
		if GetV(V_MOTION,MyEnemy)==MOTION_DAMAGE then
			local t=1
			for i,v in ipairs(GetActors()) do
				if v~=MyID then
					if GetV(V_TARGET,v)==MyEnemy then
						t=0
						break
					end
				end
			end
			if t==1 then
				AttackTimeout=GetTick()+AttackTimeLimit
				TraceAI("AttackTimeout Reset - we're clearly attacking successfully")
			end
		end
	end
	if (AttackTimeout < GetTick() and AttackTimeLimit > 0) then -- Attack time limit reached.
		MyState = FOLLOW_ST
		Unreachable[MyEnemy]=1
		MyEnemy = 0
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MySkillUseCount= 0
		TraceAI ("ATTACK_ST -> FOLLOW_ST -- attack timeout reached, so we're probably posbugged. Dropping target and returning to owner in the hope that that sorts it out")
		return OnFOLLOW_ST()
	end
	
	local aggro = GetAggroCount()
	if(aggro > UseBerserkMobbed and UseBerserkMobbed > 0)then
		BerserkMode=1
	end	
	DoAutoBuffs(2)
	local skill,level
	if UseSkillOnly==1 then
		skill,level=GetAtkSkill(MyID)
	elseif MySkill~=0 then
		skill,level=MySkill,MySkillLevel
	else 
		skill,level=nil,nil
	end
	if (false == IsInAttackSight(MyID,MyEnemy,skill,level)) then  -- Check if we can attack enemy, if not back to chase 
		ResetCounters()
		MyState=CHASE_ST
		TraceAI ("ATTACK_ST -> CHASE_ST  : ENEMY_OUTATTACKSIGHT_IN MyEnemy: "..MyEnemy.." distance to "..GetDistanceA(MyID,MyEnemy))
		if (FastChangeCount < FastChangeLimit and FastChange_A2C == 1) then
			FastChangeCount = FastChangeCount+1
			return OnCHASE_ST()
		end
	end
	if (MyAttackStanceX==0) then
		x,y=GetV(V_POSITION,MyID)
		MyAttackStanceX,MyAttackStanceY=x,y
		logappend("AAI_DANCE","Attack Stance set to "..MyDestX..","..MyDestY.." current pos: "..x..","..y)
	end
	if (UseAutoPushback > 0) then
		if DoAutoPushback(MyID)  == nil then
			return
		end
	end
	OnAttackStart()
	local tact_skill,tact_debuff,tact_sp,tact_skillclass=GetTact(TACT_SKILL,MyEnemy),GetTact(TACT_DEBUFF,MyEnemy),GetTact(TACT_SP,MyEnemy),GetTact(TACT_SKILLCLASS,MyEnemy)
	local skill_level
	
	--logappend("AAI_ATK","tact_skill set "..tact_skill)
	--if AutoMobMode==1 then 
	--	mskill,mlevel=GetMobSkill(MyID)
	--	mobcount=GetMobCount(mskill,mlevel,MyEnemy,1)
	--	--TraceAI("mskill/level "..FormatSkill(mskill,mlevel).." mobcount "..mobcount)
	--elseif AutoMobMode==2 then
	--	mskill,mlevel=GetMobSkill(MyID)
	--	mobcount=GetMobCount(mskill,mlevel,MyEnemy,0)
	--else
	--	mobcount=0
	--end
	--Sniping routine
	if (IsHomun(MyID)==1 and SuperPassive~=1 and BerserkMode==0 and (GetTick() >= AutoSkillTimeout) and aggro <= AutoMobCount and GetTact(TACT_SNIPE,MyEnemy)==SNIPE_OK and (ShouldStandby == 0 or StickyStandby ==0)) then
		target=SelectEnemy(GetEnemyList(MyID,2)) -- This actually checks range - I know it's ugly to do it there, skill range checks need to be done at that point so we can pick a low priority target thats in range, instead of a high priority one out of range. 
		if target ~=0 then
			snipeskill=0
			local snipe_tact_skillclass=GetTact(TACT_SKILLCLASS,target)
			if snipe_tact_skillclass == CLASS_MINION then
				snipeskill,snipelevel=GetMinionSkill(MyID)
			end
			if snipeskill==0 and (snipe_tact_skillclass == CLASS_S or snipe_tact_skillclass == CLASS_BOTH or snipe_tact_skillclass == CLASS_MIN_S) then
				snipeskill,snipelevel=GetSAtkSkill(MyID)
			end
			if snipeskill==0 and (snipe_tact_skillclass == CLASS_OLD or snipe_tact_skillclass == CLASS_BOTH or snipe_tact_skillclass == CLASS_MIN_OLD) then
				snipeskill,snipelevel=GetAtkSkill(MyID)
			end
			--TraceAI("snipe "..skill.." level"..level)
			if snipeskill ~=0 then
				slevel = GetTact(TACT_SKILL,target)
				if slevel < 0 then
					slevel=-1*slevel
					if slevel > snipelevel then
						slevel = snipelevel
					end
					if ((GetV(V_SP,MyID)-ReserveSP >= GetTact(TACT_SP,target)+GetSkillInfo(snipeskill,3,slevel))) then
						TraceAI("Snipe attack on "..target.." "..snipeskill.." "..slevel)
						DoSkill(snipeskill,slevel,target)
					end
				end
			end
		end
	end
	
	
	-- Begin skill selection routine
	skilltouse = {-1,0,0}
	-- First digit (1): -1 = no skill, 0 single target, 1 debuff, 2 mob
	-- Second digit (2): skill id
	-- Third digit (3): skill level
	
	if (1==1) then --non paniced attack
		if (MySkill==0 and UseAttackSkill == 1 and GetTick() >= AutoSkillTimeout) then	
			if (tact_skill < 0) then		-- Negative value of TACT_SKILL -> 1 cast of skill
				skill_level=tact_skill*-1	-- with level = to the absolute value of the
				tact_skill=1			-- value of TACT_SKILL.
			else
				skill_level=11
			end
			local SkillList=GetTargetedSkills(MyID)
			TraceAI("Begin autoskill routine")
			local availsp = GetV(V_SP,MyID)
			if BerserkMode~=1 or Berserk_IgnoreMinSP ~=1 then
				availsp = availsp - tact_sp
			end
			for i,v in ipairs(SkillList) do
				skilltype=v[1]
				TraceAI("skilltype ".. skilltype.." MySkillUsedCount "..MySkillUsedCount.." tact_skill ".. tact_skill.." tact_skillclass"..tact_skillclass.."v"..v[1].." "..v[2].." "..v[3])		
				if v[2]~=0 then
					if IsInAttackSight(MyID,MyEnemy,v[2],v[3])==true then
						if (skilltype == MOB_ATK and UseHomunSSkillAttack==1 and AutoMobMode~=0 and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1))) then
							local mobskill_level=skill_level
							if AoEFixedLevel == 1 then
								mobskill_level=v[3]
							end
							local mobmode=0
							if AutoMobMode==2 then
								mobmode=1
							end
							mobskillcount=GetMobCount(v[2],math.min(v[3],mobskill_level),MyEnemy,mobmode)
							--TraceAI("mobskillcount="..mobskillcount.."tact_skillclass="..tact_skillclass.."class_mob="..CLASS_MOB.."AutoMobCount="..AutoMobCount.." "..FormatSkill(v[2],math.min(v[3],mobskill_level)))
							if (mobskillcount >= AutoMobCount or tact_skillclass == CLASS_MOB) then
								if (availsp >= GetSkillInfo(v[2],3,math.min(v[3],mobskill_level)))then
									if (skilltouse[1] < 2) then
										skilltouse=v
									end
								end
							end
						elseif (skilltype ==DEBUFF_ATK and AttackDebuffUsed < AttackDebuffLimit and (IsFriendOrSelf(GetV(V_TARGET,MyEnemy))==1 or AttackDebuffWhenAttacked~=1)) then
							if (tact_debuff == v[2] or (tact_debuff==1 and BasicDebuffs[v[2]]~=nil)) then
								if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
									skilltouse=v
								end
							end
						elseif (skilltype==MAIN_ATK and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (tact_skillclass < 1 or tact_skillclass==CLASS_MIN_OLD )) then
							if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
								skilltouse=v
							end
						elseif (skilltype==S_ATK and UseHomunSSkillAttack==1 and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (tact_skillclass==CLASS_S or tact_skillclass==CLASS_BOTH or tact_skillclass==CLASS_MIN_S or ((tact_skillclass==CLASS_COMBO_1 or tact_skillclass==CLASS_COMBO_2) and v[2]==MH_SONIC_CLAW))) then
							if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
								skilltouse=v
							end
						elseif (skilltype==COMBO_ATK and UseHomunSSkillAttack==1 and (AutoComboMode==2 or (AutoComboMode==1 and (tact_skillclass == CLASS_COMBO_1 or tact_skillclass==CLASS_COMBO_2)) or Berserk_ComboAlways==1) and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (v[2] == MH_SILVERVEIN_RUSH or tact_skillclass~=CLASS_COMBO_1)) then
							if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
								skilltouse=v
							end
						elseif (skilltype==GRAPPLE_ATK and UseHomunSSkillAttack==1 and (AutoComboMode==2 or (AutoComboMode==1 and tact_skillclass > 5) or Berserk_ComboAlways==1) and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (v[2] == MH_TINDER_BREAKER or (v[2]==MH_CBC and tact_skillclass~=CLASS_GRAPPLE) or tact_skillclass==CLASS_GRAPPLE_2 )) then
							if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
								skilltouse=v
							end
						elseif (skilltype==MINION_ATK and UseHomunSSkillAttack==1 and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and (tact_skillclass==CLASS_MINION or tact_skillclass==CLASS_MIN_OLD or tact_skillclass==CLASS_MIN_S)) then
							if (availsp-ReserveSP >= GetSkillInfo(v[2],3,math.min(v[3],skill_level))) then
								skilltouse=v
							end
						end
					end
				end
				TraceAI("skill selected "..skilltouse[2])
			end
		end
		-- Now we finalize the selection
		if skilltouse[1]~= -1 then
			MySkill=skilltouse[2]
			if (IsHomun(MyID)==1 and skill_level~=11 and (skilltouse[1]~=MOB_ATK or AoEFixedLevel ~= 1)) then  	--no need to check what skill
				MySkillLevel=skill_level			--Only homuns can use non-max level
			else							--and they dont have any mob/debuffs
				MySkillLevel=skilltouse[3]
			end
			if (skilltouse[1] == DEBUFF_ATK) then
				AttackDebuffUsed=AttackDebuffUsed+1
			else
				MySkillUsedCount=MySkillUsedCount+1
			end
		end	
	end
	
	-- Now we resolve it
	
	--if (MySkill == 0) then
	if (UseSkillOnly ~= 1) then
		Attack (MyID,MyEnemy)
		TraceAI("Normal attack vs: "..MyEnemy)
		if GetV(V_HOMUNTYPE,MyID) == ELEANOR and (EleanorDoNotSwitchMode==1 and EleanorMode==-1) or EleanorMode==1  then
			MySpheres = math.max(math.min(10,MySpheres+1/SphereTrackFactor),0)
			UpdateTimeoutFile()
		end
	end
	-- else
	if (MySkill ~=0) then
		TraceAI("Skill Attack: "..MySkill.." target: "..MyEnemy.." level:"..MySkillLevel)
		SkillTarget=MyEnemy
		if (MySkill==MA_SHARPSHOOTING and AoEMaximizeTargets==1) then
			target,hitcount=GetBestFASTarget(MyID)
			TraceAI(target.." - "..hitcount)
			if hitcount > 0 and target~=-1 then
				SkillTarget=target
			elseif hitcount== 0 then
				MySkill=0
			end
			TraceAI("Skill Attack: "..MySkill.." (FAS) target: "..SkillTarget.." enemy: "..MyEnemy)			
		elseif (MySkill==ML_BRANDISH and AoEMaximizeTargets==1) then
			target=GetBestBrandishTarget(MyID)
			if target~=-1 then
				SkillTarget=target
			end
			TraceAI("Skill Attack: "..MySkill.." (brandish) target: "..SkillTarget.." enemy: "..MyEnemy)
		elseif (MySkill==MH_HAILAGE_STAR or MySkill==MS_BOWLING_BASH) and AoEMaximizeTargets==1 then 
			target=GetBestAoETarget(MyID,MySkill,MySkillLevel)
			if target~=-1 then
				SkillTarget=target
			end
			TraceAI("Skill Attack: "..MySkill.." (brandish) target: "..SkillTarget.." enemy: "..MyEnemy)
		elseif ((MySkill==MH_XENO_SLASHER or MySkill==MH_LAVA_SLIDE or MySkill==MA_SHOWER or MySkill==MH_POISON_MIST) and AoEMaximizeTargets==1) or  (MySkill==MH_VOLCANIC_ASH and AshMaximizeTargets==1) then
			targx,targy=GetBestAoECoord(MyID,MySkill,MySkillLevel)
			if targx~=-1 then
				SkillTargetX,SkillTargetY=targx,targy
			end
			TraceAI("Skill Attack: "..MySkill.." (brandish) target: "..SkillTarget.." enemy: "..MyEnemy)
		end
		if MySkill ~=0 then
			if GetV(V_HOMUNTYPE,MyID) == ELEANOR then
				MySpheres = math.max(math.min(10,MySpheres+1/SphereTrackFactor),0)
				UpdateTimeoutFile()
			end
			DoSkill(MySkill,MySkillLevel,SkillTarget,-1,SkillTargetX,SkillTargetY)
		end
	end
	if ((UseSkillOnly ~= 1 and UseDanceAttack==1 and GetV(V_SP,MyID) >= DanceMinSP) or (BerserkMode==1 and Berserk_Dance==1) or (panicmode==1 and Panic_UseDanceAttack==1 and HPPercent(MyID) > FleeHP)) and (IsHomun(MyID)==1 and MySkill==0) and GetDistanceRect(MyEnemy,GetV(V_OWNER,MyID)) < 13 then
		nx,ny=GetDanceCell(MyAttackStanceX,MyAttackStanceY,MyEnemy)
		if GetDistanceAPR(GetV(V_OWNER,MyID),nx,ny) >= GetMoveBounds() then
			logappend("AAI_DANCE","Dance attack canceled, too close to move bounds "..GetDistanceAPR(GetV(V_OWNER,MyID),nx,ny).." "..GetMoveBounds())
		else 
			logappend("AAI_DANCE","Dancing between "..MyAttackStanceX..","..MyAttackStanceY.." and "..nx..","..ny)
			Move(MyID,nx,ny)
			Attack(MyID,MyEnemy)
			Move(MyID,MyAttackStanceX,MyAttackStanceY)
		end
	end
	MySkill = 0
	MySkillLevel=0
end


-------------------
-- TANK ROUTINES --
-------------------

function	OnTANKCHASE_ST ()
	if (UseSkillOnly==1) then
		skill,level=GetAtkSkill(MyID)
	elseif (UseSkillOnly==-1) then
		skill,level=GetAtkSkill(MyID)
		if (GetV(V_SP,MyID)-GetTact(TACT_SP,MyEnemy) < GetSkillInfo(skill,3,level)) then
			skill,level,sp=nil,nil,nil
		end
	else
		skill,level,sp=nil,nil,nil
	end
	TraceAI ("OnTANKCHASE_ST")
	if (true == IsOutOfSight(MyID,MyEnemy) or (ChaseGiveUpCount > ChaseGiveUp and GetV(V_MOTION,MyID)~=MOTION_MOVE)) then	-- ENEMY_OUTSIGHT_IN
		if (ChaseGiveUpCount>ChaseGiveUp) then
			Unreachable[MyEnemy]=1
		end
		
		MyState = IDLE_ST
		MyEnemy = 0
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MyDestX, MyDestY = 0,0
		TraceAI ("TANKCHASE_ST -> IDLE_ST : ENEMY_OUTSIGHT_IN")
		ChaseGiveUpCount=0
		
		return
	end
	if (true == IsInAttackSight(MyID,MyEnemy)) then  -- ENEMY_INATTACKSIGHT_IN
		ChaseGiveUpCount=0
		if(IsNotKS(MyID,MyEnemy)==1) then
			MyState = TANK_ST
			MySkillUsedCount=0
			TraceAI ("TANKCHASE_ST -> TANK_ST : ENEMY_INATTACKSIGHT_IN")
			return OnTANK_ST()
		else
			MyState = IDLE_ST
			MyEnemy = 0
			EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
			EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
			MyDestX, MyDestY = 0,0
			TraceAI ("TANKCHASE_ST -> IDLE_ST : Enemy is taken")
		end
		
		return
	end
	TraceAI("Tank chase: Can we skill while chasing?")
	if UseSkillOnly == -1 and (GetTick() >= AutoSkillTimeout) then
		dist=GetDistanceA(MyID,MyEnemy)
		tact_debuff,tact_skill,tact_sp,tact_skillclass=GetTact(TACT_DEBUFF,MyEnemy),GetTact(TACT_SKILL,MyEnemy),GetTact(TACT_SP,MyEnemy),GetTact(TACT_SKILLCLASS,MyEnemy)
		skilltouse={-1,0,0}
		local SkillList=GetTargetedSkills(MyID)
		TraceAI("Begin autoskill while tank chasing routine")
		if (tact_skill < 0) then		-- Negative value of TACT_SKILL -> 1 cast of skill
			skill_level=tact_skill*-1	-- with level = to the absolute value of the
			tact_skill=1			-- value of TACT_SKILL.
		else
			skill_level=11
		end
		for i,v in ipairs(SkillList) do

			skilltype=v[1]
			if v[2]~=0 then
				--logappend("AAI_Chase","skilltype ".. skilltype.." MySkillUsedCount "..MySkillUsedCount.." tact_skill ".. tact_skill.." tact_skillclass ".. tact_skillclass.."v"..v[1].." "..v[2].." "..v[3])
				if (GetV(V_SP,MyID) >= tact_sp+GetSkillInfo(v[2],3,math.min(v[3],skill_level)) and GetSkillInfo(v[2],2,math.min(v[3],skill_level)) >= dist) then 
				--TraceAI("skilltype ".. skilltype.." MySkillUsedCount "..MySkillUsedCount.." tact_skill ".. tact_skill.."v"..v[1].." "..v[2].." "..v[3])
					if (skilltype == MOB_ATK and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1))) then
						if (tact_skillclass == CLASS_MOB) then
							if (skilltouse[1] < 2) then
								skilltouse=v
							end
						end
					elseif (skilltype ==DEBUFF_ATK and ChaseDebuffUsed==0) then
						if (tact_debuff*-1 == v[2] or (tact_debuff==1 and BasicDebuffs[v[2]]~=nil)) then
							skilltouse=v
						end
					elseif (skilltype==MAIN_ATK and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and tact_skillclass~=CLASS_S) then
						skilltouse=v
					elseif (skilltype==S_ATK and UseHomunSSkillChase==1 and (MySkillUsedCount < tact_skill or tact_skill==SKILL_ALWAYS or (BerserkMode==1 and Berserk_SkillAlways==1)) and tact_skillclass~=CLASS_OLD) then
						skilltouse=v
					end
				end
			end
		end
		if skilltouse[2]~=0 then
			TraceAI("Using skill while tank chasing:"..skilltouse[2])
			local slvl=skilltouse[3]
			if skill_level~=11 then
				slvl=skill_level
			end
			DoSkill(skilltouse[2],slvl,MyEnemy,-1)
			if skilltouse[1] == DEBUFF_ATK then
				ChaseDebuffUsed=1
			end
			MySkillUsedCount=MySkillUsedCount+1
		end
	else
		TraceAI("Not in range, and can't use chase skill")
	end
	ChaseGiveUpCount=ChaseGiveUpCount+1
	MyDestX, MyDestY =  GetStandPoint(MyID,MyEnemy,MySkill,MySkillLevel,alt)
	if MyDestX==-1 or MyDestY==1 then
		Unreachable[MyEnemy]=1
		MyState = IDLE_ST
		MyEnemy = 0
		EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
		EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		MyDestX, MyDestY = 0,0
		TraceAI ("TANKCHASE_ST -> IDLE_ST : target is surrounded so GetStandPoint can't find valid cell. Target dropped and deprioritized")
		ChaseGiveUpCount=0
	end
	if (GetTact(TACT_CHASE,MyEnemy)~=1) then
		Move (MyID,MyDestX,MyDestY)
		TraceAI ("TANKCHASE_ST -> TANKCHASE_ST : DESTCHANGED_IN"..MyDestX.." "..MyDestY)
	end
	return
end 

function OnTANK_ST()
	if (GetV(V_MOTION,MyEnemy)==MOTION_DEAD or IsOutOfSight(MyID,MyEnemy)) then
		MyState=IDLE_ST
		TraceAI("TANK_ST->IDLE_ST - Target dead or out of sight")
		return
	end
	if (GetV(V_TARGET,MyEnemy)~=MyID and (TankHitTimeout + 2500) < GetTick()) then
		if (IsInAttackSight(MyID,MyEnemy)==true) then
			Attack(MyID,MyEnemy)
			TankHitTimeout = GetTick()
		else
			MyState=TANKCHASE_ST
			TraceAI("TANK_ST->TANKCHASE_ST - Target out of range")
		end
		return
	end
	if GetV(V_TARGET,MyEnemy)==MyID then
		TraceAI("TANK_ST->IDLE_ST - Target is tanked successfully")
		MyState=IDLE_ST
	end
end

--------------------
--- REST ROUTINE ---
--------------------
function	OnREST_ST ()
	TraceAI("OnREST_ST")
	if (DoIdleTasks()==nil) then
		return
	end
	if SuperPassive~=1 then
		local	object = SelectEnemy(GetFriendTargets())
		if (object ~= 0) then		--Check for monsters attacking owner
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("REST_ST -> CHASE_ST : MYOWNER_ATTACKED_IN")
			return 
		end
		object = SelectEnemy(GetEnemyList(MyID,0))	
		if (object ~= 0) then
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("REST_ST -> CHASE_ST : ATTACKED_IN")
			return
		end
	end
	
	--If theres nothing else to do, return to the "rest station"
	
	x,y=GetV(V_POSITION,MyID)
	ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
	xoff=x-ox
	yoff=y-oy
	TraceAI(xoff.." "..ox.." "..x)
	if (GetV(V_MOTION,GetV(V_OWNER,MyID))~=MOTION_SIT) then
		MyState=IDLE_ST
		TraceAI("REST_ST -> IDLE_ST: Owner stood up")
	elseif (xoff~=RestXOff or yoff~=RestYOff) then
		MyDestX=ox+RestXOff
		MyDestY=oy+RestYOff
		TraceAI("REST_ST -> REST_ST: moving from "..formatpos(x,y).." to "..formatpos(MyDestX,MyDestY))
		Move(MyID,MyDestX,MyDestY)
	else
		TraceAI("REST_ST -> REST_ST: At rest station")
	end
end

-----------------------------
---Friend motion routines ---
-----------------------------
function	OnFRIEND_CIRCLE_ST()
	x,y = GetV(V_POSITION,MyID)
	dist = GetDistance(x,y,NewFriendX,NewFriendY)
	TraceAI("OnFRIEND_CIRCLE_ST"..x..","..y.." "..dist) 
	if FriendCircleIter == 0 then
		if dist > 2 then
			Move(MyID,NewFriendX,NewFriendY)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout > 16 then
				MyState=IDLE_ST
				TraceAI("Dropping circle attempt, timeout exceeded")
			end
			return
		else
			FriendCircleIter=1
		end
	end
	if FriendCircleIter ==1 then
		if x==NewFriendX and y==NewFriendY-2 then
			FriendCircleIter=2
			FriendCircleTimeout=0
		else 
		 	Move(MyID,NewFriendX,NewFriendY-2)
		 	FriendCircleTimeout=FriendCircleTimeout+1
		 	if FriendCircleTimeout>4 then
		 		FriendCircleIter=2
				FriendCircleTimeout=0
		 		TraceAI("giving up on circle step 1")	
		 	end
		 	return
		end
	end
	if FriendCircleIter ==2 then
		if x==NewFriendX-2 and y==NewFriendY then
			FriendCircleIter=3
			FriendCircleTimeout=0
		else 
		 	Move(MyID,NewFriendX-2,NewFriendY)
		 	FriendCircleTimeout=FriendCircleTimeout+1
		 	if FriendCircleTimeout>4 then
		 		FriendCircleIter=3
				FriendCircleTimeout=0
		 		TraceAI("giving up on circle step 2")	
		 	end
		 	return
		end
	end
	if FriendCircleIter ==3 then
		if x==NewFriendX and y==NewFriendY+2 then
			FriendCircleIter=4
			FriendCircleTimeout=0
		else 
			Move(MyID,NewFriendX,NewFriendY+2)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout>4 then
				FriendCircleIter=4
				FriendCircleTimeout=0
				TraceAI("giving up on circle step 3")	
			end
			return
		end
	end
	if FriendCircleIter ==4 then
		if x==NewFriendX+2 and y==NewFriendY then
			FriendCircleIter=5
			FriendCircleTimeout=0
		else 
			Move(MyID,NewFriendX+2,NewFriendY)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout>4 then
				FriendCircleIter=5
				FriendCircleTimeout=0
				TraceAI("giving up on circle step 4")	
			end
			return
		end
	end
	if FriendCircleIter == 5 then
		if x==NewFriendX and y==NewFriendY-2 then
			FriendCircleIter=0
			FriendCircleTimeout=0
			MyState=IDLE_ST
			TraceAI("Circle completed")
			return
		else 
			Move(MyID,NewFriendX,NewFriendY-2)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout>4 then
				FriendCircleIter=0
				FriendCircleTimeout=0
				MyState=IDLE_ST
				TraceAI("giving up on circle step 5")	
			end
			return
		end
	end
end

function	OnFRIEND_CROSS_ST()
	x,y = GetV(V_POSITION,MyID)
	dist = GetDistance(x,y,NewFriendX,NewFriendY)
	TraceAI("OnFRIEND_CROSS_ST"..x..","..y.." "..dist) 
	if FriendCircleIter == 0 then
		if dist > 2 then
			Move(MyID,NewFriendX,NewFriendY)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout > 16 then
				MyState=IDLE_ST
				TraceAI("Dropping cross attempt, timeout exceeded")
			end
			return
		else
			FriendCircleIter=1
		end
	end
	if FriendCircleIter ==1 then
		if x==NewFriendX-2 and y==NewFriendY then
			FriendCircleIter=2
			FriendCircleTimeout=0
		else 
		 	Move(MyID,NewFriendX-2,NewFriendY)
		 	FriendCircleTimeout=FriendCircleTimeout+1
		 	if FriendCircleTimeout>4 then
		 		FriendCircleIter=2
				FriendCircleTimeout=0
		 		TraceAI("giving up on cross step 1")	
		 	end
		 	return
		end
	end
	if FriendCircleIter ==2 then
		if x==NewFriendX+2 and y==NewFriendY then
			FriendCircleIter=3
			FriendCircleTimeout=0
		else 
		 	Move(MyID,NewFriendX+2,NewFriendY)
		 	FriendCircleTimeout=FriendCircleTimeout+1
		 	if FriendCircleTimeout>4 then
		 		FriendCircleIter=3
				FriendCircleTimeout=0
		 		TraceAI("giving up on cross step 2")	
		 	end
		 	return
		end
	end
	if FriendCircleIter ==3 then
		if x==NewFriendX-2 and y==NewFriendY then
			FriendCircleIter=4
			FriendCircleTimeout=0
		else 
			Move(MyID,NewFriendX-2,NewFriendY)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout>4 then
				FriendCircleIter=4
				FriendCircleTimeout=0
				TraceAI("giving up on cross step 3")	
			end
			return
		end
	end
	if FriendCircleIter ==4 then
		if x==NewFriendX+2 and y==NewFriendY then
			FriendCircleIter=5
			FriendCircleTimeout=0
		else 
			Move(MyID,NewFriendX+2,NewFriendY)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout>4 then
				FriendCircleIter=5
				FriendCircleTimeout=0
				TraceAI("giving up on cross step 4")	
			end
			return
		end
	end
	if FriendCircleIter == 5 then
		if x==NewFriendX-2 and y==NewFriendY then
			FriendCircleIter=0
			FriendCircleTimeout=0
			MyState=IDLE_ST
			TraceAI("Circle completed")
			return
		else 
			Move(MyID,NewFriendX-2,NewFriendY)
			FriendCircleTimeout=FriendCircleTimeout+1
			if FriendCircleTimeout>4 then
				FriendCircleIter=0
				FriendCircleTimeout=0
				MyState=IDLE_ST
				TraceAI("giving up on cross step 5")	
			end
			return
		end
	end
end

-------------------
--Command State Process
-------------------

function	OnMOVE_CMD_ST ()

	TraceAI ("OnMOVE_CMD_ST")
	if GetDistanceAPR(GetV(V_OWNER,MyID),MyMoveX,MyMoveY) > 15 then
		TraceAI("OnMOVE_CMD_ST -> IDLE_ST: Attempt to move to location off screen")
		logappend("AAI_ERROR","We were in MOVE_CMD_ST trying to move to "..formatpos(MyMoveX,MyMoveY).." while owner standing at "..formatpos(GetV(V_POSITION,GetV(V_OWNER,MyID))))
		MyState=IDLE_ST
		return OnIDLE_ST()
	end
	local x, y = GetV (V_POSITION,MyID)
	if (x == MyMoveX and y == MyMoveY) then	
		StickyX,StickyY=0,0
		if (MoveSticky ~= 0) then
			if (ReturnToMoveHold==0) then
				ReturnToMoveHold = 1
				StickyX,StickyY=x,y
			else 
				ReturnToMoveHold = 0
			end
		end
		TraceAI("OnMOVE_CMD_ST -> IDLE_ST: Arrived at Destination "..formatpos(x,y))
		MyState=IDLE_ST
		return OnIDLE_ST()
	elseif GetV(V_MOTION,MyID) == MOTION_STAND or MyDestX~=MyMoveX or MyDestY~=MyMoveY then
		MyDestX,MyDestY=MyMoveX,MyMoveY
		Move(MyID,MyDestX,MyDestY)
	end
end

function	OnMOVE_CMD_HOLD_ST ()
	
	TraceAI ("OnMOVE_CMD_HOLD_ST")
	MySkillUsedCount		= 0
	ChaseGiveUpCount		= 0
	AttackGiveUpCount		= 0
	ChaseDebuffUsed			= 0
	AttackDebuffUsed		= 0
	BypassKSProtect			= 0
	BerserkMode			= 0
	if (DoIdleTasks()==nil) then
		return
	end
	if (MoveStickyFight==1 and SuperPassive~=1 ) then
		local	object = SelectEnemy(GetFriendTargets())
		if (object ~= 0) then							-- MYOWNER_ATTACKED_IN
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("MOVE_CMD_HOLD_ST -> CHASE_ST : MYOWNER_ATTACKED_IN")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				OnCHASE_ST()
			end
			return 
		end
		object = SelectEnemy(GetEnemyList(MyID,0))
		if (object ~= 0) then							-- ATTACKED_IN
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("MOVE_CMD_HOLD_ST -> CHASE_ST : ATTACKED_IN")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				OnCHASE_ST()
			end
			return
		end
		object = SelectEnemy(GetEnemyList(MyID,-1))
		if (object ~= 0) then
			MyState = TANKCHASE_ST
			MyEnemy = object
			TraceAI ("MOVE_CMD_HOLD_ST -> TANKCHASE_ST")
			return
		end
	end
end


function OnSTOP_CMD_ST ()


end




function OnATTACK_OBJECT_CMD_ST ()

	

end


function OnATTACK_AREA_CMD_ST ()

	TraceAI ("OnATTACK_AREA_CMD_ST")

	local	object = GetOwnerEnemy (MyID)
	if (object == 0) then							
		object = GetMyEnemy (MyID) 
	end

	if (object ~= 0) then							-- MYOWNER_ATTACKED_IN or ATTACKED_IN
		MyState = CHASE_ST
		MyEnemy = object
		return
	end

	local x , y = GetV (V_POSITION,MyID)
	if (x == MyDestX and y == MyDestY) then			-- DESTARRIVED_IN
			MyState = IDLE_ST
	end

end




function OnPATROL_CMD_ST ()

	TraceAI ("OnPATROL_CMD_ST")

	local	object = GetOwnerEnemy (MyID)
	if (object == 0) then							
		object = GetMyEnemy (MyID) 
	end

	if (object ~= 0) then							-- MYOWNER_ATTACKED_IN or ATTACKED_IN
		MyState = CHASE_ST
		MyEnemy = object
		TraceAI ("PATROL_CMD_ST -> CHASE_ST : ATTACKED_IN")
		return
	end

	local x , y = GetV (V_POSITION,MyID)
	if (x == MyDestX and y == MyDestY) then			-- DESTARRIVED_IN
		MyDestX = MyPatrolX
		MyDestY = MyPatrolY
		MyPatrolX = x
		MyPatrolY = y
		Move (MyID,MyDestX,MyDestY)
	end

end


-----------------------------------------------------------------------
--IF ANYONE READING MY CODE HAS A FUCK'S CLUE WHAT THE HOLD COMMAND IS
--OR WHAT IN THE DEVIL IT'S PURPOSE IS, PLEASE ENLIGHTEN ME! -Azzy 
----------------------------------------------------------------------

function OnHOLD_CMD_ST () 

	TraceAI ("OnHOLD_CMD_ST")
	logappend("AAI_ERROR","We're in HOLD_CMD_ST - where did hold cmd come from?")
	if (MyEnemy ~= 0) then
		local d = GetDistance(MyEnemy,MyID)
		if (d ~= -1 and d <= GetV(V_ATTACKRANGE,MyID)) then
				Attack (MyID,MyEnemy)
		else
			MyEnemy = 0
			EnemyPosX = {0,0,0,0,0,0,0,0,0,0}
			EnemyPosY = {0,0,0,0,0,0,0,0,0,0}
		end
		return
	end


	local	object = GetOwnerEnemy (MyID)
	if (object == 0) then							
		object = GetMyEnemy (MyID)
		if (object == 0) then						
			return
		end
	end

	MyEnemy = object

end




function OnSKILL_OBJECT_CMD_ST ()
	if IsInAttackSight(MyID,MyEnemy,MySkill,MySkillLevel) then
		DoSkill(MySkill,MySkillLevel,MyEnemy)
		TraceAI("SKILL_OBJECT_CMD_ST --> IDLE_ST - skill used")
		MyState=IDLE_ST
		MyDestX,MyDestY,MyEnemy,MySkill,MySkillLevel=0,0,0,0,0
		return
	elseif IsOutOfSight(MyID,MyEnemy) then
		TraceAI("SKILL_OBJECT_CMD_ST --> IDLE_ST - target off screen")
		MyState=IDLE_ST
		MyDestX,MyDestY,MyEnemy,MySkill,MySkillLevel=0,0,0,0,0
	elseif SkillObjectCMDTimeout>SkillObjectCMDLimit then
		TraceAI("SKILL_OBJECT_CMD_ST --> IDLE_ST - Couldn't get into range to use skill "..MySkill.." on "..MyEnemy)
		MyState=IDLE_ST
		MyDestX,MyDestY,MyEnemy,MySkill,MySkillLevel=0,0,0,0,0
		return OnIDLE_ST()
	else
		x,y= GetStandPoint(MyID,MyEnemy,MySkill,MySkillLevel,alt)
		if x < 10 and y < 10 then
			local ex,ey=GetV(V_POSITION,MyEnemy)
			local hx,hy=GetV(V_POSITION,MyID)
			local ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
			logappend("AAI_ERROR","Anomalous move in progress: h "..formatpos(hx,hy).." "..formatmotion(GetV(V_MOTION,MyID)).." e "..formatpos(ex,ey).." "..formatmotion(GetV(V_MOTION,MyEnemy)).." o "..formatpos(ox,oy).." "..formatmotion(GetV(V_MOTION,GetV(V_OWNER,MyID))).." dest "..formatpos(x,y))
		end
		Move(MyID,x,y)
		SkillObjectCMDTimeout=SkillObjectCMDTimeout+1
		return
	end
	
	
end




function OnSKILL_AREA_CMD_ST ()

	TraceAI ("OnSKILL_AREA_CMD_ST")

	local x , y = GetV (V_POSITION,MyID)
	if (GetDistance(x,y,MyDestX,MyDestY) <= AttackRange(MyID,MySkill,MySkillLevel)) then	-- DESTARRIVED_IN
		DoSkill(MySkill,MySkillLevel,0,nil,MyDestX,MyDestY)
		MyState = IDLE_ST
		MySkill = 0
	else
		targetx,targety=Closest(MyID,MyDestX,MyDestY,AttackRange(MyID,MySkill,MySkillLevel))
		TraceAI("Moving to "..formatpos(targetx,targety).." from "..formatpos(x,y))
		if GetDistanceAPR(GetV(V_OWNER,MyID),targetx,targety) > GetMoveBounds() then
			MyState = IDLE_ST
			MySkill = 0
			TraceAI("OnSKILL_AREA_CMD_ST -> IDLE_ST Target out of range")
		else
			Move (MyID,targetx,targety)
		end
	end

end







function OnFOLLOW_CMD_ST ()
	TraceAI ("OnFOLLOW_CMD_ST")
	local d = GetDistanceA (GetV(V_OWNER,MyID),MyID)
	if ( d > FollowStayBack) then
		BetterMoveToOwner (MyID,FollowStayBack)
		return
	end
	-- Start the friending process
	if (StandbyFriending == 1) then
		local actors = GetActors()
		for i,v in ipairs(actors) do
			if (IsMonster(v)~=1 and GetV(V_MOTION,GetV(V_OWNER,MyID))==MOTION_SIT) then
				TraceAI("Friend list modification")
				if (IsToRight(GetV(V_OWNER,MyID),v)==1) then
					if (MyFriends[v]==nil) then
						MyFriends[v] = 1
						UpdateFriends()
						MyState=FRIEND_CIRCLE_ST
						ReturnToState=FOLLOW_CMD_ST
						NewFriendX,NewFriendY=GetV(V_POSITION,v)
					end
				elseif (IsToRight(v,GetV(V_OWNER,MyID))==1) then
					if (MyFriends[v]~=nil) then
						MyFriends[v] = nil
						UpdateFriends()
						MyState=FRIEND_CROSS_ST
						ReturnToState=FOLLOW_CMD_ST
						NewFriendX,NewFriendY=GetV(V_POSITION,v)
					end
				end
			end
		end
	end
	-- Okay, that's done. 
	if (DefendStandby == 1 and SuperPassive~=1) then
		local	object = SelectEnemy(GetFriendTargets())
		if (object ~= 0) then							-- MYOWNER_ATTACKED_IN
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("FOLLOW_CMD_ST -> CHASE_ST : MYOWNER_ATTACKED_IN")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				OnCHASE_ST()
			end
			return 
		end
		object = SelectEnemy(GetEnemyList(MyID,0))
		if (object ~= 0) then							-- ATTACKED_IN
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("FOLLOW_CMD_ST -> CHASE_ST : ATTACKED_IN ")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				OnCHASE_ST()
			end
			return
		end
	end
end


--#####################################
--### Targeting Routines start here ###
--#####################################
--[[
targets[actorid]=

MotionClass
-1 = Dead
0  = Stand
1  = Moving
2  = Flinch
3  = Attacking
4  = Skilling
5  = Casting
6  = Other

TargetClass
-2  = Non-friend player
-1  = Monster
0  = None
1  = Self
2  = Friend/Owner
]]--]]

function GetFriendTargets() -- returns list of targets of friends who are attacking
	local targets = {}
	for i,v in ipairs (GetActors()) do
		if (IsFriend(v) == 1) then
			motion=GetV(V_MOTION,v)
			target=GetV(V_TARGET,v)
			if (IsMonster(target)==1) then
				tact=GetTact(TACT_BASIC,target)
				if (FriendAttack[motion]==1 and tact > 0 and tact ~=9) then
					targets[target]={MotionClassLU[GetV(V_MOTION,target)],GetTargetClass(target),GetTact(TACT_BASIC,target),GetTact(TACT_CAST,target)}
					
				end
			end
		end
	end
	return targets
end
-- aggro arguments
-- 2 = snipe
-- 1 = aggro
-- 0 = nonaggro
-- -1 = tank
-- -2 = rescue


function	GetEnemyList (myid,aggro)
	local owner  = GetV(V_OWNER,myid)
	local enemys = {}
	if aggro==2 then
		sskill,slevel=GetSAtkSkill(MyID)
		oskill,olevel=GetAtkSkill(MyID)
		mskill,mlevel=GetMinionSkill(MyID)
	end
	TraceAI("GetEnemyList with aggro "..aggro)
	for k,v in pairs(Targets) do
		tact = GetTact(TACT_BASIC,k)
		casttact=GetTact(TACT_CAST,k)
		if tact==TACT_TANKMOB then
			if GetAggroCount() > AutoMobCount then
				tact = TACT_ATTACK_M
			else
				tact = TACT_TANK
			end
		end
		--TraceAI("Target"..k.." tact:"..tact.." Motion"..v[1].." TClass"..v[2])
		if (0 < tact and (tact < 5 or tact >9) and aggro==1 and (DoNotAttackMoving ~=1 or v[1]~=1) and (tact ~= 14 or AttackLastFullSP==0 or SPPercent(MyID)==100)) or  (tact > 9 and tact < 13 and aggro == 2 and k~=MyEnemy) or  (v[2]>0 and tact>0 and (tact~=9 or v[2]==1) and (v[1]==3 or casttact >= CAST_REACT) and aggro~=2 and (aggro > -1 or (aggro==-2 and IsRescueTarget(k)==1))) or (tact == -1 and aggro==-1 and v[2]~=1) then
			--TraceAI("Tactics say to attack:"..k)
			if (IsNotKS(myid,k)==1 and v[1] > -1) then
				--TraceAI("Is alive and not a KS")
				if aggro == 0 or (aggro~=2 and v[2]>0) then 
					if (GetMoveBounds() >= GetDistanceRect(owner,k)) then
						--TraceAI("Adding to target list: "..k)
						r={v[1],v[2],tact,casttact}
						enemys[k] = r
					--else 
					--	tempx,tempy=GetV(V_POSITION,owner)
					--	targx,targy=GetV(V_POSITION,k)
					--	TraceAI("target ignored "..k.." mypos "..tempx..","..tempy.." enemy "..targx..","..targy.." bounds "..GetMoveBounds().."dist "..GetDistanceRect(owner,k))
					end
				elseif aggro~=2 then
					if (GetAggroDist() >= GetDistanceA(owner,k)) then
						TraceAI("Adding to target list: "..k)
						r={v[1],v[2],tact,casttact}
						enemys[k] = r
					end
				else -- Sniping - so we need to check range on skill, instead of aggrodist
					dist = GetDistanceA(MyID,k)
					tact_skill_class=(GetTact(TACT_SKILLCLASS,k))
					if tact_skill_class==CLASS_MINION and mskill~=0 then
						if dist <= GetSkillInfo(mskill,2,mlevel) then
							r={v[1],v[2],tact,casttact}
							enemys[k] = r
						end
					elseif sskill~=0 and tact_skill_class~=CLASS_OLD then
						if dist <= GetSkillInfo(sskill,2,slevel) then
							r={v[1],v[2],tact,casttact}
							enemys[k] = r
						end
					elseif oskill~=0 and tact_skill_class~=CLASS_S then
						if dist <= GetSkillInfo(oskill,2,olevel) then
							r={v[1],v[2],tact,casttact}
							enemys[k] = r
						end
					end
				end
			end
		end
	end
	return enemys
end

-- format of return
-- enemys[n][1] = Motion Class
-- enemys[n][2] = Target Class
-- enemys[n][3] = tact
-- enemys[n][4] = casttact

function SelectEnemy(enemys,curenemy)
	local min_priority=-1
	local priority
	local min_dis = 100
	local dis
	--local min_aggro = -1
	--local aggro = 0
	local result=0
	local max_reachable=1
	--local min_mobcount=1
	--local mobcount=0
	if curenemy~=nil then -- it's an opportunistic attack
		local dist = GetDistanceA(MyID,curenemy)
		local aggrotemp=0
		if IsFriendOrSelf(GetV(V_TARGET,curenemy)) ==1 then
			aggrotemp=1
		end
		min_priority=convpriority(GetTact(TACT_BASIC,curenemy),aggrotemp)
		if dist < 3 then 
			return curenemy
		else
			min_dis = dist - 3
		end
	end
	for k,v in pairs(enemys) do
		local basepriority = v[3] -- basic tact
		if v[2]>0 and (v[1]==3 or v[4]>=CAST_REACT) then
			aggro=1
		else
			aggro=0
		end
		priority=convpriority(basepriority,aggro)
		--TraceAI(k.." "..basepriority.." "..priority)
		--elseif ((priority==2 or priority==5) and (v[1]==3 or v[4]>=CAST_REACT)) then
		--	aggro=-1
		--elseif then	
		--aggro = 1
		--else
		--	aggro=0
		--end
		dis = GetDistanceA (MyID,k)
		unreachable=Unreachable[k]
		if unreachable == nil then
			unreachable=0
		end
		
		--TraceAI(priority.."/"..min_priority.." "..dis.."/"..min_dis.." "..unreachable.."/"..max_reachable)
		if (unreachable <= max_reachable) then
			--if (aggro >= min_aggro) then
				if (priority > min_priority or (priority==min_priority and dis < min_dis)) then
					--if (dis < min_dis) then
						result = k
						min_dis = dis
						min_priority=priority
						--min_aggro=aggro
						max_reachable=unreachable
					--end
				end
			--end
		end
	end
	if max_reachable==1 then
		AllTargetUnreachable=1
	else 
		AllTargetUnreachable=0
	end
	--TraceAI("SelectEnemy returning target "..result)
	return result
end
function convpriority(base,agr)
	local priority
	if base > 9 and base < 13 then --Snipe modes are to be treated as attack
		base = base-8
	end
	if base == 13 then
		if agr == 1 then
			base = 7
		else 
			base = 2
		end
	end
	if base == 14 then
		base= 1
	end
	if base>6 and agr==1 then
		priority=base
	elseif base==4 or base==3 or base==15 then
		priority=base+1
		if agr==0 then 
			priority=priority-2
		end
	elseif (priority==5 and aggro==1) then 
		return 2
	elseif base==2 then
		return 1
	else
		return 0
	end
	return priority
end

--####################################################
--### DoIdleTasks - stuff done in any "idle" state ###
--### like buffs and command processing            ###
--####################################################

function DoIdleTasks()
	local cmd = List.popleft(ResCmdList)
	if (cmd ~= nil) then		
		ProcessCommand (cmd)	-- ¿¹¾à ¸í·É¾î Ã³¸® 
		return 
	end
	if OnIdleTasks()==1 then
		return
	end
	if UseAutoHeal==2 then
		if DoHealingTasks(MyID)==1 then
			return
		end
	end
	if DoAutoBuffs(1) ~=1 then
		return
	end
	if (UseSacrificeOwner == 1 and SacrificeTimeout ~=-1) then
		if (GetTick() > SacrificeTimeout) then
			local skill,level= GetSacrificeSkill(MyID)
			if (skill <= 0) then
				SacrificeTimeout = -1
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				DoSkill(skill,level,GetV(V_OWNER,MyID),7)
				SacrificeTimeout = GetTick() + GetSkillInfo(skill,8,level) -- this will recast it before it drops, because the countdown starts at the start of the cast time, but duration counts down from end of cast time.
				return
			end
		end
	end
	if (GetV(V_MOTION,GetV(V_OWNER,MyID))==MOTION_SIT and MyState~=REST_ST and DoNotUseRest~=1) then
		MyState=REST_ST
		TraceAI("DoIdleTasks - Owner sitting, MyState -> REST_ST")
		return
	end
	return 1
end

function DoAutoBuffs(buffmode)
	if GetTick() < AutoSkillTimeout then
		return 1
	end
	if buffmode==2 then -- Berserk mode only buffs
		if BerserkMode~=1 then
			return 1
		end
	end
	TraceAI("DoAutoBuffs"..buffmode)
	if (UseProvokeOwner == buffmode and ProvokeOwnerTimeout ~=-1) then
		if (GetTick() > ProvokeOwnerTimeout) then
			local skill,level= GetProvokeSkill(MyID)
			if (skill <= 0) then
				ProvokeOwnerTimeout = -1
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["ProvokeOwner"]=GetSkillInfo(skill,3,level)
				if MyASAPBuffs[3]==skill and buffmode==3 then
					ProvokeOwnerTimeout = GetTick()+20000 --We're stuck in an ASAP loop!
					logappend("AAI_ERROR","ASAP buff attempt canceled, we were just trying to do this and it didnt work, delaying 20 seconds "..FormatSkill(skill,level))
				else
					MyPState = MyState
					MyState = PROVOKE_ST
					MyPEnemy = GetV(V_OWNER,MyID)
					MyPSkill = skill
					MyPSkillLevel = level
					MyPMode = 7
					TraceAI(MyState.." --> PROVOKE_ST to use "..FormatSkill(skill,level))
					return OnPROVOKE_ST()
				end
			end
		end
	end
	if OffensiveOwnerTimeout ~=-1 then
		TraceAI("offensive owner ~= -1")
		if (GetTick() > OffensiveOwnerTimeout) then
			local skill,level,opt = GetOffensiveOwnerSkill(MyID)
			TraceAI("timeout ok "..opt.." "..FormatSkill(skill,level).." "..buffmode)
			if (skill <= 0) then
				OffensiveOwnerTimeout = -1
			elseif level==0 or opt~=buffmode then
				-- skill in cooldown
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["OffensiveOwner"]=GetSkillInfo(skill,3,level)
				if MyASAPBuffs[3]==skill and buffmode==3 then
					OffensiveOwnerTimeout = GetTick()+20000 --We're stuck in an ASAP loop!
					logappend("AAI_ERROR","ASAP buff attempt canceled, we were just trying to do this and it didnt work, delaying 20 seconds "..FormatSkill(skill,level))
				else
					MyPState = MyState
					MyState = PROVOKE_ST
					MyPEnemy = GetV(V_OWNER,MyID)
					MyPSkill = skill
					MyPSkillLevel = level
					MyPMode = 11
					TraceAI(MyState.." --> PROVOKE_ST to use "..FormatSkill(skill,level))
					return OnPROVOKE_ST()
				end
			end
		end
	end
	if DefensiveOwnerTimeout ~=-1 then
		TraceAI("defensive owner ~= -1")
		if (GetTick() > DefensiveOwnerTimeout)  and (DefensiveBuffOwnerMobbed==0 or (DefensiveBuffOwnerMobbed <= GetAggroCount(GetV(V_OWNER,MyID)) and HPPercent(GetV(V_OWNER,MyID)) < DefensiveBuffOwnerHP)) then
			local skill,level,opt = GetDefensiveOwnerSkill(MyID)
			TraceAI("timeout ok "..opt.." "..FormatSkill(skill,level).." "..buffmode)
			if (skill <= 0) then
				DefensiveOwnerTimeout = -1
			elseif level==0 or opt~=buffmode then
				-- skill in cooldown
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["DefensiveOwner"]=GetSkillInfo(skill,3,level)
				if MyASAPBuffs[3]==skill and buffmode==3 then
					DefensiveOwnerTimeout = GetTick()+20000 --We're stuck in an ASAP loop!
					logappend("AAI_ERROR","ASAP buff attempt canceled, we were just trying to do this and it didnt work, delaying 20 seconds "..FormatSkill(skill,level))
				else
					MyPState = MyState
					MyState = PROVOKE_ST
					MyPEnemy = GetV(V_OWNER,MyID)
					MyPSkill = skill
					MyPSkillLevel = level
					MyPMode = 12
					TraceAI(MyState.." --> PROVOKE_ST to use "..FormatSkill(skill,level))
					return OnPROVOKE_ST()
				end
			end
		end
	end
	if OtherOwnerTimeout ~=-1 then
		TraceAI("other owner ~= -1 "..GetTick().." "..OtherOwnerTimeout)
		if (GetTick() > OtherOwnerTimeout) then
			local skill,level,opt = GetOtherOwnerSkill(MyID)
			TraceAI("timeout ok "..opt.." "..FormatSkill(skill,level).." "..buffmode)
			if (skill <= 0) then
				OtherOwnerTimeout = -1
			elseif level==0 or opt~=buffmode then
				-- skill in cooldown
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["OtherOwner"]=GetSkillInfo(skill,3,level)
				if MyASAPBuffs[3]==skill and buffmode==3 then
					OtherOwnerTimeout = GetTick()+20000 --We're stuck in an ASAP loop!
					logappend("AAI_ERROR","ASAP buff attempt canceled, we were just trying to do this and it didnt work, delaying 20 seconds "..FormatSkill(skill,level))
				else
					MyPState = MyState
					MyState = PROVOKE_ST
					MyPEnemy = GetV(V_OWNER,MyID)
					MyPSkill = skill
					MyPSkillLevel = level
					MyPMode = 13
					TraceAI(MyState.." --> PROVOKE_ST to use "..FormatSkill(skill,level))
					return OnPROVOKE_ST()
				end
			end
		end
	end
	
	if (UseProvokeSelf == buffmode and ProvokeSelfTimeout ~=-1) then
		if (GetTick() > ProvokeSelfTimeout) then
			local skill,level = GetProvokeSkill(MyID)
			if (skill <= 0) then
				ProvokeSelfTimeout = -1
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				--MyState=PROVOKE_ST
				--OnPROVOKE_ST()
				--return
				DoSkill(skill,level,MyID)
				ProvokeSelfTimeout = GetTick()+GetSkillInfo(skill,8,level)
				return
			end
		end
	end
	if (UseOffensiveBuff == buffmode and QuickenTimeout ~=-1) then
		if (GetTick() > QuickenTimeout) then
			local skill,level = GetQuickenSkill(MyID)
			if (skill<=0) then
				QuickenTimeout = -1
			elseif level==0 then
				 -- skill in cooldown
			else
				if (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
					DoSkill(skill,level,MyID,2)
					QuickenTimeout = AutoSkillCastTimeout + GetSkillInfo(skill,8,level)
					UpdateTimeoutFile()
					return
				end
			end
		end
	end
	
	if (UseDefensiveBuff == buffmode and GuardTimeout ~=-1) then
		if (GetTick() > GuardTimeout) then
			local skill,level = GetGuardSkill(MyID)
			if (skill <= 0) then
				GuardTimeout = -1
			elseif level==0 then
				-- skill in cooldown
			elseif skill==HAMI_BULWARK and UseSmartBulwark ==1  then
				local spreq=MyBuffSPCost+GetSkillInfo(skill,3,level)
				if UseOffensiveBuff ~=0 and QuickenTimeout~=-1 then
					spreq=spreq+120
				end
				if spreq <= GetV(V_SP,MyID) then
					DoSkill(skill,level,MyID,1)
					GuardTimeout = AutoSkillCastTimeout + GetSkillInfo(skill,8,level)
					UpdateTimeoutFile()
				end
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				DoSkill(skill,level,MyID,1)
				GuardTimeout = AutoSkillCastTimeout + GetSkillInfo(skill,8,level)
				UpdateTimeoutFile()
				return
			end
		end
	end
	if SOffensiveTimeout ~=-1 then
		if (GetTick() > SOffensiveTimeout) then
			local skill,level,opt = GetSOffensiveSkill(MyID)
			if (skill <= 0) then
				SOffensiveTimeout = -1
			elseif level==0 or opt~=buffmode then
				-- skill in cooldown
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["SOffensive"]=GetSkillInfo(skill,3,level)
				DoSkill(skill,level,MyID,4)
				SOffensiveTimeout = AutoSkillCastTimeout + GetSkillInfo(skill,8,level)		
				--logappend("AAI_SKILL",skill.."|"..level.."|"..GetSkillInfo(skill,8,level).."|"..SOffensiveTimeout)
				UpdateTimeoutFile()
				return
			end
		end
	end
	if SDefensiveTimeout ~=-1 then
		TraceAI("sdefensive ~= -1")
		if (GetTick() > SDefensiveTimeout) then
			local skill,level,opt = GetSDefensiveSkill(MyID)
			TraceAI("timeout ok "..opt.." "..FormatSkill(skill,level).." "..buffmode)
			if (skill <= 0) then
				SDefensiveTimeout = -1
			elseif level==0 or opt~=buffmode then
				-- skill in cooldown
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["SDefensive"]=GetSkillInfo(skill,3,level)
				DoSkill(skill,level,MyID,5)
				SDefensiveTimeout = AutoSkillCastTimeout + GetSkillInfo(skill,8,level)
				UpdateTimeoutFile()
				return
			end
		end
	end
	if SOwnerBuffTimeout ~=-1 then
		if (GetTick() > SOwnerBuffTimeout) then
			local skill,level,opt = GetSOwnerBuffSkill(MyID)
			if (skill <= 0) then
				SOwnerBuffTimeout = -1
			elseif level==0 or opt ~=buffmode then
				-- do nothing, skill in cooldown
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["SOwnerBuff"]=GetSkillInfo(skill,3,level)
				DoSkill(skill,level,MyID,6)
				SOwnerBuffTimeout = AutoSkillCastTimeout + GetSkillInfo(skill,8,level)
				UpdateTimeoutFile()
				return
			end
		end
	end
	if UseBayeriSteinWand == buffmode and SteinWandTimeout~=-1 then
		if GetTick() > SteinWandTimeout  then
			if GetV(V_HOMUNTYPE,MyID)~=BAYERI then
				SteinWandTimeout=-1
			else
				if (GetAggroCount(MyID) >= UseSteinWandSelfMob and UseSteinWandSelfMob~=0) or (GetAggroCount(GetV(V_OWNER,MyID)) >= UseSteinWandOwnerMob and UseSteinWandOwnerMob~=0) then
					DoSkill(MH_STEINWAND,BayeriSteinWandLevel,MyID,10)
					SteinWandTimeout=AutoSkillCastTimeout+GetSkillInfo(MH_STEINWAND,8,BayeriSteinWandLevel)
					return
				end
			end
		end
	end
	if (UseAutoMag == buffmode and MagTimeout ~=-1) then
		if (GetTick() > MagTimeout) then
			if (GetV(V_MERTYPE,MyID)~=4) then
				MagTimeout = -1
			elseif (40 <= GetV(V_SP,MyID) and level ~=0) then
				DoSkill(MER_MAGNIFICAT,1,MyID,3)
				MagTimeout = GetTick() + 34000
				UpdateTimeoutFile()
				return
			end
		end
	end
	if SightTimeout ~=-1 then
		TraceAI("tick:"..GetTick().."SightTimeout"..SightTimeout)
		if (GetTick() > SightTimeout) then
			local skill,level,opt = GetSightOrAoE(MyID)
			if (skill <= 0) then
				SightTimeout = -1
			elseif level==0 or opt~=buffmode then
				-- skill in cooldown
			elseif (GetSkillInfo(skill,3,level) <= GetV(V_SP,MyID)) then
				MyBuffSPCosts["SightOrAoE"]=GetSkillInfo(skill,3,level)
				if IsHomun(MyID)==1 then
					if MyASAPBuffs[3]==skill and buffmode==3 then
						SightTimeout = GetTick()+20000 --We're stuck in an ASAP loop!
						logappend("AAI_ERROR","ASAP buff attempt canceled, we were just trying to do this and it didnt work, delaying 20 seconds "..FormatSkill(skill,level))
					else
						MyPState = MyState
						MyState = PROVOKE_ST
						MyPEnemy = GetV(V_OWNER,MyID)
						MyPSkill = skill
						MyPSkillLevel = level
						MyPMode = 7
						TraceAI(MyState.." --> PROVOKE_ST: Using AoE skill as buff"..MyPState.." "..MyState.." "..MyPEnemy.." "..MyPSkill.." "..MyPSkillLevel)
					return OnPROVOKE_ST()
				end				
				else
					DoSkill(skill,level,MyID,7)
					SightTimeout = AutoSkillCastTimeout + GetSkillInfo(skill,8,level)
					return
				end
			end
		end
	end
	if PainkillerFriends ~=0 then
		local skill,level,opt = GetDefensiveOwnerSkill(MyID)
		opt = PainkillerFriends
		if skill <=0 then 
			--logappend("AAI_PKF","Painkiller friends disabled, don't have skill")
			PainkillerFriends=0
		elseif level==0 or opt~=buffmode then
			--logappend("AAI_PKF","not time to use it")
			-- skill in cooldown
		elseif (GetSkillInfo(skill,3,level) > GetV(V_SP,MyID)) then
			
			--logappend("AAI_PKF","No SP")
			-- no SP
		else
			TraceAI("Painkiller Friends check")
			
			--logappend("AAI_PKF","Painkiller friends check")
			for k,v in pairs(Players) do
				--logappend("AAI_PKF","Painkiller friend "..k)
				if MyFriends[k]==FRIEND or MyFriends[k]==PKFRIEND then
					--logappend("AAI_PKF","Painkiller friend "..k.."not a friend")
					if PKFriendsTimeout[k]~=nil then
						if PKFriendsTimeout[k] < GetTick() then
							MyPState = MyState
							MyState = PROVOKE_ST
							MyPEnemy = k
							MyPSkill = skill
							MyPSkillLevel = level
							MyPMode = k
							TraceAI(MyState.." --> PROVOKE_ST to use "..FormatSkill(skill,level).." on friend "..k)
							return OnPROVOKE_ST()
						end
					else 
						MyPState = MyState
						MyState = PROVOKE_ST
						MyPEnemy = k
						MyPSkill = skill
						MyPSkillLevel = level
						MyPMode = k
						TraceAI(MyState.." --> PROVOKE_ST to use "..FormatSkill(skill,level))
						return OnPROVOKE_ST()
					end
				end
			end
		end
	end
	return OnAutoBuffs(buffmode)
end

function DoHealingTasks (myid) 
	rhp=HPPercent(myid)
	ohp=HPPercent(GetV(V_OWNER,myid))
	skill,level=GetHealingSkill(myid)
	if skill<=0 then 
		UseAutoHeal=0
		return
	elseif level==0 or GetTick() < AutoSkillTimeout then
		return --skill in cooldown
	end
	if rhp < HealSelfHP then
		if skill==HVAN_CHAOTIC then
			if GetV(V_SP,myid) > GetSkillInfo(skill,3,level) then
				TraceAI("Using self Healing skill "..FormatSkill(skill,level))
				if ohp < HealOwnerHP and MyState==IDLE_ST then
					DoSkill(skill,5,myid) 
				else
					DoSkill(skill,4,myid)
				end
				return 1
			else
				TraceAI("Can't use self healing skill, no SP")
			end
		end
	end
	if ohp < HealOwnerHP then
		if GetV(V_SP,myid) > GetSkillInfo(skill,3,level) then
			TraceAI("Using Healing skill "..FormatSkill(skill,level))
			DoSkill(skill,level,GetV(V_OWNER,myid))
			return 1
		else
			TraceAI("Can't use healing skill, no SP")
			return
		end
	end
end

function UpdateTimeoutFile()
	if StickyStandby==2 then
		ShouldStandbyx=ShouldStandby
	else
		ShouldStandbyx=0
	end
	if IsHomun(MyID)==1 then
		OutFile=io.open(ConfigPath.."data/H_"..GetV(V_OWNER,MyID).."Timeouts.lua","w")
	else
		OutFile=io.open(ConfigPath.."data/M_"..GetV(V_OWNER,MyID).."Timeouts.lua","w")
	end
	if OutFile~=nil then
		OutFile:write("MagTimeout="..TimeoutConv(MagTimeout).."\nSOffensiveTimeout="..TimeoutConv(SOffensiveTimeout).."\nSDefensiveTimeout="..TimeoutConv(SDefensiveTimeout).."\nSOwnerBuffTimeout="..TimeoutConv(SOwnerBuffTimeout).."\nGuardTimeout="..TimeoutConv(GuardTimeout).."\nQuickenTimeout="..TimeoutConv(QuickenTimeout).."\nOffensiveOwnerTimeout="..TimeoutConv(OffensiveOwnerTimeout).."\nDefensiveOwnerTimeout="..TimeoutConv(DefensiveOwnerTimeout).."\nOtherOwnerTimeout="..TimeoutConv(OtherOwnerTimeout).."\nShouldStandby="..ShouldStandbyx.."\nRegenTick[1]="..RegenTick[1].."\nMySpheres="..MySpheres.."\nEleanorMode="..EleanorMode)
		OutFile:close()
	else
		TraceAI("Failed to update timeout file")
		logappend("AAI_ERROR","Failed to update timeout file for owner "..GetV(V_OWNER,MyID))
	end
	return
end

function TimeoutConv(a)
	if a==-1 then
		return 0
	else
		return a
	end
end

function OnPROVOKE_ST()
	--local skill,level = GetProvokeSkill(MyID)
	if MyPSkillLevel==nil then
		logappend("AAI_ERROR","PSkillLevel is nil at start of OnPROVOKE_ST")
	end
	if MyPosX[1]==MyPosX[2] and MyPosY[1]==MyPosY[2] then
		SkillObjectCMDTimeout=SkillObjectCMDTimeout+1
	end
	local tx,ty=GetV(V_POSITION,MyPEnemy)
	if IsInAttackSight(MyID,MyPEnemy,MyPSkill,MyPSkillLevel) then
		
		if MyPMode == 7 then
			ProvokeOwnerTimeout = GetTick()+GetSkillInfo(MyPSkill,8,MyPSkillLevel)
		elseif MyPMode== 9 then
			SightTimeout = GetTick()+GetSkillInfo(MyPSkill,8,MyPSkillLevel)
		elseif MyPMode== 11 then
			OffensiveOwnerTimeout = GetTick()+GetSkillInfo(MyPSkill,8,MyPSkillLevel)
		elseif MyPMode== 12 then
			DefensiveOwnerTimeout = GetTick()+GetSkillInfo(MyPSkill,8,MyPSkillLevel)
		elseif MyPMode== 13 then
			OtherOwnerTimeout = GetTick()+GetSkillInfo(MyPSkill,8,MyPSkillLevel)
		elseif IsPlayer(MyPMode) then -- to detect painkiller-friends, in which case PMode is the id of the friend
			PKFriendsTimeout[MyPMode]=GetTick()+GetSkillInfo(MyPSkill,8,MyPSkillLevel)	
		end
		UpdateTimeoutFile()
		DoSkill(MyPSkill,MyPSkillLevel,MyPEnemy,MyPMode)
		MyState=MyPState
		TraceAI("PROVOKE_ST -> IDLE_ST - Buff/AoE okay"..MyState)
		MyDestX,MyDestY,MyPEnemy,MyPSkill,MyPState,MyPSkillLevel,MyPMode=0,0,0,0,0,0,0
		return
	elseif SkillObjectCMDTimeout>SkillObjectCMDLimit then
		TraceAI("PROVOKE_ST -> IDLE_ST Couldn't get into range to provoke/AoE owner")
		if (MyPMode==12) then
			DefensiveOwnerTimeout=GetTick()+20000
		elseif (MyPMode==7) then
			ProvokeOwnerTimeout=GetTick()+10000
		end
		if MyPState~=PROVOKE_ST then
			MyState=MyPState
		else
			MyState=0
		end
		SkillObjectCMDTimeout=0
		MyDestX,MyDestY,MyPEnemy,MyPSkill,MyPState,MyPSkillLevel,MyPMode=0,0,0,0,0,0,0
		return
	elseif SkillObjectCMDTimeout>(SkillObjectCMDLimit/2) then --We're having trouble getting to the place we want to in order to use this buff, so let's just try to move right to target
		range = AttackRange(MyID,MyPSkill,MyPSkillLevel)
		if range > 2 and MyPEnemy==GetV(V_OWNER,MyID) then
			TraceAI("PROVOKE_ST -> PROVOKE_ST - Moving to owner from "..formatpos(MyPosX[1],MyPosY[1]).." targeting "..MyPEnemy.." at "..formatpos(tx,ty))
			MoveToOwner(MyID)
		else
			--local x,y=ClosestR(MyID,MyPEnemy,AttackRange(MyID,MyPSkill,MyPSkillLevel),math.random(2))
			local x,y=GetStandPoint(MyID,MyPEnemy,MyPSkill,MyPSkillLevel,1)
			if x==-1 then
				TraceAI("PROVOKE_ST -> IDLE_ST target surrounded, no available cells!")
				if MyPState~=PROVOKE_ST then
					MyState=MyPState
				else
					MyState=0
				end
				SkillObjectCMDTimeout=0
				MyDestX,MyDestY,MyPEnemy,MyPSkill,MyPState,MyPSkillLevel,MyPMode=0,0,0,0,0,0,0
			else
				TraceAI("PROVOKE_ST -> PROVOKE_ST - Moving (alt=1) to "..formatpos(x,y).." from "..formatpos(MyPosX[1],MyPosY[1]).." targeting "..MyPEnemy.." at "..formatpos(tx,ty))
				Move(MyID,x,y)
			end
		end
		return
	else
		local x,y=GetStandPoint(MyID,MyPEnemy,MyPSkill,MyPSkillLevel,0)
		if x==-1 then
			TraceAI("PROVOKE_ST -> IDLE_ST target surrounded, no available cells!")
			if MyPState~=PROVOKE_ST then
				MyState=MyPState
			else
				MyState=0
			end
			SkillObjectCMDTimeout=0
			MyDestX,MyDestY,MyPEnemy,MyPSkill,MyPState,MyPSkillLevel,MyPMode=0,0,0,0,0,0,0
		else
			TraceAI("PROVOKE_ST -> PROVOKE_ST - Moving to "..formatpos(x,y).." from "..formatpos(MyPosX[1],MyPosY[1]).." targeting "..MyPEnemy.." at "..formatpos(tx,ty))
			Move(MyID,x,y)
		end
		return
	end
end

function	OnIDLEWALK_ST ()
	TraceAI ("OnIDLEWALK_ST")
	ResetCounters()
	MyEnemy					= 0
	if SPPercent(MyID) < IdleWalkSP then
		MyState=IDLE_ST
		TraceAI ("IDLEWALK_ST -> IDLE_ST : SP is below IdleWalkSP - switching to idle mode to regen SP")
		return OnIDLE_ST()
	end
	if (DoIdleTasks()==nil) then
		return
	end
	--Targeting
	if SuperPassive~=1 then
		local	object = SelectEnemy(GetFriendTargets())
		if (object ~= 0) then							-- MYOWNER_ATTACKED_IN
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("IDLEWALK_ST -> CHASE_ST : MYOWNER_ATTACKED_IN")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				OnCHASE_ST()
			end
			return 
		end
		if (HPPercent(MyID) > AggroHP and (SPPercent(MyID) > AggroSP or AggroSP==0) and (ShouldStandby == 0 or StickyStandby ==0)) then
			aggro=1
		else
			aggro=0
		end
		object=SelectEnemy(GetEnemyList(MyID,aggro))
		if object~=0 then
			MyState = CHASE_ST
			MyEnemy = object
			TraceAI ("IDLEWALK_ST -> CHASE_ST : ATTACKED_IN")
			if (FastChangeCount < FastChangeLimit and FastChange_I2C ==1) then
				return OnCHASE_ST()
			end
			return	
		end
		if (aggro==1 and TankMonsterCount < TankMonsterLimit) then
			object = SelectEnemy(GetEnemyList(MyID,-1))
			if (object ~= 0) then
				MyState = TANKCHASE_ST
				MyEnemy = object
				TraceAI ("IDLEWALK_ST -> TANKCHASE_ST")
				return
			end
		end
	end
	--Following
	local distance = GetDistanceAR(MyID,GetV(V_OWNER,MyID))
	if ( distance > GetMoveBounds()) then		-- MYOWNER_OUTSIGNT_IN
		MyState = FOLLOW_ST
		TraceAI ("IDLEWALK_ST -> FOLLOW_ST: Way too far away from owner "..distance)
		return
	end
	if UseAutoHeal==3 then
		if DoHealingTasks(MyID) == 1 then 
			return
		end
	end
	DoAutoBuffs(-2)
	-- end of the usual idle tasks - now we have to do the idle walk part of it, which sucks. 
	local x,y=GetV(V_POSITION,MyID)
	local ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
	local motion=GetV(V_MOTION,MyID)
	if (GetDistanceAPR(MyID,MyDestX,MyDestY)<=1) then --we're there.
		if OldHomunType==AMISTR and UseCastleRoute==1 and (UseIdleWalk==5 or UseIdleWalk==6) and RelativeRoute==0 and GetDistanceP(x,y,ox,oy) > 2 then
			if GetTick() > AutoSkillTimeout then
				DoSkill(HAMI_CASTLE,5,MyID)
				TraceAI("Castle Route: Casting castling on self")
			else
				TraceAI("Castle Route: Skill timeout not OK - can't cast castling")
			end
			return
		elseif UseCastleRoute==1 and OldHomunType==AMISTR and RelativeRoute==0 then
			TraceAI("We're set to use castling route, but can't, UseIdleWalk="..UseIdleWalk.." distance: "..GetDistanceP(x,y,ox,oy))
		end
		MyDestX,MyDestY=GetIdleWalkDest(MyID)
	elseif (GetDistanceAPR(MyID,MyDestX,MyDestY)>=1) and (IdleWalkTries > 6 or GetDistanceAPR(GetV(V_OWNER,MyID),MyDestX,MyDestY) > GetMoveBounds()) then 
		MyDestX,MyDestY=GetIdleWalkDest(MyID)
		if MyDestX==ox and MyDestY==oy then
			MyDestX,MyDestY=Closest(MyID,MyDestX,MyDestY,1,1)
		end
		IdleWalkTries=0 
		TraceAI("IDLEWALK_ST: New destination: "..MyDestX..","..MyDestY)
		return Move(MyID,MyDestX,MyDestY)
	elseif motion == MOTION_STAND then
		if IdleWalkTries == 4 then
			MyDestX,MyDestY=Closest(MyID,MyDestX,MyDestY,1,1)
			TraceAI("IDLEWALK_ST: Having a bit of trouble - adjust dest to: "..MyDestX..","..MyDestY)
		end
		TraceAI("IDLEWALK_ST: No move after "..IdleWalkTries.." trying again:"..MyDestX..","..MyDestY)
		IdleWalkTries=IdleWalkTries+1
		return Move(MyID,MyDestX,MyDestY)
	else
		--we're en route
		return
	end
end

function GetIdleWalkDest(MyID)
	local mx,my=GetV(V_POSITION,MyID)
	local ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
	local xoff,yoff=mx-ox,my-oy
	TraceAI("Idlewalk"..xoff..","..yoff)
	if UseIdleWalk==1 then --orbit
		local stepsize = 30
		if IdleWalkDistance > 4 then
			stepsize=30
		else
			stepsize=45
		end
		local temp=math.deg(math.atan2(xoff,yoff))+stepsize/2
		if temp < 0 then
			temp=temp+360
		end
		local step = math.floor(temp/stepsize) + 1
		local angle=math.rad(step*stepsize)
		local destx=math.ceil(math.sin(angle)*IdleWalkDistance)+ox
		local desty=math.ceil(math.cos(angle)*IdleWalkDistance)+oy
		TraceAI("Orbit Dest: "..destx..","..desty.." owner: "..ox..","..oy.." mypos: "..mx..","..my)
		return destx,desty	
	elseif UseIdleWalk==2 then -- Cross
		local temp=math.deg(math.atan2(xoff,yoff))+45
		if temp < 0 then
			temp=temp+360
		end
		step = math.floor(temp/90)
		TraceAI("Cross step "..step)
		if step == 0 then -- north goes to south
			return ox,oy-IdleWalkDistance
		elseif step == 1 then -- east goes to north
			return ox,oy+IdleWalkDistance
		elseif step == 2 then -- south goes to west
			return ox-IdleWalkDistance,oy
		else  -- must be west!
			return ox+IdleWalkDistance,oy
		end
	elseif UseIdleWalk==3 then -- Rectangle
		local temp=math.deg(math.atan2(xoff,yoff))+22.5
		local tempt=temp
		if temp < 0 then
			temp=temp+360
		end
		local step = math.floor(temp/45) + 1
		local destx,desty = ox,oy
		if step > 0 and step < 4 then
			destx = ox + IdleWalkDistance
		elseif step >4 and step < 8 then
			destx = ox - IdleWalkDistance
		end
		if step ==8 or step == 1 or step == 7 then
			desty= oy + IdleWalkDistance 
		elseif step > 2 and step < 6 then
			desty=oy-IdleWalkDistance
		end
		TraceAI("Rectangle Dest: "..destx..","..desty.." owner: "..ox..","..oy.." mypos: "..mx..","..my.." temp: "..temp.." "..tempt.." step: "..step)
		return destx,desty
	elseif UseIdleWalk==4 then -- Random
		local step = math.random(0,359)
		local angle=math.rad(step)
		local destx=absceil(math.sin(angle)*IdleWalkDistance)+ox
		local desty=absceil(math.cos(angle)*IdleWalkDistance)+oy
		TraceAI("Random Dest: "..destx..","..desty.." owner: "..ox..","..oy.." mypos: "..mx..","..my) 
		return destx,desty	
	elseif UseIdleWalk==5 or UseIdleWalk==6 then -- Route walk
		local routelen=1
		local step = nil
		local dist = 999
		local posx,posy
		if RelativeRoute==1 then
			posx,posy=xoff,yoff
			TraceAI("Relative route "..xoff..","..yoff)	
		else
			TraceAI("Absolute route "..mx..","..my)	
			posx,posy=mx,my
		end
		
		for k,v in pairs(MyRoute) do
			routelen=k
			if v[1]==posx and v[2]==posy then 
				step=k
				dist=0
				TraceAI("Route Analysis: on route cell "..posx..","..posy.." route step: "..k.." "..v[1]..","..v[2].." current step "..step.."/"..dist)
			else 
				local distance=math.sqrt((v[1]-posx)^2+(v[2]-posy)^2)
				if distance < dist then
					dist=distance
					step=k
					TraceAI("Route Analysis: "..posx..","..posy.." route step: "..k.." "..v[1]..","..v[2].." distance "..distance.." current step "..step.."/"..dist)
				end
			end
		end
		-- now we're at position 'step'	
		local nextstep
		if RouteWalkDirection==1 and step==routelen then
			if UseIdleWalk==5 then
				RouteWalkDirection=-1
				nextstep=step-1
			else 
				nextstep=1
			end
		elseif RouteWalkDirection==-1 and step==1 then
			if UseIdleWalk==5 then
				RouteWalkDirection=1
				nextstep=2
			else 
				nextstep=routelen
			end
		else
			nextstep=step+1*RouteWalkDirection
		end
		TraceAI("Route Walk - nextstep "..nextstep.." from "..step)
		local destx,desty
		if RelativeRoute==1 then
			destx,desty = ox+MyRoute[nextstep][1],oy+MyRoute[nextstep][2]
		else
			destx,desty = MyRoute[nextstep][1],MyRoute[nextstep][2]
		end
		
		TraceAI("Route Dest: "..destx..","..desty.." owner: "..ox..","..oy.." mypos: "..mx..","..my.." pos: "..posx..","..posy.." routelen: "..routelen.." "..dist.." step: "..step.." nextstep= "..nextstep)
		return destx,desty
	else
		logappend("AAI_ERROR","Invalid UseIdleWalk made it all the way to GetIdleWalkDest()")
		UseIdleWalk=0
		return GetV(V_POSITION,MyID)
	end
end
--######################
--### DoAutoPushback ###
--######################

function DoAutoPushback(myid)
	local actors = GetActors()
	local x,y=GetV(V_POSITION,myid)
	for i,v in ipairs(actors) do
		if (IsMonster(v)==1) then
			local tact= GetTact(TACT_PUSHBACK,v)
			local target =GetV(V_TARGET,v)
			if (tact==2 or (tact==1 and IsFriendOrSelf(target)==1))then				
				TraceAI("Pushback: "..GetDistanceA(target,v))
				if (GetDistanceA(target,v) <= AutoPushbackThreshold and GetDistanceA(target,v)~=-1) then
					TraceAI("Enemies close to me, using pushback")
					local skill,level=GetPushbackSkill(MyID)
					if (skill<=0) then
						UseAutoPushback=0
					elseif (GetV(V_SP,myid) >= GetSkillInfo(skill,3,level) and GetV(V_SKILLATTACKRANGE,MyID,skill) >= GetDistanceA(myid,v)) then
						DoSkill(skill,level,v)
						return
					end
					break
				end
			end
		elseif (IsFriendOrSelf(id)==0 and PVPmode ~=0) then
			local tact= GetPVPTact(TACT_PUSHBACK,v)
			local target =GetV(V_TARGET,v)
			if (tact==2 or (tact==1 and IsFriendOrSelf(target)==1))then
				if (GetDistanceA(target,v) <= AutoPushbackThreshold) then
					TraceAI("Enemies close to me, using pushback")
					local skill,level=GetPushbackSkill(MyID)
					if (skill<=0) then
						UseAutoPushback=0
					elseif (GetV(V_SP,myid) >= GetSkillInfo(skill,3,level)) then
						DoSkill(skill,level,v)
						return
					end
					break
				end
			end
		end
	end
	return 1
end


--####################
--### DoKiteAdjust ###
--####################

function DoKiteAdjust(myid,enemy)
	local step
	local target=GetV(V_TARGET,enemy)
	if (IsFriend(target)==1 or target==MyID) then
		step=KiteStep
	else
		step=KiteParanoidStep
	end
	local x,y=GetV(V_POSITION,myid)
	local ox,oy=GetV(V_POSITION,GetV(V_OWNER,myid))
	local ex,ey=GetV(V_POSITION,enemy)
	local xoptions ={[2]=1,[0]=1,[1]=1}
	local yoptions ={[2]=1,[0]=1,[1]=1}
	local xdirection,ydirection=0,0
	if (x > ex) then
		xoptions[2]=0
	elseif (x < ex) then
		xoptions[1]=0
	else
		yoptions[0]=0
	end
	if (y > ey) then
		yoptions[2]=0
	elseif (y < ey) then
		yoptions[1]=0
	else
		xoptions[0]=0
	end
	if (ox > x) then
		if (xoptions[1]==1) then
			xdirection=1
		elseif (xoptions[0]==1) then
			xdirection=0
		elseif (xoptions[2]==1 and (ox-x+step) <= KiteBounds) then
			xdirection=-1
		elseif	(ey < y) then
			xdirection=0
		else
			xdirection=1
		end
	else
		if (xoptions[2]==1) then
			xdirection=-1
		elseif (xoptions[0]==1) then
			xdirection=0
		elseif (xoptions[1]==1 and (x-ox+step) <= KiteBounds) then
			xdirection=1
		elseif	(ey > y) then
			xdirection=0
		else
			xdirection=-1
		end
	end
	if (oy > y) then
		if (yoptions[1]==1) then
			ydirection=1
		elseif (yoptions[0]==1 and xdirection~=0) then
			ydirection=0
		elseif (yoptions[2]==1 and oy-y+step <= step) then
			ydirection=-1
		elseif	(ex > x and xdirection~=0) then
			ydirection=0
		else
			ydirection=1
		end
	else 
		if (yoptions[2]==1) then
			ydirection=-1
		elseif (yoptions[0]==1 and xdirection~=0) then
			ydirection=0
		elseif (yoptions[1]==1 and y-oy+step <= KiteBounds) then
			ydirection=1
		elseif	(ex < x and xdirection~=0) then
			ydirection=0
		else
			ydirection=-1
		end
	end
	TraceAI("Kiteing in "..xdirection..","..ydirection.." direction")
	MyDestX=x+step*xdirection
	MyDestY=y+step*ydirection
	Move(myid,MyDestX,MyDestY)
end

function FailSkillUse(mode) 
	local modex=mode
	if IsPlayer(mode)==1 then
		mode=13
	end
	if SkillFailCount[mode]==nil then 
		SkillFailCount[mode]=0
	end
	if SkillFailCount[mode] < SkillRetryLimit[mode] then
		if mode == -1 then -- attack state
			MySkillUsedCount=math.max(0,MySkillUsedCount-1)
		elseif mode==1 then
			GuardTimeout=1
		elseif mode==2 then
			QuickenTimeout=1
		elseif mode==3 then
			MagTimeout=1
		elseif mode==4 then
			SOffensiveTimeout=1
		elseif mode==5 then
			SDefensiveTimeout=1
		elseif mode==6 then
			SOwnerBuffTimeout=1
		elseif mode==7 then
			SightTimeout=1
		elseif mode==9 then
			ProvokeOwnerTimeout=1
		elseif mode==10 then
			SteinWandTimeout = 1
		elseif mode==11 then
			OffensiveOwnerTimeout = 1
		elseif mode==12 then
			DefensiveOwnerTimeout = 1
		elseif mode==13 then
			OtherOwnerTimeout = 1
		elseif IsPlayer(modex) then
			--logappend("AAI_PKF","skill failed on"..mode)
			PKFriendsTimeout[modex]=1
		else
			OnFailUnknownMode(mode)
		end
		TraceAI("Skill cast appears to have failed: Mode "..mode.." fail count "..SkillFailCount[mode].." will try again")
		logappend("AAI_SKILLFAIL","Skill cast appears to have failed: Mode "..mode.." fail count "..SkillFailCount[mode].." will try again")
		SkillFailCount[mode]=SkillFailCount[mode]+1
	else
		if (mode~=nil and mode ~=0) then
		TraceAI("Skill cast appears to have failed, but we're past the retry limit, so screw it: Mode "..mode.." fail count "..SkillFailCount[mode])
		logappend("AAI_SKILLFAIL","Skill cast appears to have failed, but we're past the retry limit, so screw it: Mode "..mode.." fail count "..SkillFailCount[mode])
		SkillFailCount[mode]=0
	end
	end
	AutoSkillTimeout = 1
	AutoSkillCastTimeout = 1
	if AutoSkillCooldown[CastSkill]~=nil then
		AutoSkillCooldown[CastSkill]=1
	end
	CastSkill=0
	CastSkillLevel=0
	CastSkillMode=0
	CastSkillTime=0
	CastSkillState=0	
end	

--########################
--### Main AI Function ###
--########################

function AI(myid)
	MyID = myid
	if LastAITime==GetTick() then --prevent AI from running twice in the same tick. 
		TraceAI("double-AI() call detected, blocked")
		return
	else
		if LastAITime + 400 < GetTick() and LastAITime > 10 then
			TraceAI("Missed AI calls. Previous AI call was "..LastAITime-GetTick().." ms ago")
			logappend("AAI_SKILLFAIL", "Missed AI calls. Previous AI call was "..LastAITime-GetTick().." ms ago")
			EnemyPosX = {0,0,0,0,0,0,0,0,0,0} --When we miss AI calls, that means our predictive motion is probly screwed up
			EnemyPosY = {0,0,0,0,0,0,0,0,0,0} --so flush this to prevent homun from getting confused by it, 
		end
		LastAIDelay=GetTick()-LastAITime
		LastAITime=GetTick()
		if MyEnemy ~= 0 then
			local ex,ey=GetV(V_POSITION,MyEnemy)
			for v=10,2,-1 do
				EnemyPosX[v],EnemyPosY[v]=EnemyPosX[v-1],EnemyPosY[v-1]
			end
			EnemyPosX[1],EnemyPosY[1]=ex,ey,GetV(V_MOTION,MyID)
		end
	end
	if DoneInit== 0 then
		doInit(myid)
	end
	if AggressiveRelogTracking==1 then
		local OutFile
		if IsHomun(MyID)==1 then
			OutFile=io.open(AggressiveRelogPath.."H_"..GetV(V_OWNER,MyID).."Time.lua","w")
		else
			OutFile=io.open(AggressiveRelogPath.."M_"..GetV(V_OWNER,MyID).."Time.lua","w")
		end
		if OutFile~=nil then
			OutFile:write("LastAITime_ART="..LastAITime)
			OutFile:close()
		else
			TraceAI("Failed to update time file for Aggressive Relog Tracking")
			logappend("AAI_ERROR","Failed to update aggressive relog time tracking file for owner "..GetV(V_OWNER,MyID))
		end
	end
	OnAIstart()
	-- ###AUTOFRIEND###
	-- Save the ID to a file so counterpart can friend it
	-- Why is it here instead of at the start?
	-- Because the client wont tell us our ID until AI() is called :-(
	if (NeedToDoAutoFriend==1 and NewAutoFriend==1) then
		TraceAI("Now it's time to do the autofriend")
		local owner=GetV(V_OWNER,myid)
		local OutFile
		if (IsHomun(myid)==1) then
			OutFile=io.open(ConfigPath.."data/H_"..owner..".txt","w")
		else
			OutFile=io.open(ConfigPath.."data/M_"..owner..".txt","w")
		end
		if OutFile~=nil then
			OutFile:write (myid)
			OutFile:close()
		else
			TraceAI("Failed to create autofriending file.")
			logappend("AAI_ERROR","Failed to create autofriending file for owner "..GetV(V_OWNER,MyID))
		end
		NeedToDoAutoFriend=0
	end
	
	--###BOOKKEEPING###
	
	
	-- Hackjob to fix strange behavior, with the timeouts being set to hours, days, or weeks in the future (suspect due to GetTick() returning bad numbers). 

	if GuardTimeout-GetTick() > 350000 then
		logappend("AAI_ERROR","Guard timeout was "..GuardTimeout.." time is "..GetTick())
		GuardTimeout=1
	end
	if MagTimeout-GetTick() > 350000 then
		logappend("AAI_ERROR","Mag timeout was "..MagTimeout.." time is "..GetTick())
		MagTimeout=1
	end
	if QuickenTimeout-GetTick() > 1205000 then
		logappend("AAI_ERROR","Quicken timeout was "..QuickenTimeout.." time is "..GetTick())
		QuickenTimeout=1
	end
	if SOffensiveTimeout-GetTick() > 350000 then
		logappend("AAI_ERROR","Homun S offensive timeout was "..SOffensiveTimeout.." time is "..GetTick())
		SOffensiveTimeout=1
	end
	if SDefensiveTimeout-GetTick() > 350000 then
		logappend("AAI_ERROR","Homun S defensive timeout was "..SDefensiveTimeout.." time is "..GetTick())
		SDefensiveTimeout=1
	end
	if SOwnerBuffTimeout-GetTick() > 6000000 then
		logappend("AAI_ERROR","Homun S owner buff timeout was "..SOwnerBuffTimeout.." time is "..GetTick())
		SOwnerBuffTimeout=1
	end
	if OffensiveOwnerTimeout-GetTick() > 6000000 then
		logappend("AAI_ERROR","Offensive owner buff timeout was "..OffensiveOwnerTimeout.." time is "..GetTick())
		OffensiveOwnerTimeout=1
	end
	if DefensiveOwnerTimeout-GetTick() > 6000000 then
		logappend("AAI_ERROR","Defensive owner buff timeout was "..DefensiveOwnerTimeout.." time is "..GetTick())
		DefensiveOwnerTimeout=1
	end
	if OtherOwnerTimeout-GetTick() > 6000000 then
		logappend("AAI_ERROR","Other owner buff timeout was "..OtherOwnerTimeout.." time is "..GetTick())
		OtherOwnerTimeout=1
	end
	if MyMaxSP~=GetV(V_MAXSP,MyID) then
		AdjustCapriceLevel()
		MyMaxSP=GetV(V_MAXSP,MyID)
	end
	if AIInitTick==0 or AIInitTick==1 or AIInitTick==nil then
		AIInitTick=GetTick()
	end
	FastChangeCount = 0
	--###For UseSmartBulwark:
	if UseSmartBulwark==1 then
		MyBuffSPCost=0
		for k,v in pairs(MyBuffSPCosts) do
			MyBuffSPCost=MyBuffSPCost+v
		end
	end

	--###DATA GATHERING###
	for k,v in pairs(Unreachable) do
		if (IsOutOfSight(myid,k)==true or GetV(V_MOTION,k)==MOTION_DEAD or (IsFriendOrSelf(GetV(V_TARGET,k))==1) and GetV(V_MOTION,k)~=MOTION_STAND) then
			Unreachable[k]=nil
			TraceAI("Marking as reachable"..k)
		end
	end
	
	-- Position sensing
	local x,y=GetV(V_POSITION,MyID)
	local ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
	if MyEnemy ~= 0 then
		local ex,ey=GetV(V_POSITION,MyEnemy)
	else
		ex,ey=0,0
	end
	--myposlog=""
	for v=10,2,-1 do
		MyASAPBuffs[v],MyPosX[v],MyPosY[v],OwnerPosX[v],OwnerPosY[v],EnemyPosX[v],EnemyPosY[v],MyMotions[v],MyStates[v],MyEnemies[v]=MyASAPBuffs[v-1],MyPosX[v-1],MyPosY[v-1],OwnerPosX[v-1],OwnerPosY[v-1],EnemyPosX[v-1],EnemyPosY[v-1],MyMotions[v-1],MyStates[v-1],MyEnemies[v-1]
	end	
	MyPosX[1],MyPosY[1],OwnerPosX[1],OwnerPosY[1],EnemyPosX[1],EnemyPosY[1],MyMotions[1],MyStates[1],MyEnemies[1]=x,y,ox,oy,ex,ey,GetV(V_MOTION,MyID),MyState,MyEnemy
	if MyState==PROVOKE_ST then
		MyASAPBuffs[1]=MyASAPBuffs[2]
	else
		MyASAPBuffs[1]=0
	end
	--for v=1,10 do
	--	myposlog=myposlog.." "..MyPosX[v]..","..MyPosY[v]
	--end
	--TraceAI("MyPosLog "..myposlog.." x="..x.."y="..y)
	if x~=MyPosX[2] or y~=MyPosY[2] then
		--TraceAI("we moved")
		LastMovedTime=GetTick()
	end
	-- Actor list preprocessing
	local actors=GetActors()
	Actors={}
	OldPlayers=Players
	Players={}
	Monsters={}
	Summons={}
	Retainers={}
	Targets={}
	TakenCells={} --OccupiedCellDetection 
	tMobID=""
	TankMonsterCount=0
	local seralegionCount=0
	SeraLegionList=""
	local seralegionActive=0
	local seralegionBugged=0
	for i,v in ipairs(actors) do
		local x,y = GetV(V_POSITION,v)
		TakenCells[x.."_"..y]=1
		if AAIActors[v]~=1 then
			if IsHomun(myid)==1 then
				logappend("AAI_ACTORS","Actor "..v.." type "..GetV(V_HOMUNTYPE,v).." at "..x..","..y.." Is M="..IsMonster(v))
			else
				logappend("AAI_ACTORS","Actor "..v.." mertype "..GetV(V_MERTYPE,v).." at "..x..","..y.." Is M="..IsMonster(v))
			end
			AAIActors[v]=1
		end
		local x,y = GetV(V_POSITION,v)
		if GetV(V_HOMUNTYPE,v)==1102 and x==174 and 33==y and GetV(V_MOTION,v)==MOTION_STAND then
			-- This is the eden group bathory, ignore it. 
		else	
			if (false == IsOutOfSight(myid,v)) then
				Actors[v]=1
				--TraceAI(v.." of type "..GetV(V_HOMUNTYPE,v).." in sight")
				if GetV(V_HOMUNTYPE,MyID)==SERA then
					local actortype=GetV(V_HOMUNTYPE,v)
					if (actortype > 2157 and actortype < 2161) then
						seralegionCount=seralegionCount+1
						SeraLegionList=SeraLegionList..v.." "
						if GetV(V_MOTION,v)==MOTION_STAND and GetDistanceAR(MyID,v)>3 then
							seralegionBugged=seralegionBugged+1
						else 
							seralegionActive=seralegionActive+1
						end
					end
				end
				if (v > MagicNumber2) then
					Players[v]=1
					if MyFriends[v]==FRIEND and GetV(V_OWNER,MyID)~=v then --Newly appeared on screen
						if OldPlayers[v]~=1 or AggressiveAutofriend then
							local newfriendhidfile=io.open(ConfigPath.."data/H_"..v..".txt","r")
							local newfriendmidfile=io.open(ConfigPath.."data/M_"..v..".txt","r")
							TraceAI("new friend on screen, checking H_ID"..v)
							if newfriendhidfile~=nil then
								TraceAI("h_id found"..v)
								local newfriendhid=newfriendhidfile:read("*line")
								if newfriendhid~=nil then
									TraceAI("h_id: "..newfriendhid)
									MyFriends[newfriendhid+1-1]=RETAINER --crude type conversion
								end
								newfriendhidfile:close()
							end
							if newfriendmidfile~=nil then
							TraceAI("new friend on screen, checking M_ID"..v)
								local newfriendmid=newfriendmidfile:read("*line")
								TraceAI("m_id found"..v)
								if newfriendmid~=nil then
									TraceAI("m_id: "..newfriendmid)
									MyFriends[newfriendmid+1-1]=RETAINER
								end
								newfriendmidfile:close()
							end
						end	
					end
				elseif IsMonster(v)==1 then
					--TraceAI(v.." of type "..GetV(V_HOMUNTYPE,v).." is a monster")
					if LiveMobID == 1 and IsHomun(MyID)==1 then
						tMobID=tMobID.."MobID["..v.."]="..GetV(V_HOMUNTYPE,v).."\n"
					end
					Monsters[v]=1
					if (v < MagicNumber) then
						Summons[v]=1
					end
					if (AutoDetectPlant==1 and IsActive[v]~=1 and IsHomun(myid)~=1) then
						if (GetV(V_MOTION,v)==MOTION_STAND or GetV(V_MOTION,v)==MOTION_DAMAGE or GetV(V_MOTION,v)==MOTION_DEAD) then
							IsActive[v]=0
						else
							IsActive[v]=1
						end
					end
					if (GetTact(TACT_BASIC,v)==TACT_TANK and GetV(V_TARGET,v)==MyID) then
						TankMonsterCount=TankMonsterCount+1
					end
					motionclass=MotionClassLU[GetV(V_MOTION,v)]
					if motionclass==nil then 
						motionclass=3 
					end --CHANGE
					--TraceAI(v.." of type "..GetV(V_HOMUNTYPE,v).." "..motionclass)
					if (motionclass~=-1 and (IsActive[v]==1 or AutoDetectPlant~=1 or IsHomun(myid)==1)) then 
						--TraceAI(v.." of type "..GetV(V_HOMUNTYPE,v).." target added")
						Targets[v]={motionclass,GetTargetClass(GetV(V_TARGET,v))}
					end
				elseif (v < MagicNumber) then		
					Retainers[v]=1
				end
			end
		end
	end
	if LiveMobID == 1 and IsHomun(MyID)==1 and tMobID ~="" then
		local midoutfile=io.open(AggressiveRelogPath.."MobID.lua","w")
		if midoutfile~=nil then
			midoutfile:write(tMobID)
			midoutfile:close()
		else
			TraceAI("Failed to update MobID - check permissions and/or AggressiveRelogPath.")
			logappend("AAI_ERROR","Failed to update aggressive relog time tracking file for owner "..GetV(V_OWNER,MyID))
		end
	end
	if LiveMobID == 1 and IsHomun(MyID)==0 then
		MobID={}
		if pcall(function () dofile(AggressiveRelogPath.."MobID.lua") end) then
			-- do nothing
		else
			logappend("AAI_ERROR", "Failed to load MobID from "..AggressiveRelogPath.."MobID.lua")
		end
	end
	if GetV(V_HOMUNTYPE,MyID)==SERA then
		for t=1,4 do
			SeraLegionTotalHist[t+1]=SeraLegionTotalHist[t]
			SeraLegionBugHist[t+1]=SeraLegionBugHist[t]
		end
		SeraLegionTotalHist[1]=seralegionCount
		SeraLegionBugHist[1]=seralegionBugged
		SeraLegionCount=math.max(SeraLegionTotalHist[1],SeraLegionTotalHist[2],SeraLegionTotalHist[3],SeraLegionTotalHist[4],SeraLegionTotalHist[5])
		SeraLegionBugged=math.min(SeraLegionBugHist[1],SeraLegionBugHist[2],SeraLegionBugHist[3],SeraLegionBugHist[4],SeraLegionBugHist[5])
		SeraLegionActive=SeraLegionCount-SeraLegionBugged
		if SeraLegionCount==0 and GetTick() > AutoSkillTimeout and GetTick() < AutoSkillCooldown[MH_SUMMON_LEGION] then
			--Why are we in cooldown when there are no bugs out? Cast must have failed, or something killed them. 
			AutoSkillCooldown[MH_SUMMON_LEGION]=1
			TraceAI("Sera Legion: Legion cooldown canceled, bugs not present")
		elseif SeraLegionBugged > 2 then
			AutoSkillCooldown[MH_SUMMON_LEGION]=1
			TraceAI("Sera Legion: Legion cooldown canceled, bugs bugged")
		end
		--logappend("AAI_Legion","Sera Legion - "..SeraLegionCount.." bugs out "..SeraLegionActive.." active and "..SeraLegionBugged.." bugged. "..SeraLegionList)
	end
	if PVPmode==1 then
		for k,v in pairs(Players) do
			--logappend("AAI_PVP",k.." ("..GetV(V_HOMUNTYPE,k)..") Motion: "..FormatMotion(GetV(V_MOTION,k)).."Is monster? "..IsMonster(k))
			if IsHomun(MyID)==1 then
				TraceAI("PVP: Player "..k.." ("..GetV(V_HOMUNTYPE,k)..") Motion: "..FormatMotion(GetV(V_MOTION,k)).."Is monster? "..IsMonster(k))
			else
				TraceAI("PVP: Player "..k.."  Motion: "..FormatMotion(GetV(V_MOTION,k)).."Is monster? "..IsMonster(k))
			end
			if IsMonster(k)==1 then
				Targets[k] = {MotionClassLU[GetV(V_MOTION,k)],GetTargetClass(GetV(V_TARGET,k))}
			end
		end
	end
	
	--New autofriend routine
	if (NewAutoFriend==1 and AssumeHomun==1) then
		friendedOK=0
		retainercount=0
		for k,v in pairs(Retainers) do
			if (k~=MyID) then
				retainercount=retainercount+1
				if (MyFriends[k]==2) then
					friendedOK=1
				end
			end
		end	
		if (friendedOK==0) then
			local owner=GetV(V_OWNER,MyID)
			if (IsHomun(myid)==1) then
				InFile=io.open(ConfigPath.."data/M_"..owner..".txt","r")
			else
				InFile=io.open(ConfigPath.."data/H_"..owner..".txt","r")
			end
			if InFile~=nil then
				retainerid=InFile:read("*a")
				InFile:close()
				retainerid=tonumber(retainerid)
				if (retainerid ~=nil) then
					MyFriends[retainerid]=2
				end
			end
		end
	end
	--SP+Skillfail Watcher
	local clearcastskill=0  --There are a buncha globals that need to be zeroed when we're done watching for skill cast success or failure. However, after the initial round of skill failure checking, we still need to know what this skill was in order to check what the skill was. Also, we need to make sure we don't call FailSkillUse() if it looks like it failed, but the SP for it was used. So we set this to 1 if we see it successfully cast, 2 if failed, and then act appropriately afterwards.
	local sp = GetV(V_SP,MyID)
	if CastSkill~=0 then
		local castskillold = CastSkill
		local castskilloldlvl = CastSkillLevel -- remember these for the SP watcher down below. 
		local skillcastingtime = GetSkillInfo(CastSkill,4,CastSkillLevel)+GetSkillInfo(CastSkill,5,CastSkillLevel)*CastTimeRatio
		logappend("AAI_SKILLFAIL", "Skillfail Watcher active: "..FormatSkill(CastSkill,CastSkillLevel).."mode"..CastSkillMode.."delay "..LastAIDelay.." motion "..GetV(V_MOTION,MyID))
		if GetSkillInfo(CastSkill,4,CastSkillLevel)+GetSkillInfo(CastSkill,5,CastSkillLevel) == 0 then 
			if LastAIDelay > 500 then
				--Skill cast successfully
				TraceAI("Delay watcher: Skill use successful - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
				logappend("AAI_SKILLFAIL","successful skill use detected - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
				clearcastskill=1
				LastASAPTargBuffTime	=0
				LastASAPTargBuffTarg	=0
				LastASAPTargBuffMode	=0
			elseif GetTick() - CastSkillTime > 1000 then
				--Musta failed, we tried to use an instant cast skill 1 second ago and still no sign of it and no sign of delay.
				TraceAI("Delay watcher: no sign of instacast skill casting 1 second later - failed. mode: "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel))
				logappend("AAI_SKILLFAIL", "no sign of instacast skill casting 1 second later - failed. mode: "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel))
				clearcastskill=2
			end
		else
			if GetV(V_MOTION,MyID)==MOTION_CASTING then
				CastSkillState=1
			elseif CastSkillState>0 then
				if LastAIDelay > 220 then
					--Skill cast successfully
					if CastSkillMode==8 then
						if EleanorMode==1 then
							EleanorMode=0
						else
							EleanorMode=1
						end
						UpdateTimeoutFile()
					end
					TraceAI("Delay watcher: Skill use successful detected by delay - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
					logappend("AAI_SKILLFAIL","successful skill use detected by delay - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
					clearcastskill=1
				else
					CastSkillState=CastSkillState+1
					if CastSkillState > 2 then
						local flinch=0
						for v=1,10,1 do
							if MyMotions[v]==MOTION_DAMAGE then
								flinch=1
								break
							end
						end
						-- Ground targeted skills aren't interruptible! 
						if (flinch==1 and GetSkillInfo(CastSkill,7,CastSkillLevel)~=2) or skillcastingtime + AutoSkillTimeout + CastSkillTime < GetTick() then 
							TraceAI("Delay watcher: Skill casting detected, but no delay - cast was broken: "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." flinch: "..flinch.." expected cast completion: "..(skillcastingtime + CastSkillTime))
							logappend("AAI_SKILLFAIL", "Skill casting detected, but no delay - cast was broken: "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." flinch: "..flinch.." expected cast completion: "..(skillcastingtime + CastSkillTime))
							clearcastskill=2
						elseif skillcastingtime + CastSkillTime > GetTick() then
							TraceAI("Delay watcher: Skill use successful - was seen casting, and no sign of interruption, no delay. mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
							logappend("AAI_SKILLFAIL","Skill use successful - was seen casting, and no sign of interruption, no delay. mode"..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
							clearcastskill=1
						end
					end
				end
			else -- CastSkillState is 0, so the skill hasn't started casting, but just in case it slipped by:
				if LastAIDelay > 220 then
					--Skill cast successfully
					if CastSkillMode==8 then
						if EleanorMode==1 then
							EleanorMode=0
						else
							EleanorMode=1
						end
						UpdateTimeoutFile()
					end
					TraceAI("Delay watcher: Skill use successful - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
					logappend("AAI_SKILLFAIL","successful skill use detected - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
					clearcastskill=1
				elseif GetTick() - CastSkillTime > 1000 then
					TraceAI("Delay watcher: no sign of skill casting 1 second later - failed. mode: "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel))
					logappend("AAI_SKILLFAIL", "no sign of skill casting 1 second later - failed. mode: "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel))
					clearcastskill=2
				end
			end
		end
		-- sp watcher
		if sp-MyLastSP == RegenTick[1] - GetSkillInfo(castskillold,3,castskilloldlvl) or MyLastSP - sp == GetSkillInfo(castskillold,3,castskilloldlvl) then
			--if IsHomun(myid)==0 then
				TraceAI("SP watcher: Skill use successful - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
				logappend("AAI_SKILLFAIL","successful skill use detected by SP use - mode "..CastSkillMode.." skill "..FormatSkill(CastSkill,CastSkillLevel).." LastAIDelay "..LastAIDelay)
				clearcastskill=1
			--end
			if sp-MyLastSP == RegenTick[1] - GetSkillInfo(castskillold,3,castskilloldlvl) then
				LastSPTime=GetTick()
			end
		elseif MyLastSP<= sp then
			if sp-MyLastSP==RegenTick[1] and RegenTick[1]~=0 then
				LastSPTime=GetTick()
			end
		end
	else
		if sp-MyLastSP == RegenTick[1] and RegenTick[1]~=0 then 
			LastSPTime=GetTick()
		elseif sp-MyLastSP > 100 then
			-- do nothing, owner aid-potted it, ignore this
		elseif sp-MyLastSP > RegenTick[1] or (sp-MyLastSP < RegenTick[1] and sp-MyLastSP > 0)  then
			LastSPTime=GetTick()
			if sp-MyLastSP > math.floor(GetV(V_MAXSP,MyID)/100)+3 then -- this could be the correct tick to use
				for v=3,2,-1 do
					RegenTick[2][v]=RegenTick[2][v-1]
				end
				RegenTick[2][1]=sp-MyLastSP
				local tickcount=0
				for k,v in pairs(RegenTick[2]) do
					if v~=sp-MyLastSP then
						break
					end
					tickcount=k
				end
				if tickcount==3 then
					RegenTick[1]=sp-MyLastSP
					TraceAI("Watcher: New SP Regen tick set: "..RegenTick[1])
					logappend("AAI_SKILLFAIL","New SP Regen tick set: "..RegenTick[1])
					UpdateTimeoutFile()
				end
			end
		end
	end
	if clearcastskill==1 then
		if (CastSkill==MH_CBC or CastSkill==MH_EQC or CastSkill==MH_TINDER_BREAKER) then
			EleanorMode=0 --grappler
			UpdateTimeoutFile()
		elseif (CastSkill==MH_SONIC_CLAW or CastSkill==MH_SILVERVEIN_RUSH or CastSkill==MH_MIDNIGHT_FRENZY) then
			EleanorMode=1
			UpdateTimeoutFile()
		end
		SkillFailCount[CastSkillMode]=0
		--LavaSlideMode=constant
		if (LavaSlideMode==4 and CastSkill==MH_LAVA_SLIDE) then
			SightTimeout=GetTick()+500
		end
		CastSkill=0
		CastSkillLevel=0
		CastSkillMode=0
		CastSkillTime=0
		CastSkillState=0	
	elseif clearcastskill==2 then
			FailSkillUse(CastSkillMode)
	end
	MyLastSP=sp
	--###COMMAND PROCESSING###
	local msg	= GetMsg (myid)			-- command
	local rmsg	= GetResMsg (myid)		-- reserved command
	
	if msg[1] == NONE_CMD then
		if rmsg[1] ~= NONE_CMD then
			if List.size(ResCmdList) < 10 then
				List.pushright (ResCmdList,rmsg)
			end
		end
	else
		List.clear (ResCmdList)	-- »õ·Î¿î ¸í·ÉÀÌ ÀÔ·ÂµÇ¸é ¿¹¾à ¸í·ÉµéÀº »èÁ¦ÇÑ´Ù.  
		ProcessCommand (msg)	-- ¸í·É¾î Ã³¸® 
	end
	
	
	OnAImiddle()
	
	--###EMERGENCY HANDLING###
	
	-- Avoid Routine
	if (IsHomun(MyID)==1 and UseAvoid==1 and (GetTick()-AIInitTick) > 5000) then
		for i,v in ipairs(actors) do
			if MyAvoid[GetV(V_HOMUNTYPE,v)]==1 then
				os.exit()
			end
		end
	end
	if UseAutoHeal==1 then
		if DoHealingTasks(MyID) == 1 then
			return
		end
	end
	
	-- Prevent from being left behind
	-- Used only in critical (merc out of MoveBounds) situations
	-- Otherwise, IDLE_ST handles it
	
	local dist2owner=GetDistanceRect(MyID,GetV(V_OWNER,MyID))
	if (MyState ~=FOLLOW_ST and dist2owner > GetMoveBounds()) then
		MyState=FOLLOW_ST
	end
	--Cancel all action during the spawn invulnerability
	if (GetTick() < (MyStart + SpawnDelay)) then
		return
	end
	if OldHomunType==AMISTR and UseCastleDefend ==1 then
		if GetTick() > AutoSkillTimeout then
			local mytargetweight =0
			local ownertargetweight =0
			for k,v in pairs(Targets) do 
				if v[2]==1 then
					mytargetweight=mytargetweight+GetTact(TACT_WEIGHT,k)
				elseif v[2]==2 then
					if GetV(V_TARGET,k)==GetV(V_OWNER,MyID) then
						ownertargetweight=ownertargetweight+GetTact(TACT_WEIGHT,k)
					end
				end
			end
			if CastleDefendThreshold <= ownertargetweight and ownertargetweight > mytargetweight then
				DoSkill(HAMI_CASTLE,5,MyID)
			end
		end
	end
	object = SelectEnemy(GetEnemyList(MyID,-2))
	if (object~=0 and object ~= MyEnemy and MyState~=FOLLOW_ST) then
		MyEnemy=object
		MyState=CHASE_ST
		TraceAI("RESCUE ACTIVATED - Targeting "..object)
	end
	-- New in 1.51 - specialized cast react tactics. 
	for k,v in pairs(Targets) do
		if v[2]==1 or v[2] == 2 then
			tactcast= GetTact(TACT_CAST,k)
			if tactcast > CAST_REACT then
				local skill,level=0,0
				if tactcast > 1000 then
					for ii,vv in ipairs(GetTargetedSkills()) do
						if vv[2]==tactcast and vv[3]~=0 and vv[3]~=nil then
							skill=vv[2]
							level=vv[3]
							break
						end
					end
				else -- generic skill response. 
					for ii,vv in ipairs(GetTargetedSkills()) do
						if tactcast==9 and vv[2]~=0 and vv[3]~=0 and vv[3] ~=nil then
							skill=vv[2]
							level=vv[3]
							break
						elseif
							tactcast==vv[1]-10 and vv[2]~=0 and vv[3]~=0 and vv[3] ~=nil then
							skill=vv[2]
							level=vv[3]
							break
						end
					end
				end
				if skill~=0 then
					MySkill=skill
					MySkillLevel=level
					MyEnemy=k
					MyState=OnSKILL_OBJECT_CMD_ST
					TraceAI("CAST_REACT_(skill) being enabled against target"..k.." with tactic "..tactcast.." with "..FormatSkill(skill,level))
					break
				end
			elseif tactcast == CAST_REACT_STIEN then
				if GetV(V_HOMUNTYPE,MyID)==BAYERI then
					if AutoSkillTimeout < GetTick() and GetSkillInfo(MH_STEINWAND,3,5) < GetV(V_SP,MyID) then
						DoSkill(MH_STEINWAND,5,MyID)
						TraceAI("CAST_REACT_STIEN being enabled against target"..k.." with tactic "..tactcast)
					
						return
					end
				end
			elseif tactcast == CAST_REACT_CASTLE then
				if (modulo(GetV(V_HOMUNTYPE,MyID),4)==AMISTR or OldHomunType==AMISTR) and v[2]==2 then
					if AutoSkillTimeout < GetTick() and GetSkillInfo(HAMI_CASTLE,3,5) < GetV(V_SP,MyID) then
						DoSkill(HAMI_CASTLE,5,MyID)
						TraceAI("CAST_REACT_CASTLE being enabled against target"..k.." with tactic "..tactcast)
						return
					end
				end
			end
		end
	end

	if MyState~=PROVOKE_ST then
		if DoAutoBuffs(3) ~= 1 then
			logappend("AAI_ASAP","ASAP BUFF "..MyState)
			if MyState==PROVOKE_ST then --if we're looking at a targeted buff, this means it's an ASAP poison mist, painkiller, or lava slide
				MyASAPBuffs[1]=MyPSkill
			end
			return
		end
	end
	-- Check to see if mercenary should activate kiting routine
	if ((KiteMonsters==1 and (KiteOK(MyID)==1 or ForceKite == 1)) or HPPercent(MyID) < FleeHP) then
		local x,y=GetV(V_POSITION,MyID)
		if ((x==KiteDestX and y==KiteDestY) or (KiteDestX==0 and KiteDestY==0)) then
			local actors = GetActors()
			kitecalled=0
			for i,v in ipairs(actors) do
				if (IsMonster(v)==1 and GetV(V_MOTION,v) ~= MOTION_DEAD) then
					local target=GetV(V_TARGET,v)
					local tact = GetTact(TACT_KITE,v)
					if ((IsFriendOrSelf(target)==1 and tact==1) or tact==2) then
						local threshold
						if (IsFriend(target)==1 or target==MyID) then
							threshold=KiteThreshold
						else
							threshold=KiteParanoidThreshold
						end
						if (GetDistanceA(MyID,v) <= threshold) then
							TraceAI("Enemies close to me, start kite routine. ")
							DoKiteAdjust(MyID,v)
							kitecalled=1
							break
						end
					end
				end
			end
			if (kitecalled == 0) then
				KiteDestX,KiteDestY=0,0
			end
		else
			Move(myid,KiteDestX,KiteDestY)
		end
	end 
	--Stienwand autocast on tele stuff
	if GetTick() < SteinWandPauseTime then
		return
	end
	if UseSteinWandTele ==1 and GetV(V_HOMUNTYPE,MyID)==BAYERI then
		if SteinWandPauseTime == 0 then
			DoSkill(MH_STEINWAND,BayeriSteinWandLevel,MyID)
			SteinWandTimeout=AutoSkillCastTimeout+GetSkillInfo(MH_STEINWAND,8,BayeriSteinWandLevel)
			SteinWandPauseTime=SteinWandTelePause+GetTick()
			return
		end
	end
	--###STATE PROCESSES###
	--TraceAI("SP tracking: Time: "..GetTick().." last moved: "..LastMovedTime.." last sp time "..LastSPTime)
	if (LagReduction) then
		if LagReductionCD > 0 then
			LagReductionCD=LagReductionCD-1
		end
	end
 	if LagReductionCD > 0 then
 		TraceAI("Skipping state functions due to aggressive lag reduction")
 	elseif (MyState == IDLE_ST) then
		OnIDLE_ST ()
	elseif (MyState == CHASE_ST) then					
		OnCHASE_ST ()
	elseif (MyState == ATTACK_ST) then
		OnATTACK_ST ()
	elseif (MyState == FOLLOW_ST) then
		OnFOLLOW_ST ()
	elseif (MyState == MOVE_CMD_ST) then
		OnMOVE_CMD_ST ()
	elseif (MyState == STOP_CMD_ST) then
		OnSTOP_CMD_ST ()
	elseif (MyState == ATTACK_OBJECT_CMD_ST) then
		OnATTACK_OBJECT_CMD_ST ()
	elseif (MyState == ATTACK_AREA_CMD_ST) then
		OnATTACK_AREA_CMD_ST ()
	elseif (MyState == PATROL_CMD_ST) then
		OnPATROL_CMD_ST ()
	elseif (MyState == HOLD_CMD_ST) then
		OnHOLD_CMD_ST ()
	elseif (MyState == SKILL_OBJECT_CMD_ST) then
		OnSKILL_OBJECT_CMD_ST ()
	elseif (MyState == SKILL_AREA_CMD_ST) then
		OnSKILL_AREA_CMD_ST ()
	elseif (MyState == FOLLOW_CMD_ST) then
		OnFOLLOW_CMD_ST ()
	elseif (MyState == IDLEWALK_ST) then
		OnIDLEWALK_ST ()
	elseif (MyState == ORBITWALK_ST) then
		OnORBITWALK_ST()
	elseif (MyState == REST_ST) then
		OnREST_ST()
	elseif (MyState == TANKCHASE_ST) then
		OnTANKCHASE_ST()
	elseif (MyState == TANK_ST) then
		OnTANK_ST()
	elseif (MyState == PROVOKE_ST) then
		OnPROVOKE_ST()
	elseif (MyState == MOVE_CMD_HOLD_ST) then
		OnMOVE_CMD_HOLD_ST()
	elseif (MyState == FRIEND_CROSS_ST) then
		OnFRIEND_CROSS_ST()
	elseif (MyState == FRIEND_CIRCLE_ST) then
		OnFRIEND_CIRCLE_ST()
	else
		if NewState(MyState)==-1 then  
			TraceAI("Invalid State: "..MyState.." -> IDLE_ST")
			logappend("AAI_ERROR","MyState set to invalid state: "..MyState)
			MyState=IDLE_ST
		end
	end
	if (LagReduction) then
		modtwroSend()
	end
	OnAIEnd()
end
