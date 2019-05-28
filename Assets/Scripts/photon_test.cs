using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class photon_test :MonoBehaviour
{
    public GameObject text_obj;
    public GameObject btn;
    bool flag=true;
    void Start() {
       
        
        
    }
    
    // ロビーに入ると呼ばれる
     void OnJoinedLobby(){
        Debug.Log("ロビーに入りました");
        /*
        //RoomOptionsのインスタンスを生成
        RoomOptions roomOptions = new RoomOptions();
        
        // ルームに入室できる最大人数。0を代入すると上限なし。
        roomOptions.MaxPlayers = 0;
        
        // ルームへの入室を許可するか否か
        roomOptions.IsOpen = true;
        
        // ロビーのルーム一覧にこのルームが表示されるか否か
        roomOptions.IsVisible = true;
        
        // 名前空間(ExitGames.Client.Photon)内のHashtableクラスのインスタンスを生成して
        ExitGames.Client.Photon.Hashtable roomHash = new ExitGames.Client.Photon.Hashtable();
        
        // 設定したいカスタムプロパティを、キーと値のセットでAdd
        roomHash.Add("Time", 0);
        roomHash.Add("MapCode", 1);
        roomHash.Add("Mode", "Easy");
        
        // ルームオプションにハッシュをセット
        roomOptions.CustomRoomProperties = roomHash; */
        
        // 第1引数はルーム名、第2引数はルームオプション、第3引数はロビーです。
        //PhotonNetwork.CreateRoom("RoomName", roomOptions, null);
    }
        
       /* private void OnJoinedRoom() {
            Debug.Log("ルームへ入室しました。");
            
            Debug.Log(PhotonNetwork.room.name);             // ルーム名
            Debug.Log(PhotonNetwork.room.playerCount);      // 現在人数
            Debug.Log(PhotonNetwork.room.maxPlayers);       // 最大人数
            Debug.Log(PhotonNetwork.room.open);             // 開放フラグ
            Debug.Log(PhotonNetwork.room.visible);          // 可視フラグ
            Debug.Log(PhotonNetwork.room.customProperties); // カスタムプロパティ
        } */
       
        
       public void click_func(){
           
               Text tex = text_obj.GetComponent<Text> ();  //text_objをtexに変換
               tex.text = "Now Loading";
               
               btn.SetActive(false);       //ボタンを無効化
               // photon接続
               PhotonNetwork.ConnectUsingSettings (null);
               //PhotonNetwork.playerName = "morita";
              
               //デバックログを表示させるためコールチン
               StartCoroutine(sleep());
               
               
        
        }
       IEnumerator sleep(){
           yield return new WaitForSeconds(3); //5秒待つ
           SceneManager.LoadScene("Lobby");
       }
       
       
        
       
}
