using System;

namespace Codewars.TasksFromDiffSourses
{
    class WeatherForDay
    {
        private int Temperature { get;  set; }
        private int Atmosphere { get;  set; }
        private  WinterPower Winter { get; set; }
        private Rain RainForDay { get; set; }
        public WeatherForDay() { }
        public WeatherForDay(int Temperature, int Atmosphere, char Winter, char RainForDay)
        {
            this.Temperature = Temperature;
            this.Atmosphere = Atmosphere;
            this.Winter = new WinterPower(Winter);
            this.RainForDay = new Rain(RainForDay);
        }
        public void Input()
        {

        }
        public void Output()
        {

        }
        public override string ToString()
        {
            return Temperature.ToString()+ "C"+"\t"+
        }

    }
    class WinterPower
    {
        public char key { get; set; }
        public string value { get;  set; }
        public WinterPower()
        {

        }
        public WinterPower(char key)
        {
            this.key = key;
            switch (key)
            {
                case 't':
                    value = "тихо";
                    break;
                case '1':
                    value = "легенький";
                    break;
                case 'p':
                    value = "помірний";
                    break;
                case 's':
                    value = "сильний";
                    break;
                default:
                    Console.WriteLine("Invalid value");
                    break;
            }
        }
        public override string ToString()
        {
            return this.value;
        }
    }
    class Rain : WinterPower
    {
        public Rain(char key) : base(key)
        {

        }
    }
}
