using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Crafting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftData;

using UnityEngine;
using Nautilus.Utility;
using System.Reflection;
using Nautilus.Handlers;
using RamuneLib;

using Nautilus.Assets.PrefabTemplates;
using CustomFoods_3.Ingredients;

namespace CustomFoods_3.FastFood
{
    public class ChilliDog
    {
        public static void Patch()
        {
            var chilidog = new CustomPrefab(
               "ChiliDog",
               "A Hotdog made with what looks like chili",
               "Cheif Peeper made this with his own hands.");

            // Set our prefab to a clone of the Seamoth electrical defense module
            chilidog.SetGameObject(new CloneTemplate(chilidog.Info, TechType.NutrientBlock)
            {
                ModifyPrefab = prefab =>
                {
                    Eatable eatable = prefab.EnsureComponent<Eatable>();
                    eatable.foodValue = 40;
                    eatable.waterValue = 6;
                }
            });

            // Make our item compatible with the seamoth module slot
            SpriteHandler.RegisterSprite(chilidog.Info.TechType, "BepinEx/plugins/CustomFoods3/Assets/hotdog.png");



            // Make the Vehicle upgrade console a requirement for our item's blueprint
            ScanningGadget scanning = chilidog.SetUnlock(TechType.Peeper);

            // Add our item to the Vehicle upgrades category
            scanning.WithPdaGroupCategory(TechGroup.Survival, TechCategory.CookedFood);

            var recipe = new RecipeData()
            {
                craftAmount = 1,
                Ingredients =
    {
        new Ingredient(Bread.Info.TechType, 2),
        new Ingredient(TechType.CuredPeeper, 1),
        new Ingredient(TechType.CreepvinePiece, 1),
        
    },
            };

            // Add a recipe for our item, as well as add it to the Moonpool fabricator and Seamoth modules tab
            chilidog.SetRecipe(recipe)
        .WithFabricatorType(Fabricator.CustomfoodsFabricator.CraftTreeType)
        .WithStepsToFabricatorTab("FastFood");
        

            // Register our item to the game
            chilidog.Register();



        }
    }
}