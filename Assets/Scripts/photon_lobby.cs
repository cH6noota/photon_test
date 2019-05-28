    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class photon_lobby : MonoBehaviour
{
    //public GameObject text_obj;
    //public GameObject make_btn;
    public GameObject join_btn;
    bool flag = true;
    
    void Start(){
        if (PhotonNetwork.GetRoomList().Length == 0)
        {
            Debug.LogWarning("部屋なし");
            join_btn.SetActive(false);
        }
        
    }
    
    
    void OnJoinedRoom() {
        
        if (flag){
            Debug.Log("部屋を作成しました");
        }
        else{
            Debug.Log("ルームへ入室しました。");
            Debug.Log(PhotonNetwork.room.name);
        }
        SceneManager.LoadScene("MainScene_photon");
    }
    
   public void click_make(){
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
        roomOptions.CustomRoomProperties = roomHash; 
        
        // 第1引数はルーム名、第2引数はルームオプション、第3引数はロビーです。
        PhotonNetwork.CreateRoom("RoomName", roomOptions, null);
        PhotonNetwork.playerName="macPC";
        
    }
    public void click_join(){
        flag=false;
        PhotonNetwork.playerName = "macPC";
        //PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.JoinRoom("RoomName");
    }
    
    
    
    
}
