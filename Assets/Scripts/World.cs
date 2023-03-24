using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private GameObject lobsterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(lobsterPrefab, new Vector2(3, 3), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
