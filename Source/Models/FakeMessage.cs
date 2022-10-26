using System.Collections.Generic;

namespace Source.Models;

public class FakeMessage
{
    public static List<string> FakeM()
    {
        List<string> list = new()
        {
            "Hello",
            "How are you?",
            "I am good",
            "Thank you",
            "Nice to meet you",
            "Good bye",
            "OK",
            "NO",
            "YES",
            "See you soon",
            "Good night",
            "Bye bye!!"
        };
        return list;
    }
}
