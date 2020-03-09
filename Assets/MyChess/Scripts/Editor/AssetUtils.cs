using System.Collections.Generic;
using System.IO;
using MyChess.Scripts.Utility.Common;
using UnityEditor;
using UnityEngine;

namespace MyChess.Scripts.Editor
{
    public static class AssetUtils
    {
        #region AssetUtils

        private static string _assetsName = "Assets";

        public static List<T> FindAllAssets<T>(string assetsPath = null) where T : Object
        {
            return LoadAllAssets<T>(GetAllAssetsPaths("*", assetsPath));
        }

        public static List<T> FindAllAssetsByExtension<T>(string fileExtension, string assetsPath = null) where T : Object
        {
            if (string.IsNullOrEmpty(fileExtension))
            {
                return null;
            }

            if (fileExtension[0] == '.')
            {
                fileExtension = fileExtension.Substring(1);
            }

            return LoadAllAssets<T>(GetAllAssetsPaths("*." + fileExtension, assetsPath));
        }

        private static List<T> LoadAllAssets<T>(string[] paths) where T : Object
        {
            if (paths.IsEmpty())
            {
                return null;
            }

            var assetsOfType = new List<T>();

            foreach (var path in paths)
            {
                var asset = AssetDatabase.LoadAssetAtPath(path, typeof(T)) as T;
                if (asset == null)
                {
                    continue;
                }

                assetsOfType.Add(asset);
            }

            return assetsOfType;
        }

        private static string[] GetAllAssetsPaths(string searchPattern, string assetsPath = null)
        {
            var fullDataPath = Application.dataPath;
            if (!string.IsNullOrEmpty(assetsPath))
            {
                fullDataPath = fullDataPath.Replace(_assetsName, assetsPath);
            }

            var directoryInfo = new DirectoryInfo(fullDataPath);
            var fileInfos = directoryInfo.GetFiles(searchPattern, SearchOption.AllDirectories);
            var assetPaths = new List<string>();
            foreach (var file in fileInfos)
            {
                var assetPath = file.FullName.Replace(@"\", "/").Replace(Application.dataPath, _assetsName);
                assetPaths.Add(assetPath);
            }

            return assetPaths.ToArray();
        }

        #endregion
    }
}