using UnityEngine;
using System.Collections;

public class Manager_Tiles : MonoBehaviour {

    public int numberOfTilesLeft;
	public int branchChance;
	
	private int tilesInStack = 0;
	private int doIBranch = 0;
	void Start () {

	}

	public void checkSpawn(Spawn_FloorTile tile)
	{
		do{
        if (numberOfTilesLeft >= 1)
        {
			tilesInStack++;
            bool success = tile.CreateTile();
			tilesInStack--;
			if (!success){ }
		}
		doIBranch = Random.Range(1, 100);
		}while (doIBranch <= branchChance);
	}
	public void spawnRoom(GameObject roomBase, Spawn_VacancyCheck whichSpawner)
	{
		GameObject newRoom = Instantiate(roomBase, whichSpawner.transform.position, whichSpawner.transform.rotation);
		newRoom.name = ("Base Tile " + numberOfTilesLeft);
		newRoom.transform.SetParent (transform); 
		numberOfTilesLeft--;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
