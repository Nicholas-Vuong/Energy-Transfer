using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnergyTower : MonoBehaviour
{
    public Sprite NormalTower;
    public Sprite SelectedTower;
    public Sprite ZappedTower;
    [SerializeField] DeadLightning[] dead;
    [SerializeField] Energy[] energies;
    [SerializeField] Game game;
    public int poleNumber;
    private bool OneSelect = false;
    private bool TwoSelect = false;
    private bool ThreeSelect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        
        if (tag.Equals("Pole 1"))
        {
            game.GetComponent<Game>().Click(0);
            GetComponent<AudioSource>().Play();
        }
        if (tag.Equals("Pole 2"))
        {
            game.GetComponent<Game>().Click(1);
            GetComponent<AudioSource>().Play();
        }
        if (tag.Equals("Pole 3"))
        {
            game.GetComponent<Game>().Click(2);
            GetComponent<AudioSource>().Play();
        }
    }

    public void setGraphic(int tower)
    {
        if (tower == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = NormalTower;
        }
        if (tower == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = SelectedTower;
        }
        if (tower == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ZappedTower;
        }
    }

    public Energy[] GetEnergies()
    {
        return energies;
    }

    public DeadLightning[] GetDead()
    {
        return dead;
    }
}
