-------------------------------
-- This file is part of AzzyAI 1.55
-- If you want to use these functions in your own AI
-- it is reccomended that you use the seperately available
-- version, which does not utilize AAI-specific systems. 
-- Written by Dr. Azzy of iRO Chaos
AUVersion="1.56"
-------------------------------




--[[
USAGE NOTES


HPPercent(id)
SPPercent(id)
Returns the current hp or sp of id as a percentage. This only works on things which the player can see the hp/sp of, obviously.

Closer(id,x,y)
Returns coordinants of a location 1 cell closer to actor (id) 

ClosestR(id1,id2,range)
Returns coordinants of the cell within <range> cells of <id2> that is closest to <id1>.
Intended for targeting of ranged skills.

BetterMoveToOwner(mercid,range)
Moves to the closest sell withing range cells of the owner. 

IsNotKS(id)
Returns 1 if attacking monster (id) would be a KS, 0 otherwise. 

IsFriend(id)
Returns 1 if (id) is the owner or a friend. 

@@@@@@@@@@@@@@@@@@@@@@@@@
@@@ Monster Functions @@@
@@@@@@@@@@@@@@@@@@@@@@@@@

GetMobCount(id,range,[id2])
Returns the number of monsters within range cells of the actor id, and the number of said monsters which are currently targeting id. If id2 is specified, monsters which are targeting id2 will also be included in the second value returned. 
Useful for deciding whether to use anti-mob skills.
ex:
local mobcount,aggrocount = GetMobCount(MyID,1,GetV(V_OWNER,MyID))

GetBestBrandishTarget(id)
Returns the id of the best monster adjacent to the mercenary to use brandish spear on (that is, the target that will result in the most monsters being hit). 
Assumes level 1 brandish area. 

ex:
SkillObject(MyID,MySkillLevel,ML_BRANDISH,GetBestBrandishTarget(MyID))


@@@@@@@@@@@@@@@@@@@@@@@
@@@ Skill Functions @@@
@@@@@@@@@@@@@@@@@@@@@@@

GetAtkSkill(id)
Returns a list containing skill id, skill level of the mercenary's single target offencive skill. Crash is not returned in this list, because the damage output spamming crash is lower than the damage output from using normal attacks. 

ex: 
local skill,level= GetAtkSkill(MyID)

GetMobSkill(merctype)
As GetAtkSkill() only for antimob skills

ex
local skill,level = GetMobSkill(MyID)

GetQuickenSkill(id)
Returns a list containing the ID of the weapon quicken skill posessed by the mercenary and the skill level

ex
local skill,level = GetQuickenSkill(MyID)

GetGuardSkill(id)
As GetQuickenSkill() only returns the ID of the guard or parry skill posessed by the mercenary. 

GetSacrificeSkill(id)
As GetQuickenSkill() only returns the ID and other perameters for the Sacrifice (aka Devotion) skill posessed by the mercenary.

GetProvokeSkill(id)
As GetQuiceknSkill() only returns the ID and other perameters for the Provoke skill posessed by the mercenary. 

GetPushbackSkill(id)
As GetMobSkill() only returns the ID and other perameters for the pushback skill (arrow repel or skid trap) posessed by the mercenary

--]]--


--#########################
--### Tactics Functions ###
--######################### 

function 	GetTact(t,m)
	local x
	if m==nil then
		TraceAI("GetTact: Error - nil target")
		logappend("AAI_ERROR","GetTact: Error - nil target")
	end
	if t==nil then
		TraceAI("GetTact: Error - nil tactic target:"..m)
		logappend("AAI_ERROR","request for tactic type nil target:"..m)
	end
	if (IsPlayer(m)==1) then
		if (PVPmode~=0) then
			TraceAI("GetTact: Returning pvp tactic")
			return GetPVPTact(t,m)
		else
			TraceAI("GetTact: not pvp mode returning 0")
			return 0
		end
	end
	local e = 0
	if (IsHomun(MyID)==0) then 
		if (MobID[m]==nil) then
			e=GetClass(m)
		else
			e=MobID[m]
		end
	else
		e=GetV(V_HOMUNTYPE,m)
	end
	temp=GetMyTact(e)
	if (temp==nil) then
		if (e >= 1324 and e <= 1363) or (e >= 1938 and e <=1946) then
			temp=GetMyTact(13)
			TraceAI("GetTact: No tactic "..t.." for "..e.."actor: "..m.." but it's a treasure chest.")
		end
		if temp==nil then
			temp=GetMyTact(0)
			--TraceAI("GetTact: No tactic "..t.." for "..e.."actor: "..m.." using default instead")
		end
	end
	if (temp[t]==nil) then
		temp=GetMyTact(0)
		TraceAI("GetTact: Undefined tactic "..t.." for "..e.."actor: "..m.." using default instead")
	end
	x=temp[t]
	if (x==nil) then
		logappend("AAI_ERROR","Default tactic "..t.." is undefined - Please review and correct tactics file or restore default tactics file")
		return 0
	else
		if t==TACT_SP and x==-1 then
			x = AttackSkillReserveSP
		elseif t==TACT_CHASE then
			--TraceAI("TactChase called"..GetV(V_SP,MyID).." "..ChaseSPPauseSP.." "..GetTick().." "..math.max(LastMovedTime,LastSPTime).." "..(5000-ChaseSPPauseTime))
			if GetV(V_SP,MyID) < ChaseSPPauseSP and (GetTick() - math.max(LastMovedTime,LastSPTime)) > (5000-ChaseSPPauseTime) then 
				if ((ChaseSPPause==1 and x~=CHASE_ALWAYS) or x==CHASE_CLEVER) then
					TraceAI("Cleverchase activated: "..m.." ("..e..") ".." LastTick "..math.max(LastMovedTime,LastSPTime))
					return 1
				end
			end
			if x==CHASE_ALWAYS then
				return 0
			elseif x==CHASE_NEVER then
				return 1
			else
				return DoNotChase
			end
		end
		return x
	end
end

function GetMyTact(m)
	return MyTact[m]
end

function	GetPVPTact(t,m)
	local x
	local class
	local e = ENEMY
	if IsMonster(m)==0 then
		TraceAI("pvp tact lookup on ally")
		e= ALLY
	end
	if (MyPVPTact[m]~=nil) then
		e = m
	elseif (MyFriends[m]~=nil) then
		e = MyFriends[m]
	end
	if IsHomun(MyID)==1 then
		class=GetV(V_HOMUNTYPE,m)
	end
	if MyPVPTact[m]~=nil then
		x=MyPVPTact[m][t]
	elseif e~=ALLY and class~=nil then 
		if MyPVPTact[class] ~=nil then
			x=MyPVPTact[class][t]
		end
	elseif MyFriends[e]==nil then
		x=MyPVPTact[e][t]
	end
	if x==nil then
		x=MyPVPTact[0][t]
	end
	if (x==nil) then
		TraceAI("ERROR: Default PVP tactic "..t.." is undefined!")
		logappend("AAI_ERROR","Default PVP tactic "..t.." is undefined! Please correct your PVP tactics file")
		return 0
	else	
	TraceAI("pvp TL on P "..m.."IsMonster "..IsMonster(m).." type "..e.." for tactic "..t.." returning "..x)
		return x
	end
end

function	GetClass(m)
	if (m < MagicNumber) then
		return 10
	elseif (IsActive[m]==0 and AutoDetectPlant==1) then
		return 11
	else
		return 0
	end
end

function IsRescueTarget(id)
	local tactrescue=GetTact(TACT_RESCUE,id)
	local target=GetV(V_TARGET,id)
	local owner=GetV(V_OWNER,MyID)
	if target==owner then
		local hp = HPPercent(owner)
		if RescueOwnerLowHP > hp then
			TraceAI("RescueOwnerLowHP -> rescue owner from "..id)
			return 1
		elseif RescueOwnerLowHP < 0 and -1*RescueOwnerLowHP < hp then
			TraceAI("RescueOwnerLowHP -> rescue of owner canceled "..id)
			return 0
		end
	end
	if tactrescue==RESCUE_NEVER then
		return 0
	else	
		TraceAI("tactrescue not never "..tactrescue.." id "..id)
		if tactrescue==RESCUE_RETAINER then
			if MyFriends[target]==2 then
				return 1
			end
		elseif tactrescue==RESCUE_FRIEND then
			if MyFriends[target]==1 then
				return 1
			end
		elseif tactrescue==RESCUE_ALL then
			if IsFriendOrSelf(target)==1 and target ~=MyID then
				return 1
			end
		elseif tactrescue==RESCUE_OWNER then
			if target==GetV(V_OWNER,MyID) then
				return 1
			end
		elseif tactrescue==RESCUE_SELF then
			if target==MyID then
				return 1
			end
		end
	end
	return 0
end

function GetTargetClass(id)
-- 0 = no target, 1 = self 2= friend, -1 = other monster -2 = other player
	if id == MyID then
		return 1
	elseif id == 0 then
		return 0
	elseif (id > MagicNumber2) then
		if IsFriendOrSelf(id)==1 then
			return 2
		else
			return -2
		end
	elseif IsMonster(id)==1 then
		return -1
	else
		return 0
	end
end

--########################
--### Friend Functions ###
--########################


function IsFriend(id)
	if (id==GetV(V_OWNER,MyID)) then
		return 1
	elseif (id~= MyID) then
		friendclass=MyFriends[id]
		if (friendclass==FRIEND or friendclass==RETAINER) then
			return 1
		end
	end
	return 0
end

function IsPVPFriend(id)
	if (id==GetV(V_OWNER,MyID)) then
		return 1
	elseif (id~= MyID) then
		friendclass=MyFriends[id]
		if (friendclass==FRIEND or friendclass==RETAINER or friendclass==NEUTRAL or friendclass==ALLY or friendclass==NEUTRAL) then
			return 1
		end
	end
	return 0
end

function IsFriendOrSelf(id)
	if (id==GetV(V_OWNER,MyID) or id == MyID) then
		return 1
	else
		if (MyFriends[id]~=nil) then
			return 1	
		end
	end
	return 0
end

function IsPlayer(id)
	if (id>MagicNumber2) then
		return 1
	else
		return 0
	end
end

function UpdateFriends() 
	FriendsFile = io.open(ConfigPath.."A_Friends.lua", "w")
	if FriendsFile~=nil then
		FriendsFile:write (STRING_A_FRIENDS_HEAD)
		for k,v in pairs(MyFriends) do
			if (v==FRIEND or (v==PKFRIEND and PainkillerFriendsSave == 1)) then
				FriendsFile:write ("MyFriends["..k.."]="..v.." -- \n")
			end
		end
		FriendsFile:close()
	else
		TraceAI("Failed to open A_Friends.lua for writing!")
		logappend("AAI_ERROR","Failed to open A_Friends.lua for writing!")
	end
end

--########################
--### Monster functions###
--########################


function GetAggroCount(target)
	local aggrocount=0
	if target ==nil then
		for k,v in pairs(Targets) do
			if v[2] > 0 then -- it's aggressive
				distance = GetDistanceA(GetV(V_OWNER,MyID),k)
				if (distance <= GetMoveBounds()) then
					aggrocount=aggrocount+1*GetTact(TACT_WEIGHT,k)
				end
			end
		end
	else
		for k,v in pairs(Targets) do
			if GetV(V_TARGET,k)==target then
				aggrocount=aggrocount+1*GetTact(TACT_WEIGHT,k)
			end
		end
	end
	return aggrocount
end

function GetMobCount(skill,level,target,aggro)
	local mobcount=0
	if skill==0 or level==0 then 
		return 0
	end
	local skillaoe=SkillAOEInfo[skill][1][level]
	local x,y=GetV(V_POSITION,MyID)
	if skillaoe==nil then
		if skill == ML_BRANDISH then
			for k,v in pairs (Targets) do
				if GetV(V_MOTION,k)~=MOTION_DEAD then
					if (GetDistanceA(myid,k)<=1 and GetDistanceA(target,k) <=1 and (v[2]>0 or aggro~=0)) then
						mobcount=mobcount+1*GetTact(TACT_WEIGHT,k)
					elseif (GetDistanceA(myid,k) ==2 and GetDistance3(myid,k) < 2.5 and GetDistance3(target,k) < 2.5 and (v[2]>0 or aggro~=0)) then -- sides, 2 cells to either side of target/merc
						mobcount=mobcount+1*GetTact(TACT_WEIGHT,k)
					end
				end
			end
		elseif skill== MA_SHARPSHOOTING then
			mx,my=GetV(V_POSITION,target)
			dx=math.abs(x-mx)
			dy=math.abs(y-my)
			if ((dx==0) or (dx==1 and dy>1) or (dx==2 and dy>6) or (dx==3 and dy>9) or (dx==4 and dy>11)) then 
				if my>y then
					mobcount=GetFASTargetCount(MyID,0,1,aggro)
				elseif my<y then
					mobcount=GetFASTargetCount(MyID,0,-1,aggro)
				end
			elseif ((dy==0) or (dy==1 and dx>1) or (dy==2 and dx>6) or (dy==3 and dx>9) or (dy==4 and dx>11)) then
				if mx>x then
					mobcount=GetFASTargetCount(MyID,1,0,aggro)
				elseif mx<x then
					mobcount=GetFASTargetCount(MyID,-1,0,aggro)
				end
			-- diagonals
			elseif mx>x then
				if my>y then
					mobcount=GetFASTargetCount(MyID,1,1,aggro)
				else
					mobcount=GetFASTargetCount(MyID,-1,1,aggro)
				end
			elseif my>y then
				mobcount=GetFASTargetCount(MyID,1,-1,aggro)
			else
				mobcount=GetFASTargetCount(MyID,-1,-1,aggro)
			end
		end
	else -- we have a wellbehaved skill
		if GetSkillInfo(skill,7)==0 then
			target=MyID
		end
		range=(skillaoe-1)/2
		local logstring=""
		for k,v in pairs(Targets) do
			local tbas=GetTact(TACT_BASIC,k)
			local dist = GetDistanceAR(target,k)
			logstring=logstring.."|"..k.."v[2]"..v[2].."t"..GetV(V_TARGET,k).."m"..GetV(V_MOTION,k).."aggro"..aggro
			if dist <= range and (v[2]>0 or aggro~=0) and tbas~=0 then
				mobcount=mobcount+1*GetTact(TACT_WEIGHT,k)
				logstring=logstring.."add:"..GetTact(TACT_WEIGHT,k).."new:"..mobcount
			end			
		end
		logappend("AAI_MOBCOUNT","Mobcount on well-behaved skill "..FormatSkill(skill,level).." range "..range.." logstring: "..logstring.." result: "..mobcount)
	end
	return mobcount
end

function GetBestAoETarget(myid,skill,level)
	local mcount=0
	local result=-1
	for k,v in pairs(Targets) do
		if mcount < GetMobCount(skill,level,k,1) then
			result=k
			mcount=GetMobCount(skill,level,k,1)
		end
	end
	return result
end

function GetBestAoECoord(myid,skill,level)
	local mcount =0
	local resultx = -1
	local resulty = -1
	local range=GetSkillInfo(skill,2,level)
	local aoesize=(SkillAOEInfo[skill][1][level]-1)/2
	local myx
	local myy
	myx,myy=GetV(V_POSITION,myid)
	local ox,oy=GetV(V_POSITION,GetV(V_OWNER,MyID))
	grid={}
	for xx=ox-20,ox+20 do
		grid[xx]={}
		--for xx=oy-20,oy+20 do
		--	grid[xx][yy]=0
		--end
	end
	for k,v in pairs(Targets) do
		local tbas = GetTact(TACT_BASIC,k)
		x,y=GetV(V_POSITION,k)
		if x < ox+20 and x > ox-20 and y < oy+20 and y > oy-20 and tbas~=0 then 
			if grid[x][y]==nil then
				grid[x][y]=GetTact(TACT_WEIGHT,k)
			else
				grid[x][y]=grid[x][y]+GetTact(TACT_WEIGHT,k)
			end
		end
	end
	for xx=myx-range,myx+range do
		for yy=myy-range,myy+range do
			local thiscount=0
			for xxx=xx-aoesize,xx+aoesize do
				if grid[xxx]~=nil then
					for yyy=yy-aoesize,yy+aoesize do
						if grid[xxx][yyy] ~=nil then
							thiscount=thiscount+grid[xxx][yyy]
						end
					end
				end
			end
			if thiscount>mcount then
				mcount=thiscount
				resultx,resulty=xx,yy
			end
		end
	end
	return resultx,resulty
end

function GetBestBrandishTarget(myid)
	local mobs =0
	local maxmobs = 0
	local besttarget= -1
	for k,v in pairs(Targets) do
		if (GetDistanceA(myid,k) <=1) then --Is a target in range to brandish
			mobs = 0
			for kk,vv in pairs (Targets) do
				local tbas=GetTact(TACT_BASIC,kk)
				if tbas ~= 0 then
					if (GetDistanceA(myid,kk)<=1 and GetDistanceA(k,kk) <=1) then
						mobs=mobs+1
					elseif (GetDistanceA(myid,kk) ==2 and GetDistance3(myid,kk) < 2.5 and GetDistance3(k,kk) < 2.5)then -- sides, 2 cells to either side of target/merc
						mobs=mobs+1
					end
				end
			end
			if (mobs > maxmobs) then
				maxmobs = mobs
				besttarget = v
			end
		end
	end
	return besttarget
end

function GetBestFASTarget(myid)
	local options = GetFASOptions(myid)
	local mincount=0
	local target=-1
	for x,v in pairs(options) do
		for y,v2 in pairs(v) do
			--TraceAI("GetBestFAST "..x.." "..y.." "..v2)
			if v2~=0 then
				count=GetFASTargetCount(myid,x,y)
				if count > mincount then
					mincount = count
					target = v2
				end
			end
		end
	end
	return target,mincount			
end

function GetFASDirection(myid,target)
	local x,y=GetV(V_POSITION,myid)
	if GetDistanceA(myid,target) < 15 then
		local mx,my=GetV(V_POSITION,target)
		local dx=math.abs(x-mx)
		local dy=math.abs(y-my)
		if ((dx==0) or (dx==1 and dy>1) or (dx==2 and dy>6) or (dx==3 and dy>9) or (dx==4 and dy>11)) then 
			if my>=y then
				return 0,1 --n
			elseif my<y then
				return 0,-1 --s
			end
		elseif ((dy==0) or (dy==1 and dx>1) or (dy==2 and dx>6) or (dy==3 and dx>9) or (dy==4 and dx>11)) then
			if mx>x then
				return 1,0 --e
			elseif mx<x then
				return-1,0 --w
			end
		-- diagonals
		elseif mx>x then
			if my>=y then
				return 1,1 --ne
			else
				return 1,-1 --se
			end
		elseif my>=y then
			return -1,1 --nw
		else
			return -1,-1 --sw
		end
	end
end

function GetFASOptions(myid)
	local x,y=GetV(V_POSITION,myid)
	noption=0
	eoption=0
	soption=0
	woption=0
	neoption=0
	nwoption=0
	seoption=0
	swoption=0
	for k,v in pairs(Monsters) do
		TraceAI("FAS loop id: "..k)
		if GetDistanceA(myid,k) < 15 then
			mx,my=GetV(V_POSITION,k)
			dx=math.abs(x-mx)
			dy=math.abs(y-my)
			if ((dx==0) or (dx==1 and dy>1) or (dx==2 and dy>6) or (dx==3 and dy>9) or (dx==4 and dy>11)) then 
				if my>y then
					noption=k
				elseif my<y then
					soption=k
				end
			elseif ((dy==0) or (dy==1 and dx>1) or (dy==2 and dx>6) or (dy==3 and dx>9) or (dy==4 and dx>11)) then
				if mx>x then
					eoption=k
				elseif mx<x then
					woption=k
				end
			-- diagonals
			elseif mx>x then
				if my>=y then
					neoption=k
				else
					seoption=k
				end
			elseif my>=y then
				nwoption=k
			else
				swoption=k
			end
		end
		if (noption~=0 and soption~=0 and eoption~=0 and woption~=0 and neoption~=0 and seoption~=0 and swoption~=0 and nwoption~=0) then
			TraceAI("All Options Avail - break")
			break
		end
	end
	result={[-1]={[-1]=swoption,[0]=woption,[1]=nwoption},[0]={[-1]=soption,[0]=0,[1]=noption},[1]={[-1]=seoption,[0]=eoption,[1]=neoption}}
	TraceAI("Returning FAS Options: "..swoption.."-"..woption.."-"..nwoption.." "..soption.."--"..noption.." "..seoption.."-"..eoption.."-"..neoption)
	return result
end

function GetFASTargetCount(myid,directionx,directiony,aggro)
	local x,y=GetV(V_POSITION,myid)
	local s=directionx+directiony
	TraceAI("GFASTC: "..s)
	count=0
	if s==1 or s==-1 then -- straight
		if directiony==0 then --Horizontal
			ymin=y-1
			ymax=y+1
			if directionx==1 then --East
				xmin=x
				xmax=x+14
			else
				xmin=x-14
				xmax=x
			end
		else	--Vertical
			xmin=x-1
			xmax=x+1
			if directiony==1 then -- north
				ymin=y
				ymax=y+14
			else
				ymin=y-14
				ymax=y
			end
		end
		for k,v in pairs(Targets) do
			mx,my=GetV(V_POSITION,k)
			--logappend("AAI_mobcount","straight monster:"..xmin.."-"..xmax..","..ymin.."-"..ymax.." "..mx..","..my)
			if GetTact(TACT_BASIC,k)~=0 and mx>=xmin and xmax>=mx and my>=ymin and ymax>=my then
				count=count+1
			end
		end
		--logappend("AAI_mobcount","straight:"..xmin.."-"..xmax..","..ymin.."-"..ymax.." count"..count)
		return count
	else	--Diagonal
		count = 0
		for k,v in pairs(Targets) do
			if GetTact(TACT_BASIC,k)~=0 and IsNotKS(MyID,k)==1 then
				mx,my=GetV(V_POSITION,k)
				if directionx==1 then --east
					if (mx+1>=x and x+14>=mx) then -- has prayer of hitting
						if mx==x-1 then
							if my==y+directiony then
								count=count+1
							end
						elseif mx==x then
							if (my==y or my==y+directiony or my==y+2*directiony) then
								count=count+1
							end
						elseif mx==x+14 then
							if my==y+12*directiony then
								count=count+1
							end
						elseif mx==x+13 then
							if (my==y+11*directiony or my==y+10*directiony or my==y+12*directiony) then
								count=count+1
							end
						else	--not a special case
							if directiony==1 then
								miny=y-2+(mx-x)
								maxy=miny+5
							else
								maxy=y+2-(mx-x)
								miny=maxy-5
							end
							if my>=miny and maxy>=my then
								count=count+1
							end
						end
					end
				else --west
					if mx-1<=x and x-14<=mx then -- has prayer of hitting
						if mx==x+1 then
							if my==y+directiony then
								count=count+1
							end
						elseif mx==x then
							if (my==y or my==y+directiony or my==y+2*directiony) then
								count=count+1
							end
						elseif mx==x-14 then
							if my==y+12*directiony then
								count=count+1
							end
						elseif mx==x-13 then
							if (my==y+11*directiony or my==y+10*directiony or my==y+12*directiony) then
								count=count+1
							end
						else	--not a special case
							if directiony==1 then
								miny=y-2+(x-mx)
								maxy=miny+5
							else
								maxy=y+2-(x-mx)
								miny=maxy-5
							end
							if my>=miny and maxy>=my then
								count=count+1
							end
						end
					end
				end
			end
		end
		--logappend("AAI_mobcount","diagonal:"..count)
	end
	return count
end

function IsHiddenOnScreen(myid) --Currently disabled - assume there is never hidden on screen.
	return 1
end

function IsHomun(myid)
	if (GetV(V_HOMUNTYPE,myid)~=nil) then
		return 1
	end
	return 0

end

function GetMerType(myid)
	local merctype=GetV(V_MERTYPE,myid)
	TraceAI("Merc is homun?"..IsHomun(myid))
	if (merctype~=1) then
		return merctype
	elseif merctype > 30 then
		logappend("AAI_ERROR","Invalid merctype reported"..merctype)
		return merctype
	else
		mhp=GetV(V_MAXHP,myid)
		msp=GetV(V_MAXSP,myid)
		if (mhp > 250 and mhp < 333 and msp >= 200 and 250 >= msp ) then -- it's an archer 1
			return ARCHER01
		elseif (mhp == 7513 and msp == 201) then 
			TraceAI("Newly summoned Pengineer")
			return PENGINEER
		elseif (mhp >= 4000 and 5000 >= mhp and msp >= 50 and msp < 65 ) then -- looks like a kitty!
			TraceAI("Wild Rose")
			return WILDROSE
		elseif (mhp >= 7513 and 8500 >= mhp and msp >= 201 and msp < 250 ) then 
			TraceAI("Pengineer")
			return PENGINEER
		elseif (mhp >= 7200 and 7512 >= mhp and msp >= 200 and msp < 250 ) then -- looks like a dopple!
			TraceAI("Dopple Merc")
			return DOPPLEMERC
		elseif (mhp >= 10000 and 13000 >= mhp and msp >= 220 and msp < 300 ) then -- looks like alice!
			TraceAI("Alice")
			return ALICE
		elseif	(mhp >= 6100 and 7200 >= mhp and msp >= 180 and msp < 250 ) then -- looks like a mimic!
			TraceAI("Mimic")
			return MIMIC
		elseif (mhp >= 7500 and 9500 >= mhp and msp >= 180 and msp < 220 ) then -- looks like a disguise!
			TraceAI("Disguise")
			return DISGUISE
		elseif (mhp >= 7000 and 8500 >= mhp and msp >= 250 and msp < 320 ) then -- looks like a male GM mercenary!
			TraceAI("GM Mercenary")
			return GMMALE
		elseif (mhp > 12300 and 14500 >= mhp and msp >= 450 and msp < 600 ) then -- Nice stats, must be one of them overpowerd isis mercs
			TraceAI("ISIS Mercenary")
			return ISIS
		else
			TraceAI("Unknown merc type. Contact the developer ASAP.") 
			return UNKNOWNMER
		end
	end
end

function IsNotKS(myid,target)
	--TraceAI("Checking for KS:"..target)
	local targettarget=GetV(V_TARGET,target)
	local motion=GetV(V_MOTION,target)
	local tactks=GetTact(TACT_KS,target)
	if (target==MyEnemy and BypassKSProtect==1) then --If owner has told homun to attack explicity, let it.
		return 1
	end
	if target==nil then
		TraceAI("IsNotKS")
	end
	if (IsPlayer(target)==1) then
		--TraceAI("PVP - not KS")
		return 1
	elseif (IsFriend(targettarget)==1 or targettarget==myid) then
		--TraceAI("Not KS - "..target.." fighting friend: "..targettarget)
		return 1
	elseif ((tactks==KS_POLITE or DoNotAttackMoving ==1) and motion==MOTION_MOVE) then
		return 0
	elseif (tactks==KS_ALWAYS) then
		--TraceAI("It's an FFA monster, not a KS")
		return 1
	elseif targettarget > 0 and IsMonster(targettarget)~=1 and Actors[targettarget]==1 then
		--TraceAI("Is KS - "..target.." attacking player "..targettarget.." motion "..motion)
		return 0
	else
		--TraceAI("Not Targeted - seeing if anyone is targeting it")
		local actors = GetActors()
		for i,v in ipairs(actors) do
			if (IsMonster(v)~=1 and IsFriendOrSelf(v)==0) then
				if (GetV(V_TARGET,v) == target and (v > 100000 or KSMercHomun ~=1)) then
					--TraceAI("Is KS - "..target.." is targeted by "..v)
					return 0
				end
			end
		end
	--TraceAI("Not KS - "..target.." is not targeted by any other player.")
	return 1
	end
end
function GetKSReason(myid,target)
	--TraceAI("Checking for KS:"..target)
	local targettarget=GetV(V_TARGET,target)
	local motion=GetV(V_MOTION,target)
	local tactks=GetTact(TACT_KS,target)
	if (target==MyEnemy and BypassKSProtect==1) then --If owner has told homun to attack explicity, let it.
		return "KS Protect bypassed"
	end
	if target==nil then
		TraceAI("IsNotKS")
	end
	if (IsPlayer(target)==1) then
		--TraceAI("PVP - not KS")
		return "PVP, not KS"
	elseif ((tactks==KS_POLITE or DoNotAttackMoving ==1) and motion==MOTION_MOVE) then
		return "KS polite aka DoNotAttackMoving"
	elseif (IsFriend(targettarget)==1 or targettarget==myid) then
		--TraceAI("Not KS - "..target.." fighting friend: "..targettarget)
		return "Not KS - enemy attacking "..targettarget
	elseif (tactks==KS_ALWAYS) then
		--TraceAI("It's an FFA monster, not a KS")
		return "FFA monster"
	elseif targettarget > 0 and IsMonster(targettarget)~=1 and Actors[targettarget]==1 then
		--TraceAI("Is KS - "..target.." attacking player "..targettarget.." motion "..motion)
		if MyFriends[targettarget]~=nil then
			return "KS - enemy is attacking "..targettarget.." MyFriends: "..MyFriends[targettarget]
		else
			return "KS - enemy is attacking "..targettarget
		end
	else
		--TraceAI("Not Targeted - seeing if anyone is targeting it")
		local actors = GetActors()
		for i,v in ipairs(actors) do
			if (IsMonster(v)~=1 and IsFriendOrSelf(v)==0) then
				if (GetV(V_TARGET,v) == target and (v > 100000 or KSMercHomun ~=1)) then
					--TraceAI("Is KS - "..target.." is targeted by "..v)
					if MyFriends[v]~=nil then
						return "KS - enemy attacked by "..v.." MyFriends: "..MyFriends[v]
					else
						return "KS - enemy attacked by "..v
					end
				end
			end
		end
	--TraceAI("Not KS - "..target.." is not targeted by any other player.")
	return "not KS, not targeted by anything"
	end
end
--########################
--### HP/SP % functions###
--########################

function HPPercent(id)
	local maxHP=GetV(V_MAXHP,id)
	local curHP=GetV(V_HP,id)
	percHP=100*curHP/maxHP
	return percHP
end

function SPPercent(id)
	local maxSP=GetV(V_MAXSP,id)
	local curSP=GetV(V_SP,id)
	percSP=100*curSP/maxSP
	return percSP
end

--########################
--### Spacial functions###
--########################
OldMove=Move

function Move(myid,x,y)
	local ox,oy = GetV(V_POSITION,myid)
	local dis = GetDistance(ox,oy,x,y)
	local dis2owner=GetDistanceAPR(GetV(V_OWNER,myid),x,y)
	local newx,newy=x,y
	if dis2owner > 14 then 
		logappend("AAI_ERROR","Attempt to move to location "..x..","..y.." which is "..dis2owner.." cells from owner, call disregarded")
		return 
	elseif dis > 15  then
		--factor = 14/dis
		factor=0.5+((math.random(3)-2)*0.1)
		if dis > 25 then 
			factor =0.4+((math.random(3)-2)*0.1)
		end
		local dx,dy = x-ox,y-oy
		if math.random(2)==1 then
			dx=math.ceil(factor*dx)
		else 
			dx=math.floor(factor*dx)
		end
		if math.random(2)==1 then
			dy=math.ceil(factor*dy)
		else 
			dy=math.floor(factor*dy)
		end
		if _VERSION=="Lua 5.1" then 
			while TakenCells[(x+dx).."_"..(y+dy)] do
				factor=factor-0.08
				if math.random(2)==1 then
					dx=math.ceil(factor*(x-ox))
				else 
					dx=math.floor(factor*(x-ox))
				end
				if math.random(2)==1 then
					dy=math.ceil(factor*(y-oy))
				else 
					dy=math.floor(factor*(y-oy))
				end
			end
		end
		if x==MyDestX and y==MyDestY then
			newx=ox+dx
			newy=oy+dy
			MyDestX,MyDestY=newx,newy
			TraceAI("MOVE: Attempt to move more than 15 cells, destination + MyDest adjusted: "..x..","..y.." "..dis.." "..factor.."new: "..newx..","..newy)
		else
			newx=ox+dx
			newy=oy+dy
			TraceAI("MOVE: Attempt to move more than 15 cells, destination adjusted: "..x..","..y.." "..dis.." "..factor.."new: "..newx..","..newy)
		end
	end
	if (LagReduction and LagReduction ~=0) then
		modtwROMoveX,modtwROMoveY=x,y
		return
	else 
		return OldMove(myid,newx,newy)
	end
end


OldSkillObject=SkillObject
function SkillObject(myid,lvl,skill,target)
	if skill==8041 or skill==8043 or skill==8020 or skill==8025 then
		logappend("AAI_ERROR","Attempted to use skill "..SkillInfo[skill][1].." improperly. Check for corrupt H_SkillInfo or badly behaved addon")
	else
		if (LagReduction and LagReduction ~=0) then
			modtwROSkillObjectID=skill
			modtwROSkillObjectLV=lvl
			modtwROSkillObjectTarg=target
		else
			return OldSkillObject(myid,lvl,skill,target)
		end
	end
end

OldAttack=Attack
function Attack(myid,target)
	if SuperPassive==1 then
		TraceAI("Notice: Attack() called while in SuperPassive. MyEnemy "..MyEnemy.." MyState "..MyState)
	end
	if (LagReduction and LagReduction ~=0) then
		modtwROAttackTarget=target
	else
		return OldAttack(myid,target)
	end
end

OldSkillGround=SkillGround
function SkillGround(myid,lvl,skill,x,y)
	if (LagReduction and LagReduction ~=0) then
		modtwROSkillGroundX=x
		modtwROSkillGroundY=y
		modtwROSkillGroundID=skill
		modtwROSkillGroundLV=lvl
	else
		return OldSkillGround(myid,lvl,skill,x,y)
	end
end

function	GetDistance (x1,y1,x2,y2)
	return math.floor(math.sqrt((x1-x2)^2+(y1-y2)^2))
end

function	GetDistance2 (id1, id2)
	local x1, y1 = GetV (V_POSITION,id1)
	local x2, y2 = GetV (V_POSITION,id2)
	if (x1 == -1 or x2 == -1) then
		return -1
	end
	return GetDistance (x1,y1,x2,y2)
end


function	GetDistanceA (id1, id2)
	local x1, y1 = GetV (V_POSITION,id1)
	local x2, y2 = GetV (V_POSITION,id2)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return GetDistance (x1,y1,x2,y2)
end

function	GetDistanceAP (id1, x2,y2)
	local x1, y1 = GetV (V_POSITION,id1)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return GetDistance (x1,y1,x2,y2)
end

function	GetDistanceAPR (id1, x2,y2)
	local x1, y1 = GetV (V_POSITION,id1)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	local x=x1-x2
	local y=y1-y2
	return math.max(math.abs(x),math.abs(y))
end

function GetDistanceRect(id1,id2)
	local x1, y1 = GetV (V_POSITION,id1)
	local x2, y2 = GetV (V_POSITION,id2)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	local x=x1-x2
	local y=y1-y2
	return math.max(math.abs(x),math.abs(y))
end

function GetDistance3(id1,id2) 
	local x1, y1 = GetV (V_POSITION,id1)
	local x2, y2 = GetV (V_POSITION,id2)
	if (x1 == -1 or x2 == -1) then
		return -1
	end
	return math.sqrt((x1-x2)^2+(y1-y2)^2)
end

function GetAggroDist()
	if OwnerPosX[10]==OwnerPosX[1] and OwnerPosY[10]==OwnerPosY[1] then
		return StationaryAggroDist
	else
		return MobileAggroDist
	end
end

function GetMoveBounds()
	if OwnerPosX[10]==OwnerPosX[1] and OwnerPosY[10]==OwnerPosY[1] then
		return StationaryMoveBounds
	else
		return MobileMoveBounds
	end
end
function IsToRight(id1,id2)
	local x1,y1=GetV(V_POSITION,id1)
	local x2,y2=GetV(V_POSITION,id2)
	if (x1+1==x2 and y1==y2) then
		return 1
	else
		return 0
	end
end

function	GetDistanceP (x1,y1,x2,y2)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return math.floor(math.sqrt((x1-x2)^2+(y1-y2)^2))
end

function	GetDistanceA (id1, id2)
	local x1, y1 = GetV (V_POSITION,id1)
	local x2, y2 = GetV (V_POSITION,id2)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return GetDistance (x1,y1,x2,y2)
end

function	GetDistanceAP (id1, x2,y2)
	local x1, y1 = GetV (V_POSITION,id1)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return GetDistance (x1,y1,x2,y2)
end

function	GetDistancePR (x1,y1,x2,y2)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return math.max(math.abs(x1-x2),math.abs(y1-y2))
end

function GetDistanceAR(id1,id2)
	local x1, y1 = GetV (V_POSITION,id1)
	local x2, y2 = GetV (V_POSITION,id2)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return math.max(math.abs(x1-x2),math.abs(y1-y2))
end

function	GetDistanceAPR (id1, x2,y2)
	local x1, y1 = GetV (V_POSITION,id1)
	if (x1 == -1 or x2 == -1) then
		return 999
	end
	return math.max(math.abs(x1-x2),math.abs(y1-y2))
end






function BetterMoveToOwner(myid,range)
	if (range==nil) then
		range=1
	end
	local x,y = GetV(V_POSITION,myid)
	local ox,oy = GetV(V_POSITION,GetV(V_OWNER,myid))
	local destx,desty=0,0
	if (x > ox+range) then
		destx=ox+range
	elseif (x < ox - range) then
		destx=ox-range
	else
		destx=x
	end
	if (y > oy+range) then
		desty=oy+range
	elseif (y < oy - range) then
		desty=oy-range
	else
		desty=y
	end
	MyDestX,MyDestY=destx,desty
	Move(myid,MyDestX,MyDestY)
	return
end
function BetterMoveToOwnerXY(myid,range)
	if (range==nil) then
		range=1
	end
	local x,y = GetV(V_POSITION,myid)
	local ox,oy = GetV(V_POSITION,GetV(V_OWNER,myid))
	local destx,desty=0,0
	if (x > ox+range) then
		destx=ox+range
	elseif (x < ox - range) then
		destx=ox-range
	else
		destx=x
	end
	if (y > oy+range) then
		desty=oy+range
	elseif (y < oy - range) then
		desty=oy-range
	else
		desty=y
	end
	return destx,desty
end
function BetterMoveToLoc(myid,range,ox,oy)
	if (range==nil) then
		range=1
	end
	local x,y = GetV(V_POSITION,myid)
	--local ox,oy = GetV(V_POSITION,GetV(V_OWNER,myid))
	local destx,desty=0,0
	if (x > ox+range) then
		destx=ox+range
	elseif (x < ox - range) then
		destx=ox-range
	else
		destx=x
	end
	if (y > oy+range) then
		desty=oy+range
	elseif (y < oy - range) then
		desty=oy-range
	else
		desty=y
	end
	MyDestX,MyDestY=destx,desty
	Move(myid,MyDestX,MyDestY)
	return
end
function BetterMoveToLocXY(myid,range,ox,oy)
	if (range==nil) then
		range=1
	end
	local x,y = GetV(V_POSITION,myid)
	--local ox,oy = GetV(V_POSITION,GetV(V_OWNER,myid))
	local destx,desty=0,0
	if (x > ox+range) then
		destx=ox+range
	elseif (x < ox - range) then
		destx=ox-range
	else
		destx=x
	end
	if (y > oy+range) then
		desty=oy+range
	elseif (y < oy - range) then
		desty=oy-range
	else
		desty=y
	end
	
	return destx,desty
end

function	GetOwnerPosition (id)
	return GetV (V_POSITION,GetV(V_OWNER,id))
end

function	GetDistanceFromOwner (id)
	local x1, y1 = GetOwnerPosition (id)
	local x2, y2 = GetV (V_POSITION,id)
	if (x1 == -1 or x2 == -1) then
		return -1
	end
	return GetDistance (x1,y1,x2,y2)
end

function	IsOutOfSight (id1,id2)
	local x1,y1 = GetV (V_POSITION,id1)
	local x2,y2 = GetV (V_POSITION,id2)
	if (x1 == -1 or x2 == -1 or id1==-1 or id2==-1) then
		return true
	end
	local d = GetDistancePR(x1,y1,x2,y2)
	if d > 20 then
		return true
	else
		return false
	end
end


function	IsInAttackSight (myid,target,skill,level)
	if (skill==nil) then
		skill=MySkill
		level=MySkillLevel
	elseif (level==nil) then
		logappend("AAI_ERROR","IsInAttackSight called with nil level but skill is not nil. State:"..MyState.." skill "..skill)
	end
	local x1,y1 = GetV (V_POSITION,myid)
	local x2,y2 = GetV (V_POSITION,target)
	if (x1 == -1 or x2 == -1) then
		return false
	end
	local d		= GetDistance (x1,y1,x2,y2)
	local a     = AttackRange(myid,skill,level)
	if a >= d then
		return true;
	else
		return false;
	end
end



function AttackRange(myid,skill,level)
	if (skill==nil or level== nil) then
		if skill==nil or level==nil then
			logappend("AAI_ERROR","AttackRange called with invalid arguments State:"..MyState.." MySkill "..MySkill.." MySkillLevel"..MySkillLevel.." skill: "..formatval(skill).." level: "..formatval(level))
		end
		skill=MySkill
		level=MySkillLevel
	end
	local a     = 0
	if (skill == 0) then
		mertype=GetMerType(myid)
		if (mertype==nil) then
			mertype=-1
		end
		if (mertype == -1) then
			a     = 1
		elseif (mertype > 10 and mertype < 21) then
			a     = 2 --spear mercenary
		else
			a     = GetV(V_ATTACKRANGE,myid)
		end
	--elseif (skill==MS_BOWLINGBASH) then
	--	a	= 1
	else
		a = GetSkillInfo(skill,2,level)
		if a==nil then
			TraceAI("AttackRange() cannot get range for skill "..formatval(skill).." level "..formatval(level))
		end
	end
	if level == nil then
		logappend("AAI_ERROR","AttackRange called with nil level, skill = "..skill.." "..MyState)
	end
	TraceAI("Attack Sight - skill:"..skill.."level: "..level.." Range:"..a) 
	return a
end

function Closer(id,ox,oy)
	local x,y=GetV(V_POSITION,id)
	local newx,newy=0,0
	if (ox==x) then
		newx=x
	elseif (ox > x) then
		newx=ox-1
	else
		newx=ox+1
	end
	if (oy==y) then
		newy=y
	elseif (oy > y) then
		newy=oy-1
	else
		newy=oy+1
	end
	return newx,newy
end




function GetStandPoint(myid,target,skill,level,alt)
	local r=AttackRange(myid,skill,level)
	if GetDistanceA(myid,target) <= r then
		logappend("AAI_ERROR","GetStandPoint called while within range")
		return GetV(V_POSITION,MyID)
	end
	local tx,ty=GetV(V_POSITION,target)
	local x,y=-1,-1
	if _VERSION=="Lua 5.1" and myid==MyID and (alt==nil or alt==0) then
		x,y=GetV(V_POSITION_APPLY_SKILLATTACKRANGE,target,skill,level)
	end
	if skill==0 or skill==nil or (tx==x and ty==y) or (tx < 1 or ty < 1) or math.floor(GetDistanceAP(target,x,y)) > r then -- Use normal closest call, since V_POSITION_APPLY_SKILLATTACKRANGE doesn't work for non-skills, or has given us clearly bogus standpoint for skill.
		x,y=Closest(myid,tx,ty,r,alt)
	end
	return AdjustStandPoint(x,y,tx,ty,r,alt)
end

function AdjustStandPoint (x,y,tx,ty,r,alt)
	if _VERSION=="Lua 5.1" then
		-- Now we need to make sure x and y are not on occupied cells, because of the changes to the client
		local bounds=GetMoveBounds()
		local logstring=""
		if (alt==nil) then
			logstring=logstring.."x,y"..x..","..y.." tx,ty"..tx..","..ty.." r "..r.."alt nil bounds "..bounds.." | "
		else 
			logstring=logstring.."x,y"..x..","..y.." tx,ty"..tx..","..ty.." r "..r.."alt "..alt.." bounds "..bounds.." | "
		end
		local i=0
		
		while (TakenCells[x.."_"..y] or GetDistanceAPR(GetV(V_OWNER,MyID),x,y) > bounds) do
			i=i+1
			if (TakenCells[x.."_"..y]) then
				logstring=logstring.."i="..i.."tc="..TakenCells[x.."_"..y].."d ".. GetDistanceAPR(GetV(V_OWNER,MyID),x,y).." :"
			else 
				logstring=logstring.."i="..i.."tc= nil d ".. GetDistanceAPR(GetV(V_OWNER,MyID),x,y).." :"
			end
			if r==1 then
				if alt==nil or alt==0 then
					x,y=AdjustCW(x,y,tx,ty)
					logstring=logstring.."CW "..x..","..y
				elseif alt==1 then
					x,y=AdjustCCW(x,y,tx,ty)
					logstring=logstring.."CCW "..x..","..y
				else --alt=2
					x,y=AdjustOpp(x,y,tx,ty)
					logstring=logstring.."OPP "..x..","..y
					alt=0
				end
				if i > 7 then
					logappend("AAI_CLOSEST","AdjustStandPoint() FAILED  logstring="..logstring)

		TraceAI("AdjustStandPoint() FAILED logstring="..logstring)
					return -1,-1
				end
			else
				if alt==nil or alt==0 then
					x,y=AdjustCWr(x,y,tx,ty,r)
					logstring=logstring.."CWr "..x..","..y
				elseif alt==1 then
					x,y=AdjustCCWr(x,y,tx,ty,r)
					logstring=logstring.."CCWr "..x..","..y
				else --alt=2
					x,y=x*-1,y*-1
					logstring=logstring.."Opp R "..x..","..y
					alt=0
				end
				if i > 7 then
					logappend("AAI_CLOSEST","AdjustStandPoint() FAILED  logstring="..logstring)
					return -1,-1
				end
			end
		end
		logappend("AAI_CLOSEST","AdjustStandPoint() returned "..x.." , "..y.." logstring="..logstring)
	end
	return x,y
end

function Closest(myid,ox,oy,range,alt)
	local x,y=GetV(V_POSITION,myid)
	local dx,dy=ox-x,oy-y
	local newx,newy=0,0
	local logstring="x,y"..x..","..y.." ox,oy"..ox..","..oy
	if range > 1 then
		logstring=logstring.."range > 1 "
		dist=math.sqrt(dx^2+dy^2)
		if (dist < range) then
			newx,newy=x,y
			logstring=logstring.."dist < range new"..newx..","..newy.." "
		else
			factor=range/dist
			xoff=(dx-absceil(dx*factor))
			yoff=(dy-absceil(dy*factor))
			newx,newy=x+xoff,y+yoff
			logstring=logstring.."dist > range new" ..newx..","..newy.." factor:"..factor.." "
		end
		-- This routine tries to find an adjacent cell to the closest cell that will be close enough - to address unwalkable cells near where retainer wants to walk (think: pebbles in thors)
		
		if (alt ~= nil) then
			logstring=logstring.."alt not nil"..alt.." "
			if (alt==1) then
				if (x > ox) then
					newx=newx-1
				elseif (x < ox) then
					newx=newx+1
				else
					alt=2
				end
			end
			if (alt==2) then
				if (y > oy) then
					newy=newy-1
				elseif (y < oy) then
					newy=newy+1
				else
					alt=3
				end
			end
		
			--if (alt==4) then -- This seems to cause more problems than it solves, set to 4 to prevent from running
			--	if (x > ox) then
			--		newx=newx-1
			--		newy=newy+1
			--	elseif (x < ox) then
			--		newx=newx+1
			--		newy=newy+1
			--	elseif (y > oy) then
			--		newy=newy-1
			--		newx=newx+1
			--	else 	
			--		newy=newy+1
			--		newx=newx+1
			--	end
			--end
			logstring=logstring.."end of alt sequence new"..newx..","..newy.." alt "..alt.." "
		end
		--xxx,yyy=GetV(V_POSITION,target)
		--TraceAI("alt is: "..GetDistance(xxx,yyy,newx,newy).." "..xxx..","..yyy.." "..newx..","..newy.."MyPos: "..x..","..y) 	
	else -- simplified, better closest point for melee. 
		logstring=logstring.."range = 1 d"..dx..","..dy.." o"..ox..","..oy.." "
		if dx > 0 then
			newx=ox-1
		elseif dx < 0 then
			newx=ox+1
		else -- dx = 0
			newx=x
		end
		if dy > 0 then
			newy=oy-1
		elseif dy < 0 then
			newy=oy+1
		else -- dy = 0
			newy=y
		end
		logstring=logstring.."new"..newx..","..newy.." "
		if alt~=nil then
			if alt==1 then
				newx,newy=AdjustCW(newx,newy,ox,oy)
				logstring=logstring.."adjust cw"..newx..","..newy.." "
			else
				newx,newy=AdjustCCW(newx,newy,ox,oy)
				logstring=logstring.."adjust ccw"..newx..","..newy.." "
			end
		end
	end
	local logalt="nil"
	if alt~=nil then
		logalt=alt
	end
	if newx<=0 or newy<=0 then 
		logappend("AAI_ERROR","Closest() Failure!"..newx.." , "..newy.." alt ="..logalt.." logstring="..logstring)
	end
	logappend("AAI_CLOSEST","Closest() returned "..newx.." , "..newy.." alt ="..logalt.." logstring="..logstring)
	return newx,newy
end

function AdjustCW(x,y,ox,oy)
	local newx,newy,dy,dx
	if x==ox then
		if y==oy then --stacked!? Unstack!
			newx,newy=ox+1,oy
		else
			dy=y-oy
			newx=x+absunit(dy)
			newy=y
		end
	elseif y==oy then
		dx=x-ox
		newy=y-absunit(dx)
		newx=x
	elseif y>oy then
		if x>ox then
			newy=y-1
			newx=x
		else
			newy=y
			newx=x+1
		end
	else -- y<oy
		if x>ox then
			newx=x-1
			newy=y
		else
			newx=x
			newy=y+1
		end
	end
	return newx,newy
end
function AdjustCCW(x,y,ox,oy)
	local newx,newy,dx,dy
	if x==ox then
		if y==oy then --stacked!? Unstack!
			newx,newy=ox-1,oy
		else
			dy=y-oy
			newx=x-absunit(dy)
			newy=y
		end
	elseif y==oy then
		dx=x-ox
		newy=y+absunit(dx)
		newx=x
	elseif y>oy then
		if x>ox then
			newy=y
			newx=x-1
		else
			newy=y-1
			newx=x
		end
	else -- y<oy
		if x>ox then
			newx=x
			newy=y+1
		else
			newx=x+1
			newy=y
		end
	end
	return newx,newy
end

function AdjustCWr(x,y,ox,oy,r)
	if r==1 then
		return AdjustCW(x,y,ox,oy)
	end
	local newx,newy,dy,dx
	dx,dy=x-ox,y-oy
	if math.abs(dx) == math.abs(dy)  then --we're on a diagonal, this could be a problem, so let's get off it!
		if dx < 0 then
			if dy < 0 then
				newx=x+1
				newy=y
			else
				newx=x
				newy=y-1
			end
		elseif dx > 0 then
			if dy < 0 then
				newy=y+1
				newx=x
			else
				newx=x-1
				newy=y
			end
		else --stacked, which should NEVER HAPPEN but has somehow happened anyway
			newx=x+1
			newy=y+1
			logappend("AAI_ERROR","AdjustCWr called with x,y=ox,oy - this can't happen!")
		end
	else
		if math.abs(dx) < math.abs(dy) then --north or south quadrant
			if dy < 0 then -- south quadrant
				newx=x+1
				newy=y+1
			else --north
				newx=x-1
				newy=y-1
			end
		else --east or west quadrant
			if dx < 0 then --west
				newy=y-1
				newx=x+1
			else
				newx=x-1
				newy=y+1
			end
		end
	end

	if (newx-ox==0 and math.abs(newy-oy)==1) or (newy-oy==0 and math.abs(newx-ox)==1) then
		newx,newy=newx*2,newy*2
	end
	return newx,newy
end

function AdjustCCWr(x,y,ox,oy,r)
	if r==1 then
		return AdjustCCW(x,y,ox,oy)
	end
	local newx,newy,dy,dx
	dx,dy=x-ox,y-oy
	if math.abs(dx) == math.abs(dy)  then --we're on a diagonal, this could be a problem, so let's get off it!
		if dx < 0 then
			if dy < 0 then
				newx=x
				newy=y+1
			else
				newx=x+1
				newy=y
			end
		elseif dx > 0 then
			if dy < 0 then
				newy=y
				newx=x-1
			else
				newx=x
				newy=y-1
			end
		else --stacked, which should NEVER HAPPEN but has somehow happened anyway
			newx=x-1
			newy=y-1
			logappend("AAI_ERROR","AdjustCWr called with x,y=ox,oy - this can't happen!")
		end
	else
		if math.abs(dx) < math.abs(dy) then --north or south quadrant
			if dy < 0 then -- south quadrant
				newx=x-1
				newy=y+1
			else --north
				newx=x+1
				newy=y-1
			end
		else --east or west quadrant
			if dx < 0 then --west
				newy=y+1
				newx=x+1
			else
				newx=x-1
				newy=y-1
			end
		end
	end
	if (newx-ox==0 and math.abs(newy-oy)==1) or (newy-oy==0 and math.abs(newx-ox)==1) then
		newx,newy=newx*2,newy*2
	end
	return newx,newy
end

function AdjustOpp(x,y,ox,oy)
	dx=ox-x
	dy=oy-y
	return x+2*dx,y+2*dy
end
function ClosestR(myid,target,range,alt)
	local ox,oy=GetV(V_POSITION,target)
	return Closest(myid,ox,oy,range,alt)
end

--###############################   ##   ##
--### LUA 5.1 feature support ###   ##   ##
--###############################   ##   ##


function DiagonalDist(distance)
	return math.floor(math.sqrt(distance*distance))
end

function GetDanceCell(x,y,enemy)
	local enemyx,enemyy=GetV(V_POSITION,enemy)
	if IsInAttackSight(MyID,enemy) == false then --Why is this being called?! 
		logappend("AAI_ERROR","GetDanceCell() called when enemy out of range!" )
		x,y=Closest(MyID,enemyx,enemyy,1)
		return x,y
	end
	t = math.random(2)
	if t == 1 then
		return AdjustCW(x,y,enemyx,enemyy)
	elseif t == 2 then
		return AdjustCCW(x,y,enemyx,enemyy)
	else 
		return AdjustOpp(x,y,enemyx,enemyy)
	end
end

--[[ --disabled for a simpler dance alog, because you can't dance any ranged attacks at the moment, so optimize for range=1

function GetDanceCell(x,y,enemy)
	distance = GetDistance2(MyID,enemy)
	ex,ey=GetV(V_POSITION,enemy)
	s=(((math.random(2)-1)*2)-1)
	t=(((math.random(2)-1)*2)-1)
	if (GetDistance(x-s,y+t,ex,ey) == distance) then
		return x-s,y+t
	elseif (GetDistance(x,y+t,ex,ey) == distance) then
		return x,y+t
	elseif (GetDistance(x+s,y+t,ex,ey) == distance) then
		return x+s,y+t
	elseif (GetDistance(x-s,y,ex,ey) == distance) then
		return x-s,y
	elseif (GetDistance(x+s,y,ex,ey) == distance) then
		return x+s,y
	elseif (GetDistance(x-s,y-t,ex,ey) == distance) then
		return x-s,y-t
	elseif (GetDistance(x,y-t,ex,ey) == distance) then
		return x,y-t
	else
		return x+s,y-t
	end
	
end
]]--]]
--#########################
--### GetSkill functions###
--#########################

function GetSAtkSkill(myid)
	local skill = 0
	local level = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if htype > 47 then -- it's a Homun S
			if htype==EIRA and UseEiraEraseCutter==1 then
				skill=MH_ERASER_CUTTER
				if EiraEraseCutterLevel==nil then
					level=4
				else
					level=EiraEraseCutterLevel
				end
			elseif htype==BAYERI and UseBayeriStahlHorn==1 then
				skill=MH_STAHL_HORN
				if BayeriStahlHornLevel==nil then
					level=5
				else
					level=BayeriStahlHornLevel
				end
			elseif htype==SERA and UseSeraParalyze==1 then
				skill=MH_NEEDLE_OF_PARALYZE
				if SeraParalyzeLevel==nil then
					level=5
				else
					level=SeraParalyzeLevel
				end
			elseif htype==ELEANOR and UseEleanorSonicClaw==1 and ( EleanorMode==0 or EleanorDoNotSwitchMode==1 ) then
				skill=MH_SONIC_CRAW
				if EleanorSonicClawLevel==nil then
					level=5
				else
					level=EleanorSonicClawLevel
				end
			elseif htype==ELEANOR and UseEleanorTinderBreaker==1 and EleanorMode==1 then
				skill=MH_TINDER_BREAKER
				if EleanorTinderBreakerLevel==nil then
					level=5
				else
					level=EleanorTinderBreakerLevel
				end
			end
		end
		if level ~=0 then
			return skill,level
		end
	end
	return 0,0
end

function GetComboSkill(myid)
	local skill = 0
	local level = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if htype==ELEANOR then
			if EleanorMode==0 or EleanorDoNotSwitchMode==1 then
				if ComboSCTimeout > GetTick() and MySpheres >= AutoComboSpheres then
					skill=MH_SILVERVEIN_RUSH
					if EleanorSilverveinLevel==nil then
						level=5
					else
						level=EleanorSilverveinLevel
					end
				elseif ComboSVTimeout > GetTick()  then
					skill=MH_MIDNIGHT_FRENZY
					if EleanorMidnightLevel==nil then
						level=5
					else
						level=EleanorMidnightLevel
					end
				end
			end
		end
		if level ~=0 then
			return skill,level
		end
	end
	return 0,0
end

function GetGrappleSkill(myid)
	local skill = 0
	local level = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if htype==ELEANOR and MySpheres >= AutoComboSpheres then
			if EleanorMode==1 or EleanorDoNotSwitchMode==1 then
				if ComboSCTimeout > GetTick() then
					if MySpheres >= AutoComboSpheres -1 then
						skill=MH_CBC
						if EleanorCBCLevel==nil then
							level=5
						else
							level=EleanorCBCLevel
						end
					end
				elseif ComboSVTimeout > GetTick() then
					if MySpheres >= AutoComboSpheres -1 then
						skill=MH_EQC
						if EleanorEQCLevel==nil then
							level=5
						else
							level=EleanorEQCLevel
						end
					end
				elseif MySpheres >= AutoComboSpheres then
					skill=MH_TINDER_BREAKER
					if EleanorTinderBreakerLevel==nil then
						level=5
					else
						level=EleanorTinderBreakerLevel
					end				
				end
			end
		end
		if level ~=0 then
			return skill,level
		end
	end
	return 0,0
end

function GetAtkSkill(myid)
	local skill = 0
	local level = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if htype < 17 then
			homuntype=modulo(GetV(V_HOMUNTYPE,myid),4)
		else
			homuntype=modulo(OldHomunType,4)
		end
		if (homuntype==0) then -- It's a vani!
			skill=HVAN_CAPRICE
			if GetTick() < AutoSkillCooldown[skill] then
				level=0
				skill=0
			elseif (VanCapriceLevel==nil) then
				level=5
			else
				level=VanCapriceLevel
			end
		elseif	(homuntype==3) then -- It's a filer!
			skill=HFLI_MOON
			if GetTick() < AutoSkillCooldown[skill] then
				level=0
				skill=0
			elseif (FilerMoonlightLevel==nil) then
				level=5
			else
				level=FilerMoonlightLevel
			end
		end		
		if level ~=0 then
			return skill,level
		end
	else
		for i,v in ipairs(AtkSkillList) do
			level = SkillList[MercType][v]
			if level ~= nil then
				skill=v
				return skill,level
			end
		end
	end
	return 0,0
end

function GetPushbackSkill(myid)
	if (IsHomun(myid)==1) then
		return 0,0
	else
		for i,v in ipairs(PushSkillList) do
			level = SkillList[MercType][v]
			if level ~= nil then
				skill=v
				return skill,level
			end
		end
	end
	return 0,0
end


function GetDebuffSkill(myid)
	if (IsHomun(myid)==1) then
		if GetV(V_HOMUNTYPE,MyID)==EIRA and UseEiraSilentBreeze==1 then
			skill=MH_SILENT_BREEZE
			if EiraSilentBreezeLevel==nil then
				level=5
			else
				level=EiraSilentBreezeLevel
			end
			return skill,level
		elseif GetV(V_HOMUNTYPE,MyID)==DIETER and UseDieterVolcanicAsh==1 then
			skill=MH_VOLCANIC_ASH
			level=5
			local t = GetTick()
			if (AshTimeout[1] < t or AshTimeout[2] < t or AshTimeout[3] < t) then
				return skill,level
			else 
				return 0,0
			end
		end
	else
		for i,v in ipairs(DebuffSkillList) do
			level = SkillList[MercType][v]
			if level ~= nil then
				skill=v
				return skill,level
			end
		end
	end
	return 0,0
end

function GetMinionSkill(myid)
	local level,skill=0,0
	if (IsHomun(myid)==1) then
		if GetV(V_HOMUNTYPE,MyID)==SERA and UseSeraCallLegion==1 then
			skill=MH_SUMMON_LEGION
			TraceAI("GetMinionSkill"..skill)
			if SeraCallLegionLevel == nil then
				level=5
			elseif SeraCallLegionLevel < 1 then
				skill,level=0,0
			elseif SeraCallLegionLevel > 5 then
				level=5
			else
				level=SeraCallLegionLevel
			end
			TraceAI("GetMinionSkill "..skill..level)
			if AutoSkillCooldown[skill]~=nil then
				if GetTick() < AutoSkillCooldown[skill] then -- in cooldown
					level=0
					skill=0
				end
			end
			return skill,level
		end
	end
	return 0,0
end

function GetProvokeSkill(myid)
	if (IsHomun(myid)==1) then
		return 0,0
	else
		level=SkillList[MercType][MER_PROVOKE]
		if level ~=nil then
			return MER_PROVOKE,level
		end
	end
	return 0,0
end

function GetSacrificeSkill(myid)
	level=SkillList[MercType][ML_DEVOTION]
	if level ~=nil then
		return ML_DEVOTION,level
	end
	return 0,0
end

function GetMobSkill(myid)
	local skill = 0
	local level = 0
	if (IsHomun(myid)==1) then
	
		htype=GetV(V_HOMUNTYPE,MyID)
		if htype <17 then
			skill=0
		else -- it's a homun s
			if htype==EIRA and UseEiraXenoSlasher==1 then
				skill=MH_XENO_SLASHER
				if EiraXenoSlasherLevel==nil then
					level=4
				else
					level=EiraXenoSlasherLevel
				end
			elseif htype==BAYERI and UseBayeriHailegeStar==1 then
				skill=MH_HEILIGE_STANGE
				if BayeriHailegeStarLevel==nil then
					level=5
				else
					level=BayeriHailegeStarLevel
				end
			elseif htype==SERA and UseSeraPoisonMist==1 and PoisonMistMode==0 then
				skill=MH_POISON_MIST
				if SeraPoisonMistLevel==nil then
					level=5
				else
					level=SeraPoisonMistLevel
				end
			elseif htype==DIETER and UseDieterLavaSlide==1 and LavaSlideMode==0 then
				skill=MH_LAVA_SLIDE
				if DieterLavaSlideLevel==nil then
					level=10
				else
					level=DieterLavaSlideLevel
				end
			end 
			if AutoSkillCooldown[skill]~=nil then
				if GetTick() < AutoSkillCooldown[skill] then -- in cooldown
					level=0
					skill=0
				end
			end
		end
		return skill,level
	else -- SO MUCH EASIER WHEN LEVEL ISN'T SELECTABLE!!!!
		for i,v in ipairs(MobSkillList) do
			level = SkillList[MercType][v]
			if level ~= nil then
				skill=v
				return skill,level
			end
		end
	end
	return 0,0
end


function	GetQuickenSkill(myid)
	local level = 0
	local skill = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if htype < 17 then
			homuntype=modulo(GetV(V_HOMUNTYPE,myid),4)
		else
			homuntype=modulo(OldHomunType,4)
		end
		if (homuntype==1) then -- It's a lif!
			skill=HLIF_CHANGE
			level=3
		elseif	(homuntype==3) then -- It's a filer!
			skill=HFLI_FLEET
			if (FilirFlitLevel==nil) then
				level=5
			else
				level=FilirFlitLevel
			end
		elseif  (homuntype==2) then --it's an amistr
			skill=HAMI_BLOODLUST
			level=3
		end
	else
		level=SkillList[MercType][MER_QUICKEN]
		if level ~=nil then
			skill=MER_QUICKEN
		end
	end
	if AutoSkillCooldown[skill]~=nil then
		if GetTick() < AutoSkillCooldown[skill] then -- in cooldown
			level=0
			skill=0
		end
	end
	return skill,level
end

function	GetSOffensiveSkill(myid)
	local level = 0
	local skill = 0
	local skillopt = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if (htype==BAYERI and UseBayeriAngriffModus~=0) then
			skill=MH_ANGRIFFS_MODUS
			level = 5
			skillopt=UseBayeriAngriffModus
		elseif	(htype==DIETER and UseDieterMagmaFlow~=0) then
			skill=MH_MAGMA_FLOW
			level = 5
			skillopt=UseDieterMagmaFlow
		end
		return skill,level,skillopt
	else
		level=SkillList[MercType][MER_BLESSING]
		if level~=nil then
			skill=MER_BLESSING
		else
			level=0
		end
		return skill,level,UseBlessingSelf
	end
end

function	GetSDefensiveSkill(myid)
	local level = 0
	local skill = 0
	local skillopt=0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if (htype==BAYERI and UseBayeriGoldenPherze~=0) then
			skill=MH_GOLDENE_FERSE
			level = 5
			skillopt=UseBayeriGoldenPherze
		elseif	(htype==DIETER and UseDieterGraniticArmor~=0) then
			skill=MH_GRANITIC_ARMOR
			level = 5
			skillopt=UseDieterGraniticArmor
		end
		return skill,level,skillopt
	else
		level=SkillList[MercType][MER_KYRIE]
		if level~=nil then
			skill=MER_KYRIE
		else
			level=0
		end
		return skill,level,UseKyrieSelf
	end
	return 0,0,0
end

function	GetSOwnerBuffSkill(myid)
	local level = 0
	local skill = 0
	local skillopt = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if (htype==EIRA and UseEiraOveredBoost~=0) then
			skill=MH_OVERED_BOOST
			level = 5
			skillopt=UseEiraOveredBoost
		elseif	(htype==DIETER and UseDieterPyroclastic~=0) then
			skill=MH_PYROCLASTIC
			if DieterPyroclasticLevel==nil then
				level = 10
			else
				level=DieterPyroclasticLevel
			end
			skillopt=UseDieterPyroclastic
		end
		return skill,level,skillopt
	else
		level=SkillList[MercType][MER_INCAGI]
		if level~=nil then
			skill=MER_INCAGI
		else
			level=0
		end
		return skill,level,UseIncAgiSelf
	end
	return 0,0,0
end

function GetSightOrAoE(myid)
	local level = 0
	local skill = 0
	local skillopt = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if	(htype==DIETER and UseDieterLavaSlide==1 and LavaSlideMode~=0) then
			skill=MH_LAVA_SLIDE
			level = 10
			skillopt=LavaSlideMode
		elseif (htype==SERA and PoisonMistMode~=0 and UseSeraPoisonMist==1) then
			skill=MH_POISON_MIST
			level = 5
			skillopt=PoisonMistMode
		end
	else
		if MercType==2 then
			skill=MER_SIGHT
			level=1
			skillopt=UseAutoSight
		end
	end
	if AutoSkillCooldown[skill]~=nil then
		if GetTick() < AutoSkillCooldown[skill] then -- in cooldown
			level=0
			skill=skill
		end
	end
	return skill,level,skillopt
end
function	GetGuardSkill(myid)
	local level = 0
	local skill = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if htype < 17 then
			homuntype=modulo(GetV(V_HOMUNTYPE,myid),4)
		else
			homuntype=modulo(OldHomunType,4)
		end
		if (homuntype==1) then -- It's a lif!
			skill=HLIF_AVOID
			if (LifEscapeLevel==nil) then
				level=5
			else
				level=LifEscapeLevel
			end
		elseif (homuntype==2) then -- It's an amistr!
			skill=HAMI_DEFENCE
			if (AmiBulwarkLevel==nil) then
				level=5
			else
				level=AmiBulwarkLevel
			end
		elseif (homuntype==3) then -- It's an filir!
			skill=HFLI_SPEED
			if (FilirAccelLevel==nil) then
				level=5
			else
				level=FilirAccelLevel
			end
		end
		return skill,level
	else
		for i,v in ipairs(GuardSkillList) do
			level = SkillList[MercType][v]
			if level ~= nil then
				skill=v
				return skill,level
			end
		end
	end
	return 0,0
end

function	GetOffensiveOwnerSkill(myid)
	local level = 0
	local skill = 0
	local skillopt = 0
	if (IsHomun(myid)==1) then
		return 0,0,0
	else
		level=SkillList[MercType][MER_BLESSING]
		if level~=nil then
			skill=MER_BLESSING
		else
			level=0
		end
		return skill,level,UseBlessingOwner
	end
end
function	GetDefensiveOwnerSkill(myid)
	local level = 0
	local skill = 0
	local skillopt = 0
	if (IsHomun(myid)==1) then
		if GetV(V_HOMUNTYPE,MyID)==SERA and UseSeraPainkiller~=0 then
			level=5
			return MH_PAIN_KILLER,level,UseSeraPainkiller
		else
			return 0,0,0
		end
	else
		level=SkillList[MercType][MER_KYRIE]
		if level~=nil then
			skill=MER_KYRIE
		else
			level=0
		end
		return skill,level,UseKyrieOwner
	end
end
function	GetOtherOwnerSkill(myid)
	local level = 0
	local skill = 0
	local skillopt = 0
	if (IsHomun(myid)==1) then
		return 0,0,0
	else
		level=SkillList[MercType][MER_INCAGI]
		if level~=nil then
			skill=MER_INCAGI
		else
			level=0
		end
		return skill,level,UseIncAgiOwner
	end
end



function GetHealingSkill(myid)
	local level = 0
	local skill = 0
	if (IsHomun(myid)==1) then
		htype=GetV(V_HOMUNTYPE,myid)
		if htype < 17 then --if it's not a homun S just run it through modulo. 
			homuntype=modulo(GetV(V_HOMUNTYPE,myid),4)
		else --If it's a homun S, get the OldHomunType
			if homuntype == EIRA and HealOwnerBreeze == 1 then --Handling for Eira silent breeze
				skill=MH_SILENT_BREEZE
				if GetTick() < AutoSkillCooldown[skill] then
					level=0
				else
					level=5
				end
				return skill,level
			end
			homuntype=modulo(OldHomunType,4)
		end
		if (homuntype==1) then -- It's a lif
			skill=HLIF_HEAL
			if GetTick() < AutoSkillCooldown[skill] then
				level=0
			elseif (LifHealLevel==nil) then
				level=5
			else
				level=LifHealLevel
			end
		elseif homuntype==0 then -- It's a vani
			skill=HVAN_CHAOTIC
			if GetTick() < AutoSkillCooldown[skill] then
				level=0
			elseif (VaniChaoticLevel==nil) then
				level=3
			else
				level=VaniChaoticLevel
			end
		end
	else
		--currently no merc healing skills
	end
	return skill,level
end

function GetSnipeSkill(myid)
	return GetAtkSkill(myid)
end

function GetTargetedSkills(myid)
	s,l=GetAtkSkill(myid)
	Mainatk={MAIN_ATK,s,l}
	s,l=GetSAtkSkill(myid)
	Satk={S_ATK,s,l}
	s,l=GetComboSkill(myid)
	ComboAtk={COMBO_ATK,s,l}
	s,l=GetGrappleSkill(myid)
	GrappleAtk={GRAPPLE_ATK,s,l}
	s,l=GetMobSkill(myid)
	Mobatk={MOB_ATK,s,l}
	s,l=GetDebuffSkill(myid)
	Debuffatk={DEBUFF_ATK,s,l}
	s,l=GetMinionSkill(myid)
	Minionatk={MINION_ATK,s,l}
	result={Mainatk,Satk,ComboAtk,GrappleAtk,Mobatk,Debuffatk,Minionatk}
	return result
end

function GetSkillInfo(skill,info,level)
	if skill~=nil and info~=nil then
		if SkillInfo[skill]~=nil then
			local t=SkillInfo[skill][info]
			if t~=nil then
				if level ==nil and type(t)=="table" then
					logappend("AAI_ERROR","Attempted to call GetSkillInfo() with only 2 arguments "..skill.." "..info)
					if type(t)~="table" and t~=nil then
						return t
					else
						return -1
					end
				elseif type(t)~="table" then
					return t
				elseif SkillInfo[skill][info][level]~=nil then
					return SkillInfo[skill][info][level]
				else
					logappend("AAI_ERROR","GetSkillInfo(): No skill info type "..info.." found for this level "..FormatSkill(skill,level))
					if info==2 then
						local r=0
						if (_VERSION=="Lua 5.1") then
							r=GetV(V_SKILLATTACKRANGE_LEVEL,MyID,skill,level)
						else
							r=GetV(V_SKILLATTACKRANGE,MyID,skill)
						end
						logappend("AAI_ERROR","GetSkillInfo(): Range for unknown skill requested, returning builtin value"..r.." "..skill)
						return r
					elseif SkillInfo[skill][info][1]~= nil then
						return SkillInfo[skill][info][1]
					else
						return 0
					end
				end
			else
				logappend("AAI_ERROR","GetSkillInfo(): No skill info type "..info.." found for this skill "..FormatSkill(skill,level).." called by ")
				if info==2 then
					logappend("AAI_ERROR","GetSkillInfo(): Range for unknown skill requested, returning builtin value"..GetV(V_SKILLATTACKRANGE,MyID,skill))
					return GetV(V_SKILLATTACKRANGE,MyID,skill)
				elseif info==7 then
					return 1
				else
					return 0
				end
			end
		else
			logappend("AAI_ERROR","GetSkillInfo(): No skill info found for this skill "..FormatSkill(skill,level).." info type requested "..info)
			if info==2 then
				logappend("AAI_ERROR","GetSkillInfo(): Range for unknown skill requested, returning builtin value"..GetV(V_SKILLATTACKRANGE,MyID,skill))
				return GetV(V_SKILLATTACKRANGE,MyID,skill)
			elseif info==7 then
				return 1
			else
				return 0
			end
		end
	else
		if skill==nil then
			skill="nil"
		end
		if level==nil then
			level="nil"
		end
		if info==nil then
			info="nil"
		end
		logappend("AAI_ERROR","GetSkillInfo(): Invalid arguments - skill="..skill.." level="..level.." info="..info)
		return 0
	end
end
--#######################
--### Other Functions ###
--#######################

function KiteOK(myid)
	mertype=GetV(V_MERTYPE,myid)
	if (mertype==nil) then
		homuntype=modulo(GetV(V_HOMUNTYPE,myid),4)
		if ((homuntype==0 or homuntype==3 )and DoNotChase==1) then
			return 1
		else
			return 0
		end
	elseif (mertype < 11) then
		return 1
	else
		return 0
	end
end

function DoSkill(skill,level,target,mode,targx,targy)
	TraceAI("doskill called skill:"..skill.."level:"..level.."target"..target)
	if skill==0 or level==0 or skill==nil or level==nil then
		logappend("AAI_ERROR","doskill called skill:"..skill.."level:"..level.."target"..target.."mode"..mode.."state "..MyState.."pstate "..MyPState)
		return 0
	end
	targetmode=GetSkillInfo(skill,7)
	if skill==HFLI_SBR44 and AllowSBR44~=1 then
		logappend("AAI_ERROR","Attempt to use SBR 44 blocked. If you really want to use this, set AllowSBR44 = 1 in H_Extra")
	elseif targetmode==0 then
		SkillObject(MyID,level,skill,MyID)
	elseif targetmode==1 then
		SkillObject(MyID,level,skill,target)
	elseif targetmode==2 then
		if targx == nil then
			x,y=GetV(V_POSITION,target)
			SkillGround(MyID,level,skill,x,y)
		else
			SkillGround(MyID,level,skill,targx,targy)
		end
	end
	if mode~=nil then
		if mode > 0 then
			CastSkillMode=mode
			CastSkill=skill
			CastSkillLevel=level
			CastSkillTime=GetTick()
			CastSkillState=0
			logappend("AAI_SKILLFAIL", "Mode set "..mode.." skill "..skill.." level "..level)
		else --mode is negative, call the plugin mode handler. 
			DoSkillHandleMode(skill,level,target,mode,targx,targy)
			logappend("AAI_SKILLFAIL", "Mode set "..mode.." skill "..skill.." level "..level)
		end
	end
	local t=GetTick();
	delay=AutoSkillDelay + GetSkillInfo(skill,4,level)+GetSkillInfo(skill,5,level)*CastTimeRatio
	AutoSkillCastTimeout=delay+t
	if AutoSkillCooldown[skill]~=nil then
		AutoSkillCooldown[skill]=t+GetSkillInfo(skill,9,level)+delay
	elseif (skill==MH_VOLCANIC_ASH) then --handle the three ash timeouts
		if (AshTimeout[1] < t) then
			AshTimeout[1]=t+GetSkillInfo(skill,9,level)+delay
		elseif (AshTimeout[2] < t) then
			AshTimeout[2]=t+GetSkillInfo(skill,9,level)+delay
		else 
			AshTimeout[3]=t+GetSkillInfo(skill,9,level)+delay
		end
	end
	delay = delay + GetSkillInfo(skill,6,level)
	AutoSkillTimeout=t+delay
	if AutoSkillCooldown[skill]~=nil then
		TraceAI("DoSkill: "..skill.." level:"..level.." target:"..target.." mode:"..targetmode.." delay "..delay.." cooldown: "..AutoSkillCooldown[skill]-GetTick())
	else
		TraceAI("DoSkill: "..skill.." level:"..level.." target:"..target.." mode:"..targetmode.." delay "..delay)
	end
	if skill==MH_MIDNIGHT_FRENZY then
		MySpheres = math.max(0,MySpheres - 2)
		ComboSVTimeout=0
		UpdateTimeoutFile()
	elseif skill==MH_SILVERVEIN_RUSH then
		ComboSVTimeout=GetTick()+2000
		ComboSCTimeout=0
		MySpheres = math.max(0,MySpheres - 1)
		UpdateTimeoutFile()
	elseif skill==MH_SONIC_CRAW then
		ComboSCTimeout=GetTick()+2000
		ComboSVTimeout=0
	elseif skill==MH_TINDER_BREAKER then
		ComboSCTimeout=GetTick()+2000
		ComboSVTimeout=0
		MySpheres = math.max(0,MySpheres - 1)
	elseif skill==MH_CBC then
		ComboSVTimeout=GetTick()+2000
		ComboSCTimeout=0
		MySpheres = math.max(0,MySpheres - 1)
	elseif skill==MH_EQC then
		ComboSVTimeout=0
		ComboSCTimeout=0
		--No sphere use?
	else --Combo wasn't used, so kill the timeouts
		ComboSCTimeout=0
		ComboSVTimeout=0
	end

	TraceAI("DoSkill: "..skill.." level:"..level.." target:"..target.." mode:"..targetmode.." delay "..delay)
	logappend("AAI_SKILLFAIL", "DoSkill: "..skill.." level:"..level.." target:"..target.." mode:"..targetmode.." delay "..delay)
	return
end

function modtwroSend()
	if modtwROSkillGroundID~=0 then
		logappend("AAI_Lag","Calling skillground function")
		OldSkillGround(MyID,modtwROSkillGroundLV,modtwROSkillGroundID,modtwROSkillGroundX,modtwROSkillGroundY)
		LagReductionCD=LagReduction
	elseif modtwROSkillObjectID~=0 then
		logappend("AAI_Lag","Calling SkillObject function")
		OldSkillObject(MyID,modtwROSkillObjectLV,modtwROSkillObjectID,modtwROSkillObjectTarg)
		LagReductionCD=LagReduction
	else
		if modtwRODidMove==0 then
			if modtwROMoveX~=0 then
				logappend("AAI_Lag","Calling Move function, didmove=0")
				OldMove(MyID,modtwROMoveX,modtwROMoveY)
				LagReductionCD=LagReduction
				modtwRODidMove=1
				modtwRODidAttack=0
			end
		else
			modtwRODidMove=0
		end
		if modtwRODidAttack==0 then
			if modtwROAttackTarget~=0 then
				logappend("AAI_Lag","Calling attack function, didattack=0")
				OldAttack(MyID,modtwROAttackTarget)
				LagReductionCD=LagReduction
				modtwRODidAttack=1
			end
		else
			modtwRODidAttack=0
		end
	end
	modtwROSkillGroundLV,modtwROSkillGroundID,modtwROSkillGroundX,modtwROSkillGroundY,modtwROSkillObjectLV,modtwROSkillObjectID,modtwROSkillObjectTarg,modtwROAttackTarget=0,0,0,0,0,0,0,0
	modtwROAttackTarget,modtwROMoveX,modtwROMoveY=0,0,0
end








-- I SHOULDNT HAVE TO CODE THIS!
function modulo(a,b)
	return a-math.floor(a/b)*b
end
-- OR THIS!
function len(listin)
	local length=0
	for k,v in pairs(listin) do
		length = length + 1
	end
	return length
end

function absceil(x)
	if x>0 then
		return math.ceil(x)
	else
		return math.floor(x)
	end
end

function absunit(x)
	if x==0 then
		return 0
	elseif x > 0 then
		return 1
	else -- x < 0
		return -1
	end
end


-- Logging functions:

function 	FormatSkill(skill,level)
	if skill==nil then
		return "nil skill"
	end
	local output
	local name
	if SkillInfo[skill]==nil then
		name=skill
	elseif SkillInfo[skill][1]==nil then
		name=skill
	else
		name=SkillInfo[skill][1]
	end
	output = name.." ("..skill..")"
	if level == nil then
		return output
	else 
		return output.." level "..level
	end
end

function FormatMotion(motion)
	if motion==0 then
		return "Standing ("..motion..")"
	elseif motion==1 then
		return "Moving ("..motion..")"
	elseif motion==2 or motion==9 then 
		return "Attacking ("..motion..")"
	elseif motion==3 then 
		return "Dead ("..motion..")"
	elseif motion==4 then 
		return "Flinching  ("..motion..")"
	elseif motion==5 then
		return "Bending over ("..motion..")"
	elseif motion==6 then
		return "Sitting ("..motion..")"
	elseif motion==7 then 
		return "Using skill ("..motion..")"
	elseif motion==8 then
		return "Casting ("..motion..")"
	else
		return motion
	end
end

function formatval (val)
	if val == nil then
		return "nil"
	elseif type(val)=="string" then
		return "'"..val.."'"
	elseif type(val)=="function" then
		return "function"
	end
	return val
end

function logappend (filename,message)
	if LogEnable[filename]==1 then
		TraceAI("Logging "..filename.." - "..message)
		outfile = io.open("./"..filename..".log", "a")
		outfile:seek("end")
		if filename=="AAI_SKILLFAIL" then
			outfile:write(os.date("%c").." ("..GetTick()..") "..TypeString..MyState.."\t"..message.."\n")
		else
			outfile:write(os.date("%c").." "..TypeString..MyState.."\t"..message.."\n")
		end
		outfile:close()
	end
end

function formatmypos(steps)
	if steps>10 then
		logappend("AAI_ERROR","Invalid number of steps called for formatmypos() "..steps)
		steps=10
	elseif steps <1 then
		logappend("AAI_ERROR","Invalid number of steps called for formatmypos() "..steps)
		steps=1
	end
	local outstring=""
	for v=1,steps,1 do
		outstring=outstring.."("..MyPosX[v]..","..MyPosY[v]..")"
		if v~=step then
			outstring=outstring..","
		end
	end
	return outstring
end

function formatpos(x,y)
	return x..","..y
end
--------------------------------------------
-- List utility
--------------------------------------------
List = {}

function List.new ()
	return { first = 0, last = -1}
end

function List.pushleft (list, value)
	local first = list.first-1
	list.first  = first
	list[first] = value;
end

function List.pushright (list, value)
	local last = list.last + 1
	list.last = last
	list[last] = value
end

function List.popleft (list)
	local first = list.first
	if first > list.last then 
		return nil
	end
	local value = list[first]
	list[first] = nil         -- to allow garbage collection
	list.first = first+1
	return value
end

function List.popright (list)
	local last = list.last
	if list.first > last then
		return nil
	end
	local value = list[last]
	list[last] = nil
	list.last = last-1
	return value 
end

function List.clear (list)
	for i,v in ipairs(list) do
		list[i] = nil
	end
--[[
	if List.size(list) == 0 then
		return
	end
	local first = list.first
	local last  = list.last
	for i=first, last do
		list[i] = nil
	end
--]]
	list.first = 0
	list.last = -1
end

function List.size (list)
	local size = list.last - list.first + 1
	return size
end