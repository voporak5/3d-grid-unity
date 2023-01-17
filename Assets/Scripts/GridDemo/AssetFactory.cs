using System.Collections.Generic;
using UnityEngine;
using CCintron.Grid;

namespace CCintron.GridDemo
{
    public class AssetFactory
    {
        //Depending on your language's data structures you can use something
        //else, create your own custom data structure, or create a variable for 
        //each type of object you need to return.
        //I used a dictionary because it is a C# convenience
        Dictionary<GamePieceType, GameObject> assetDict; 

        public AssetFactory()
        {
            assetDict = new Dictionary<GamePieceType, GameObject>();

            assetDict[GamePieceType.Bridge] = Load("Bridge");
            assetDict[GamePieceType.House] = Load("House");
            assetDict[GamePieceType.House2] = Load("House2");
            assetDict[GamePieceType.Lamp] = Load("Lamp");
            assetDict[GamePieceType.Well] = Load("Well");
        }

        public Node Get(GamePieceType piece)
        {
            GameObject prefab = assetDict[piece];
            string pattern = GetPattern(piece);            

            return new GamePiece(pattern,prefab);
        }

        private string GetPattern(GamePieceType piece)
        {
            //Here we defined the positioning of our object on the grid
            //3x3 square, 3 squares in a row, a single square, etc.
            switch (piece)
            {
                case GamePieceType.Bridge:      return "xxx";       //3 in a row
                case GamePieceType.House:       return "xx\nxx";    //2x2 square
                case GamePieceType.House2:      return "xx\nxx";    //2x2 square
                case GamePieceType.Lamp:        return "x";         //single square
                case GamePieceType.Well:        return "x";         //single square
                default:                        return string.Empty;
            }
        }

        private GameObject Load(string asset)
        {
            return (GameObject)Resources.Load(string.Format("Prefabs/{0}", asset));
        }
 
    }
}