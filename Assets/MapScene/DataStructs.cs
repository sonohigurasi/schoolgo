using UnityEngine;
using System.Collections;
using System;

struct LocationCoordinate {
    public float 
        longitude, //経度
        latitude; //緯度

    public LocationCoordinate(float longitude, float latitude) {
        this.longitude = longitude;
        this.latitude = latitude;
    }

    //2点間の距離を得る(単位:km)
    static double DistanceLocations(LocationCoordinate location1, LocationCoordinate location2) {
        float deltaX = Math.Abs(location1.longitude - location2.longitude);
        float R = 6378.137f; //地球の半径
        var distance = R * Math.Acos(Math.Sin(location1.latitude) * Math.Sin(location2.latitude) +
            Math.Cos(location1.latitude) * Math.Sin(location2.latitude) * Math.Cos(deltaX));
        return distance;
    }

    //2点間の角度を得る
    static double AngleLocations(LocationCoordinate location1, LocationCoordinate location2) {
        float deltaX = Math.Abs(location1.longitude - location2.longitude);
        var angle = 90.0 - Math.Atan2(Math.Sin(deltaX),
            Math.Cos(location1.latitude) * Math.Tan(location2.latitude) -
             Math.Sin(location1.latitude) * Math.Cos(deltaX));
        return angle;
    }
}

struct QuestInfo {
    int questID;
    string questName;
    string questDescription;
    DateTime startTime, endTime; //クエストの出現開始時刻と終了時刻
}

struct QuestPlaceInfo {
    LocationCoordinate location;
    QuestInfo questInfo;
}

/*
public class DataStructs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/