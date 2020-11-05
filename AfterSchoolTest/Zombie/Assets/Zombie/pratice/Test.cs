using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public PropertyTest propertyTest;


    private void Start()
    {
        propertyTest.InputA = 10f;

        var inputA = propertyTest.InputA;



       // propertyTest.InputB = 10f;
       // var inputB = propertyTest.InputB;


       

        propertyTest.InputC = 10f; //내부 10출력
        var inputC = propertyTest.InputC; //외부에는 10 출력

    }
}
