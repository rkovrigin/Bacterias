using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bacteria : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] const int commandStackSize = 128;
    [SerializeField] int bitUsageAmount = 5;
    [SerializeField] int maxEnergy = 255;
    [SerializeField] Bacteria prefab;

    public List<int> commandList;
    Rigidbody2D myRigidBody;
    int energy = 50;
    int currentCommandIndex = 0;
    public Bacteria parent = null;
    PetriDish petriDish;
    SunLight sunlight;

    private void Awake()
    {
        if (commandList == null || commandList.Count == 0)
        {
            commandList = new List<int>(commandStackSize);
            for (int i = 0; i < commandStackSize; ++i)
            {
                commandList.Add(Random.Range(0, (int)Mathf.Pow(2, bitUsageAmount)));
            }
        }
    }

    public void SetEnergy(int energyToSet)
    {
        energy = energyToSet;
    }

    public int GetEnergy()
    {
        return energy;
    }

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        petriDish = FindObjectOfType<PetriDish>();
        sunlight = FindObjectOfType<SunLight>();
    }

    void Update()
    {
        Action();
    }

    void OnMouseDown()
    {
        string commands = "";
        //foreach(int i in commandList)
        //{
        //    commands = commands + " " + i;
        //}
        Debug.Log(commands + ";   ENERGY = " + energy);
    }

    private void Action()
    {
        if (energy <= 0)
        {
            Destroy(gameObject);
            PetriDish.bacteriesCount -= 1;
        }

        if (commandList.Count == 0) return;

        var currentCommand = commandList[currentCommandIndex];

        if (currentCommand == Command.COMMAND_MOVE)
        {
            int nextCommand = commandList[(currentCommandIndex + 1) % commandStackSize];
            Vector2 direction = Command.spin[nextCommand % Command.directionsAmount];
            myRigidBody.velocity = direction;
            energy -= 5;
        }
        else if (currentCommand == Command.COMMAND_PHOTOSYNTHESIS)
        {
            energy += (int)sunlight.GetSunEnergy(gameObject.transform.position);
        }
        else if (currentCommand == Command.COMMAND_COPY)
        {
            if (energy > 30)
            {
                petriDish.AddBacteria(transform.position, this);
                energy -= 20;
            }
            else
            {
                energy -= 5;
            }
            
        }
        else if (currentCommand == Command.COMMAND_ATTACK)
        {
            energy -= 10;
        }
        else
        {
            energy -= 10;
        }

        currentCommandIndex = (currentCommandIndex + 1) % commandStackSize;
    }
}
