using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour
{
    [SerializeField]private List<MineHandler> mineHandlers = new List<MineHandler>();
    private int dayIndex = 0;
    public void AddMineManager(MineHandler mineHandler)=> mineHandlers.Add(mineHandler);
    
    public void SetMines(string days)
    {
        int day = int.Parse(days);
        if (day != dayIndex && day <= mineHandlers.Count)
        {
            mineHandlers[dayIndex].InitMine();
            dayIndex = day;
        }
    }
}
