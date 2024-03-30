using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float spanSpeed = 30f;
    public float limitBorder = 50f;
    public float zoomSpeed = 5f;
    public float minHeight = 10f;
    public float maxHeight = 80f;
    
    public bool isCameraMove = true;


    // Update is called once per frame
    void Update()
    {

        if(GameController.gameFinished){
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            isCameraMove = !isCameraMove;
        }

        if(!isCameraMove){
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height)
        {
            if(transform.position.z >= limitBorder){
                return;
            }else{
                transform.Translate(Vector3.forward * spanSpeed * Time.deltaTime, Space.World);
            }
        }
       

        if (Input.GetKey("s") || Input.mousePosition.y <= limitBorder)
        {
            if(transform.position.z <= -limitBorder){
                return;
            }else{
                transform.Translate(Vector3.back * spanSpeed * Time.deltaTime, Space.World);
            }
        }


        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - limitBorder)
        {
            if(transform.position.x >= limitBorder){
                return;
            }else{
                transform.Translate(Vector3.right * spanSpeed * Time.deltaTime, Space.World);
            }
            
        }
 
        if (Input.GetKey("a") || Input.mousePosition.x <= limitBorder)
        {
            if(transform.position.x <= -limitBorder){
                return;
            }else{
                transform.Translate(Vector3.left * spanSpeed * Time.deltaTime, Space.World);
            }
        }



        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        Vector3 tmpPos = transform.position;
       

        tmpPos.y -= scrollValue * 300f * zoomSpeed * Time.deltaTime;
        float tmpY = tmpPos.y;
        tmpY = Mathf.Clamp(tmpY, minHeight, maxHeight);
        tmpPos.y = tmpY;
        transform.position = tmpPos;
    }
}
