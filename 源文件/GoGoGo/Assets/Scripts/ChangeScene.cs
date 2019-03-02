using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class ChangeScene : MonoBehaviour {

    [DllImport("Gesture_DLL")]
    private static extern void StartDevice(char[] addr);
    // Use this for initialization
    void Start () {
        //通过dll打开摄像头
        char[] s = { 'h', 'h' };
        StartDevice(s);

        //设置按钮切换场景
        GameObject btnObj = GameObject.Find("Button");
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.GoNextScene(btnObj);
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //切换场景到游戏界面
    public void GoNextScene(GameObject NScene)
    {
        SceneManager.LoadScene("Main");
    }
}
