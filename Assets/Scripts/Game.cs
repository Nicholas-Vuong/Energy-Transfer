using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Sprite NormalTower;
    public Sprite SelectedTower;
    public Sprite ZappedTower;
    [SerializeField] Text scoreText;
    [SerializeField] EnergyTower[] towers;
    bool dead;
    int selected = -1;
    EnergyTower from;
    EnergyTower to;
    Energy e = null;
    int[] Lightning = new int[4];
    [SerializeField] int energyLevel;
    [SerializeField] float animationSpeed;
    bool lose = false;
    bool win = false;
    bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = animationSpeed;
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            if (Input.GetKeyDown("r")||Input.GetKeyDown("R"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void Overload(GameObject energy1, GameObject energy2)
    {
        
    }
    public void Click(int pole)
    {
        if (dead)
        {
            return;
        }
        //checks to see if a pole is already clicked
        if (selected == -1)
        {
            selected = pole;
            towers[pole].GetComponent<SpriteRenderer>().sprite = SelectedTower;
        }
        else 
        {
            //checks to see if same pole is clicked
            if (selected == pole)
            {
                towers[pole].GetComponent<SpriteRenderer>().sprite = NormalTower;
                selected = -1;
            }
            //if a pole is already slected and a new pole is clicked
            else
            {
                //checks for lowest energy 
                int lowest = 4;
                for (int x = 0; x < 4; x++)
                {
                    if (towers[selected].GetEnergies()[x]==null)
                    {
                        continue;
                    }
                    if (towers[selected].GetEnergies()[x].EnergyLevel() < lowest)
                    {
                        lowest = towers[selected].GetEnergies()[x].EnergyLevel();
                        break;
                    }
                }
                towers[pole].GetEnergies()[lowest-1] = towers[selected].GetEnergies()[lowest-1];
                towers[selected].GetComponent<SpriteRenderer>().sprite = NormalTower;
                towers[pole].GetEnergies()[lowest-1].moveLightning(pole);
                towers[selected].GetEnergies()[lowest-1] = null;
                selected = -1;
                //checks for overload
                for (int x = 0; x < 4; x++)
                {
                    if (towers[pole].GetEnergies()[x] == null)
                    {
                        continue;
                    }
                    Debug.Log(towers[pole].GetEnergies()[lowest - 1].EnergyLevel() + " " + towers[pole].GetEnergies()[x].EnergyLevel());
                    if (towers[pole].GetEnergies()[lowest - 1].EnergyLevel() > towers[pole].GetEnergies()[x].EnergyLevel())
                    {
                        lose = true;
                        for (int y = 0; y < 4; y++)
                        {
                            if (towers[pole].GetEnergies()[y] == null)
                            {
                                continue;
                            }
                            towers[pole].GetComponent<EnergyTower>().GetEnergies()[y].transform.position = new Vector2(10, 10);
                        }
                        towers[pole].GetComponent<SpriteRenderer>().sprite = ZappedTower;
                        towers[pole].GetComponent<EnergyTower>().GetEnergies()[x] = null;
                        GameObject dead = GameObject.FindGameObjectWithTag("DeadLightning");
                        Debug.Log(dead);
                        if (pole == 0)
                        {
                            Debug.Log("dead 1");
                            dead.transform.position = new Vector2(-7.50f, -.02f);
                        }
                        else if (pole == 1)
                        {
                            Debug.Log("dead 2");
                            dead.transform.position = new Vector2(-0.025f, -.02f);
                        }
                        else if (pole == 2)
                        {
                            Debug.Log("dead 3");
                            dead.transform.position = new Vector2(7.0f, -.02f);
                        }
                        Debug.Log("I LOST");
                        break;
                    }
                }
                //checks for win
                int count = 0;
                for (int x = 0; x < 4; x++)
                {
                    if (towers[2].GetEnergies()[x] != null)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == 4)
                {
                    win = true;
                    Debug.Log("Win");
                    scoreText.text = "You Win! Press R to Restart";
                    gameover = true;
                }
                if (lose==true&&win==false)
                {
                    Debug.Log("Lose");
                    scoreText.text = "You broke the Energy Machine, You Lose! Press R to Restart";
                    gameover = true;
                    GetComponent<AudioSource>().Play();
                }
            }
        }
        Debug.Log(pole);
    }
}
