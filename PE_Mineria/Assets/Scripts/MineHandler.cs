using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineHandler : MonoBehaviour
{
    public GameObject Model;
    private MineManager manager;
    private Material material;
    private Collider collider;
    private void Start()
    {
        manager = FindAnyObjectByType<MineManager>();
        manager?.AddMineManager(this);
        material = GetComponent<MeshRenderer>().material;
        material.color = Color.black;
        collider = GetComponent<Collider>();
        collider.enabled = false;
    }
    public void InitMine()
    {
        print("se");
        material.color = Color.white;
        collider.enabled = true;
    }

}
