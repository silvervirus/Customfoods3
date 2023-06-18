using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using RamuneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;
using Nautilus.Assets.Gadgets;

namespace CustomFoods_3.Ingredients
{
    internal class Yeast

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("Yeast", "Yeast", " Yeast is a single-cell organism, called Saccharomyces cerevisiae, which needs food.", Utilities.GetSprite("Yeast"), 2, 2);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(TechType.SmallMelon);

            _ = prefab.SetRecipe(Utilities.CreateRecipe(1,
                new Ingredient(TechType.Peeper, 1)))
                

                .WithFabricatorType(Fabricator.CustomfoodsFabricator.CraftTreeType)
                .WithStepsToFabricatorTab("Ingredients")
                .WithCraftingTime(0.5f);

            var clone = new CloneTemplate(Info, TechType.Salt)
            {

            };


            prefab.SetGameObject(clone);
            prefab.Register();
        }

    }
}




