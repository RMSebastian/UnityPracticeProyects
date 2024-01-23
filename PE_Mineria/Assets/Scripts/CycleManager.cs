using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CycleManager : MonoBehaviour
{
	private List<string> cycleList = new List<string> { "Morning", "Midday", "Afternoon", "Night" };
	[SerializeField]private UnityEvent<string> dayCycleChangedEvent = new UnityEvent<string>();
    [SerializeField] private UnityEvent<string> dayChangedEvent = new UnityEvent<string>();
	private int cycleIndex, totalDaysIndex;
    private void Start()
    {
		cycleIndex = -1;
		totalDaysIndex = 1;
		ChangeTime();
		NextDay();
    }
    public void ChangeTime()
	{
		cycleIndex++;
		if (cycleIndex > cycleList.Count - 1)
		{
			totalDaysIndex++;
			cycleIndex = 0;
			NextDay();
		}
		CyclingDay();
    }
	private void CyclingDay()=> dayCycleChangedEvent.Invoke(cycleList[cycleIndex]);
    private void NextDay()=> dayChangedEvent.Invoke(totalDaysIndex.ToString());
}
