using BepInEx;
using HarmonyLib;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using Nautilus.Handlers;
using Nautilus.Options;
using static CraftData;
using Nautilus.Assets.Gadgets;
using UnityEngine;
using RamuneLib;
using CustomFoods_3.FastFood;
using CustomFoods_3.Ingredients;
using System;

namespace CustomFoods_3.Fabricator
{
    [BepInPlugin(CustomfoodsFabricator.PLUGIN_GUID, CustomfoodsFabricator.PLUGIN_NAME, CustomfoodsFabricator.PLUGIN_VERSION)]
    public class CustomfoodsFabricator : BaseUnityPlugin
    {
        public const String PLUGIN_GUID = "SN.CustomFoods3";
        public const String PLUGIN_NAME = "CustomFood3_SN";
        public const String PLUGIN_VERSION = "1.0.0";
        public static CraftTree.Type CraftTreeType;
        private static readonly Harmony harmony = new Harmony(PLUGIN_GUID);

        public void Awake()


        {

            var prefab = new CustomPrefab("CustomFoodFabricator", "Chief Peeper's Fabricator", "Cheif Peeper has many custom food orders for you to taste and enjoy", Utilities.GetSprite("CF3mod"));
            var fabTree = prefab.CreateFabricator(out CustomfoodsFabricator.CraftTreeType);
            var model = new FabricatorTemplate(prefab.Info, CustomfoodsFabricator.CraftTreeType)
            {
                FabricatorModel = FabricatorTemplate.Model.MoonPool,
                ModifyPrefab = go =>
                {
                    var renderer = go.GetComponentInChildren<SkinnedMeshRenderer>(true);


                }
            };
            prefab.SetGameObject(model);
            prefab.SetRecipe(new RecipeData(new Ingredient(TechType.Titanium, 1), new Ingredient(TechType.Peeper, 2), new Ingredient(TechType.JeweledDiskPiece, 1)));
            prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);
            prefab.Register();

            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "CustomFoods", "CustomFoods", Utilities.GetSprite("Peeperburger"));
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "Ingredients", "Ingredients", SpriteManager.Get(TechType.HeatBlade));
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "Juices", "Juices", Utilities.GetSprite("Tea"));
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "Coffee", "Coffee", Utilities.GetSprite("Coffee"));
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "Cakes", "Cakes", Utilities.GetSprite("cake1"));
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "Mexican ", "Mexican ", Utilities.GetSprite("taco"));
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "FullMeals ", "FullMeals ", Utilities.GetSprite("Sushi"));
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "FastFood ", "FastFood", Utilities.GetSprite("Peeperburger"), new string[] { "CustomFoods" });
            CraftTreeHandler.AddTabNode(CustomfoodsFabricator.CraftTreeType, "Japanese ", "Japanese ", Utilities.GetSprite("sushi"));

           
            harmony.PatchAll();
            Main.FindPiracy();
            Flour.Patch();
            Yeast.Patch();
            Bread.Patch();
            Sugar.Patch();
            Spice.Patch();
            SeaWeed.Patch();
            CoffeeBean.Patch();
            Peeperburger.Patch();
            ChilliDog.Patch();

        }




    }
}




