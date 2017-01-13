using UnityEngine;
using System.Collections;

public class Spawn_VacancyCheck : MonoBehaviour {

    public bool isAvailable;

	// Use this for initialization
	void Awake ()
    {
        isAvailable = true;
    }

	public bool check()
	{
		if (Physics.CheckSphere(transform.position,1.5f))
		{return false;}
		else{return true;}
			
	}
}
