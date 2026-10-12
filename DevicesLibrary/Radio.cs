using System;

namespace DevicesLibrary
{
    public class Radio : Device
    {
        public string FrequencyRange { get; set; }
        public bool BatteryPowered { get; set; }

        public Radio() : this("Unknown", "Unknown", 0m, "FM", false) { }

        public Radio(string brand, string model, decimal price, string frequencyRange, bool batteryPowered)
            : base(brand, model, price)
        {
            FrequencyRange = frequencyRange ?? throw new ArgumentNullException(nameof(frequencyRange));
            BatteryPowered = batteryPowered;
        }

        public override string ToString()
        {
            return $"Радиоприёмник: {Brand} {Model}, диапазон {FrequencyRange}, цена {Price} руб., питание от батарей: {(BatteryPowered ? "да" : "нет")}";
        }
    }
}