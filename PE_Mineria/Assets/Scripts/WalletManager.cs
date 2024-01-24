using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public static float Money { get; private set; }
    public void AddMoney(float  value)=> Money += value;
    public void SubstractMoney(float value)=> Money -= value;
}
