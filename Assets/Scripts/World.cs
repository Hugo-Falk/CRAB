using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private GameObject lobsterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(lobsterPrefab, new Vector2(Random.Range(4.5f, 4.5f), Random.Range(4.5f, 4.5f)), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
