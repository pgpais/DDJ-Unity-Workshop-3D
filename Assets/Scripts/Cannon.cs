using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{   
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootingPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Shoot(){
        Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
