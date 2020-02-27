using System.ComponentModel;
using System.Windows;

namespace CSharp_Vanin_02.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}