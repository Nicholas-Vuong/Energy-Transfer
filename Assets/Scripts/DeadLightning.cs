using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLightning : MonoBehaviour
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
    public void moveDeadlightning(int rod)
    {
        if (rod == 0)
        {
            gameObject.transform.position = new Vector2(-7.25f, transform.position.y);
        }
        if (rod == 1)
        {
            gameObject.transform.position = new Vector2(0.025f, transform.position.y);
        }
        if (rod == 2)
        {
            gameObject.transform.position = new Vector2(7.25f, transform.position.y);
        }
    }

}
