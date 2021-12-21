using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData {
    public static int WeekNo = 1;
    public static int BlockNumber = 9;
    public static int Selections { get; set; }          // The number of selections for this trial
    public static int ScreenNo = 27;                    // The current instructions screen no
    public static string AvatarImageName { get; set; }
    public static int SelectionCount { get; set; }
    public static string ParticipantID = "adsa";
    public static float SpreadSpacing = 40;
    public static float NarrowSpacing = 4;
    public static bool isSpread { get; set; }
    public static float gridCellSize { get; set; }
    public static string FormFName { get; set; }
    public static string LogFName = "";
    public static string MailerFilename { get; set; }
    public static string ARecordingPath { get; set; }
    public static bool isReturnFromEnd = false;         //Set to true at the end of the game and is ues to decided wheter to play the audio when the opening menu is loaded
    public static bool isSendingMail { get; set; }      //  Set in InitializeVariables and used in MailerCheck and LoadingCircle
    public static bool isErrorSendingMail { get; set; } //  Set in InitializeVariables and used LoadingCircle

    //  Used to remove the references to anxiety in week one screen 1 & 2 if set true
    public static bool isV2 = true;

    //  For Debug Purposes
    public static bool isDebugMode = true;
    public static bool is1Trial = true;         //  Used to make each block only last 1 trial

    //  Baloon Game  //
    public static int goodClipCounter = 0;
    public static int calmClipCounter = 0;
    public static int bothClipCounter = 0;
    public static int neverClipCounter = 0;

}
