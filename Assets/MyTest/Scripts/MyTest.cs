using UnityEngine;
using System.Collections;
using LuaInterface;
using System;

public class MyTest : MonoBehaviour {

    public static UIProxy MyUIProxy;
    public static Data MyData;

    private LuaScriptMgr luaMgr;
    private LuaFunction luaFunc;

    void Awake()
    {
        MyUIProxy = gameObject.AddComponent<UIProxy>();
        MyData = gameObject.AddComponent<Data>();
    }

	// Use this for initialization
	void Start () {
        luaMgr = new LuaScriptMgr();
        luaMgr.Start();
        luaMgr.DoFile("Logic.MyTest2");
        luaFunc = luaMgr.GetLuaFunction("Test2");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("q"))
        {
            luaFunc.Call();
        }
    }
}
