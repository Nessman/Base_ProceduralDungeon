using UnityEngine;
using System.Collections;

public class Spawn_FloorTile : MonoBehaviour {

    public GameObject roomBase;

    public GameObject SpawnerNorthCheck;
    public GameObject SpawnerEastCheck;
    public GameObject SpawnerSouthCheck;
    public GameObject SpawnerWestCheck;

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
		manager_Tiles.checkSpawn(this);
    }

    public bool CreateTile ()
    {
	int attempts = 0;
	int whichSpawner = Random.Range(1, 4);
	while(attempts <= 4)
		{
		//Debug.Log(vacanyChecks[whichSpawner]);
        if (vacanyChecks[whichSpawner].check() == true)
            {
				manager_Tiles.spawnRoom(roomBase, vacanyChecks[whichSpawner]);
				return true;
            }
			whichSpawner++;
			if(whichSpawner > 4) {whichSpawner = 1;} //to not break the game when I run out of the array
			attempts++;
		}
		return false;
    }
}
