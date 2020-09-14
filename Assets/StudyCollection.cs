using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyCollection : MonoBehaviour
{
    // System.Collections : ArrayList, Queue, Stack >> 현재 사용을 권장하지 않음
    // System.Collections.Generic : List<>, Dictionary<KEY,VALUE>, Queue<>, Stack<>

    int[] intArray = new int[10];
    string[] stringArray;
    ArrayList arrayList;
    
    List<string> stringList; // 인스턴스 타입, 크기를 마음대로 바꿀 수 있는 어레이
    Dictionary<string, Vector2> vectorDic; // 인스턴스 타입, 키값으로 자료를 관리하는 자료형

    Stack<int> intStack; // 마지막에 넣은 값이 먼저 나옴
    Queue<int> intQueue; // 넣은 순서대로 값이 나옴

    
    void Start()
    {
        intStack = new Stack<int>();
        intQueue = new Queue<int>();

        intStack.Push(0);   // 값 넣기
        intStack.Push(1);
        intStack.Push(2);
        intStack.Push(3);

        intQueue.Enqueue(0);    // 값 넣기
        intQueue.Enqueue(1);
        intQueue.Enqueue(2);
        intQueue.Enqueue(3);

        int allCount = intStack.Count;
        for (int i = 0; i < allCount; i++)
        {
            Debug.Log("intStack 의 " + (i + 1) + "번째 값 : " + intStack.Pop()); // 값 빼기
            Debug.Log("intQueue 의 " + (i + 1) + "번째 값 : " + intQueue.Dequeue()); // 값 빼기
        }
        
        int curInt = intStack.Peek(); // 값을 빼지 않고 반환
    }

    void StudyDictionary()
    {
        vectorDic = new Dictionary<string, Vector2>();

        vectorDic.Add("위", Vector2.up);
        vectorDic.Add("아래", Vector2.down);
        vectorDic.Add("왼쪽", Vector2.left);
        vectorDic.Add("오른쪽", Vector2.right);

        if (vectorDic.ContainsKey("위") == true) // 키가 있는지
        {
            Vector2 upVec = vectorDic["위"];
        }

        if (vectorDic.ContainsValue(Vector2.up) == true) // 값이 있는지
        {

        }

        ShowVectorDic();
        
        Debug.Log("-------------------------------------------------------");
        
        vectorDic.Remove("아래");

        ShowVectorDic();
        
        vectorDic.Clear();
    }

    void ShowVectorDic()
    {
        foreach (KeyValuePair<string, Vector2> dicElement in vectorDic)
        {
            Debug.Log("vectorDic[" + dicElement.Key + "] : " + dicElement.Value);
        }
    }

    void StudyList()
    {
        stringList = new List<string>();
        
        stringList.Add("일");
        stringList.Add("이");
        stringList.Add("삼");
        stringList.Add("사");

        // stringList 안의 값 : "일" | "이" | "삼" | "사"
        // stringList  인덱스 :  0      1      2      3

        ShowStringList();

        stringList.Remove("오"); // 없는 요소를 지우라고 하기 때문에 아무일도 일어나지 않음

        Debug.Log("-------------------------------------------------------");

        stringList.Remove("이");

        // stringList 안의 값 : "일" | "삼" | "사"
        // stringList  인덱스 :  0      1      2      3

        ShowStringList();

        Debug.Log("-------------------------------------------------------");

        stringList.Insert(2, "삼.오");

        ShowStringList();

        Debug.Log("-------------------------------------------------------");

        stringList.Clear();
        stringList.Add("비웠다!");

        ShowStringList();

        stringArray = stringList.ToArray();             // 어레이 -> 리스트
        stringList = new List<string>(stringArray);     // 리스트 -> 어레이
    }

    void ShowStringList()
    {
        for(int i = 0; i < stringList.Count; ++i)
        {
            Debug.Log("stringList[" + i + "] : " + stringList[i]);
        }
    }

    void StudyArrayList()
    {
        // ArrayList (System.Collections)
        arrayList = new ArrayList();

        arrayList.Add(123); // int > 값타입 
        arrayList.Add("글자");
        arrayList.Add(new GameObject());
    }

}
