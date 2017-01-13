using UnityEngine;
using System.Collections;

public class Spawn_FloorTile : MonoBehaviour {

    public GameObject roomBase;

    public GameObject SpawnerNorthCheck;
    public GameObject SpawnerEastCheck;
    public GameObject SpawnerSouthCheck;
    public GameObject SpawnerWestCheck;
	public int spawnChance;
    
    private int whichSpawner;
    private int doIBranch =  1;


    private Manager_Tiles manager_Tiles;
    private Spawn_VacancyCheck[] vacanyChecks = new Spawn_VacancyCheck[5]; // 5 is used to house the 4 cardinal directions and an empty starting point
    
    
    
    

    void Start ()
    {
		manager_Tiles = transform.root.GetComponent <Manager_Tiles> ();
        //manager_Tiles = GameObject.Find("TileManager").GetComponent <Manager_Tiles> (); 

        vacanyChecks[1] = SpawnerNorthCheck.GetComponent<Spawn_VacancyCheck>();
        vacanyChecks[2] = SpawnerEastCheck.GetComponent<Spawn_VacancyCheck>();
        vacanyChecks[3] = SpawnerSouthCheck.GetComponent<Spawn_VacancyCheck>();
        vacanyChecks[4] = SpawnerWestCheck.GetComponent<Spawn_VacancyCheck>();

        if (manager_Tiles.tilesLeft() >= 1)
        {
            whichSpawner = Random.Range(1, 4);
			//whichSpawner = 1;
            //Debug.Log(vacanyChecks[whichSpawner]);
            //doIBranch = Random.Range(1, 10);
            CreateTile();
		}
		doIBranch = Random.Range(1, 100);
		if (manager_Tiles.spawnChance(doIBranch) == true && manager_Tiles.tilesLeft() >= 1)
		{
			whichSpawner = Random.Range(1, 4);
			//doIBranch = 0;
			//Debug.Log("branch!" + transform.parent.name);
			//whichSpawner = 3;
			CreateTile();
		}
		
    }

    public bool CreateTile ()
    {
	int attempts = 0;
	while(attempts <= 4)
	//for (int i = 0; i < 5; i++)
		{
        if (vacanyChecks[whichSpawner].check() == true)
            {
				manager_Tiles.spawnRoom(roomBase, vacanyChecks[whichSpawner]);
				return true;
                /*
				GameObject newRoom = Instantiate(roomBase, vacanyChecks[whichSpawner].transform.position, vacanyChecks[whichSpawner].transform.rotation);
                newRoom.name = ("Base Tile " + manager_Tiles.tilesLeft());
                manager_Tiles.numberOfTilesLeft -= 1;
				*/
				//newRoom.transform.parent = transform.parent.transform;
            }
			whichSpawner++;
			if(whichSpawner > 4) {whichSpawner = 1;} //to not break the game when I run out of the array
			attempts++;
		}
		return false;
    }
}
