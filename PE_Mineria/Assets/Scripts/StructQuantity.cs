public struct StructQuantity
{
    public MachinerySO Machine;
    public ResourcesSO Resource;
    public float Quantity;
    public float MaxQuantity;

    public void SetMaxQuantity()=> MaxQuantity = (Machine.Cost == 0) ? 50 : Machine.Cost / 4;
}
