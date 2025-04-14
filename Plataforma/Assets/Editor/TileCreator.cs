using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System.IO;

public class TileCreator : MonoBehaviour
{
    [MenuItem("Ferramentas/Criar Tiles de uma Pasta")]
    public static void CreateTilesFromFolder()
    {
        string sourceFolder = "Assets/SunnyLand Artwork/Environment/props";
        string targetFolder = "Assets/TilesGerados";

        if (!AssetDatabase.IsValidFolder(sourceFolder))
        {
            Debug.LogError("Pasta não encontrada: " + sourceFolder);
            return;
        }

        if (!AssetDatabase.IsValidFolder(targetFolder))
        {
            AssetDatabase.CreateFolder("Assets", "TilesGerados");
        }

        string[] guids = AssetDatabase.FindAssets("t:Sprite", new[] { sourceFolder });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);

            if (sprite != null)
            {
                Tile tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = sprite;

                string fileName = Path.GetFileNameWithoutExtension(assetPath);
                string tilePath = Path.Combine(targetFolder, fileName + ".asset");

                AssetDatabase.CreateAsset(tile, tilePath);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Tiles criados em: " + targetFolder);
    }
}
