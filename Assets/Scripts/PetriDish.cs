using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetriDish : MonoBehaviour
{
    [SerializeField] public static readonly int Capasity = 128;
    [SerializeField] int InitialAmount = 10;
    [SerializeField] Bacteria bacteria;

    float minX = 0f;
    float minY = 0f;
    float maxX = 16f;
    float maxY = 9f;

    public static int bacteriesCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InitialAmount; ++i)
        {
            AddBacteria();
        }
    }

    public Bacteria AddBacteria(Vector3? position = null, Bacteria parentBacteria = null)
    {
        if (bacteriesCount <= Capasity)
        {
            Bacteria newBacteria = Instantiate<Bacteria>(bacteria, gameObject.transform);
            if (parentBacteria)
            {
                List<int> tmp = new List<int>(parentBacteria.commandList);
                newBacteria.parent = parentBacteria;
                newBacteria.commandList = tmp;
            }
            if (position != null)
            {
                newBacteria.transform.position = (Vector3)position;
            }
            bacteriesCount += 1;
            return newBacteria;
        }
        return null;
    }
}
