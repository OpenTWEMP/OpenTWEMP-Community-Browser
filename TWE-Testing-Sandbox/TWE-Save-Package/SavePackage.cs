using System;

namespace TWE_Save_Package
{
    public struct SavePackage
    {
        public string GameSaveFileName { get; set; }
        public string UserDescription { get; set; }
        public string UserNickName { get; set; }
        public string ModName { get; set; }
        public string ModVersion { get; set; }
        public string CurrentFaction { get; set; }
        public uint CurrentTurnNumber { get; set; }
        public string CreationDateTime { get; }

        public SavePackage(string gamesave, string description, string nickname, string modName, string modVersion, string faction, uint turnNumber)
        {
            GameSaveFileName = gamesave;
            UserDescription = description;
            UserNickName = nickname;
            ModName = modName;
            ModVersion = modVersion;
            CurrentFaction = faction;
            CurrentTurnNumber = turnNumber;

            CreationDateTime = GetCreationDateTime();
        }

        private static string GetCreationDateTime()
        {
            return DateTime.Now.ToShortDateString();
        }
    }
}
