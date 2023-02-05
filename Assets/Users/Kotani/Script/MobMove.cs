using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// UniRxの参照
using UniRx;

public class MobMove : MonoBehaviour
{
    private float IntervalTime;

    [SerializeField]
    private GameObject RouteObj;

    private List<GameObject> route = new List<GameObject>();
    
    [SerializeField]
    private int speed;

    [SerializeField]
    private float StayTime;

    private int i=1;
    // 起動時処理
    void Start()
    {
        IntervalTime=0.00001f;
        RouteListSet();
        this.transform.position = route[0].transform.position;
        MobMoveRoute();
    }

    float StopTime=0;
    void MobMoveRoute()
    {
        // 10秒ごとに実行（Timerかつ第一引数に 0 指定の場合、Subscribe後に即座に1回目の処理が実行される）
        Observable.Timer(System.TimeSpan.Zero, System.TimeSpan.FromSeconds(IntervalTime))
            .Subscribe(x =>
            {
                //処理内容
                if(this.transform.position == route[i].transform.position)
                {
                    if(i < route.Count-1){i++;}
                    else{i=1;}
                    Debug.Log(i);
                    //var dt =transform.InverseTransformPoint(route[i].transform.position);
                    //Debug.Log(Mathf.Atan2 (dt.x, dt.y) * Mathf.Rad2Deg);
                }
                else{
                if(route[i].gameObject.name == "Stop"){//止める処理
                    StopTime+=Time.deltaTime;
                    if(StopTime >= StayTime){i++;StopTime=0;}
                }else{
                this.transform.position = 
                Vector3.MoveTowards(transform.position,route[i].transform.position, speed * Time.deltaTime);
                }
                }
            }
            ).AddTo(this);

        // 10秒ごとに実行（Intervalの場合、Subscribe後に待機時間を待機してから1回目の処理が実行される）
        Observable.Interval(System.TimeSpan.FromSeconds(IntervalTime))
            .Subscribe(x =>
            {
                //処理内容

                /*Debug.Log("Interval Time : " + Time.time + ", No : " + x.ToString() +
                    ", ThreadID : " + System.Threading.Thread.CurrentThread.ManagedThreadId);*/
            }
            ).AddTo(this);
    }

    void RouteListSet()
    {
        // 子オブジェクトを全て取得する
        foreach (Transform childTransform in RouteObj.transform)
        {
            route.Add(childTransform.gameObject);
        }
        route.Add(route[0]);
    }
}
