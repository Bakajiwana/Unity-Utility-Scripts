using UnityEngine;
using System.Collections;

/* 	===============================Pseudocode Logic==================================
	Objective: Spawn a Random Game Object
	- From a variety of Objects in an array
	- Figure out the one that should be spawned
	- Use a random chance on each object to select the best candidate for the spawn
	- If spawn instantly is set spawn object instantly and then
	- Invoke the spawn function with random time
	- Once Spawn Function is activated figure out whether it should spawn or not
	==================================================================================
*/

public class RandomSpawner : MonoBehaviour
{
	//Spawn Objects
	[Header("Spawn Object Parameters")]
	[Tooltip ("Spawn Objects Array. Must be the same array length as Spawn Object Chance " +
	          "array. it's best to order these objects from uncommon to common. However " +
	          "it's still okay to have whatever order you like, it just makes " +
	          "the random generated objects override each other more accurately")]
	public GameObject[] spawnObjects;
	[Range(0, 100)]
	[Tooltip("This must be equal to the size of the Spawn Objects Array. Best ordered " +
	         "uncommon to common")]
	public int[] spawnObjectChance;

	//Spawn Options
	[Header("Spawn Options")]
	[Tooltip ("Should this object/s spawn instantly")]
	public bool spawnInstantly = true;
	[Tooltip("Should this object/s spawn once or within a random loop")]
	public bool spawnOnce = true;
	[Range(0f, 100f)]
	[Tooltip("Chance of Spawn from a percentage scale. Set to 100% for definite spawn")]
	public float spawnChance = 100f;

	//Random Times
	[Header("Random Time Parameters")]
	public float spawnMinTime = 1f;
	public float spawnMaxTime = 5f;	

	//Parent Spawn Object
	[Header("(Optional) Parent Object")]
	public Transform parentObject;
	public bool maintainWorldSpace = true;

	//This Function is called before Initialisation
	void Awake()
	{
		if (spawnObjects.Length != spawnObjectChance.Length)
		{
			print("Mate.... Make sure Spawn Object Chance has the same size as Spawn Objects.");
			this.enabled = false;
			return;
		}
	}

	//Used for Initialisation
	void OnEnable()
	{
		if (spawnInstantly)
		{
			//Spawn Random Object Instantly
			SpawnRandomObject();
		}
		else
		{
			//Or Invoke Random Time for function to be activated
			Invoke("SpawnRandomObject", Random.Range(spawnMinTime, spawnMaxTime));
		}
	}

	//This Function is called when a Random Object is required to spawn
	[ContextMenu ("Spawn Random Object")]
	public void SpawnRandomObject()
	{
		//Once Spawn Function is activated figure out whether it should spawn or not
		int randomChance = Random.Range(0, 100);

		if (randomChance <= spawnChance)
		{			
			SpawnObject(GetRandomObjectIndex());	//Spawn Random Object
		}

		//Once Object has spawned, repeat invoke with random time
		if (!spawnOnce)
		{
			Invoke("SpawnRandomObject", Random.Range(spawnMinTime, spawnMaxTime));
		}
	}

	//This Function is called to spawn the specific object
	public void SpawnObject(int _index)
	{		
		//This is a function because it may be called from another script
		if(parentObject)
		{
			Transform spawn = Instantiate (spawnObjects[_index].transform, transform.position, transform.rotation) as Transform;
			spawn.SetParent(parentObject, maintainWorldSpace);
		}
		else 
		{
			Instantiate (spawnObjects[_index], transform.position, transform.rotation);
		}		
	}

	int GetRandomObjectIndex()
	{
		int index = 0;

		//For all the Spawn Objects in the array
		for (int i = 0; i < spawnObjects.Length; i++)
		{
			//If up to the last loop by default the final spawn object will be selected
			if (i == spawnObjects.Length - 1)
			{
				index = i;
				break;
			}

			//Calculate whether the index object will spawn if not move on to the next
			int randomChance = Random.Range(0, 100);	//Calculate a random number

			//If Random Chance is lesser than Spawn Object Chance then return the index
			if (randomChance <= spawnObjectChance[i])
			{
				index = i; 	//Set Index
				break;		//then break this for loop
			}
			else
			{
				continue; 	//Continue the for loop
			}
		}

		return index;		//Return the chosen index
	}
}
