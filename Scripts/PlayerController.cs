using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameDirector director;


    // Start is called once before the first execution of Update after the MonoBehaviour is created]
    //ゲームが起動したら一番最初に一回だけ呼ばれるメッソド
    void Start()
    {
        //フレームレートを60に設定
        Application.targetFrameRate = 60;

        director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }

    // Update is called once per frame
    //一秒間に何回も高速で呼ばれるメソッド
    void Update()
    {

        //ゲームが止まっているときは何もしない
        if (director.stopFlag == true)
        {
            return;
        }


        //左矢印が押されたとき
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //playerを左に「3」動かす
            transform.Translate(-3, 0, 0);

        }

        //右矢印が押されたとき
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //playerを右に「3」動かす
            transform.Translate(3, 0, 0);
        }

       
        
    }
}
