using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace CK.Resources
{
    public class AutoAtlas
    {
        static SpriteAtlasPackingSettings packSetting = new SpriteAtlasPackingSettings()
        {
            blockOffset = 1,
            padding = 2,
            enableRotation = false,
            enableTightPacking = false
        };

        private static SpriteAtlasTextureSettings textureSetting = new SpriteAtlasTextureSettings()
        {
            sRGB = true,
            filterMode = FilterMode.Bilinear,
        };

        private static TextureImporterPlatformSettings importerSetting = new TextureImporterPlatformSettings()
        {
            maxTextureSize = 2048,
            compressionQuality = 50,
        };

       // [MenuItem("Assets/创建图集", false, 19)]
        static void CreateAtlas()
        {
            var select = Selection.activeObject;
            var path = AssetDatabase.GetAssetPath(select);
            var t_name = Path.GetFileName(path);
            CreateAtlasOfAssetDir(path,t_name);
        }
        [MenuItem("Tea/创建图集", false, 19)]
        static void AutoAtlasCreate()
        {
            string rpath = "Assets/AssetArts/ui";
            DirectoryInfo direction = new DirectoryInfo(rpath);
            DirectoryInfo[] directs = direction.GetDirectories(); //文件夹
            DirectoryInfo dir;
            int i, j;
            for (i = 0; i < directs.Length; i++)
            {
                dir = directs[i];
                string dataPath = rpath + "/" + dir.Name;//dir.FullName;// System.IO.Path.GetFullPath(".");

                //创建图集
                string atlas = dataPath + "\\" + dir.Name + ".spriteatlas";
                Debug.LogError("创建图集:"+atlas);
                CreateAtlasOfAssetDir(dataPath, dir.Name);
                // if (File.Exists(atlas))
                // {
                //     Debug.Log("图集找到" + atlas);
                // }
                // else
                // {
                //     
                // }
            }
        }

        public static void CreateAtlasOfAssetDir(string dirAssetPath,string p_name)
        {
           // Debug.LogError("CreateAtlasOfAssetDir:"+dirAssetPath);
            
            // if (string.IsNullOrEmpty(dirAssetPath) || Path.HasExtension(dirAssetPath))
            // {
            //     Debug.LogError("当前选中对象不是文件夹，请选择对应文件夹重新创建图集");
            //     return;
            // }
            //
            // var t_name = Path.GetFileName(dirAssetPath);
            SpriteAtlas atlas = new SpriteAtlas();
            atlas.SetPackingSettings(packSetting);
            atlas.SetTextureSettings(textureSetting);
            atlas.SetPlatformSettings(importerSetting);

            var atlasPath = $"{dirAssetPath}/{p_name}.spriteatlas";
            Debug.LogError("atlasPath:"+atlasPath);
            TryAddSprites(atlas, dirAssetPath);
            AssetDatabase.CreateAsset(atlas, atlasPath);
            AssetDatabase.SaveAssets();
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<Object>(atlasPath);
        }

        static void TryAddSprites(SpriteAtlas atlas, string dirPath)
        {
            string[] files = Directory.GetFiles(dirPath);
            if (files == null || files.Length == 0) return;

            Sprite sprite;
            List<Sprite> spriteList = new List<Sprite>();
            foreach (var file in files)
            {
                if (file.EndsWith(".meta")) continue;
                sprite = AssetDatabase.LoadAssetAtPath<Sprite>(file);
                if (sprite == null) continue;
                spriteList.Add(sprite);
            }

            if (spriteList.Count > 0) atlas.Add(spriteList.ToArray());
        }
    }
}

