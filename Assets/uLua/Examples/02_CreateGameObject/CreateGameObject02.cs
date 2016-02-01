using UnityEngine;
using System.Collections;
using LuaInterface;
using System;

public class CreateGameObject02 : MonoBehaviour {
    LuaScriptMgr mgr;
    LuaFunction func;

	//非反射调用
	void Start () {
        mgr = new LuaScriptMgr();
        mgr.Start();
        mgr.DoFile("Logic.MyTest");
        func = mgr.GetLuaFunction("Test");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey("q"))
        {
            func.Call();
        }
        if(Input.GetKey("w"))
        {
            NativeTest();
        }
	}

    void NativeTest()
    {
        float startTime = Time.realtimeSinceStartup;
        GameObject parent = new GameObject("node");
        GameObject template = new GameObject("template");
        template.transform.parent = parent.transform;

        for (int i = 0; i < 1000; i++)
        {
            if (i < parent.transform.childCount)
            {
                GameObject child0 = parent.transform.GetChild(i).gameObject;
            }
            GameObject child = GameObject.Instantiate(parent.transform.GetChild(0).gameObject);
            child.transform.parent = parent.transform;
            child.transform.localPosition = new Vector3(0, 0, 0);
            child.transform.localRotation = Quaternion.identity;
            child.transform.localScale = parent.transform.GetChild(0).localScale;
        }
        float stopTime = Time.realtimeSinceStartup;
        Debug.Log("Performance Time is " + (stopTime - startTime));
    }
}
