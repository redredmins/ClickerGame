using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay
{
    // params : 가변인자.
    //          자료형은 무조건 어레이로. 여러 매개변수가 있다면 맨 마지막에 넣어주셔야 합니다.
    public void ShowText(int a, params string[] texts)
    {
        string textForShow = "";
        foreach(string t in texts)
        {
            textForShow = textForShow + " / " + t;
        }

        Debug.Log(textForShow);
    }

}


public class GenericClass<T>
    where T : new()
{
    T genericThing;
    T[] genericThings;

    public GenericClass(T thing, params T[] things)
    {
        this.genericThing = thing;
        this.genericThings = things;
    }

    public void ShowMyThing()
    {
        Debug.Log(genericThing.ToString());

        foreach (var g in genericThings)
        {
            Debug.Log("genericThings : " + g.ToString());
        }
    }

}
