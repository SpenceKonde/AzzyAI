--twRO lag fix mod for non-AzzyAI AI's. 
--to install, place in USER_AI, and add dofile("./AI/USER_AI/twRO.lua") to the end of AI.lua (or in another location where it will execute after the function definition for AI())
--This chops 1 level off of the stack. 

LogEnable["AAI_Lag"]=0

modtwROMoveDid =0
modtwROAttackDid=0
modtwROSkillGroundLV,modtwROSkillGroundID,modtwROSkillGroundX,modtwROSkillGroundY,modtwROSkillObjectLV,modtwROSkillObjectID,modtwROSkillObjectTarg,modtwROAttackTarget=0,0,0,0,0,0,0,0
modtwROAttackTarget,modtwROMoveX,modtwROMoveY=0,0,0

modtwROExMove=Move

function Move(myid,x,y)
	logappend("AAI_Lag","Move called by AI proper"..formatpos(x,y))
	modtwROMoveX=x
	modtwROMoveY=y
end

modtwROExSkillObject=SkillObject
function SkillObject(myid,lvl,skill,target)
	logappend("AAI_Lag","SkillObject called by AI proper"..FormatSkill(skill,level))
	modtwROSkillObjectID=skill
	modtwROSkillObjectLV=lvl
	modtwROSkillObjectTarg=target
end

modtwROExSkillGround=SkillGround
function SkillGround(myid,lvl,skill,x,y)
	logappend("AAI_Lag","SkillGround called by AI proper "..FormatSkill(skill,level).." "..formatpos(x,y))
	modtwROSkillGroundX=x
	modtwROSkillGroundY=y
	modtwROSkillGroundID=skill
	modtwROSkillGroundLV=lvl
end

modtwROExAttack=Attack
function Attack(myid,target)
	logappend("AAI_Lag","Attack called by AI proper "..target)
	modtwROAttackTarget=target
end

modtwROExAI=AI
function AI(myid)
	modtwROExAI(myid)
	if modtwROSkillGroundID~=0 then
		logappend("AAI_Lag","Calling skillground function")
		modtwROExSkillGround(MyID,modtwROSkillGroundLV,modtwROSkillGroundID,modtwROSkillGroundX,modtwROSkillGroundY)
	elseif modtwROSkillObjectID~=0 then
		logappend("AAI_Lag","Calling SkillObject function")
		modtwROExSkillObject(MyID,modtwROSkillObjectLV,modtwROSkillObjectID,modtwROSkillObjectTarg)
	else
		if modtwRODidMove==0 then
			if modtwROMoveX~=0 then
				logappend("AAI_Lag","Calling Move function, didmove=0")
				modtwROExMove(MyID,modtwROMoveX,modtwROMoveY)
				modtwRODidMove=1
				modtwRODidAttack=0
			end
		else
			modtwRODidMove=0
		end
		if modtwRODidAttack==0 then
			if modtwROAttackTarget~=0 then
				logappend("AAI_Lag","Calling attack function, didattack=0")
				modtwROExAttack(MyID,modtwROAttackTarget)
				modtwRODidAttack=1
			end
		else
			modtwRODidAttack=0
		end
	end
	modtwROSkillGroundLV,modtwROSkillGroundID,modtwROSkillGroundX,modtwROSkillGroundY,modtwROSkillObjectLV,modtwROSkillObjectID,modtwROSkillObjectTarg,modtwROAttackTarget=0,0,0,0,0,0,0,0
	modtwROAttackTarget,modtwROMoveX,modtwROMoveY=0,0,0
end