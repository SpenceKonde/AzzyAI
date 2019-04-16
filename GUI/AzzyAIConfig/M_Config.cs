// M_Config.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains the static class M_Config, which is used to store
// the values of the M_Config.lua configuration file.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace AzzyAIConfig
{
    static class M_Config
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
            if (Regex.IsMatch(file, "AutoDetectPlant\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AutoDetectPlant = Convert.ToInt32(Regex.Match(file, "AutoDetectPlant\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
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
            if (Regex.IsMatch(file, "OpportunisticTargeting\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                OpportunisticTargeting = Convert.ToInt32(Regex.Match(file, "OpportunisticTargeting\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "AttackLastFullSP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AttackLastFullSP = Convert.ToInt32(Regex.Match(file, "AttackLastFullSP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
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
            if (Regex.IsMatch(file, "AoEMaximizeTargets\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                AoEMaximizeTargets = Convert.ToInt32(Regex.Match(file, "AoEMaximizeTargets\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
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
            if (Regex.IsMatch(file, "UseProvokeOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseProvokeOwner = Convert.ToInt32(Regex.Match(file, "UseProvokeOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DefensiveBuffOwnerMobbed\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DefensiveBuffOwnerMobbed = Convert.ToInt32(Regex.Match(file, "DefensiveBuffOwnerMobbed\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseDefensiveBuff\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseDefensiveBuff = Convert.ToInt32(Regex.Match(file, "UseDefensiveBuff\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseAutoMag\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseAutoMag = Convert.ToInt32(Regex.Match(file, "UseAutoMag\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseAutoSight\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseAutoSight = Convert.ToInt32(Regex.Match(file, "UseAutoSight\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseSacrificeOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseSacrificeOwner = Convert.ToInt32(Regex.Match(file, "UseSacrificeOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBlessingSelf\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBlessingSelf = Convert.ToInt32(Regex.Match(file, "UseBlessingSelf\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseBlessingOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseBlessingOwner = Convert.ToInt32(Regex.Match(file, "UseBlessingOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseKyrieSelf\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseKyrieSelf = Convert.ToInt32(Regex.Match(file, "UseKyrieSelf\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseKyrieOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseKyrieOwner = Convert.ToInt32(Regex.Match(file, "UseKyrieOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseIncAgiSelf\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseIncAgiSelf = Convert.ToInt32(Regex.Match(file, "UseIncAgiSelf\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "UseIncAgiOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                UseIncAgiOwner = Convert.ToInt32(Regex.Match(file, "UseIncAgiOwner\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
            }
            if (Regex.IsMatch(file, "DefensiveBuffOwnerHP\\s*=\\s*-?\\d+", RegexOptions.Multiline))
            {
                DefensiveBuffOwnerHP = Convert.ToInt32(Regex.Match(file, "DefensiveBuffOwnerHP\\s*=\\s*-?\\d+", RegexOptions.Multiline).Value.Split('=')[1].Trim());
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
            if (Regex.IsMatch(file, "AutoDetectPlant\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AutoDetectPlant\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "AutoDetectPlant", AutoDetectPlant), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AutoDetectPlant", AutoDetectPlant);
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
            if (Regex.IsMatch(file, "AoEMaximizeTargets\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(AoEMaximizeTargets\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "AoEMaximizeTargets", AoEMaximizeTargets), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "AoEMaximizeTargets", AoEMaximizeTargets);
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
                file = Regex.Replace(file, "(ChaseSPPauseSP\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "ChaseSPPauseSP", ChaseSPPauseSP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "ChaseSPPauseSP", ChaseSPPauseSP);
            }
            if (Regex.IsMatch(file, "ChaseSPPauseTime\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(ChaseSPPauseTime\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "ChaseSPPauseTime", ChaseSPPauseTime), RegexOptions.Multiline);
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
                file = Regex.Replace(file, "(UseOffensiveBuff\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseOffensiveBuff", UseOffensiveBuff), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseOffensiveBuff", UseOffensiveBuff);
            }
            if (Regex.IsMatch(file, "UseProvokeOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseProvokeOwner\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseProvokeOwner", UseProvokeOwner), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseProvokeOwner", UseProvokeOwner);
            }
            if (Regex.IsMatch(file, "DefensiveBuffOwnerMobbed\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DefensiveBuffOwnerMobbed\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "DefensiveBuffOwnerMobbed", DefensiveBuffOwnerMobbed), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DefensiveBuffOwnerMobbed", DefensiveBuffOwnerMobbed);
            }
            if (Regex.IsMatch(file, "UseDefensiveBuff\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseDefensiveBuff\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseDefensiveBuff", UseDefensiveBuff), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseDefensiveBuff", UseDefensiveBuff);
            }
            if (Regex.IsMatch(file, "UseAutoMag\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseAutoMag\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseAutoMag", UseAutoMag), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseAutoMag", UseAutoMag);
            }
            if (Regex.IsMatch(file, "UseAutoSight\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseAutoSight\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseAutoSight", UseAutoSight), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseAutoSight", UseAutoSight);
            }
            
            if (Regex.IsMatch(file, "UseSacrificeOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseSacrificeOwner\\s*=\\s*)(\\d+|-\\d+)", string.Format("{0,-25}= {1}", "UseSacrificeOwner", UseSacrificeOwner), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseSacrificeOwner", UseSacrificeOwner);
            }
            if (Regex.IsMatch(file, "UseBlessingSelf\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBlessingSelf\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseBlessingSelf", UseBlessingSelf), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBlessingSelf", UseBlessingSelf);
            }
            if (Regex.IsMatch(file, "UseBlessingOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseBlessingOwner\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseBlessingOwner", UseBlessingOwner), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseBlessingOwner", UseBlessingOwner);
            }
            if (Regex.IsMatch(file, "UseKyrieSelf\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseKyrieSelf\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseKyrieSelf", UseKyrieSelf), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseKyrieSelf", UseKyrieSelf);
            }
            if (Regex.IsMatch(file, "UseKyrieOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseKyrieOwner\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseKyrieOwner", UseKyrieOwner), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseKyrieOwner", UseKyrieOwner);
            }
            if (Regex.IsMatch(file, "UseIncAgiSelf\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseIncAgiSelf\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseIncAgiSelf", UseIncAgiSelf), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseIncAgiSelf", UseIncAgiSelf);
            }
            if (Regex.IsMatch(file, "UseIncAgiOwner\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(UseIncAgiOwner\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "UseIncAgiOwner", UseIncAgiOwner), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "UseIncAgiOwner", UseIncAgiOwner);
            }
            if (Regex.IsMatch(file, "DefensiveBuffOwnerHP\\s*=\\s*(\\d+|-\\d+)", RegexOptions.Multiline))
            {
                file = Regex.Replace(file, "(DefensiveBuffOwnerHP\\s*=\\s*)(\\d+|-\\+)", string.Format("{0,-25}= {1}", "DefensiveBuffOwnerHP", DefensiveBuffOwnerHP), RegexOptions.Multiline);
            }
            else
            {
                file = string.Format("{1}{0}{2,-25}= {3}", Environment.NewLine, file, "DefensiveBuffOwnerHP", DefensiveBuffOwnerHP);
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
        static int _AutoDetectPlant = 1;
        public static int AutoDetectPlant
        {
            get { return _AutoDetectPlant; }
            set { _AutoDetectPlant = value; }
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

        static int _AttackTimeLimit = 10000;
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

        #region AutoSkillOptions
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
        static int _AoEMaximizeTargets = 0;
        public static int AoEMaximizeTargets
        {
            get { return _AoEMaximizeTargets; }
            set { _AoEMaximizeTargets = value; }
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

        static int _UseOffensiveBuff = 0;
        public static int UseOffensiveBuff
        {
            get { return _UseOffensiveBuff; }
            set { _UseOffensiveBuff = value; }
        }
        static int _UseProvokeOwner = 0;
        public static int UseProvokeOwner
        {
            get { return _UseProvokeOwner; }
            set { _UseProvokeOwner = value; }
        }
        static int _DefensiveBuffOwnerMobbed = 0;
        public static int DefensiveBuffOwnerMobbed
        {
            get { return _DefensiveBuffOwnerMobbed; }
            set { _DefensiveBuffOwnerMobbed = value; }
        }
        static int _UseDefensiveBuff = 0;
        public static int UseDefensiveBuff
        {
            get { return _UseDefensiveBuff; }
            set { _UseDefensiveBuff = value; }
        }
        static int _UseAutoMag = 1;
        public static int UseAutoMag 
        {
            get { return _UseAutoMag; }
            set { _UseAutoMag = value; }
        }
        static int _UseAutoSight = 1;
        public static int UseAutoSight 
        {
            get { return _UseAutoSight; }
            set { _UseAutoSight = value; }
        }
        static int _UseSacrificeOwner = 0;
        public static int UseSacrificeOwner 
        {
            get { return _UseSacrificeOwner; }
            set { _UseSacrificeOwner = value; }
        }
        static int _UseBlessingSelf = 0;
        public static int UseBlessingSelf
        {
            get { return _UseBlessingSelf; }
            set { _UseBlessingSelf = value; }
        }
        static int _UseBlessingOwner = 0;
        public static int UseBlessingOwner
        {
            get { return _UseBlessingOwner; }
            set { _UseBlessingOwner = value; }
        }
        static int _UseKyrieSelf = 0;
        public static int UseKyrieSelf
        {
            get { return _UseKyrieSelf; }
            set { _UseKyrieSelf = value; }
        }
        static int _UseKyrieOwner = 0;
        public static int UseKyrieOwner
        {
            get { return _UseKyrieOwner; }
            set { _UseKyrieOwner = value; }
        }
        static int _UseIncAgiSelf = 0;
        public static int UseIncAgiSelf
        {
            get { return _UseIncAgiSelf; }
            set { _UseIncAgiSelf = value; }
        }
        static int _UseIncAgiOwner = 0;
        public static int UseIncAgiOwner
        {
            get { return _UseIncAgiOwner; }
            set { _UseIncAgiOwner = value; }
        }
        static int _DefensiveBuffOwnerHP = 0;
        public static int DefensiveBuffOwnerHP
        {
            get { return _DefensiveBuffOwnerHP; }
            set { _DefensiveBuffOwnerHP = value; }
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
        static int _FleeHP = 0;
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