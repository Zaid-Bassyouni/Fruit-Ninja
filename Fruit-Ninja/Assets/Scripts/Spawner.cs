using UnityEngine;
using System.Collections ;

public class Spawner : MonoBehaviour
{
    private Collider SpawnArea;
    public GameObject[] FruitPrefabs;

    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce=18f;
    public float maxForce=22f;

    public float maxLifeTime=5f;

    private void Awake()
    {
        SpawnArea = GetComponent<Collider>();
    }
    private void Start()
    {
       // InvokeRepeating("createObject",0f,2f);
        //InvokeRepeating("DestroyObject",0f,2f);

    }
    
   /*     private void createObject()
        {
          int randomIndex = Random.Range(0, FruitPrefabs.Length);
          GameObject selectedPrefab = FruitPrefabs[randomIndex];

         Vector3 position = new Vector3();
         position.x=Random.Range(SpawnArea.bounds.min.x,SpawnArea.bounds.max.x);
         position.y=Random.Range(SpawnArea.bounds.min.y,SpawnArea.bounds.max.y);
         position.z=Random.Range(SpawnArea.bounds.min.z,SpawnArea.bounds.max.z);

         Quaternion rotation = Quaternion.Euler(0f,0f,Random.Range(minAngle,maxAngle));

         
         //  DestroyObject(selectedPrefab,maxLifeTime );

         float Force =Random.Range(minForce,maxForce);
         selectedPrefab.GetComponent<Rigidbody>().AddForce(selectedPrefab.transform.up*Force,ForceMode.Impulse);

        }*/
  

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
      StopAllCoroutines();
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        while (enabled)
        {
            GameObject selectedFruitPrefab = FruitPrefabs[Random.Range(0, FruitPrefabs.Length)];

            Vector3 position = new Vector3();
            position.x = Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x);
            position.y = Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);
            position.z = Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z);
                                       
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle)); //we don't need x //we don't need Y // all we need is Rotion in Z AXIS.

          GameObject Fruit=  Instantiate(selectedFruitPrefab, position, rotation);
            Destroy(Fruit ,maxLifeTime);

            float force = Random.Range(minForce, maxForce);
            Fruit.GetComponent<Rigidbody>().AddForce(Fruit.transform.up * force, ForceMode.Impulse);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }
    
}
