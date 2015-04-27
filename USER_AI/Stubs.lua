function NewState(state)
	if state==0 then --replace with the name of your new state, and specify variable for it in extras.lua
		return OnIDLE_ST() --replace this with your new state function. 
	else
		return -1 --signifying an invalid state
	end
end
function OnInit()
	return
end
function OnAImiddle() --called after info gathering, but before emergency processing
	return
end
function OnAIstart() --called at the start of AI()
	return
end
function OnAIEnd() --called at the end of AI() after everything else.
	return
end
function OnIdleTasks() --called when AI is in IDLE_ST. 
	return 0 --return 1 to skip the rest of OnIdleSt()
end
function OnAttackStart() -- Called in attack state, after checking whether to leave attack, and after checking for 
	return 0
end
function OnChaseStart() -- Called in chase state, after checking whether to leave chase, but before taking any actions to do chasing. 
	return 0
end
function OnAutoBuffs(buffmode) --called at the end of calling autobuff routine. Buffmode is the buff mode (ie, 1=idle etc). Return nil if your code did something and the current AI() function should return as well, otherwise YOU MUST RETURN 1!!!
	return 1
end
function DoSkillHandleMode(skill,level,target,mode,targx,targy)
	return 0
end
function OnFailUnknownMode(mode)
	return
end