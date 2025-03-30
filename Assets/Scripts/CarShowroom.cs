using UnityEngine;

public class CarShowroom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Car myCar = new Car();
        F1 F1Car = new F1();
        Debug.Log(F1Car.wheelCount);
    }
}
