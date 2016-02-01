using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UIProxyWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AttachUI", AttachUI),
			new LuaMethod("SetLabelText", SetLabelText),
			new LuaMethod("SetSprite", SetSprite),
			new LuaMethod("GridReposition", GridReposition),
			new LuaMethod("ScrollViewReposition", ScrollViewReposition),
			new LuaMethod("New", _CreateUIProxy),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "UIProxy", typeof(UIProxy), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIProxy(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIProxy class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UIProxy);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AttachUI(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIProxy obj = (UIProxy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProxy");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		GameObject arg1 = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		GameObject o = obj.AttachUI(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLabelText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIProxy obj = (UIProxy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProxy");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.SetLabelText(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		UIProxy obj = (UIProxy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProxy");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.SetSprite(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GridReposition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIProxy obj = (UIProxy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProxy");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		obj.GridReposition(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScrollViewReposition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIProxy obj = (UIProxy)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProxy");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		obj.ScrollViewReposition(arg0);
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

