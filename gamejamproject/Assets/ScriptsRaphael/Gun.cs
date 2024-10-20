using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPoint;
    public Transform bulletPoint2;
    public Transform bulletPoint3;
    public int gunLevel;
    private bool canShoot = true;
    public float reloadTime;

    // Start is called before the first frame update
    void Start()
    {
        reloadTime = 3;
        gunLevel = 0;
        StartCoroutine(reload());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
    }
    void ShootLvlTres()
    {
        Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        Instantiate(bullet, bulletPoint2.position, bulletPoint2.rotation);
        Instantiate(bullet, bulletPoint3.position, bulletPoint3.rotation);
    }

    IEnumerator reload()
    {
        Debug.Log("Iniciou corrotina");
        while (canShoot){
            Debug.Log("Iniciou while");
            yield return new WaitForSeconds(reloadTime);
            if (gunLevel == 0)
            {
                reloadTime = 3;
                Shoot();
            }
            else if (gunLevel == 1)
            {
                reloadTime = 3;
                Shoot();
                StartCoroutine(rajada());
            }
            else if (gunLevel == 2)
            {
                Debug.Log("entrou no gun level2");
                reloadTime = 2;
                Shoot();
                StartCoroutine(rajada());
            }
            else if (gunLevel == 3)
            {
                reloadTime = 2;
                ShootLvlTres();
            }
            else if (gunLevel == 4) {
                reloadTime = 1.5f;
                ShootLvlTres();
            }
        }
    }

    IEnumerator rajada()
    {
        yield return new WaitForSeconds(0.2f);
        Shoot();
    }
}
