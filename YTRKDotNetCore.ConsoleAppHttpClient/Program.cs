using Newtonsoft.Json;


Console.WriteLine("Hello, World!");

string jsonStr = await File.ReadAllTextAsync("data.json");

var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);

foreach (var questions in model.questions)
{
    Console.WriteLine(questions.questionNo);
}


// (json to C#) or (C# to json)  ပြောင်းမယ်ဆိုရင် newtonsoft.json ဆိုတဲ့ package လိုပါတယ်

Console.ReadLine();


static string ToNumber(string num)
{
    num = num.Replace("၁","1")း;
    num = num.Replace("၂","2")း;
    num = num.Replace("၃","3")း;
    num = num.Replace("၄","4")း;
    num = num.Replace("၅","5")း;

    return num;
}

public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}
