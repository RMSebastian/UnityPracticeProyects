using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MineManager : MonoBehaviour
{
    [SerializeField]private List<MineHandler> mineHandlers = new List<MineHandler>();
    [SerializeField]private List<ResourcesSO> typeOfResources = new List<ResourcesSO>();
    [SerializeField]private UnityEvent<ResourcesSO, UnityAction<MachinerySO>> OnSelectionEvent = new UnityEvent<ResourcesSO, UnityAction<MachinerySO>>();
    private int dayIndex = 0;
    public void UnlockMine(string days)
    { 
        int day = int.Parse(days);

        if (day != dayIndex && day <= mineHandlers.Count)
        {
            if (dayIndex != 0) mineHandlers[dayIndex].InitMine(typeOfResources[Random.Range(0, typeOfResources.Count)]);
            else
            {
                SortLists(mineHandlers);
                mineHandlers[dayIndex].InitMine(typeOfResources[0]);
            }
            dayIndex = day;
        }
    }
    public void AddMineManager(MineHandler mineHandler)=> mineHandlers.Add(mineHandler);
    public void UpdateOnCycle() { for (int i = 0; i < dayIndex; i++) mineHandlers[i].UpdateOnCyle(); }
    public void OnSelectEvent(ResourcesSO resources, UnityAction<MachinerySO> action) => OnSelectionEvent.Invoke(resources, action);    
    private void SortLists<T>(List<T> list) where T: Object=> list.Sort((left, right) => left.name.CompareTo(right.name));


}
