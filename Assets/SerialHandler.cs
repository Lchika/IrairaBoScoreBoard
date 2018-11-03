using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using UnityEngine.SceneManagement;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

	//public string portName = "/dev/tty.usbserial-AI045S5Q"; // ポート名(Macだと/dev/tty.usbmodem1421など)
	public string portName = "/dev/tty.usbserial-A7043RK5"; // pro mini
    public int baudRate = 115200;  // ボーレート(Arduinoに記述したものに合わせる)

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private byte[] buff = new byte[1];
    private bool isNewMessageReceived_ = false;

	public static SerialHandler singleton;

	public bool[] is_added_event = new bool[2];

	public enum SceneStateE : int
	{
		sceneStateNone = 0,
		sceneStateRanking,
		sceneStateWaitingStart,
		sceneStatePlaying,
		sceneStateResult,
		sceneStateAppreciate,

	}

	private static SceneStateE scene_state = SceneStateE.sceneStateNone;

    void Awake()
    {
		//　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
		if (singleton == null) {
			DontDestroyOnLoad (gameObject);
			singleton = this;
			Open();
			is_added_event [0] = false;
			is_added_event [1] = false;
		//　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
		} else {
			Destroy (this);
		}
    }

    void Update()
    {
        if (isNewMessageReceived_)
        {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
    }

    void OnDestroy()
    {
        //Close();
    }

    private void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
        //または
        //serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();
        Debug.Log("Serial Port Open!");

        isRunning_ = true;

        thread_ = new Thread(new ThreadStart(Read));
        thread_.Start();
    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive)
        {
            thread_.Join();
            thread_ = null;
        }

        if (serialPort_ != null && serialPort_.IsOpen)
        {
            serialPort_.Close();
            serialPort_.Dispose();
            Debug.Log("Serial Port Close!");
        }
    }

    private void Read()
    {
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
        {
            //Debug.Log("Read Serial Port!");
			if (serialPort_.BytesToRead > 0) {
				try {
					//message_ = serialPort_.ReadLine();
					serialPort_.Read (buff, 0, 1);
					//ASCII エンコード
					message_ = System.Text.Encoding.ASCII.GetString (buff);
					Debug.Log ("Read Serial Massage, " + message_);
					isNewMessageReceived_ = true;
					this.Write(message_);
				} catch (System.Exception e) {
					Debug.LogWarning (e.Message);
				}
			}
        }
    }

    public void Write(string message)
    {
        try
        {
            serialPort_.Write(message);
			Debug.Log ("Write Serial Massage, " + message);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

	public void SetSceneState(SceneStateE state){
		scene_state = state;
	}

	public SceneStateE getSceneState(){
		return scene_state;
	}
}