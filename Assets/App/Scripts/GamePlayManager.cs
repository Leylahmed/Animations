using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    [SerializeField] private Transform TileSpawnPoint;

    [Range(0, 10)]
    [SerializeField] private int numberOfTiles;

    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private List<GameObject> tileArray = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for(int i=0; i<numberOfTiles; i++)
        {
            GameObject tileInstance = Instantiate(tilePrefab);

            tileInstance.name = tileArray.Count.ToString();

            if (tileArray.Count > 0)
            {
                tileInstance.transform.position = tileArray[tileArray.Count - 1].GetComponent<TileController>().endPoint.position;
                tileInstance.transform.parent = tileArray[0].transform;
            }
            else
            {
                tileInstance.transform.position = TileSpawnPoint.position;

                tileInstance.GetComponent<TileController>().InvokeRepeating("MoveTile", 0, 0.01f);
            }

            tileArray.Add(tileInstance);
        }
    }

    public void ChangeParent()
    {
        GameObject temp = tileArray[0];

        foreach (GameObject tile in tileArray)
        {
            tile.transform.parent = null;
        }

        temp.GetComponent<TileController>().CancelInvoke("MoveTile");

        temp.transform.position = tileArray[tileArray.Count - 1].GetComponent<TileController>().endPoint.position;

        tileArray.Remove(temp);

        tileArray.Add(temp);

        for(int i=1;i<tileArray.Count;i++)
        {
            tileArray[i].transform.parent = tileArray[0].transform;
        }

        tileArray[0].GetComponent<TileController>().InvokeRepeating("MoveTile", 0, 0.01f);

    }

}
