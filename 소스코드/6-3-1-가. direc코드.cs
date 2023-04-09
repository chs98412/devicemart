using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

public class direc : MonoBehaviour
{
    DynamoDBContext context;
    AmazonDynamoDBClient DBclient;
    CognitoAWSCredentials credentials;
    Character c;
    public Camera a;
    public Text txt;
    private void Start() //AWS에 접속해서 인증받고 권한을 받아오는 단
    {
        UnityInitializer.AttachToGameObject(this.gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:ceafc145-14a2-4c03-b397-22368bc8ab4f", RegionEndpoint.APNortheast2);
        DBclient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBclient);
        
        
    }

    [DynamoDBTable("character_info")]
    public class Character
    {
        [DynamoDBHashKey] // Hash key.
        public string id { get; set; }
        [DynamoDBProperty]
        public int item { get; set; }
    }

    

    public void FindItem() //DB에서 캐릭터 정보 받기
    {
        context.LoadAsync<Character>("leapmotion", (AmazonDynamoDBResult<Character> result) =>
        {
            // id가 leapmotion인 캐릭터 정보를 DB에서 받아옴
            if (result.Exception != null)
            {
                Debug.LogException(result.Exception);
                return;
            }
            c = result.Result;
            Debug.Log(c.item); //찾은 캐릭터 정보 중 아이템 정보 출력
        }, null);
    }

     void Update()
    {
       
        FindItem();
        if (c!=null)//앱 실행 후 초기화되는 aws에서 정보를 받아오는 변수이므로 받아온 정보가 null값인지를 먼저 확인한다.
        {
            if (c.item == 1234)
            {

                GameObject.Destroy(this.gameObject);
                SceneManager.LoadScene("realA");
            }
        }


        
    }





}

