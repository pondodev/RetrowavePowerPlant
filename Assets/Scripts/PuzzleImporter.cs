using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor.Experimental.AssetImporters;
using Newtonsoft.Json;

[ScriptedImporter(1, "yeet")]
public class PuzzleImporter : ScriptedImporter
{
    private struct TempPuzzleData
    {
        public int width;
        public int height;
        public int[] startTerminalCoord;
        public int[] endTerminalCoord;
        public PuzzlePieceData[] pieces;
    }

    public override void OnImportAsset(AssetImportContext context)
    {
        string jsonData = File.ReadAllText(context.assetPath);

        // broken for now idk
        //PuzzleData puzzle = ScriptableObject.CreateInstance<PuzzleData>();
        //JsonUtility.FromJsonOverwrite(jsonData, puzzle);
        //Debug.Log(puzzle.pieces[0].terminal);

        // this is also broken so idk
        PuzzleData puzzle = ScriptableObject.CreateInstance<PuzzleData>();
        TempPuzzleData temp = JsonConvert.DeserializeObject<TempPuzzleData>(jsonData);
        puzzle.width = temp.width;
        puzzle.height = temp.height;
        puzzle.startTerminalCoord = temp.startTerminalCoord;
        puzzle.endTerminalCoord = temp.endTerminalCoord;
        puzzle.pieces = temp.pieces;
        Debug.Log(puzzle.pieces);

        context.AddObjectToAsset("main", puzzle);
        context.SetMainObject(puzzle);
    }
}