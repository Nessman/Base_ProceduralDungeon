using UnityEngine;
using System.Collections;

public class Manager_Tiles : MonoBehaviour {

    public int numberOfTilesLeft;
	public int branchChance;
	// Use this for initialization
	void Start () {

	}
	public int tilesLeft(){
		return numberOfTilesLeft;
	}
	public void spawnRoom(GameObject roomBase, Spawn_VacancyCheck whichSpawner)
	{
		GameObject newRoom = Instantiate(roomBase, whichSpawner.transform.position, whichSpawner.transform.rotation);
		newRoom.name = ("Base Tile " + numberOfTilesLeft);
		newRoom.transform.SetParent (transform); 
		numberOfTilesLeft--;
	}
	public bool spawnChance(int doIBranch)
	{
		if (doIBranch <= branchChance){
			return true;
		}
		else {return false;}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
