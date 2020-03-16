using System.IO;
using UnityEngine;
using UnityEditor.Experimental.AssetImporters;

[ScriptedImporter(1, "yeet")]
public class PuzzleImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext context)
    {
        string jsonData = File.ReadAllText(context.assetPath);

        PuzzleData puzzle = ScriptableObject.CreateInstance<PuzzleData>();
        JsonUtility.FromJsonOverwrite(jsonData, puzzle);

        context.AddObjectToAsset("main", puzzle);
        context.SetMainObject(puzzle);
    }
}