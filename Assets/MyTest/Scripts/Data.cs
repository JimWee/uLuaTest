using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {
    List<string> labelNameList = new List<string>();
    List<string> spriteNameList = new List<string>();
    string[] spriteNames = new string[] { "Orc Armor - Shoulders", "Orc Armor - Bracers", "Orc Armor - Boots" };

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 100; i++)
        {
            labelNameList.Add(string.Format("UILabel{0}", i));
            spriteNameList.Add(spriteNames[i % 3]);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public List<string> GetLabelNameList()
    {
        return labelNameList;
    }

    public List<string> GetSpriteNameList()
    {
        return spriteNameList;
    }
}
