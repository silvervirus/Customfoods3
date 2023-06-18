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
    internal class Spice

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("Spice", "Spice", "extracted from CreepVines seeds to make a flavor Enhancer", Utilities.GetSprite("Spice"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(TechType.SmallMelon);

            _ = prefab.SetRecipe(Utilities.CreateRecipe(4,
               
                new Ingredient(TechType.CreepvineSeedCluster, 1)))
                

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




