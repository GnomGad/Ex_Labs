using System;
using System.Text;
/// <summary>
/// NameTV - название тв NameArtist Фамилия ведущего  Assest - оценка от 1 до 5  Type это тип И-игровая А-аналитическая Т-ток-шоу
/// </summary>
public struct GetTvshow
{
    public string NameTV;
    public string NameArtist;
    public ValueOfTV Value;
    public char Type;
    public int n;

    public void ShowTheme()
    {
        Console.WriteLine(new string('-',77));
        Console.WriteLine("|{0,-75}|", " Телепередачи");
        Console.WriteLine(new string('-', 77));
        Console.WriteLine("| {0,-29}| {1,-19} | {2,-7} | {3,-5} | {4,-3}|", "Передача", "Ведущий", "Рейтинг", "Тип","№");
    }

    public void ShowThis()
    {
        Console.WriteLine(new string('-', 77));
        Console.WriteLine("| {0,-29}| {1,-19} | {2,-7} | {3,-5} | {4,-3}|", NameTV, NameArtist, (int)Value, Type,n);
    }
    
    public void ShowStatement()
    {
        Console.WriteLine(new string('-', 77));
        Console.WriteLine("| {0,-74}|", "Перечисляемый тип: И - игровая; А - аналитическая; Т – ток-шоу");
        Console.WriteLine(new string('-', 77));
    }
    public void check_for_value(string value, out string er)
    {
        er = "good";
        if (Int32.Parse(value) == 1) Value = ValueOfTV.one;
        else if (Int32.Parse(value) == 2) Value = ValueOfTV.two;
        else if (Int32.Parse(value) == 3) Value = ValueOfTV.three;
        else if (Int32.Parse(value) == 4) Value = ValueOfTV.four;
        else if (Int32.Parse(value) == 5) Value = ValueOfTV.five;
        else er = "error";
    }
    public void check_for_value_non_set_value(string value, out string er)
    {
        er = "good";
        if (!(Int32.Parse(value) >= 1 && Int32.Parse(value) <=5))   
            er = "error"; 
       
    }
    public void check_for_tyoe(char value, out string er)
    {
        er = "good";
        if (value == 'A' || value == 'А') Type = 'А';
        else if (value == 'T' || value == 'Т') Type = 'Т';
        else if (value == 'I' || value == 'И') Type = 'И';
        else er = "error";
    }
    public void check_for_tyoe_non_set_type(char value, out string er)
    {
        er = "good";
        if (value == 'A' || value == 'А') er = "good"; 
        else if (value == 'T' || value == 'Т') er = "good"; 
        else if (value == 'I' || value == 'И') er = "good"; 
        else er = "error";
    }
}

public struct LogActions
{
   public string Telepered;
    ForLogAction Action;// действие адд делит упдейт
    DateTime Time;
   
    /// <summary>
    ///  Тип действия и время
    /// </summary>
    /// <param name="action"></param>
    /// <param name="time"></param>
    public void addlog(string telepered, ForLogAction action,DateTime time)
    {
        Telepered = telepered;
        Action = action;
        Time = time;
    }


    public void showlog()
    {
        string txt = Telepered;
        string text= "";
        if (Action == ForLogAction.Add) text = "Пользователь добавил телепередачу \""+txt+"\"";
        else if (Action == ForLogAction.Delete) text = "Пользователь удалил телепередачу \"" + txt + "\"";
        else if (Action == ForLogAction.Update) text = "Пользователь обновил телепередачу \"" + txt + "\"";
        Console.WriteLine("{0:00}:{1:00}:{2:00}  -  {3}",Time.Hour,Time.Minute,Time.Second,text);
    }
}
public struct BigSpan
{
     TimeSpan ts;
   public  DateTime timelast;
    public void timebigtest(DateTime timenow)
    {
        if (timenow.Subtract(timelast) > ts)
        {
            ts = timenow.Subtract(timelast);
            timelast = timenow;
        }

    }
    public void showtime()
    {
        Console.WriteLine("{0:00}:{1:00}:{2:00}  -  {3}", ts.Hours, ts.Minutes, ts.Seconds, "Самый долгий период бездействия пользователя"); ;
    }
}
public enum ValueOfTV
{
    one =1,
    two,
    three,
    four,
    five
}
public enum ForLogAction
{ 
    Add,
    Delete,
    Update,
 
}
