using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using RamuneLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;
using UnityEngine;
using Nautilus.Assets.Gadgets;

namespace CustomFoods_3.Ingredients
{
    internal class Flour

    {



        public static PrefabInfo Info;

        public static void Patch()
        {


            Info = Utilities.CreatePrefabInfo("Flour", "Flour", "Extracted from dried Creepvine Pieces", Utilities.GetSprite("Flour"), 1, 1);
            var prefab = new CustomPrefab(Info);



            prefab.SetUnlock(TechType.CreepvinePiece);

            _ = prefab.SetRecipe(Utilities.CreateRecipe(2,
                new Ingredient(TechType.CreepvinePiece, 2),
                new Ingredient(TechType.FilteredWater, 1)))

                .WithFabricatorType(Fabricator.CustomfoodsFabricator.CraftTreeType)
                .WithStepsToFabricatorTab("Ingredients")
                .WithCraftingTime(0.5f);

            var clone = new CloneTemplate(Info, TechType.WaterFiltrationSuitWater)
            {

            };


            prefab.SetGameObject(clone);
            prefab.Register();
        }

    }
}



