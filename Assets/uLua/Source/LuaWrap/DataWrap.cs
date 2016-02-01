using System;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class DataWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("GetLabelNameList", GetLabelNameList),
			new LuaMethod("GetSpriteNameList", GetSpriteNameList),
			new LuaMethod("New", _CreateData),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Data", typeof(Data), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateData(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Data class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Data);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLabelNameList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Data obj = (Data)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Data");
		List<string> o = obj.GetLabelNameList();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSpriteNameList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Data obj = (Data)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Data");
		List<string> o = obj.GetSpriteNameList();
		LuaScriptMgr.PushObject(L, o);
		return 1;
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

