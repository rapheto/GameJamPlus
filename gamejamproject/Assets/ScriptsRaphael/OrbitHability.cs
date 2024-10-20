using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitHability : MonoBehaviour
{
    public int orbitLevel;
    public Orbitcircle orbitScript;
    public Orbitcircle orbitScript2;
    public GameObject orbitOne;
    public GameObject orbitTwo;
    public GameObject orbitThree;
    public bool oneOrbit;
    public bool twoOrbit;
    public bool LevelTwoOrbit;
    public bool LevelThreeOrbit;
    public bool LevelFiveOrbit;
    // Start is called before the first frame update
    void Start()
    {
        oneOrbit = false;
        twoOrbit = false;
        LevelFiveOrbit = false;
        LevelThreeOrbit = false;
        LevelTwoOrbit = false;
        orbitLevel = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (orbitLevel == 1 && !oneOrbit)
        {
            
            orbitOne.SetActive(true);
            orbitScript = GameObject.FindGameObjectWithTag("OrbitCircle").GetComponent<Orbitcircle>();
            oneOrbit = true;
        }
        else if (orbitLevel == 2 && !LevelTwoOrbit)
        {
            orbitScript.orbitSpeed = 100;
            LevelTwoOrbit = true;
        }
        else if (orbitLevel == 3 && !LevelThreeOrbit)
        {
            orbitScript.orbitSpeed = 150;
            LevelThreeOrbit = true;
        }
        else if (orbitLevel == 4 && !twoOrbit)
        {
            orbitOne.SetActive(false);
            orbitTwo.SetActive(true);
            orbitThree.SetActive(true);
            orbitScript = GameObject.FindGameObjectWithTag("OrbitCircle").GetComponent<Orbitcircle>();
            orbitScript2 = GameObject.FindGameObjectWithTag("OrbitCircle2").GetComponent<Orbitcircle>();
            orbitScript.orbitSpeed = 150;
            orbitScript2.orbitSpeed = 150;
        }
        else if (orbitLevel == 5 && !LevelFiveOrbit) {
            orbitScript.orbitSpeed = 200;
            orbitScript2.orbitSpeed = 200;
            LevelFiveOrbit = true;
        }
    }
}
