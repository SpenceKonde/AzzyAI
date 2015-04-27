-----------------------------
-- Dr. Azzy's Homunculus AI
-- Written by Dr. Azzy of iRO Loki
-- Permission granted to distribute in unmodified form
-- Please contact me via the iRO Forums if you wish to modify
-- so that we can work together to extend and improve this AI.
-----------------------------
Version="1.56"
ErrorCode=""
ErrorInfo=""
LastSavedDate=""
TactLastSavedDate=""
TypeString="H"

dofile("./AI/USER_AI/Const_.lua")
dofile("./AI/USER_AI/H_SkillList.lua") 
dofile("./AI/USER_AI/Defaults.lua")
dofile("./AI/USER_AI/AzzyUtil.lua")
dofile("./AI/USER_AI/Stubs.lua")
dofile("./AI/USER_AI/A_Friends.lua")
dofile("./AI/USER_AI/H_Config.lua")
dofile("./AI/USER_AI/H_Tactics.lua")
dofile("./AI/USER_AI/AI_main.lua")
dofile("./AI/USER_AI/H_PVP_Tact.lua")
dofile("./AI/USER_AI/H_Avoid.lua")
dofile("./AI/USER_AI/H_Extra.lua")

function WriteStartupLog(Version,ErrorCode,ErrorInfo)
	local verspattern="%d.%d%d"
	if AUVersion==nil then
		AUVersion="1.30b or earlier"
		ErrorCode="File version error"
		ErrorInfo=ErrorInfo.."AzzyUtil.lua no version found"
	elseif string.gfind(AUVersion,verspattern)()~="1.552" then
		ErrorCode="File version error"
		ErrorInfo=ErrorInfo.."AzzyUtil.lua wrong version "..string.gfind(AUVersion,verspattern)().."\n"
	end
	TestFile=io.open("./AI/USER_AI/data/test.txt","w")
	if TestFile~=nil then
		TestFile:close()
	else
		ErrorCode="cannot create files in data folder"
		ErrorInfo=ErrorInfo.." Data folder likely missing. Create folder named 'data' in USER_AI "
	end
	if CVersion==nil then
		CVersion="1.30b or earlier"
		ErrorCode="File version error"
		ErrorInfo=ErrorInfo.."Const_.lua no version found"
	elseif string.gfind(CVersion,verspattern)()~="1.56" then
		ErrorCode="File version error"
		ErrorInfo=ErrorInfo.."Const_.lua wrong version "..string.gfind(CVersion,verspattern)().."\n"
	end
	if MainVersion==nil then
		MainVersion="1.30b or earlier"
		ErrorCode="File version error"
		ErrorInfo=ErrorInfo.." AI_main.lua no version found"
	elseif string.gfind(MainVersion,verspattern)()~="1.56" then
		ErrorCode="File version error"
		ErrorInfo=ErrorInfo.."AI_main.lua wrong version "..string.gfind(MainVersion,verspattern)().."\n"
	end
	--[[
	if fsize("./AI/USER_AI/AzzyUtil.lua")~=AULen then
		ErrorCode="Damaged File"
		ErrorInfo=ErrorInfo.." AzzyUtil.lua has been modified or is corrupted"
	end
	if fsize("./AI/USER_AI/Const_.lua")~=ConstLen then
		ErrorCode="Damaged File"
		ErrorInfo=ErrorInfo.." Const_.lua has been modified or is corrupted"
	end
	if fsize("./AI/USER_AI/AI_main.lua")~=MainLen then
		ErrorCode="Damaged File"
		ErrorInfo=ErrorInfo.." AI_main.lua has been modified or corrupted"
	end
	--]]
	if fsize("./AI/USER_AI/H_Config.lua")==3898 then
		ConfigVers="Default: "..LastSavedDate
	else
		ConfigVers="Custom, edited "..LastSavedDate
	end
	if fsize("./AI/USER_AI/H_Tactics.lua")==5393 then
		TacticVers="Default: "..TactLastSavedDate
	else
		TacticVers="Custom, edited "..TactLastSavedDate
	end
	local OutString
	if ErrorCode=="" then
		OutString="AzzyAI (hom) version "..Version.."\nMain version:"..MainVersion.."\nAzzyUtil version:"..AUVersion.."\nConstant version:"..CVersion.."\nConfig: "..ConfigVers.."\nTactics: "..TacticVers.." \nTime: "..os.date("%c").."\nLua Version:".._VERSION.."\nstarted successfully. \n This AI is installed properly"
	else
		OutString="AzzyAI (hom) version "..Version.."\nMain version:"..MainVersion.."\nAzzyUtil version:"..AUVersion.."\nConstant version:"..CVersion.."\nConfig: "..ConfigVers.."\nTactics: "..TacticVers.." \nTime: "..os.date("%c").."\nLua Version".._VERSION.."\nError: "..ErrorCode.." "..ErrorInfo
	end
	OutFile=io.open("AAIStartH.txt","w")
	if OutFile == nil then
		Error("No write permissions for RO folder, please fix permissions on the RO folder in order to use AzzyAI. Version Info: "..OutString)
	else
		OutFile:write(OutString)
		OutFile:close()
	end
end

function fsize(file)
	local f=io.open(file,"r")
	local size = f:seek("end")
	f:close()
	return size
end

WriteStartupLog(Version,ErrorCode,ErrorInfo)
-------------------------------
-- Add no code to this file
---------------------------------