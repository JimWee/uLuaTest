--ZBS = "D:/ZeroBraneStudio/";
--LuaPath = "E:/Unity Projects/uLua/uLua/Assets/uLua/Lua"
--package.path = package.path..";./?.lua;"..ZBS.."lualibs/?/?.lua;"..ZBS.."lualibs/?.lua;"..LuaPath.."?.lua;"

--require("mobdebug").start()

--import 'Behaviour'
--import 'Component'
--import 'GameObject'
--import 'MonoBehaviour'
--import 'Transform'

function Test()
    local startTime = os.clock()
    local parent = GameObject('node')
    local template = GameObject('template')
    template.transform.parent = parent.transform

    -- local startTime = os.clock()
    for i = 0, 1000 do
        if i < parent.transform.childCount then
            local child = parent.transform:GetChild(i).gameObject
        end
        local child = GameObject.Instantiate(parent.transform:GetChild(0).gameObject)
        child.transform.parent = parent.transform
        child.transform.localPosition = Vector3(0, 0, 0)
        child.transform.localRotation = Quaternion.identity
        child.transform.localScale = parent.transform:GetChild(0).localScale
    end
    local stopTime = os.clock()
    luanet.Debugger.Log('Performance Time is {0}', stopTime - startTime)
end
