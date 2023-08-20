﻿using System.Globalization;
using System.IO;
using System.Net.Http;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Chat.Client.ViewModels;

namespace Chat.Client.Converter;

public class Base64Converter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is EditorModel model && model.EditorType == EditorType.Image)
        {
            return new Bitmap(new MemoryStream(System.Convert.FromBase64String(model.Content)));
        }

        if (value is string str)
        {
            try
            {
                if (str.StartsWith("avares://"))
                {
                    return new Bitmap(AssetLoader.Open(new Uri(str)));
                }

                if (str.StartsWith("base64://"))
                {
                    str = str.Replace("base64://", "");
                    return new Bitmap(new MemoryStream(System.Convert.FromBase64String(str)));
                }

                return new Bitmap(new MemoryStream(System.Convert.FromBase64String(str)));
            }
            catch
            {
                return value;
            }
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}