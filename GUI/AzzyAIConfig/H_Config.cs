// H_Config.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the static class H_Config, which is used to store
// the values of the H_Config.lua configuration file.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;



namespace AzzyAIConfig
{
    static class H_Config
    {
        #region Load
        public static void Load(string fileName)
        {
            // Read the contents from fileName
            string file = File.ReadAllText(fileName);

            // Load the configurations from the contents
            LoadBasicOptions(file);
            LoadAutoSkillOptions(file);
            LoadWalkFollowOptions(file);
            LoadAutobuffOptions(file);
            LoadKitingOptions(file);
            LoadFriendingOptions(file);
            LoadStandbyOptions(file);
            LoadBerserkOptions(file);
            LoadPVPOptions(file);

            // Output to the console "Loading complete."
            Program.WriteLine("Loading complete.");
        }

        static void LoadBasicOptions(string file)
        {
            // Output to the console "Loading Basic Options"
            Program.WriteLine("Loading Basic Options");

            // Check for each Basic Option variable in the file contents and store it
            if (Regex.IsMatch(file, "AggroHP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AggroHP = Convert.ToInt32(Regex.Match(file, "AggroHP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AggroSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AggroSP = Convert.ToInt32(Regex.Match(file, "AggroSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            
            if (Regex.IsMatch(file, "KiteMonsters\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                KiteMonsters = Convert.ToInt32(Regex.Match(file, "KiteMonsters\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "PainkillerFriends\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                PainkillerFriends = Convert.ToInt32(Regex.Match(file, "PainkillerFriends\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "PainkillerFriendsSave\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                PainkillerFriendsSave = Convert.ToInt32(Regex.Match(file, "PainkillerFriendsSave\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "SuperPassive\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                SuperPassive = Convert.ToInt32(Regex.Match(file, "SuperPassive\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseAttackSkill\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseAttackSkill = Convert.ToInt32(Regex.Match(file, "UseAttackSkill\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AssumeHomun\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AssumeHomun = Convert.ToInt32(Regex.Match(file, "AssumeHomun\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DoNotChase\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DoNotChase = Convert.ToInt32(Regex.Match(file, "DoNotChase\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDanceAttack\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDanceAttack = Convert.ToInt32(Regex.Match(file, "UseDanceAttack\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseAvoid\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseAvoid = Convert.ToInt32(Regex.Match(file, "UseAvoid\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "TankMonsterLimit\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                TankMonsterLimit = Convert.ToInt32(Regex.Match(file, "TankMonsterLimit\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "RescueOwnerLowHP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                RescueOwnerLowHP = Convert.ToInt32(Regex.Match(file, "RescueOwnerLowHP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "StationaryAggroDist\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                StationaryAggroDist = Convert.ToInt32(Regex.Match(file, "StationaryAggroDist\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "MobileAggroDist\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                MobileAggroDist = Convert.ToInt32(Regex.Match(file, "MobileAggroDist\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "OldHomunType\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                OldHomunType = Convert.ToInt32(Regex.Match(file, "OldHomunType\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "OpportunisticTargeting\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                OpportunisticTargeting = Convert.ToInt32(Regex.Match(file, "OpportunisticTargeting\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AttackLastFullSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AttackLastFullSP = Convert.ToInt32(Regex.Match(file, "AttackLastFullSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DanceMinSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DanceMinSP = Convert.ToInt32(Regex.Match(file, "DanceMinSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AttackTimeLimit\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AttackTimeLimit = Convert.ToInt32(Regex.Match(file, "AttackTimeLimit\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "LagReduction\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                LagReduction = Convert.ToInt32(Regex.Match(file, "LagReduction\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DoNotAttackMoving\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DoNotAttackMoving = Convert.ToInt32(Regex.Match(file, "DoNotAttackMoving\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "LiveMobID\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                LiveMobID = Convert.ToInt32(Regex.Match(file, "LiveMobID\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadAutoSkillOptions(string file)
        {
            // Output to the console "Loading AutoSkill Options"
            Program.WriteLine("Loading AutoSkill Options");

            // Check for each AutoSkill Option variable in the file contents and store it
            if (Regex.IsMatch(file, "AttackSkillReserveSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AttackSkillReserveSP = Convert.ToInt32(Regex.Match(file, "AttackSkillReserveSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AutoMobCount\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoMobCount = Convert.ToInt32(Regex.Match(file, "AutoMobCount\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSkillOnly\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSkillOnly = Convert.ToInt32(Regex.Match(file, "UseSkillOnly\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AutoSkillDelay\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoSkillDelay = Convert.ToInt32(Regex.Match(file, "AutoSkillDelay\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AutoSkillLimit\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoSkillLimit = Convert.ToInt32(Regex.Match(file, "AutoSkillLimit\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseAutoPushback\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseAutoPushback = Convert.ToInt32(Regex.Match(file, "UseAutoPushback\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AutoPushbackThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoPushbackThreshold = Convert.ToInt32(Regex.Match(file, "AutoPushbackThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AoEReserveSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AoEReserveSP = Convert.ToInt32(Regex.Match(file, "AoEReserveSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AoEFixedLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AoEFixedLevel = Convert.ToInt32(Regex.Match(file, "AoEFixedLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AutoMobMode\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoMobMode = Convert.ToInt32(Regex.Match(file, "AutoMobMode\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AutoComboMode\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoComboMode = Convert.ToInt32(Regex.Match(file, "AutoComboMode\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AutoComboSpheres\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoComboSpheres = Convert.ToInt32(Regex.Match(file, "AutoComboSpheres\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseHomunSSkillChase\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseHomunSSkillChase = Convert.ToInt32(Regex.Match(file, "UseHomunSSkillChase\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseHomunSSkillAttack\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseHomunSSkillAttack = Convert.ToInt32(Regex.Match(file, "UseHomunSSkillAttack\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AoEMaximizeTargets\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AoEMaximizeTargets = Convert.ToInt32(Regex.Match(file, "AoEMaximizeTargets\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseEiraXenoSlasher\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseEiraXenoSlasher = Convert.ToInt32(Regex.Match(file, "UseEiraXenoSlasher\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "EiraXenoSlasherLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                EiraXenoSlasherLevel = Convert.ToInt32(Regex.Match(file, "EiraXenoSlasherLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseEiraEraseCutter\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseEiraEraseCutter = Convert.ToInt32(Regex.Match(file, "UseEiraEraseCutter\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "EiraEraseCutterLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                EiraEraseCutterLevel = Convert.ToInt32(Regex.Match(file, "EiraEraseCutterLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseEiraSilentBreeze\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseEiraSilentBreeze = Convert.ToInt32(Regex.Match(file, "UseEiraSilentBreeze\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "EiraSilentBreezeLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                EiraSilentBreezeLevel = Convert.ToInt32(Regex.Match(file, "EiraSilentBreezeLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBayeriStahlHorn\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBayeriStahlHorn = Convert.ToInt32(Regex.Match(file, "UseBayeriStahlHorn\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "BayeriStahlHornLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                BayeriStahlHornLevel = Convert.ToInt32(Regex.Match(file, "BayeriStahlHornLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBayeriHailegeStar\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBayeriHailegeStar = Convert.ToInt32(Regex.Match(file, "UseBayeriHailegeStar\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "BayeriHailegeStarLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                BayeriHailegeStarLevel = Convert.ToInt32(Regex.Match(file, "BayeriHailegeStarLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSeraParalyze\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSeraParalyze = Convert.ToInt32(Regex.Match(file, "UseSeraParalyze\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "SeraParalyzeLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                SeraParalyzeLevel = Convert.ToInt32(Regex.Match(file, "SeraParalyzeLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSeraPoisonMist\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSeraPoisonMist = Convert.ToInt32(Regex.Match(file, "UseSeraPoisonMist\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "SeraPoisonMistLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                SeraPoisonMistLevel = Convert.ToInt32(Regex.Match(file, "SeraPoisonMistLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseEleanorSonicClaw\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseEleanorSonicClaw = Convert.ToInt32(Regex.Match(file, "UseEleanorSonicClaw\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "EleanorDoNotSwitchMode\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                EleanorDoNotSwitchMode = Convert.ToInt32(Regex.Match(file, "EleanorDoNotSwitchMode\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "EleanorSonicClawLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                EleanorSonicClawLevel = Convert.ToInt32(Regex.Match(file, "EleanorSonicClawLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "EleanorSilverveinLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                EleanorSilverveinLevel = Convert.ToInt32(Regex.Match(file, "EleanorSilverveinLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "EleanorMidnightLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                EleanorMidnightLevel = Convert.ToInt32(Regex.Match(file, "EleanorMidnightLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDieterLavaSlide\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDieterLavaSlide = Convert.ToInt32(Regex.Match(file, "UseDieterLavaSlide\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDieterVolcanicAsh\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDieterVolcanicAsh = Convert.ToInt32(Regex.Match(file, "UseDieterVolcanicAsh\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DieterLavaSlideLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DieterLavaSlideLevel = Convert.ToInt32(Regex.Match(file, "DieterLavaSlideLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSeraCallLegion\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSeraCallLegion = Convert.ToInt32(Regex.Match(file, "UseSeraCallLegion\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "SeraCallLegionLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                SeraCallLegionLevel = Convert.ToInt32(Regex.Match(file, "SeraCallLegionLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadWalkFollowOptions(string file)
        {
            // Output to the console "Loading Walk/Follow Options"
            Program.WriteLine("Loading Walk/Follow Options");

            // Check for each Walk/Follow Option variable in the file contents and store it
            if (Regex.IsMatch(file, "FollowStayBack\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                FollowStayBack = Convert.ToInt32(Regex.Match(file, "FollowStayBack\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            
            if (Regex.IsMatch(file, "RestXOff\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                RestXOff = Convert.ToInt32(Regex.Match(file, "RestXOff\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "RestYOff\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                RestYOff = Convert.ToInt32(Regex.Match(file, "RestYOff\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DoNotUseRest\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DoNotUseRest = Convert.ToInt32(Regex.Match(file, "DoNotUseRest\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "SpawnDelay\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                SpawnDelay = Convert.ToInt32(Regex.Match(file, "SpawnDelay\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "MoveSticky\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                MoveSticky = Convert.ToInt32(Regex.Match(file, "MoveSticky\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "MoveStickyFight\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                MoveStickyFight = Convert.ToInt32(Regex.Match(file, "MoveStickyFight\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseIdleWalk\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseIdleWalk = Convert.ToInt32(Regex.Match(file, "UseIdleWalk\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "IdleWalkSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                IdleWalkSP = Convert.ToInt32(Regex.Match(file, "IdleWalkSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseCastleRoute\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseCastleRoute = Convert.ToInt32(Regex.Match(file, "UseCastleRoute\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "RelativeRoute\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                RelativeRoute = Convert.ToInt32(Regex.Match(file, "RelativeRoute\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "IdleWalkDistance\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                IdleWalkDistance = Convert.ToInt32(Regex.Match(file, "IdleWalkDistance\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "ChaseSPPause\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                ChaseSPPause = Convert.ToInt32(Regex.Match(file, "ChaseSPPause\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "ChaseSPPauseSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                ChaseSPPauseSP = Convert.ToInt32(Regex.Match(file, "ChaseSPPauseSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "ChaseSPPauseTime\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                ChaseSPPauseTime = Convert.ToInt32(Regex.Match(file, "ChaseSPPauseTime\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "StationaryMoveBounds\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                StationaryMoveBounds = Convert.ToInt32(Regex.Match(file, "StationaryMoveBounds\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "MobileMoveBounds\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                MobileMoveBounds = Convert.ToInt32(Regex.Match(file, "MobileMoveBounds\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadAutobuffOptions(string file)
        {
            // Output to the console "Loading Autobuff Options"
            Program.WriteLine("Loading Autobuff Options");

            // Check for each Autobuff Option variable in the file contents and store it
            if (Regex.IsMatch(file, "UseOffensiveBuff\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseOffensiveBuff = Convert.ToInt32(Regex.Match(file, "UseOffensiveBuff\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDefensiveBuff\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDefensiveBuff = Convert.ToInt32(Regex.Match(file, "UseDefensiveBuff\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "LifEscapeLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                LifEscapeLevel = Convert.ToInt32(Regex.Match(file, "LifEscapeLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "FilirFlitLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                FilirFlitLevel = Convert.ToInt32(Regex.Match(file, "FilirFlitLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AmiBulwarkLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AmiBulwarkLevel = Convert.ToInt32(Regex.Match(file, "AmiBulwarkLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "HealOwnerHP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                HealOwnerHP = Convert.ToInt32(Regex.Match(file, "HealOwnerHP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseAutoHeal\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseAutoHeal = Convert.ToInt32(Regex.Match(file, "UseAutoHeal\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "HealOwnerBreeze\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                HealOwnerBreeze = Convert.ToInt32(Regex.Match(file, "HealOwnerBreeze\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "FilirAccelLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                FilirAccelLevel = Convert.ToInt32(Regex.Match(file, "FilirAccelLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSeraPainkiller\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSeraPainkiller = Convert.ToInt32(Regex.Match(file, "UseSeraPainkiller\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DefensiveBuffOwnerMobbed\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DefensiveBuffOwnerMobbed = Convert.ToInt32(Regex.Match(file, "DefensiveBuffOwnerMobbed\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBayeriAngriffModus\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBayeriAngriffModus = Convert.ToInt32(Regex.Match(file, "UseBayeriAngriffModus\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBayeriGoldenPherze\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBayeriGoldenPherze = Convert.ToInt32(Regex.Match(file, "UseBayeriGoldenPherze\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDieterMagmaFlow\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDieterMagmaFlow = Convert.ToInt32(Regex.Match(file, "UseDieterMagmaFlow\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDieterGraniticArmor\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDieterGraniticArmor = Convert.ToInt32(Regex.Match(file, "UseDieterGraniticArmor\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDieterPyroclastic\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDieterPyroclastic = Convert.ToInt32(Regex.Match(file, "UseDieterPyroclastic\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DieterPyroclasticLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DieterPyroclasticLevel = Convert.ToInt32(Regex.Match(file, "DieterPyroclasticLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseEiraOveredBoost\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseEiraOveredBoost = Convert.ToInt32(Regex.Match(file, "UseEiraOveredBoost\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "HealSelfHP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                HealSelfHP = Convert.ToInt32(Regex.Match(file, "HealSelfHP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "LavaSlideMode\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                LavaSlideMode = Convert.ToInt32(Regex.Match(file, "LavaSlideMode\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "PoisonMistMode\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                PoisonMistMode = Convert.ToInt32(Regex.Match(file, "PoisonMistMode\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBayeriSteinWand\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBayeriSteinWand = Convert.ToInt32(Regex.Match(file, "UseBayeriSteinWand\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "BayeriSteinWandLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                BayeriSteinWandLevel = Convert.ToInt32(Regex.Match(file, "BayeriSteinWandLevel\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSteinWandSelfMob\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSteinWandSelfMob = Convert.ToInt32(Regex.Match(file, "UseSteinWandSelfMob\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSteinWandOwnerMob\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSteinWandOwnerMob = Convert.ToInt32(Regex.Match(file, "UseSteinWandOwnerMob\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSteinWandTele\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSteinWandTele = Convert.ToInt32(Regex.Match(file, "UseSteinWandTele\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "SteinWandTelePause\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                SteinWandTelePause = Convert.ToInt32(Regex.Match(file, "SteinWandTelePause\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseCastleDefend\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseCastleDefend = Convert.ToInt32(Regex.Match(file, "UseCastleDefend\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "CastleDefendThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                CastleDefendThreshold = Convert.ToInt32(Regex.Match(file, "CastleDefendThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSmartBulwark\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSmartBulwark = Convert.ToInt32(Regex.Match(file, "UseSmartBulwark\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadKitingOptions(string file)
        {
            // Output to the console "Loading Kiting Options"
            Program.WriteLine("Loading Kiting Options");

            // Check for each Kiting Option variable in the file contents and store it
            if (Regex.IsMatch(file, "KiteParanoid\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                KiteParanoid = Convert.ToInt32(Regex.Match(file, "KiteParanoid\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "KiteStep\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                KiteStep = Convert.ToInt32(Regex.Match(file, "KiteStep\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "KiteParanoidStep\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                KiteParanoidStep = Convert.ToInt32(Regex.Match(file, "KiteParanoidStep\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "KiteThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                KiteThreshold = Convert.ToInt32(Regex.Match(file, "KiteThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "KiteParanoidThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                KiteParanoidThreshold = Convert.ToInt32(Regex.Match(file, "KiteParanoidThreshold\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "KiteBounds\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                KiteBounds = Convert.ToInt32(Regex.Match(file, "KiteBounds\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "ForceKite\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                ForceKite = Convert.ToInt32(Regex.Match(file, "ForceKite\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            } 
            if (Regex.IsMatch(file, "FleeHP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                FleeHP = Convert.ToInt32(Regex.Match(file, "FleeHP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadFriendingOptions(string file)
        {
            // Output to the console "Loading Friending Options"
            Program.WriteLine("Loading Friending Options");

            // Check for each Friending Option variable in the file contents and store it
            if (Regex.IsMatch(file, "StandbyFriending\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                StandbyFriending = Convert.ToInt32(Regex.Match(file, "StandbyFriending\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "MirAIFriending\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                MirAIFriending = Convert.ToInt32(Regex.Match(file, "MirAIFriending\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadStandbyOptions(string file)
        {
            // Output to the console "Loading Standby Options"
            Program.WriteLine("Loading Standby Options");

            // Check for each Standby Option variable in the file contents and store it
            if (Regex.IsMatch(file, "DefendStandby\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DefendStandby = Convert.ToInt32(Regex.Match(file, "DefendStandby\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "StickyStandby\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                StickyStandby = Convert.ToInt32(Regex.Match(file, "StickyStandby\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadBerserkOptions(string file)
        {
            // Ouput to the console "Loading Berserk Options"
            Program.WriteLine("Loading Berserk Options");

            // Check for each Berserk Option variable in the file contents and store it
            if (Regex.IsMatch(file, "UseBerserkMobbed\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBerserkMobbed = Convert.ToInt32(Regex.Match(file, "UseBerserkMobbed\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBerserkSkill\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBerserkSkill = Convert.ToInt32(Regex.Match(file, "UseBerserkSkill\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBerserkAttack\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBerserkAttack = Convert.ToInt32(Regex.Match(file, "UseBerserkAttack\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "Berserk_SkillAlways\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                Berserk_SkillAlways = Convert.ToInt32(Regex.Match(file, "Berserk_SkillAlways\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "Berserk_Dance\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                Berserk_Dance = Convert.ToInt32(Regex.Match(file, "Berserk_Dance\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            } 
            if (Regex.IsMatch(file, "Berserk_IgnoreMinSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                Berserk_IgnoreMinSP = Convert.ToInt32(Regex.Match(file, "Berserk_IgnoreMinSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "Berserk_ComboAlways\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                Berserk_ComboAlways = Convert.ToInt32(Regex.Match(file, "Berserk_ComboAlways\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }

        static void LoadPVPOptions(string file)
        {
            // Output to the console "Loading PVP Options"
            Program.WriteLine("Loading PVP Options");

            // Check for each PVP Option variable in the file contents and store it
            if (Regex.IsMatch(file, "PVPmode\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                PVPmode = Convert.ToInt32(Regex.Match(file, "PVPmode\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
        }
        #endregion

        #region Save
        public static void Save(string fileName)
        {
            // Read the file contents from fileName
            string file = File.ReadAllText(fileName);

            // Update the file contents with the current values
            file = SaveBasicOptions(file);
            file = SaveAutoSkillOptions(file);
            file = SaveWalkFollowOptions(file);
            file = SaveAutobuffOptions(file);
            file = SaveKitingOptions(file);
            file = SaveFriendingOptions(file);
            file = SaveStandbyOptions(file);
            file = SaveBerserkOptions(file);
            file = SavePVPOptions(file);

            // Output to the console "Saving to file: <fileName>"
            Program.WriteLine("Saving to file: {0}", fileName);

            // Save the file
            File.WriteAllText(fileName, file);

            // Output to the console "Saving complete."
            Program.WriteLine("Saving complete.");
        }

        static string SaveBasicOptions(string file)
        {
            // Output to the console "Writing Basic Options"
            Program.WriteLine("Writing Basic Options");

            // Check for each Basic Option variable and update it if found
            // If a Basic Option variable is not found, add it to the file contents


            if (Regex.IsMatch(file, "LastSavedDate\\s*=\\s*\".*\"", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "LastSavedDate\\s*=\\s*\".*\"", string.Format("{0,-25}= {1}", "LastSavedDate", "\"" + DateTime.Now + "\""), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "LastSavedDate", "\"" + DateTime.Now + "\"");
            }
            if (Regex.IsMatch(file, "AggroHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AggroHP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AggroHP", AggroHP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AggroHP", AggroHP);
            }
            if (Regex.IsMatch(file, "AggroSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AggroSP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AggroSP", AggroSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AggroSP", AggroSP);
            }
            
            if (Regex.IsMatch(file, "KiteMonsters\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(KiteMonsters\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "KiteMonsters", KiteMonsters), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "KiteMonsters", KiteMonsters);
            }
            if (Regex.IsMatch(file, "PainkillerFriends\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(PainkillerFriends\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "PainkillerFriends", PainkillerFriends), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "PainkillerFriends", PainkillerFriends);
            }
            if (Regex.IsMatch(file, "PainkillerFriendsSave\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(PainkillerFriendsSave\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "PainkillerFriendsSave", PainkillerFriendsSave), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "PainkillerFriendsSave", PainkillerFriendsSave);
            }
            if (Regex.IsMatch(file, "SuperPassive\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(SuperPassive\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "SuperPassive", SuperPassive), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "SuperPassive", SuperPassive);
            }
            if (Regex.IsMatch(file, "UseAttackSkill\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseAttackSkill\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseAttackSkill", UseAttackSkill), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseAttackSkill", UseAttackSkill);
            }
            if (Regex.IsMatch(file, "AssumeHomun\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AssumeHomun\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AssumeHomun", AssumeHomun), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AssumeHomun", AssumeHomun);
            }
            if (Regex.IsMatch(file, "DoNotChase\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DoNotChase\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "DoNotChase", DoNotChase), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DoNotChase", DoNotChase);
            }
            if (Regex.IsMatch(file, "UseDanceAttack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDanceAttack\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseDanceAttack", UseDanceAttack), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDanceAttack", UseDanceAttack);
            }
            if (Regex.IsMatch(file, "UseAvoid\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseAvoid\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseAvoid", UseAvoid), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseAvoid", UseAvoid);
            }
            if (Regex.IsMatch(file, "TankMonsterLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(TankMonsterLimit\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "TankMonsterLimit", TankMonsterLimit), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "TankMonsterLimit", TankMonsterLimit);
            }
            if (Regex.IsMatch(file, "RescueOwnerLowHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(RescueOwnerLowHP\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "RescueOwnerLowHP", RescueOwnerLowHP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "RescueOwnerLowHP", RescueOwnerLowHP);
            }
            if (Regex.IsMatch(file, "StationaryAggroDist\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(StationaryAggroDist\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "StationaryAggroDist", StationaryAggroDist), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "StationaryAggroDist", StationaryAggroDist);
            }
            if (Regex.IsMatch(file, "MobileAggroDist\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(MobileAggroDist\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "MobileAggroDist", MobileAggroDist), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "MobileAggroDist", MobileAggroDist);
            }
            if (Regex.IsMatch(file, "OldHomunType\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(OldHomunType\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "OldHomunType", OldHomunType), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "OldHomunType", OldHomunType);
            }
            if (Regex.IsMatch(file, "OpportunisticTargeting\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(OpportunisticTargeting\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "OpportunisticTargeting", OpportunisticTargeting), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "OpportunisticTargeting", OpportunisticTargeting);
            }
            if (Regex.IsMatch(file, "AttackLastFullSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AttackLastFullSP\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AttackLastFullSP", AttackLastFullSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AttackLastFullSP", AttackLastFullSP);
            }
            if (Regex.IsMatch(file, "DanceMinSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DanceMinSP\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "DanceMinSP", DanceMinSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DanceMinSP", DanceMinSP);
            }
            if (Regex.IsMatch(file, "AttackTimeLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AttackTimeLimit\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AttackTimeLimit", AttackTimeLimit), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AttackTimeLimit", AttackTimeLimit);
            }
            if (Regex.IsMatch(file, "LagReduction\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(LagReduction\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "LagReduction", LagReduction), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "LagReduction", LagReduction);
            }
            if (Regex.IsMatch(file, "DoNotAttackMoving\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DoNotAttackMoving\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "DoNotAttackMoving", DoNotAttackMoving), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DoNotAttackMoving", DoNotAttackMoving);
            }
            if (Regex.IsMatch(file, "LiveMobID\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(LiveMobID\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "LiveMobID", LiveMobID), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "LiveMobID", LiveMobID);
            }
            // Return the new file contents
            return string.Copy(file);
        }

        static string SaveAutoSkillOptions(string file)
        {
            // Output to the console "Writing AutoSkill Options"
            Program.WriteLine("Writing AutoSkill Options");

            // Check for each AutoSkill Option variable and update it if found
            // If a AutoSkill Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "AttackSkillReserveSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AttackSkillReserveSP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AttackSkillReserveSP", AttackSkillReserveSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AttackSkillReserveSP", AttackSkillReserveSP);
            }
            if (Regex.IsMatch(file, "AutoMobCount\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoMobCount\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AutoMobCount", AutoMobCount), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoMobCount", AutoMobCount);
            }
            if (Regex.IsMatch(file, "UseSkillOnly\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSkillOnly\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseSkillOnly", UseSkillOnly), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSkillOnly", UseSkillOnly);
            }
            if (Regex.IsMatch(file, "AutoSkillDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoSkillDelay\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AutoSkillDelay", AutoSkillDelay), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoSkillDelay", AutoSkillDelay);
            }
            if (Regex.IsMatch(file, "AutoSkillLimit\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoSkillLimit\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AutoSkillLimit", AutoSkillLimit), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoSkillLimit", AutoSkillLimit);
            }
            if (Regex.IsMatch(file, "UseAutoPushback\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseAutoPushback\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseAutoPushback", UseAutoPushback), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseAutoPushback", UseAutoPushback);
            }
            if (Regex.IsMatch(file, "AutoPushbackThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoPushbackThreshold\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AutoPushbackThreshold", AutoPushbackThreshold), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoPushbackThreshold", AutoPushbackThreshold);
            }
            if (Regex.IsMatch(file, "AoEReserveSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AoEReserveSP\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AoEReserveSP", AoEReserveSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AoEReserveSP", AoEReserveSP);
            }
            if (Regex.IsMatch(file, "AoEFixedLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AoEFixedLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AoEFixedLevel", AoEFixedLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AoEFixedLevel", AoEFixedLevel);
            }
            if (Regex.IsMatch(file, "AutoMobMode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoMobMode\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AutoMobMode", AutoMobMode), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoMobMode", AutoMobMode);
            }
            if (Regex.IsMatch(file, "AutoComboMode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoComboMode\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AutoComboMode", AutoComboMode), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoComboMode", AutoComboMode);
            }
            if (Regex.IsMatch(file, "AutoComboSpheres\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoComboSpheres\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AutoComboSpheres", AutoComboSpheres), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoComboSpheres", AutoComboSpheres);
            }
            if (Regex.IsMatch(file, "UseHomunSSkillChase\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseHomunSSkillChase\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseHomunSSkillChase", UseHomunSSkillChase), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseHomunSSkillChase", UseHomunSSkillChase);
            }
            if (Regex.IsMatch(file, "UseHomunSSkillAttack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseHomunSSkillAttack\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseHomunSSkillAttack", UseHomunSSkillAttack), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseHomunSSkillAttack", UseHomunSSkillAttack);
            }
            if (Regex.IsMatch(file, "AoEMaximizeTargets\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AoEMaximizeTargets\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AoEMaximizeTargets", AoEMaximizeTargets), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AoEMaximizeTargets", AoEMaximizeTargets);
            }
            if (Regex.IsMatch(file, "UseEiraXenoSlasher\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseEiraXenoSlasher\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseEiraXenoSlasher", UseEiraXenoSlasher), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseEiraXenoSlasher", UseEiraXenoSlasher);
            }
            if (Regex.IsMatch(file, "EiraXenoSlasherLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(EiraXenoSlasherLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "EiraXenoSlasherLevel", EiraXenoSlasherLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "EiraXenoSlasherLevel", EiraXenoSlasherLevel);
            }
            if (Regex.IsMatch(file, "UseEiraEraseCutter\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseEiraEraseCutter\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseEiraEraseCutter", UseEiraEraseCutter), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseEiraEraseCutter", UseEiraEraseCutter);
            }
            if (Regex.IsMatch(file, "EiraEraseCutterLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(EiraEraseCutterLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "EiraEraseCutterLevel", EiraEraseCutterLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "EiraEraseCutterLevel", EiraEraseCutterLevel);
            }
            if (Regex.IsMatch(file, "UseEiraSilentBreeze\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseEiraSilentBreeze\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseEiraSilentBreeze", UseEiraSilentBreeze), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseEiraSilentBreeze", UseEiraSilentBreeze);
            }
            if (Regex.IsMatch(file, "EiraSilentBreezeLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(EiraSilentBreezeLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "EiraSilentBreezeLevel", EiraSilentBreezeLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "EiraSilentBreezeLevel", EiraSilentBreezeLevel);
            }
            if (Regex.IsMatch(file, "UseBayeriStahlHorn\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBayeriStahlHorn\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseBayeriStahlHorn", UseBayeriStahlHorn), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBayeriStahlHorn", UseBayeriStahlHorn);
            }
            if (Regex.IsMatch(file, "BayeriStahlHornLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(BayeriStahlHornLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "BayeriStahlHornLevel", BayeriStahlHornLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "BayeriStahlHornLevel", BayeriStahlHornLevel);
            }
            if (Regex.IsMatch(file, "UseBayeriHailegeStar\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBayeriHailegeStar\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseBayeriHailegeStar", UseBayeriHailegeStar), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBayeriHailegeStar", UseBayeriHailegeStar);
            }
            if (Regex.IsMatch(file, "BayeriHailegeStarLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(BayeriHailegeStarLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "BayeriHailegeStarLevel", BayeriHailegeStarLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "BayeriHailegeStarLevel", BayeriHailegeStarLevel);
            }
            if (Regex.IsMatch(file, "UseSeraParalyze\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSeraParalyze\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseSeraParalyze", UseSeraParalyze), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSeraParalyze", UseSeraParalyze);
            }
            if (Regex.IsMatch(file, "SeraParalyzeLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(SeraParalyzeLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "SeraParalyzeLevel", SeraParalyzeLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "SeraParalyzeLevel", SeraParalyzeLevel);
            }
            if (Regex.IsMatch(file, "UseSeraPoisonMist\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSeraPoisonMist\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseSeraPoisonMist", UseSeraPoisonMist), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSeraPoisonMist", UseSeraPoisonMist);
            }
            if (Regex.IsMatch(file, "SeraPoisonMistLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(SeraPoisonMistLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "SeraPoisonMistLevel", SeraPoisonMistLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "SeraPoisonMistLevel", SeraPoisonMistLevel);
            }
            if (Regex.IsMatch(file, "UseEleanorSonicClaw\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseEleanorSonicClaw\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseEleanorSonicClaw", UseEleanorSonicClaw), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseEleanorSonicClaw", UseEleanorSonicClaw);
            }
            if (Regex.IsMatch(file, "EleanorDoNotSwitchMode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(EleanorDoNotSwitchMode\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "EleanorDoNotSwitchMode", EleanorDoNotSwitchMode), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "EleanorDoNotSwitchMode", EleanorDoNotSwitchMode);
            }
            
            if (Regex.IsMatch(file, "EleanorSonicClawLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(EleanorSonicClawLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "EleanorSonicClawLevel", EleanorSonicClawLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "EleanorSonicClawLevel", EleanorSonicClawLevel);
            }
            if (Regex.IsMatch(file, "EleanorSilverveinLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(EleanorSilverveinLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "EleanorSilverveinLevel", EleanorSilverveinLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "EleanorSilverveinLevel", EleanorSilverveinLevel);
            }
            if (Regex.IsMatch(file, "EleanorMidnightLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(EleanorMidnightLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "EleanorMidnightLevel", EleanorMidnightLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "EleanorMidnightLevel", EleanorMidnightLevel);
            }
            if (Regex.IsMatch(file, "UseDieterLavaSlide\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDieterLavaSlide\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseDieterLavaSlide", UseDieterLavaSlide), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDieterLavaSlide", UseDieterLavaSlide);
            } 
            if (Regex.IsMatch(file, "UseDieterVolcanicAsh\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDieterVolcanicAsh\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseDieterVolcanicAsh", UseDieterVolcanicAsh), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDieterVolcanicAsh", UseDieterVolcanicAsh);
            }
            if (Regex.IsMatch(file, "DieterLavaSlideLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DieterLavaSlideLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "DieterLavaSlideLevel", DieterLavaSlideLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DieterLavaSlideLevel", DieterLavaSlideLevel);
            }
            if (Regex.IsMatch(file, "UseSeraCallLegion\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSeraCallLegion\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseSeraCallLegion", UseSeraCallLegion), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSeraCallLegion", UseSeraCallLegion);
            }
            if (Regex.IsMatch(file, "SeraCallLegionLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(SeraCallLegionLevel\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "SeraCallLegionLevel", SeraCallLegionLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "SeraCallLegionLevel", SeraCallLegionLevel);
            }

            // Return the new file contents
            return string.Copy(file);
        }

        static string SaveWalkFollowOptions(string file)
        {
            // Output to the console "Writing Walk/Follow Options"
            Program.WriteLine("Writing Walk/Follow Options");

            // Check for each Walk/Follow Option variable and update it if found
            // If a Walk/Follow Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "FollowStayBack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(FollowStayBack\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "FollowStayBack", FollowStayBack), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "FollowStayBack", FollowStayBack);
            }
            
            if (Regex.IsMatch(file, "RestXOff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(RestXOff\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "RestXOff", RestXOff), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "RestXOff", RestXOff);
            }
            if (Regex.IsMatch(file, "RestYOff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(RestYOff\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "RestYOff", RestYOff), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "RestYOff", RestYOff);
            }
            if (Regex.IsMatch(file, "DoNotUseRest\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DoNotUseRest\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "DoNotUseRest", DoNotUseRest), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DoNotUseRest", DoNotUseRest);
            }
            if (Regex.IsMatch(file, "SpawnDelay\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(SpawnDelay\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "SpawnDelay", SpawnDelay), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "SpawnDelay", SpawnDelay);
            }
            
            if (Regex.IsMatch(file, "MoveSticky\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(MoveSticky\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "MoveSticky", MoveSticky), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "MoveSticky", MoveSticky);
            }
            if (Regex.IsMatch(file, "MoveStickyFight\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(MoveStickyFight\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "MoveStickyFight", MoveStickyFight), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "MoveStickyFight", MoveStickyFight);
            }
            if (Regex.IsMatch(file, "UseIdleWalk\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseIdleWalk\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseIdleWalk", UseIdleWalk), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseIdleWalk", UseIdleWalk);
            }
            if (Regex.IsMatch(file, "IdleWalkSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(IdleWalkSP\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "IdleWalkSP", IdleWalkSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "IdleWalkSP", IdleWalkSP);
            }
            if (Regex.IsMatch(file, "UseCastleRoute\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseCastleRoute\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseCastleRoute", UseCastleRoute), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseCastleRoute", UseCastleRoute);
            }
            if (Regex.IsMatch(file, "RelativeRoute\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(RelativeRoute\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "RelativeRoute", RelativeRoute), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "RelativeRoute", RelativeRoute);
            }
            if (Regex.IsMatch(file, "IdleWalkDistance\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(IdleWalkDistance\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "IdleWalkDistance", IdleWalkDistance), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "IdleWalkDistance", IdleWalkDistance);
            }
            if (Regex.IsMatch(file, "ChaseSPPause\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(ChaseSPPause\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "ChaseSPPause", ChaseSPPause), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "ChaseSPPause", ChaseSPPause);
            }
            if (Regex.IsMatch(file, "ChaseSPPauseSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(ChaseSPPauseSP\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "ChaseSPPauseSP", ChaseSPPauseSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "ChaseSPPauseSP", ChaseSPPauseSP);
            }
            if (Regex.IsMatch(file, "ChaseSPPauseTime\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(ChaseSPPauseTime\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "ChaseSPPauseTime", ChaseSPPauseTime), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "ChaseSPPauseTime", ChaseSPPauseTime);
            }
            if (Regex.IsMatch(file, "StationaryMoveBounds\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(StationaryMoveBounds\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "StationaryMoveBounds", StationaryMoveBounds), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "StationaryMoveBounds", StationaryMoveBounds);
            }
            if (Regex.IsMatch(file, "MobileMoveBounds\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(MobileMoveBounds\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "MobileMoveBounds", MobileMoveBounds), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "MobileMoveBounds", MobileMoveBounds);
            }

            // Return the new file contents
            return string.Copy(file);
        }

        static string SaveAutobuffOptions(string file)
        {
            // Output to the console "Writing Autobuff Options"
            Program.WriteLine("Writing Autobuff Options");

            // Check for each Autobuff Option variable and update it if found
            // If a Autobuff Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "UseOffensiveBuff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseOffensiveBuff\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseOffensiveBuff", UseOffensiveBuff), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseOffensiveBuff", UseOffensiveBuff);
            }
            if (Regex.IsMatch(file, "UseDefensiveBuff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDefensiveBuff\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseDefensiveBuff", UseDefensiveBuff), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDefensiveBuff", UseDefensiveBuff);
            }
            if (Regex.IsMatch(file, "LifEscapeLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(LifEscapeLevel\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "LifEscapeLevel", LifEscapeLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "LifEscapeLevel", LifEscapeLevel);
            }
            if (Regex.IsMatch(file, "FilirFlitLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(FilirFlitLevel\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "FilirFlitLevel", FilirFlitLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "FilirFlitLevel", FilirFlitLevel);
            }
            if (Regex.IsMatch(file, "AmiBulwarkLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AmiBulwarkLevel\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AmiBulwarkLevel", AmiBulwarkLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AmiBulwarkLevel", AmiBulwarkLevel);
            }
            if (Regex.IsMatch(file, "HealOwnerHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(HealOwnerHP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "HealOwnerHP", HealOwnerHP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "HealOwnerHP", HealOwnerHP);
            }
            if (Regex.IsMatch(file, "UseAutoHeal\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseAutoHeal\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseAutoHeal", UseAutoHeal), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseAutoHeal", UseAutoHeal);
            }
            if (Regex.IsMatch(file, "HealOwnerBreeze\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(HealOwnerBreeze\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "HealOwnerBreeze", HealOwnerBreeze), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "HealOwnerBreeze", HealOwnerBreeze);
            }
            if (Regex.IsMatch(file, "FilirAccelLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(FilirAccelLevel\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "FilirAccelLevel", FilirAccelLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "FilirAccelLevel", FilirAccelLevel);
            }
            if (Regex.IsMatch(file, "UseSeraPainkiller\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSeraPainkiller\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseSeraPainkiller", UseSeraPainkiller), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSeraPainkiller", UseSeraPainkiller);
            }
            if (Regex.IsMatch(file, "DefensiveBuffOwnerMobbed\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DefensiveBuffOwnerMobbed\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "DefensiveBuffOwnerMobbed", DefensiveBuffOwnerMobbed), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DefensiveBuffOwnerMobbed", DefensiveBuffOwnerMobbed);
            }
            if (Regex.IsMatch(file, "UseBayeriAngriffModus\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBayeriAngriffModus\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseBayeriAngriffModus", UseBayeriAngriffModus), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBayeriAngriffModus", UseBayeriAngriffModus);
            }
            if (Regex.IsMatch(file, "UseBayeriGoldenPherze\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBayeriGoldenPherze\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseBayeriGoldenPherze", UseBayeriGoldenPherze), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBayeriGoldenPherze", UseBayeriGoldenPherze);
            }
            if (Regex.IsMatch(file, "UseDieterMagmaFlow\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDieterMagmaFlow\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseDieterMagmaFlow", UseDieterMagmaFlow), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDieterMagmaFlow", UseDieterMagmaFlow);
            }
            if (Regex.IsMatch(file, "UseDieterGraniticArmor\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDieterGraniticArmor\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseDieterGraniticArmor", UseDieterGraniticArmor), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDieterGraniticArmor", UseDieterGraniticArmor);
            }
            if (Regex.IsMatch(file, "UseDieterPyroclastic\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDieterPyroclastic\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseDieterPyroclastic", UseDieterPyroclastic), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDieterPyroclastic", UseDieterPyroclastic);
            }
            if (Regex.IsMatch(file, "DieterPyroclasticLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DieterPyroclasticLevel\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "DieterPyroclasticLevel", DieterPyroclasticLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DieterPyroclasticLevel", DieterPyroclasticLevel);
            }
            if (Regex.IsMatch(file, "UseEiraOveredBoost\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseEiraOveredBoost\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseEiraOveredBoost", UseEiraOveredBoost), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseEiraOveredBoost", UseEiraOveredBoost);
            }
            if (Regex.IsMatch(file, "HealSelfHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(HealSelfHP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "HealSelfHP", HealSelfHP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "HealSelfHP", HealSelfHP);
            }
            if (Regex.IsMatch(file, "LavaSlideMode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(LavaSlideMode\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "LavaSlideMode", LavaSlideMode), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "LavaSlideMode", LavaSlideMode);
            }
            if (Regex.IsMatch(file, "PoisonMistMode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(PoisonMistMode\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "PoisonMistMode", PoisonMistMode), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "PoisonMistMode", PoisonMistMode);
            }
            if (Regex.IsMatch(file, "UseBayeriSteinWand\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBayeriSteinWand\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseBayeriSteinWand", UseBayeriSteinWand), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBayeriSteinWand", UseBayeriSteinWand);
            }
            if (Regex.IsMatch(file, "BayeriSteinWandLevel\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(BayeriSteinWandLevel\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "BayeriSteinWandLevel", BayeriSteinWandLevel), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "BayeriSteinWandLevel", BayeriSteinWandLevel);
            }
            if (Regex.IsMatch(file, "UseSteinWandSelfMob\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSteinWandSelfMob\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseSteinWandSelfMob", UseSteinWandSelfMob), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSteinWandSelfMob", UseSteinWandSelfMob);
            }
            if (Regex.IsMatch(file, "UseSteinWandOwnerMob\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSteinWandOwnerMob\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseSteinWandOwnerMob", UseSteinWandOwnerMob), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSteinWandOwnerMob", UseSteinWandOwnerMob);
            }
            if (Regex.IsMatch(file, "UseSteinWandTele\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSteinWandTele\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseSteinWandTele", UseSteinWandTele), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSteinWandTele", UseSteinWandTele);
            }
            if (Regex.IsMatch(file, "SteinWandTelePause\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(SteinWandTelePause\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "SteinWandTelePause", SteinWandTelePause), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "SteinWandTelePause", SteinWandTelePause);
            }
            if (Regex.IsMatch(file, "UseCastleDefend\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseCastleDefend\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseCastleDefend", UseCastleDefend), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseCastleDefend", UseCastleDefend);
            }
            if (Regex.IsMatch(file, "CastleDefendThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(CastleDefendThreshold\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "CastleDefendThreshold", CastleDefendThreshold), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "CastleDefendThreshold", CastleDefendThreshold);
            } 
            if (Regex.IsMatch(file, "UseSmartBulwark\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSmartBulwark\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseSmartBulwark", UseSmartBulwark), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSmartBulwark", UseSmartBulwark);
            }
            // Return the new file contents
            return string.Copy(file);
        }

        static string SaveKitingOptions(string file)
        {
            // Output to the console "Writing Kiting Options"
            Program.WriteLine("Writing Kiting Options");

            // Check for each Kiting Option variable and update it if found
            // If a Kiting Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "KiteParanoid\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(KiteParanoid\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "KiteParanoid", KiteParanoid), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "KiteParanoid", KiteParanoid);
            }
            if (Regex.IsMatch(file, "KiteStep\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(KiteStep\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "KiteStep", KiteStep), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "KiteStep", KiteStep);
            }
            if (Regex.IsMatch(file, "KiteParanoidStep\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(KiteParanoidStep\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "KiteParanoidStep", KiteParanoidStep), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "KiteParanoidStep", KiteParanoidStep);
            }
            if (Regex.IsMatch(file, "KiteThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(KiteThreshold\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "KiteThreshold", KiteThreshold), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "KiteThreshold", KiteThreshold);
            }
            if (Regex.IsMatch(file, "KiteParanoidThreshold\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(KiteParanoidThreshold\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "KiteParanoidThreshold", KiteParanoidThreshold), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "KiteParanoidThreshold", KiteParanoidThreshold);
            }
            if (Regex.IsMatch(file, "KiteBounds\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(KiteBounds\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "KiteBounds", KiteBounds), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "KiteBounds", KiteBounds);
            }
            if (Regex.IsMatch(file, "ForceKite\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(ForceKite\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "ForceKite", ForceKite), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "ForceKite", ForceKite);
            }
            if (Regex.IsMatch(file, "FleeHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(FleeHP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "FleeHP", FleeHP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "FleeHP", FleeHP);
            }
            // Return the new file contents
            return string.Copy(file);
        }

        static string SaveFriendingOptions(string file)
        {
            // Output to the console "Writing Friending Options"
            Program.WriteLine("Writing Friending Options");

            // Check for each Friending Option variable and update it if found
            // If a Friending Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "StandbyFriending\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(StandbyFriending\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "StandbyFriending", StandbyFriending), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "StandbyFriending", StandbyFriending);
            }
            if (Regex.IsMatch(file, "MirAIFriending\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(MirAIFriending\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "MirAIFriending", MirAIFriending), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "MirAIFriending", MirAIFriending);
            }

            // Return the new file contents
            return string.Copy(file);
        }

        static string SaveStandbyOptions(string file)
        {
            // Output to the console "Writing Standby Options"
            Program.WriteLine("Writing Standby Options");

            // Check for each Standby Option variable and update it if found
            // If a Standby Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "DefendStandby\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DefendStandby\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "DefendStandby", DefendStandby), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DefendStandby", DefendStandby);
            }
            if (Regex.IsMatch(file, "StickyStandby\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(StickyStandby\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "StickyStandby", StickyStandby), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "StickyStandby", StickyStandby);
            }

            // Return the new file contents
            return string.Copy(file);
        }

        static string SaveBerserkOptions(string file)
        {
            // Output to the console "Writing Berserk Options"
            Program.WriteLine("Writing Berserk Options");

            // Check for each Berserk Option variable and update it if found
            // If a Berserk Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "UseBerserkMobbed\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBerserkMobbed\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseBerserkMobbed", UseBerserkMobbed), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBerserkMobbed", UseBerserkMobbed);
            }
            if (Regex.IsMatch(file, "UseBerserkSkill\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBerserkSkill\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseBerserkSkill", UseBerserkSkill), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBerserkSkill", UseBerserkSkill);
            }
            if (Regex.IsMatch(file, "UseBerserkAttack\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBerserkAttack\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseBerserkAttack", UseBerserkAttack), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBerserkAttack", UseBerserkAttack);
            }
            if (Regex.IsMatch(file, "Berserk_SkillAlways\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(Berserk_SkillAlways\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "Berserk_SkillAlways", Berserk_SkillAlways), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "Berserk_SkillAlways", Berserk_SkillAlways);
            }
            if (Regex.IsMatch(file, "Berserk_Dance\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(Berserk_Dance\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "Berserk_Dance", Berserk_Dance), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "Berserk_Dance", Berserk_Dance);
            } 
            if (Regex.IsMatch(file, "Berserk_IgnoreMinSP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(Berserk_IgnoreMinSP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "Berserk_IgnoreMinSP", Berserk_IgnoreMinSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "Berserk_IgnoreMinSP", Berserk_IgnoreMinSP);
            }
            if (Regex.IsMatch(file, "Berserk_ComboAlways\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(Berserk_ComboAlways\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "Berserk_ComboAlways", Berserk_ComboAlways), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "Berserk_ComboAlways", Berserk_ComboAlways);
            }
            // Return the new file contents
            return string.Copy(file);
        }

        static string SavePVPOptions(string file)
        {
            // Output to the console "Writing PVP Options"
            Program.WriteLine("Writing PVP Options");

            // Check for each PVP Option variable and update it if found
            // If a PVP Option variable is not found, add it to the file contents
            if (Regex.IsMatch(file, "PVPmode\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(PVPmode\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "PVPmode", PVPmode), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "PVPmode", PVPmode);
            }

            // Return the new file contents
            return string.Copy(file);
        }
        #endregion

        #region Basic Options
        /////////////////
        //Basic Options//
        /////////////////
        //AggroHP: The mercenary will be aggressive when it's current HP is greater than this percent of it's maximum HP
        //To make your homun behave in a passive manner, set this to 100. 
        //Set AggroDistance to the maximum distance you want your merc to attack when aggressive.
        //If SuperPassive is set to 1, the AI will be completely passive, and will not attack in any way
        //This is intended for the purpose of getting killcount or using the AI for utility purposes.
        //Set KiteMonsters to 1 to attempt to avoid or "kite" monsters if you have an archer mercenary 
        //Set UseAttackSkill to 1 to automatically use offencive skills while attacking.
        /////////////////
        static int _AggroHP = 60;
        public static int AggroHP //Set this to 100 for passive mode (only attack monsters targeting owner/friends.
        {
            get { return _AggroHP; }
            set { _AggroHP = value; }
        }
        static int _AggroSP = 0;
        public static int AggroSP //As above for SP. 
        {
            get { return _AggroSP; }
            set { _AggroSP = value; }
        }
        static int _KiteMonsters = 0;
        public static int KiteMonsters
        {
            get { return _KiteMonsters; }
            set { _KiteMonsters = value; }
        }
        static int _PainkillerFriends = 0;
        public static int PainkillerFriends
        {
            get { return _PainkillerFriends; }
            set { _PainkillerFriends = value; }
        }
        static int _PainkillerFriendsSave = 0;
        public static int PainkillerFriendsSave
        {
            get { return _PainkillerFriendsSave; }
            set { _PainkillerFriendsSave = value; }
        }
        static int _SuperPassive = 0;
        public static int SuperPassive
        {
            get { return _SuperPassive; }
            set { _SuperPassive = value; }
        }
        static int _UseAttackSkill = 1;
        public static int UseAttackSkill
        {
            get { return _UseAttackSkill; }
            set { _UseAttackSkill = value; }
        }
        static int _AssumeHomun = 1;
        public static int AssumeHomun //Set this to 1 if you have a homun. 
        {
            get { return _AssumeHomun; }
            set { _AssumeHomun = value; }
        }
        static int _DoNotChase = 0;
        public static int DoNotChase
        {
            get { return _DoNotChase; }
            set { _DoNotChase = value; }
        }
        static int _UseDanceAttack = 0;
        public static int UseDanceAttack
        {
            get { return _UseDanceAttack; }
            set { _UseDanceAttack = value; }
        }
        static int _UseAvoid = 0;
        public static int UseAvoid
        {
            get { return _UseAvoid; }
            set { _UseAvoid = value; }
        }
        static int _TankMonsterLimit = 4;
        public static int TankMonsterLimit
        {
            get { return _TankMonsterLimit; }
            set { _TankMonsterLimit = value; }
        }
        static int _RescueOwnerLowHP = 0;
        public static int RescueOwnerLowHP
        {
            get { return _RescueOwnerLowHP; }
            set { _RescueOwnerLowHP = value; }
        }
        static int _StationaryAggroDist = 0;
        public static int StationaryAggroDist
        {
            get { return _StationaryAggroDist; }
            set { _StationaryAggroDist = value; }
        }
        static int _MobileAggroDist = 0;
        public static int MobileAggroDist
        {
            get { return _MobileAggroDist; }
            set { _MobileAggroDist = value; }
        }
        static int _OldHomunType = 0;
        public static int OldHomunType
        {
            get { return _OldHomunType; }
            set { _OldHomunType = value; }
        }
        static int _OpportunisticTargeting = 0;
        public static int OpportunisticTargeting
        {
            get { return _OpportunisticTargeting; }
            set { _OpportunisticTargeting = value; }
        }
        static int _AttackLastFullSP = 0;
        public static int AttackLastFullSP
        {
            get { return _AttackLastFullSP; }
            set { _AttackLastFullSP = value; }
        }
        static int _DanceMinSP = 0;
        public static int DanceMinSP
        {
            get { return _DanceMinSP; }
            set { _DanceMinSP = value; }
        }
        static int _AttackTimeLimit = 60;
        public static int AttackTimeLimit //Set this to 100 for passive mode (only attack monsters targeting owner/friends.
        {
            get { return _AttackTimeLimit; }
            set { _AttackTimeLimit = value; }
        }
        static int _LagReduction = 0;
        public static int LagReduction
        {
            get { return _LagReduction; }
            set { _LagReduction = value; }
        }
        static int _DoNotAttackMoving = 0;
        public static int DoNotAttackMoving
        {
            get { return _DoNotAttackMoving; }
            set { _DoNotAttackMoving = value; }
        }

        static int _LiveMobID = 0;
        public static int LiveMobID
        {
            get { return _LiveMobID; }
            set { _LiveMobID = value; }
        }
        #endregion

        #region AutoSkill Options
        /////////////////////
        //AutoSkill Options//
        /////////////////////
        //If you want the mercenary to always keep a certain amount of SP (ex. for quicken skills), set AttackSkillReserveSP to that amount
        //To automatically use anti-mob skills on multiple monsters, set AutoMobCount to the minimum 
        //number of monsters to use that on. Otherwise, set it to something really big. 
        //Do not change AutoSkillDelay unless you really think you know what you're doing.
        //Set UseSkillOnly to never use normal attacks, can be useful because normal attacks
        //are treated differently by monsters for the purposes of target changing. 
        //UseSkillOnly will be ignored if UseAttackSkill is set to 0. 
        /////////////////////
        static int _AttackSkillReserveSP = 0;
        public static int AttackSkillReserveSP
        {
            get { return _AttackSkillReserveSP; }
            set { _AttackSkillReserveSP = value; }
        }
        static int _AutoMobCount = 2;
        public static int AutoMobCount
        {
            get { return _AutoMobCount; }
            set { _AutoMobCount = value; }
        }
        static int _UseSkillOnly = -1;
        public static int UseSkillOnly //Set to 0 to only use skills when attacking normally, -1 to skill while attacking or chasing, and 1 to only use skills. 
        {
            get { return _UseSkillOnly; }
            set { _UseSkillOnly = value; }
        }
        static int _AutoSkillDelay = 400;
        public static int AutoSkillDelay //Leave at 400
        {
            get { return _AutoSkillDelay; }
            set { _AutoSkillDelay = value; }
        }
        static int _AutoSkillLimit = 100;
        public static int AutoSkillLimit //Default number of times to use an attack skill on a single monster, if not specified otherwise in the tact file. Tact list overrides this.
        {
            get { return _AutoSkillLimit; }
            set { _AutoSkillLimit = value; }
        }
        static int _UseAutoPushback = 0;
        public static int UseAutoPushback //Set to 1 to autouse pushback skills on mobs targeting merc. Set to 2 to use on monsters targeting owner/friends too (the latter is not reccomended)
        {
            get { return _UseAutoPushback; }
            set { _UseAutoPushback = value; }
        }
        static int _AutoPushbackThreshold = 2;
        public static int AutoPushbackThreshold //This is the distance between the monster and the target for use of pushback
        {
            get { return _AutoPushbackThreshold; }
            set { _AutoPushbackThreshold = value; }
        }

        static int _AoEReserveSP = 0;
        public static int AoEReserveSP
        {
            get { return _AoEReserveSP; }
            set { _AoEReserveSP = value; }
        }
        static int _AoEFixedLevel = 0;
        public static int AoEFixedLevel
        {
            get { return _AoEFixedLevel; }
            set { _AoEFixedLevel = value; }
        }
        static int _AutoMobMode = 0;
        public static int AutoMobMode
        {
            get { return _AutoMobMode; }
            set { _AutoMobMode = value; }
        }
        static int _AutoComboMode = 0;
        public static int AutoComboMode
        {
            get { return _AutoComboMode; }
            set { _AutoComboMode = value; }
        }
        static int _AutoComboSpheres = 0;
        public static int AutoComboSpheres
        {
            get { return _AutoComboSpheres; }
            set { _AutoComboSpheres = value; }
        }
        static int _UseHomunSSkillChase = 0;
        public static int UseHomunSSkillChase
        {
            get { return _UseHomunSSkillChase; }
            set { _UseHomunSSkillChase = value; }
        }
        static int _UseHomunSSkillAttack = 0;
        public static int UseHomunSSkillAttack
        {
            get { return _UseHomunSSkillAttack; }
            set { _UseHomunSSkillAttack = value; }
        }
        static int _AoEMaximizeTargets = 0;
        public static int AoEMaximizeTargets
        {
            get { return _AoEMaximizeTargets; }
            set { _AoEMaximizeTargets = value; }
        }
        static int _UseEiraXenoSlasher = 0;
        public static int UseEiraXenoSlasher
        {
            get { return _UseEiraXenoSlasher; }
            set { _UseEiraXenoSlasher = value; }
        }
        static int _EiraXenoSlasherLevel = 0;
        public static int EiraXenoSlasherLevel
        {
            get { return _EiraXenoSlasherLevel; }
            set { _EiraXenoSlasherLevel = value; }
        }
        static int _UseEiraSilentBreeze = 0;
        public static int UseEiraSilentBreeze
        {
            get { return _UseEiraSilentBreeze; }
            set { _UseEiraSilentBreeze = value; }
        }
        static int _EiraSilentBreezeLevel = 0;
        public static int EiraSilentBreezeLevel
        {
            get { return _EiraSilentBreezeLevel; }
            set { _EiraSilentBreezeLevel = value; }
        }
        static int _UseEiraEraseCutter = 0;
        public static int UseEiraEraseCutter
        {
            get { return _UseEiraEraseCutter; }
            set { _UseEiraEraseCutter = value; }
        }
        static int _EiraEraseCutterLevel = 0;
        public static int EiraEraseCutterLevel
        {
            get { return _EiraEraseCutterLevel; }
            set { _EiraEraseCutterLevel = value; }
        }
        static int _UseBayeriStahlHorn = 0;
        public static int UseBayeriStahlHorn
        {
            get { return _UseBayeriStahlHorn; }
            set { _UseBayeriStahlHorn = value; }
        }
        static int _BayeriStahlHornLevel = 0;
        public static int BayeriStahlHornLevel
        {
            get { return _BayeriStahlHornLevel; }
            set { _BayeriStahlHornLevel = value; }
        }
        static int _UseBayeriHailegeStar = 0;
        public static int UseBayeriHailegeStar
        {
            get { return _UseBayeriHailegeStar; }
            set { _UseBayeriHailegeStar = value; }
        }
        static int _BayeriHailegeStarLevel = 0;
        public static int BayeriHailegeStarLevel
        {
            get { return _BayeriHailegeStarLevel; }
            set { _BayeriHailegeStarLevel = value; }
        }
        static int _UseSeraParalyze = 0;
        public static int UseSeraParalyze
        {
            get { return _UseSeraParalyze; }
            set { _UseSeraParalyze = value; }
        }
        static int _SeraParalyzeLevel = 0;
        public static int SeraParalyzeLevel
        {
            get { return _SeraParalyzeLevel; }
            set { _SeraParalyzeLevel = value; }
        }
        static int _UseSeraPoisonMist = 0;
        public static int UseSeraPoisonMist
        {
            get { return _UseSeraPoisonMist; }
            set { _UseSeraPoisonMist = value; }
        }
        static int _SeraPoisonMistLevel = 0;
        public static int SeraPoisonMistLevel
        {
            get { return _SeraPoisonMistLevel; }
            set { _SeraPoisonMistLevel = value; }
        }
        static int _UseEleanorSonicClaw = 0;
        public static int UseEleanorSonicClaw
        {
            get { return _UseEleanorSonicClaw; }
            set { _UseEleanorSonicClaw = value; }
        }

        static int _EleanorDoNotSwitchMode = 0;
        public static int EleanorDoNotSwitchMode
        {
            get { return _EleanorDoNotSwitchMode; }
            set { _EleanorDoNotSwitchMode = value; }
        }
        static int _EleanorSonicClawLevel = 0;
        public static int EleanorSonicClawLevel
        {
            get { return _EleanorSonicClawLevel; }
            set { _EleanorSonicClawLevel = value; }
        }
        static int _EleanorSilverveinLevel = 0;
        public static int EleanorSilverveinLevel
        {
            get { return _EleanorSilverveinLevel; }
            set { _EleanorSilverveinLevel = value; }
        }
        static int _EleanorMidnightLevel = 0;
        public static int EleanorMidnightLevel
        {
            get { return _EleanorMidnightLevel; }
            set { _EleanorMidnightLevel = value; }
        }
        static int _UseDieterLavaSlide = 0;
        public static int UseDieterLavaSlide
        {
            get { return _UseDieterLavaSlide; }
            set { _UseDieterLavaSlide = value; }
        }
        static int _UseDieterVolcanicAsh = 0;
        public static int UseDieterVolcanicAsh
        {
            get { return _UseDieterVolcanicAsh; }
            set { _UseDieterVolcanicAsh = value; }
        }
        static int _DieterLavaSlideLevel = 0;
        public static int DieterLavaSlideLevel
        {
            get { return _DieterLavaSlideLevel; }
            set { _DieterLavaSlideLevel = value; }
        }
        static int _UseSeraCallLegion = 1;
        public static int UseSeraCallLegion
        {
            get { return _UseSeraCallLegion; }
            set { _UseSeraCallLegion = value; }
        }
        static int _SeraCallLegionLevel = 5;
        public static int SeraCallLegionLevel
        {
            get { return _SeraCallLegionLevel; }
            set { _SeraCallLegionLevel = value; }
        }
        
        #endregion

        #region Walk/Follow Options
        ///////////////////////
        //Walk/Follow Options//
        ///////////////////////
        //To make your mercenary stay x cells away from you, set FollowStayBack to x
        //MoveBounds is the max distance from you that your merc will get without immediately trying to return to you. 
        //To make your mercenary orbit you while idle at full HP, set UseOrbitWalk to the radius
        //which you want it to orbit at. This is kinda pointless and is not reccomended.
        //To make your mercenary walk randomly when above AggroHP, set UseRandomWalk to 1, and autofollow (ctrl+shift+rclick) your merc.
        ///////////////////////
        static int _FollowStayBack = 2;
        public static int FollowStayBack // Reccomend to set this to 1 or 2 for melees, 2 or 3 for archer
        {
            get { return _FollowStayBack; }
            set { _FollowStayBack = value; }
        }
        
        static int _RestXOff = -2;
        public static int RestXOff
        {
            get { return _RestXOff; }
            set { _RestXOff = value; }
        }
        static int _RestYOff = 0;
        public static int RestYOff // Set these to the coordinate offset you want your merc to move to when you sit. 
        {
            get { return _RestYOff; }
            set { _RestYOff = value; }
        }
        static int _DoNotUseRest = 0;
        public static int DoNotUseRest // Disable rest feature
        {
            get { return _DoNotUseRest; }
            set { _DoNotUseRest = value; }
        }
        static int _SpawnDelay = 1000;
        public static int SpawnDelay
        {
            get { return _SpawnDelay; }
            set { _SpawnDelay = value; }
        }
        static int _MoveSticky = 0;
        public static int MoveSticky // Set to 1 to stay where told to move to
        {
            get { return _MoveSticky; }
            set { _MoveSticky = value; }
        }
        static int _MoveStickyFight = 0;
        public static int MoveStickyFight // Set to 1 to fight normally in above mode
        {
            get { return _MoveStickyFight; }
            set { _MoveStickyFight = value; }
        }

        static int _UseIdleWalk = 0;
        public static int UseIdleWalk
        {
            get { return _UseIdleWalk; }
            set { _UseIdleWalk = value; }
        }
        
        static int _IdleWalkSP = 0;
        public static int IdleWalkSP
        {
            get { return _IdleWalkSP; }
            set { _IdleWalkSP = value; }
        }
        static int _UseCastleRoute = 0;
        public static int UseCastleRoute
        {
            get { return _UseCastleRoute; }
            set { _UseCastleRoute = value; }
        }
        static int _RelativeRoute = 0;
        public static int RelativeRoute
        {
            get { return _RelativeRoute; }
            set { _RelativeRoute = value; }
        }
        static int _IdleWalkDistance = 0;
        public static int IdleWalkDistance
        {
            get { return _IdleWalkDistance; }
            set { _IdleWalkDistance = value; }
        }
        static int _ChaseSPPause = 0;
        public static int ChaseSPPause
        {
            get { return _ChaseSPPause; }
            set { _ChaseSPPause = value; }
        }
        static int _ChaseSPPauseSP = 0;
        public static int ChaseSPPauseSP
        {
            get { return _ChaseSPPauseSP; }
            set { _ChaseSPPauseSP = value; }
        }
        static int _ChaseSPPauseTime = 0;
        public static int ChaseSPPauseTime
        {
            get { return _ChaseSPPauseTime; }
            set { _ChaseSPPauseTime = value; }
        }
        static int _StationaryMoveBounds = 0;
        public static int StationaryMoveBounds
        {
            get { return _StationaryMoveBounds; }
            set { _StationaryMoveBounds = value; }
        }
        static int _MobileMoveBounds = 0;
        public static int MobileMoveBounds
        {
            get { return _MobileMoveBounds; }
            set { _MobileMoveBounds = value; }
        }

        #endregion

        #region Autobuff Options
        ////////////////////
        //Autobuff options//
        ////////////////////
        //To automatically use these skills so as to keep them up at all times
        //set UseAuto(skill) to 1. 
        //AutoSight will only proc when hidden monsters or players are on screen
        //(Currently disabled - if UseAutoSight is on, sight will be kept up always)
        ////////////////////
        static int _UseOffensiveBuff = 1;
        public static int UseOffensiveBuff //Controls filer flitting, lif urgent escape
        {
            get { return _UseOffensiveBuff; }
            set { _UseOffensiveBuff = value; }
        }
        static int _UseDefensiveBuff = 1;
        public static int UseDefensiveBuff //Controls ami bullwork
        {
            get { return _UseDefensiveBuff; }
            set { _UseDefensiveBuff = value; }
        }

        static int _LifEscapeLevel = 5;
        public static int LifEscapeLevel
        {
            get { return _LifEscapeLevel; }
            set { _LifEscapeLevel = value; }
        }
        static int _FilirFlitLevel = 5;
        public static int FilirFlitLevel
        {
            get { return _FilirFlitLevel; }
            set { _FilirFlitLevel = value; }
        }
        static int _AmiBulwarkLevel = 5;
        public static int AmiBulwarkLevel
        {
            get { return _AmiBulwarkLevel; }
            set { _AmiBulwarkLevel = value; }
        }
        static int _HealOwnerHP = 50;
        public static int HealOwnerHP 
        {
            get { return _HealOwnerHP; }
            set { _HealOwnerHP = value; }
        }
        static int _UseAutoHeal = 0;
        public static int UseAutoHeal
        {
            get { return _UseAutoHeal; }
            set { _UseAutoHeal = value; }
        }
        static int _HealOwnerBreeze = 0;
        public static int HealOwnerBreeze
        {
            get { return _HealOwnerBreeze; }
            set { _HealOwnerBreeze = value; }
        }
        static int _FilirAccelLevel = 0;
        public static int FilirAccelLevel
        {
            get { return _FilirAccelLevel; }
            set { _FilirAccelLevel = value; }
        }
        static int _UseSeraPainkiller = 0;
        public static int UseSeraPainkiller
        {
            get { return _UseSeraPainkiller; }
            set { _UseSeraPainkiller = value; }
        }
        static int _DefensiveBuffOwnerMobbed = 0;
        public static int DefensiveBuffOwnerMobbed
        {
            get { return _DefensiveBuffOwnerMobbed; }
            set { _DefensiveBuffOwnerMobbed = value; }
        }
        static int _UseBayeriAngriffModus = 0;
        public static int UseBayeriAngriffModus
        {
            get { return _UseBayeriAngriffModus; }
            set { _UseBayeriAngriffModus = value; }
        }
        static int _UseBayeriGoldenPherze = 0;
        public static int UseBayeriGoldenPherze
        {
            get { return _UseBayeriGoldenPherze; }
            set { _UseBayeriGoldenPherze = value; }
        }
        static int _UseDieterMagmaFlow = 0;
        public static int UseDieterMagmaFlow
        {
            get { return _UseDieterMagmaFlow; }
            set { _UseDieterMagmaFlow = value; }
        }
        static int _UseDieterGraniticArmor = 0;
        public static int UseDieterGraniticArmor
        {
            get { return _UseDieterGraniticArmor; }
            set { _UseDieterGraniticArmor = value; }
        }
        static int _UseDieterPyroclastic = 0;
        public static int UseDieterPyroclastic
        {
            get { return _UseDieterPyroclastic; }
            set { _UseDieterPyroclastic = value; }
        }
        static int _DieterPyroclasticLevel = 0;
        public static int DieterPyroclasticLevel
        {
            get { return _DieterPyroclasticLevel; }
            set { _DieterPyroclasticLevel = value; }
        }
        static int _UseEiraOveredBoost = 0;
        public static int UseEiraOveredBoost
        {
            get { return _UseEiraOveredBoost; }
            set { _UseEiraOveredBoost = value; }
        }
        static int _HealSelfHP = 0;
        public static int HealSelfHP
        {
            get { return _HealSelfHP; }
            set { _HealSelfHP = value; }
        }
        static int _LavaSlideMode = 0;
        public static int LavaSlideMode
        {
            get { return _LavaSlideMode; }
            set { _LavaSlideMode = value; }
        }
        static int _PoisonMistMode = 0;
        public static int PoisonMistMode
        {
            get { return _PoisonMistMode; }
            set { _PoisonMistMode = value; }
        }
        static int _UseBayeriSteinWand = 0;
        public static int UseBayeriSteinWand
        {
            get { return _UseBayeriSteinWand; }
            set { _UseBayeriSteinWand = value; }
        }
        static int _BayeriSteinWandLevel = 0;
        public static int BayeriSteinWandLevel
        {
            get { return _BayeriSteinWandLevel; }
            set { _BayeriSteinWandLevel = value; }
        }
        static int _UseSteinWandSelfMob = 0;
        public static int UseSteinWandSelfMob
        {
            get { return _UseSteinWandSelfMob; }
            set { _UseSteinWandSelfMob = value; }
        }
        static int _UseSteinWandOwnerMob = 0;
        public static int UseSteinWandOwnerMob
        {
            get { return _UseSteinWandOwnerMob; }
            set { _UseSteinWandOwnerMob = value; }
        }
        static int _UseSteinWandTele = 0;
        public static int UseSteinWandTele
        {
            get { return _UseSteinWandTele; }
            set { _UseSteinWandTele = value; }
        }
        static int _SteinWandTelePause = 0;
        public static int SteinWandTelePause
        {
            get { return _SteinWandTelePause; }
            set { _SteinWandTelePause = value; }
        }
        static int _UseCastleDefend = 0;
        public static int UseCastleDefend
        {
            get { return _UseCastleDefend; }
            set { _UseCastleDefend = value; }
        }
        static int _CastleDefendThreshold = 0;
        public static int CastleDefendThreshold
        {
            get { return _CastleDefendThreshold; }
            set { _CastleDefendThreshold = value; }
        }
        static int _UseSmartBulwark = 0;
        public static int UseSmartBulwark
        {
            get { return _UseSmartBulwark; }
            set { _UseSmartBulwark = value; }
        }


        #endregion

        #region Kiting Options
        //////////////////
        //Kiting Options//
        //////////////////
        //Set ForceKite to use attempt kiting for all mercenaries, even non archers. Will behave strangely. 
        //KiteStep is the distance the mercenary will move in each kiting attempt, while KiteThreshold 
        //the distance between merc and monster at which it will attempt to kite. 
        //KiteBound is the maximum distance that the merc will ever move from the owner when kiting
        //Set KiteParanoid to 1 to attempt to kite monsters that are not currently attacking.
        //KiteParanoidStep and KiteParanoidThreshold have the same purpose as KiteStep and KiteThreshold
        //////////////////
        static int _KiteParanoid = 1;
        public static int KiteParanoid //Set to 1 if the map you're on has aggressive monsters that own your merc.
        {
            get { return _KiteParanoid; }
            set { _KiteParanoid = value; }
        }
        static int _KiteStep = 5;
        public static int KiteStep //It is not reccomended to change these without good reason
        {
            get { return _KiteStep; }
            set { _KiteStep = value; }
        }
        static int _KiteParanoidStep = 2;
        public static int KiteParanoidStep //Theres a bit of trial and error to setting these
        {
            get { return _KiteParanoidStep; }
            set { _KiteParanoidStep = value; }
        }
        static int _KiteThreshold = 3;
        public static int KiteThreshold //such that the mercenary acts in a desirable manner
        {
            get { return _KiteThreshold; }
            set { _KiteThreshold = value; }
        }
        static int _KiteParanoidThreshold = 2;
        public static int KiteParanoidThreshold
        {
            get { return _KiteParanoidThreshold; }
            set { _KiteParanoidThreshold = value; }
        }
        static int _KiteBounds = 8;
        public static int KiteBounds
        {
            get { return _KiteBounds; }
            set { _KiteBounds = value; }
        }
        static int _ForceKite = 0;
        public static int ForceKite // Not reccomended
        {
            get { return _ForceKite; }
            set { _ForceKite = value; }
        }
        static int _FleeHP = 8;
        public static int FleeHP
        {
            get { return _FleeHP; }
            set { _FleeHP = value; }
        }
        #endregion

        #region Friending Options
        /////////////////////
        //Friending Options//
        /////////////////////
        static int _StandbyFriending = 1;
        public static int StandbyFriending
        {
            get { return _StandbyFriending; }
            set { _StandbyFriending = value; }
        }
        static int _MirAIFriending = 0;
        public static int MirAIFriending
        {
            get { return _MirAIFriending; }
            set { _MirAIFriending = value; }
        }
        #endregion

        #region Standby Options
        ///////////////////
        //Standby Options//
        ///////////////////
        static int _DefendStandby = 0;
        public static int DefendStandby //Set to 1 to defend while in standby
        {
            get { return _DefendStandby; }
            set { _DefendStandby = value; }
        }
        static int _StickyStandby = 0;
        public static int StickyStandby //Set to 1 to return to standby after doing other things (ex: defending)
        {
            get { return _StickyStandby; }
            set { _StickyStandby = value; }
        }
        #endregion

        #region Berserk Options
        ///////////////////
        //Berserk Options//
        ///////////////////
        static int _UseBerserkMobbed = 0;
        public static int UseBerserkMobbed //Set to a number other than 0 to go berzerk when this many monsters are attacking
        {
            get { return _UseBerserkMobbed; }
            set { _UseBerserkMobbed = value; }
        }
        static int _UseBerserkSkill = 0;
        public static int UseBerserkSkill //Set to 1 to go berzerk when told to use a skill on target
        {
            get { return _UseBerserkSkill; }
            set { _UseBerserkSkill = value; }
        }
        static int _UseBerserkAttack = 0;
        public static int UseBerserkAttack //Set to 1 to go berzerk when told to attack a target
        {
            get { return _UseBerserkAttack; }
            set { _UseBerserkAttack = value; }
        }
        static int _Berserk_SkillAlways = 0;
        public static int Berserk_SkillAlways //Set to 1 to ignore skill use limits when berzerk
        {
            get { return _Berserk_SkillAlways; }
            set { _Berserk_SkillAlways = value; }
        }
        static int _Berserk_Dance = 0;
        public static int Berserk_Dance //Set to 1 to use dance attack when berzerk
        {
            get { return _Berserk_Dance; }
            set { _Berserk_Dance = value; }
        }
        static int _Berserk_IgnoreMinSP = 0;
        public static int Berserk_IgnoreMinSP //Set to 1 to use dance attack when berzerk
        {
            get { return _Berserk_IgnoreMinSP; }
            set { _Berserk_IgnoreMinSP = value; }
        }

        static int _Berserk_ComboAlways = 0;
        public static int Berserk_ComboAlways
        {
            get { return _Berserk_ComboAlways; }
            set { _Berserk_ComboAlways = value; }
        }
        #endregion

        #region PVP Options
        ///////////////
        //PVP Options//
        ///////////////
        static int _PVPmode = 0;
        public static int PVPmode // Set to 1 to enable PVP behavior
        {
            get { return _PVPmode; }
            set { _PVPmode = value; }
        }
        #endregion
    }
}