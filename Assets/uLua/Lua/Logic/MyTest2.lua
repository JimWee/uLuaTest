local function GetTemplateChild(parent, index)
    if index < parent.transform.childCount then
        return parent.transform:GetChild(index).gameObject
    end

    local child = GameObject.Instantiate(parent.transform:GetChild(0).gameObject)
    child.transform.parent = parent.transform
    child.transform.localPosition = Vector3(0, 0, 0)
    child.transform.localRotation = Quaternion.identity
    child.transform.localScale = parent.transform:GetChild(0).localScale
    return child
end

local function FindChild(parent, childName)
    return parent.transform:Find(childName).gameObject;
end

--MyTest = luanet.MyTest
--Debugger = luanet.Debugger
import 'MyTest'
import 'Data'
import 'UIProxy'

function Test2()
    local startTime = os.clock()
    local parent = GameObject.Find("UI Root (3D)")
    local window = MyTest.MyUIProxy:AttachUI("test_ui", parent)
    local uiGrid = FindChild(window, "Scroll View/UIGrid")
    local labelNameList = MyTest.MyData:GetLabelNameList()
    local spriteNameList = MyTest.MyData:GetSpriteNameList()

    for i = 0, 99 do
        local uiItem = GetTemplateChild(uiGrid, i)
        MyTest.MyUIProxy:SetLabelText(FindChild(uiItem, "UILabel1"), labelNameList[i])
        MyTest.MyUIProxy:SetLabelText(FindChild(uiItem, "UILabel2"), labelNameList[i])
        MyTest.MyUIProxy:SetLabelText(FindChild(uiItem, "UILabel3"), labelNameList[i])
        MyTest.MyUIProxy:SetSprite(FindChild(uiItem, "UISprite"), spriteNameList[i])
    end
    MyTest.MyUIProxy:GridReposition(uiGrid)
    MyTest.MyUIProxy:ScrollViewReposition(FindChild(window, "Scroll View"))
    local stopTime = os.clock()
    Debugger.Log('Performance Time is {0}', stopTime - startTime)
end
