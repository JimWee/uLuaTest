using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIProxy : MonoBehaviour {

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}    

    public GameObject AttachUI(string name, GameObject parent)
    {
        GameObject obj = GameObject.Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        obj.transform.SetParent(parent.transform, false);
        return obj;
    }

    public void SetLabelText(GameObject uiLabel, string text) {
        UILabel label = uiLabel.GetComponent<UILabel>();
        label.text = text;
    }

    public void SetSprite(GameObject uiSprite, string spriteName)
    {
        UISprite sprite = uiSprite.GetComponent<UISprite>();
        sprite.spriteName = spriteName;
    }

    public void GridReposition(GameObject uiGrid)
    {
        UIGrid grid = uiGrid.GetComponent<UIGrid>();
        grid.Reposition();
    }

    public void ScrollViewReposition(GameObject uiScrollView)
    {
        UIScrollView scrollView = uiScrollView.GetComponent<UIScrollView>();
        scrollView.ResetPosition();
    }
}
