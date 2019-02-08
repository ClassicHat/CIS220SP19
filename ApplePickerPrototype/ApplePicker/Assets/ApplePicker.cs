using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Seit in Inspector")]
    public GameObject basketPrefab;

    public int numBaskets = 3;

    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;

    // Use this for initialization
    void Start ()
    {
        basketList = new List<GameObject>();

	    for (int i = 0; i < numBaskets; i++)
	    {
	        GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
	        Vector3 pos = Vector3.zero;
	        pos.y = basketBottomY + (basketSpacingY * i);
	        tBasketGO.transform.position = pos;

	        basketList.Add(tBasketGO);
	    }//End for loop
    }//End Start Method
	
	// Update is called once per frame
	void Update () {
		
	}//End Update Method

    public void AppleDestroyed()
    {
        //Destroy all of the apples
        //Get the index of the basket in the basketList
        int basketIndex = basketList.Count - 1;

        //Get a reference to that basket GameObject
        GameObject tbasketGO = basketList[basketIndex];

        //Remove that basket from the list and destroy the game object
        basketList.RemoveAt(basketIndex);
        Destroy(tbasketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }

    }//End AppleDestroyed

}//End Class
