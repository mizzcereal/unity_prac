using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class MusicSheet : MonoBehaviour
{
    private int measure = 0;
    private float measureTime = 0f;
    private int maxMeasureNumber = 0;
    private int bpm = 0;


    [SerializeField] private SelectMenu selectMenu;

    [SerializeField] Text txtSongName = null;
    [SerializeField] Text txtComposerName = null;

    [SerializeField] Image backgroundSongImage = null;
    [SerializeField] Image musicSheetImage = null;

    public void ShowMusicSheetSongInfo(Song song)
    {
        // gameObject.SetActive(true);
        txtSongName.text = song.name;
        txtComposerName.text = song.composer;
        backgroundSongImage.sprite = song.sprite;
        musicSheetImage.sprite = song.musicSheetSprite;
        if (song.musicXMLFile != null)
        {
            ParseMusicXML(song.musicXMLFile.text);
        }
        else
        {
            Debug.LogError("MusicXML file is not assigned.");
        }
    }

    // xml파일에서 bpm 및 노트 정보를 가져옴
    void ParseMusicXML(string xmlContent)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlContent);

        XmlNode readBpm = xmlDoc.SelectSingleNode("//direction-type/metronome");
        if (readBpm != null)
        {
            string beatUnit = readBpm.SelectSingleNode("beat-unit")?.InnerText;
            this.bpm = (int)float.Parse(readBpm.SelectSingleNode("per-minute")?.InnerText ?? "0");

            Debug.Log("BPM: " + this.bpm + " (beat unit: " + beatUnit + ")");
        }
        else
        {
            Debug.LogError("bpm정보가 없습니다.");
        }

        XmlNodeList readMeasureNumber = xmlDoc.SelectNodes("//measure");
        foreach (XmlNode measureNode in readMeasureNumber)
        {
            XmlAttribute attribute = measureNode.Attributes["number"];
            if (attribute != null)
            {
                int measureNumber;
                if (int.TryParse(attribute.Value, out measureNumber))
                {
                    maxMeasureNumber = Mathf.Max(maxMeasureNumber, measureNumber);
                }
            }
        }
        Debug.Log("가장 큰 measure 번호: " + maxMeasureNumber);
    }

    void Update()
    {
        
        measureTime += Time.deltaTime;

        if(bpm == 60)
        {
            if(measureTime >= 4.0f)
            {
                measureTime = 0f;
                measure++;
                Debug.Log("Measure :" + measure);
                if (measure % 4 == 0) // Check if measure is a multiple of 4
                {
                    transform.position += new Vector3(0f, 50f, 0f);
                }
            }
        }
        else if (bpm == 100) // Condition for bpm == 100
        {
            if (measureTime >= 2.4f) // Adjusted condition for bpm == 100
            {
                measureTime = 0f;
                measure++;
                Debug.Log("Measure: " + measure);
                if (measure % 4 == 0) // Check if measure is a multiple of 4
                {
                    transform.position += new Vector3(0f, 50f, 0f);
                }
            }
        }

        if(measure == maxMeasureNumber)
        {
            Debug.Log("measure : " + maxMeasureNumber + "에 도착");
        }
        
    }

}
