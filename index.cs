using System;
using System.Collections.Generic;

public class Decodifier
{
    
    public static void Main()
    {
        string cryptographyMessage = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        string realMessage = getMessageDescribed(cryptographyMessage);
        
        Console.WriteLine(realMessage);
    }

    private static string getMessageDescribed(string message){
        List<string> binaries = ParseCryptographyMessage(message);
        string realMessage = BinToText(binaries);
        
        return realMessage;
    }
    
    private static string BinToText(List<string> binariesArray){
        char[] newMessage = new char[binariesArray.Count];
        
        for (int i = 0; i < binariesArray.Count; i++)
        {
            newMessage[i] = Convert.ToChar(Convert.ToInt32(binariesArray[i], 2));
        }

        return new string(newMessage);
    }
    
    private static List<string> ParseCryptographyMessage(string message) {
        List<string> messageSplited = splitMessage(message);
        List<string> newMessage = new List<string>();
        
        foreach(string item in messageSplited){
            string first = item.Substring(0,4);
            string second = item.Substring(4,2);
            
            string initialSecond = item.Substring(6,1) == "0" ? "1" : "0";
            string endSecond = item.Substring(7,1) == "0" ? "1" : "0";
            
            newMessage.Add($"{second}{initialSecond}{endSecond}{first}");
        }
        
        return newMessage;
    }
    
    
    private static List<string> splitMessage(string message) {
        List<string> messageSplited = new List<string>();
        
        int index = 0;
        
        foreach(char s in message){
            if(Char.IsWhiteSpace(s)){
                int end = 8;
                
                if(messageSplited.Count == 0) {
                    string firstItem = message.Substring(index - 8, end);
                    messageSplited.Add(firstItem);
                }
                
                int initial = index + 1;
                string item = message.Substring(initial, end);
                messageSplited.Add(item);
            }
            index++;
        }
        
        return messageSplited;
    }
}
