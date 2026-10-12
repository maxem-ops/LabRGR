using System;

namespace DevicesLibrary
{
    public class Device
    {
        private decimal _price;

        public string Brand { get; set; }
        public string Model { get; set; }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Цена не может быть отрицательной.");
                _price = value;
            }
        }

        public Device() : this("Unknown", "Unknown", 0m) { }

        public Device(string brand, string model, decimal price)
        {
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Model = model ?? throw new ArgumentNullException(nameof(model));
            Price = price;
        }

        public override string ToString()
        {
            return $"Устройство: {Brand} {Model}, цена: {Price} руб.";
        }
    }
}