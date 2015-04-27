1.56:
* Add support for taking over /AI
* Fix issue with pauses bugging up predictive move. 
* Corrected issue that could cause rescuer to get distracted .
* Corrected issue where state of skill use count could be lost.
* Corrected issue with Tanking tactic.


GUI:
+ Re-add allow SBR
+ Re-add lavaslidemode/poisonmistmode=3 with warning. 

1.551
* Correct issue with standpoint selection while attacking on low aspd homuns. 
* Extend AAI_Closest logging to cover the closely related AdjustStandPoint() function.
* Correct boneheaded mistake in AdjustStandPoint() which resulted in pathing hangs.
* Improve the wrapper for move to hopefully improve chase performance for things far away.
* When all targets are unreachable, return to owner in the hopes that they'll be reachable from there.
* Corrected issue with obstacle handling when chasing monsters near edges of screen. 

1.55
* Fix ChaseSPPause, UseDieterLavaSlide/UseSeraPoisonMist message in GUI.
* Add UseDieterVolcanicAsh and associated tactics options to GUI.
* Add UseSmartBulwark to GUI - for some reason it was missing. 
* Add support for using Volcanic Ash as a debuff.
* LagReduction can now be set to values higher than 1, this further slows homun responses, in an effort to reduce homun-lag on busy zone servers.
* New logging option to log all actions of lag reduction mode in H_Extra and M_Extra. 
* Change default LavaSlideMode and PoisonMistMode to 1 (Idle) by popular demand. 
* Improve logging for config errors. 
* Disable painkiller if sera doesn't have poison mist, since it can't have painkiller. It will still log complaint in AAIStartH
* Handle case where owner is surrounded by monsters so painkiller is impossible.

1.543 (test build)
* Improved logging in PROVOKE_ST

1.542 (test build)
* Correct issue with skill selection where tact_skillclass is set to a combo or grappler option. 
* Correct issue with grappler combos not working at all. 
* Correct issue with sphere counting. 
* Correct issue with AoEFixedLevel not being applied due to a typo.
* Added missing timeout globals to Const_.lua

1.541
* Correct client crash issue.
* Tighten limit on movement to 14 cell from owner instead of 15.

1.54
* Reorganize Standpoint to simplify code and give us a place to check for occupied cells
* Record occupied cells in AI() data gathering. 
* Check and correct for occupied cells on clients using Lua 5.1 only. 
* AI no longer uses monster location as "last resort" for chasing, as this no longer works. 
* New measures to prevent unwanted behavior from AttackTimeLimit 
* Corrected two issues that resulted in spurious errors being logged.
* AoEMaximizeTargets is now checked for skills other than brandish spear and focused arrow strike. 
* Corrected issue with debuffs obeying attack vs chasing tactic option.
* Added AttackDebuffWhenAttacked option - if set, debuffs set to be used while attacking are only used if the monster is attacking the homun or owner. 
* Corrected issue where skills could be erroneously determined to have failed, resulting in multicasting certain skills. This is not a perfect fix, but it should improve the matter. 
* Specific changes to painkiller to address issues with the cast time of that skill not matching expected values. 
* Corrected issue with monsters set React (Self) being attacked when they were attacking owner/friends, not just homun.
* Corrected error when using ATTACK_LAST and AttackLastFullSP options
* Corrected issue with AoEMaximizeTargets counting targets set to 'ignore'
* Corrected range of spear mecenary skills and normal attacks to 2, Dec Agi to 9, Lex Div to 5. 
* Corrected range and target mode of mercenary recovery skills. 
* Added improved logging to Attack State
* Corrected issue with manually commanding merc to use ground targeted skills. 
* Corrected cooldown of bloodlust. Added 10 sec grace time to bloodlust and mental charge to prevent it from missing the recast. 
* Reworked obstacle avoiding and poslag detection. 
* Documented AttackLastFullSP

GUI: 
* Add DoNotAttackMoving, LiveMobID
* Clarify AttackTimeLimit description
* New icon by Kami Kali 

1.53
* The case where the homun is in move command state but the location to move to is off screen or invalid is now recognized, and the movement command is ignored. Previously, the homun would hang in this state.
* UseSmartBulwark will now check ALL buff skills, and make sure you'll have enough SP for a full suite of buffs after casting bulwark. Note that you will want to also set ReserveSP if you want it to ever cast bulwark, otherwise it could keep it's SP below this threshold by casting attack skills, and it would never use bulwark
* Added LiveMobID option, under H_Extra and M_Extra. This allows MobID to be auto-generated as long as both homun and merc are present, with the homun "spotting" for the mercenary. Like AggressiveRelogTracking, this involves a lot of disk activity, and may produce poor performance if used on a system with a slow hard drive. 
* Merc AI will no longer crash if no Mob_ID.lua file is present. 
* Mob_ID file no longer requires array definition at start of file (MobID={}). 
* Corrected issue that could lead to double-casting of lava slide. 
* Cleaned up logic around skill fail detection to prevent potential bad things. 
* Improvements to the use of V_POSITION_APPLY_SKILLATTACKRANGE; it will now be ignored:
	* If it tells us to move to the location of the target to use a normal attack.
	* If alt ~= nil, indicating trouble moving to the target, we will now assume it's giving bad target cells.
	* If it tells us to move to the location of the target and it's a player (this is doomed to fail)
* Issue with PVPMode=1 causing merc to crash fixed
* Provoke will be recast more often to help prevent gaps in coverage. 
* Packages now contain USER_AI folder, which should hopefully help reduce installation confusion

GUI:
* No changes - LiveMobID will will be added to future version pending verification in the field. 

1.521
* Corected issue with 1 range skills being used on players. This was particularly relevant with painkiller, rendering the autocast useless. 

1.52
* If we see lua version 5.1.x we do the following differently;
   * Use builtin method to find stand point, unless doing motion prediction. 
   * Use V_SKILLATTACKRANGE_LEVEL as fallback if we face a skill we don't know the range for. 

* Fixed rarely encountered issue with Tanking which reduced responsiveness. 
* Added kludgy workaround to deal with the bathory in eden group. This will cause bathories in MOTION_STAND at 174,33 to be ignored. 
* AAI_ACTOR logging no longer hangs the client
* Add support for using Silent Breeze to heal owner, now that it's possible the owner could be immune to it's silence effect. Enable with HealOwnerBreeze
* IdleWalk should be more fluid. 
* If we can't write the startup log, we now throw an error that describes the problem.
* Improved coverage of Poison Mist when PoisonMistMode~=0
* We now default to PoisonMistMode=1 
* Cleaned up AttackRange and related functions to take advantage of new functionality and remove dead code
* Added formatval() utility function for plugin developers, which will convert any value into something safe to concatenate into a string, and enclose strings in single-quotes. Meant for logging, where you want to get the logging message when some value you're logging is nil (the exact case where you want to know all you can!), not a "concatenate nil value" error message. 

GUI:
* Add HealOwnerBreeze


1.51
* Issues with not attacking when at exactly 0 sp fixed
* Fix sevral issues with GUI not saving options correctly. 
* Clarify GUI messages about MOB_ID
* Corrected issue with PVP tactics in GUI
* Fix issue with Berserk Mode feature not working. 
* No longer attack clones produced by the Illusion: Shadow skill by default
* Fixed issue where homun would fail to return to owner when UseIdleWalk was enabled, but homun was not eligible for using idlewalk due to low HP/SP. 
* Integrated twRO lag mod as new option: LagReduction - Set to true (1) if you encounter lag with homun out. Setting this to true will reduce responsiveness of the homun, however. You may want to enable this only while using homun on particularly heavily loaded maps.
* New Feature: REACT_ tactics to use attack or defense skills in response to monster casting on you. 
* Fixed issues with OnSKILL_AREA_CMD_ST() which would be relevant if the devs ever fixed ground targeted skills to call SKILL_AREA_CMD instead of acting as though the player was using the skill (which causes the casts to often fail or cause the player to move, because it's trying to get the player in range instead of the homun). 
* Added DoSkillHandleMode() function to developer API. This is called when a skill is used by DoSkill() when DoSkill() has been passed a negative argument for mode. This allows you to handle this case. It is passed all arguments that DoSkill() is called with. 
* Added OnFailUnknownMode(mode) function to developer API. This is called when the AI thinks a skill has failed, and the mode is a positive value, but is not known to AzzyAI. 
* UseAutoMag and UseBayeriSteinWand now work with options other than idle.  
* UseAutoMag can now be set to the normal buff options
* Added support for new LagReduction option in GUI. 
* Fixed issue where homunculi were terrible at detecting successful skill casts. 
* Situation where buff timeouts are set to clearly bogus values now handled better for old buffs (we immediately attempt a recast, like we do for homun buffs, instead of waiting 300 seconds)

1.50 Final
* Fix issue with Amistr Bulwark
* Fix issue with timeout of mental charge getting reset
* Investigate possible issue with level 9 sword mercenary - cannot reproduce. 
* Corrected issue with skill fail detection on mercenaries; they do not have the distinct tell that homuns do in event of successful cast!
* Investigate issue with skill fail detection on painkiller - cannot reproduce.
* Corrected issue with spurrious error log entries regarding skill info type 3 on skill 0 level 0. 
* Add tactics to enable use of attack skills AND summon legion against a target.
* Corrected issue with obstacle handling and dance attack doing a bad job of selecting cells. 
* For LavaSlideMode/PoisonMistMode = 3 (ASAP), if we're having trouble moving into range, we'll call the builtin MoveToOwner. 
* For Painkiller owner, for buffmode 3 (ASAP), if we're having trouble moving into range, try the usual ways to get close to owner (since MoveToOwner only gets homun into 2 cells of owner, not close enough). 
* For buffmode 3 (ASAP) on targeted skills, we will no longer get stuck in a loop if unable to buff. Failed attempts will be retried in 20 seconds. 
* Corrected missing 'local' keyword in several helper functions in AzzyUtil, removed some dead code. 
* Improved logging around Closest() function, enable with LogClosest=1 in H_Extra
* Corrected default SeraCallLegionLevel to 5, instead of 0 which disabled use of the skill. 
* Corrected bugged bug detector for Call Legion to be less hasty to assume that the bugs are bugged, when they're still active and standing ready to assist their master.
* We will start trying to recast painkiller 1 second earlier now, since some people will rely on this staying up 100% of the time.
* Corrected issue where use of painkiller on other players via PainkillerFriends would be done at the wrong time, depending on UseSeraPainkiller. This would cause ASAP loops when UseSeraPainkiller was set to 3 (ASAP). 
* Corrected issue where circular routes could not be used with Castling (there may still be other issues with Castling Route to be corrected in a future version)
* Corrected issue where route walk would produce "attempt to concatenate global 'distance' (a nil value)" errors while the homun was standing on one of the cells in the route (including while loading, because the default route has step 0,0 and that is sometimes returned for GetV(V_POSITION) right after loading.
* When superpassive=1, commanding homun to use a skill on a monster will no longer cause the homun to begin attacking that monster with normal attacks or other skills.
* Corrected issue with new skill tactics not being handled while chasing
* Corrected issue with AoEFixedLevel not being honored while chasing
* Corrected several cases where UseHomunSSkillAttack and UseHomunSSkillChase not being honored.
* Tightened code involved in skill failure detection to hopefully do a better job of dealing with the inconsistent responses of the server and/or API.
* Corrected issue with incorrect prioritization during opportunistic target changing. 
* Fixed issue where error could appear when SuperPassive=1
* Added LogEnable options to H_Extra/M_Extra. 
* Corrected issue where sniping would not respect TACT_SKILLCLASS when using less common skill class tactics. 
* Expanded logging around error condition after manually commanding homun to use a skill. 
* Corrected rare issue where opportunisitc targeting or rescue could confuse predictive motion and generate errors or lead to erratic chasing movements. 
* UseAvoid will not kill the client until 5 seconds have passed since summoning homun - disconnecting during this time will not immediately remove the character in game, so it won't do any good.
* Corrected issue with merc+homun autofriend
* Corrected issue with dance attack bypassing UseSkillOnly
* Attack() being called in superpassive is no longer logged as error;
it is not an error, the owner can manually command homun to attack.
* Corrected issue where homun could become stuck when commanded to use
a skill on an actor which subsequently moves offscreen.
* Added support for Isis monster mercenary.
* Corrected issue with monster mercenaries not correctly closing to melee range. 


GUI:
* Add support for new tactics
* Corrected multiple issues with the SKILL_CLASS tactic option for mercenaries - for mercenary, only two values are valid - CLASS_BOTH and CLASS_MOB. 
* SeraCallLegionLevel can nolonger be set to invalid values like 0. 
* Clarified and corrected descriptions of AggroDist and MoveBounds options. Confusion over the difference between FollowStayBack and MoveBounds has been responsible for several spurrious bug reports. 
* Corrected issue with UseEiraSilentBreeze and EiraSilentBreezeLevel. 
* Corrected issue with saving certain buff related tactics. 
* Corrected issue with saving AutoMobCount
* Configuration Tool now forces itself to run as admin, just like the RO client. This should fix issues where the AI would load, but settings changes in the config tool would be ignored. 
* Corrected issue with loading AutoMobCount
* Corrected issue with SteinWandTelePause

1.50 dev 17.1
* Fixed issue with CHASE_NEVER tactic.

1.50 dev 17
* Fixed issue with Silent Breeze debuff tactic not being recognized. 
* Corrected issue where Silent Breeze skill would not be recognized on Eira. 
* Corrected issue with GetTact() handling of invalid tactics behaving incorrectly. 
* Spurrious error messages are no longer recorded when homun is summoned. 
* Corrected issue with several Eira skills. 

GUI: 
* Added option for UseEiraSilentBreeze, EiraSilentBreezeLevel

1.50 dev 16
* Fixed two critical issues with dev 15. 

1.50 dev 15

* Failed cast detection completely reworked, now based on a characteristic delay in AI() calls while the homun does the cast animation. 
* Added EleanorDoNotSwitchMode option. When this is enabled, all eleanor mode switching must be done manually; we will always assume we are in the right mode. This was requested by Meoryou2. 
* We now log the most recent time that the configuration tool has been used to modify the config file. 
* Added racooons to the default tactics to ignore. 
* Corrected issue with default configuration enabling ChaseSPPause by default
* We detect when someone has modified the AI to use the ranged pierce exploit and write a warning to AAIStartM.txt (assuming the modification was done in the obvious manner). AzzyAI does not condone the use of this exploit, and it may be prohibited on the RO that you play.
* Global variables moved to Const_.lua, this will make the code easier for me to manage. 
* When StickyStandby and DefendStandby are both enabled, homun will not attack targets aggressively if the owner attacks a monster with a lower priority. 
* Corrected issue where an Eleanor might use combo attacks when skill_class tactic was set to minions (ie, sera's summon swarm). 
* Added new grapple tactics. 
* Corrected skill data to include Tinderbreaker cast time. 
* DanceMinSP will not be checked when dancing due to being in berserk mode. 
* Corrected issue with UseEiraOveredBoost
* Corrected spelling of Eira related options
* Corrected issue where low level vani with less than 30 max SP would not autocast caprice. It will now cast the highest level of caprice it can with it's current max SP. 
* When we fail at moving into range to use Painkiller, or cast lavaslide or poison mist under the owner, we now take more aggressive actions. 

GUI:
* ASAP option removed for auto-mist and auto-lava slide. There are issues that could occur when this option was used which could result in a hung situation. 
* Added support for EleanorDoNotSwitchMode options
* Now records the date that start file was saved on to assist in debugging.
* StickyStandby = 2 now supported, this will save standby status through teleport/mapchange/relog. 
* Added support for new grapple tactics
* Corrected spelling of Eira related options

1.50 dev 14
* Added PainkillerFriends option, if set to 1, will try to keep painkiller up on all friended players. Additionally, if a player is manually targeted with painkiller, they will be added to the list of players to Painkiller. If PainkillerFriendsSave option is 1, these lists will be recorded, otherwise, they will only last until the next resummon. 
* Corrected incorrect SKILLCLASS tactic in default H_Tactics.lua
* Success of casting targeted buff skills was not being checked. This has been fixed. 
* Corrected issue where failure to use some skills would result in the AI crashing
* Corrected issue where failed skill use was not treated appropriately.
* Corrected issue with default mercenary configuration in M_Config.lua 
* Added OnAIEnd() callback to enable support for twRO-mod without losing stack space.

GUI:
* Added suport for Painkiller Friends related options. 

1.50 dev 13
* Fixed line 3135 error

1.50 dev 12
* Fixed issue with Eleanor mode switching
* Fixed issue with non-human-readable date/time in AAIStart file
* Enabled default/customized file detection in AAIStart file
* Added version checking to AAIStart file
* Improved handling of missing data folder; this will now log errors instead of crashing, and will also log to AAIStart. 
* If you have two accounts logged in at once on the same computer from the same RO installation, AND they are friended with eachother, they will autofriend eachothers homunculi and mercenaries. 
* See errata for additional notes on new features

GUI:
* Added IdleWalkSP option
* Fixed issue with GUI crash when working with tactics
* Fixed issue where "once, level:" option could be set for mercenaries; mercenary skills are not level-selectable. 
* Clarified description of LavaSlideMode and PoisonMistMode, corrected copy/paste error.
* Options relating to Painkiller now shown under autobuff options.

1.50 dev 11
* Added support for Pengineer mercenaries
* Improved mercenary identification. 
* Resolved issue with counting monsters for AoEMaximizeTargets that also spammed the error log.

1.50 dev 10
* Corrected issue with default SeraCallLegionLevel, RestXOff and RestYOff values
* Trapped and handled obstacle handling issue in following state. 
* Trapped and corrected several obstacle handling issues, including the one encountered at the enterance to anthell.
* Fixed spurrious log messages in PVPmode. 
* Fixed issue with enabling PVPmode. 
* Fixed issue with spurrious error messages when using a Sera homunculus. 
* Fixed issue with IdleWalk logging errors when starting IdleWalk routines.
* Added IdleWalkSP option. Set this to the SP (as a %) above which IdleWalk will be enabled.
* Fixed issue with level 5 of Caprice not being used. 
* Added verbose chase mode logging to facilitate debugging of likely issues with the new obstacle handling. 
* Logs to AAI_ERROR and similar are now recorded in AI traces.
* Removed spurrious AAI_ATK log file. 
* Corrected issue with document size bloat

1.50 dev 9
AI:
* Corrected issue with StickyMove referring to a function I never wrote. 
* Corrected issue with Summon Legion producing errors.
* Spelling errors in constant file fixed.
* ProvokeOwnerMobbed changed to DefensiveBuffOwnerMobbed, and now effects Kyrie not Provoke for mercenaries.
* ProvokeOwnerHP changed to DefensiveBuffOwnerHP, and now effects Kyrie, not Provoke for mercenaries.
* Painkiller use now controlled by new option UseSeraPainkiller.
* Added options to use the new GM mercenary skills
* Improved forward compatibility with future skills. Manual use will now not throw errors.
* Added support for new GM mercenaries.
* Corrected potential infinite loop scenario with skills set to be used "ASAP"
* Corrected issue where route walk caused errors. 
* Corrected issue where IdleWalk did not correctly calculate the relative positions of homun and owner. 
* Corrected issue where square IdleWalk pattern did not correctly deal with the top left corner. 
* Corrected issue where random IdleWalk pattern did not correctly calculate destinations.
* Corrected issue where IdleWalk would become confused if the homun paused en route.
* Corrected several issues involving route walk. 

Docs:
* Documented RescueOwnerLowHP
* Documented new buff features

GUI:
* Updated GUI to be compatible with systems running with non-US localization
* Updated GUI to include descriptions of kiting parameters. 
* Updated GUI to perform data validation on most numberical options
* Corrected issue with skill tactics in GUI
* Updated GUI to account for new and renamed options related to buffs
* Corrected issue with the GUI blanking M_Extra.lua
* Corrected several typos and option categorization issues.


1.50 dev 8:
* Updated AI to be compatible with clients running LUA 5.1 (such as fRO)

1.50 dev 7:
* Urgent Escape is now a defensive buff, not an offensive one
* Added support for using Mental Charge as an offensive buff for Lif type homunculi (not that you'd probably want to use it). 
* Updated documentation to reflect recent changes. 
* Updated documentation regarding installation procedure. 
* Replaced corrupted H_Config.lua and M_Config.lua with working version. 

GUI: 
* Added support for CLASS_MINION for the skillclass tactic. 

1.50 dev 6:
* Corrected issue with defensive buffs not working correctly when set to be used at times other than while idle. 
* Corrected issue where homun could end up in endless loop after unsuccessfully attempting to provoke or painkiller owner
* Corrected issue where the AI would crash sometimes when attempting to use painkiller on owner. 

GUI:
* Corrected issue with a crash while creating new tactics. 
* Corrected issue where AttackTimeLimit and AggroHP were confused, resulting in bogus settings being saved and causing the homun to abandon targets inappropriately.


1.50 dev 5:
* Fixed issue with missing PVP tactics files.
* Fixed error encountered with Sera homunculus S. 
* Added "as soon as possible" option to all buffs. Set the option to 3 to enable.
* Renamed UseAutoQuicken to UseOffensiveBuff.
* Renamed UseAutoGuard to UseDefensiveBuff.
* Renamed ReserveAoESP to AoEReserveSP.
* Renamed MobSkillFixedLevel to AoEFixedLevel.
* Renamed UseSmartAoE to AoEMaximizeTargets
* Renamed UseAutoSkill_MinSP to AttackSkillReserveSP
* Renamed UseAutoSkill to UseAttackSkill
* Renamed UseCleverChase to ChaseSPPause
* Renamed CleverChaseSP to ChaseSPPauseSP
* Renamed CleverChaseTime to ChaseSPPauseTime
* Added AttackTimeLimit option - time, in milliseconds, to attack something before deciding that you're not actually attacking it and mark it unreachable.

GUI:
* Added new config options, applied above renaming. 
* Added support for new tactics options.
* Added support for independent homun and merc PVP tactics. 
* Corrected issue where extras files were not properly saved. 
* Corrected issue where PVP tactics were not saved.




1.50 dev 4:
* Added support for CLASS_MINION skill class tactic - if this is set as skill tactic, Sera will use Call Legion on this class of monster
* UseSmartAOE now supports all skills (except brandish is still done approximately)
* Clever chase now prevents normal following too
* Other changes and fixes - changelog file got reverted at some point.
* Added basic PVP support 

1.50 dev 3
* Fixed issue with TACT_IGNORE and TACT_TANKMOB not working as advertised or intended. 
* Fixed multiple issues with CleverChase
* Added CHASE_CLEVER tactic; This is probably the correct way to use CleverChase. Monsters with the chase tactic set to CHASE_CLEVER will use CleverChase even if CleverChase is otherwise turned off. They will still observe CleverChaseSP and CleverChaseTime
* Fixed issue with Sera skill, Painkiller being spammed when it shouldn't. 
* Added tracking for the status of Sera's Legion (the rest of this functionality isn't done yet)
* Added ProvokeOwnerMobbed option - If owner is below 90% hp, and has at least this many monsters on him, THEN use provoke (ie, painkiller) on them. This way you can use it on a fragile genetic without wasting time casting it when he's safe and healthy.

* Added a few options for stonewalling as a bayeri (Stien Wand, that is. "Stien wand" is german for "stone wall")

BayeriSteinWandLevel - Use this level of steinwand - useful if you want to use shorter lasting one (at the expense of a flimsy wall)
UseStienWandTele - Use stienwand when you log in and when you land from teleport, but never any other time. I'd suggest using this with DoNotUseChase. 
StienWandTelePause - stand still for this long after casting stienwand

The idea is that you would land, pop stienwand, and then pause for a second or few while the monsters run to you, and then the bay can drop a Heilage Star (Holy Rod) on the monsters that run to you. 

UseBayeriSteinWand	- Use Stienwand when bay or owner is mobbed. Works like other kinds of buffs. 
UseSteinWandOwnerMob	- This many monsters on owner will trigger steinwand use. 0 = don't use stienwand in response to mobs on owner
UseSteinWandSelfMob	- This many monsters on the bay will trigger steinwand use. 0 = don't use stienwand in response to mobs on bay


Using both of these (UseSteinWandTele and using it while mobbed) is probably not a good idea. The two are not aware of eachother. 

1.50 dev 2
* Slimmed down documentation file size. 
* Fixed error when using all mercenaries. 
* Fixed error when using mercenaries with level 2 or higher of the skill Crash.
* Fixed issue with ReserveAoESP not working at all
* Fixed issue with ReserveAoESP not working for chase skills
* Fixed issue with ReserveAoESP not working for AoE-as-buff mode.
* Fixed issue with AOE-as-buff mode not working at all.
* Missing fix for Dieter skills (from 1.40 dev 20) replaced. 
* Fixed issue with AOE-as-buff mode failing to account for skills having a finite range.
* Fixed AutoMobMode=2 to correctly count only aggro monsters.
* We no longer count dead or dying monsters when deciding whether to use an AoE. This should correct the long-standing behavior where a homun deals the dying blow to 1 monster as another monster arrives, and then (with AutoMobCount=2) uses it's AoE attack on them. 
* Provoke only worked with mode 1 (during idle state). Now it works all the time. 

1.50 dev 1 - Initial 1.50 release, see ToDo list for more changes.  
* Added SP, Weight, Chase, and Snipe tactics.
* Added support for use of castling. 
* Replaced old system for idle walking motions
* Added option to use AoE skills like buffs on the owner.
* Added SP and skill failure watcher
* Added clever chase
* Implemented use of combo skills
* Added new basic tactics
* Added low priority heal option
* Added option for buffing at times other than in idle state.
* Improved support for multiple homuns
* Added option for aggressive tracking of relogs
* Treasure Boxes are now ignored by default as a fail-safe.
* Snipe will not be used if it should be using an AoE skill
* Added opportunistic target changes
* Added DanceMinSP option
* Various other changes and additions

1.41
* Fixed critical issue with mercenary AoE skills introduced by 1.40 dev 19 
* Fixed issue with UseSmartAOE when used with FAS which can cause the mercenary to incorrectly select targets with FAS when handling targets to the northwest or southeast of the mercenary. 
* The area of Brandish Spear is calculated incorrectly for comparison to UseAutoMobCount. This will be fixed in 1.50 as the framework planned for this is not ready. 
* Corrected improper use of FAS when there were not enough monsters on screen.
* Corrected issue with FAS target counting of monsters in the four cardinal directions being 2 cells narrower in the vertical direction (this meant that the area it was counting for east/west direction was only 1 cell wide).
* Corrected issue with FAS target counting of monsters in the diagonal directions always counting zero monsters. 
* Corrected issue with mercenaries failing to correctly use debuff skills
* Corrected AutoMobCount to 2 in default mercenary settings. 

1.40 Final
* Padded skill delays to reduce the liklihood of the AI trying to recast skills before the cooldown is up due to lag, flywings, etc. This is 5 seconds for bloodlust, 1-1.5 for flitting/accel flight - so you can still make it bug by winging around alot - or of course if you log out or manually cast the skill - but this should help significantly
* Padded lava slide and a few other skills with a short delay, because my tests indicate that they seem to have one, and we were trying to cast other skills during that delay and failing. 
* AI will not let you cast SBR 44 manually, unless you set AllowSBR44=1 in H_Extra. Misclick insurance. Unfortunately, I can't do the same for self destruct

1.40 dev 23 - release candidate
* Fixed MobSkillFixedLevel option
* RESCUE_ALL will now rescue if the target is friend or owner, but not if target is self. This makes a lot more sense. 
* Fixed issue with failing to use autobuffs on homunculi with more than one buff with a non-zero cast time and delay, due to failure to check delay status. 
* Corrected default H_Tactics to use basic tactic ATTACK_M instead of REACT_M, an error introduced by poor source control in dev 21 and 22. 
* Improved logging around autobuff and healing skills.
* Added function to improve human readability of skill-usage logging in future updates.

1.40 dev 22 - release candidate
* Fixed issue with Chaotic Blessings and Healing Hands not correctly using cooldown. 
* Fixed issue in which UseAutoSkill_MinSP would be ignored if Berserk_IgnoreMinSP (defaults to 1) was enabled, even when the AI wasn't in berserk mode.
* Cleaned up SP checking, much easier to read and work on now
* Cleaned up attack state logging. 
* New option for homuns: MobSkillFixedLevel - if set to 1, always use the level set via (homuntype)(skill)Level option (ex, DieterLavaSlideLevel)) for antimob skills, ignoring tactics stating otherwise. Defaults to 1. I've been seeing lots of people using lvl 1~4 of lava slide in OD2, and i'm pretty sure it's because they wanted to use lvl 1~4 of the bolt skills, but level 5 of lava slide.  
* Fixed issue with commanding homunculus to use skills not behaving as expected. 
* Fixed issue with UseSkillOnly mode not correctly using attack ranges
* Fixed issue with Sera skill Poison Mist not properly using cooldown
* Fixed major issue with incorrectly estimating casting times. 
* Fixed issue with incorrectly calculating cooldown options
* Added cooldown on Lava Slide ("what? you didn't have one already?" you say? See last point).
* Improved logging around skill cooldowns.  

1.40 dev 21 - release candidate
* Fixed issue with sniping
* Fixed issue with tanking
* Updated documentation

1.40 dev 20 - release candidate
* Fixed issue with Dieter selfbuff skills
* Added OnInit() call, for players to handle multiple homun AI configurations. 
* Added protection for file conflict issue when using multiple homuns at once - will now fail gracefully. 
* AoE skill count no longer counts killsteals as targets when deciding whether to cast an AoE
* Sonic claw delay is back, because the GMs added a short delay on it
* Added UseSmartBulwark option. 

1.40 dev 19 - release candidate
* Sonic claw will be spammed faster now
* Fixed issue with movement destination selection. This will fix issue with choosing non-optimal cells to move to, and prevent a hang possible under unusual conditions. 
* Corrected issue with monster counting function. 
* Corrected anti-mob skills to count the monsters within the AoE instead of the monsters currently near the homun. 
* Fixed timing for Sera's Poison Mist skill
* Internal stability improvements
* Added improved tracing for issue with failure to call AI()
* Improved reporting of serious error conditions. Please delete all AAI*.log files in your RO folder. 
* Improved reporting of time in AAIStartH/AAIStartM files.

1.40 dev 18 - release candidate
* Deactivate dance attack near edges of screen. This will prevent an obstacle-slide effect from pushing homun off screen.

1.40 dev 17
* Corrected bloodlust support
* Improved behavior when chasing moving targets - if you're faster, you'll catch it now. 
* Fixed issue with loop at edges of screen

1.40 dev 16
* Corrected issue with improper default values contributing to improperly dropped targets. 
* Improved system for chasing blocked targets. 
* Improved catches for rescue loops. 
* Possible improvement in dance attack
* Improved logging around chasing and movement. 


1.40 dev 15
* Independent cooldown timers for Moonlight, Caprice, Chaotic Blessing, and Healing Hands. I have not tested this with a homun with more than 1 attack skill since I don't have any yet, so try it out and see if it works. 
* Added improved logging to try to nail down a freeze bug.
* Support Bloodlust Autocast

1.40 dev 14
* Fixed critical issue that lead to homun running off screen.
* Fixed issue where fix for archers introduced with dev 7 was not applied when homun HP was above AggroHP
* Minor responsiveness tweaks. 
* Fixed more improper tail calls.
* Fixed a number of cases where responsiveness measures were being used improperly, forcing me to use more conservative settings for the responsiveness measures. This has been corrected. (this will be tested with more aggressive settings, and these will be included in the next version if they do not adversely effect stability).
* Fixed issue with improperly dropped targets
* Fixed issue with follow state in strongly adverse conditions. 
* Fixed issue with spurious warnings in AAI_Warning.log - changes introduced in dev 9 had led to warnings being produced under normal circumstance.

1.40 dev 13
* Fixed issue with moving long distances. 
* Improved chasing behavior, should fix the wobble.
* Improved boundary detection while chasing. 
* Fixed issue with SP being counted incorrectly when using skill levels other than max level
* Fixed issue a distance function in AzzyUtil.lua (no reported issues in the field). 
* Fixed issue with occasional target dropping while closing to melee range. 
* Fixed numerous serious bugs with skill while chasing. 


1.40 dev 12
* Fixed critical issue with sniping tactic. 

1.40 dev 11
* Fixed issue with provoke state. 
* Fixed issue with provoke skill info.
* Fixed issue with AI mistaking sacrifice for provoke
* Three above issues combined to cause crashes on homuns with sacrifice when autoprovoke was enabled.

1.40 Dev 10
* Fixed issue where we attempted to use math.huge which isn't implemented in lua 5.0.2
* Fixed issue where chase state tried to move to a target one last time after dropping it's old target. 
* Fixed line 667 error, which was caused by the combination of the two above bugs. 
* Corrected error where stationary aggrodist and movebound would be used if the owner was moving only in the north-south direction. 
* Improved logging for the closest cell calculations, because they're brittle and cause a lot of problems. 
* Corrected issue with ranged mercenaries moving 1 cell closer than they need to when approaching targets from the west and south. 

1.40 Dev 9
* Removed posbug correction code - was causing dropped targets, inappropriate dancing, and other issues because it is impossible to detect posbug due to GetV() bug, and hence was activating even when not posbugged. 
* Fixed issue with Sniping - TACT_SNIPE_L/M/H should now work. If you can 1-shot in OD2, try it out! Makes much better use of SP. 
* Fixed issue that could cause a high-speed homunculus to run off the screen chasing a monster. We will now drop the target instead. This was killing people in OD2.
* Fixed improper tail call from chase to idle.
* Default tactics are now a bit better: They default to not attacking the stupid event mobs, nor ants and giearths for doing ant eggs. 
* Set DoNotAttackMoving in H_Extra to make the homunculus not attack stuff that's moving. It'll still continue chasing them if they do move, though. This is not the final version of this feature, but it's been requested by several people - here's an interim solution. 


1.40 Dev 8 
Quick bugfix release
* Fixed follow obstacle fix from previous versions as it was not being used correctly
* Fixed attack posbug fix, which was suffering from an almost identical issue
* Fixed missing geographer tactic.

1.40 Dev 7x
* Fixed the attack chase loop bug.

1.40 Dev 7
* Added support for autoskill skill selection tactic - Manually edit H_Tactics.lua and chance the size tactic to CLASS_BOTH (to use either pre-S or homunS skills), CLASS_OLD (for pre-s skill only), or CLASS_S (for S skills only), or CLASS_MOB (if, for some reason, you want to use a mob skill on this, even if there aren't enough targets around to normally justify using a mob attack (per MobAttackCount) - i expect this to be most useful for mercenaries, particularly the lvl 10 sword merc, where you might want it to use BB for the higher damage - of course tactics for mercs require MobID - so maybe this isn't so useful.) For mercenaries, you can edit this using the GUI - use the TACT_SIZE tactic, SIZE_LARGE is the same as CLASS_MOB, SIZE_UNDEFINED should be used in all other cases (since there's no S-class skills for merc)
* Unified code between chase skill use and attack skill use
* Fixed longstanding issue with debuff while attacking which would prevent the homun from using debuffs while attacking if told via tactics to use a certain debuff skill. This bug has been present since 1.30 or earlier and had not been reported. Did anyone try to use this?
* Corrected boneheaded prioritization of targets which resulted in the homun aggroing new monsters while ignoring monsters currently attacking him. This was a really really nasty bug IMO. 
* FOLLOW_ST with FAST CHANGE did not use proper tail call when changing to IDLE_ST, this was corrected (internal change)
* Removed more obsolete code
* Fixed a few potential error message
* Fixed issue with empty AAI_Warning file
* Fixed error with bow mercenaries that have the skill Double Strafe
* Another change dedicated to truly eradicate the follow state hang.
* Fixed issue with inappropriate use of antiposbug measures which could cause problems around obstacles. 
* Fixed issue where the wrong measure of range was compared to MoveBounds for attacking monsters outside AggroDist, resulting in failure to defend against ranged attackers (like those blasted orc archers!) on the edges of the screen.  
* Improved tracing to try to trace down yet another freeze issue. 

1.40 Dev 6x2, 6x3
* Fixed issues in M_SkillList.lua

1.40 Dev 6x1
* Fixed missing config program and fixed an issue in M_SkillList.lua


1.40 Dev 6
* Corrected issue with AttackRange() leading to homuns not closing to 1 cell range, resulting in Filirs and Eleanors not closing to skill range
* Corrected issue with MotionClasses resulting in monsters currently targeting the owner not being correctly given priority
* Follow state no longer attempts to move to the owner's location; That doesn't work anymore. Follow state will now move to 1 cell range if it can't move to distance specified in FollowStayBack for ~500ms, and after another ~500ms it will use MoveToOwner() builtin. 
* Corrected issue where follow behavior did not return to normal if the homun was interrupted while in follow state. Combined with above, homun could hang in freeze state until vap/recalled. 
* M_SkillList.lua now loads. 
* Accellerated Flight now works. It is classified as a defensive skill (turn on UseAutoGuard to use it). 
* Obsolete code removed from AzzyUtil
* Pierce size removed. This variable and tactic will be removed or repurposed in a future release. 
* Added AoE info to the skill info database - this is not currently used. 
* Added additional AI tracing. 
* Removed unneeded files accidentally included in previous packages

1.40 Dev 5 
* HUGE internal overhaul of skill selection
* Fix for issue with manually commanding homun to use skills
* Fix for random error caused by new aggrodist/movebounds
* Fix for incorrect Stahl Horn range
* Closer to support for new buff skills
* Fix for vibrating homun when sitting issue.
* Support for Homun S buff skills



1.40 Dev 3
* Fixed issue with dance attack
* Fixed issue with chase targeting 
* Fixed issue with sniping activating incorrectly
* Fixed issue that may have been triggering freezes (sending invalid move commands)
* Fixed issue with poor handling of ranged monsters near edge of screen. See the two new AggroDist values in H_Extra
* Added support for Sera autocasting painkiller on you (set UseOwnerProvoke=1 in H_Extra to enable!)
* Added support for vani's healing themselves ( turn on UseAutoHeal and it will kick in automatically. Control the %hp that it will activate at with HealHomunHP in H_Extra)
* Added support for choosing which skills to use while chasing. 

** Known issue: Stahl horn is assumed to have a range of 5 at all levels, instead of 4+SkillLevel. The fix is understood, but a bit tedious (need to update all calls to a function). 


1.40 dev 2

* Fixed issues with chase when UseSkillOnly=0 that really should have been fixed long ago. (special thanks to Notepad ++ for this one!). My appologies to the people who reported this and who I accused of installing the AI wrong. There was a bug there afterall!
* Added framework to autouse Homun S buffs. 
* Fixed commands to use skills on non-monsters. Previously homun would not try to get in range to use the skill. 
* Added some development logging. Please contact me if an AAI_WARNING.log or AAI_RMsg.log is created in your RO folder!



1.40 dev 1, 1x: 
Fixes to critical (but trivial) bugs. 


1.40 dev 0  1/27/2012

AI: 
* Added basic support for new homuns.
* You must tell the AI which homun you had before if it's not a vani
* Made some improvements to motion locking issue - this is an issue I'm currently not entirely sure of the underlying basis of. I think it has to do with the horrible change to Move() behavior recently. 
* Added support for using Homun S skills automatically. This has known issues, but is probably better than before. 

* Features not anywhere near done. 





Final Release 4/23/2011

AI:
*Corrected issue with reacting to owner target
*Chose more intelligent defaults. 

GUI: 
*Corrected version numbers.

Documentation:
*Documentation now includes latest release notes and new Rescue feature. 

Dev 07 4/3/2011

AI: 
*Fixed rescue system
*Added 2 more rescue options

GUI:
*Fixed issue with debuff tactics. 
*Added support for new rescue options


Dev 06 3/25/2011

AI:
*Corrected critical bug causing error when summoning mercenary. My sincerest apologies for the delay in this fix, I had not monitored the forums, and was unaware of the issue. 

Dev 05 3/4/2011

GUI:
*GUI unchanged. Known issue with saving debuff data. 

AI:
*Corrected sp usage for Bloodlust
*Corrected default tactics files to not KS by default 
*Corrected bug with attack-state obstacle/terrain handling
*Improved performance of attach-state obstacle/terrain handling
*Corrected bug with targeting of summons.
*Corrected issue with magic number incorrectly identifying summons as non-summoned monsters. 
*Use proper tail calls to return to idle state from attack state
*Corrected issue with homun/merc targeting dying objects, greatly increasing perfomance in switching to new targets after killing one. 
*AAIStart files will now state whether the tactics and config have been modified. Useful 

Dev 04 2/14/2011

GUI:
*Fixed issue with blanking of Extras
*Fixed issue with setting skill tactic to 'Once; this level:' resulting in a crash;
*About box now displays accurate information, albeit in a much crappier form. 
*Help -> documentation now works
*Removed size option from homun tactics, as no homun tactics depend on size. 

Known but not fixed:
#tactics entries show as blanks in the list until GUI is exited and restarted. 


AI:
*Fixed line 1940 error, caused by leftover code from the old targeting system. 
*Added support for autouse of bloodlust on amistr. 

