using DoomPacker.Model;
using System.IO;

namespace DoomPacker.Backend
{
    public class PackService
    {
        public void CreateModPack(ModPackContent modPackContent) 
        {
            // ModpackContent (ImagePath, Title, Description, modsList) 
            // Create XML file with modPackContent

            //ExampleModPack
            //-ModsFolder
            //   - SomeMods.pk3
            //- ModPackInfo.xml
            //   < Title />

            //   < Version />

            //   < Description />

            //   < ModsOrder />
            //-TitleImage.jpg

            Directory.CreateDirectory(App.AppSettings.ModPackFolder);
        }
    }
}
