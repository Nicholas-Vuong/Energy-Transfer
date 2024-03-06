using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] int energyLevel;
    [SerializeField] float animationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = animationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void moveLightning(int rod)
    {
        if (rod == 0)
        {
            gameObject.transform.position = new Vector2(-7.25f, transform.position.y);
            GetComponent<AudioSource>().Play();
        }
        if (rod == 1)
        {
            gameObject.transform.position = new Vector2(0.025f, transform.position.y);
            GetComponent<AudioSource>().Play();
        }
        if (rod == 2)
        {
            gameObject.transform.position = new Vector2(7.25f, transform.position.y);
            GetComponent<AudioSource>().Play();
        }
    }
    public int EnergyLevel()
    {
        return energyLevel;
    }
}
