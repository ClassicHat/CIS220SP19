using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCamera : MonoBehaviour
{
    private static int W, H;
    private static int[,] MAP;
    public static Sprite[] SPRITES;
    public static Transform TILE_ANCHOR;
    public static Tile[,] TILES;

    [Header("Set in Inspector")]
    public TextAsset mapData;
    public Texture2D mapTiles;
    public TextAsset mapCollisions;
    public Tile tilePrefab;

	// Use this for initialization
	void Awake ()
	{
	    LoadMap();
	}

    public void LoadMap()
    {
        // create an anchor for our tiles. All tiles will
        // have the anchor as their parent
        GameObject go = new GameObject("TILE_ANCHOR");
        TILE_ANCHOR = go.transform;

        // load all of the sprites from mapTiles
        SPRITES = Resources.LoadAll<Sprite>(mapTiles.name);

        // read in the map data
        string[] lines = mapData.text.Split('\n');
        H = lines.Length;
        string[] tileNums = lines[0].Split(' ');
        W = tileNums.Length;

        // system globalization
        System.Globalization.NumberStyles hexNum;

        hexNum = System.Globalization.NumberStyles.HexNumber;

        // place the mpa data into a 2D array for faster access
        MAP = new int[W, H];

        for (int j = 0; j < H; j++)
        {
            tileNums = lines[j].Split(' ');
            for (int i = 0; i < W; i++)
            {
                if (tileNums[i] == "..")
                {
                    MAP[i, j] = 0;
                }
                else
                {
                    print("Contents of tileNums " + tileNums[i]);
                    print("Contents of hexNum " + hexNum);
                    MAP[i, j] = int.Parse(tileNums[i], hexNum);
                }
            } // end of for
        } // end of for

        print("Parsed " + SPRITES.Length + " sprites.");
        print("Map size: " + W + " wide by " + H + " high ");

        //Call to show map
        ShowMap();
    }

    void ShowMap()
    {
        TILES = new Tile[W, H];

        //Runs through the whole map and instantiates tiles where nessessary
        for(int j = 0; j<H; j++)
        {
            for(int i = 0; i< W; i++)
            {
                if(MAP[i, j] != 0)
                {
                    Tile ti = Instantiate<Tile>(tilePrefab);
                    ti.transform.SetParent(TILE_ANCHOR);
                    ti.SetTile(i, j);
                    TILES[i, j] = ti;
                }//End if
            }//End for loop
        }//End for loop
    }//End ShowMap

    static public int GET_MAP(int x, int y)
    {
        if (x < 0 || x >= W || y < 0 || y >= H)
        {
            return -1;
        }

        return MAP[x, y];
    }
    static public int GET_MAP(float x, float y)
    {
        int tX = Mathf.RoundToInt(x);
        int tY = Mathf.RoundToInt(y - 0.25f);
        return GET_MAP(tX, tY);
    }
    static public void SET_MAP(int x, int y, int tNum)
    {
        // additional security or a break point could be set here
        if (x < 0 || x >= W || y < 0 || y >= H)
            return; // do not allow out of range exceptions
        MAP[x, y] = tNum;
    }
	

}
