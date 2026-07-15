using System.IO;

namespace DoomPacker.Backend
{
    public class FileManager
    {
        private readonly string _modsFolder = App.AppSettings.ModsFolder;

        public List<string> FindModsInDirectory()
        {
            List<string> modsList = [];

            var directory = new DirectoryInfo(_modsFolder);

            if (directory.Exists)
            {
                FileInfo[] mods = directory.GetFiles();

                foreach ( FileInfo mod in mods )
                {
                    if (mod.Name.EndsWith(".pk3") || mod.Name.EndsWith(".wad"))
                        modsList.Add(mod.Name);
                }
            }

            return modsList;
        }
    }
}
