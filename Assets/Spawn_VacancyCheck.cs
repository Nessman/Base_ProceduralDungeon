using UnityEngine;
using System.Collections;

public class Spawn_VacancyCheck : MonoBehaviour {

    public bool isAvailable;

	// Use this for initialization
	void Awake ()
    {
        isAvailable = true;
        //check();
    }

	public bool check()
	{
		if (Physics.CheckSphere(transform.position,1.5f))
		{
					//isAvailable = false;
					return false;

		}
		else{
			return true;
		}
			
	}
    /*
    void OnTriggerStay(Collider ground) // C#, type first, name in second
    {
        if (ground.gameObject.tag == "Ground")
        {
            isAvailable = false;
        }
    }*/
}
