using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITutorialTask
{
    /// <summary>
    /// チュートリアルのタイトルを取得する
    /// </summary>
    string GetTitle();

    /// <summary>
    /// 説明文を取得する
    /// </summary>
    string GetText();

    //ボタンを所得する
    bool GetNextButton();
    bool GetBackButton();

    /// <summary>
    /// チュートリアルタスクが設定された際に実行される
    /// </summary>
    void OnTaskSetting();

    /// <summary>
    /// 次のタスクに進めるかを判定する
    /// </summary>
    bool CheckTask();

    //次のタスクに進むときに行う処理
    void NextTask();

    /// <summary>
    /// 達成後に次のタスクへ遷移するまでの時間(秒)
    /// </summary>
    float GetTransitionTime();
}
