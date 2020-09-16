using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyGeneric : MonoBehaviour
{
    void Start()
    {
        TextDisplay td = new TextDisplay();

        td.ShowText(1, "이런", "식으로", "몇 개든지", "넣을 수", "있습니다.");

        td.ShowText(1 , "!!", "~~");
    }


    void TestGeneric()
    {
        int aInt = 7;
        float aFloat = Mathf.PI;

        char oneText = 'A';
        string textString = "ABCDEF~";

        Vector2 twoDPos = new Vector2(3f, 5f);
        Vector3 threeDPos = new Vector3(0f, 1f, 0f);

        Debug.Log("ShowLog<int, char, Vector2>(aInt, oneText, twoDPos);");
        ShowLog<int, char, Vector2>(aInt, oneText, twoDPos);

        Debug.Log("ShowLog<float, string, Vector3>(aFloat, textString, threeDPos);");
        ShowLog<float, string, Vector3>(aFloat, textString, threeDPos);
    }

    void TestGenericClass()
    {
        GameObject aObj = new GameObject(); 
        GameObject bObj = new GameObject();
        
        GenericClass<GameObject> objGc = new GenericClass<GameObject>(aObj, aObj, bObj);

        aObj.name = "aObj";
        bObj.name = "bObj";

        Debug.Log("---- obj generic class");
        objGc.ShowMyThing();

        Vector2 aVec = new Vector2(1f, 2f);
        Vector2 bVec = new Vector2(3f, 4f);
        Vector2[] vecArray = new Vector2[2]
        {
            aVec, bVec
        };

        GenericClass<Vector2> vecGc = new GenericClass<Vector2>(aVec, vecArray);

        Debug.Log("---- vec generic class");
        vecGc.ShowMyThing();

    }

    // 제네릭 메서드
    // : 임의의 매개변수 타입 T, U, P를 만들고, 다양한 타입의 값을 받아올 수 있음.
    void ShowLog<T, U, P>(T number, U text, P vector)
        where T : struct
        //where U : System.IComparable<U>
        where P : System.IEquatable<P>
    {
        Debug.Log("number : " + number);
        Debug.Log("text : " + text);
        Debug.Log("vector : " + vector.ToString());
    }

    void ShowLog(int intNum, char text, Vector2 vec)
    {

    }
}
