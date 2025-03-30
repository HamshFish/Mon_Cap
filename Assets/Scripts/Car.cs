using UnityEngine;
public class Car
{
    private string owner = "";
    protected string colour = "Red";
    public float speed = 5;
    public int wheelCount = 4;

    public Car()
    {
        Debug.Log("Constructor");
        owner = "GRIMM";
    }
}

public class F1 : Car
{
    public F1()
    {
        speed = 10;
    }
}
