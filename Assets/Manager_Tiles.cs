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
		int branches = 1;
		bool success = true;
		while (numberOfTilesLeft >= 1)
        {
			tilesInStack++;
            success = tile.CreateTile();
			tilesInStack--;
			doIBranch = Random.Range(1, 100);
			if (doIBranch <= branchChance && branches > 0){branches--;}
			else{break;}
		}
		//Debug.Log(tilesInStack);
		if (success == false && tilesInStack <= 0){forceSpawn();}
	}
	public void spawnRoom(GameObject roomBase, Spawn_VacancyCheck whichSpawner)
	{
		GameObject newRoom = Instantiate(roomBase, whichSpawner.transform.position, whichSpawner.transform.rotation);
		newRoom.name = ("Base Tile " + numberOfTilesLeft);
		newRoom.transform.SetParent (transform); 
		numberOfTilesLeft--;
	}
	void forceSpawn()
	{
		foreach(Transform child in transform){
			if (child.gameObject.GetComponentInChildren<Spawn_FloorTile>().CreateTile()==true){break;}
		}
	}
}
