using System;
using System.Collections.Generic;

public static class LuaBinder
{
	public static List<string> wrapList = new List<string>();
	public static void Bind(IntPtr L, string type = null)
	{
		if (type == null || wrapList.Contains(type)) return;
		wrapList.Add(type); type += "Wrap";
		switch (type) {
			case "BehaviourWrap": BehaviourWrap.Register(L); break;
			case "ComponentWrap": ComponentWrap.Register(L); break;
			case "DataWrap": DataWrap.Register(L); break;
			case "DebuggerWrap": DebuggerWrap.Register(L); break;
			case "EnumWrap": EnumWrap.Register(L); break;
			case "GameObjectWrap": GameObjectWrap.Register(L); break;
			case "IEnumeratorWrap": IEnumeratorWrap.Register(L); break;
			case "MonoBehaviourWrap": MonoBehaviourWrap.Register(L); break;
			case "MyTestWrap": MyTestWrap.Register(L); break;
			case "ObjectWrap": ObjectWrap.Register(L); break;
			case "stringWrap": stringWrap.Register(L); break;
			case "System_ObjectWrap": System_ObjectWrap.Register(L); break;
			case "TimeWrap": TimeWrap.Register(L); break;
			case "TransformWrap": TransformWrap.Register(L); break;
			case "TypeWrap": TypeWrap.Register(L); break;
			case "UIProxyWrap": UIProxyWrap.Register(L); break;
		}
	}
}
