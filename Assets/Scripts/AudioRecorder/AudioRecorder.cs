using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRecorder {

    private bool isRecording = false;
    private AudioClip recording;
    private float startRecordingTime;

    public bool recordAudio()
    {
        bool recordedSuccessfully = false;

        if (!isRecording)
        {
            Debug.Log("Attempting to record");
            //Get the max frequency of a microphone, if it's less than 44100 record at the max frequency, else record at 44100
            int minFreq;
            int maxFreq;
            int freq = 44100;

            string[] availableMics = Microphone.devices;
            if (availableMics.Length < 1)
            {
                Debug.Log("There is no available mic to record with.");
                return false;
            }

            Microphone.GetDeviceCaps("", out minFreq, out maxFreq);
            if (maxFreq < 44100)
                freq = maxFreq;

            //Start the recording, the length of 300 gives it a cap of 5 minutes
            recording = Microphone.Start("", false, 300, freq);
            startRecordingTime = Time.time;
            isRecording = true;
            recordedSuccessfully = true;
        }
        else
        {
            Debug.Log("We are already recording.  Stop the previosu recording before starting a new one.");
        }

        return recordedSuccessfully;
    }

    // Returns the filepath for the recording or null if there was no recording
    public string stopRecording()
    {
        string recordingFilePath = null;

        if (isRecording)
        {
            Debug.Log("Attempting to stop record");
            //End the recording, then play it
            Microphone.End("");
            isRecording = false;

            //Trim the audioclip by the length of the recording
            AudioClip recordingNew = AudioClip.Create(recording.name, (int)((Time.time - startRecordingTime) * recording.frequency), recording.channels, recording.frequency, false);
            float[] data = new float[(int)((Time.time - startRecordingTime) * recording.frequency)];
            recording.GetData(data, 0);
            recordingNew.SetData(data, 0);
            this.recording = recordingNew;

            // Save the audio file as a wav file
            string fileName = "myfile";
            string filePath = SavWav.Save(fileName, recording);

            Debug.Log("This is the filepath:  " + filePath);

            recordingFilePath = filePath;

        } else
        {
            Debug.Log("There is no current recording.");
        }

        return recordingFilePath;
    }

}
