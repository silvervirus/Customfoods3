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
    internal class Bread

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("Bread", "Bread", "Freshly baked Bread made from Flour water and yeast baked in Oven", Utilities.GetSprite("Bread"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(TechType.Peeper);

            _ = prefab.SetRecipe(Utilities.CreateRecipe(1,
               
                new Ingredient(Dough.Info.TechType, 1)))
                

                .WithFabricatorType(Fabricator.CustomfoodsFabricator.CraftTreeType)
                .WithStepsToFabricatorTab("Ingredients")
                .WithCraftingTime(0.5f);

            var clone = new CloneTemplate(Info, TechType.Creepvine)
            {

            };


            prefab.SetGameObject(clone);
            prefab.Register();
        }

    }
}




