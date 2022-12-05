namespace Лаба4_CSharp_
{
    public class InputCtrl
    {
        private static InputCtrl _instance;
        public static InputCtrl Instance => _instance ??= new InputCtrl();

        private const string nums = "0123456789.,";
        private readonly char[] separateDate = { '/', '.', ',' };

        public string[] ChechProduct()
        {
            string[] correctInput = { "", "", "", "", "", "" };

            correctInput[0] = Input(20, Mode.NoCheck, 0);   //Name
            correctInput[1] = Input(6, Mode.Num, 24);       //Weight
            correctInput[2] = Input(6, Mode.Num, 32);       //Price
            correctInput[3] = Input(6, Mode.Num, 40);       //Num
            correctInput[4] = Input(8, Mode.Date, 56);      //EndDate
            correctInput[5] = Input(5, Mode.Bool, 88);      //Sale

            return correctInput;
        }

        private string Input(int lenField, Mode mode, int targetPos)
        {
            string str = "";
            while (str == "" || str.Length > lenField || !ChechSym(str, mode))
            {
                Console.SetCursorPosition(targetPos, 1);
                Console.Write(ProizvStr(" ", Console.BufferWidth - 1 - targetPos));
                Console.SetCursorPosition(targetPos, 1);
                str = Console.ReadLine();
            }
            return str;
        }

        public string ProizvStr(string str, int num)
        {
            string s = str;
            for (int i = 0; i < num; i++)
            {
                s += str;
            }
            return s;
        }

        private bool ChechSym(string str, Mode mode)
        {
            switch (mode)
            {
                case Mode.NoCheck:
                    return true;

                case Mode.Num:
                    foreach (char sym in str)
                    {
                        if (!nums.Contains(sym))
                            return false;
                    }
                    return true;

                case Mode.Date:
                    string[] numsDate = str.Split(separateDate,
                        options: StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    try
                    {
                        foreach (char sym in numsDate[0])
                        {
                            if (!nums.Contains(sym))
                                return false;
                        }
                        int day = int.Parse(numsDate[0]);
                        if (day < 0 || day > 31)
                            return false;

                        foreach (char sym in numsDate[1])
                        {
                            if (!nums.Contains(sym))
                                return false;
                        }
                        int month = int.Parse(numsDate[1]);
                        if (month < 0 || month > 12)
                            return false;

                        foreach (char sym in numsDate[2])
                        {
                            if (!nums.Contains(sym))
                                return false;
                        }
                        return true;
                    }

                    catch
                    {
                        return false;
                    }

                case Mode.Bool:
                    if (str.ToLower() == "true" || str.ToLower() == "false")
                        return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        private enum Mode
        {
            NoCheck,
            Num,
            Date,
            Bool
        }
    }
}
