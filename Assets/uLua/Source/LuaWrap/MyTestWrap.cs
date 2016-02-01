using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MyTestWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateMyTest),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("MyUIProxy", get_MyUIProxy, set_MyUIProxy),
			new LuaField("MyData", get_MyData, set_MyData),
		};

		LuaScriptMgr.RegisterLib(L, "MyTest", typeof(MyTest), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMyTest(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MyTest class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(MyTest);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MyUIProxy(IntPtr L)
	{
		LuaScriptMgr.Push(L, MyTest.MyUIProxy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MyData(IntPtr L)
	{
		LuaScriptMgr.Push(L, MyTest.MyData);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MyUIProxy(IntPtr L)
	{
		MyTest.MyUIProxy = (UIProxy)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIProxy));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_MyData(IntPtr L)
	{
		MyTest.MyData = (Data)LuaScriptMgr.GetUnityObject(L, 3, typeof(Data));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

