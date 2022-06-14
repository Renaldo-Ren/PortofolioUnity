using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_spawn : MonoBehaviour
{
    public float spawnMinXPos;
    public float spawnMaxXPos;
    public float spawnMinYPos;
    public float spawnMaxYPos;
    [SerializeField]
    private GameObject fish;

    [SerializeField]
    private GameObject predator;

    [SerializeField]
    private float fishInterval;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFish(fishInterval, fish));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnFish(float interval, GameObject fish)
    {
        yield return new WaitForSeconds(interval);
        Vector3 fishPos = new Vector3(Random.Range(spawnMinXPos,spawnMaxXPos), Random.Range(spawnMinYPos,spawnMaxYPos), -1f);
        GameObject newFish = Instantiate(fish, fishPos, Quaternion.identity);
        StartCoroutine(spawnFish(interval, fish));
    }
}

