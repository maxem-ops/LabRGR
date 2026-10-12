using System;

namespace DevicesLibrary
{
    public class TV : Device
    {
        private int _screenSize;

        public int ScreenSize
        {
            get => _screenSize;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Диагональ должна быть положительной.");
                _screenSize = value;
            }
        }

        public bool IsSmart { get; set; }

        public TV() : this("Unknown", "Unknown", 0m, 32, false) { }

        public TV(string brand, string model, decimal price, int screenSize, bool isSmart)
            : base(brand, model, price)
        {
            ScreenSize = screenSize;
            IsSmart = isSmart;
        }

        public override string ToString()
        {
            return $"Телевизор: {Brand} {Model}, диагональ {ScreenSize}\", цена {Price} руб., Smart TV: {(IsSmart ? "да" : "нет")}";
        }
    }
}