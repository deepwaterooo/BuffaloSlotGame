using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ref: https://stackoverflow.com/questions/45876539/unity-infinite-loop-of-moving-sprites-slot-machine-reel
public class Reel : MonoBehaviour {

    public float reelHeight = 6.0f;
    public float symbolWidth = 1.5f;
    public float symbolHeight = 1.5f;

    public float reelXPos = 0f;
    public int reelSymbolHeight = 4;
    
    public float reelSpeed = 5f;
    public float fallTimer = 0.05f;
    
    [SerializeField]
    public GameObject symbol;

    public List<GameObject> symbols = new List<GameObject>();
    
    private bool inSpin = false;
    private float fallTime = 0f;
    private int cnt = 0;
    private Queue<int> idxQueue;
    private Dictionary<int, LinkedList<GameObject>> symbolDic;
    private int symbolIdx;
    private GameObject newSymbol;
    private float smoothing = 0.01f;
    private float adjustBottom = -1.5f;
    
    void Start() {
        int[] reelSymbols = new int[] {0, 1, 2, 3, 5, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 0, 1, 2, 3, 5, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        idxQueue = new Queue<int>();
        for (int i = 0; i < reelSymbols.Length; i++) {
            idxQueue.Enqueue(reelSymbols[i]);
        }
        symbolDic = new Dictionary<int, LinkedList<GameObject>>();
        
        //for (; symbolIdx < reelSymbols.Length; symbolIdx++) {
        for (; symbolIdx < reelSymbolHeight; symbolIdx++) {
        // for (int i = 0; i < 4; i++) {
        //for (int i = 0; i < reelSymbols.Length; i++) {
            if (idxQueue.Count > 0) {
                symbolIdx = idxQueue.Dequeue();
                symbol = Instantiate (symbol, new Vector3 (reelXPos, symbolIdx * symbolHeight + adjustBottom, 0), Quaternion.identity);
                symbol.GetComponent<Symbol>().symbolType = reelSymbols [symbolIdx];
                symbols.Add(symbol);   
            } 
            /*symbol = Instantiate (symbol, new Vector3 (reelXPos, i * symbolHeight + adjustBottom, 0), Quaternion.identity);
            symbol.GetComponent<Symbol>().symbolType = reelSymbols [i];
            symbols.Add(symbol);    */
        }
    }
    
    void Update () {
        if (inSpin && fallTime - fallTimer < 0.0001f) {
            foreach (GameObject symbol in symbols.ToArray()) {
                float currentReelSpeed = reelSpeed * Time.deltaTime;
                symbol.transform.Translate(Vector3.down * currentReelSpeed);

                if (symbol.transform.position.y > 3.5f * symbolHeight + adjustBottom) {
                    symbol.GetComponent<SpriteRenderer>().enabled = false;
                } else if (symbol.transform.position.y > 0f + adjustBottom && symbol.transform.position.y <= 3.5f * symbolHeight + adjustBottom) {
                    if (symbol.GetComponent<SpriteRenderer>().enabled == false) 
                        symbol.GetComponent<SpriteRenderer>().enabled = true;
                } else if (symbol.transform.position.y <= -1.0f * symbolHeight + adjustBottom) {
                    /*Vector3 currentPosition = symbol.transform.position;
                    currentPosition.y = (currentPosition.y + 1.0f * symbolHeight) + (symbols.Count - 1) * symbolHeight;
                    symbol.transform.position = currentPosition;    */

                    symbol.GetComponent<SpriteRenderer>().enabled = false; // 保存这些东西的目的是什么, 系统优化???
                    int idx = symbol.GetComponent<Symbol>().getIdx();
                    if (symbolDic.ContainsKey(idx)) {
                        LinkedList<GameObject> list = symbolDic[idx];
                        list.AddLast(symbol);
                        symbolDic[idx] = list;
                    } else {
                        LinkedList<GameObject> symbolList = new LinkedList<GameObject>();
                        symbolList.AddLast(symbol);
                        symbolDic[idx] = symbolList;
                    }
                    
                    // instantiate a new symbol, 是直接再生成新对象，还是直接索取对象池中已有的 ？？？
                    if (idxQueue.Count > 0) {
                        symbolIdx = idxQueue.Dequeue();
                        newSymbol = Instantiate (symbol, new Vector3 (reelXPos, 3f * symbolHeight + adjustBottom, 0), Quaternion.identity);
                        newSymbol.GetComponent<Symbol>().symbolType = symbolIdx;
                        symbols.Add(newSymbol);   
                    } 
                }
            }
            fallTime += Time.deltaTime;
        }
        if (inSpin && fallTime - fallTimer >= 0.0001f) {
            SpinReel(); // so far for one reel only 
        }
        cnt++;
    }

    public void SpinReel () {
        inSpin = !inSpin;
        if (inSpin) 
            fallTime = 0f;
        else
            FreezeSymbols();
    }

    public void FreezeSymbols() {
        foreach (GameObject symbol in symbols) {
            Vector3 currentPosition = symbol.transform.position;
            float y = currentPosition.y;
            if (y > 0f + adjustBottom && y <= 1f * symbolHeight + adjustBottom) {
                currentPosition.y = 0f;
            } else if (y > 1f * symbolHeight + adjustBottom && y <= 2f * symbolHeight + adjustBottom) {
                currentPosition.y = symbolHeight;
            } else if (y > 2f * symbolHeight + adjustBottom && y <= 3f * symbolHeight + adjustBottom) {
                currentPosition.y = 2f * symbolHeight;
            } else if (y > 3f * symbolHeight + adjustBottom && y <= 4f * symbolHeight + adjustBottom) {
                currentPosition.y = 3f * symbolHeight;
            } else if (symbol.transform.position.y <= -symbolHeight + adjustBottom) {
                //currentPosition = symbol.transform.position; // 原作者放错的位置
                currentPosition.y = (currentPosition.y + symbolHeight) + (symbols.Count - 1) * symbolHeight;
            }
            //symbol.transform.position = currentPosition;
            // 怎么才能平滑地回滚到指定的位置呢？
            symbol.transform.position = Vector3.Lerp(symbol.transform.position, currentPosition, smoothing * Time.deltaTime);
        }
    }
}
