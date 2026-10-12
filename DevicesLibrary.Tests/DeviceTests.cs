using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using DevicesLibrary;

public class DeviceTests
{
    [Fact]
    public void Device_Constructor_SetsProperties()
    {
        var device = new Device("Samsung", "Basic", 1000m);
        Assert.Equal("Samsung", device.Brand);
        Assert.Equal("Basic", device.Model);
        Assert.Equal(1000m, device.Price);
    }

    [Fact]
    public void TV_Constructor_SetsProperties()
    {
        var tv = new TV("Samsung", "QN90A", 120000m, 65, true);
        Assert.Equal("Samsung", tv.Brand);
        Assert.Equal("QN90A", tv.Model);
        Assert.Equal(120000m, tv.Price);
        Assert.Equal(65, tv.ScreenSize);
        Assert.True(tv.IsSmart);
    }

    [Fact]
    public void Radio_Constructor_SetsProperties()
    {
        var radio = new Radio("Sony", "ICF-P26", 2500m, "FM/AM", true);
        Assert.Equal("Sony", radio.Brand);
        Assert.Equal("ICF-P26", radio.Model);
        Assert.Equal(2500m, radio.Price);
        Assert.Equal("FM/AM", radio.FrequencyRange);
        Assert.True(radio.BatteryPowered);
    }

    [Fact]
    public void TV_ToString_ReturnsCorrectString()
    {
        var tv = new TV("Samsung", "QN90A", 120000m, 65, true);
        string result = tv.ToString();
        Assert.Equal("Телевизор: Samsung QN90A, диагональ 65\", цена 120000 руб., Smart TV: да", result);
    }

    [Fact]
    public void Radio_ToString_ReturnsCorrectString()
    {
        var radio = new Radio("Sony", "ICF-P26", 2500m, "FM/AM", true);
        string result = radio.ToString();
        Assert.Equal("Радиоприёмник: Sony ICF-P26, диапазон FM/AM, цена 2500 руб., питание от батарей: да", result);
    }

    [Fact]
    public void Polymorphism_ListOfDevice_CallsDerivedToString()
    {
        var devices = new List<Device>
        {
            new Device("Generic", "Basic", 1000m),
            new TV("LG", "C2", 90000m, 55, true),
            new Radio("Panasonic", "RF-2400", 3000m, "FM/AM", false)
        };

        string output = string.Join("\n", devices.Select(d => d.ToString()));

        Assert.Contains("Устройство: Generic Basic, цена: 1000 руб.", output);
        Assert.Contains("Телевизор: LG C2, диагональ 55\", цена 90000 руб., Smart TV: да", output);
        Assert.Contains("Радиоприёмник: Panasonic RF-2400, диапазон FM/AM, цена 3000 руб., питание от батарей: нет", output);
    }

    [Fact]
    public void Price_Setter_ThrowsOnNegative()
    {
        var device = new Device();
        Assert.Throws<ArgumentOutOfRangeException>(() => device.Price = -1);
    }

    [Fact]
    public void ScreenSize_Setter_ThrowsOnNonPositive()
    {
        var tv = new TV();
        Assert.Throws<ArgumentOutOfRangeException>(() => tv.ScreenSize = 0);
    }
}