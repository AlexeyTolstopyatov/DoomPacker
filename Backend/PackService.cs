using DoomPacker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
